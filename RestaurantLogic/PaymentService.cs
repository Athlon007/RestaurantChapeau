﻿using System;
using System.Collections.Generic;
using System.Text;
using RestaurantModel;
using RestaurantDAL;

namespace RestaurantLogic
{
    public class PaymentService
    {
        PaymentDao paymentDb;
        public PaymentService()
        {
            //create connection to database
            paymentDb = new PaymentDao();
        }
        //getting list of all orders within the bill
        public List<Order> GetAllOrdersInBill(int billID)
        {
            List<Order> orders = paymentDb.GetAllOrdersInBill(billID);
            return orders;
        }

        //getting list of all items within the order
        public List<MenuItem> GetAllItemsInOrder(int orderID)
        {
            List<MenuItem> items = paymentDb.GetAllItemsInOrder(orderID);
            return items;
        }
        // getting a bill
        public Bill GetBill(int tableID)
        {
            return paymentDb.GetBill(tableID);
        }

        //update bill status
        public void UpdateBillStatus(int billID, int billStatus)
        {
            paymentDb.UpdateBillStatus(billID, billStatus);
        } 
        
        public void CreatePayment(int billId, DateTime dateTime, decimal amountPaid, string comment, decimal tip)
        {
            paymentDb.CreatePayment(billId, dateTime, amountPaid, comment, tip);
        }

        public bool HasBill(int tableID)
        {
            return paymentDb.HasBill(tableID);
        }
    }
}
