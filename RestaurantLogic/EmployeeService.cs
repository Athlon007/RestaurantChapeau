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
