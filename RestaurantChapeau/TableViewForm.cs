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
using System.Threading.Tasks;

namespace RestaurantChapeau
{
    public partial class TableViewForm : Form
    {
        ReservationService reservationService = new ReservationService();
        Reservation reservation = new Reservation();
        Employee currentEmployee;

        Button[] tableButtons;

        // For UI scaling
        const int WindowWidth = 651;
        const int WindowHeight = 830;

        OrderLogic orderLogic = new OrderLogic();
        PaymentService paymentService = new PaymentService();
        Bill currentBill;
        int currentTableNumber;



        public TableViewForm(Employee employee)
        {
            InitializeComponent();
            currentEmployee = employee;

            DPIScaler.Instance.UpdateToForm(this);
            this.Width = Convert.ToInt32(DPIScaler.Instance.ScaleWidth * WindowWidth);
            this.Height = Convert.ToInt32(DPIScaler.Instance.ScaleHeight * WindowHeight);

            // Hide tab view tabs.
            theTabControl.Appearance = TabAppearance.FlatButtons;
            theTabControl.ItemSize = new Size(0, 1);
            theTabControl.SizeMode = TabSizeMode.Fixed;

            lblTopBarText.Font = FontManager.Instance.ScriptMT(lblTopBarText.Font.Size);

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
                    bool isTableReserved = DateTime.Now.AddHours(+1) >= reservation.ReservationStart;
                    bool isTakenNow = DateTime.Now > reservation.ReservationStart;
                    bool tableHasBill = reservationService.TableHasBill(reservation.tableid);
                    if (isTakenNow && tableHasBill)
                    {
                        tableButtons[reservation.tableid - 1].Image = Properties.Resources.occupied;
                        
                    }
                    else if(isTableReserved)
                    {
                        tableButtons[reservation.tableid - 1].Image = Properties.Resources.reserved;
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
            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker1.Value = DateTime.Now;
        }


        private void btn_TableViewPnGoBack_Click(object sender, EventArgs e)
        {
            TableViewForm_Load(sender, e);
        }


        private void btn_TableViewOrder_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void btn_TableViewReservation_Click(object sender, EventArgs e)
        {
            theTabControl.SelectedTab = tabReservation;
            //pnl_ViewReservation.Show();

        }

        private void btn_MakeReservation_Click(object sender, EventArgs e)
        {
            ReservationService reservationService = new ReservationService();
            string firstName = txt_ReservationFirstName.Text;
            string lastName = txt_ReservationLastName.Text;
            string email = txt_ReservationEmail.Text;
            DateTime reservationStart = dateTimePicker1.Value;
            string TableId = txt_ReservationTableID.Text;

            //add the customer info for the reservation to the database
            reservationService.AddToReservation(firstName, lastName, email, "1", reservationStart, TableId);
            MessageBox.Show("Succesfully made reservation!");

            //hide the panels and show the dashboard again
            theTabControl.SelectedTab = tabPageMain;
            txt_ReservationFirstName.Clear();
            txt_ReservationLastName.Clear();
            txt_ReservationEmail.Clear();
            txt_ReservationTableID.Clear();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            theTabControl.SelectedTab = tabViewReservations;
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
            theTabControl.SelectedTab = tabViewReservations;
        }

        private void btn_ViewReservationGoBack_Click(object sender, EventArgs e)
        {
            theTabControl.SelectedTab = tabPageMain;
            DisplayReservation();
            CheckReservations();
        }

        private void btn_ViewReservationMake_Click(object sender, EventArgs e)
        {
            theTabControl.SelectedTab = tabReservation;
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
                DisplayReservation();
                theTabControl.SelectedTab = tabViewReservations;
                
            }

            //if the answer is no do nothing
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The action executed on table button click.
        /// </summary>
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
            
        private void button1_Click_1(object sender, EventArgs e)
        {            
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        /// <summary>
        /// Loads table data.
        /// </summary>
        /// <param name="tableId">Table number.</param>
        /// <param name="reservation">Reservation (if null, Bill is made and OrderView is loaded)</param>
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
                    ShowTableDetails(tableId, currentBill);
                }
            }
        }

        /// <summary>
        /// Shows the order view (on top of the current window).
        /// </summary>
        /// <param name="bill">Bill that curently is served.</param>
        private void ShowOrderView(int tableID, Bill bill = null)
        {
            OrderView order = new OrderView(currentEmployee, bill, tableID);
            order.ShowDialog(this);
            order.Location = this.Location; // Show OrderView right on top of this window.
        }

        /// <summary>
        /// Loads the table bill information and shows the tabPageTableDetails.
        /// </summary>
        /// <param name="tableId"></param>
        /// <param name="bill"></param>
        private void ShowTableDetails(int tableId, Bill bill)
        {
            try
            {
                // Clear up the items belonging to the flwMenuItems.
                flwMenuItems.Controls.Clear();

                // First we want the list of all orders for that bill.
                List<Order> orders = orderLogic.GetOrdersForBill(bill);;
                int count = 1;
                bool allOrdersServed = true;
                decimal total = 0;
                foreach (Order order in orders)
                {
                    // Show the UI separator.
                    new OrderSeparatorUI(flwMenuItems, $"Order #{count}", order, OnMarkOrderAsDelivered_Click);
                    count++;

                    // If any of the orders have status different than "Served", that means not all of them have been served.
                    if (order.Status != OrderStatus.Served)
                    {
                        allOrdersServed = false;
                    }

                    // Now we want the menu items that belong to that order.
                    List<MenuItem> items = orderLogic.GetItemsForOrder(order);
                    foreach (MenuItem item in items)
                    {
                        new MenuItemTableDetailUI(flwMenuItems, item, lblSub.Left);
                        total += item.Quantity * item.PriceBrutto;
                    }
                }

                lblTotal.Text = $"{total} €";

                // Is any order not served yet?
                // Then we disable the button.
                btnCheckout.Enabled = allOrdersServed;

                // Set the btnDummyTable picture and number according to the last button.
                btnDummyTable.Text = tableId.ToString();
                btnDummyTable.BackgroundImage = tableButtons[tableId - 1].Image;

                // Finally, we can switch tabs.
                theTabControl.SelectedTab = tabPageTableDetails;
            }
            catch (Exception ex)
            {
                ErrorLogger.Instance.WriteError(ex);
            }
        }

        /// <summary>
        /// Action executed when user clicks "Mark as Served"
        /// </summary>
        private void OnMarkOrderAsDelivered_Click(object sender, EventArgs events)
        {
            try
            {
                if ((sender as Button).Tag == null)
                {
                    throw new NullReferenceException("Button has no Order attached to it.");
                }

                Order order = (Order)(sender as Button).Tag;
                order.Status = OrderStatus.Served;
                orderLogic.UpdateOrderStatus(order);
            }
            catch (Exception ex)
            {
                ErrorLogger.Instance.WriteError(ex);
            }

            // Refresh the window.
            ShowTableDetails(currentTableNumber, currentBill);
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

        private void picBackButton_Click(object sender, EventArgs e)
        {
            if (theTabControl.SelectedTab != tabPageMain)
            {
                theTabControl.SelectedTab = tabPageMain;
            }
            else
            {
                this.Close();
            }
        }
    }
}
