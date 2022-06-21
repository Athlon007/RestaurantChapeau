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
            btn_LoginRegister.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //if the username and password fields are not empty enable and color the button
            if (txt_LoginEmail.Text != "" && txt_LoginPassword.Text != "")
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

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void showPanel(string panelName)
        {
            if (panelName == "tableView")
            {
                HidePanels();

                pnl_ForgotPassword.Show();

                txt_LoginEmail.Text = "";
                txt_LoginPassword.Text = "";
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void txt_LoginPassword_TextChanged(object sender, EventArgs e)
        {
            //if the username and password fields are not empty enable and color the button
            if (txt_LoginEmail.Text != "" && txt_LoginPassword.Text != "")
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

        private void btn_Register_Click(object sender, EventArgs e)
        {
            pnl_Register.Show();
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

        private void pnl_Register_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btn_LoginRegister_Click_1(object sender, EventArgs e)
        {
            HidePanels();
            pnl_Register.Show();
        }

        private void btn_RegisterRegister_Click(object sender, EventArgs e)
        {
            try
            {
                //create connection to user layer
                employeeService = new EmployeeService();

                //password hasher
                PasswordWithSaltHasher pwHasher = new PasswordWithSaltHasher();

                //store the employee name and password
                string email = txt_RegisterEmail.Text;
                string firstName = txt_RegisterFirstName.Text;
                string lastName = txt_RegisterLastName.Text;
                string password = txt_RegisterPassword.Text;

                //if both the password and employee name are valid add the user
                if (PasswordRequirements(password))
                {
                    //this hashes the password
                    HashWithSaltResult hashPassword = pwHasher.HashWithSalt(password, 64, SHA256.Create());

                    //add the username, hashed password, salt and the user role to the database
                    employeeService.AddToRegister(firstName, lastName, email, hashPassword.Digest, hashPassword.Salt);
                    MessageBox.Show("Succesfully Registered! You can now login.");

                    //hide the panels and show the dashboard again
                    HidePanels();
                    txt_RegisterFirstName.Clear();
                    txt_RegisterLastName.Clear();
                    txt_RegisterEmail.Clear();
                }
                else if (!PasswordRequirements(password)) //if the password does not meet the requirements inform the user
                {
                    MessageBox.Show("The password does not meet the requirements");
                }
                else //if the username is taken inform the user
                {
                    MessageBox.Show("The employeename is already in use");
                    txt_RegisterFirstName.Clear();
                    txt_RegisterLastName.Clear();
                }
                txt_RegisterPassword.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to register: {ex.Message}");
            }

        }
        private bool PasswordRequirements(string password)
        {
            //the number of conditions to be met 
            int goodConditions = 1;

            //the current conditions
            int conditions = 0;

            //if the length of the password is greater than 8, add 1 to the current conditions
            if (password.Length == 4)
                conditions++;

            return conditions == goodConditions;
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
                string id = txt_LoginEmail.Text;
                string enteredPassword = txt_LoginPassword.Text;

                //gets the employee if the login credentials are correct
                Employee employee = employeeService.GetEmployeeByEmployeeID(id, enteredPassword);

                //hide the panels and form, display form of tableView
                HidePanels();
                this.Hide();

                

                switch (employee.employeeType)
                {
                    case EmployeeType.Waiter:
                        MessageBox.Show($"Welcome {employee.firstName}!");
                        TableViewForm tableView = new TableViewForm(employee);
                        tableView.Show();
                        break;
                    case EmployeeType.KitchenStaff:
                        MessageBox.Show($"Welcome {employee.firstName}!");
                        KitchenViewForm kitchenView = new KitchenViewForm(employee);
                        kitchenView.Show();
                        break;
                    case EmployeeType.Bartender:
                        MessageBox.Show($"Welcome {employee.firstName}!");
                        KitchenViewForm kitchenView2 = new KitchenViewForm(employee);
                        kitchenView2.Show();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login not successful: {ex.Message}");

                //clear the text boxes
                txt_LoginEmail.Text = "";
                txt_LoginPassword.Text = "";

            }
        }

        private void pnl_ForgotPassword_Paint(object sender, PaintEventArgs e)
        {

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