using System;

namespace RestaurantModel
{
    public class Payment
    {
        public int BillId { get; set; }
        public DateTime DateTime { get; set; }
        public decimal AmountPaid { get; set; }
        public string Comment { get; set; }
        public decimal Tip { get; set; }
    }
}