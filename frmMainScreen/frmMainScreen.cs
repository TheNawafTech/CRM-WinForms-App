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
using static ClsUser_Person.ClsUser;
using frmViewClients;
using nfrmAddNewClient;
using frmRemoveClient;
using frmSearchClient;
using frmUpdateClient_FindUser_First_;

namespace nfrmMainScreen
{
    public partial class frmMainScreen : Form
    {

        ClsUser User = new ClsUser();

        public frmMainScreen(ref ClsUser user)
        {
            InitializeComponent();
            User = user;
        }

        void CheckPermissions()
        {
            if (User.Permissions == enPermissions.All)
            {
                btnViewClients.Enabled = true;
                btnSearchClient.Enabled = true;
                btnRemoveClient.Enabled = true;
                btnUpdateClient.Enabled = true;
                btnAddNewClient.Enabled = true;
                btnManageUsers.Enabled = true;
                return;
            }
            else
            {

                if ((User.Permissions & enPermissions.ListClients) == enPermissions.ListClients)
                {
                    btnViewClients.Enabled = true;
                }

                if ((User.Permissions & enPermissions.FindClient) == enPermissions.FindClient)
                {
                    btnSearchClient.Enabled = true;
                }

                if ((User.Permissions & enPermissions.DeleteClient) == enPermissions.DeleteClient)
                {
                    btnRemoveClient.Enabled = true;
                }

                if ((User.Permissions & enPermissions.UpdateClients) == enPermissions.UpdateClients)
                {
                    btnUpdateClient.Enabled = true;
                }

                if ((User.Permissions & enPermissions.AddNewClient) == enPermissions.AddNewClient) 
                {
                    btnAddNewClient.Enabled = true;
                }

                if ((User.Permissions & enPermissions.ManageUsers) == enPermissions.ManageUsers)
                {
                    btnManageUsers.Enabled = true;
                }

            }
        }
        private void frmMainScreen_Load(object sender, EventArgs e)
        {
            lbTitle.Font = new Font("Segoe UI", 28, FontStyle.Bold);
            lbTitle.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف

            CheckPermissions();
        }
        private void btnViewClients_Click(object sender, EventArgs e)
        {
            frmViewClientss frm = new frmViewClientss();
           
            frm.Show();
        }

        private void btnAddNewClient_Click(object sender, EventArgs e)
        {
            nfrmAddNewClient.frmAddNewClient  frmAddNewClient = new nfrmAddNewClient.frmAddNewClient();
            frmAddNewClient.Show();
        }

        private void btnRemoveClient_Click(object sender, EventArgs e)
        {
            frmRemoveClient.frmRemoveClient frm = new frmRemoveClient.frmRemoveClient();
            frm.ShowDialog();
        }

        private void btnUpdateClient_Click(object sender, EventArgs e)
        {
            frmUpdateClient_FindUser_First_.frmUpdateClient_FindClientFirst frm = new frmUpdateClient_FindClientFirst();
            frm.ShowDialog();
        }

        private void btnSearchClient_Click(object sender, EventArgs e)
        {
            frmSearchClient.frmSearchClient frm = new frmSearchClient.frmSearchClient();
            frm.ShowDialog();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            frmManageUsers.frmManageUsers frm = new frmManageUsers.frmManageUsers();
            frm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
