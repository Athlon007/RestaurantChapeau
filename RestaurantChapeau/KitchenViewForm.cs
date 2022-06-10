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
        int secs, mins, hours;
        bool IsActive;

        Employee employee;
        private Order selectedOrder;
        private MenuItem selectedItem;

        public KitchenViewForm(Employee employee)
        {
            this.employee = employee;
            InitializeComponent();
            SetFonts();
            DisplayOrders();

            ResetTimer();
        }

        #region Display Orders
        public void DisplayOrders()
        {
            OrderLogic orderService = new OrderLogic();
            List<Order> orders = orderService.GetKitchenOrdersToPrepare();

            foreach (Order order in orders)
            {
                //create new listview item and add the items to the listview item
                ListViewItem li = new ListViewItem(order.Id.ToString());
                li.SubItems.Add(order.PlacedTime.ToString());

                // if the item is complete, display status is ready or else not ready in the listview
                if (order.Complete == true)
                {
                    li.SubItems.Add("Ready");
                }
                else
                {
                    li.SubItems.Add("Not ready");
                }
                //order tags become an order item
                li.Tag = order;

                //get all the items that belong to an order
                List<MenuItem> items = orderService.GetItemsForOrder(order);
                //if there are no items, do nothing
                if (items.Count == 0)
                    continue;

                // all lthe items above an item in a listview have a status of ready
                bool allItemsAboveReady = true;

                // for all the items that belong to an order
                foreach (MenuItem item in items)
                {
                    //if the order item is not ready to serve
                    if (item.Status < OrderStatus.ReadyToServe)
                    {
                        //this makes sure so that the bartender doesnt see orders which contain food orders and otherwise (prevents empty order items in the listview)
                        if (((item.IsDrink && employee.employeeType == EmployeeType.Bartender) || (!item.IsDrink && employee.employeeType == EmployeeType.KitchenStaff)))
                            allItemsAboveReady = false;
                    }
                }
                //if order is ready add to completed orders page or add to new order page
                if (allItemsAboveReady == true)
                {
                    listViewKitchen_CompleteOrders.Items.Add(li);
                }
                else
                {
                    listViewNewOrders.Items.Add(li);
                }
            }
        }
        #endregion

        #region Display Order Items
        private void DisplayOrderItems()
        {
            List<MenuItem> orderMenuItems = new List<MenuItem>();
            OrderLogic orderService = new OrderLogic();

            //extract order item from the selected item in the listview
            Order orderItem = listViewNewOrders.SelectedItems.Count == 0 ? this.selectedOrder : (Order)listViewNewOrders.SelectedItems[0].Tag;

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
            else if(employee.employeeType==EmployeeType.Bartender)          
            {
                orderMenuItems = orderService.GetBarOrderItemsByID(orderItem.Id);
            }
            // delete all the items in the listview before adding new ones
            RemoveListViewItems(listViewKitchen_ActiveOrder);

            //foreach item in the list acquired from the db, add the name to the active order 
            foreach (MenuItem item in orderMenuItems)
            {
                ListViewItem li = new ListViewItem(item.Name.ToString());
                li.Tag = item;
                li.SubItems.Add(item.Quantity.ToString());
                li.SubItems.Add(item.Status.ToString());

                listViewKitchen_ActiveOrder.Items.Add(li);

                //set the background of the item to green if its ready to serve
                if (item.Status >= OrderStatus.ReadyToServe)
                {
                    li.BackColor = Color.Green;
                }
            }
        }
        #endregion

        #region Select item in new orders list view
        private void listViewNewOrders_Click(object sender, EventArgs e)
        {
            HidePanels();
            pnlKitchen_ActiveOrder.Show();
            DisplayOrderItems();

            //Begin timer
            IsActive = true;

            selectedOrder = (Order)listViewNewOrders.SelectedItems[0].Tag;
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
        }
        #endregion

        #region Ready Order Button
        private void btn_readyOrder_Click(object sender, EventArgs e)
        {
            //reset the timer
            ResetTimer();

            //connect to logic layer
            OrderLogic orderService = new OrderLogic();
            Order orderItem = selectedOrder;

            //save the name of the highlighted menu item into a menuitem
            selectedItem = (MenuItem)listViewKitchen_ActiveOrder.FocusedItem.Tag;

            //if all the items on the listview are selected, change status to ready else preparing
            if (listViewKitchen_ActiveOrder.CheckedItems.Count == listViewKitchen_ActiveOrder.Items.Count)
            {
                orderItem.Complete = true;
                MessageBox.Show($"Order {orderItem.Id.ToString()} has been completed");
                orderService.UpdateOrderStatus( orderItem);
                // stop the timer
                IsActive = false;
            }
            else if (listViewKitchen_ActiveOrder.CheckedItems.Count == 0)
            {
                MessageBox.Show($"Please select an item to mark ready");
            }
            else
            {
                // set the selected item to ready
                selectedItem.Status = OrderStatus.ReadyToServe;
                orderService.SetOrderItemStatus(selectedItem, orderItem);
                MessageBox.Show($"Item {selectedItem.Name} is now ready");
            }

            //remove the items on the new order listview and update with new information
            RemoveListViewItems(listViewNewOrders);
            DisplayOrders();

            //remove all the item in the active order listview and display again 
            RemoveListViewItems(listViewKitchen_ActiveOrder);
            DisplayOrderItems();
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
    }
}
