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
        public int GetTheNumberOfTable()
        {
            return tableDB.GetNumberOfTables();
        }
        public bool IsOccupied(int tableId)
        {
            return tableDB.IsOccupied(tableId);
        }
        public Table OccupyTable(int tableId)
        {
            return tableDB.OccupyTable(tableId);
        }
    }
}
