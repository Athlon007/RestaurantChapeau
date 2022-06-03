using System.Collections.Generic;
using RestaurantModel;
using RestaurantDAL;

namespace RestaurantLogic
{
    public class MenuLogic
    {
        private MenuDao menuDao = new MenuDao();

        /// <summary>
        /// Returns the list of all available menu types at the moment.
        /// </summary>
        /// <returns>List of menu types.</returns>
        public List<MenuType> GetMenuTypes()
        {
            return menuDao.GetMenuTypes();
        }

        /// <summary>
        /// Returns the list of all categories that match the menu type.
        /// </summary>
        /// <param name="menuType">Lunch, Dinner or Drinks</param>
        /// <returns>List of menu categories.</returns>
        public List<MenuCategory> GetMenuCategories(MenuType menuType)
        {
            return menuDao.GetMenuCategories(menuType);
        }
    }
}
