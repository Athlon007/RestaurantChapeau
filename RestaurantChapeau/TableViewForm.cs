//<<<<<<< HEAD
//﻿using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Text;
//using System.Windows.Forms;
//using RestaurantLogic;
//using RestaurantModel;
//using RestaurantDAL;
//using RestaurantChapeau.OrderViewUIController;
//using System.Threading.Tasks;

//namespace RestaurantChapeau
//{
//    public partial class TableViewForm : Form
//    {
//        ReservationService reservationService = new ReservationService();
//        Reservation reservation = new Reservation();
//        Employee currentEmployee;

//        Button[] tableButtons;

//        // For UI scaling
//        const int WindowWidth = 651;
//        const int WindowHeight = 830;

//        OrderLogic orderLogic = new OrderLogic();
//        PaymentService paymentService = new PaymentService();
//        Bill currentBill;
//        int currentTableNumber;



//        public TableViewForm(Employee employee)
//        {
//            InitializeComponent();
//            currentEmployee = employee;

//            DPIScaler.Instance.UpdateToForm(this);
//            this.Width = Convert.ToInt32(DPIScaler.Instance.ScaleWidth * WindowWidth);
//            this.Height = Convert.ToInt32(DPIScaler.Instance.ScaleHeight * WindowHeight);

//            //lblTopBarText.Font = FontManager.Instance.ScriptMT(lblTopBarText.Font.Size);

//            tableButtons = new Button[]
//            {
//                btn_Table1,
//                btn_Table2,
//                btn_Table3,
//                btn_Table4,
//                btn_Table5,
//                btn_Table6,
//                btn_Table7,
//                btn_Table8,
//                btn_Table9,
//                btn_Table10
//            };
//            CheckReservations();
//        }

//        private void CheckReservations()
//        {
//            for (int i = 0; i < tableButtons.Length; i++)
//            {
//                Button button = tableButtons[i];
//                button.Image = Properties.Resources.screenshotTable;
//                button.Tag = null;

//                if (reservationService.TableHasBill(i + 1))
//                {
//                    button.Image = Properties.Resources.occupied;
//                }
//            }

//            List<Reservation> reservations = reservationService.GetAllReservations();
//            foreach (Reservation reservation in reservations)
//            {
//                tableButtons[reservation.tableid - 1].Tag = reservation;
//                if (reservation.isReserved)
//                {
//                    bool isTableReserved = DateTime.Now.AddHours(+1) >= reservation.ReservationStart;
//                    bool isTakenNow = DateTime.Now > reservation.ReservationStart;
//                    bool tableHasBill = reservationService.TableHasBill(reservation.tableid);
//                    if (isTakenNow && tableHasBill)
//                    {
//                        tableButtons[reservation.tableid - 1].Image = Properties.Resources.occupied;
                        
//                    }
//                    else if(isTableReserved)
//                    {
//                        tableButtons[reservation.tableid - 1].Image = Properties.Resources.reserved;
//                    }
//                    else
//                    {
//                        tableButtons[reservation.tableid - 1].Image = Properties.Resources.screenshotTable;
//                    }                    
//                }
//            }
//        }

//        private void TableViewForm_Load(object sender, EventArgs e)
//        {
//            dateTimePicker1.MinDate = DateTime.Now;
//            dateTimePicker1.Value = DateTime.Now;
//        }


//        private void btn_TableViewPnGoBack_Click(object sender, EventArgs e)
//        {
//            TableViewForm_Load(sender, e);
//        }


//        private void btn_TableViewOrder_Click(object sender, EventArgs e)
//        {
//            Form1 form1 = new Form1();
//            form1.Show();
//        }

//        private void btn_TableViewReservation_Click(object sender, EventArgs e)
//        {
//            //theTabControl.SelectedTab = tabReservation;
//            pnl_ViewReservation.Show();

//        }

//        private void btn_MakeReservation_Click(object sender, EventArgs e)
//        {
//            ReservationService reservationService = new ReservationService();
//            string firstName = txt_ReservationFirstName.Text;
//            string lastName = txt_ReservationLastName.Text;
//            string email = txt_ReservationEmail.Text;
//            DateTime reservationStart = dateTimePicker1.Value;
//            string TableId = txt_ReservationTableID.Text;

//            //add the customer info for the reservation to the database
//            reservationService.AddToReservation(firstName, lastName, email, "1", reservationStart, TableId);
//            MessageBox.Show("Succesfully made reservation!");

//            //hide the panels and show the dashboard again
//            //theTabControl.SelectedTab = tabPageMain;
//            txt_ReservationFirstName.Clear();
//            txt_ReservationLastName.Clear();
//            txt_ReservationEmail.Clear();
//            txt_ReservationTableID.Clear();

