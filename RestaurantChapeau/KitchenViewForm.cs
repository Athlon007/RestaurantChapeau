﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RestaurantLogic;
using RestaurantDAL;
using RestaurantModel;

namespace RestaurantChapeau
{
    public partial class KitchenViewForm : Form
    {
        private OrderLogic orderService;
        public KitchenViewForm()
        {
            InitializeComponent();
            DisplayOrders();
            Timer();
        }

       
        public void DisplayOrders()
        {
            orderService = new OrderLogic();
            List<Order> orders = orderService.GetOrdersToPrepare();

            //clear the listview
            listViewNewOrders.Items.Clear();
            foreach (Order order in orders)
            {
                //create new listview item and add the items to the listview item
                ListViewItem li = new ListViewItem(order.Id.ToString());
                li.SubItems.Add(order.PlacedTime.ToString());
                li.SubItems.Add(order.Status.ToString());
                li.Tag = order;

                //add items to the listview
                listViewNewOrders.Items.Add(li);
            }
        }
        private void DisplayOrderItems()
        {
            //extract order item from the selected item in the listview
            Order orderItem = (Order)listViewNewOrders.SelectedItems[0].Tag;

            lblKitchenn_OrderNo.Text=orderItem.Id.ToString();
            
            // select from database which items have the order id of the id stated in the listview
            List<MenuItem> orderMenuItems = orderService.GetOrderFoodItems(orderItem.Id);

            // delete all the items in the listview before adding new ones
            RemoveListViewItems();

            //foreach item in the list acquired from the db, add the name to the active order 
            foreach (MenuItem item in orderMenuItems)
            {
                ListViewItem li = new ListViewItem(item.Name.ToString());
                li.SubItems.Add(item.Quantity.ToString());

                listViewKitchen_ActiveOrder.Items.Add(li);
            }
           
        }

        #region Select item in new orders list view
        private void listViewNewOrders_Click(object sender, EventArgs e)
        {
            HidePanels();
            pnlKitchen_ActiveOrder.Show();
            DisplayOrderItems();
        }
        #endregion

        #region Load Kitchen View
        private void KitchenViewForm_Load(object sender, EventArgs e)
        {
            HidePanels();
            pnlKitchen_NewOrders.Show();
        }
        #endregion

        #region New Order button
        private void btnKitchen_newOrders_Click(object sender, EventArgs e)
        {
            HidePanels();
            pnlKitchen_NewOrders.Show();    
        }
        #endregion

        #region Active order button
        private void btnKitchen_ActiveOrder_Click(object sender, EventArgs e)
        {
            HidePanels();
            pnlKitchen_ActiveOrder.Show();
        }
        #endregion

        #region Complete Orders button 
        private void btnKitchen_CompleteOrders_Click(object sender, EventArgs e)
        {
            HidePanels();
            pnlKitchen_CompleteOrders.Show();
        }
        #endregion


        #region Ready Order Button
        private void btn_readyOrder_Click(object sender, EventArgs e)
        {
            Order orderItem = (Order)listViewNewOrders.SelectedItems[0].Tag;

            orderItem.Status = OrderStatus.Preparing;

            orderService.UpdateOrderStatus(orderItem);
            listViewKitchen_CompleteOrders.Items.Add(orderItem.Id.ToString()); ;
         
        }
        #endregion

        #region Hide Panels
        private void HidePanels()
        {
            pnlKitchen_NewOrders.Hide();
            pnlKitchen_CompleteOrders.Hide();
            pnlKitchen_ActiveOrder.Hide();
        }
        #endregion

        #region Remove ListviewItems
        private void RemoveListViewItems()
        {
            foreach (ListViewItem item in listViewKitchen_ActiveOrder.Items)
                listViewKitchen_ActiveOrder.Items.Remove(item);
        }
        #endregion

        private void Timer()
        {
            timer1 = new Timer();
            timer1.Interval = (10 * 1000); // 30 secs
            timer1.Tick += new EventHandler(timer1_Tick_1);
            timer1.Start();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            
            
        }
    }
}
