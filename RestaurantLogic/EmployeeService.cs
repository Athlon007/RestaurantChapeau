using System;
using System.Collections.Generic;
using System.Text;
using RestaurantModel;
using RestaurantDAL;

namespace RestaurantLogic
{
    public class EmployeeService
    {
        EmployeeDao employeeDb;
        public EmployeeService()
        {
            //create connection to database
            employeeDb = new EmployeeDao();
        }
        //adding the user to the db
        public void AddToRegister(string firstName, string lastName,string email, string passwordHash, string passwordSalt)
        {
            employeeDb.AddToRegister(firstName, lastName,email, passwordHash, passwordSalt);
        }
        //getting the user by its username
        public Employee GetEmployeeByEmployeeName(string employeeName)
        {
            return employeeDb.GetEmployeeByEmployeeName(employeeName);
        }

        //getting the list of all users
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = employeeDb.GetAllEmployees();
            return employees;
        }
    }
}
