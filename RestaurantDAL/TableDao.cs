using System;
using System.Collections.Generic;
using System.Text;
using RestaurantModel;
using System.Data.SqlClient;
using System.Data;

namespace RestaurantDAL
{
    public class TableDao : BaseDao
    {
        public Table GetTableId(int id)
        {
            string query = $"SELECT id, activeBill FROM dbo.[Table] WHERE id = @id";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@id", id)
            };
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }
        public int GetNumberOfTables()
        {
            string query = $"select count(id) AS count from dbo.[Table]";
            SqlParameter[] sqlParameters = new SqlParameter[0];           
            return ReadTableCount(ExecuteSelectQuery(query, sqlParameters));
        }        
        private Table ReadTable(DataTable dataTable)
        {
            // create object to store values
            Table table = new Table();
            if (dataTable.Rows.Count > 0)
            {
                DataRow dr = dataTable.Rows[0];
                table.Id = Convert.ToInt32(dr["id"]);                
            }
            else
            {
                throw new Exception("There is no user with these credentials");
            }
            return table;
        }

        private int ReadTableCount(DataTable dataTable)
        {
            // create object to store values
            int number;
            if (dataTable.Rows.Count > 0)
            {
                DataRow dr = dataTable.Rows[0];
                number = Convert.ToInt32(dr["count"]);
            }
            else
            {
                throw new Exception("There is no user with these credentials");
            }
            return number;
        }
    }
}
