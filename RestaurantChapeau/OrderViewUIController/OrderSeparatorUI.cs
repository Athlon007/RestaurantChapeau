using System;
using System.Drawing;
using System.Windows.Forms;
using RestaurantModel;

namespace RestaurantChapeau.OrderViewUIController
{
    /// <summary>
    /// Used for Table Details view.
    /// </summary>
    internal class OrderSeparatorUI : OrderViewUIControlBase
    {
        private Font orderFont = new Font("Segoe UI", 12, FontStyle.Bold | FontStyle.Italic);
        private Font statusFont = new Font("Segoe UI", 12, FontStyle.Italic);
        private Font buttonFont = new Font("Segoe UI", 12);

        private Color disabledButtonColor = Color.FromArgb(255, 209, 209, 209);
        private Color disabledButtonTextColor = Color.FromArgb(255, 111, 111, 111);

        const int ButtonWidth = 150;

        public OrderSeparatorUI(FlowLayoutPanel flow, string orderName, Order order, EventHandler OnMarkAsServedClick) : base(flow)
        {
            // Order name
            Label lblName = AddLabelWithoutPanel(orderName, 250);
            lblName.Font = orderFont;

            // Status
            string statusText = order.Status.ToString();
            if (order.Status == OrderStatus.NotStarted)
            {
                statusText = "Not Started";
            }
            else if (order.Status == OrderStatus.ReadyToServe)
            {
                statusText = "Ready-To-Serve";
            }
            statusText = "Status: " + statusText;
            Label lblStatus = AddLabelWithoutPanel(statusText);
            lblStatus.Font = statusFont;

            // Button "mark as served".
            Button btnMarkAsServed = AddButton("Mark as Served", OnMarkAsServedClick);
            btnMarkAsServed.Font = buttonFont;
            btnMarkAsServed.Height = lblStatus.Height / 2;
            btnMarkAsServed.Width = Convert.ToInt32(DPIScaler.Instance.ScaleWidth * ButtonWidth);
            btnMarkAsServed.Tag = order;
            Padding btnPadding = btnMarkAsServed.Margin;
            btnPadding.Top *= 3;
            btnMarkAsServed.Margin = btnPadding;
            if (order.Status != OrderStatus.ReadyToServe)
            {
                btnMarkAsServed.Enabled = false;
                btnMarkAsServed.BackColor = disabledButtonColor;
                btnMarkAsServed.ForeColor = disabledButtonTextColor;
            }
            else
            {
                btnMarkAsServed.Click += OnMarkAsServedClick;
            }

            SetLineBreak(btnMarkAsServed);

            // Make status label take most of the width.
            int statusWidth = flow.Width - btnMarkAsServed.Width - Convert.ToInt32(DPIScaler.Instance.ScaleWidth * 170);
            lblStatus.MaximumSize = new Size(statusWidth, lblName.Height);
            lblStatus.Height = lblName.Height;
            lblStatus.Width = statusWidth;
        }
    }
}
