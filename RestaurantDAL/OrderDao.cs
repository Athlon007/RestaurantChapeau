using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using RestaurantModel;

namespace RestaurantDAL
{
    internal class OrderDao : BaseDao
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

        public List<MenuCategory> GetMenuCategories()
        {
            string query = "SELECT [id], [name] FROM dbo.MenuCategory;";
            return ReadMenuCategories(ExecuteSelectQuery(query));
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
                            "WHERE mi.categoryId = @CategoryId AND m.menuTypeId = @MenuTypeId";
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
    }
}
