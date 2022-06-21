using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantModel
{
    public class Reservation
    {
        public int reservationID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public bool isReserved { get; set; }
        public DateTime ReservationStart { get; set; }
        public int tableid { get; set; }
    }
}
