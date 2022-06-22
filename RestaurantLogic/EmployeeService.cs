using System;
using System.Collections.Generic;
using System.Text;
using RestaurantModel;
using RestaurantDAL;
using System.Security.Cryptography;

namespace RestaurantLogic
{
    public class EmployeeService
    {
        EmployeeDao employeeDb;
        PasswordWithSaltHasher passwordHasher;
        public EmployeeService()
        {
            //create connection to database
            employeeDb = new EmployeeDao();
            passwordHasher = new PasswordWithSaltHasher();
        }

        //adding the user to the db
        public void AddToRegister(string firstName, string lastName, string id, string passwordHash, string passwordSalt)
        {
            employeeDb.AddToRegister(firstName, lastName, id, passwordHash, passwordSalt);
        }

        //getting the user by its username
        public Employee GetEmployeeByEmployeeID(string userName, string enteredPassword)
        {
            //Employee employee = employeeDb.GetEmployeeByEmployeeID(id);
            string storedSaltFromDatabase = employeeDb.GetSaltForEmployee(userName);
            HashWithSaltResult password = passwordHasher.HashWithKnownSalt(enteredPassword, storedSaltFromDatabase, SHA256.Create());
            return  employeeDb.GetEmployeeByEmployeeAccount(userName, password.Digest);
        }
    }
}
