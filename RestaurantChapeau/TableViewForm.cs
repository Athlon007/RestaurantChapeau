using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RestaurantChapeau
{
    public partial class TableViewForm : Form
    {
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
    }
}
