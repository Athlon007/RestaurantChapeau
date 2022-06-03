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

namespace RestaurantChapeau
{
    public partial class TableViewForm : Form
    {
        ReservationService reservationService = new ReservationService();
        PaymentService paymentService = new PaymentService();
        Reservation reservation = new Reservation();
        Employee currentEmployee;
        Button[] tableButtons;
        OrderLogic orderLogic = new OrderLogic();
        Bill currentBill;
        int currentTableNumber;
        Order order = new Order();
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

            foreach (Button btn in tableButtons)
            {
                btn.Click += OnTableButtonClick;
            }
        }

        private void CheckReservations()
        {
            for (int i = 0; i < tableButtons.Length; i++)
            {
                Button button = tableButtons[i];
                button.Image = Properties.Resources.screenshotTable;
                button.Tag = null;

                if (reservationService.TableHasBill(i + 1))
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
                    bool tableHasBill = reservationService.TableHasBill(reservation.tableid);
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


        private void btn_TableViewOrder_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
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
            ReservationService reservationService = new ReservationService();
            string firstName = txt_ReservationFirstName.Text;
            string lastName = txt_ReservationLastName.Text;
            string email = txt_ReservationEmail.Text;
            DateTime reservationStart = dateTimePicker1.Value;
            string TableId = txt_ReservationTableID.Text;

            if (firstName == "" || lastName == "" || email == "" || reservationStart == null || TableId == "")
            {
                MessageBox.Show("please fill out text box");
            }
            else
            {
                //add the customer info for the reservation to the database
                reservationService.AddToReservation(firstName, lastName, email, "1", reservationStart, TableId);
                MessageBox.Show("Succesfully made reservation!");
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            HidePanel();
            pbTableViewLogOut.Hide();
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
            pbTableViewLogOut.Show();
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
            pbTableViewLogOut.Show();
            CheckReservations();
        }

        private void pbTableViewLogOut_Click_1(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
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
                ErrorLogger.Instance.WriteError(ex, true);
            }
        }
        private void HandleTableButtonClick(int tableId)
        {
            if (!paymentService.HasBill(tableId))
            {
                // Table has no bill?
                // Go to order view.
                ShowOrderView(tableId);
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
                }
                else
                {
                    // Bill has some orders?
                    // Show table details and load table's information.
                    pnl_TableDetailView.Show();
                    lv_TableDetailView_SelectedIndexChanged(tableId, this.currentBill);
                }
            }
        }
        private void ShowOrderView(int tableID, Bill bill = null)
        {
            OrderView order = new OrderView(currentEmployee, bill, tableID);
            order.ShowDialog(this);
            order.Location = this.Location; // Show OrderView right on top of this window.
        }

        private void lv_TableDetailView_SelectedIndexChanged(int tableId, Bill bill)
        {
            lbl_DisplayTableNr.Text = "Table" + tableId.ToString();
            List<Order> orders = orderLogic.GetOrdersForBill(bill);
            lv_TableDetailView.Clear();
            lv_TableDetailView.Columns.Add("ID", 80, HorizontalAlignment.Left);
            lv_TableDetailView.Columns.Add("Status", 80, HorizontalAlignment.Left);
            lv_TableDetailView.Columns.Add("Menu", 260, HorizontalAlignment.Left);
            lv_TableDetailView.Columns.Add("Quantity", 79, HorizontalAlignment.Left);
            lv_TableDetailView.Columns.Add("Time", 160, HorizontalAlignment.Left);

            lv_TableDetailView.View = View.Details;

            foreach (Order order in orders)
            {
                List<MenuItem> menus = orderLogic.GetItemsForOrder(order);
                foreach (MenuItem item in menus)
                {
                    ListViewItem li = new ListViewItem(order.Id.ToString());
                    li.SubItems.Add(order.Status.ToString());
                    li.SubItems.Add(item.Name.ToString());
                    li.SubItems.Add(item.Quantity.ToString());
                    li.SubItems.Add(order.PlacedTime.ToString());
                    li.Tag = order;
                    lv_TableDetailView.Items.Add(li);
                }
            }

        }
        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            ShowOrderView(currentTableNumber, currentBill);
        }

        private void TableViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Should make it so the Login form also gets closed...
            Application.Exit();
        }

        private void pbTableDetailViewGoBack_Click(object sender, EventArgs e)
        {
            HidePanel();
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

            Order orderItem = (Order)lv_TableDetailView.SelectedItems[0].Tag;
            if (orderItem.Status == OrderStatus.NotStarted || orderItem.Status == OrderStatus.Preparing)
            {
                MessageBox.Show("You cannot change status yet");
            }
            else if (orderItem.Status == OrderStatus.ReadyToServe)
            {
                orderItem.Status = OrderStatus.Served;
                orderLogic.UpdateOrderStatus(orderItem);
                lv_TableDetailView_SelectedIndexChanged(currentTableNumber, currentBill);
            }
            else if (orderItem.Status == OrderStatus.Served)
            {
                MessageBox.Show("You already changed status");
            }
        }
    }
}