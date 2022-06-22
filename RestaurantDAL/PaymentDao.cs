using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using RestaurantModel;
using System.Globalization;

namespace RestaurantDAL
{
    public class PaymentDao : BaseDao
    {

        //getting all orders within the bill
        public List<Order> GetAllOrdersInBill(int billID)
        {
            string query = $"SELECT id, complete, comment from dbo.[Order] where billId = {billID}";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadOrderTable(ExecuteSelectQuery(query, sqlParameters));
        }
        //getting all items within the order
        public List<MenuItem> GetAllItemsInOrder(int orderID)
        {
            string query = $" SELECT dbo.MenuItem.id, name, dbo.Vat.vat AS vat, priceBrutto, CAST(CASE WHEN isDrink IS NULL THEN 0 ELSE 1 END AS BIT) AS isDrink, dbo.PartOf.quantity AS quantity FROM (dbo.MenuItem inner JOIN dbo.PartOf ON dbo.MenuItem.id = dbo.PartOf.menuItemId) INNER JOIN dbo.Vat on dbo.MenuItem.vatId = dbo.Vat.id where OrderId = {orderID}";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadItemTable(ExecuteSelectQuery(query, sqlParameters));
        }

        // getting a bill
        public Bill GetBill(int tableID)
        {
            string query = $"Select id, tableId from dbo.Bill where tableId = @tableId and status = @status";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@tableId",tableID),
                new SqlParameter("@status",1)
            };
            return ReadBillTable(ExecuteSelectQuery(query, sqlParameters));
        }

        public void UpdateBillStatus(int billID, int billStatus)
        {
            string query = $"UPDATE dbo.Bill SET status={billStatus} WHERE id={billID}";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }

        public Bill CreateBill(int tableID)
        {
            string query = $"INSERT INTO dbo.Bill(tableId, status) OUTPUT INSERTED.id, INSERTED.tableId, INSERTED.status VALUES(@tableId, @status);";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@tableId",tableID),
                new SqlParameter("@status",1)
            };
            return ReadBillTable(ExecuteEditAndSelectQuery(query, sqlParameters));
        }        
        public void CreatePayment(int billId, decimal amountPaid, string comment, decimal tip, int paymentType, int paymentNum)
        {
            string query = $"INSERT INTO dbo.Payment (billId, dateTime, amountPaid, comment, tip, paymentType, paymentNum) VALUES ({billId}, CURRENT_TIMESTAMP, {amountPaid},'{comment}', {tip}, {paymentType}, {paymentNum})";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }
        private List<Order> ReadOrderTable(DataTable dataTable)
        {
            //create list to store the orders 
            List<Order> orders = new List<Order>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Order order = new Order()
                {
                    Id = Convert.ToInt32(dr["id"]),
                    Complete = Convert.ToBoolean(dr["complete"]),
                    Comment = (string)(dr["comment"]),

                };

                orders.Add(order);
            }
            return orders;
        }
        private List<MenuItem> ReadItemTable(DataTable dataTable)
        {
            //create list to store the order items 
            List<MenuItem> items = new List<MenuItem>();

            foreach (DataRow dr in dataTable.Rows)
            {
                MenuItem item = new MenuItem()
                {
                    Id = Convert.ToInt32(dr["id"]),
                    Name = (string)dr["name"],
                    Vat = (decimal)dr["vat"],
                    PriceBrutto = (decimal)dr["priceBrutto"],
                    IsDrink = (bool)dr["isDrink"],
                    Quantity = Convert.ToInt32(dr["quantity"])
                };

                items.Add(item);
            }
            return items;
        }
        private Bill ReadBillTable(DataTable dataTable)
        {
            // create object to store values
            Bill bill = new Bill();
            Table table = new Table();
            if (dataTable.Rows.Count > 0)
            {
                DataRow dr = dataTable.Rows[0];
                table.Id = Convert.ToInt32(dr["tableId"]);
                bill.Id = Convert.ToInt32(dr["id"]);
                bill.Table = table;
            }
            else
            {
                throw new Exception("There is no Bill for this table");
            }
            return bill;
        }

        public bool HasBill(int tableID)
        {
            string query = $"Select id from dbo.Bill where tableId = @tableId and status = @status";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@tableId",tableID),
                new SqlParameter("@status",1)
            };
            return ExecuteSelectQuery(query, sqlParameters).Rows.Count > 0;
        }
    }
}
