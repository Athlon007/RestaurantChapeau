using System;
using System.Drawing;
using System.Windows.Forms;
using RestaurantModel;

namespace RestaurantChapeau
{
    class MenuItemUIControl
    {
        private MenuItem menuItem;
        private Font menuItemsFont = new Font("Segoe UI", 12);
        const int RowHeight = 60;

        private Label lblName;
        private Button btnQuantitySubtract, btnQuantityAdd;
        private TextBox txtQuantity; 

        public bool DeleteOnZero { get; set; }

        public MenuItemUIControl(FlowLayoutPanel flow, MenuItem menuItem, int nameSpace)
        {
            this.menuItem = menuItem;

            lblName = new Label();
            lblName.Text = menuItem.Name;
            lblName.Font = menuItemsFont;
            lblName.Height = RowHeight;
            lblName.Width = nameSpace;
            lblName.TextAlign = ContentAlignment.MiddleLeft;
            flow.Controls.Add(lblName);

            btnQuantitySubtract = new Button();
            btnQuantitySubtract.Text = "-";
            btnQuantitySubtract.Height = RowHeight;
            btnQuantitySubtract.Font = menuItemsFont;
            btnQuantitySubtract.Click += QuantitySubtractClick;
            flow.Controls.Add(btnQuantitySubtract);

            txtQuantity = new TextBox();
            UpdateQuantityTextBox();
            txtQuantity.Font = menuItemsFont;
            txtQuantity.Height = RowHeight;
            txtQuantity.TextAlign = HorizontalAlignment.Center;
            txtQuantity.KeyPress += TextBoxQuantityKeyPress;
            txtQuantity.TextChanged += TextBoxQuantityTextChanged;
            flow.Controls.Add(txtQuantity);        

            btnQuantityAdd = new Button();
            btnQuantityAdd.Text = "+";
            btnQuantityAdd.Height = RowHeight;
            btnQuantityAdd.Font = menuItemsFont;
            btnQuantityAdd.Click += QuantityAddClick;
            flow.Controls.Add(btnQuantityAdd);
        }

        private void TextBoxQuantityTextChanged(object sender, EventArgs e)
        {
            int quantity = 0;
            if (txtQuantity.Text.Length > 0)
            {
                quantity = int.Parse(txtQuantity.Text);
            }

            OrderBasket.Instance.Set(menuItem, quantity);
            UpdateQuantityTextBox();

            // Always set the cursor at the end.
            txtQuantity.SelectionStart = txtQuantity.Text.Length;
            txtQuantity.SelectionLength = 0;
        }

        private void TextBoxQuantityKeyPress(object sender, KeyPressEventArgs e)
        {
            // Don't allow anything other than digits.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void QuantityAddClick(object sender, EventArgs e)
        {
            OrderBasket.Instance.Add(menuItem);
            UpdateQuantityTextBox();
        }

        private void QuantitySubtractClick(object sender, EventArgs e)
        {
            OrderBasket.Instance.Subtract(menuItem);
            UpdateQuantityTextBox();
        }

        private void UpdateQuantityTextBox()
        {
            txtQuantity.Text = OrderBasket.Instance.ItemCount(menuItem).ToString();
        }
    }
}
