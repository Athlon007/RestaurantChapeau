using System;
using System.Collections.Generic;
using RestaurantModel;
using System.Data;
using System.Data.SqlClient;

namespace RestaurantDAL
{
    public class MenuDao : BaseDao
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
    }
}
