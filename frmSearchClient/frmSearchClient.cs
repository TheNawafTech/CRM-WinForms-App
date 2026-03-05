using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmSearchClient
{
    public partial class frmSearchClient : Form
    {
        public frmSearchClient()
        {
            InitializeComponent();
        }

        private void frmSearchClient_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف
            label2.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف

            txtClientID.Text = "Enter Client ID..";

            this.ActiveControl = label1;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            txtClientID.Text = ClsBusinessLayer.ClsBusinessLayer.txtEnter(txtClientID.Text, "Enter Client ID..");
            txtClientID.ForeColor = Color.Black;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

            txtClientID.Text = ClsBusinessLayer.ClsBusinessLayer.txtLeave(txtClientID.Text, "Enter Client ID..");
            txtClientID.ForeColor = Color.Black;
        }

        private bool _ValidateInput()
        {
            if (txtClientID.Text == "Enter Client ID..")
            {
                MessageBox.Show("Please fill the feilds", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClientID.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtClientID.Text) || !int.TryParse(txtClientID.Text, out _)) 
            {
                MessageBox.Show("Client ID must be a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClientID.Focus();
                return false;
            }
            
            // Check if the client exists
            if (!ClsBusinessLayer.ClsBusinessLayer.IsClientExsist(int.Parse(txtClientID.Text)))
            {
                MessageBox.Show("Client does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClientID.Focus();
                return false;
            }
            return true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!_ValidateInput())
                return;

            ClsClient.ClsClient client = new ClsClient.ClsClient();
           
            if (ClsBusinessLayer.ClsBusinessLayer.GetClient(int.Parse(txtClientID.Text), ref client)) 
            {
                MessageBox.Show($"Client Found:\n\nID: {client.ClientID}\nName: {client.ClientName}\nEmail: {client.Email}\nPhone: {client.Phone}", "Client Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Client not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}