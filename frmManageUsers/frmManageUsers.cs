using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using frmViewUsers;
using frmAddNewUser;
//using frmUpdateUser;
using frmDeleteUser;
using frmFindUser;

namespace frmManageUsers
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف

        }

        private void btnListUsers_Click(object sender, EventArgs e)
        {
            frmViewUsers.frmViewUsers frmView = new frmViewUsers.frmViewUsers();
            frmView.ShowDialog();
        }

        private void btnAddnewUser_Click(object sender, EventArgs e)
        {
            frmAddNewUser.frmAddNewUser frmAdd = new frmAddNewUser.frmAddNewUser();
            frmAdd.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            frmDeleteUser.frmDeleteUser frmDelete = new frmDeleteUser.frmDeleteUser();
            frmDelete.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
          //  frmUpdateUser.frmUpdateUser frmUpdate = new frmUpdateUser.frmUpdateUser();
            //frmUpdate.ShowDialog();
        }
        private void btnFindUser_Click(object sender, EventArgs e)
        {
            frmFindUser.frmSearchUser frmFind = new frmFindUser.frmSearchUser();
            frmFind.ShowDialog();
        }
    }
}
