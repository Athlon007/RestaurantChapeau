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
            string query = $"select id from dbo.[Table]";
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
        public void OccupyTable(int tableId)
        {
            string query = $"UPDATE dbo.[Bill] SET status = @status where tableId = @tableId";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@status",1),
                new SqlParameter("@tableId",tableId)
            };
            ExecuteEditQuery(query, sqlParameters);
        }                       
    }
}
