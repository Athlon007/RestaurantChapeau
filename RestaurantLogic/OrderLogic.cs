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
            //return orderDao.GetMenuCategories(menuType);

            List<MenuCategory> categories = orderDao.GetMenuCategories(menuType);
            List<MenuCategory> output = new List<MenuCategory>();

            foreach (MenuCategory category in categories)
            {
                if (menuType.Name == "Lunch")
                {
                    if (category.Id == 3 || category.Id >= 5)
                    {
                        continue;
                    }
                }
                else if (menuType.Name == "Dinner" && category.Id >= 5)
                {
                    continue;
                }
                else if (menuType.Name == "Drink" && category.Id < 5)
                {
                    continue;
                }

                category.MenuType = menuType;
                output.Add(category);
            }

            return output;
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
