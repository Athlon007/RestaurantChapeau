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

            string query = $"INSERT INTO [Employee] (firstName, lastName, email, passwordHash, passwordSalt) VALUES (@firstName, @lastName, @email, @passwordHash, @passwordSalt)";
            SqlParameter[] sqlParameters = new SqlParameter[5];
            {
                new SqlParameter("@firstName", firstName);
                new SqlParameter("@lastName", lastName);
                new SqlParameter("@email", email);
                new SqlParameter("@passwordHash", passwordHash);
                new SqlParameter("@passwordSalt", passwordSalt);
            };            
            ExecuteEditQuery(query, sqlParameters);
        }
        //getting the user from the db by the employeeName, in order to get the salt
        public Employee GetEmployeeByEmployeeID(string id)
        {
            string query = $"SELECT id, firstName, lastName, email, passwordHash, passwordSalt, employeeType FROM dbo.[Employee] WHERE email = @email";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@email", id)
            };
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
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
