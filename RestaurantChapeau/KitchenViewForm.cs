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
        private void DisplayListviewInformation()
        {
            orderService = new OrderLogic();
            List<Order> orders = new List<Order>();
            
            if (currentPanel == pnlKitchen_NewOrders)
            {
                foreach (Order order in orders)
                {
                    //clear the listview
                    listViewKitchen_CompleteOrders.Clear();

                    //create new listview item and add the items to the listview item
                    ListViewItem li = new ListViewItem(order.Id.ToString());
                    li.SubItems.Add(order.PlacedTime.ToString());

                    if (order.Status==0)
                    {
                        orderStatus=OrderStatus.NotStarted;
                        li.SubItems.Add(orderStatus.ToString());
                    }
                    //add listview items to the listview
                    listViewKitchen_ActiveOrder.Items.Add(li);  
                }
               
            }

        }

        private void KitchenViewForm_Load(object sender, EventArgs e)
        {
            currentPanel = pnlKitchen_CompleteOrders;
            pnlKitchen_CompleteOrders.Show();
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
    }
}
