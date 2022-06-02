using System.Collections.Generic;
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

        /// <summary>
        /// Returns the list of all available menu types at the moment.
        /// </summary>
        /// <returns>List of menu types.</returns>
        public List<MenuType> GetMenuTypes()
        {
            return orderDao.GetMenuTypes();
        }

        /// <summary>
        /// Returns the list of all categories that match the menu type.
        /// </summary>
        /// <param name="menuType">Lunch, Dinner or Drinks</param>
        /// <returns>List of menu categories.</returns>
        public List<MenuCategory> GetMenuCategories(MenuType menuType)
        {
            return orderDao.GetMenuCategories(menuType);
        }

        /// <summary>
        /// Returns all menu items belonging to specific menu type and category.
        /// </summary>
        /// <param name="menuType">Menu type to filter for (Lunch, Dinner, Drinks).</param>
        /// <param name="menuCategory">Menu category to filter for.</param>
        /// <returns>A list of menu items belonging to that type and category.</returns>
        public List<MenuItem> GetMenuItems(MenuType menuType, MenuCategory menuCategory)
        {
            return orderDao.GetMenuItems(menuType.Id, menuCategory.Id);
        }

        /// <summary>
        /// Returns the item from menu by its ID.
        /// </summary>
        /// <param name="itemId">Item ID to look-up.</param>
        /// <returns>A MenuItem object.</returns>
        public MenuItem GetMenuItem(int itemId)
        {
            return orderDao.GetMenuItemById(itemId);
        }

        /// <summary>
        /// Creates a new order for provided bill.
        /// </summary>
        /// <param name="bill">Bill for which the order will be created.</param>
        /// <param name="comment">Comment of the order.</param>
        /// <returns>A new order object.</returns>
        public Order CreateNewOrderForBill(Bill bill, string comment)
        {
            return orderDao.CreateNewOrderForBill(bill, comment);
        }

        /// <summary>
        /// Adds a new item to the order.
        /// </summary>
        /// <param name="order">Order to which add the item to.</param>
        /// <param name="item">Item that is meant to be added.</param>
        /// <param name="quantity">Quantity of the item.</param>
        public void AddItemToOrder(Order order, MenuItem item, int quantity)
        {
            orderDao.AddItemToOrder(order, item, quantity);
        }

        /// <summary>
        /// Returns the list of all orders that are either not started, or being prepared, with all of its items.
        /// </summary>
        public List<Order> GetKitchenOrdersToPrepare()
        {
            return orderDao.GetKitchenOrdersToPrepare();
        }

        public void RegisterOrderToBartender(Employee employee, Order order)
        {
            orderDao.RegisterOrderToBartender(employee, order);
        }
      
        public List<MenuItem> GetOrderItemsByID(int orderID)
        {
            return orderDao.GetOrderItemsByID(orderID);
        }

        public List<MenuItem> GetBarOrderItemsByID(int orderID)
        {
            return orderDao.GetBarOrderItemsByID(orderID);
        }
        public void UpdateOrderStatus(Order order)
        {
            orderDao.UpdateOrderStatus(order);
        }
        public Order GetOrderCommentByID(int orderID)
        {
            return orderDao.GetOrderCommentByID(orderID);
        }

        public Table GetOrderTable(int orderId)
        {
            return orderDao.GetOrderTable(orderId);
        }
    }

}
