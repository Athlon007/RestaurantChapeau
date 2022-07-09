using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using RestaurantModel;



namespace RestaurantDAL
{
    public class OrderItemDAO : BaseDao
    {
        public List<OrderItem> GetAllOrderItems(OrderItem orderItem)
        {
            try
            {
                string query = "Select mi.[name] as 'Name',orderId,menuItemId,quantity,po.[status],tableId,o.comment,placedTime,MenuCategory.name as 'menutype' " +
                    " from PartOf po " +
                    "join [Order] o  on po.orderId = o.id	" +
                    "join Bill on o.billId=bill.id" +
                    " join MenuItem mi on mi.id = po.menuItemId" +
                    " join MenuCategory on mi.categoryId = MenuCategory.id " +
                    "Where convert(Date,placedTime) = cast(GETDATE() as date) and isDrink=@orderItemType and po.[status] = @status";

                SqlParameter[] parameters = new SqlParameter[]
                {
                     new SqlParameter("@status", orderItem.Status),
                    new SqlParameter("@orderItemType", orderItem.OrderItemType)
                };
                return ReadOrderItems(ExecuteSelectQuery(query, parameters));
            }
            catch (Exception e)
            {
                throw new Exception($"There was a problem getting the order items: {e.Message}");
            }
        }
        private List<OrderItem> ReadOrderItems(DataTable table)
        {
            List<OrderItem> items = new List<OrderItem>();

            foreach (DataRow row in table.Rows)
            {
                OrderItem item = new OrderItem();
                item.OrderId = Convert.ToInt32((row["orderId"]));
                item.Id = Convert.ToInt32(row["menuItemId"]);
                item.Name = row["name"].ToString();
                item.MenuType = row["menutype"].ToString();
                item.Quantity = Convert.ToInt32((row["quantity"]));
                item.Comment = row["comment"].ToString();   
                item.Status = (OrderStatus)Convert.ToInt32(row["status"]);
                item.PlacedTime = Convert.ToDateTime(row["placedTime"]);
                item.Table = Convert.ToInt32((row["tableId"]));
                //add items to table 
                items.Add(item);
            }
            return items;

        }
    }
}
