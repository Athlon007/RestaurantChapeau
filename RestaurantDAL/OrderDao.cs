using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using RestaurantModel;

namespace RestaurantDAL
{
    public class OrderDao : BaseDao
    {
        /// <summary>
        /// Returns the list of all menu items for specific menu type and category.
        /// </summary>
        /// <param name="menuTypeId">Menu type ID.</param>
        /// <param name="menuCategoryId">Menu category ID.</param>
        public List<MenuItem> GetMenuItems(int menuTypeId, int menuCategoryId)
        {
            string query =  "SELECT mi.[id], mi.[name], mi.priceBrutto, v.vat, mi.isDrink " +
                            "FROM MenuItem mi " +
                            "JOIN Vat v ON v.id = mi.vatId " +
                            "JOIN Menu m ON m.menuItemId = mi.id " +
                            "WHERE mi.categoryId = @CategoryId AND m.menuTypeId = @MenuTypeId;";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CategoryId", menuCategoryId),
                new SqlParameter("@MenuTypeId", menuTypeId)
            };
            return ReadMenuItems(ExecuteSelectQuery(query, parameters));
        }

        public List<MenuItem> ReadMenuItems(DataTable table)
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            foreach (DataRow dr in table.Rows)
            {
                MenuItem item = ReadMenuItem(dr);
                menuItems.Add(item);
            }

