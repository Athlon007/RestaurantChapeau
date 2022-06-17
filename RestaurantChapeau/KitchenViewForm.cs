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


        public KitchenViewForm(Employee employee)
        {
            this.employee = employee;
            InitializeComponent();
            SetFonts();
            DisplayNewOrders(false, listViewNewOrders, OrderStatus.Preparing);

            ResetTimer();
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
            try
            {
                List<MenuItem> orderMenuItems = new List<MenuItem>();
                orderService = new OrderLogic();

                //extract order item from the selected item in the listview
                Order orderItem = new Order();

                if (listview.SelectedItems.Count == 0)//listview neweorders
                {
                    orderItem = this.selectedOrder;
                }
                else
                {
                    orderItem = (Order)listview.SelectedItems[0].Tag;//new orders
                }
                // get table number from the database where orderid is selected item
                Table table = orderService.GetOrderTable(orderItem.Id);

                lblKitchenn_OrderNo.Text = orderItem.Id.ToString();
                lbl_tableNo.Text = table.Id.ToString();

                //get the order comment by the orderID
                Order selectedOrder = orderService.GetOrderCommentByID(orderItem.Id);
                lbl_OrderComments.Text = selectedOrder.Comment;

                //if kitchenmode is true, display only kitchen items
                if (employee.employeeType == EmployeeType.KitchenStaff)
                {
                    orderMenuItems = orderService.GetOrderItemsByID(orderItem.Id);
                }
                else if (employee.employeeType == EmployeeType.Bartender)
                {
                    orderMenuItems = orderService.GetBarOrderItemsByID(orderItem.Id);
                }
                // delete all the items in the listview before adding new ones
                RemoveListViewItems(listViewKitchen_ActiveOrder);

                //foreach item in the list acquired from the db, add the name to the active order listview
                foreach (MenuItem item in orderMenuItems)
                {
                    ListViewItem li = new ListViewItem(item.Name.ToString());
                    li.Tag = item;
                    li.SubItems.Add(item.Quantity.ToString());
                    li.SubItems.Add(item.Status.ToString());

                    // add all items to the listview active order
                    listViewKitchen_ActiveOrder.Items.Add(li);

                    //set the background of the item to green if its ready to serve
                    if (item.Status >= OrderStatus.ReadyToServe)
                    {
                        li.BackColor = Color.GreenYellow;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was a problem fetching the items belonging to the order: {ex.Message}");
            }
        }
        #endregion

        #region Select item in new orders list view
        private void listViewNewOrders_Click(object sender, EventArgs e)
        {
            HidePanels();
            pnlKitchen_ActiveOrder.Show();
            // display order items for the selected item on  a listview
            DisplayOrderItems(listViewNewOrders);

            //Begin timer
            IsActive = true;

            // the selected order is the order that has been selected in the new orderlistview
            // makes sure that the order is not null when you make an order ready and doesnt break the program
            selectedOrder = (Order)listViewNewOrders.SelectedItems[0].Tag;


            foreach (ListViewItem item in listViewKitchen_ActiveOrder.Items)
            {
                MenuItem menuItem = (MenuItem)item.Tag;
                if (menuItem.Status == OrderStatus.Preparing)
                {
                    btn_preparingOrder.Enabled = false;
                }
            }
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
            // hide all panels and show
            HidePanels();
            pnlKitchen_NewOrders.Show();

            RemoveListViewItems(listViewNewOrders);
            //DisplayOrders(complete);

            DisplayNewOrders(false, listViewNewOrders, OrderStatus.Preparing);
        }
        #endregion

        #region Active order button
        private void btnKitchen_ActiveOrder_Click(object sender, EventArgs e)
        {
            // hide all panels annd show active order
            HidePanels();
            pnlKitchen_ActiveOrder.Show();
        }
        #endregion

        #region Complete Orders button
        private void btnKitchen_CompleteOrders_Click(object sender, EventArgs e)
        {
            // hide all panels and show complete orders
            HidePanels();
            pnlKitchen_CompleteOrders.Show();

            RemoveListViewItems(listViewKitchen_CompleteOrders);
            DisplayNewOrders(true, listViewKitchen_CompleteOrders, OrderStatus.Served);
        }
        #endregion

        #region Ready Order Button
        private void btn_readyOrder_Click(object sender, EventArgs e)
        {
            try
            {
                //reset the timer
                ResetTimer();

                //connect to logic layer
                orderService = new OrderLogic();

                Order orderItem = selectedOrder;

                //save the name of the highlighted menu item into a menuitem
                selectedItem = (MenuItem)listViewKitchen_ActiveOrder.FocusedItem.Tag;

                //if all the items on the listview are selected, change status to ready else preparing
                if (listViewKitchen_ActiveOrder.SelectedItems.Count == 0)
                {
                    MessageBox.Show($"Please select an item to mark ready");
                }
                else
                {
                    foreach (ListViewItem item in listViewKitchen_ActiveOrder.SelectedItems)
                    {
                        //set menu item to item in the listview
                        MenuItem menuItem = (MenuItem)item.Tag;
                        menuItem.Status = OrderStatus.ReadyToServe;
                        orderService.SetOrderItemStatus(menuItem, orderItem,false);
                    }

                    // assume all items are ready
                    bool allItemsDone = true;

                    // for each checked item in the listview
                    foreach (MenuItem menuItem in orderService.GetItemsForOrder(orderItem))
                    {
                        //MenuItem menuItem = (MenuItem)item.Tag;
                        // if status is not ready to serve, then all the items are not done
                        if (menuItem.Status < OrderStatus.ReadyToServe)
                        {
                            allItemsDone = false;
                            break;
                        }
                    }
                    //if all the items are done and are selected, change status to ready else preparing
                    if (allItemsDone)
                    {
                        orderItem.Complete = true;
                        MessageBox.Show($"Order {orderItem.Id.ToString()} has been completed");
                        orderService.UpdateOrderStatus(orderItem);

                        // stop the timer
                        IsActive = false;
                        // enable start order button
                        btn_preparingOrder.Enabled = true;
                    }
                }

                //remove the items on the new order listview and update with new information
                RemoveListViewItems(listViewNewOrders);
                DisplayNewOrders(false, listViewNewOrders, OrderStatus.Served);

                //remove all the item in the active order listview and display again
                RemoveListViewItems(listViewKitchen_ActiveOrder);
                DisplayOrderItems(listViewNewOrders);



            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was a problem readying the order: {ex.Message}");
            }


        }
        #endregion

        #region Hide Panels
        private void HidePanels()
        {
            // hide new orders panel
            pnlKitchen_NewOrders.Hide();
            //hide complete orders panel
            pnlKitchen_CompleteOrders.Hide();
            //hide actice orer panel
            pnlKitchen_ActiveOrder.Hide();
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
            lblMins.Text = mins.ToString(":00");
            lblSecs.Text = secs.ToString(":00");
            lblHours.Text = hours.ToString("00");
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

        private void listViewKitchen_CompleteOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayOrderItems(listViewKitchen_CompleteOrders);
        }

        private void listViewKitchen_CompleteOrders_Click(object sender, EventArgs e)
        {
            HidePanels();
            pnlKitchen_ActiveOrder.Show();
            DisplayOrderItems(listViewKitchen_CompleteOrders);

            //Begin timer
            IsActive = true;

            // the selected order is the order that has been selected in the new orderlistview
            // makes sure that the order is not null when you make an order ready and doesnt break the program
            selectedOrder = (Order)listViewKitchen_CompleteOrders.SelectedItems[0].Tag;
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
            // set the labels to the form of the chapeau lettering with the font size of the labe before
            lbl_activeOrder.Font = FontManager.Instance.ScriptMT(lbl_activeOrder.Font.Size);
            lbl_completedOrders.Font = FontManager.Instance.ScriptMT(lbl_completedOrders.Font.Size);
            lbl_newOrders.Font = FontManager.Instance.ScriptMT(lbl_newOrders.Font.Size);
            lblKitchenn_OrderNo.Font = FontManager.Instance.ScriptMT(lbl_newOrders.Font.Size);

            //
            lbl_activeOrder.UseCompatibleTextRendering = true;
            lbl_completedOrders.UseCompatibleTextRendering = true;
            lbl_newOrders.UseCompatibleTextRendering = true;
            lblKitchenn_OrderNo.UseCompatibleTextRendering = true;
        }
        #endregion

        public void PreparingOrder()
        {
            Order order = selectedOrder;
            orderService = new OrderLogic();
            MenuItem menuItem = new MenuItem();
            bool isDrink;

            if (employee.employeeType==EmployeeType.KitchenStaff)
            {
                 isDrink = false;
            }
            else
            {
                isDrink = true;
            }
            foreach (ListViewItem item in listViewKitchen_ActiveOrder.Items)
            {
                menuItem = (MenuItem)item.Tag;
                menuItem.Status = OrderStatus.Preparing;
                orderService.SetOrderItemStatus(menuItem, order,isDrink);
            }

            MessageBox.Show("Order has been started!");
            btn_preparingOrder.Enabled = false;
            RemoveListViewItems(listViewKitchen_ActiveOrder);
            DisplayOrderItems(listViewKitchen_ActiveOrder);
        }
    }

}
