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
        OrderLogic orderLogic;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            orderLogic = new OrderLogic();
        }
    }
}
