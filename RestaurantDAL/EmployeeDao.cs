using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using RestaurantModel;

namespace RestaurantDAL
{   
    public class EmployeeDao : BaseDao
    {

        //adding a new user to the db
        public void AddToRegister(string firstName, string lastName, string email,string passwordHash, string passwordSalt)
        {

            string query = $"INSERT INTO [Employee] (firstName, lastName, email, passwordHash, passwordSalt) VALUES ('{firstName}', '{lastName}', '{email}', '{passwordHash}', '{passwordSalt}')";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }
        //getting the user from the db by the employeeName, in order to get the salt
        public Employee GetEmployeeByEmployeeName(string email)
        {
            string query = $"SELECT id, firstName, lastName, email, passwordHash, passwordSalt, employeeType FROM dbo.[Employee] WHERE email = @email";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@email", email)
            };
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }

        //getting a list of all the employees
        public List<Employee> GetAllEmployees()
        {
            string query = $"SELECT id, firstName, lastName, email, passwordHash, passwordSalt, employeeType FROM [Employee]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Employee> ReadTables(DataTable dataTable)
        {
            //create list to store the employees 
            List<Employee> employees = new List<Employee>();

            foreach (DataRow dr in dataTable.Rows)
            {
                //store each room with the following fields from the database
                Employee employee = new Employee()
                {
                    id = Convert.ToInt32(dr["id"]),
                    firstName = (string)(dr["firstName"]),
                    lastName = (string)(dr["lastName"]),
                    email = (string)(dr["email"]),
                    passwordHash = (string)(dr["passwordHash"]),
                    passwordSalt = (string)(dr["passwordSalt"])
                };
                if (!Convert.IsDBNull(dr["employeeType"]))
                {
                    employee.employeeType = (EmployeeType)Convert.ToInt32(dr["employeeType"]);
                }
                employees.Add(employee);
            }
            return employees;
        }

        private Employee ReadTable(DataTable dataTable)
        {
            // create object to store values
            Employee employee= new Employee();
            if (dataTable.Rows.Count > 0)
            {
                DataRow dr = dataTable.Rows[0];
                employee.id = Convert.ToInt32(dr["id"]);
                employee.firstName = (string)(dr["firstName"]);
                employee.lastName = (string)(dr["lastName"]);
                employee.email = (string)(dr["email"]);
                employee.passwordHash = (string)(dr["passwordHash"]);
                employee.passwordSalt = (string)(dr["passwordSalt"]);
                if (!Convert.IsDBNull(dr["employeeType"]))
                {
                    employee.employeeType = (EmployeeType)Convert.ToInt32(dr["employeeType"]);
                }
            }
            else
            {
                throw new Exception("There is no user with these credentials");
            }
            return employee;
        }       
    }
}
