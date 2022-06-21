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
        private OrderLogic orderLogic;
        private MenuLogic menuLogic;

        private Bill bill;
        private Employee employee;
        private int tableID;

        MenuType currentMenuType;

        Font fontMenuType = new Font("Segoe UI", 18);

        Color activeButtonColor = Color.FromArgb(255, 67, 179, 215);
        Color activeButtonTextColor = Color.FromArgb(255, 255, 255, 255);

        const int WindowWidth = 651;
        const int WindowHeight = 830;

        /// <summary>
        /// Creates a new Order View. Employee that takes the order must be specified. Bill CAN be null.
        /// </summary>
        /// <param name="employee">Employee which takes the order</param>
        /// <param name="bill">Bill for wich the new order is created</param>
        /// <exception cref="ArgumentNullException">Employee cannot be null.</exception>
        public OrderView(Employee employee, Bill bill, int tableID)
        {
            InitializeComponent();
            DPIScaler.Instance.UpdateToForm(this);

            if (employee == null)
            {
                throw new ArgumentNullException("Employee must be provided");
            }

            if (tableID == 0)
            {
                throw new ArgumentNullException("Table ID must be provided!");
            }

            this.bill = bill;
            this.employee = employee;
            this.tableID = tableID;

            // Set form dimensions according constant values and scale it.
            this.Width = Convert.ToInt32(DPIScaler.Instance.ScaleWidth * WindowWidth);
            this.Height = Convert.ToInt32(DPIScaler.Instance.ScaleHeight * WindowHeight);

            // Hide tab view tabs.
            theTabControl.Appearance = TabAppearance.FlatButtons;
            theTabControl.ItemSize = new Size(0, 1);
            theTabControl.SizeMode = TabSizeMode.Fixed;

            // Center the "tick" picture.
            picTick.Left = this.Width / 2 - picTick.Width / 2;

            // Clear order basket.
            OrderBasket.Instance.Clear();
            OrderBasket.Instance.AddListener(this);

            // Assign font to the top-bar "Order" test.
            lblHeader.Font = FontManager.Instance.ScriptMT(lblHeader.Font.Size);           
        }

        private void OrderView_Load(object sender, EventArgs e)
        {
            // create menuLogic and orderLogic objects. Should slightly speed-up the load time.
            try
            {
                orderLogic = new OrderLogic();
                menuLogic = new MenuLogic();
            }
            catch (Exception ex)
            {
                ErrorLogger.Instance.WriteError(ex, "Something went wrong while connecting to the database.");
            }

            LoadGUI();
        }

        /// <summary>
        /// Load MenuTypes and then the first (Lunch) menu.
        /// </summary>
        private void LoadGUI()
        {
            try
            {
                LoadMenuTypes();
                LoadMenu(currentMenuType);

                theTabControl.SelectedTab = tabPageMenu;
                lblHeader.Text = "Menu";
            }
            catch (Exception ex)
            {
                ErrorLogger.Instance.WriteError(ex, "Sometihng went wrong while loading menu types and categories.");
                ShowFail("Can't obtain menu info :(");
            }
        }

        /// <summary>
        /// Loads menu types, and creates buttons in the top nav-bar.
        /// </summary>
        private void LoadMenuTypes()
        {
            flwMenuItems.Controls.Clear();
            List<MenuType> menuTypes = menuLogic.GetMenuTypes();

            // Buttons cannot be exactly the height (or width) of the flwMenuTypes,
            // otherwise they might get cut-off.
            // We also scale the button according to the current DPI, so it looks the same
            // on 1920x1080 and 3600x2252.
            int widthHeighAdjust = Convert.ToInt32(DPIScaler.Instance.ScaleWidth * 11);

            foreach (MenuType menuType in menuTypes)
            {
                Button menuTypeButton = new Button();
                menuTypeButton.Tag = menuType;
                menuTypeButton.Text = menuType.Name;
                menuTypeButton.Height = flwMenuTypes.Height - widthHeighAdjust;
                menuTypeButton.Width = flwMenuTypes.Width / menuTypes.Count - widthHeighAdjust;
                menuTypeButton.Click += OnMenuTypeClick;
                menuTypeButton.TextAlign = ContentAlignment.MiddleCenter;
                menuTypeButton.Font = fontMenuType;
                menuTypeButton.Margin = new Padding(Convert.ToInt32(DPIScaler.Instance.ScaleWidth * 5));
                menuTypeButton.FlatStyle = FlatStyle.Flat;
                menuTypeButton.FlatAppearance.BorderSize = 0; 
                flwMenuTypes.Controls.Add(menuTypeButton);
            }

            if (currentMenuType == null)
            {
                currentMenuType = menuTypes[0];
            }
        }

        /// <summary>
        /// An action executed when MenuType button is clicked.
        /// </summary>
        private void OnMenuTypeClick(object sender, EventArgs e)
        {
            // Do not load menu that is currently selected.
            if (currentMenuType == (MenuType)(sender as Button).Tag)
            {
                return;
            }

            currentMenuType = (MenuType)(sender as Button).Tag;

            try
            {
                LoadMenu(currentMenuType);
            }
            catch (Exception ex)
            {
                ErrorLogger.Instance.WriteError(ex, "Something went wrong while loading the menu.");
            }
        }

        private void UpdateSelectedMenuType(MenuType menuType)
        {
            foreach (Control control in flwMenuTypes.Controls)
            {
                if (control is Button)
                {
                    Button button = control as Button;
                    Color backgroundColor = Color.White; // Unselected background button color.
                    Color textColor = Color.Black; // Unselected font color.
                    if (button.Tag == menuType)
                    {
                        // Is button the menu type that has been picked?
                        // Set the colors of it to selected one.
                        backgroundColor = activeButtonColor;
                        textColor = activeButtonTextColor;
                    }

                    button.BackColor = backgroundColor;
                    button.ForeColor = textColor;
                }
            }
        }

        /// <summary>
        /// Loads selected menu type.
        /// </summary>
        /// <param name="menuType">MenuType to load.</param>
        private void LoadMenu(MenuType menuType)
        {
            // First we update the buttons of menu types.
            UpdateSelectedMenuType(menuType);

            // Clear controls in menu items.
            flwMenuItems.Controls.Clear();

            // Get menu categories of the menu type.
            try
            {
                List<MenuCategory> menuCategories = menuLogic.GetMenuCategories(menuType);

                foreach (MenuCategory menuCategory in menuCategories)
                {
                    // Create new category separator.
                    new CategorySeparatorUI(flwMenuItems, menuCategory.Name);

                    // Get menu items of this menu type and category.
                    List<MenuItem> menuItems = orderLogic.GetMenuItems(menuType, menuCategory);

                    // Create UI stuff for menu items.
                    foreach (MenuItem menuItem in menuItems)
                    {
                        new MenuItemUI(flwMenuItems, menuItem);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Instance.WriteError(ex, "Something went wrong while loading the menu.");
            }
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            LoadCheckout();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Loads the checkout menu.
        /// </summary>
        private void LoadCheckout()
        {
            try
            {
                flwCheckout.Controls.Clear();

                if (OrderBasket.Instance.GetAll().Count == 0)
                {
                    // No menu items?
                    // Create label saying that no items are selected, and disable Finish button.
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
                    // ...otherwise load stuff from the basket.
                    int count = 1;
                    foreach (MenuItem menuItem in OrderBasket.Instance.GetAll())
                    {
                        MenuSummaryUI summaryButton = new MenuSummaryUI(flwCheckout, menuItem, count);
                        summaryButton.OnDeleteItem = LoadCheckout;
                        count++;
                    }

                    btnFinish.Enabled = true;
                }

                // Switch tab and update header text.
                theTabControl.SelectedTab = tabPageCheckout;
                lblHeader.Text = "Summary";
            }
            catch (Exception ex)
            {
                ErrorLogger.Instance.WriteError(ex, "Something went wrong while loading the checkout.");
            }
        }

        /// <summary>
        /// The "Place Order" button.
        /// </summary>
        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                if (bill == null)
                {
                    PaymentService payment = new PaymentService();
                    bill = payment.CreateBill(tableID);
                }

                Order order = orderLogic.CreateNewOrderForBill(bill, txtComment.Text);

                // Add items to the new order.
                foreach (MenuItem basketItem in OrderBasket.Instance.GetAll())
                {
                    orderLogic.AddItemToOrder(order, basketItem, basketItem.Quantity);
                    basketItem.Stock -= basketItem.Quantity;
                    orderLogic.SetItemQuantity(basketItem);
                }

                orderLogic.RegisterOrderToBartender(employee, order);

                // Clear basket, go go to "Success" tab.
                OrderBasket.Instance.Clear();
                theTabControl.SelectedTab = tabOrderSucceeded;
                lblHeader.Text = "";
                Task.Run(() => LoadOrderCompleted());
            }
            catch (Exception ex)
            {
                ErrorLogger.Instance.WriteError(ex, "Something went wrong while placing the order.");
            }
        }

        /// <summary>
        /// Waits 1 second to show the "Success" tab and closes the form.
        /// </summary>
        private void LoadOrderCompleted()
        {
            Thread.Sleep(1000);
            Action safeLoad = delegate { this.Close(); };
            Invoke(safeLoad);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            theTabControl.SelectedTab = tabPageMenu;
            lblHeader.Text = "Menu";

            try
            {
                LoadMenu(currentMenuType);
            }
            catch (Exception ex)
            {
                ErrorLogger.Instance.WriteError(ex, "Something went wrong while opening the menu.");
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
                    return;
                }
            }
        }

        /// <summary>
        /// Called by basket, in order to update the btnPlaceOrder text.
        /// </summary>
        public void UpdateUI()
        {
            btnPlaceOrder.Text = $"View Order ({OrderBasket.Instance.Count})";
            btnFinish.Enabled = OrderBasket.Instance.Count > 0;
        }

        /// <summary>
        /// If something goes wrong, it replaced the first tab's text with an error.
        /// </summary>
        /// <param name="failReason">Fail reason that will be displayed</param>
        private void ShowFail(string failReason)
        {
            lblConnecting.Text = failReason;
            theTabControl.SelectedTab = tabConnecting;
        }

        private void picBackButton_Click(object sender, EventArgs e)
        {
            if (theTabControl.SelectedTab == tabPageMenu || theTabControl.SelectedTab == tabConnecting)
            {
                this.Close();
            }
            else
            {
                theTabControl.SelectedTab = tabPageMenu;
                lblHeader.Text = "Menu";

                try
                {
                    LoadMenu(currentMenuType);
                }
                catch (Exception ex)
                {
                    ErrorLogger.Instance.WriteError(ex, "Something went wrong while loading menu type.");
                }
            }
        }
    }
}
