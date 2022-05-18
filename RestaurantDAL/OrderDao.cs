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
            string query =  "SELECT mc.[id], mc.[name] " +
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
            string query =  "SELECT mi.[id], mi.[name], mi.priceBrutto, v.vat " +
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
                MenuItem item = new MenuItem();
                item.Id = Convert.ToInt32(dr["id"]);
                item.Name = (string)dr["name"];
                item.PriceBrutto = Convert.ToDecimal(dr["priceBrutto"]);
                item.Vat = Convert.ToDecimal(dr["vat"]);

                menuItems.Add(item);
            }

            return menuItems;
        }

        public MenuItem GetMenuItemById(int itemId)
        {
            string query = "SELECT mi.[id], mi.[name], mi.priceBrutto, v.vat " +
                            "FROM MenuItem mi " +
                            "JOIN Vat v ON v.id = mi.vatId " +
                            "WHERE mi.[id] = @ItemId;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ItemId", itemId)
            };

            return ReadMenuItem(ExecuteSelectQuery(query, parameters));
        }

        private MenuItem ReadMenuItem(DataTable table)
        {
            if (table.Rows.Count == 0)
            {
                throw new NoNullAllowedException("Menu item not found!");
            }

            MenuItem menuItem = new MenuItem();
            menuItem.Id = Convert.ToInt32(table.Rows[0]["id"]);
            menuItem.Name = (string)table.Rows[0]["name"];
            menuItem.PriceBrutto = Convert.ToDecimal(table.Rows[0]["priceBrutto"]);
            menuItem.Vat = Convert.ToDecimal(table.Rows[0]["vat"]);

            return menuItem;
        }

        /// <summary>
        /// Registers a new order in database and returns it at the same time.
        /// </summary>
        public Order CreateNewOrderForBill(Bill bill)
        {
            string query =  "INSERT INTO dbo.Order (placedTime, status, billId) " +
                            "OUTPUT Inserted.[id], Inserted.placedTime, Inserted.status, Inserted.billId " +
                            "VALUES (@Now, 0, @BillId)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Now", DateTime.Now.ToString("yyyyMMdd HH:mm:ss")),
                new SqlParameter("@BillId", bill.Id)
            };

            return ReadOrder(ExecuteSelectQuery(query, parameters), bill);
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

            return order;
        }
    }
}