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
        ReservationService reservationService = new ReservationService();
        PaymentService paymentService = new PaymentService();
        Reservation reservation = new Reservation();
        Employee currentEmployee;
        Button[] tableButtons;
        Label[] notificationLabels;
        Label[] drinkNotificationLabels;
        OrderLogic orderLogic = new OrderLogic();
        Bill currentBill;
        int currentTableNumber;
        Order order = new Order();
        OrderView orderViewWindow;
        Payment paymentWindow;

        Timer timer;
        public TableViewForm(Employee employee)
        {
            InitializeComponent();
            currentEmployee = employee;
            tableButtons = new Button[]
            {
                btn_Table1,
                btn_Table2,
                btn_Table3,
                btn_Table4,
                btn_Table5,
                btn_Table6,
                btn_Table7,
                btn_Table8,
                btn_Table9,
                btn_Table10
            };
            CheckReservations();

            notificationLabels = new Label[]
            {
                lbl_Table1Notification,
                lbl_Table2Notification,
                lbl_Table3Notification,
                lbl_Table4Notification,
                lbl_Table5Notification,
                lbl_Table6Notification,
                lbl_Table7Notification,
                lbl_Table8Notification,
                lbl_Table9Notification,
                lbl_Table10Notification
            };

            drinkNotificationLabels = new Label[]
            {
                lbl_DrinkNotification1,
                lbl_DrinkNotification2,
                lbl_DrinkNotification3,
                lbl_DrinkNotification4,
                lbl_DrinkNotification5,
                lbl_DrinkNotification6,
                lbl_DrinkNotification7,
                lbl_DrinkNotification8,
                lbl_DrinkNotification9,
                lbl_DrinkNotification10
            };

            foreach (Button btn in tableButtons)
            {
                btn.Click += OnTableButtonClick;
            }

            timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 10000;
            timer.Start();
            DPIScaler.Instance.UpdateToForm(this);
            lv_TableDetailView.Columns.Add("ID", (int)(40 * DPIScaler.Instance.ScaleWidth), HorizontalAlignment.Left);
            lv_TableDetailView.Columns.Add("Status", (int)(80 * DPIScaler.Instance.ScaleWidth), HorizontalAlignment.Left);
            lv_TableDetailView.Columns.Add("Menu", (int)(230 * DPIScaler.Instance.ScaleWidth), HorizontalAlignment.Left);
            lv_TableDetailView.Columns.Add("Quantity", (int)(60 * DPIScaler.Instance.ScaleWidth), HorizontalAlignment.Left);
            lv_TableDetailView.Columns.Add("Time", (int)(230 * DPIScaler.Instance.ScaleWidth), HorizontalAlignment.Left);

            label1.Font = FontManager.Instance.ScriptMT(label1.Font.Size);
            label2.Font = FontManager.Instance.ScriptMT(label2.Font.Size);
            lblHeader.Font = FontManager.Instance.ScriptMT(lblHeader.Font.Size);
            lbl_DisplayTableNr.Font = FontManager.Instance.ScriptMT(lbl_DisplayTableNr.Font.Size);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (orderViewWindow != null && orderViewWindow.Visible)
            {
                return;
            }

            if (paymentWindow != null && paymentWindow.Visible)
            {
                return;
            }

            if (currentBill != null)
                lv_TableDetailView_SelectedIndexChanged(currentTableNumber, currentBill);
            CheckNotification();
            CheckReservations();
            CheckDrinkNotification();
        }
        private void ShowNotification()
        {
            lbl_Table1Notification.Show();
            lbl_Table2Notification.Show();
            lbl_Table3Notification.Show();
            lbl_Table4Notification.Show();
            lbl_Table5Notification.Show();
            lbl_Table6Notification.Show();
            lbl_Table7Notification.Show();
            lbl_Table8Notification.Show();
            lbl_Table9Notification.Show();
            lbl_Table10Notification.Show();
        }
        private void HideNotification()
        {
            lbl_Table1Notification.Hide();
            lbl_Table2Notification.Hide();
            lbl_Table3Notification.Hide();
            lbl_Table4Notification.Hide();
            lbl_Table5Notification.Hide();
            lbl_Table6Notification.Hide();
            lbl_Table7Notification.Hide();
            lbl_Table8Notification.Hide();
            lbl_Table9Notification.Hide();
            lbl_Table10Notification.Hide();
        }
       
        private void CheckNotification()
        {
            try
            {
                for (int i = 0; i < notificationLabels.Length; i++)
                {
                    Label label = notificationLabels[i];
                    label.Text = "";
                    int tableNumber = i + 1;
                    if (paymentService.HasBill(tableNumber))
                    {
                        Bill bill = paymentService.GetBill(tableNumber);
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
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Something went wrong with notifycation: {ex.Message}");
            }
        }
        private void CheckDrinkNotification()
        {
            try
            {
                for (int i = 0; i < drinkNotificationLabels.Length; i++)
                {
                    Label label = drinkNotificationLabels[i];
                    label.Text = "";
                    int tableNumber = i + 1;
                    if (paymentService.HasBill(tableNumber))
                    {
                        Bill bill = paymentService.GetBill(tableNumber);
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong with notifycation: {ex.Message}");
            }
        }
        private void CheckReservations()
        {
            try
            {
                for (int i = 0; i < tableButtons.Length; i++)
                {
                    Button button = tableButtons[i];
                    button.Image = Properties.Resources.screenshotTable;
                    button.Tag = null;

                    if (paymentService.HasBill(i + 1))
                    {
                        button.Image = Properties.Resources.occupied;
                    }                    
                }

                List<Reservation> reservations = reservationService.GetAllReservations();
                foreach (Reservation reservation in reservations)
                {
                    tableButtons[reservation.tableid - 1].Tag = reservation;
                    if (reservation.isReserved)
                    {
                        bool reservationNoShowUp = DateTime.Now >= reservation.ReservationStart.AddHours(-1);
                        bool isTableReserved = DateTime.Now.AddHours(+1) >= reservation.ReservationStart;
                        bool isTakenNow = DateTime.Now > reservation.ReservationStart;
                        bool tableHasBill = paymentService.HasBill(reservation.tableid);
                        if (isTakenNow && tableHasBill)
                        {
                            tableButtons[reservation.tableid - 1].Image = Properties.Resources.occupied;

                        }
                        else if (isTableReserved)
                        {
                            tableButtons[reservation.tableid - 1].Image = Properties.Resources.reserved;
                        }
                        else if (reservationNoShowUp)
                        {
                            tableButtons[reservation.tableid - 1].Image = Properties.Resources.screenshotTable;
                        }
                        else
                        {
                            tableButtons[reservation.tableid - 1].Image = Properties.Resources.screenshotTable;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Something went wrong while checking reservation: {ex.Message}");
            }

        }

        private void TableViewForm_Load(object sender, EventArgs e)
        {
            HidePanel();
            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker1.Value = DateTime.Now;
        }
        public void HidePanel()
        {
            pnl_Reservation.Hide();
            pnl_ViewReservation.Hide();
            pnl_TableDetailView.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_TableViewReservation_Click(object sender, EventArgs e)
        {
            HidePanel();
            pnl_Reservation.Show();
        }

        private void btn_MakeReservation_Click(object sender, EventArgs e)
        {
            try
            {
                ReservationService reservationService = new ReservationService();
                List<Reservation> reservations = reservationService.GetAllReservations();
                Dictionary<DateTime,string> reservationCheck = new Dictionary<DateTime, string>();
                string firstName = txt_ReservationFirstName.Text;
                string lastName = txt_ReservationLastName.Text;
                string email = txt_ReservationEmail.Text;
                DateTime reservationStart = dateTimePicker1.Value;
                string TableId = txt_ReservationTableID.Text;
                //DateTime reservationAvailable = reservation.ReservationStart;

                if (firstName == "" || lastName == "" || email == "" || reservationStart == null || TableId == "")
                {
                    MessageBox.Show("please fill out text box");
                }
                else if(reservationCheck.ContainsKey(reservation.ReservationStart) && reservationCheck.ContainsValue(reservation.tableid.ToString()))
                {
                    MessageBox.Show("you are unable to make reservation");
                }                
                else if(!reservationCheck.ContainsKey(reservation.ReservationStart) && !reservationCheck.ContainsValue(reservation.tableid.ToString()))
                {
                    //add the customer info for the reservation to the database
                    reservationService.AddToReservation(firstName, lastName, email, "1", reservationStart, TableId);
                    MessageBox.Show("Succesfully made reservation!");
                    reservationCheck.Add(reservationStart,TableId);
                }

                //hide the panels and show the dashboard again
                HidePanel();
                pnl_Reservation.Show();
                txt_ReservationFirstName.Clear();
                txt_ReservationLastName.Clear();
                txt_ReservationEmail.Clear();
                txt_ReservationTableID.Clear();
                DisplayReservation();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"something went wrong with this button: {ex.Message}");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            HidePanel();
            pnl_ViewReservation.Show();
            try
            {
                DisplayReservation();
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
                List<Reservation> reservationList = reservationService.GetAllReservations();

                lV_ReservationDisplay.Clear();
                lV_ReservationDisplay.Columns.Add("ID", 50, HorizontalAlignment.Left);
                lV_ReservationDisplay.Columns.Add("First Name", 90, HorizontalAlignment.Left);
                lV_ReservationDisplay.Columns.Add("Last Name", 90, HorizontalAlignment.Left);
                lV_ReservationDisplay.Columns.Add("Email", 150, HorizontalAlignment.Left);
                lV_ReservationDisplay.Columns.Add("Time", 150, HorizontalAlignment.Left);
                lV_ReservationDisplay.Columns.Add("Table number", 150, HorizontalAlignment.Left);
                lV_ReservationDisplay.View = View.Details;
                foreach (Reservation r in reservationList)
                {
                    ListViewItem li = new ListViewItem(r.reservationID.ToString());
                    li.SubItems.Add(r.firstName);
                    li.SubItems.Add(r.lastName);
                    li.SubItems.Add(r.email);
                    li.SubItems.Add(r.ReservationStart.ToString());
                    li.SubItems.Add(r.tableid.ToString());
                    lV_ReservationDisplay.Items.Add(li);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Something went wrong with the disyplay reseravtion: {ex.Message}");
            }

        }

        private void btn_MakeReservationGoBack_Click(object sender, EventArgs e)
        {
            HidePanel();
            pnl_ViewReservation.Show();
        }

        private void btn_ViewReservationGoBack_Click(object sender, EventArgs e)
        {
            HidePanel();
            DisplayReservation();
            CheckReservations();
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
                    //create activity object
                    Reservation reservation = new Reservation();
                    {
                        reservation.reservationID = int.Parse(lV_ReservationDisplay.SelectedItems[0].SubItems[0].Text);
                    };

                    //delete reservation
                    reservationService.CancelReservation(reservation);
                    // show that delete was successful
                    MessageBox.Show("Succeesfully cancel the reservation!");
                    //refresh panel
                    HidePanel();
                    DisplayReservation();
                    pnl_ViewReservation.Show();
                    CheckReservations();
                }

                //if the answer is no do nothing
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Something went wrong with the reservation system: {ex.Message}");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void pbTableViewLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void pbViewReservationGoBack_Click(object sender, EventArgs e)
        {
            HidePanel();
            DisplayReservation();
        }

        private void pnl_ViewReservation_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picBackButton_Click(object sender, EventArgs e)
        {
            HidePanel();
            pnl_ViewReservation.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void picBackButton_Click_1(object sender, EventArgs e)
        {
            HidePanel();
            pnl_ViewReservation.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HidePanel();
            CheckReservations();
        }

        private void pbTableViewLogOut_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void OnTableButtonClick(object sender, EventArgs e)
        {
            try
            {

                if (!int.TryParse((sender as Button).Text, out int id))
                {
                    throw new Exception("Could not read table ID.");
                }

                Reservation reservation = null;
                if ((sender as Button).Tag != null)
                {
                    reservation = (Reservation)(sender as Button).Tag;
                }

                HandleTableButtonClick(id);
            }
            catch (Exception ex)
            {
                ErrorLogger.Instance.WriteError(ex, "Something went wrong while opening table details.");
            }
        }
        private void HandleTableButtonClick(int tableId)
        {
            try
            {
                if (!paymentService.HasBill(tableId))
                {
                    // Table has no bill?
                    // Go to order view.
                    ShowOrderView(tableId);
                    //HideNotification();
                    //pb_TableAgenda.Hide();
                }
                else
                {
                    // Get the bill for this table.
                    this.currentBill = paymentService.GetBill(tableId);
                    this.currentTableNumber = tableId;

                    if (!orderLogic.HasBillOrders(this.currentBill))
                    {
                        // Bill has no orders?
                        // Automatically go into order creation process.
                        ShowOrderView(tableId, this.currentBill);
                        HideNotification();
                        pb_TableAgenda.Hide();
                    }
                    else
                    {
                        // Bill has some orders?
                        // Show table details and load table's information.
                        pnl_TableDetailView.Show();
                        lv_TableDetailView_SelectedIndexChanged(tableId, this.currentBill);
                        HideNotification();
                        pb_TableAgenda.Hide();
                    }
                }
            }
            catch(Exception ex)
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
                orderViewWindow.Location = this.Location; // Show OrderView right on top of this window.
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
                        li.SubItems.Add(order.PlacedTime.ToString());
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

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            ShowOrderView(currentTableNumber, currentBill);
        }

        private void TableViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Should make it so the Login form also gets closed...
            timer.Stop();
            Application.Exit();
        }

        private void pbTableDetailViewGoBack_Click(object sender, EventArgs e)
        {
            HidePanel();
            ShowNotification();
            pb_TableAgenda.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pnl_ViewReservation_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btn_TableDetailViewAddOrder_Click(object sender, EventArgs e)
        {
            ShowOrderView(currentTableNumber, currentBill);
        }

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
                        MessageBox.Show("You cannot change status yet");
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
            catch(Exception ex)
            {
                MessageBox.Show($"Something went wrong while executing button: {ex.Message}");
            }
        }

        private void TableViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_TableDetailViewCheckOut_Click(object sender, EventArgs e)
        {
            paymentWindow = new Payment(currentTableNumber, pnl_TableDetailView);
            paymentWindow.Show();
        }

        private void tableView_OccupyTable_Click(object sender, EventArgs e)
        {
            tableButtons[reservation.tableid - 1].Image = Properties.Resources.occupied;
        }

        private void btn_Table6_Click(object sender, EventArgs e)
        {

        }

        private void lv_TableDetailView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pb_TableAgenda_Click(object sender, EventArgs e)
        {

        }       

        private void btn_Occupy_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}