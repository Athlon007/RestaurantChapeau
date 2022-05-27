﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using RestaurantModel;

namespace RestaurantDAL
{
    public class OrderDao : BaseDao
    {
        public List<MenuType> GetMenuTypes()
        {
            string query = "SELECT [id], [name] FROM dbo.MenuType;";
            return ReadMenuTypes(ExecuteSelectQuery(query));
        }

        private List<MenuType> ReadMenuTypes(DataTable table)
        {
            List<MenuType> menuTypes = new List<MenuType>();
            foreach (DataRow dr in table.Rows)
            {
                MenuType menuType = new MenuType();
                menuType.Id = Convert.ToInt32(dr["id"]);
                menuType.Name = dr["name"].ToString();

                menuTypes.Add(menuType);
            }

            return menuTypes;
        }

        public List<MenuCategory> GetMenuCategories(MenuType menuType)
        {
            string query = "SELECT mc.[id], mc.[name] " +
                            "FROM dbo.MenuCategory mc " +
                            "JOIN dbo.HasCategory hc ON mc.[id] = hc.menuCategoryId " +
                            "WHERE hc.menuTypeId = @MenuTypeId;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MenuTypeId", menuType.Id)
            };

            return ReadMenuCategories(ExecuteSelectQuery(query, parameters));
        }

        private List<MenuCategory> ReadMenuCategories(DataTable table)
        {
            List<MenuCategory> menuCategories = new List<MenuCategory>();
            foreach (DataRow dr in table.Rows)
            {
                MenuCategory menuCategory = new MenuCategory();
                menuCategory.Id = Convert.ToInt32(dr["id"]);
                menuCategory.Name = dr["name"].ToString();

                menuCategories.Add(menuCategory);
            }

            return menuCategories;
        }

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

            return ReadOrder(ExecuteEditAndSelectQuery(query, parameters), bill);
        }

        private Order ReadOrder(DataTable table, Bill bill)
        {
            Order order = new Order();

            if (table.Rows.Count == 0)
            {
                throw new NoNullAllowedException("Could not create a new order");
            }

            DataRow row = table.Rows[0];
            order.Id = Convert.ToInt32(row["id"]);
            order.PlacedTime = Convert.ToDateTime(row["placedTime"]);
            order.Status = (OrderStatus)Convert.ToInt32(row["status"]);
            order.Bill = bill;
            if (table.Columns.Contains("comment") && !Convert.IsDBNull(row["comment"]))
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
                Order order = ReadOrder(tableOrders, null);

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

    }
}
