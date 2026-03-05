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
        public frmDeleteUser()
        {
            InitializeComponent();

            textBox1.Text = "Enter User ID..";
            textBox1.ForeColor = Color.Gray;
        }

        private bool Validateinput()
        {
            textBox1.Text = textBox1.Text.Trim();

            if (textBox1.Text == "Enter User ID.." || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter a valid User ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (ClsBusinessLayer.ClsBusinessLayer.IsUserExsist(int.Parse(textBox1.Text), ref User))
            {
                return true;
            }

            return false;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validateinput())
            {
                DialogResult Result = MessageBox.Show($"Are you sure you want to delete this User?\n\n" +
                   $"ID: {textBox1.Text}\n UserName: {User.UserName}\n FullName: {User.FullName}\n Email: {User.Email}\n Permissions: {User.Permissions}", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Result == DialogResult.OK)
                {
                    ClsBusinessLayer.ClsBusinessLayer.RemoveUser(int.Parse(textBox1.Text));
                    
                    MessageBox.Show("User removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
                MessageBox.Show("Failed to remove User. Please check the User ID and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