//        }

//        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
//        {

//        }

//        private void btn_Test_Click(object sender, EventArgs e)
//        {
//            //theTabControl.SelectedTab = tabViewReservations;
//            try
//            {
//                DisplayReservation();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }
//        }

//        private void DisplayReservation()
//        {
//            List<Reservation> reservationList = reservationService.GetAllReservations();

//            lV_ReservationDisplay.Clear();
//            lV_ReservationDisplay.Columns.Add("ID", 50, HorizontalAlignment.Left);
//            lV_ReservationDisplay.Columns.Add("First Name", 90, HorizontalAlignment.Left);
//            lV_ReservationDisplay.Columns.Add("Last Name", 90, HorizontalAlignment.Left);
//            lV_ReservationDisplay.Columns.Add("Email", 150, HorizontalAlignment.Left);
//            lV_ReservationDisplay.Columns.Add("Time", 150, HorizontalAlignment.Left);
//            lV_ReservationDisplay.Columns.Add("Table number", 150, HorizontalAlignment.Left);
//            lV_ReservationDisplay.View = View.Details;
//            foreach (Reservation r in reservationList)
//            {
//                ListViewItem li = new ListViewItem(r.reservationID.ToString());
//                li.SubItems.Add(r.firstName);
//                li.SubItems.Add(r.lastName);
//                li.SubItems.Add(r.email);
//                li.SubItems.Add(r.ReservationStart.ToString());
//                li.SubItems.Add(r.tableid.ToString());
//                lV_ReservationDisplay.Items.Add(li);
//            }
//        }

//        public void HidePanel()
//        {
//            pnl_Reservation.Hide();
//            pnl_ViewReservation.Hide();
//        }

//        private void btn_MakeReservationGoBack_Click(object sender, EventArgs e)
//        {
//            HidePanel();
//            pnl_ViewReservation.Show();
//        }

//        private void btn_ViewReservationGoBack_Click(object sender, EventArgs e)
//        {
//            HidePanel();
//            DisplayReservation();
//            CheckReservations();
//        }

//        private void btn_ViewReservationMake_Click(object sender, EventArgs e)
//        {
//            HidePanel();
//            pnl_Reservation.Show();
//        }

//        private void btn_ViewReservationCancel_Click(object sender, EventArgs e)
//        {
//            //dialog pop up asking the user if he is sure of the action
//            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to cancel this reservation? ", "Cancel reservation", MessageBoxButtons.YesNo);

//            //if the answer is yes proceed to remove activity
//            if (dialogResult == DialogResult.Yes)
//            {
//                //create activity object
//                Reservation reservation = new Reservation();
//                {
//                    reservation.reservationID = int.Parse(lV_ReservationDisplay.SelectedItems[0].SubItems[0].Text);
//                };

//                //delete reservation
//                reservationService.CancelReservation(reservation);
//                // show that delete was successful
//                MessageBox.Show("Succeesfully cancel the reservation!");
//                //refresh panel
//                DisplayReservation();
//                pnl_ViewReservation.Show();

//            }

//            //if the answer is no do nothing
//            else if (dialogResult == DialogResult.No)
//            {
//                return;
//            }
//        }

//        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
//        {

//        }

//        private void label1_Click(object sender, EventArgs e)
//        {
//        }

//        private void button1_Click_1(object sender, EventArgs e)
//        {            
//            this.Close();
//            LoginForm loginForm = new LoginForm();
//            loginForm.Show();
//        }
//    }
//}
//=======//
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

namespace RestaurantChapeau
{
    public partial class TableViewForm : Form
    {
        ReservationService reservationService = new ReservationService();
        Reservation reservation = new Reservation();
        Employee currentEmployee;

        Button[] tableButtons;

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
            HidePanel();
            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker1.Value = DateTime.Now;
        }
        public void HidePanel()
        {
            pnl_Reservation.Hide();
            pnl_ViewReservation.Hide();
        }        
        private void btn_TableViewOrder_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btn_Table1.BackColor = Color.Red;
            btn_Table1.Image = Properties.Resources.occupied;

