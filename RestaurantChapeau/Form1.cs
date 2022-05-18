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
            OrderLogic orderLogic = new OrderLogic();

            Table table = new Table();
            table.Id = 1;
            Bill bill = new Bill();
            bill.Id = 1;

            OrderView orderView = new OrderView(bill);
            orderView.ShowDialog();
        }
    }
}
