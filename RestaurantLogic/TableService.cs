using System;
using System.Collections.Generic;
using System.Text;
using RestaurantModel;
using RestaurantDAL;


namespace RestaurantLogic
{
    public class TableService
    {
        TableDao tableDB;
        public TableService()
        {
            tableDB = new TableDao();
        }       
        public List<Table> GetTables()
        {
            return tableDB.GetTables();
        }      
        public void  OccupyTable(int tableId)
        {
             tableDB.OccupyTable(tableId);
        }       
    }
}
