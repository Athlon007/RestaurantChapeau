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
        
        public void AddToReservation(string firstName, string lastName, string email,string isReserved, DateTime ReservationStart, string tableid)
        {

            string query = $"INSERT INTO dbo.[Reservation] (firstName, lastName, email, isReserved, ReservationStart, tableid) VALUES (@firstName, @lastName, @email, @isReserved, @ReservationStart, @tableid);";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@firstName", firstName),
                new SqlParameter("@lastName", lastName),
                new SqlParameter("@email", email),
                new SqlParameter("@isReserved", isReserved),
                new SqlParameter("@ReservationStart", ReservationStart),
                new SqlParameter("@tableid", tableid)
            };
            ExecuteEditQuery(query, sqlParameters);
        }
        //getting the reservation from the db by the email
        public Reservation GetReservationByTableId(int tableId)
        {
            string query = $"SELECT id, firstName, lastName, email, isReserved, ReservationStart, tableid FROM dbo.[Reservation] WHERE tableid = @tableid";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@tableid", tableId)
            };
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }
        //getting a list of all the reservation
        public List<Reservation> GetAllReservations()
        {
            string query = $"SELECT id, firstName, lastName, email, isReserved, ReservationStart, tableid FROM [Reservation]";
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
                    reservationID = int.Parse(dr["id"].ToString()),
                    firstName = (string)(dr["firstName"]),
                    lastName = (string)(dr["lastName"]),
                    email = (string)(dr["email"]),
                    isReserved = (bool)(dr["isReserved"]),
                    ReservationStart = (DateTime)(dr["ReservationStart"]),
                    tableid = int.Parse(dr["tableid"].ToString())
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
                reservation.reservationID = int.Parse(dr["id"].ToString());
                reservation.firstName = (string)(dr["firstName"]);
                reservation.lastName = (string)(dr["lastName"]);
                reservation.email = (string)(dr["email"]);
                reservation.isReserved = (bool)(dr["isReserved"]);
                reservation.ReservationStart = (DateTime)(dr["ReservationStart"]);
                reservation.tableid = int.Parse(dr["tableid"].ToString());
            }
            else
            {
                
            }
            return reservation;
        }
        public void CancelReservation(Reservation reservation)
        {
            string query = $"DELETE FROM dbo.[Reservation] WHERE id={reservation.reservationID}";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }
        public void isReserved(Reservation reservation)
        {
            string query = $"Select isReserved, tableid from Reservation where id={reservation.isReserved}, {reservation.tableid};";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }

        public bool TableHasBill(int tableId)
        {
            string query = $"Select status FROM [Bill] WHERE tableId={tableId}";
            return ReadTableHasBill(ExecuteSelectQuery(query));
        }

        private bool ReadTableHasBill(DataTable table)
        {
            if (table.Rows.Count == 0)
            {
                return false;
            }

            if (Convert.IsDBNull(table.Rows[0]["status"]))
            {
                return false;
            }

            return true;
        }
    }
}
