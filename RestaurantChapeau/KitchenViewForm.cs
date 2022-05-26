using System;
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
       // private OrderStatus orderStatus;
        private Panel currentPanel;
        private OrderLogic orderService;
        public KitchenViewForm()
        {
            InitializeComponent();
            DisplayListviewInformation();
        }

        private void HidePanels()
        {
            pnlKitchen_NewOrders.Hide();
            pnlKitchen_CompleteOrders.Hide();
            pnlKitchen_ActiveOrder.Hide();
        }
        public void DisplayListviewInformation()
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

        private void KitchenViewForm_Load(object sender, EventArgs e)
        {
            HidePanels();
            currentPanel = pnlKitchen_NewOrders;
            pnlKitchen_NewOrders.Show();
        }

        private void btnKitchen_newOrders_Click(object sender, EventArgs e)
        {
            HidePanels();
            currentPanel = pnlKitchen_NewOrders;
            pnlKitchen_NewOrders.Show();
           
        }

        private void btnKitchen_ActiveOrder_Click(object sender, EventArgs e)
        {
            HidePanels();
            currentPanel = pnlKitchen_ActiveOrder;
            pnlKitchen_ActiveOrder.Show();

        }
        private void btnKitchen_CompleteOrders_Click(object sender, EventArgs e)
        {
            HidePanels();
            pnlKitchen_CompleteOrders.Show();
        }

        private void listViewNewOrders_Click(object sender, EventArgs e)
        {
            HidePanels();
            pnlKitchen_ActiveOrder.Show();
            DisplayOrderItems();
        }

        private void btn_readyOrder_Click(object sender, EventArgs e)
        {
            Order orderItem = (Order)listViewNewOrders.SelectedItems[0].Tag;

            orderItem.Status = OrderStatus.Preparing;

            orderService.UpdateOrderStatus(orderItem);
        }
        private void RemoveListViewItems()
        {
            foreach (ListViewItem item in listViewKitchen_ActiveOrder.Items)
                listViewKitchen_ActiveOrder.Items.Remove(item);
        }
    }
}
