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

        const int ButtonWidth = 20;

        public OrderSeparatorUI(FlowLayoutPanel flow, string orderName, Order order, EventHandler OnMarkAsServedClick) : base(flow)
        {
            // Order name
            Label lblName = AddLabelWithoutPanel(orderName, 20);
            lblName.Font = orderFont;

            // Status
            string statusText = order.Status.ToString();
            if (order.Status == OrderStatus.NotStarted)
            {
                statusText = "Not Started";
            }
            else if (order.Status == OrderStatus.ReadyToServe)
            {
                statusText = "Ready To Serve";
            }
            Label lblStatus = AddLabelWithoutPanel(statusText, 20);
            lblStatus.Font = statusFont;

            // Button "mark as served".
            Button btnMarkAsServed = AddButton("Mark as Served", OnMarkAsServedClick);
            btnMarkAsServed.Height = lblStatus.Height;
            btnMarkAsServed.Width = Convert.ToInt32(DPIScaler.Instance.ScaleWidth * ButtonWidth);
            btnMarkAsServed.Tag = order;
            if (order.Status != OrderStatus.ReadyToServe)
            {
                btnMarkAsServed.Enabled = false;
            }
            else
            {
                btnMarkAsServed.Click += OnMarkAsServedClick;
            }

            SetLineBreak(btnMarkAsServed);
            
            // Make status label take most of the width (and push the 
            lblStatus.AutoSize = false;
            lblStatus.Height = lblName.Height;
            lblStatus.Width = flow.Width - lblName.Width - Convert.ToInt32(DPIScaler.Instance.ScaleWidth * 10);
        }
    }
}
