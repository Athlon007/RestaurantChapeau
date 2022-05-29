using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantModel
{
    public class Employee
    {
        public int id;
        public string firstName;
        public string lastName;
        public string email;
        public string passwordHash;
        public string passwordSalt;
        public EmployeeType employeeType;
    }
}
