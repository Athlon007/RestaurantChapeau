﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RestaurantLogic;
using RestaurantModel;
using RestaurantDAL;
using RestaurantChapeau.OrderViewUIController;

namespace RestaurantChapeau
{
    public partial class TableViewForm : Form
    {
        TableService tableService = new TableService();
        ReservationService reservationService = new ReservationService();
        PaymentService paymentService = new PaymentService();
        Reservation reservation = new Reservation();
        Employee currentEmployee;
        OrderLogic orderLogic = new OrderLogic();
        Bill currentBill;
        int currentTableNumber;
        Order order = new Order();
        OrderView orderViewWindow;
        Payment paymentWindow;
        int nrOfTables;
        Timer timer;

        //On form load
        public TableViewForm(Employee employee)
        {
            InitializeComponent();

            nrOfTables = tableService.GetTheNumberOfTable();
            currentEmployee = employee;

            //Start the timer for refreshing information
            timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 10000;
            timer.Start();

            //Update DPI scale
            DPIScaler.Instance.UpdateToForm(this);

            //Initialise listview with DPI scale
            lv_TableDetailView.Columns.Add("ID", (int)(40 * DPIScaler.Instance.ScaleWidth), HorizontalAlignment.Left);
            lv_TableDetailView.Columns.Add("Status", (int)(80 * DPIScaler.Instance.ScaleWidth), HorizontalAlignment.Left);
            lv_TableDetailView.Columns.Add("Menu", (int)(280 * DPIScaler.Instance.ScaleWidth), HorizontalAlignment.Left);
            lv_TableDetailView.Columns.Add("Quantity", (int)(100 * DPIScaler.Instance.ScaleWidth), HorizontalAlignment.Left);
            lv_TableDetailView.Columns.Add("Time", (int)(200 * DPIScaler.Instance.ScaleWidth), HorizontalAlignment.Left);

            //Adjust fonts based on scale
            label1.Font = FontManager.Instance.ScriptMT(label1.Font.Size);
            label2.Font = FontManager.Instance.ScriptMT(label2.Font.Size);
            lblHeader.Font = FontManager.Instance.ScriptMT(lblHeader.Font.Size);
            lbl_DisplayTableNr.Font = FontManager.Instance.ScriptMT(lbl_DisplayTableNr.Font.Size);
        }

        //Refresh on timer tick
        private void Timer_Tick(object sender, EventArgs e)
        {
            //If order window is open, don't do anything
            if (orderViewWindow != null && orderViewWindow.Visible)
            {
                return;
            }
            //If payment window is open, don't do anything
            if (paymentWindow != null && paymentWindow.Visible)
            {
                return;
            }
            //Refresh table details
            DynamicLabelsForFoodNotification();
            DynamicLabelsForDrinkNotification();
            DynamicButtonsForTables();
            if (currentBill != null)
                lv_TableDetailView_SelectedIndexChanged(currentTableNumber, currentBill);
        }
        private void btn_MakeReservation_Click(object sender, EventArgs e)
        {
            try
            {
                ReservationService reservationService = new ReservationService();

                Reservation newReservation = new Reservation();
                newReservation.firstName = txt_ReservationFirstName.Text;
                newReservation.lastName = txt_ReservationLastName.Text;
                newReservation.email = txt_ReservationEmail.Text;
                newReservation.ReservationStart = dateTimePicker1.Value;
                newReservation.tableid = (int)reservationTableNumber.Value;

                if (newReservation.firstName == "" || newReservation.lastName == "" || newReservation.email == "" || newReservation.ReservationStart == null)
                {
                    MessageBox.Show("please fill out all textboxes");
                }

                List<Reservation> allReservations = reservationService.GetAllReservations();

                //Check if reservation is valid
                foreach (Reservation reservation in allReservations)
                {
                    if (reservation.tableid == newReservation.tableid && reservation.ReservationStart == newReservation.ReservationStart)
                    {
                        MessageBox.Show("you are unable to make reservation");
                        return;
                    }
                    else if (reservation.tableid == newReservation.tableid && reservation.ReservationStart.AddHours(1) >= newReservation.ReservationStart)
                    {
                        MessageBox.Show("you are unable to make reservation");
                        return;
                    }
                }
                //Add the reservation to the database
                reservationService.AddToReservation(newReservation);
                MessageBox.Show("Succesfully made reservation!");
                //for (int i = 0; i < nrOfTables; i++)
                //{
                //    if (!paymentService.HasBill(i + 1))
                //    {

                //        break;
                //    }
                //    else
                //    {                        
                //        MessageBox.Show("You cannot make reservation, this table is occupied");
                //        break;
                //    }
                //}


                //hide the panels and show the dashboard again
                HidePanel();
                pnl_Reservation.Show();
                txt_ReservationFirstName.Clear();
                txt_ReservationLastName.Clear();
                txt_ReservationEmail.Clear();
                DisplayReservation();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"something went wrong with this button: {ex.Message}");
            }
        }

