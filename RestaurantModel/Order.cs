using System;

namespace RestaurantModel
{
    public class Order
    {
        public int Id { get; set; } 
        public DateTime PlacedTime { get; set; }
        public int Status { get; set; }
        public int Bill { get; set; } 
    }
}
