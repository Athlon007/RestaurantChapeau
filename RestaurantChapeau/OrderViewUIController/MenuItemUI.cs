using System;
using System.Windows.Forms;
using RestaurantModel;

namespace RestaurantChapeau.OrderViewUIController
{
    internal class MenuItemUI : OrderViewUIControlBase
    {
        private MenuItem menuItem;
        private TextBox txtQuantity;

        public MenuItemUI(FlowLayoutPanel flow, MenuItem menuItem) : base(flow)
        {
            this.menuItem = menuItem;

            // Item name label.
            Label lblName = AddLabel(menuItem.Name);

            // Subtract Button
            Button btnSubtract = AddButton("-", QuantitySubtractClick);

            // TextBox Quantity
            txtQuantity = AddTextBox();
            txtQuantity.TextChanged += TextBoxQuantityTextChanged;
            txtQuantity.KeyPress += TextBoxQuantityKeyPress;
            UpdateQuantityTextBox();

            // Add Button
            Button btnAdd = AddButton("+", QuantityAddClick);

            // resize the name label to occupy the most of the screen's width.
            lblName.Parent.Width = flow.Width - btnSubtract.Width * 2 - btnSubtract.Padding.Left * 4 - txtQuantity.Width * 2 - txtQuantity.Parent.Padding.Left * 2;

            SetLineBreak(btnAdd);

            if (menuItem.Stock == 0)
            {
                lblName.Font = new System.Drawing.Font(lblName.Font, System.Drawing.FontStyle.Strikeout);
                btnSubtract.BackColor = lblName.Parent.BackColor;
                btnSubtract.Enabled = false;
                btnAdd.BackColor = lblName.Parent.BackColor;
                btnAdd.Enabled = false;
                //txtQuantity.BackColor = lblName.Parent.BackColor;
                txtQuantity.Enabled = false;
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
    }
}
