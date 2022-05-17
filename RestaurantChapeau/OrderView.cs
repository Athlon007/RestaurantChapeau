using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RestaurantLogic;
using RestaurantModel;

namespace RestaurantChapeau
{
    public partial class OrderView : Form
    {
        OrderLogic orderLogic;

        public OrderView()
        {
            InitializeComponent();

            //LoadMenuItems(null, null);
            orderLogic = new OrderLogic();
            LoadMenuTypes();
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

            LoadMenuCategories((MenuType)(sender as Button).Tag);
        }

        private void LoadMenuCategories(MenuType menuType)
        {
            ClearMenuCategories();
            ClearMenuItems();
            List<MenuCategory> menuCategories = orderLogic.GetMenuCategories(menuType);

            foreach (MenuCategory menuCategory in menuCategories)
            {
                Button menuCategoryButon = new Button();
                menuCategoryButon.Tag = menuCategory;
                menuCategoryButon.Text = menuCategory.Name;
                menuCategoryButon.Height = flwMenuTypes.Height;
                menuCategoryButon.Width = flwMenuTypes.Width / menuCategories.Count - 7;
                menuCategoryButon.Click += OnMenuCategoryClick;
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

            MenuCategory category = (MenuCategory)(sender as Button).Tag;
            MenuType menuType = category.MenuType;
            LoadMenuItems(menuType, category);
        }

        private void LoadMenuItems(MenuType menuType, MenuCategory menuCategory)
        {
            ClearMenuItems();

            List<MenuItem> menuItems = orderLogic.GetMenuItems(menuType, menuCategory);

            foreach (MenuItem menuItem in menuItems)
            {
                new MenuItemUIControl(flwMenuItems, menuItem, lblSub.Left);
            }
        }

        private void ClearMenuItems()
        {
            flwMenuItems.Controls.Clear();
        }
    }
}
