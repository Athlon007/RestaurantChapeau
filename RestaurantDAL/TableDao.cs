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
        public List<Table> GetTables()
        {
            string query = $"select id, IsOccupied from dbo.[Table]";
            return ReadTable(ExecuteSelectQuery(query));
        }     
        private List<Table> ReadTable(DataTable dataTable)
        {
            // create object to store values
            List<Table> tables = new List<Table>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Table table = new Table()
                {
                    Id = int.Parse(dr["id"].ToString()),
                    isOccupied = (bool)(dr["IsOccupied"])
                };
                tables.Add(table);

            }
            return tables;
        }
        public void  OccupyTable(int tableId)
        {
            string query = $"UPDATE dbo.[Table] SET IsOccupied = @IsOccupied where id = @id";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("id",tableId),
                new SqlParameter("IsOccupied",1)
            };
             ExecuteEditQuery(query, sqlParameters);
        }
        public void MakeTableFree(int tableId)
        {
            string query = $"UPDATE dbo.[Table] SET IsOccupied = @IsOccupied where id = @id";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("id",tableId),
                new SqlParameter("IsOccupied",0)
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
    }
}
