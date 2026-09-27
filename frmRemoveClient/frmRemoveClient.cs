using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClsBusinessLayer;
using ClsClient;

namespace frmRemoveClient
{
    public partial class frmRemoveClient : Form
    {

        ClsClient.ClsClient Client = null;
        int _ClientID; // set by Validateinput

        public frmRemoveClient()
        {
            InitializeComponent();
        }
        
        void DesignTheForm()
        {
            label1.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            label1.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف
        }

        private void frmRemoveClient_Load(object sender, EventArgs e)
        {
            DesignTheForm();

            label1.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف

            label2.BackColor = Color.FromArgb(80, 0, 0, 0); //رمادي شفاف

            textBox1.Text = "Enter Client ID..";
            textBox1.ForeColor = Color.Gray;

            this.ActiveControl = btnSubmit;
            this.Focus();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

            if (textBox1.Text == "Enter Client ID..")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Gray;
            }

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Enter Client ID..";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private bool Validateinput()
        {
            textBox1.Text = textBox1.Text.Trim();

            // Covers the placeholder, empty input, letters and non-positive numbers.
            if (!int.TryParse(textBox1.Text, out _ClientID) || _ClientID <= 0)
            {
                MessageBox.Show("Please enter a valid Client ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return false;
            }

            if (!ClsBusinessLayer.ClsBusinessLayer.IsClientExsist(_ClientID, ref Client))
            {
                MessageBox.Show("Failed to remove client. Please check the Client ID and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validate the inputs and check if there is any thing wrong..

            if (Validateinput())
            {
                DialogResult Result = MessageBox.Show($"Are you sure you want to delete this client?\n" 
                    +$"ID: {textBox1.Text}\nClient Name: {Client.ClientName}\nPhone: {Client.Phone}\nEmail: {Client.Email}\nTotal Orders: {Client.TotalOrders}\nTotal Purchase Value: {Client.TotalPurchaseValue}", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Result == DialogResult.OK)
                {
                    if (ClsBusinessLayer.ClsBusinessLayer.RemoveClient(_ClientID))
                    {
                        MessageBox.Show("Client removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Unable to remove the client. The record was not deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
     
}
