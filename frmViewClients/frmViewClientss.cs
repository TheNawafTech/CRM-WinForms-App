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

namespace frmViewClients
{
    public partial class frmViewClientss : Form
    {
        public frmViewClientss()
        {
            InitializeComponent();
        }

        public void GetAllClients()
        {
            DataTable Dt = new DataTable();
            if (ClsBusinessLayer.ClsBusinessLayer.GetAllRecords(ref Dt, "SELECT * FROM Clients"))
            {
                dataGridView1.DataSource = Dt;
                dataGridView1.Columns["ClientID"].HeaderText = "Client ID"; // Hide ClientID column
                dataGridView1.Columns["ClientName"].HeaderText = "Client Name"; // Rename column header
                dataGridView1.Columns["Phone"].HeaderText = "Phone"; // Rename column header
                dataGridView1.Columns["Email"].HeaderText = "Email"; // Rename column header
                dataGridView1.Columns["TotalOrders"].HeaderText = "Total Orders"; // Rename column header
                dataGridView1.Columns["TotalPurchaseValue"].HeaderText = "Total Purchase Value"; // Rename column header
            }
            else
            {
                MessageBox.Show("No clients found.");
            }
        }

        void DesignTheDataGridViewClients()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dataGridView1.Columns["ClientName"].DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            dataGridView1.Columns["Phone"].DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            dataGridView1.Columns["Email"].DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            dataGridView1.Columns["TotalOrders"].DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            dataGridView1.Columns["TotalPurchaseValue"].DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);

            dataGridView1.EnableHeadersVisualStyles = false; // Disable default header styles to apply custom styles
            dataGridView1.BorderStyle = BorderStyle.None; // Remove border for a cleaner look
            dataGridView1.AllowUserToAddRows = false; // Disable adding new rows
            dataGridView1.AllowUserToDeleteRows = false; // Disable deleting rows   
            dataGridView1.ReadOnly = true; // Make the DataGridView read-only
            dataGridView1.RowHeadersVisible = false; // Hide row headers for a cleaner look

            dataGridView1.RowTemplate.Height = 40; // Set row height for better visibility
            dataGridView1.ColumnHeadersHeight = 40; // Set header height for better visibility
            dataGridView1.MultiSelect = false; // Disable multi-select for a cleaner user experience

            dataGridView1.SelectionChanged += (s, ev) =>
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var selectedRow = dataGridView1.SelectedRows[0];
                    // You can perform actions with the selected row here
                }
            };

            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            // لون النص
            dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            // لون التحديد
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;


        }
        private void frmViewClientss_Load(object sender, EventArgs e)
        {
            label1.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            label1.BackColor = Color.FromArgb(80, 0, 0, 0); // رمادي شفاف

            GetAllClients();
            DesignTheDataGridViewClients();
        }
    }
}
