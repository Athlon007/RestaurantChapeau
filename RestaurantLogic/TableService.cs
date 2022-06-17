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
        public Table GetTableNumber(int id)
        {
            return tableDB.GetTableId(id);            
        }
    }
}
