using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RestaurantLogic;
using RestaurantModel;
using System.Threading;
using System.Threading.Tasks;
using RestaurantChapeau.OrderViewUIController;

namespace RestaurantChapeau
{
    public partial class OrderView : Form
    {
        OrderLogic orderLogic;
        Bill bill;

        MenuType currentMenuType;

        Font fontMenuType = new Font("Segoe UI", 18);

        Color activeButtonColor = Color.FromArgb(255, 67, 179, 215);
        Color activeButtonTextColor = Color.FromArgb(255, 255, 255, 255);

        public OrderView(Bill bill)
        {
            InitializeComponent();

            if (bill == null)
            {
                throw new NullReferenceException("Bill must be provided!");
            }

            this.bill = bill;

            // Hide tab view tabs.
            theTabControl.Appearance = TabAppearance.FlatButtons;
            theTabControl.ItemSize = new Size(0, 1);
            theTabControl.SizeMode = TabSizeMode.Fixed;

            OrderBasket.Instance.Clear();
            OrderBasket.Instance.AddListener(this);

            lblTopBarText.Font = FontManager.Instance.ScriptMT(lblTopBarText.Font.Size);

            try
            {
                Task.Run(() => AttemptConnect());
            }
            catch (Exception ex)
            { 
                ShowFail("Couldn't obtain the menu info :(");
                ErrorLogger.Instance.WriteError(ex, false);
            }
        }

        void AttemptConnect()
        {
            orderLogic = new OrderLogic();

            if (lblHeader.InvokeRequired)
            {
                Action safeLoad = delegate { LoadGUI(); };
                lblHeader.Invoke(safeLoad);
            }
        }

        void LoadGUI()
        {
            LoadHeader();
            try
            {
                LoadMenuTypes();
                LoadMenu(currentMenuType);
                theTabControl.SelectedTab = tabPageMenu;
            }
            catch (Exception ex)
            {
                ErrorLogger.Instance.WriteError(ex, false);
                ShowFail("Can't obtain menu info :(");
            }
        }

        void LoadHeader()
        {
            string headerText = theTabControl.SelectedTab == tabPageMenu ? $"Menu" : $"Summary";
            lblHeader.Text = headerText;
        }

        private void LoadMenuTypes()
        {
            ClearMenuTypes();
            List<MenuType> menuTypes = orderLogic.GetMenuTypes();

            foreach (MenuType menuType in menuTypes)
            {
                Button menuTypeButton = new Button();
                menuTypeButton.Tag = menuType;
                menuTypeButton.Text = menuType.Name;
                menuTypeButton.Height = flwMenuTypes.Height - 22;
                menuTypeButton.Width = flwMenuTypes.Width / menuTypes.Count - 22;
                menuTypeButton.Click += OnMenuTypeClick;
                menuTypeButton.TextAlign = ContentAlignment.MiddleCenter;
                menuTypeButton.Font = fontMenuType;
                menuTypeButton.Margin = new Padding(10, 10, 10, 10);
                menuTypeButton.FlatStyle = FlatStyle.Flat;
                menuTypeButton.FlatAppearance.BorderSize = 0; 
                flwMenuTypes.Controls.Add(menuTypeButton);
            }

            if (currentMenuType == null)
            {
                currentMenuType = menuTypes[0];
            }
        }

        private void ClearMenuTypes()
        {
            flwMenuTypes.Controls.Clear();
        }

        private void OnMenuTypeClick(object sender, EventArgs e)
        {
            currentMenuType = (MenuType)(sender as Button).Tag;

            try
            {
                LoadMenu(currentMenuType);
            }
            catch (Exception ex)
            {
                ErrorLogger.Instance.WriteError(ex);
            }
        }

        private void LoadMenu(MenuType menuType)
        {
            // First we update the buttons of menu types.
            foreach (Control control in flwMenuTypes.Controls)
            {
                if (control is Button)
                {
                    Button button = control as Button;
                    Color backgroundColor = Color.White;
                    Color textColor = Color.Black;
                    if (button.Tag == menuType)
                    {
                        backgroundColor = activeButtonColor;
                        textColor = activeButtonTextColor;
                    }

                    button.BackColor = backgroundColor;
                    button.ForeColor = textColor;
                }
            }

            ClearMenuItems();
            List<MenuCategory> menuCategories = orderLogic.GetMenuCategories(menuType);

            foreach (MenuCategory menuCategory in menuCategories)
            {
                new CategorySeparatorUI(flwMenuItems, menuCategory.Name);

                List<MenuItem> menuItems = orderLogic.GetMenuItems(menuType, menuCategory);

                foreach (MenuItem menuItem in menuItems)
                {
                    new MenuItemUI(flwMenuItems, menuItem, lblSub.Left);
                }
            }
        }

        private void ClearMenuItems()
        {
            flwMenuItems.Controls.Clear();
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            try
            {
                LoadCheckout();
            }
            catch (Exception ex)
            {
                ErrorLogger.Instance.WriteError(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadCheckout()
        {
            flwCheckout.Controls.Clear();

            if (OrderBasket.Instance.GetAll().Count == 0)
            {
                Label lblNothingPurchased = new Label();
                lblNothingPurchased.Text = "No items selected!";
                lblNothingPurchased.Font = new Font("Segoe UI", 18);
                lblNothingPurchased.TextAlign = ContentAlignment.MiddleCenter;
                lblNothingPurchased.Width = flwCheckout.Width - 10;
                lblNothingPurchased.Height = flwCheckout.Height - 10;
                flwCheckout.Controls.Add(lblNothingPurchased);
                btnFinish.Enabled = false;
            }
            else
            {
                int count = 1;
                foreach (MenuItem menuItem in OrderBasket.Instance.GetAll())
                {
                    new MenuItemUI(flwCheckout, menuItem, lblQuantityCheckout.Left);
                    count++;
                }

                btnFinish.Enabled = true;
            }

            theTabControl.SelectedTab = tabPageCheckout;
            LoadHeader();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            Order order = orderLogic.CreateNewOrderForBill(bill);

            foreach (MenuItem basketItem in OrderBasket.Instance.GetAll())
            {
                orderLogic.AddItemToOrder(order, basketItem, basketItem.Quantity);
            }

            OrderBasket.Instance.Clear();

            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            theTabControl.SelectedTab = tabPageMenu;
            LoadHeader();

            try
            {
                LoadMenu(currentMenuType);
            }
            catch (Exception ex)
            {
                ErrorLogger.Instance.WriteError(ex);
            }
        }

        private void OrderView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (OrderBasket.Instance.Count > 0)
            {
                DialogResult dl = MessageBox.Show("You have selected items to order.\n\nAre you sure you want to cancel this order?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dl == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        public void UpdateUI()
        {
            btnPlaceOrder.Text = $"View Order ({OrderBasket.Instance.Count})";
            btnFinish.Enabled = OrderBasket.Instance.Count > 0;
        }

        private void ShowFail(string failReason)
        {
            lblConnecting.Text = failReason;
            theTabControl.SelectedTab = tabConnecting;
        }

        private void picBackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
