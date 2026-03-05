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
using frmPermissions0;

namespace frmAddNewUser
{
    public partial class frmAddNewUser : Form
    {

        string Permissions;
        string TheTextOfPlaceholde;
        public frmAddNewUser()
        {
            InitializeComponent();
        }

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف

            txtUserName.Text = "Enter UserName..";
            txtUserName.ForeColor = Color.Gray;

            txtFullName.Text = "Enter Full Name..";
            txtFullName.ForeColor = Color.Gray;

            txtEmail.Text = "Enter Email..";
            txtEmail.ForeColor = Color.Gray;

            txtPassword.Text = "Enter Password..";
            txtPassword.ForeColor = Color.Gray;

            this.ActiveControl = label1;

            this.Focus();

        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            TheTextOfPlaceholde = "Enter UserName..";
            txtUserName.Text = ClsBusinessLayer.ClsBusinessLayer.txtEnter(txtUserName.Text, TheTextOfPlaceholde);
            txtUserName.ForeColor = Color.Black;

        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            TheTextOfPlaceholde = "Enter UserName..";

            txtUserName.Text = ClsBusinessLayer.ClsBusinessLayer.txtLeave(txtUserName.Text, TheTextOfPlaceholde);

            txtUserName.ForeColor = (string.IsNullOrEmpty(txtUserName.Text) || txtUserName.Text == TheTextOfPlaceholde) ? Color.Gray : Color.Black;
        }

        private void txtFullName_Enter(object sender, EventArgs e)
        {
            TheTextOfPlaceholde = "Enter Full Name..";
            txtFullName.Text = ClsBusinessLayer.ClsBusinessLayer.txtEnter(txtFullName.Text, TheTextOfPlaceholde);
            txtFullName.ForeColor = Color.Black;
        }

        private void txtFullName_Leave(object sender, EventArgs e)
        {
            TheTextOfPlaceholde = "Enter Full Name..";
            txtFullName.Text = ClsBusinessLayer.ClsBusinessLayer.txtLeave(txtFullName.Text, TheTextOfPlaceholde);

            txtFullName.ForeColor = (string.IsNullOrEmpty(txtFullName.Text) || txtFullName.Text == TheTextOfPlaceholde) ? Color.Gray : Color.Black;
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            TheTextOfPlaceholde = "Enter Email..";
            txtEmail.Text = ClsBusinessLayer.ClsBusinessLayer.txtEnter(txtEmail.Text, TheTextOfPlaceholde);
            txtEmail.ForeColor = Color.Black;

        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            TheTextOfPlaceholde = "Enter Email..";
            txtEmail.Text = ClsBusinessLayer.ClsBusinessLayer.txtLeave(txtEmail.Text,TheTextOfPlaceholde);

            txtEmail.ForeColor = (string.IsNullOrEmpty(txtEmail.Text) || txtEmail.Text == TheTextOfPlaceholde) ? Color.Gray : Color.Black;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            TheTextOfPlaceholde = "Enter Password..";

            txtPassword.Text = ClsBusinessLayer.ClsBusinessLayer.txtEnter(txtPassword.Text, TheTextOfPlaceholde);
            txtPassword.ForeColor = Color.Black;

        }

        private void txtPassword_Leave(object sender, EventArgs e)
        
        {
            TheTextOfPlaceholde = "Enter Password..";

            txtPassword.Text = ClsBusinessLayer.ClsBusinessLayer.txtLeave(txtPassword.Text, TheTextOfPlaceholde);

            txtPassword.ForeColor = (string.IsNullOrEmpty(txtPassword.Text) || txtPassword.Text == TheTextOfPlaceholde) ? Color.Gray : Color.Black;
        }

        private bool _ValidateAddNewUser()
        {
            if (ClsBusinessLayer.ClsBusinessLayer.IsUerNameExsist(txtUserName.Text))
            {
                MessageBox.Show("This User Name already exists, please choose another one.", "User Name Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!ClsBusinessLayer.ClsBusinessLayer.AreFildsEmpty
                (txtUserName.Text, txtFullName.Text, txtEmail.Text, txtPassword.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return false;
            }

            if (ClsBusinessLayer.ClsBusinessLayer.IsValidEmail(txtEmail.Text) == false)
            {
                MessageBox.Show("Please enter a valid email address.");
                return false;
            }

            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.");
                return false;
            }

            if (Permissions == null)
            {
                MessageBox.Show("Please assign permissions to the user.");
                return false;
            }

            return true;
        }
        private void btnPermissions_Click(object sender, EventArgs e)
        {
            frmPermissions0.frmPermissions frmPermissions = new frmPermissions();

            if (frmPermissions.ShowDialog() == DialogResult.Yes)
            {
                Permissions = frmPermissions.SelectedPermissions.ToString();
            }
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            ClsUser User = new ClsUser(txtUserName.Text.Trim(), txtFullName.Text.Trim(), txtEmail.Text.Trim(), txtPassword.Text.Trim());

            if (!_ValidateAddNewUser())
            {
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to add this user ?", "confrmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return; // User chose not to add the user
            }

            if (ClsBusinessLayer.ClsBusinessLayer.AddNewUser(ref User, Permissions))
            {
                MessageBox.Show($"User added successfully with User ID : {User.UserID}");
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to add user. Please try again.");
            }
        }
    }
}
