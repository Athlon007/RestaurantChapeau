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
        public List<Order> GetOrders(bool complete, bool isDrink, OrderStatus maximumOrderStatus)
        {
            return orderDao.GetOrders(complete, isDrink, maximumOrderStatus);
        }

        /// <summary>
        /// Registers the provided order to bartender (employee).
        /// </summary>
        /// <param name="employee">Bartender to which the order will be assigned.</param>
        /// <param name="order">Order that will be assigned.</param>
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

        /// <summary>
        /// Returns the list of all orders for specified bill.
        /// </summary>
        /// <param name="bill">Bill which we want to check.</param>
        public List<Order> GetOrdersForBill(Bill bill)
        {
            return orderDao.GetOrdersForBill(bill);
        }

        /// <summary>
        /// Returns the full list of all items belonging to a specified order.
        /// </summary>
        /// <param name="order">Order that we want to check the menu items of.</param>
        /// <returns></returns>
        public List<MenuItem> GetItemsForOrder(Order order)
        {
            return orderDao.GetItemsForOrder(order);
        }

        public List<MenuItem> GetItemsToPrepareForOrder(Order order, bool isDrink)
        {
            return orderDao.GetItemsToPrepareForOrder(order, isDrink);
        }

        /// <summary>
        /// Checks if bill has any order.
        /// </summary>
        /// <param name="bill">Bill to check.</param>
        public bool HasBillOrders(Bill bill)
        {
            return orderDao.HasBillOrders(bill);
        }

        /// <summary>
        /// Updates the menu item quantity.
        /// </summary>
        /// <param name="item">Menu item to adjust.</param>
        public void SetItemQuantity(MenuItem item)
        {
            orderDao.SetItemQuantity(item);
        }

        public void SetOrderItemStatus(MenuItem item, Order order,bool isDrink)
        {
            orderDao.SetOrderItemStatus(item, order,isDrink);

            List<MenuItem> orderItems = GetItemsForOrder(order);
            foreach (MenuItem itemItem in orderItems)
            {
                if (itemItem.Status != OrderStatus.Served)
                {
                    return;
                }
            }

            order.Complete = true;
            UpdateOrderStatus(order);
        }
    }

}
