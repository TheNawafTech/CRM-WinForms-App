using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClsBusinessLayer;
using ClsUser_Person;

namespace frmFindUser
{
    public partial class frmSearchUser : Form
    {
        public frmSearchUser()
        {
            InitializeComponent();
        }
        private bool _ValidateInput()
        {
            if (txtUserID.Text == "Enter User ID..")
            {
                MessageBox.Show("Please fill the feilds", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserID.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUserID.Text) || !int.TryParse(txtUserID.Text, out _))
            {
                MessageBox.Show("User ID must be a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserID.Focus();
                return false;
            }

            // Check if the client exists
            if (!ClsBusinessLayer.ClsBusinessLayer.IsUserExsist(int.Parse(txtUserID.Text)))
            {
                MessageBox.Show("User does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserID.Focus();
                return false;
            }
            return true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!_ValidateInput())
                return;

            ClsUser_Person.ClsUser User = new ClsUser_Person.ClsUser();

            if (ClsBusinessLayer.ClsBusinessLayer.GetUser(int.Parse(txtUserID.Text), ref User))
            {
                MessageBox.Show($"User Found:\n\nID: {User.UserID}\nUserName: {User.UserName}\nFull Name: {User.FullName}\nEmail: {User.Email}\nPermissions: {User.Permissions}", "User Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSearchUser_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف
            label2.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف

            txtUserID.Text = "Enter User ID..";

            this.ActiveControl = label1;
        }

        private void txtUserID_Enter(object sender, EventArgs e)
        {

            txtUserID.Text = ClsBusinessLayer.ClsBusinessLayer.txtEnter(txtUserID.Text, "Enter User ID..");
            txtUserID.ForeColor = Color.Black;
        }

        private void txtUserID_Leave(object sender, EventArgs e)
        {
            txtUserID.Text = ClsBusinessLayer.ClsBusinessLayer.txtLeave(txtUserID.Text, "Enter User ID..");
            txtUserID.ForeColor = Color.Black;
        }


    }
}
