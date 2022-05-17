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

namespace RestaurantChapeau
{
    
    public partial class Form1 : Form
    {
        private Employee currentEmployee= null;
        public Form1()
        {
            InitializeComponent();
        }
        public void HidePanels()
        {
            pnl_tableView.Hide();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pnl_tableView.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //if the username and password fields are not empty enable and color the button
            if (txt_LoginEmail.Text != "" && txt_LoginPassword.Text != "")
            {
                btn_login.Enabled = true;
                btn_login.BackColor = Color.FromArgb(39, 126, 172);
            }
            //else disable it
            else
            {
                btn_login.Enabled = false;
                btn_login.BackColor = Color.Transparent;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //create connection to user layer
                EmployeeService employeeService = new EmployeeService();

                //store the entered username and password
                string employeeName = txt_LoginEmail.Text;
                string enteredPassword = txt_LoginPassword.Text;

                //get the user by the entered username
                Employee employee = employeeService.GetEmployeeByEmployeeName(employeeName);

                //password hasher
                PasswordWithSaltHasher passwordHasher = new PasswordWithSaltHasher();

                //if the entered password matches the one in the db
                if (passwordHasher.PasswordValidation(enteredPassword, employee.passwordHash, employee.passwordSalt))
                {
                    MessageBox.Show("Login successful!");

                    //the current user becomes the entered user
                    currentEmployee = employee;

                    //hide the panels and show the dashboard again
                    HidePanels();
                    showPanel("Dashboard");
                }
                else
                    MessageBox.Show("Login failed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login failed: {ex.Message}");

                //clear the text boxes
                txt_LoginEmail.Text = "";
                txt_LoginPassword.Text = "";                

                LogError(ex);
            }
        }
        private void showPanel(string panelName)
        {
            if(panelName == "tableView")
            {
                HidePanels();

                pnl_tableView.Show();

                txt_LoginEmail.Text = "";
                txt_LoginPassword.Text = "";
            }
        }
        private void LogError(Exception ex)
        {
            string message = string.Format($"Time: {DateTime.Now:dd/MM/yyyy hh:mm:ss tt}");
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format($"Message: {ex.Message}");
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = "../../../ErrorLog.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
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
                btn_login.Enabled = true;
                btn_login.BackColor = Color.FromArgb(39, 126, 172);
            }
            //else diable it
            else
            {
                btn_login.Enabled = false;
                btn_login.BackColor = Color.Transparent;
            }
        }
    }
}
