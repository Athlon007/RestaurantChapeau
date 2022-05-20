using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RestaurantLogic;
using RestaurantModel;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantChapeau
{
    public partial class OrderView : Form
    {
        OrderLogic orderLogic;
        Bill bill;
        bool isConnected;

        Font fontMenuType = new Font("Segoe UI", 12);
        Font fontMenuCategory = new Font("Segoe UI", 8);

        public OrderView(Bill bill)
        {
            InitializeComponent();

            this.bill = bill;

            // Hide tab view tabs.
            theTabControl.Appearance = TabAppearance.FlatButtons;
            theTabControl.ItemSize = new Size(0, 1);
            theTabControl.SizeMode = TabSizeMode.Fixed;

            OrderBasket.Instance.Clear();
            OrderBasket.Instance.AddListener(this);

            try
            {
                Task.Run(() => AttemptConnect());
            }
            catch 
            { 
                lblConnecting.Text = "Failed to connect :(";
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
            LoadMenuTypes();

            isConnected = true;
            theTabControl.SelectedTab = tabPageMenu;
        }

        void LoadHeader()
        {
            string headerText = theTabControl.SelectedTab == tabPageMenu ? $"Table {bill.Table.Id}" : $"Checkout Table {bill.Table.Id}";
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
                menuTypeButton.Height = flwMenuTypes.Height;
                menuTypeButton.Width = flwMenuTypes.Width / menuTypes.Count - 7;
                menuTypeButton.Click += OnMenuTypeClick;
                menuTypeButton.TextAlign = ContentAlignment.MiddleLeft;
                menuTypeButton.Font = fontMenuType;
                flwMenuTypes.Controls.Add(menuTypeButton);
            }
        }

        private void ClearMenuTypes()
        {
            flwMenuTypes.Controls.Clear();
        }

        private void OnMenuTypeClick(object sender, EventArgs e)
        {
            foreach (Control control in flwMenuTypes.Controls)
            {
                control.Enabled = true;
            }
            (sender as Control).Enabled = false;

            try
            {
                LoadMenuCategories((MenuType)(sender as Button).Tag);
            }
            catch (Exception ex)
            {
                ErrorLogger.Instance.WriteError(ex);
            }
        }

        private void LoadMenuCategories(MenuType menuType)
        {
            ClearMenuCategories();
            ClearMenuItems();
            List<MenuCategory> menuCategories = orderLogic.GetMenuCategories(menuType);

            foreach (MenuCategory menuCategory in menuCategories)
            {
                Button menuCategoryButon = new Button();
                menuCategory.MenuType = menuType;
                menuCategoryButon.Tag = menuCategory;
                menuCategoryButon.Text = menuCategory.Name;
                menuCategoryButon.Height = flwMenuCategory.Height;
                menuCategoryButon.Width = flwMenuCategory.Width / menuCategories.Count - 7;
                menuCategoryButon.Click += OnMenuCategoryClick;
                menuCategoryButon.Font = fontMenuCategory;
                flwMenuCategory.Controls.Add(menuCategoryButon);
            }
        }

        private void ClearMenuCategories()
        {
            flwMenuCategory.Controls.Clear();
        }

        private void OnMenuCategoryClick(object sender, EventArgs e)
        {
            foreach (Control control in flwMenuCategory.Controls)
            {
                control.Enabled = true;
            }
            (sender as Control).Enabled = false;

            try
            {
                MenuCategory category = (MenuCategory)(sender as Button).Tag;
                MenuType menuType = category.MenuType;
                LoadMenuItems(menuType, category);
            }
            catch (Exception ex)
            {
                ErrorLogger.Instance.WriteError(ex);
            }
        }

        private void LoadMenuItems(MenuType menuType, MenuCategory menuCategory)
        {
            ClearMenuItems();

            List<MenuItem> menuItems = orderLogic.GetMenuItems(menuType, menuCategory);

            int count = 1;
            foreach (MenuItem menuItem in menuItems)
            {
                new MenuItemUIControl(flwMenuItems, menuItem, lblSub.Left, count);
                count++;
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
                foreach (KeyValuePair<int, int> key in OrderBasket.Instance.GetAll())
                {
                    MenuItem menuItem = orderLogic.GetMenuItem(key.Key);
                    new MenuItemUIControl(flwCheckout, menuItem, lblQuantityCheckout.Left, count);
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

            foreach (KeyValuePair<int, int> basketItem in OrderBasket.Instance.GetAll())
            {
                MenuItem menuItem = orderLogic.GetMenuItem(basketItem.Key);
                orderLogic.AddItemToOrder(order, menuItem, basketItem.Value);
            }

            OrderBasket.Instance.Clear();

            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            theTabControl.SelectedTab = tabPageMenu;
            LoadHeader();
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

        public void UpdateViewOrderButton()
        {
            btnPlaceOrder.Text = $"View Order ({OrderBasket.Instance.Count})";
        }
    }
}
