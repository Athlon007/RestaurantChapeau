using System;
using System.Collections.Generic;
using System.Text;
using RestaurantModel;
using System.Data;
using System.Data.SqlClient;

namespace RestaurantDAL
{
    public class TableDao : BaseDao
    {
        public List<MenuItem> GetItemsForOrder(Order order)
        {
            string query = "SELECT mi.id, mi.name, v.vat, mi.priceBrutto, mi.isDrink, po.quantity, mi.stock " +
                            "FROM MenuItem mi " +
                            "JOIN Vat v on v.id = mi.vatId " +
                            "JOIN PartOf po ON po.menuItemId = mi.id " +
                            "WHERE po.orderId = @OrderId";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("OrderId", order.Id)
            };

            return ReadMenuItemsForOrder(ExecuteSelectQuery(query, parameters));
        }
        private List<MenuItem> ReadMenuItemsForOrder(DataTable table)
        {
            List<MenuItem> items = new List<MenuItem>();
            foreach (DataRow row in table.Rows)
            {
                MenuItem item = new MenuItem();
                item.Id = Convert.ToInt32(row["id"]);
                item.Name = row["name"].ToString();
                item.PriceBrutto = Convert.ToDecimal(row["priceBrutto"]);
                item.Vat = Convert.ToDecimal(row["vat"]);
                item.Quantity = Convert.ToInt32(row["quantity"]);
                if (!Convert.IsDBNull(row["isDrink"]))
                {
                    item.IsDrink = Convert.ToBoolean(row["isDrink"]);
                }
                if (!Convert.IsDBNull(row["stock"]))
                {
                    item.Stock = Convert.ToInt32(row["stock"]);
                }

                items.Add(item);
            }

            return items;
        }
    }

    
}
