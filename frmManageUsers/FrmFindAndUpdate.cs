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

namespace frmManageUsers
{
    public partial class FrmFindAndUpdate : Form
    {
        ClsUser User = new ClsUser();
        public FrmFindAndUpdate()
        {
            InitializeComponent();
        }

        private void FrmFindAndUpdate_Load(object sender, EventArgs e)
        {
            txtUserID.Text = "Enter User ID..";

            txtUserID.ForeColor = Color.Black;
            lbUpdateUser.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف
            lbUserID.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف

            this.ActiveControl = btnSearch; // Set focus on the button
            this.Focus();
        }

        private bool _Validate()
        {
            if (!int.TryParse(txtUserID.Text, out _))
            {
                MessageBox.Show("Invalid User ID", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            if (!_Validate())
            {
                return;
            }

            if (ClsBusinessLayer.ClsBusinessLayer.GetUser(int.Parse(txtUserID.Text), ref User))
            {

                frmUpdateUser0.frmUpdateUser0 frm = new frmUpdateUser0.frmUpdateUser0(User);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("User not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtUserID_Leave_1(object sender, EventArgs e)
        {
            txtUserID.Text = ClsBusinessLayer.ClsBusinessLayer.txtLeave(txtUserID.Text, "Enter User ID..");
        }

        private void txtUserID_Enter_1(object sender, EventArgs e)
        {
            txtUserID.Text = ClsBusinessLayer.ClsBusinessLayer.txtEnter(txtUserID.Text, "Enter User ID..");
        }
    }
}
