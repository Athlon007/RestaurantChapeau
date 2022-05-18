using System;
using System.Collections.Generic;
using System.Text;
using RestaurantDAL;
using RestaurantModel;

namespace RestaurantLogic
{
    public class OrderLogic
    {
        private OrderDao orderDao;

        public OrderLogic()
        {
            orderDao = new OrderDao();
        }

        public List<MenuType> GetMenuTypes()
        {
            return orderDao.GetMenuTypes();
        }

        public List<MenuCategory> GetMenuCategories(MenuType menuType)
        {
            // TODO: Implement an SQL table that takes care of what category belongs to what type.
            return orderDao.GetMenuCategories(menuType);
        }

        public List<MenuItem> GetMenuItems(MenuType menuType, MenuCategory menuCategory)
        {
            return orderDao.GetMenuItems(menuType.Id, menuCategory.Id);
        }

        public MenuItem GetMenuItem(int itemId)
        {
            return orderDao.GetMenuItemById(itemId);
        }
    }
}
