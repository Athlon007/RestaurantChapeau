namespace RestaurantModel
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PriceBrutto { get; set; }
        public decimal Vat { get; set; }
        public int Quantity { get; set; }
        public bool IsDrink { get; set; }
        public int Stock { get; set; }
        public OrderStatus Status { get; set; }
    }
}
