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

namespace frmPermissions0
{
    public partial class frmPermissions : Form
    {
        public ClsUser.enPermissions SelectedPermissions { get; set; }

        public frmPermissions()
        {
            InitializeComponent();
        }

        void DesignForm()
        {
            lbSelectPermissions.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف

            chAddNewClient.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف
            chUpdateClient.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف
            chDeleteClient.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف
            chSearchClient.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف
            chViewClients.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف
            chManageUsers.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف

            this.ActiveControl = lbSelectPermissions;
        }

        
        
        // This method "AssignThePastPermissionsIfThere" if we call the form for updating User :
        void AssignThePastPermissionsIfThere()
        {

            var permissionsMap = new Dictionary<ClsUser.enPermissions, CheckBox>()
            {
              { ClsUser.enPermissions.ListClients, chViewClients },
              { ClsUser.enPermissions.AddNewClient, chAddNewClient },
              { ClsUser.enPermissions.DeleteClient, chDeleteClient },
              { ClsUser.enPermissions.UpdateClients, chUpdateClient },
              { ClsUser.enPermissions.FindClient, chSearchClient },
              { ClsUser.enPermissions.ManageUsers, chManageUsers },
            };

            foreach (var pair in permissionsMap)
            {
                pair.Value.Checked = (SelectedPermissions & pair.Key) == pair.Key;
            }

        }


        private void frmPermissions_Load(object sender, EventArgs e)
        {
            DesignForm();
            AssignThePastPermissionsIfThere();

        }

        private void _AssignThePermissions()
        {
            SelectedPermissions = 0;

            if (chAddNewClient.Checked)
                SelectedPermissions |= ClsUser.enPermissions.AddNewClient;
            if (chUpdateClient.Checked)
                SelectedPermissions |= ClsUser.enPermissions.UpdateClients;
            if (chDeleteClient.Checked)
                SelectedPermissions |= ClsUser.enPermissions.DeleteClient;
            if (chSearchClient.Checked)
                SelectedPermissions |= ClsUser.enPermissions.FindClient;
            if (chViewClients.Checked)
                SelectedPermissions |= ClsUser.enPermissions.ListClients;
            if (chManageUsers.Checked)
                SelectedPermissions |= ClsUser.enPermissions.ManageUsers;

            this.DialogResult = DialogResult.Yes;

        }
        private bool _AreAnyPermissionSelected()
        {
            return chAddNewClient.Checked || chUpdateClient.Checked || chDeleteClient.Checked ||
                   chSearchClient.Checked || chViewClients.Checked || chManageUsers.Checked;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!_AreAnyPermissionSelected()) 
            {
                MessageBox.Show("Please select at least one permission.");
                return;
            }
            else
            {
                DialogResult Result = MessageBox.Show("Are you sure you want to assign these permissions?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Result == DialogResult.Yes)
                {
                    _AssignThePermissions();

                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
            }
        }
    }
}
