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

            Employee employee = new Employee();
            employee.email = "test@example.com";
            employee.id = 5;

            OrderView orderView = new OrderView(employee, bill, 1);
            orderView.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e,Employee employee)
        {
            KitchenViewForm kitchen = new KitchenViewForm(employee);
            kitchen.ShowDialog();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
