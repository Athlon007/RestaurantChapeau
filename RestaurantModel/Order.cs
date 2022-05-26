using System;
using System.Collections.Generic;

namespace RestaurantModel
{
    public class Order
    {
        public int Id { get; set; } 
        public DateTime PlacedTime { get; set; }
        public List<MenuItem> Items { get; set; }
        public OrderStatus Status { get; set; } 
        public Bill Bill { get; set; } 
    }
}
