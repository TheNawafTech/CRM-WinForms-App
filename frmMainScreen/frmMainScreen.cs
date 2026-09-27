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

        // All (-1) has every bit set, so it passes every check.
        bool HasPermission(enPermissions Permission)
        {
            return (User.Permissions & Permission) == Permission;
        }

        // Re-checked when an action runs, not only when the buttons are enabled on load.
        bool _EnsurePermission(enPermissions Permission)
        {
            if (HasPermission(Permission))
            {
                return true;
            }

            MessageBox.Show("You do not have permission to access this screen.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        void CheckPermissions()
        {
            btnViewClients.Enabled = HasPermission(enPermissions.ListClients);
            btnSearchClient.Enabled = HasPermission(enPermissions.FindClient);
            btnRemoveClient.Enabled = HasPermission(enPermissions.DeleteClient);
            btnUpdateClient.Enabled = HasPermission(enPermissions.UpdateClients);
            btnAddNewClient.Enabled = HasPermission(enPermissions.AddNewClient);
            btnManageUsers.Enabled = HasPermission(enPermissions.ManageUsers);
        }
        private void frmMainScreen_Load(object sender, EventArgs e)
        {
            lbTitle.Font = new Font("Segoe UI", 28, FontStyle.Bold);
            lbTitle.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف

            CheckPermissions();
        }
        private void btnViewClients_Click(object sender, EventArgs e)
        {
            if (!_EnsurePermission(enPermissions.ListClients))
                return;

            frmViewClientss frm = new frmViewClientss();
           
            frm.Show();
        }

        private void btnAddNewClient_Click(object sender, EventArgs e)
        {
            if (!_EnsurePermission(enPermissions.AddNewClient))
                return;

            nfrmAddNewClient.frmAddNewClient  frmAddNewClient = new nfrmAddNewClient.frmAddNewClient();
            frmAddNewClient.Show();
        }

        private void btnRemoveClient_Click(object sender, EventArgs e)
        {
            if (!_EnsurePermission(enPermissions.DeleteClient))
                return;

            frmRemoveClient.frmRemoveClient frm = new frmRemoveClient.frmRemoveClient();
            frm.ShowDialog();
        }

        private void btnUpdateClient_Click(object sender, EventArgs e)
        {
            if (!_EnsurePermission(enPermissions.UpdateClients))
                return;

            frmUpdateClient_FindUser_First_.frmUpdateClient_FindClientFirst frm = new frmUpdateClient_FindClientFirst();
            frm.ShowDialog();
        }

        private void btnSearchClient_Click(object sender, EventArgs e)
        {
            if (!_EnsurePermission(enPermissions.FindClient))
                return;

            frmSearchClient.frmSearchClient frm = new frmSearchClient.frmSearchClient();
            frm.ShowDialog();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            if (!_EnsurePermission(enPermissions.ManageUsers))
                return;

            frmManageUsers.frmManageUsers frm = new frmManageUsers.frmManageUsers();
            frm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
