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

        public MenuItemUIControl(FlowLayoutPanel flow, MenuItem menuItem, int nameSpace, int count)
        {
            this.menuItem = menuItem;

            Label lblCount = new Label();
            lblCount.Text = count.ToString();
            lblCount.Font = menuItemsFont;
            lblCount.Height = RowHeight;
            lblCount.Width = RowHeight;
            lblCount.TextAlign = ContentAlignment.MiddleLeft;
            flow.Controls.Add(lblCount);

            lblName = new Label();
            lblName.Text = menuItem.Name;
            lblName.Font = menuItemsFont;
            lblName.Height = RowHeight;
            lblName.Width = nameSpace - lblCount.Width;
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
            txtQuantity.MinimumSize = new Size(txtQuantity.Width, RowHeight);
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
            // Make sure that the "+" is the last element in that flow's line.
            flow.SetFlowBreak(btnQuantityAdd, true);

            if (IsNameOverflowing())
            {
                // If the item's name is overflowing, increase the height of controls by x2.
                int preffered = lblCount.PreferredHeight;
                int real = lblCount.Height;
                int multiplyBy = (int)Math.Ceiling((double)lblCount.Height/ lblCount.PreferredHeight);
                lblCount.Height *= multiplyBy;
                lblName.Height *= multiplyBy;
                btnQuantityAdd.Height *= multiplyBy;
                btnQuantitySubtract.Height *= multiplyBy;
                txtQuantity.MinimumSize = new Size(txtQuantity.Width, txtQuantity.Height * multiplyBy);
            }
        }

        /// <summary>
        /// Called when text in quantity textbox has changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Makes sure that the only allowed input for the textbox is either digit or backspace.
        /// </summary>
        private void TextBoxQuantityKeyPress(object sender, KeyPressEventArgs e)
        {
            // Don't allow anything other than digits.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Adds the number of specific item by calling OrderBasket.Add.
        /// </summary>
        private void QuantityAddClick(object sender, EventArgs e)
        {
            OrderBasket.Instance.Add(menuItem);
            UpdateQuantityTextBox();
        }

        /// <summary>
        /// Subtracts the number of specific item by calling OrderBasket.Subtract.
        /// </summary>
        private void QuantitySubtractClick(object sender, EventArgs e)
        {
            OrderBasket.Instance.Subtract(menuItem);
            UpdateQuantityTextBox();
        }

        /// <summary>
        /// Updates the quantity label.
        /// </summary>
        private void UpdateQuantityTextBox()
        {
            txtQuantity.Text = OrderBasket.Instance.ItemCount(menuItem).ToString();
        }

        /// <summary>
        /// Returns true if the text is longer than the label's width.
        /// </summary>
        /// <returns></returns>
        private bool IsNameOverflowing()
        {
            return lblName.PreferredWidth > lblName.Width;
        }
    }
}
