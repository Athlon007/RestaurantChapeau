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
        //adding the user to the db
        public void AddToReservation(string firstName, string lastName, string email, DateTime ReservationStart, int tableid)
        {
            reservationDb.AddToReservation(firstName, lastName, email, ReservationStart, tableid);
        }
        //getting the reservation by its email
        public Reservation GetReservationByEmail(string email)
        {
            return reservationDb.GetReservationByEmail(email);
        }

        //getting the list of all reservations
        public List<Reservation> GetAllReservations()
        {
            List<Reservation> reservations= reservationDb.GetAllReservations();
            return reservations;
        }
    }
}
