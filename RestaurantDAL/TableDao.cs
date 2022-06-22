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
        public int GetNumberOfTables()
        {
            string query = $"select count(id) AS count from dbo.[Table]";
            return ReadTableCount(ExecuteSelectQuery(query));
        }
        private Table ReadTable(DataTable dataTable)
        {
            // create object to store values
            Table table = new Table();
            if (dataTable.Rows.Count > 0)
            {
                DataRow dr = dataTable.Rows[0];
                table.Id = Convert.ToInt32(dr["id"]);
                table.isOccupied = (bool)(dr["isReserved"]);
            }
            else
            {
                throw new Exception("There is error while loading table");
            }
            return table;
        }
        public void OccupyTable(int tableId)
        {
            string query = $"UPDATE dbo.[Table] SET IsOccupied = @IsOccupied where id = @id";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("id",tableId),
                new SqlParameter("IsOccupied",1)
            };
             ExecuteEditQuery(query, sqlParameters);
        }
        public bool IsOccupied(int tableId)
        {
            string query = $"select IsOccupied from dbo.[Table] where id = @id And IsOccupied = @IsOccupied";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("id",tableId),
                new SqlParameter("IsOccupied",1)
            };
            return ReadStatusOfTable(ExecuteSelectQuery(query, sqlParameters));
        }
        private bool ReadStatusOfTable(DataTable dataTable)
        {
            bool status= false;
            foreach (DataRow dr in dataTable.Rows)
            {
                 status = (bool)dr["IsOccupied"];
            }
            return status;
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
                throw new Exception("There is error while loading table");
            }
            return number;
        }
    }
}
