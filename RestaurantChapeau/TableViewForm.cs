using System;
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
        Employee currentEmployee;
        Bill currentBill;
        int currentTableNumber;
        OrderView orderViewWindow;
        Payment paymentWindow;
        List<Table> tables;
        Timer timer;

        //Lists of components
<<<<<<< HEAD
        Dictionary<int, Button> tableButtons;
=======
        List<Button> tableButtons;
>>>>>>> parent of 32697bd (I changed a lot)
        List<Label> drinkNotifications;
        List<Label> foodNotifications;

        //On form load
        public TableViewForm(Employee employee)
        {
            InitializeComponent();
            TableService tableService = new TableService();
            tables = tableService.GetTables();
            currentEmployee = employee;
            btn_LogOut.Hide();
            //Start the timer for refreshing information
            timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 10000;
            timer.Start();
            lbl_LogOut.Text = employee.firstName;
            //Update DPI scale
            DPIScaler.Instance.UpdateToForm(this);

            //Initialise listview with DPI scale
            lv_TableDetailView.Columns.Add("ID", (int)(40 * DPIScaler.Instance.ScaleWidth), HorizontalAlignment.Left);
            lv_TableDetailView.Columns.Add("Status", (int)(70 * DPIScaler.Instance.ScaleWidth), HorizontalAlignment.Left);
            lv_TableDetailView.Columns.Add("Menu", (int)(350 * DPIScaler.Instance.ScaleWidth), HorizontalAlignment.Left);
            lv_TableDetailView.Columns.Add("Q", (int)(40 * DPIScaler.Instance.ScaleWidth), HorizontalAlignment.Left);

            //Adjust fonts based on scale
            label1.Font = FontManager.Instance.ScriptMT(label1.Font.Size);
            label2.Font = FontManager.Instance.ScriptMT(label2.Font.Size);
            lblHeader.Font = FontManager.Instance.ScriptMT(lblHeader.Font.Size);
            lbl_DisplayTableNr.Font = FontManager.Instance.ScriptMT(lbl_DisplayTableNr.Font.Size);
        }

        //Refresh on timer tick
        private void Timer_Tick(object sender, EventArgs e)
        {
            //If order window or payment window is open, don't do anything
            if ((orderViewWindow != null && orderViewWindow.Visible) || (paymentWindow != null && paymentWindow.Visible))
            {
                return;
            }

            //Refresh table details
            UpdateDrinkLabels(drinkNotifications);
            UpdateFoodLabels(foodNotifications);
            UpdateTableButtons(tableButtons);

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
                    if (reservation.tableid == newReservation.tableid && reservation.ReservationStart == newReservation.ReservationStart || reservation.ReservationStart.AddHours(1) >= newReservation.ReservationStart)
                    {
                        MessageBox.Show("you are unable to make reservation please check the reservation time and table number");
                        return;
                    }
                }
                //Add the reservation to the database
                reservationService.AddToReservation(newReservation);
                MessageBox.Show("Succesfully made reservation!");
                //hide the panels and show the dashboard again
                HidePanel();
                ClearReservationTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"something went wrong with this button: {ex.Message}");
            }
        }
        private void ClearReservationTextBox()
        {
            txt_ReservationFirstName.Clear();
            txt_ReservationLastName.Clear();
            txt_ReservationEmail.Clear();
        }

        private void TableViewForm_Load(object sender, EventArgs e)
        {
            HidePanel();
            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker1.Value = DateTime.Now;
            //Create lists of components
            tableButtons = CreateButtonsForTables();
            drinkNotifications = CreateLabelsForDrinkNotification();
            foodNotifications = CreateLabelsForFoodNotification();

        }
        public void HidePanel()
        {
            pnl_Reservation.Hide();
            pnl_ViewReservation.Hide();
            pnl_TableDetailView.Hide();
            pnl_Information.Hide();
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
                ReservationService reservationService = new ReservationService();
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
                ReservationService reservationService = new ReservationService();
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

        private void CreateButtons(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                for (int i = 0; i < tables.Count + 1; i++)
                {
                    if (button.Text == i.ToString())
                    {
                        HandleTableButtonClick(i);
                        return;
                    }
                }
            }
        }

        private void HandleTableButtonClick(int tableId)
        {
            try
            {
                OrderLogic orderLogic = new OrderLogic();
                PaymentService paymentService = new PaymentService();
                TableService tableService = new TableService();
                ReservationService reservationService = new ReservationService();
                List<Reservation> CheckReservationTime = reservationService.ReservationTimeForTable(tableId);
                foreach (Reservation reservation in CheckReservationTime)
                {
                    if (reservationService.IsReserved(tableId))
                    {
                        DialogResult dialogResult = MessageBox.Show($"this table has reservation at {reservation.ReservationStart} would you like to occupy this table? ", "Go to order view", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            ShowOrderView(tableId);
<<<<<<< HEAD
                            currentBill = paymentService.CreateBill(tableId);
                            lv_TableDetailView_SelectedIndexChanged(tableId, this.currentBill);

=======
>>>>>>> parent of 32697bd (I changed a lot)
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                if (tableService.IsOccupied(tableId))
                {
                    //Get the bill for this table
                    this.currentBill = paymentService.GetBill(tableId);
                    this.currentTableNumber = tableId;
                    if (orderLogic.HasBillOrders(this.currentBill))
                    {
                        //If bill has items, load order details
                        pnl_TableDetailView.Show();
                        lv_TableDetailView_SelectedIndexChanged(tableId, this.currentBill);
                    }
                    else
                    {
                        //If bill is empty, go into order view
                        ShowOrderView(tableId, this.currentBill);
                    }

                    //Hide panel elements
                    pb_TableAgenda.Hide();
                    pbTableInfo.Hide();

                }
                else
                {

                    DialogResult dialogResult = MessageBox.Show($"would you like to occupy this table?", "Occupy table", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        tableService.OccupyTable(tableId);
                        paymentService.CreateBillForTable(tableId);
                    }
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
                OrderLogic orderLogic = new OrderLogic();
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
                        if (item.Status == OrderStatus.NotStarted)
                        {
                            li.SubItems.Add("N");
                        }
                        else if (item.Status == OrderStatus.Preparing)
                        {
                            li.ForeColor = Color.Green;
                            li.SubItems.Add("P");
                        }
                        else if (item.Status == OrderStatus.ReadyToServe)
                        {
                            li.ForeColor = Color.Blue;
                            li.SubItems.Add("R");
                        }
                        else if (item.Status == OrderStatus.Served)
                        {
                            li.ForeColor = Color.DarkOrange;
                            li.SubItems.Add("S");
                        }
                        li.SubItems.Add(item.Name.ToString());
                        li.SubItems.Add(item.Quantity.ToString());
                        ListItem listItem = new ListItem()
                        {
                            Order = order,
                            MenuItem = item
                        };
                        li.Tag = listItem;

                        lv_TableDetailView.Items.Add(li);
                        if (lv_TableDetailView.Items.Count % 2 == 0)
                        {
                            li.BackColor = Color.LightGray;
                        }
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
                OrderLogic orderLogic = new OrderLogic();
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
                        orderLogic.SetOrderItemStatus(item, order,true);
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

        private List<Label> CreateLabelsForFoodNotification()
        {
            List<Label> foodLabels = new List<Label>();
            //Set position start
            int lbX = 1;
            int lbY = 1;
            //Set labelCount to 1
            int lbCount = 1;

            //For each table, add labels
            for (int i = 0; i < tables.Count; i++)
            {
                //Create label using positioning paramaters
                Label label = CreateNotificationLabel(lbCount, lbX, lbY);

                lbX += 3;

                if (i % 2 == 1)
                {
                    lbX -= 6;
                    lbY++;
                }
                Controls.Add(label);
                foodLabels.Add(label);

                lbCount++;
            }
            return foodLabels;
        }

        private List<Label> CreateLabelsForDrinkNotification()
        {
            List<Label> drinkLabels = new List<Label>();
            int lbX = 3;
            int lbY = 1;
            int lbCount = 1;

            for (int i = 0; i < tables.Count; i++)
            {
                //Create new label with positioning parameters
                Label label = CreateNotificationLabel(lbCount, lbX, lbY);

                lbX += 3;

                //For each uneven label, move label to the left
                if (i % 2 == 1)
                {
                    lbX -= 6;
                    lbY++;
                }

                Controls.Add(label);
                drinkLabels.Add(label);

                lbCount++;
            }
            return drinkLabels;
        }

        private Label CreateNotificationLabel(int lbCount, int lbX, int lbY)
        {
            Label label = new Label();
            label.Text = "";
            label.Name = lbCount.ToString();
            label.Size = new Size(20, 20);
            label.Font = new Font("Segoe UI", 12f);
            label.BackColor = Color.Gray;
            label.ForeColor = Color.White;
            label.Location = new Point(103 * (lbX), 130 * (lbY));
            label.AutoSize = true;

            return label;
        }
        private void UpdateFoodLabels(List<Label> foodLabels)
        {
            OrderLogic orderLogic = new OrderLogic();
            PaymentService paymentService = new PaymentService();
            TableService tableService = new TableService();
            int tableNr = 1;
            foreach (Label label in foodLabels)
            {
                //If table has a bill, get ready orders and store them into label
                if (paymentService.HasBill(tableNr))
                {
                    Bill bill = paymentService.GetBill(tableNr);
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

                tableNr++;
            }
        }


        private void UpdateDrinkLabels(List<Label> drinkLabels)
        {
            OrderLogic orderLogic = new OrderLogic();
            PaymentService paymentService = new PaymentService();
            TableService tableService = new TableService();
            int tableNr = 1;
            foreach (Label label in drinkLabels)
            {
                //If table has a bill, get ready orders and store them into label
                if (paymentService.HasBill(tableNr))
                {
                    Bill bill = paymentService.GetBill(tableNr);
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
                tableNr++;
            }
        }

<<<<<<< HEAD
        private Dictionary<int, Button> CreateButtonsForTables()
        {
            Dictionary<int, Button> tableButtons = new Dictionary<int, Button>();
=======
        private List<Button> CreateButtonsForTables()
        {
            List<Button> tableButtons = new List<Button>();
>>>>>>> parent of 32697bd (I changed a lot)

            int buttonX = 1;
            int buttonY = 1;
            int buttonCount = 1;

            for (int i = 0; i < tables.Count; i++)
            {
                Button button = CreateButtons(buttonCount, buttonX, buttonY);

                buttonX += 2;
                buttonCount++;
                if (i % 2 == 1)
                {
                    buttonX -= 4;
                    buttonY++;
                }

                Controls.Add(button);
<<<<<<< HEAD
                tableButtons.Add(i + 1, button);
                button.Click += CreateButtons;
=======
                tableButtons.Add(button);
                button.Click += /*OnTableButtonClick;*/CreateButtons;
>>>>>>> parent of 32697bd (I changed a lot)

            }
            return tableButtons;
        }
        private Button CreateButtons(int count, int x, int y)
        {
            Button button = new Button();
            button.Text = count.ToString();
            button.Name = count.ToString();
            button.Font = new Font("Segoe UI", 15f);
            button.Size = new Size(160, 130);
            button.Location = new Point(145 * (x), 130 * (y));
            button.Image = Properties.Resources.screenshotTable;

            return button;
        }

<<<<<<< HEAD
        private void UpdateTableButtons(Dictionary<int, Button> tableButtons)
        {
            int tableNr = 1;
            TableService tableService = new TableService();
            ReservationService reservationService = new ReservationService();
            for (int i = 0; i < tableButtons.Count; i++)
=======
        private void UpdateTableButtons(List<Button> tableButtons)
        {
            int tableNr = 1;
            foreach (Button button in tableButtons)
>>>>>>> parent of 32697bd (I changed a lot)
            {
                if (paymentService.HasBill(tableNr) || tableService.IsOccupied(tableNr))
                {
<<<<<<< HEAD
                    tableButtons[i + 1].Image = Properties.Resources.occupiedNotif2;
=======
                    button.Image = Properties.Resources.occupiedNotif2;
>>>>>>> parent of 32697bd (I changed a lot)
                }
                else if (reservationService.IsReserved(tableNr))
                {
                    button.Image = Properties.Resources.reserved;
                }
                else
                {
                    button.Image = Properties.Resources.screenshotTable;
                }

                tableNr++;
            }
        }

        private void btn_Information_Click(object sender, EventArgs e)
        {
            HidePanel();
            pnl_Information.Show();
        }

        private void btn_GoBackInformation_Click(object sender, EventArgs e)
        {
            HidePanel();
        }

        private void lbl_LogOut_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}