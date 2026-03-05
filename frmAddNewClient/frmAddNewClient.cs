using ClsClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace nfrmAddNewClient
{
    public partial class frmAddNewClient : Form
    {
        public frmAddNewClient()
        {
            InitializeComponent();
        }

        public string TheTextOfPlaceholde;

        void DesignTheForm()
        {
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

            txtClientName.ForeColor = Color.Gray;
            txtPhone.ForeColor = Color.Gray;
            txtEmail.ForeColor = Color.Gray;
            txtTotalOrders.ForeColor = Color.Gray;
            txtTotalPurchaseValue.ForeColor = Color.Gray;


        }
        
        private void frnAddNewClient_Load(object sender, EventArgs e)
        {
            DesignTheForm();

            txtClientName.Text = "Enter Client Name..";

            txtPhone.Text = "Start with +966 (e.g., +9665 ..)";

            txtEmail.Text = "Enter Email Adress..";

            txtTotalOrders.Text = "Enter Total Orders..";

            txtTotalPurchaseValue.Text = "Enter Total Purchase Value..";

            this.ActiveControl = btnAddNewClient;

            this.Focus();

        }

        private bool _ValidateAddNewClient(ref ClsClient.ClsClient newClient)
        {
            
            if (!ClsBusinessLayer.ClsBusinessLayer.AreFildsEmpty(txtClientName.Text, txtPhone.Text, txtEmail.Text, txtTotalOrders.Text, txtTotalPurchaseValue.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return false;
            }

            if (!ClsBusinessLayer.ClsBusinessLayer.IsValidPhone(txtPhone.Text))
            {
                MessageBox.Show("The phone number must start with a valid country code (e.g., +1, +44, +966).");
                return false;
            }

            decimal purchaseValue;
            if (!decimal.TryParse(txtTotalPurchaseValue.Text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out purchaseValue))
            {
                MessageBox.Show("Please enter a valid purchase value.");
                return false;
            }
            newClient.TotalPurchaseValue = purchaseValue;

            int totalOrders;
            if (!int.TryParse(txtTotalOrders.Text.Trim(), out totalOrders))
            {
                MessageBox.Show("Please enter a valid number of total orders.");
                return false;
            }

            newClient.TotalOrders = totalOrders;


            if (!ClsBusinessLayer.ClsBusinessLayer.IsValidInt(txtTotalOrders.Text, 0))
            {
                MessageBox.Show("Please enter a valid number for Total Orders");
                return false;
            }
            if (!ClsBusinessLayer.ClsBusinessLayer.IsValidDecimal(txtTotalPurchaseValue.Text, 0))
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
       
        private void btnSubmitNewClient_Click(object sender, EventArgs e)
        {

            ClsClient.ClsClient newClient = new ClsClient.ClsClient(txtClientName.Text.Trim(), txtPhone.Text.Trim(), txtEmail.Text.Trim(), 0, 0);
            // Validae the inputs :
            if (!_ValidateAddNewClient(ref newClient)) 
            {
                return;
            }

            DialogResult Result = MessageBox.Show("Are you sure you want to add this client", "Confirm Adding",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (Result == DialogResult.Yes)
            {
                if (ClsBusinessLayer.ClsBusinessLayer.AddNewClient(newClient))
                {
                    MessageBox.Show($"New client added successfully with ID :{newClient.ClientID}");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to add new client.\nThe phone number or email might already exist. Please try again.");
                }
            }
        }

        private void txtClientName_Enter(object sender, EventArgs e)
        {
            TheTextOfPlaceholde = "Enter Client Name..";

            txtClientName.Text = ClsBusinessLayer.ClsBusinessLayer.txtEnter(txtClientName.Text, TheTextOfPlaceholde);
           
            txtClientName.ForeColor = Color.Black;
        }

        private void txtPhone_Enter(object sender, EventArgs e)
        {
            TheTextOfPlaceholde = "Start with +966 (e.g., +9665 ..)";

            txtPhone.Text = ClsBusinessLayer.ClsBusinessLayer.txtEnter(txtPhone.Text, TheTextOfPlaceholde);
            
            txtPhone.ForeColor = Color.Black;
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            TheTextOfPlaceholde = "Enter Email Adress..";

            txtEmail.Text = ClsBusinessLayer.ClsBusinessLayer.txtEnter(txtEmail.Text, TheTextOfPlaceholde);
            
            txtEmail.ForeColor = Color.Black;
        }

        private void txtTotalOrders_Enter(object sender, EventArgs e)
        {
            TheTextOfPlaceholde = "Enter Total Orders..";

            txtTotalOrders.Text = ClsBusinessLayer.ClsBusinessLayer.txtEnter(txtTotalOrders.Text, TheTextOfPlaceholde);
            
            txtTotalOrders.ForeColor = Color.Black;
        }

        private void txtTotalPurchaseValue_Enter(object sender, EventArgs e)
        {
            TheTextOfPlaceholde = "Enter Total Purchase Value..";
            txtTotalPurchaseValue.Text = ClsBusinessLayer.ClsBusinessLayer.txtEnter(txtTotalPurchaseValue.Text, TheTextOfPlaceholde);
           
            txtTotalPurchaseValue.ForeColor = Color.Black;
        }

        private void txtClientName_Leave(object sender, EventArgs e)
        {
            TheTextOfPlaceholde = "Enter Client Name..";
            txtClientName.Text = ClsBusinessLayer.ClsBusinessLayer.txtLeave(txtClientName.Text, TheTextOfPlaceholde);

            txtClientName.ForeColor = (string.IsNullOrEmpty(txtClientName.Text) || txtClientName.Text == TheTextOfPlaceholde) ? Color.Gray : Color.Black;
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            TheTextOfPlaceholde = "Start with +966 (e.g., +9665 ..)";

            txtPhone.Text = ClsBusinessLayer.ClsBusinessLayer.txtLeave(txtPhone.Text, TheTextOfPlaceholde);

            txtPhone.ForeColor = (string.IsNullOrEmpty(txtPhone.Text) || txtPhone.Text == TheTextOfPlaceholde) ? Color.Gray : Color.Black;
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            TheTextOfPlaceholde = "Enter Email Adress..";
            txtEmail.Text = ClsBusinessLayer.ClsBusinessLayer.txtLeave(txtEmail.Text, TheTextOfPlaceholde);

            txtEmail.ForeColor = (string.IsNullOrEmpty(txtEmail.Text) || txtEmail.Text == TheTextOfPlaceholde) ? Color.Gray : Color.Black;
        }

        private void txtTotalOrders_Leave(object sender, EventArgs e)
        {
            TheTextOfPlaceholde = "Enter Total Orders..";

            txtTotalOrders.Text = ClsBusinessLayer.ClsBusinessLayer.txtLeave(txtTotalOrders.Text, TheTextOfPlaceholde);

            txtTotalOrders.ForeColor = (string.IsNullOrEmpty(txtTotalOrders.Text) || txtTotalOrders.Text == TheTextOfPlaceholde) ? Color.Gray : Color.Black;
        }

        private void txtTotalPurchaseValue_Leave(object sender, EventArgs e)
        {
            TheTextOfPlaceholde = "Enter Total Purchase Value..";

            txtTotalPurchaseValue.Text = ClsBusinessLayer.ClsBusinessLayer.txtLeave(txtTotalPurchaseValue.Text, TheTextOfPlaceholde);

            txtTotalPurchaseValue.ForeColor = (string.IsNullOrEmpty(txtTotalPurchaseValue.Text) || txtTotalPurchaseValue.Text == TheTextOfPlaceholde) ? Color.Gray : Color.Black;
        }
    }
}
