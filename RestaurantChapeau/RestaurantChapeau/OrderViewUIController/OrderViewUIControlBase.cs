using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace RestaurantChapeau.OrderViewUIController
{
    class OrderViewUIControlBase
    {
        private FlowLayoutPanel flow;

        // Properties
        private Font menuItemsFont = new Font("Segoe UI", 12);
        private Font txtboxFont = new Font("Segoe UI", 24);
        private Color backgroundColor = Color.FromArgb(56, 186, 186, 186);
        private Color textBoxColor = Color.FromArgb(255, 67, 179, 215);
        private Padding margin = new Padding(2, 2, 2, 2);
        private Padding paddingTextBox = new Padding(2, 2, 2, 0);

        //private Color colorButtonHover = Color.FromArgb(255, 230, 230, 230);

        const int RowSize = 48;

        private List<Control> controls;

        public OrderViewUIControlBase(FlowLayoutPanel flow)
        {
            this.flow = flow;
            controls = new List<Control>();

            // Rescale according to form's autoscaling.
            margin.Top = Convert.ToInt32(margin.Top * DPIScaler.Instance.ScaleHeight);
            margin.Left = Convert.ToInt32(margin.Left * DPIScaler.Instance.ScaleHeight);
            margin.Right = Convert.ToInt32(margin.Right * DPIScaler.Instance.ScaleHeight);
            margin.Bottom = Convert.ToInt32(margin.Bottom * DPIScaler.Instance.ScaleHeight);

            paddingTextBox.Top = Convert.ToInt32(paddingTextBox.Top * DPIScaler.Instance.ScaleHeight);
            paddingTextBox.Left = Convert.ToInt32(paddingTextBox.Left * DPIScaler.Instance.ScaleHeight);
            paddingTextBox.Right = Convert.ToInt32(paddingTextBox.Right * DPIScaler.Instance.ScaleHeight);
            paddingTextBox.Bottom = Convert.ToInt32(paddingTextBox.Bottom * DPIScaler.Instance.ScaleHeight);
        }

        public Button AddButton(string text, EventHandler onClickAction)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Width = Convert.ToInt32(RowSize * DPIScaler.Instance.ScaleWidth);
            btn.Height = Convert.ToInt32(RowSize * DPIScaler.Instance.ScaleHeight);
            btn.Font = txtboxFont;
            btn.Margin = margin;
            btn.Click += onClickAction;
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.White;
            btn.FlatAppearance.BorderSize = 4;
            btn.FlatAppearance.BorderColor = textBoxColor;
            btn.FlatAppearance.MouseDownBackColor = textBoxColor;
            btn.TextAlign = ContentAlignment.MiddleCenter;
            flow.Controls.Add(btn);

            controls.Add(btn);

            return btn;
        }

        public Label AddLabel(string text, int width = -1)
        {
            int labelWidth = width != -1 ? width : Convert.ToInt32(RowSize * DPIScaler.Instance.ScaleWidth);

            Panel pnl = new Panel();
            pnl.Height = Convert.ToInt32(RowSize * DPIScaler.Instance.ScaleHeight);
            pnl.Width = labelWidth;
            pnl.BackColor = backgroundColor;
            pnl.Margin = margin;
            flow.Controls.Add(pnl);

            Label label = AddLabelWithoutPanel(text, labelWidth, true);
            label.Dock = DockStyle.Fill;
            pnl.Controls.Add(label);

            controls.Add(pnl);
            controls.Add(label);

            return label;
        }

        public Label AddLabelWithoutPanel(string text, int width = -1, bool doNotAddToFlow = false)
        {
            int labelWidth = width != -1 ? width : Convert.ToInt32(RowSize * DPIScaler.Instance.ScaleWidth);
            Label label = new Label();
            label.Text = text;
            label.Padding = new Padding(4, 0, 4, 0);
            label.Font = menuItemsFont;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.AutoSize = false;
            label.BackColor = Color.Transparent;
            
            int height = Convert.ToInt32(RowSize * DPIScaler.Instance.ScaleHeight);
            label.Width = labelWidth;
            label.Height = height;

            if (!doNotAddToFlow)
            {
                flow.Controls.Add(label);
            }

            return label;
        }

        public TextBox AddTextBox()
        {
            Panel pnl = new Panel();
            pnl.Padding = paddingTextBox;
            pnl.Margin = margin;
            pnl.BackColor = textBoxColor;
            pnl.Width = Convert.ToInt32(RowSize * DPIScaler.Instance.ScaleWidth);
            pnl.Height = Convert.ToInt32(RowSize * DPIScaler.Instance.ScaleHeight);
            flow.Controls.Add(pnl);

            TextBox txt = new TextBox();
            txt.Font = txtboxFont;
            txt.TextAlign = HorizontalAlignment.Center;
            txt.MinimumSize = new Size(0, pnl.Height - Convert.ToInt32(DPIScaler.Instance.ScaleHeight + 1 * 6));
            txt.Dock = DockStyle.Fill;
            pnl.Controls.Add(txt);

            controls.Add(txt);

            return txt;
        }

        public void SetLineBreak(Control control)
        {
            flow.SetFlowBreak(control, true);
        }
    }
}
