using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurantLogic;
using RestaurantModel;
using System.IO;
using System.Security.Cryptography;


namespace RestaurantChapeau
{
    public partial class LoginForm : Form
    {
        private EmployeeService employeeService;
        public LoginForm()
        {
            InitializeComponent();
        }
        public void HidePanels()
        {
            pnl_ForgotPassword.Hide();
            pnl_Register.Hide();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            HidePanels();
            btn_LoginRegister.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //if the username and password fields are not empty enable and color the button
            if (txt_LoginUserName.Text != "" && txt_LoginPassword.Text != "")
            {
                btn_LoginLogin.Enabled = true;
                btn_LoginLogin.BackColor = Color.FromArgb(67, 179, 215);
            }
            //else disable it
            else
            {
                btn_LoginLogin.Enabled = false;
                btn_LoginLogin.BackColor = Color.Transparent;
            }
        }                     
        private void txt_LoginPassword_TextChanged(object sender, EventArgs e)
        {
            //if the username and password fields are not empty enable and color the button
            if (txt_LoginUserName.Text != "" && txt_LoginPassword.Text != "")
            {
                btn_LoginLogin.Enabled = true;
                btn_LoginLogin.BackColor = Color.FromArgb(67, 179, 215);
            }
            //else diable it
            else
            {
                btn_LoginLogin.Enabled = false;
                btn_LoginLogin.BackColor = Color.Transparent;
            }
        }        

        private void btn_RegisterLogin_Click(object sender, EventArgs e)
        {
            HidePanels();
        }

        private void btn_ForgotLogin_Click(object sender, EventArgs e)
        {
            HidePanels();
        }

        private void btn_forgotPassword_Click(object sender, EventArgs e)
        {
            HidePanels();
            pnl_ForgotPassword.Show();
        }       
        private void btn_LoginRegister_Click_1(object sender, EventArgs e)
        {
            HidePanels();
            pnl_Register.Show();
        }       
        private void btn_LoginLogin_Click(object sender, EventArgs e)
        {
            Login();

        }

        private void Login()
        {
            try
            {
                //create connection to employee layer
                employeeService = new EmployeeService();

                //store the entered username and password
                string id = txt_LoginUserName.Text;
                string enteredPassword = txt_LoginPassword.Text;

                //gets the employee if the login credentials are correct
                Employee employee = employeeService.GetEmployeeByEmployeeID(id, enteredPassword);

                //hide the panels and form, display form of tableView
                HidePanels();
                this.Hide();

                

                switch (employee.employeeType)
                {
                    case EmployeeType.Waiter:
                        TableViewForm tableView = new TableViewForm(employee);
                        tableView.Show();
                        break;
                    case EmployeeType.KitchenStaff:
                        KitchenViewForm kitchenView = new KitchenViewForm(employee);
                        kitchenView.Show();
                        break;
                    case EmployeeType.Bartender:
                        KitchenViewForm kitchenView2 = new KitchenViewForm(employee);
                        kitchenView2.Show();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login not successful: {ex.Message}");

                //clear the text boxes
                txt_LoginUserName.Text = "";
                txt_LoginPassword.Text = "";

            }
        }       
        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txt_LoginPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        private void txt_LoginEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }
    }
}