using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RestaurantLogic;
using RestaurantModel;

namespace RestaurantChapeau
{
    public partial class TableViewForm : Form
    {
        ReservationService reservationService;
        public TableViewForm()
        {
            InitializeComponent();
        }
        private void TableViewForm_Load(object sender, EventArgs e)
        {
            HidePanel();
        }
        public void HidePanel()
        {
            pnl_TableViews.Hide();
            pnl_Reservation.Hide();
            pnl_ViewReservation.Hide();
        }             
        private void btn_Table1_Click(object sender, EventArgs e)
        {
            HidePanel();
            pnl_TableViews.Show();
        }
        private void btn_Table2_Click(object sender, EventArgs e)
        {
            HidePanel();
            pnl_TableViews.Show();
        }        
        private void btn_TableViewPnGoBack_Click(object sender, EventArgs e)
        {
            HidePanel();
            TableViewForm_Load(sender, e);
        }

        private void btn_Table3_Click(object sender, EventArgs e)
        {
            HidePanel();
            pnl_TableViews.Show();
        }

        private void btn_Table4_Click(object sender, EventArgs e)
        {
            HidePanel();
            pnl_TableViews.Show();
        }

        private void btn_Table5_Click(object sender, EventArgs e)
        {
            HidePanel();
            pnl_TableViews.Show();
        }

        private void btn_Table6_Click(object sender, EventArgs e)
        {
            HidePanel();
            pnl_TableViews.Show();
        }

        private void btn_Table7_Click(object sender, EventArgs e)
        {
            HidePanel();
            pnl_TableViews.Show();
        }

        private void btn_Table8_Click(object sender, EventArgs e)
        {
            HidePanel();
            pnl_TableViews.Show();
        }

        private void btn_Table9_Click(object sender, EventArgs e)
        {
            HidePanel();
            pnl_TableViews.Show();
        }

        private void btn_Table10_Click(object sender, EventArgs e)
        {
            HidePanel();
            pnl_TableViews.Show();
        }

        private void btn_TableViewOrder_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;            
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

            //add the customer info for the reservation to the database
            reservationService.AddToReservation(firstName, lastName, email,"1", reservationStart, TableId);
            MessageBox.Show("Succesfully made reservation!");

            //hide the panels and show the dashboard again
            HidePanel();
            txt_ReservationFirstName.Clear();
            txt_ReservationLastName.Clear();
            txt_ReservationEmail.Clear();
            txt_ReservationStartTime.Clear();
            txt_ReservationTableID.Clear();

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
                ReservationService reservationService = new ReservationService();
                List<Reservation> reservationList = reservationService.GetAllReservations();

                lV_ReservationDisplay.Clear();
                lV_ReservationDisplay.Columns.Add("ID", 80, HorizontalAlignment.Left);
                lV_ReservationDisplay.Columns.Add("First Name", 150, HorizontalAlignment.Left);
                lV_ReservationDisplay.Columns.Add("Last Name", 100, HorizontalAlignment.Left);
                lV_ReservationDisplay.Columns.Add("Email", 80, HorizontalAlignment.Left);
                lV_ReservationDisplay.Columns.Add("Table Number", 100, HorizontalAlignment.Left);
                lV_ReservationDisplay.View = View.Details;
                foreach (Reservation r in reservationList)
                {
                    ListViewItem li = new ListViewItem(r.reservationID.ToString());
                    li.SubItems.Add(r.firstName);
                    li.SubItems.Add(r.lastName);
                    li.SubItems.Add(r.email);
                    li.SubItems.Add(r.tableid.ToString());
                    lV_ReservationDisplay.Items.Add(li);    
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
