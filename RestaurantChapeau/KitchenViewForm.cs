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
        private Order selectedOrder;
        private MenuItem selectedItem;
        private OrderLogic orderService;
        private bool complete;
        private MenuItem menuItem;


        public KitchenViewForm(Employee employee)
        {
            this.employee = employee;
            InitializeComponent();
            // SetFonts();
            DisplayOrderItems(listview_NewOrders);

            //ResetTimer();
        }

        #region Display Orders

        /// <summary>
        /// gets orders depending on if the item is complete ,the listview to be displayed on
        ///  and the max order status by which it should get the information from the database
        /// </summary>
        /// <param name="complete"></param>
        /// is a bool which checks if the item is complete and gets data from db
        /// <param name="listView"></param>
        /// shows which listview it should display the data on
        /// <param name="maxOrderStatus"></param>
        /// max ordering status which it should show the orders 
        private void DisplayNewOrders(bool complete, ListView listView, OrderStatus maxOrderStatus)
        {
            orderService = new OrderLogic();
            //List<Order> orders = orderService.GetOrders(complete);
            List<Order> orders = new List<Order>();
            if (employee.employeeType == EmployeeType.KitchenStaff)
            {
                orders = orderService.GetOrders(complete, false, maxOrderStatus);
            }
            else if (employee.employeeType == EmployeeType.Bartender)
            {
                orders = orderService.GetOrders(complete, true, maxOrderStatus);
            }

            foreach (Order order in orders)
            {
                ListViewItem li = new ListViewItem(order.Id.ToString());
                li.SubItems.Add(order.PlacedTime.TimeOfDay.ToString());
                if (complete == false)
                    li.SubItems.Add("Not ready");
                else
                    li.SubItems.Add("Ready");

                li.Tag = order;

                //get items for selectedorder
                //List<MenuItem> items = orderService.GetItemsForOrder(order);
                List<MenuItem> items = new List<MenuItem>();
                if (employee.employeeType == EmployeeType.KitchenStaff)
                {
                    items = orderService.GetItemsToPrepareForOrder(order, false);
                }
                else if (employee.employeeType == EmployeeType.Bartender)
                {
                    items = orderService.GetItemsToPrepareForOrder(order, true);
                }

                //add items to listviews and if complete add backwards
                if (complete || items.Count > 0)
                {
                    if (complete == true)
                        listView.Items.Insert(0, li);
                    else
                        listView.Items.Add(li);
                }
            }
        }
        #endregion

        #region Display Order Items
        private void DisplayOrderItems(ListView listview)
        {
            List<OrderItem> orderItems = new List<OrderItem>();
            OrderItemLogic orderItemLogic = new OrderItemLogic();

            //create new orderitem
            OrderItem item = new OrderItem();

            //these are used by the query to search for items that are not started and are food items 
            item.Status = OrderStatus.NotStarted;

            //if kitchenmode is true, display only kitchen items
            if (employee.employeeType == EmployeeType.KitchenStaff)
            {
                //select only food items from the items in the database
                item.OrderItemType = OrderType.FoodItem;
                orderItems = orderItemLogic.GetAllOrderItems(item);
            }
            else if (employee.employeeType == EmployeeType.Bartender)
            {
                //else if the employeetype is a bartender select only items that are drinks
                item.OrderItemType = OrderType.Drink;
                orderItems = orderItemLogic.GetAllOrderItems(item);
            }
            // delete all the items in the listview before adding new ones
            RemoveListViewItems(listview_NewOrders);

            //foreach item in the list acquired from the db, add the name to the active order listview
            foreach (OrderItem orderItem in orderItems)
            {
                ListViewItem li = new ListViewItem(orderItem.Id.ToString());
                li.SubItems.Add(orderItem.Name.ToString());
                li.SubItems.Add(orderItem.Quantity.ToString());
                li.SubItems.Add(orderItem.MenuType.ToString());
                li.SubItems.Add(orderItem.Comment.ToString());
                li.SubItems.Add(orderItem.Table.ToString());
                li.SubItems.Add(orderItem.PlacedTime.ToString());
                li.SubItems.Add(orderItem.Status.ToString());
                li.Tag = item;
                // add all items to the listview active order
                listview.Items.Add(li);

            }


        }
        #endregion

        #region Select item in new orders list view

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

        private void btn_preparingOrder_Click(object sender, EventArgs e)
        {
            PreparingOrder();
        }
        #endregion

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

        #region Preparing Order Button
        public void PreparingOrder()
        {
            // enable timer
            IsActive = true;

            Order order = selectedOrder;
            orderService = new OrderLogic();

            MenuItem selectedMenuItem = menuItem;
            bool isDrink;

            // Prevents kitchen stuff updating the orderstatus in drinks and the other way round 
            if (employee.employeeType == EmployeeType.KitchenStaff)
            {
                isDrink = false;
            }
            else
            {
                isDrink = true;
            }

        }
        #endregion
    }

}