            if (reservation.tableid == 2)
            {
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_TableViewReservation_Click(object sender, EventArgs e)
        {
            HidePanel();
            pnl_Reservation.Show();
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

            if(firstName == "" || lastName == "" || email == ""||reservationStart == null||TableId=="")
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
        }

        private void pbTableViewLogOut_Click_1(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void btn_Table1_Click_1(object sender, EventArgs e)
        {
            HidePanel();
            Reservation reservation = reservationService.GetReservationByTableId(1);
            bool isTableReserved = DateTime.Now.AddHours(+1) >= reservation.ReservationStart;
            if (reservation.isReserved)
            {
                if (isTableReserved)
                {
                    MessageBox.Show("This table is currently reserved, you cannot add order(s)");
                }               
            }
            else
            {
                MessageBox.Show("hello");

            }
        }

        private void btn_Table2_Click_1(object sender, EventArgs e)
        {
            HidePanel();
            Reservation reservation = reservationService.GetReservationByTableId(2);
            bool isTableReserved = DateTime.Now.AddHours(+1) >= reservation.ReservationStart;
            if (reservation.isReserved)
            {
                if (isTableReserved)
                {
                    MessageBox.Show("This table is currently reserved, you cannot add order(s)");
                }               
            }
            else
            {
                MessageBox.Show("hello");

            }
        }

        private void btn_Table3_Click_1(object sender, EventArgs e)
        {
            HidePanel();
            Reservation reservation = reservationService.GetReservationByTableId(3);
            bool isTableReserved = DateTime.Now.AddHours(+1) >= reservation.ReservationStart;
            if (reservation.isReserved)
            {
                if (isTableReserved)
                {
                    MessageBox.Show("This table is currently reserved, you cannot add order(s)");
                }            
            }
            else
            {
                MessageBox.Show("hello");

            }
        }

        private void btn_Table4_Click_1(object sender, EventArgs e)
        {
            HidePanel();
            Reservation reservation = reservationService.GetReservationByTableId(4);
            bool isTableReserved = DateTime.Now.AddHours(+1) >= reservation.ReservationStart;
            if (reservation.isReserved)
            {
                if (isTableReserved)
                {
                    MessageBox.Show("This table is currently reserved, you cannot add order(s)");
                }               
            }
            else
            {
                MessageBox.Show("hello");

            }
        }

        private void btn_Table5_Click_1(object sender, EventArgs e)
        {
            HidePanel();
            Reservation reservation = reservationService.GetReservationByTableId(5);
            bool isTableReserved = DateTime.Now.AddHours(+1) >= reservation.ReservationStart;
            if (reservation.isReserved)
            {
                if (isTableReserved)
                {
                    MessageBox.Show("This table is currently reserved, you cannot add order(s)");
                }               
            }
            else
            {
                MessageBox.Show("hello");

            }
        }

        private void btn_Table6_Click_1(object sender, EventArgs e)
        {
            HidePanel();
            Reservation reservation = reservationService.GetReservationByTableId(6);
            bool isTableReserved = DateTime.Now.AddHours(+1) >= reservation.ReservationStart;
            if (reservation.isReserved)
            {
                if (isTableReserved)
                {
                    MessageBox.Show("This table is currently reserved, you cannot add order(s)");
                }              
            }
            else
            {
                MessageBox.Show("hello");

            }
        }

        private void btn_Table7_Click_1(object sender, EventArgs e)
        {
            HidePanel();
            Reservation reservation = reservationService.GetReservationByTableId(7);
            bool isTableReserved = DateTime.Now.AddHours(+1) >= reservation.ReservationStart;
            if (reservation.isReserved)
            {
                if (isTableReserved)
                {
                    MessageBox.Show("This table is currently reserved, you cannot add order(s)");
                }               
            }
            else
            {
                MessageBox.Show("hello");

            }
        }

        private void btn_Table8_Click_1(object sender, EventArgs e)
        {
            HidePanel();
            Reservation reservation = reservationService.GetReservationByTableId(8);
            bool isTableReserved = DateTime.Now.AddHours(+1) >= reservation.ReservationStart;
            if (reservation.isReserved)
            {
                if (isTableReserved)
                {
                    MessageBox.Show("This table is currently reserved, you cannot add order(s)");
                }                
            }
            else
            {
                MessageBox.Show("hello");

            }
        }

        private void btn_Table9_Click_1(object sender, EventArgs e)
        {
            HidePanel();
            Reservation reservation = reservationService.GetReservationByTableId(9);
            bool isTableReserved = DateTime.Now.AddHours(+1) >= reservation.ReservationStart;
            if (reservation.isReserved)
            {
                if (isTableReserved)
                {
                    MessageBox.Show("This table is currently reserved, you cannot add order(s)");
                }                
            }
            else
            {
                MessageBox.Show("hello");

            }
        }

        private void btn_Table10_Click_1(object sender, EventArgs e)
        {
            HidePanel();
            Reservation reservation = reservationService.GetReservationByTableId(10);
            bool isTableReserved = DateTime.Now.AddHours(+1) >= reservation.ReservationStart;
            if (reservation.isReserved)
            {
                if (isTableReserved)
                {
                    MessageBox.Show("This table is currently reserved, you cannot add order(s)");
                }               
            }
            else
            {
                MessageBox.Show("hello");

            }
        }
    }
}
//>>>>>>> 8482589 (.)
