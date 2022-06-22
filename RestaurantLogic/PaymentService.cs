using System;
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
        public (Bill, List<Order>) GetBillAndOrders(int tableId)
        {
            (Bill bill, List<Order> orders) = paymentDb.GetBillAndOrders(tableId);
            return (bill: bill, orders: orders);
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
        public Bill CreateBill(int tableID)
        {
            return paymentDb.CreateBill(tableID);
        }
        
        public void CreatePayment(int billId, decimal amountPaid, string comment, decimal tip, int paymentType, int paymentNum)
        {
            paymentDb.CreatePayment(billId, amountPaid, comment, tip, paymentType, paymentNum);
        }

        public bool HasBill(int tableID)
        {
            return paymentDb.HasBill(tableID);
        }
    }
}