            return menuItems;
        }

        /// <summary>
        /// Returns the menu item by its ID.
        /// </summary>
        /// <param name="itemId">Item ID.</param>
        public MenuItem GetMenuItemById(int itemId)
        {
            string query = "SELECT mi.[id], mi.[name], mi.priceBrutto, v.vat, mi.isDrink " +
                            "FROM MenuItem mi " +
                            "JOIN Vat v ON v.id = mi.vatId " +
                            "WHERE mi.[id] = @ItemId;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ItemId", itemId)
            };


            DataTable table = ExecuteSelectQuery(query, parameters);
            if (table.Rows.Count == 0)
            {
                return null;
            }

            return ReadMenuItem(table.Rows[0]);
        }

        private MenuItem ReadMenuItem(DataRow row)
        {
            if (row == null)
            {
                throw new NoNullAllowedException("Menu item not found!");
            }

            MenuItem menuItem = new MenuItem();
            menuItem.Id = Convert.ToInt32(row["id"]);
            menuItem.Name = (string)row["name"];
            menuItem.PriceBrutto = Convert.ToDecimal(row["priceBrutto"]);
            menuItem.Vat = Convert.ToDecimal(row["vat"]);
            if (!Convert.IsDBNull(row["isDrink"]))
            {
                menuItem.IsDrink = Convert.ToBoolean(row["isDrink"]);
            }

            return menuItem;
        }

        /// <summary>
        /// Registers a new order in database and returns it at the same time.
        /// </summary>
        /// <returns>Returns a new order.</returns>
        public Order CreateNewOrderForBill(Bill bill, string comment)
        {
            string query =  "INSERT INTO dbo.[Order] (placedTime, status, billId, comment) " +
                            "OUTPUT Inserted.[id], Inserted.placedTime, Inserted.status, Inserted.billId, Inserted.comment " +
                            "VALUES (@Now, 0, @BillId, @Comment)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Now", DateTime.Now.ToString("yyyyMMdd HH:mm:ss")),
                new SqlParameter("@BillId", bill.Id),
                new SqlParameter("@Comment", comment)
            };

            return ReadOrder(ExecuteEditAndSelectQuery(query, parameters).Rows[0], bill);
        }

        private Order ReadOrder(DataRow row, Bill bill)
        {
            Order order = new Order();
;
            order.Id = Convert.ToInt32(row["id"]);
            order.PlacedTime = Convert.ToDateTime(row["placedTime"]);
            order.Status = (OrderStatus)Convert.ToInt32(row["status"]);
            order.Bill = bill;
            if (row.Table.Columns.Contains("comment") && !Convert.IsDBNull(row["comment"]))
            {
                order.Comment = Convert.ToString(row["comment"]);
            }

            return order;
        }

        /// <summary>
        /// Adds a new item to an order.
        /// </summary>
        /// <param name="order">Order to add the item to.</param>
        /// <param name="item">Item to add.</param>
        /// <param name="quantity">Quantity of that item.</param>
        public void AddItemToOrder(Order order, MenuItem item, int quantity)
        {
            string query = "INSERT INTO dbo.PartOf (orderId, menuItemId, quantity)" +
                            "VALUES (@OrderId, @ItemId, @Quantity)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderId", order.Id),
                new SqlParameter("@ItemId", item.Id),
                new SqlParameter("@Quantity", quantity)
            };

            ExecuteEditQuery(query, parameters);
        }

        /// <summary>
        /// Returns the list of orders that are either not started, or being prepared with all the items.
        /// </summary>
        public List<Order> GetOrdersToPrepare()
        {
            string query = "SELECT o.[id], o.placedTime, o.status " +
                            "FROM[Order] o " +
                            "WHERE o.status <= 1;";

            DataTable tableOrders = ExecuteSelectQuery(query);
            List<Order> orders = new List<Order>();
            foreach (DataRow row in tableOrders.Rows)
            {
                Order order = ReadOrder(row, null);

                // Get all items belonging to that order.
                string selectItemsQuery =   "SELECT mi.id, mi.name, mi.priceBrutto, po.quantity, v.vat, mi.isDrink " +
                                            "FROM PartOf po " +
                                            "JOIN MenuItem mi ON po.menuItemId = mi.id " +
                                            "JOIN Vat v ON mi.vatId = v.id " +
                                            "WHERE orderId = @OrderId AND mi.isDrink is null;";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@OrderId", order.Id)
                };

                order.Items = ReadMenuItems(ExecuteSelectQuery(selectItemsQuery, parameters));

                orders.Add(order);
            }

            return orders;
        }
        //Returns all the items in an order with a specific orderID
        public List<MenuItem> GetOrderFoodItems(int orderId)
        {
            string selectItemsQuery = "SELECT mi.id, mi.name, mi.priceBrutto, po.quantity, v.vat, mi.isDrink FROM PartOf po JOIN MenuItem mi ON po.menuItemId = mi.id JOIN Vat v ON mi.vatId = v.id WHERE orderId = @orderId AND mi.isDrink is null;";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderId", orderId)
            };

            return ReadMenuItems(ExecuteSelectQuery(selectItemsQuery, parameters));
        }
        
        /// <summary>
        /// Assigns order to specified employee.
        /// </summary>
        /// <param name="employee">Employee (bartender) to which the order is supposed to be assigned.</param>
        /// <param name="order">Order to be assigned.</param>
        public void RegisterOrderToBartender(Employee employee, Order order)
        {
            string query =  "INSERT INTO dbo.[Bartender] (employeeId, orderId) " +
                            "VALUES (@EmployeeId, @OrderId)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@EmployeeId", employee.id),
                new SqlParameter("@OrderId", order.Id)
            };

            ExecuteEditQuery(query, parameters);
        }

        public void UpdateOrderStatus(Order order)
        {
            string command = (
            "UPDATE dbo.[Order] SET status =@status  WHERE Id = @orderId");
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@status", order.Status),
                    new SqlParameter("@OrderId", order.Id)
            };
            ExecuteEditQuery(command, parameters);
        }

        /// <summary>
        /// Returns the list of orders for specified bill.
        /// </summary>
        /// <param name="bill">Bill which we want orders for.</param>
        public List<Order> GetOrdersForBill(Bill bill)
        {
            string query =  "SELECT o.id, o.placedTime, o.status, o.comment " +
                            "FROM [Order] o " +
                            "JOIN Bill b ON b.id = o.billId " +
                            "WHERE b.id = @BillId";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@BillId", bill.Id)
            };

            DataTable table = ExecuteSelectQuery(query, parameters);
            List<Order> orders = new List<Order>();
            foreach (DataRow row in table.Rows)
            {
                orders.Add(ReadOrder(row, bill));
            }

            return orders;
        }

        /// <summary>
        /// Returns the full list of all items belonging to a specified order.
        /// </summary>
        /// <param name="order">Order that we want to check the menu items of.</param>
        /// <returns></returns>
        public List<MenuItem> GetItemsForOrder(Order order)
        {
            string query =  "SELECT mi.id, mi.name, v.vat, mi.priceBrutto, mi.isDrink, po.quantity " +
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

                items.Add(item);
            }

            return items;
        }

        /// <summary>
        /// Checks if bill has any order.
        /// </summary>
        /// <param name="bill"></param>
        public bool HasBillOrders(Bill bill)
        {
            string query = "SELECT COUNT(o.id) [nOfItems] FROM [Order] o JOIN Bill b ON b.id = o.billId WHERE b.id = @BillId";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@BillId", bill.Id)
            };

            DataTable table = ExecuteSelectQuery(query, parameters);
            return Convert.ToInt32(table.Rows[0]["nOfItems"]) > 0;
        }
    }
}
