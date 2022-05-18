using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RestaurantChapeau
{
    public partial class KitchenViewForm : Form
    {
        public KitchenViewForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HidePanels();
            pnlKitchen_NewOrders.Show();
        }
        private void HidePanels()
        {
            pnlKitchen_NewOrders.Hide();
            pnlKitchen_NewOrders.Hide();
        }
    }
}
