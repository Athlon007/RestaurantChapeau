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
        private OrderStatus orderStatus;
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

                //add items to the listview
                listViewNewOrders.Items.Add(li);
            }

        }
        private void DisplayOrderItems()
        {
           string orderItem= listViewNewOrders.SelectedItems.ToString();
           
            Order order=new Order();
            order.Id = orderItem[0];
            List<MenuItem> orderMenuItems= orderService.GetOrderFoodItems(order);
         
            foreach (MenuItem i in orderMenuItems)
            {
                //List<MenuItem> items = i.Items;

                foreach (MenuItem item in orderMenuItems)
                {
                    ListViewItem li = new ListViewItem(item.Name.ToString());

                    listViewKitchen_ActiveOrder.Items.Add(li);
                }
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
           listViewKitchen_ActiveOrder.Refresh();
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

        private void listViewNewOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            HidePanels();
            pnlKitchen_ActiveOrder.Show();
            DisplayOrderItems();

        }
    }
}
