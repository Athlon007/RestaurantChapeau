using System;
using System.Collections.Generic;
using System.Text;
using RestaurantModel;
using System.Windows.Forms;

namespace RestaurantChapeau.OrderViewUIController
{
    class MenuSummaryUI : OrderViewUIControlBase
    {
        private MenuItem menuItem;
        private TextBox txtQuantity;
        private bool userInput;

        public MenuSummaryUI(FlowLayoutPanel flow, MenuItem menuItem, int count) : base(flow)
        {
            this.menuItem = menuItem;

            // Counter
            Label lblCounter = AddLabel(count.ToString());
            lblCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

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

            lblName.Parent.Width = flow.Width - lblCounter.Width - btnSubtract.Width * 2 - btnSubtract.Padding.Left * 4 - txtQuantity.Width * 2 - txtQuantity.Parent.Padding.Left * 2;


            SetLineBreak(btnAdd);
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

            if (userInput && quantity == 0)
            {
                userInput = false;
                DialogResult dl = MessageBox.Show($"Do you want to delete \"{menuItem.Name}\"?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                {
                    OrderBasket.Instance.Set(menuItem, 0);
                    OnDeleteItem?.Invoke();
                    return;
                }
            }
            else
            {
                OrderBasket.Instance.Set(menuItem, quantity);
            }
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
            userInput = true;
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
            if (menuItem.Quantity == 1)
            {
                DialogResult dl = MessageBox.Show($"Do you want to delete \"{menuItem.Name}\"?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dl == DialogResult.Yes)
                {
                    OrderBasket.Instance.Subtract(menuItem);
                    OnDeleteItem?.Invoke();
                }
            }
            else
            {
                OrderBasket.Instance.Subtract(menuItem);
            }

            UpdateQuantityTextBox();
        }

        /// <summary>
        /// Updates the quantity label.
        /// </summary>
        private void UpdateQuantityTextBox()
        {
            txtQuantity.Text = OrderBasket.Instance.ItemCount(menuItem).ToString();
        }

        public Action OnDeleteItem { get; set; }
    }
}
