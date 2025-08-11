using ClsBusinessLayer;
using ClsUser_Person;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ClsUser_Person.ClsUser;
using nfrmMainScreen;
using Settings;

namespace CRM_Project_Version_001
{
    public partial class Form1 : Form
    {
        ClsUser_Person.ClsUser User = new ClsUser_Person.ClsUser();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;

            label1.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف
            label2.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف


            txtUsername.Text = "Enter Username";
            txtUsername.ForeColor = Color.Gray;

            txtPassword.Text = "Enter Password";
            txtPassword.ForeColor = Color.Gray;
            txtPassword.UseSystemPasswordChar = false;

            btnLogin.BackColor = Color.Transparent;
            this.ActiveControl = btnLogin;

            btnLogin.Focus();
        }
        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Enter Username")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = "Enter Username";
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Enter Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true; // Show password as dots
            }
        }
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.ForeColor = Color.Gray;
                txtPassword.UseSystemPasswordChar = true;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string txtUsername = this.txtUsername.Text.Trim();
            string txtPassword = this.txtPassword.Text.Trim();

            if (txtUsername == "Enter Password" || txtPassword == "Enter Password") 
            {
                MessageBox.Show("Please enter your username and password.");
                return;
            }

            if (ClsBusinessLayer.ClsBusinessLayer.LogInUser(ref txtUsername, ref txtPassword, ref User) != null)   
            {
                nfrmMainScreen.frmMainScreen MainScreen = new nfrmMainScreen.frmMainScreen(ref User);
                
                MainScreen.ShowDialog();

            }
            else
            {
                MessageBox.Show("Invalid Username or Password. Please try again.");
            }
        }

   
    }
}