        private void TableViewForm_Load(object sender, EventArgs e)
        {
            HidePanel();
            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker1.Value = DateTime.Now;
            DynamicButtonsForTables();
            DynamicPictureBoxes();
            DynamicLabelsForFoodNotification();
            DynamicLabelsForDrinkNotification();

        }
        public void HidePanel()
        {
            pnl_Reservation.Hide();
            pnl_ViewReservation.Hide();
            pnl_TableDetailView.Hide();
        }



        private void btn_Test_Click(object sender, EventArgs e)
        {

            try
            {
                HidePanel();
                pnl_ViewReservation.Show();
                DisplayReservation();
                pb_TableAgenda.Hide();
                pbTableInfo.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplayReservation()
        {
            try
            {
                //Load reservations from database
                List<Reservation> reservationList = reservationService.GetAllReservations();

                //Initialise listview
                lV_ReservationDisplay.Clear();
                lV_ReservationDisplay.Columns.Add("ID", 50, HorizontalAlignment.Left);
                lV_ReservationDisplay.Columns.Add("First Name", 100, HorizontalAlignment.Left);
                lV_ReservationDisplay.Columns.Add("Last Name", 100, HorizontalAlignment.Left);
                lV_ReservationDisplay.Columns.Add("Email", 150, HorizontalAlignment.Left);
                lV_ReservationDisplay.Columns.Add("Time", 150, HorizontalAlignment.Left);
                lV_ReservationDisplay.Columns.Add("Table number", 150, HorizontalAlignment.Left);
                lV_ReservationDisplay.View = View.Details;

                //Fill listview with reservations
                foreach (Reservation r in reservationList)
                {
                    ListViewItem li = new ListViewItem(r.reservationID.ToString());
                    li.SubItems.Add(r.firstName);
                    li.SubItems.Add(r.lastName);
                    li.SubItems.Add(r.email);
                    li.SubItems.Add(r.ReservationStart.TimeOfDay.ToString());
                    li.SubItems.Add(r.tableid.ToString());
                    li.Tag = r;
                    lV_ReservationDisplay.Items.Add(li);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong with the disyplay reseravtion: {ex.Message}");
            }
        }

        private void btn_ViewReservationMake_Click(object sender, EventArgs e)
        {
            HidePanel();
            pnl_Reservation.Show();
        }

        private void btn_ViewReservationCancel_Click(object sender, EventArgs e)
        {
            try
            {
                //dialog pop up asking the user if he is sure of the action
                DialogResult dialogResult = MessageBox.Show("Are you sure you wish to cancel this reservation? ", "Cancel reservation", MessageBoxButtons.YesNo);

                //if the answer is yes proceed to remove activity
                if (dialogResult == DialogResult.Yes)
                {
                    //create reservation object from selected listview item
                    Reservation reservation = (Reservation)lV_ReservationDisplay.SelectedItems[0].Tag;

                    //delete reservation
                    reservationService.CancelReservation(reservation);

                    // show that delete was successful
                    MessageBox.Show("Successfully cancelled the reservation!");

                    //refresh panel
                    HidePanel();
                    //CheckReservations();
                    DisplayReservation();
                    pnl_ViewReservation.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong with the reservation system: {ex.Message}");
            }
        }

        private void picBackButton_Click_1(object sender, EventArgs e)
        {
            HidePanel();
            pnl_ViewReservation.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HidePanel();
            pbTableInfo.Show();
            pb_TableAgenda.Show();
        }

        private void CreateButtons(Object sender, EventArgs e)
        {
            Button button = sender as Button;
            if(button != null)
            {
                for (int i = 0; i < nrOfTables; i++)
                {
                    if(button.Text == i.ToString())
                    {
                        HandleTableButtonClick(i + 1);
                        return;
                    }
                }
            }
        }
        //private void OnTableButtonClick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //Get table ID from the sender/button
        //        if (!int.TryParse((sender as Button).Text, out int id))
        //        {
        //            throw new Exception("Could not read table ID.");
        //        }

        //        //Load table reservation
        //        Reservation reservation;
        //        if ((sender as Button).Tag != null)
        //        {
        //            reservation = (Reservation)(sender as Button).Tag;
        //        }
        //        else
        //        {
        //            reservation = null;
        //        }

        //        HandleTableButtonClick(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogger.Instance.WriteError(ex, "Something went wrong while opening table details.");
        //    }
        //}

        //
        private void HandleTableButtonClick(int tableId)
        {
            try
            {
                List<Reservation>reservations = reservationService.GetAllReservations();
                foreach (Reservation reservation in reservations)
                {
                    if (reservationService.IsReserved(tableId))
                    {
                        DialogResult dialogResult = MessageBox.Show($"this table has reservation at {reservation.ReservationStart.TimeOfDay} would you like to occupy this table? ", "Go to order view", MessageBoxButtons.YesNo);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                if (!paymentService.HasBill(tableId))
                {
                    ShowOrderView(tableId);                    
                }
                else
                {
                    //Get the bill for this table
                    this.currentBill = paymentService.GetBill(tableId);
                    this.currentTableNumber = tableId;

                    if (!orderLogic.HasBillOrders(this.currentBill))
                    {
                        //If bill is empty, go into order view
                        ShowOrderView(tableId, this.currentBill);
                    }
                    else
                    {
                        //If bill has items, load order details
                        pnl_TableDetailView.Show();
                        lv_TableDetailView_SelectedIndexChanged(tableId, this.currentBill);
                    }

                    //Hide panel elements
                    pb_TableAgenda.Hide();
                    pbTableInfo.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong with the button: {ex.Message}");
            }
        }

        private void ShowOrderView(int tableID, Bill bill = null)
        {
            try
            {
                orderViewWindow = new OrderView(currentEmployee, bill, tableID);
                orderViewWindow.ShowDialog(this);
                orderViewWindow.Location = this.Location; //Show OrderView right on top of this window
            }
            catch (Exception ex)
            {
                ErrorLogger.Instance.WriteError(ex, "Something went wrong while loading order view.");
            }
        }

        private void lv_TableDetailView_SelectedIndexChanged(int tableId, Bill bill)
        {
            try
            {
                int lastSelected = lv_TableDetailView.SelectedItems.Count > 0 ? lv_TableDetailView.SelectedItems[0].Index : -1;
                lbl_DisplayTableNr.Text = "Table" + tableId.ToString();
                List<Order> orders = orderLogic.GetOrdersForBill(bill);
                lv_TableDetailView.Items.Clear();

                lv_TableDetailView.View = View.Details;

                foreach (Order order in orders)
                {
                    List<MenuItem> menus = orderLogic.GetItemsForOrder(order);
                    foreach (MenuItem item in menus)
                    {
                        ListViewItem li = new ListViewItem(order.Id.ToString());
                        li.SubItems.Add(item.Status.ToString());
                        li.SubItems.Add(item.Name.ToString());
                        li.SubItems.Add(item.Quantity.ToString());
                        li.SubItems.Add(order.PlacedTime.TimeOfDay.ToString());
                        ListItem listItem = new ListItem()
                        {
                            Order = order,
                            MenuItem = item
                        };
                        li.Tag = listItem;
                        if (item.Status == OrderStatus.ReadyToServe)
                        {
                            li.ForeColor = Color.Blue;
                        }
                        lv_TableDetailView.Items.Add(li);
                    }
                }

                if (lastSelected != -1)
                {
                    lv_TableDetailView.Items[lastSelected].Selected = true;
                    lv_TableDetailView.Items[lastSelected].Focused = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong while loading listview: {ex.Message}");
            }
        }

        struct ListItem
        {
            public Order Order;
            public MenuItem MenuItem;
        }

        //Back to prev screen
        private void pbTableDetailViewGoBack_Click(object sender, EventArgs e)
        {
            HidePanel();
            pb_TableAgenda.Show();
            pbTableInfo.Show();
        }

        //Add order button
        private void btn_TableDetailViewAddOrder_Click(object sender, EventArgs e)
        {
            ShowOrderView(currentTableNumber, currentBill);
        }

        //Set as served button
        private void btn_TableDetailViewChangeStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (lv_TableDetailView.FocusedItem.Tag == null) return;

                foreach (ListViewItem lvi in lv_TableDetailView.SelectedItems)
                {
                    ListItem listItem = (ListItem)lvi.Tag;
                    Order order = listItem.Order;
                    MenuItem item = listItem.MenuItem;
                    if (item.Status == OrderStatus.NotStarted || item.Status == OrderStatus.Preparing)
                    {
                        MessageBox.Show("You cannot change status yet. Kitchen/bar is still preparing the order.");
                    }
                    else if (item.Status == OrderStatus.ReadyToServe)
                    {
                        item.Status = OrderStatus.Served;
                        orderLogic.SetOrderItemStatus(item, order);
                        lv_TableDetailView_SelectedIndexChanged(currentTableNumber, currentBill);
                    }
                    else if (item.Status == OrderStatus.Served)
                    {
                        MessageBox.Show("You already changed status");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong while executing button: {ex.Message}");
            }
        }

        //When the window closes, go back to login
        private void TableViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
        //Logout button
        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Checkout button
        private void btn_TableDetailViewCheckOut_Click(object sender, EventArgs e)
        {
            paymentWindow = new Payment(currentTableNumber, pnl_TableDetailView);
            paymentWindow.Show();
        }

        private void DynamicPictureBoxes()
        {
            int pbX = 1;
            int pbY = 2;
            int pbCount = 1;
            for (int i = 0; i < nrOfTables; i++)
            {
                PictureBox picturebox = new PictureBox();
                picturebox.Size = new Size(51, 51);
                picturebox.Location = new Point(100 * (pbX), 135 * (pbY));
                picturebox.Image = Properties.Resources.food4;
                pbX += 3;
                pbCount++;
                if (i % 2 == 1)
                {
                    pbX -= 6;
                    pbY++;

                }
                //Controls.Add(picturebox);
            }
        }
        private void DynamicLabelsForFoodNotification()
        {
            int lbX = 1;
            int lbY = 2;
            int lbCount = 1;
            for (int i = 0; i < nrOfTables; i++)
            {
                Label label = new Label();
                label.Text = "";
                label.Name = lbCount.ToString();
                label.Size = new Size(20, 20);
                label.Font = new Font("Segoe UI", 12f);
                label.BackColor = Color.Gray;
                label.ForeColor = Color.White;
                label.Location = new Point(105 * (lbX), 135 * (lbY));
                label.AutoSize = true;
                lbX += 3;
                lbCount++;
                if (i % 2 == 1)
                {
                    lbX -= 6;
                    lbY++;
                }
                if (paymentService.HasBill(i + 1))
                {
                    Bill bill = paymentService.GetBill(i + 1);
                    List<Order> orders = orderLogic.GetOrdersForBill(bill);

                    int readyCount = 0;
                    foreach (Order order in orders)
                    {
                        List<MenuItem> items = orderLogic.GetItemsForOrder(order);
                        foreach (MenuItem item in items)
                        {
                            if (item.Status == OrderStatus.ReadyToServe && !item.IsDrink)
                            {
                                readyCount++;
                            }
                        }
                    }
                    label.Text = $"{readyCount}";
                }
                Controls.Add(label);
            }
        }
        private void DynamicLabelsForDrinkNotification()
        {
            int lbX = 3;
            int lbY = 2;
            int lbCount = 1;
            for (int i = 0; i < nrOfTables; i++)
            {
                Label label = new Label();
                label.Text = "";
                label.Name = lbCount.ToString();
                label.Size = new Size(20, 20);
                label.Font = new Font("Segoe UI", 12f);
                label.BackColor = Color.Gray;
                label.ForeColor = Color.White;
                label.Location = new Point(103 * (lbX), 135 * (lbY));
                label.AutoSize = true;
                lbX += 3;
                lbCount++;
                if (i % 2 == 1)
                {
                    lbX -= 6;
                    lbY++;
                }
                if (paymentService.HasBill(i + 1))
                {
                    Bill bill = paymentService.GetBill(i + 1);
                    List<Order> orders = orderLogic.GetOrdersForBill(bill);

                    int readyCount = 0;
                    foreach (Order order in orders)
                    {
                        List<MenuItem> items = orderLogic.GetItemsForOrder(order);
                        foreach (MenuItem item in items)
                        {
                            if (item.Status == OrderStatus.ReadyToServe && item.IsDrink)
                            {
                                readyCount++;
                            }
                        }
                    }
                    label.Text = $"{readyCount}";
                }
                Controls.Add(label);
            }
        }

        private void DynamicButtonsForTables()
        {
            int buttonX = 1;
            int buttonY = 2;
            int buttonCount = 1;
            //reservation = reservationService.GetAllReservationForTable();

            for (int i = 0; i < nrOfTables; i++)
            {
                Button button = new Button();
                button.Text = buttonCount.ToString();
                button.Name = buttonCount.ToString();
                button.Font = new Font("Segoe UI", 15f);
                button.Size = new Size(160, 130);
                button.Location = new Point(145 * (buttonX), 130 * (buttonY));
                button.Image = Properties.Resources.screenshotTable;
                buttonX += 2;
                buttonCount++;
                if (i % 2 == 1)
                {
                    buttonX -= 4;
                    buttonY++;
                }
                if (paymentService.HasBill(i + 1))
                {
                    button.Image = Properties.Resources.occupiedNotif2;
                }
                else if (reservationService.IsReserved(i + 1))
                {
                    button.Image = Properties.Resources.reserved;
                }
                Controls.Add(button);
                button.Click += CreateButtons;//OnTableButtonClick;
            }
        }
    }
}