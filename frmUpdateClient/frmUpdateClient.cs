using ClsClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmUpdateClient
{
    public partial class frmUpdateClient : Form
    {

        ClsClient.ClsClient Client0 = new ClsClient.ClsClient();

        public frmUpdateClient(ClsClient.ClsClient client)
        {
            InitializeComponent();
            Client0 = client;
        }

        private void _InitializeClientInfoOnScreen()
        {
            lbClientID.Text = Client0.ClientID.ToString();
            txtClientName.Text = Client0.ClientName.ToString();
            txtPhone.Text = Client0.Phone.ToString();
            txtEmail.Text = Client0.Email.ToString();
            txtTotalOrders.Text = Client0.TotalOrders.ToString();
            txtTotalPurchaseValue.Text = Client0.TotalPurchaseValue.ToString();
        }

        void DesignTheForm()
        {
            label1.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف
            label1.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            label1.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف

            lbClientName.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lbClientName.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف

            lbPhone.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lbPhone.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف

            lbEmail.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lbEmail.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف

            lbTotalOrders.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lbTotalOrders.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف

            lbTotalPurchaseValue.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lbTotalPurchaseValue.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف

            lbClientID.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف


        }
        private void frmUpdateClient_Load(object sender, EventArgs e)
        {
            _InitializeClientInfoOnScreen();
           
            DesignTheForm();
            
            this.ActiveControl = lbClientID;
        }

        private bool _ValidateUpdateClient(int TotalOrders, decimal TotalPurchase)
        {            

            if (!ClsBusinessLayer.ClsBusinessLayer.AreFildsEmpty(txtClientName.Text, txtPhone.Text, txtEmail.Text, txtTotalOrders.Text, txtTotalPurchaseValue.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return false;
            }

            if (!ClsBusinessLayer.ClsBusinessLayer.IsValidPhoneNumber(txtPhone.Text)) 
            {
                MessageBox.Show("The phone number must start with a valid country code (e.g., +1, +44, +966).");
                return false;
            }

            if (!ClsBusinessLayer.ClsBusinessLayer.IsValidInt(txtTotalOrders.Text, TotalOrders))
            {
                MessageBox.Show("Please enter a valid number for Total Orders");
                return false;
            }
            if (!ClsBusinessLayer.ClsBusinessLayer.IsValidDecimal(txtTotalPurchaseValue.Text, TotalPurchase))
            {
                MessageBox.Show("Please enter a valid amount for Total Purchase Value");
                return false;
            }

            if (!ClsBusinessLayer.ClsBusinessLayer.IsValidPhone(txtPhone.Text))
            {
                MessageBox.Show("Invalid phone number", "Invalid Phone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!ClsBusinessLayer.ClsBusinessLayer.IsValidEmail(txtEmail.Text))
            {

                MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void _SaveUpdateInfoToClient0()
        {
            Client0.ClientName = txtClientName.Text.Trim();
            Client0.Phone = txtPhone.Text.Trim();
            Client0.Email = txtEmail.Text.Trim();
            Client0.TotalOrders = int.Parse(txtTotalOrders.Text.Trim());
            Client0.TotalPurchaseValue = decimal.Parse(txtTotalPurchaseValue.Text.Trim());
        }

        private void btnUpdateClient_Click(object sender, EventArgs e)
        {
            DialogResult Result;
           
            if (_ValidateUpdateClient(Client0.TotalOrders, Client0.TotalPurchaseValue)) 
            {
                _SaveUpdateInfoToClient0();

                Result = MessageBox.Show("Are you sure you want to update client", "Confirm Updating",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Result == DialogResult.Yes)
                    if (ClsBusinessLayer.ClsBusinessLayer.UpdateClient(Client0))
                {
                    MessageBox.Show("Client updated successfully");
                    this.Close();
                }
                else
                    MessageBox.Show("Client updated Faild");
            }
        }
    }
}