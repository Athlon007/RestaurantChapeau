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
        public void AddToRegister(string firstName, string lastName, string id,string passwordHash, string passwordSalt)
        {

            string query = $"INSERT INTO [Employee] (firstName, lastName, email, passwordHash, passwordSalt) VALUES ('{firstName}', '{lastName}', '{id}', '{passwordHash}', '{passwordSalt}')";
            SqlParameter[] sqlParameters = new SqlParameter[0];                       
            ExecuteEditQuery(query, sqlParameters);
        }
        //getting the user from the db by the employeeName, in order to get the salt
        public Employee GetEmployeeByEmployeeAccount(string account, string hashedPassword)
        {
            string query = $"SELECT id, firstName, lastName, email, employeeType FROM dbo.[Employee] WHERE email = @email AND passwordHash = @passwordHash";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@email", account),
                new SqlParameter("@passwordHash", hashedPassword)
            };
            Employee employee = ReadTable(ExecuteSelectQuery(query, sqlParameters));
            if (employee == null)
            {
                throw new Exception(" YOur pass is wrong");
            }
            return employee;
        }
        public String GetSaltForEmployee(string account)
        {
            string query = $"SELECT passwordSalt FROM dbo.[Employee] WHERE email = @email";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@email",account)
            };
            string salt = ReadSalt(ExecuteSelectQuery(query, sqlParameters));
            if (salt == null)
            {
                throw new Exception("There is no user with this  email");
            }
            return salt;
        }
        private string ReadSalt(DataTable dataTable)
        {
            string salt=null;
            foreach (DataRow dr in dataTable.Rows)
            {
                 salt = (string)dr["passwordSalt"];
            }
            return salt;
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
                if (!Convert.IsDBNull(dr["employeeType"]))
                {
                    employee.employeeType = (EmployeeType)Convert.ToInt32(dr["employeeType"]);
                }
            }
            else
            {
                employee = null;
            }
            return employee;
        }       
    }
}
