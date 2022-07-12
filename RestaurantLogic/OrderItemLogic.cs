using System;
using System.Collections.Generic;
using System.Text;
using RestaurantModel;
using RestaurantDAL;

namespace RestaurantLogic
{
    public class OrderItemLogic
    {
        private OrderItemDAO orderItemDAO;
        public OrderItemLogic()
        {
            orderItemDAO = new OrderItemDAO();  
        }

        public List<OrderItem> GetAllOrderItems( OrderItem orderItem)
        {
            return orderItemDAO.GetAllOrderItems(orderItem);
        }
        public void SetOrderItemStatus(OrderItem item)
        {
            orderItemDAO.SetOrderItemStatus(item);
        }
    }
}
