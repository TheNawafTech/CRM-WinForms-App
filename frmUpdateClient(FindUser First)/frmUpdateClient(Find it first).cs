using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClsClient;

namespace frmUpdateClient_FindUser_First_
{
    public partial class frmUpdateClient_FindClientFirst : Form
    {
        public frmUpdateClient_FindClientFirst()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtClientID.Text = "Enter Client ID..";
            
            txtClientID.ForeColor = Color.Black;
            label1.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف
            label2.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف


            this.ActiveControl = btnClieck;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

            txtClientID.Text = ClsBusinessLayer.ClsBusinessLayer.txtEnter(txtClientID.Text, "Enter Client ID..");
            txtClientID.ForeColor = Color.Black;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            txtClientID.Text = ClsBusinessLayer.ClsBusinessLayer.txtLeave(txtClientID.Text, "Enter Client ID..");

        }

        private bool _Validate()
        {
            if (!int.TryParse(txtClientID.Text, out _))
            {
                MessageBox.Show("Invalid Client ID", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void _btnSearch_Click(object sender, EventArgs e)
        {
            ClsClient.ClsClient client = new ClsClient.ClsClient();

            if (_Validate())
            {
                if (ClsBusinessLayer.ClsBusinessLayer.GetClient(int.Parse(txtClientID.Text.Trim()), ref client)) 
                {
                    frmUpdateClient.frmUpdateClient frm = new frmUpdateClient.frmUpdateClient(client);
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Client not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
