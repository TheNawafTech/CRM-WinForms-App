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

namespace frmDeleteUser
{
    public partial class frmDeleteUser : Form
    {
        ClsUser User = new ClsUser();
        int _UserID; // set by Validateinput
        public frmDeleteUser()
        {
            InitializeComponent();

            textBox1.Text = "Enter User ID..";
            textBox1.ForeColor = Color.Gray;
        }

        private bool Validateinput()
        {
            textBox1.Text = textBox1.Text.Trim();

            // Covers the placeholder, empty input, letters and non-positive numbers.
            if (!int.TryParse(textBox1.Text, out _UserID) || _UserID <= 0)
            {
                MessageBox.Show("Please enter a valid User ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return false;
            }

            switch (ClsBusinessLayer.ClsBusinessLayer.GetUser(_UserID, ref User))
            {
                case ClsBusinessLayer.enOperationStatus.Success:
                    return true;

                case ClsBusinessLayer.enOperationStatus.NotFound:
                    MessageBox.Show("Failed to remove User. Please check the User ID and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                default:
                    MessageBox.Show(ClsBusinessLayer.ClsBusinessLayer.SystemErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validateinput())
            {
                DialogResult Result = MessageBox.Show($"Are you sure you want to delete this User?\n\n" +
                   $"ID: {textBox1.Text}\n UserName: {User.UserName}\n FullName: {User.FullName}\n Email: {User.Email}\n Permissions: {User.Permissions}", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Result == DialogResult.OK)
                {
                    if (ClsBusinessLayer.ClsBusinessLayer.RemoveUser(_UserID))
                    {
                        MessageBox.Show("User removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Unable to remove the user. The record was not deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void frmDeleteUser_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = ClsBusinessLayer.ClsBusinessLayer.txtEnter(textBox1.Text, "Enter User ID..");
            textBox1.ForeColor = Color.Black;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Text = ClsBusinessLayer.ClsBusinessLayer.txtLeave(textBox1.Text, "Enter User ID..");
        }
    }
}
