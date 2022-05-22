using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurantLogic;
using RestaurantModel;

namespace RestaurantChapeau
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /////////////////////////////////
        // FOR TESTING PURPOSEES ONLY! //
        /////////////////////////////////
        private void button1_Click(object sender, EventArgs e)
        {
            Table table = new Table();
            table.Id = 1;
            Bill bill = new Bill();
            bill.Id = 1;
            bill.Table = table;

            OrderView orderView = new OrderView(bill);
            orderView.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KitchenViewForm kitchen = new KitchenViewForm();
            kitchen.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
