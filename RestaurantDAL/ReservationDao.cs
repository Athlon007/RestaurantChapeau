using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RestaurantModel;
using RestaurantDAL;
using System.Data;

namespace RestaurantDAL
{
    public class ReservationDao : BaseDao
    {
        //adding a new reservation to the db
        public void AddToReservation(string firstName, string lastName, string email, DateTime ReservationStart, int tableid)
        {

            string query = $"INSERT INTO dbo.[Reservation] (firstName, lastName, email, ReservationStart, tableid) VALUES ('{firstName}', '{lastName}', '{email}', '{ReservationStart}', '{tableid}')";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }
        //getting the reservation from the db by the email
        public Reservation GetReservationByEmail(string email)
        {
            string query = $"SELECT firstName, lastName, email, passwordHash, passwordSalt FROM dbo.[Reservation] WHERE email = @email";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@email", email)
            };
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }
        //getting a list of all the reservation
        public List<Reservation> GetAllReservations()
        {
            string query = $"SELECT firstName, lastName, email, isReserved, ReservationStart, tableid FROM [Reservation]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        private List<Reservation> ReadTables(DataTable dataTable)
        {
            //create list to store the employees 
            List<Reservation> reservations= new List<Reservation>();

            foreach (DataRow dr in dataTable.Rows)
            {
                //store each room with the following fields from the database
                Reservation reservation= new Reservation()
                {
                    firstName = (string)(dr["firstName"]),
                    lastName = (string)(dr["lastName"]),
                    email = (string)(dr["email"]),
                    isReserved = (bool)(dr["isReserved"]),
                    ReservationStart = (DateTime)(dr["ReservationStart"]),
                    tableid = (int)(dr["tableid"])
                };
                reservations.Add(reservation);
            }
            return reservations;
        }

        private Reservation ReadTable(DataTable dataTable)
        {
            // create object to store values
            Reservation reservation = new Reservation();
            if (dataTable.Rows.Count > 0)
            {
                DataRow dr = dataTable.Rows[0];
                reservation.firstName = (string)(dr["firstName"]);
                reservation.lastName = (string)(dr["lastName"]);
                reservation.email = (string)(dr["email"]);
                reservation.isReserved = (bool)(dr["isReserved"]);
                reservation.ReservationStart = (DateTime)(dr["ReservationStart"]);
                reservation.tableid = (int)(dr["tableid"]);
            }
            else
            {
                throw new Exception("There is no user with these credentials");
            }
            return reservation;
        }
    }
}
