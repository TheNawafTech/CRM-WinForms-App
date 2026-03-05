using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClsUser_Person;
using ClsBusinessLayer;
using frmPermissions0;

namespace frmUpdateUser0
{
    public partial class frmUpdateUser0 : Form
    {
        ClsUser User = new ClsUser();

        string Permissions;

        public frmUpdateUser0(ClsUser user)
        {
            InitializeComponent();
            User = user;
        }

        private void frmUpdateUser0_Load(object sender, EventArgs e)
        {

            txtUserName.Text = User.UserName;
            txtFullName.Text = User.FullName;
            txtEmail.Text = User.Email;
            txtPassword.Text = User.Password;
            Permissions = User.Permissions.ToString();

            this.ActiveControl = label1;

        }

        private void btnPermissions_Click(object sender, EventArgs e)
        {
            // propebly we will make a spitial form here for load User permissions

            frmPermissions frmPermissions = new frmPermissions();

            frmPermissions.SelectedPermissions = User.Permissions;

            frmPermissions.ShowDialog();
            Permissions = frmPermissions.SelectedPermissions.ToString();
        }

        private bool _ValidateUpdateUser()
        {
            if (!ClsBusinessLayer.ClsBusinessLayer.AreFildsEmpty(txtUserName.Text, txtFullName.Text, txtEmail.Text, txtPassword.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return false;
            }

            if (!ClsBusinessLayer.ClsBusinessLayer.IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (ClsBusinessLayer.ClsBusinessLayer.IsUerNameExsist(txtUserName.Text, User)) 
            {
                MessageBox.Show("This User Name already exists, please choose another one.", "User Name Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void _SaveUpdatedIntoToTheUser()
        {
            User.UserName = txtUserName.Text.Trim();
            User.FullName = txtFullName.Text.Trim();
            User.Email = txtEmail.Text.Trim();
            User.Password = txtPassword.Text.Trim();

            User.Permissions = (ClsUser_Person.ClsUser.enPermissions)Enum.Parse(
                typeof(ClsUser_Person.ClsUser.enPermissions), Permissions);
            
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DialogResult Result;

            if (_ValidateUpdateUser())
            {
                _SaveUpdatedIntoToTheUser();

                Result = MessageBox.Show("Are you sure you want to update User", "Confirm Updating",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Result == DialogResult.Yes)
                    if (ClsBusinessLayer.ClsBusinessLayer.UpdateUser(User, Permissions))
                    {
                        MessageBox.Show("User updated successfully");
                        this.Close();
                    }
                    else
                        MessageBox.Show("User updated Faild");
            }
        }
    }
}
