using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantModel
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public string Comment { get; set; }    
        public string MenuType { get; set; }  
        public OrderStatus Status { get; set; } 
        public OrderType OrderItemType { get; set; }
        public DateTime PlacedTime { get; set; }
        public DateTime FinishedTime { get; set; }  
        public int Table { get; set; }



    }

}
