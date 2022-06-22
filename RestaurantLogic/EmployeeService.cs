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
        //getting the user by its username
        public Employee GetEmployeeByEmployeeID(string id, string enteredPassword)
        {
            //Employee employee = employeeDb.GetEmployeeByEmployeeID(id);
            HashWithSaltResult password = passwordHasher.HashWithKnownSalt(enteredPassword, employeeDb.GetSaltForEmployee(id), SHA256.Create());
            return  employeeDb.GetEmployeeByEmployeeAccount(id, password.Digest);

            //HashWithKnownSalt()
        }
    }
}
