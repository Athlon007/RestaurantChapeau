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
        // timer information
        int secs, mins, hours;
        bool IsActive;

        private Employee employee;

        public KitchenViewForm(Employee employee)
        {
            this.employee = employee;
            InitializeComponent();
            DisplayOrderItems(listview_NewOrders, OrderStatus.NotStarted);

            ResetTimer();
        }



        #region Display Order Items
        private void DisplayOrderItems(ListView listview, OrderStatus status)
        {
            OrderItemLogic orderItemLogic = new OrderItemLogic();
            
            //create new orderitem
            OrderItem item = new OrderItem();

            //these are used by the query to search for items that are not started and are food items 
            item.Status = status;

            // change the type of items to get depending on the employee that is logged in 
            switch (employee.employeeType)
            {
                case EmployeeType.KitchenStaff:
                    item.OrderItemType = OrderType.FoodItem;
                    break;
                case EmployeeType.Bartender:
                    item.OrderItemType = OrderType.Drink;
                    break;
                case EmployeeType.Waiter:
                    break;
                case EmployeeType.Manager:
                    break;
                default:
                    item.OrderItemType = OrderType.FoodItem;
                    break;
            }
            // get all the order items and save them to the list of the orderitems
            List<OrderItem> orderItems = orderItemLogic.GetAllOrderItems(item);
            // delete all the items in the listview before adding new ones
            RemoveListViewItems(listview_NewOrders);

            //foreach item in the list acquired from the db, add the name to the active order listview
            foreach (OrderItem orderItem in orderItems)
            {
                ListViewItem li = new ListViewItem(orderItem.OrderId.ToString());
                li.SubItems.Add(orderItem.Name.ToString());
                li.SubItems.Add(orderItem.Quantity.ToString());
                li.SubItems.Add(orderItem.MenuType.ToString());
                li.SubItems.Add(orderItem.Comment.ToString());
                li.SubItems.Add(orderItem.Table.ToString());
                li.SubItems.Add(orderItem.PlacedTime.TimeOfDay.ToString());
                li.SubItems.Add(orderItem.Status.ToString());
                li.Tag = orderItem;
                // add all items to the listview active order
                listview.Items.Add(li);
            }
        }
        #endregion



        #region Load Kitchen View
        private void KitchenViewForm_Load(object sender, EventArgs e)
        {
            HidePanels();
            pnl_newOrders.Show();
        }
        #endregion


        #region Hide Panels
        private void HidePanels()
        {
            // hide new orders panel
            pnl_completeOrders.Hide();
            pnl_newOrders.Hide();
        }
        #endregion

        #region Remove ListviewItems
        private void RemoveListViewItems(ListView listView)
        {
            foreach (ListViewItem item in listView.Items)
                listView.Items.Remove(item);
        }
        #endregion

        #region Timer
        private void Timer()
        {
            lbl_Mins.Text = mins.ToString(":00");
            lbl_Secs.Text = secs.ToString(":00");
            lbl_Hours.Text = hours.ToString("00");
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (IsActive)
            {
                secs++;
                if (secs >= 60)
                {
                    mins++;
                    secs = 0;
                    if (mins == 60)
                    {
                        hours++;
                        mins = 0;
                        secs = 0;
                    }
                }
            }

            //link the timer to the labels in the form
            Timer();
        }
        private void ResetTimer()
        {
            secs = 0;
            mins = 0;
            hours = 0;
        }

        #endregion

        #region Close Form 
        private void KitchenViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // show the login form
            LoginForm login = new LoginForm();
            login.Show();
        }
        #endregion

        private void btn_CompletedOrders_Click(object sender, EventArgs e)
        {
            HidePanels();
            pnl_completeOrders.Show();

            //delete everything and then display the items 
            RemoveListViewItems(listview_CompletedOrders);
            DisplayOrderItems(listview_CompletedOrders, OrderStatus.ReadyToServe);
        }

        private void btn_newOrders_Click(object sender, EventArgs e)
        {
            HidePanels();
            pnl_newOrders.Show();

            //delete everything and then display the items 
            RemoveListViewItems(listview_NewOrders);
            DisplayOrderItems(listview_NewOrders, OrderStatus.NotStarted);
        }

        private void btn_Ready_Click(object sender, EventArgs e)
        {
            // connect to logic layer 
            OrderItemLogic orderitemLogic = new OrderItemLogic();

            // the orderitem is what is selected in the listview new orders 
            OrderItem orderItem = listview_NewOrders.SelectedItems[0].Tag as OrderItem;

            //give the listview item a status (ready to serve)
            orderItem.Status = OrderStatus.ReadyToServe;

            // change the status of the selected item to ready in the database
            orderitemLogic.SetOrderItemStatus(orderItem);

            MessageBox.Show($"Item {orderItem.Name} is now ready!");

            //delete all items in the listview and reload them
            RemoveListViewItems(listview_NewOrders);
            DisplayOrderItems(listview_NewOrders, OrderStatus.NotStarted);

            //reset the timer 
            ResetTimer();
        }

        #region Fonts
        public void SetFonts()
        {
            //// set the labels to the form of the chapeau lettering with the font size of the labe before
            //lbl_activeOrder.Font = FontManager.Instance.ScriptMT(lbl_activeOrder.Font.Size);
            //lbl_completedOrders.Font = FontManager.Instance.ScriptMT(lbl_completedOrders.Font.Size);
            //lbl_newOrders.Font = FontManager.Instance.ScriptMT(lbl_newOrders.Font.Size);
            //lblKitchenn_OrderNo.Font = FontManager.Instance.ScriptMT(lbl_newOrders.Font.Size);

            ////
            //lbl_activeOrder.UseCompatibleTextRendering = true;
            //lbl_completedOrders.UseCompatibleTextRendering = true;
            //lbl_newOrders.UseCompatibleTextRendering = true;
            //lblKitchenn_OrderNo.UseCompatibleTextRendering = true;
        }
        #endregion

    }

}

