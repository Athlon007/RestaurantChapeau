using System;
using System.Collections.Generic;
using System.Text;
using RestaurantDAL;
using RestaurantModel;

namespace RestaurantLogic
{
    public class ReservationService
    {
        ReservationDao reservationDb;
        public ReservationService()
        {
            //create connection to database
            reservationDb = new ReservationDao();
        }
        public bool IsReserved(int tableId)
        {
            return reservationDb.IsReserved(tableId);
        }

        //adding the user to the db
        public void AddToReservation(Reservation reservation)
        {
            reservationDb.AddToReservation(reservation);
        }       

        //getting the list of all reservations
        public List<Reservation> GetAllReservations()
        {
            List<Reservation> reservations= reservationDb.GetAllReservations();
            return reservations;
        }
        public void CancelReservation(Reservation reservation)
        {
            reservationDb.CancelReservation(reservation);
        }              
    }
}
