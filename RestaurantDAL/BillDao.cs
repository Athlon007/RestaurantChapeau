using System;
using System.Collections.Generic;
using System.Text;
using RestaurantModel;
using System.Data;
using System.Data.SqlClient;

namespace RestaurantDAL
{
    public class BillDao : BaseDao
    {
        /// <summary>
        /// Creates a new ACTIVE bill and automatically assigns it to a table.
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public Bill CreateBill(Table table)
        {
            string query =  "INSERT INTO dbo.[Bill] (tableId, status) " +
                            "OUTPUT Inserted.[id], Inserted.tableId, Inserted.status " +
                            "VALUES (@TableId, 1)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TableId", table.Id)
            };

            return ReadBills(ExecuteEditAndSelectQuery(query, parameters))[0];
        }

        private List<Bill> ReadBills(DataTable table)
        {
            List<Bill> bills = new List<Bill>();
            foreach (DataRow dr in table.Rows)
            {
                Bill bill = new Bill();
                bill.Id = Convert.ToInt32(dr["id"]);
                bill.Status = Convert.ToInt32(dr["status"]) == 1;
                bill.Table = GetTableById(Convert.ToInt32(dr["tableId"]));
                bills.Add(bill);
            }

            return bills;
        }

        /// <summary>
        /// Returns a table by specified ID.
        /// </summary>
        /// <param name="id">Asked ID</param>
        public Table GetTableById(int id)
        {
            string query = "SELECT id FROM dbo.[Table] WHERE id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", id)
            };

            return ReadTable(ExecuteSelectQuery(query, parameters));
        }

        private Table ReadTable(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                throw new Exception("Table with specified ID does not exist.");
            }

            Table table = new Table();
            table.Id = Convert.ToInt32(dt.Rows[0]["id"]);
            return table;
        }
    }
}
