﻿namespace RestaurantModel
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PriceBrutto { get; set; }
        public decimal Vat { get; set; }
        public int Quantity { get; set; }
    }
}
