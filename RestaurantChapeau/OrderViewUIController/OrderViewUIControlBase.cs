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
        private Font txtboxFont = new Font("Segoe UI", 16);
        private Color backgroundColor = Color.FromArgb(56, 186, 186, 186);
        private Padding margin = new Padding(4, 10, 4, 10);

        const int RowHeight = 100;
        private int targetHeight;

        private List<Control> controls;

        public OrderViewUIControlBase(FlowLayoutPanel flow)
        {
            this.flow = flow;
            targetHeight = RowHeight;
            controls = new List<Control>();
        }

        public Button AddButton(string text, EventHandler onClickAction)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Height = targetHeight;
            btn.Font = menuItemsFont;
            btn.Margin = margin;
            btn.Click += onClickAction;
            flow.Controls.Add(btn);

            controls.Add(btn);

            return btn;
        }

        public Label AddLabel(string text, int width = -1)
        {
            int labelWidth = width != -1 ? width : RowHeight;

            Panel pnl = new Panel();
            pnl.Height = targetHeight;
            pnl.Width = labelWidth;
            pnl.BackColor = backgroundColor;
            pnl.Margin = margin;
            flow.Controls.Add(pnl);

            Label label = AddLabelWithoutPanel(text, labelWidth, true);
            pnl.Controls.Add(label);

            controls.Add(pnl);
            controls.Add(label);

            return label;
        }

        public Label AddLabelWithoutPanel(string text, int width = -1, bool doNotAddToFlow = false)
        {
            Label label = new Label();
            label.Text = text;
            label.Padding = new Padding(10, 0, 10, 0);
            label.Font = menuItemsFont;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.AutoSize = false;
            label.BackColor = Color.Transparent;
            label.Width = width;
            label.Height = RowHeight;
            label.MaximumSize = new Size(width, targetHeight);

            if (!doNotAddToFlow)
            {
                flow.Controls.Add(label);
            }

            return label;
        }

        public TextBox AddTextBox()
        {
            TextBox txt = new TextBox();
            txt.Font = txtboxFont;
            txt.MinimumSize = new Size(RowHeight, targetHeight);
            txt.TextAlign = HorizontalAlignment.Center;
            txt.Margin = margin;
            flow.Controls.Add(txt);

            controls.Add(txt);

            return txt;
        }

        public void SetLineBreak(Control control)
        {
            flow.SetFlowBreak(control, true);
        }
    }
}
