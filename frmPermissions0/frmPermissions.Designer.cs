namespace frmPermissions0
{
    partial class frmPermissions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbSelectPermissions = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chAddNewClient = new System.Windows.Forms.CheckBox();
            this.chUpdateClient = new System.Windows.Forms.CheckBox();
            this.chDeleteClient = new System.Windows.Forms.CheckBox();
            this.chSearchClient = new System.Windows.Forms.CheckBox();
            this.chViewClients = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chManageUsers = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbSelectPermissions
            // 
            this.lbSelectPermissions.AutoSize = true;
            this.lbSelectPermissions.BackColor = System.Drawing.Color.Transparent;
            this.lbSelectPermissions.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSelectPermissions.ForeColor = System.Drawing.Color.Transparent;
            this.lbSelectPermissions.Location = new System.Drawing.Point(248, 18);
            this.lbSelectPermissions.Name = "lbSelectPermissions";
            this.lbSelectPermissions.Size = new System.Drawing.Size(328, 40);
            this.lbSelectPermissions.TabIndex = 1;
            this.lbSelectPermissions.Text = "Select Permissions";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.chManageUsers);
            this.groupBox1.Controls.Add(this.chAddNewClient);
            this.groupBox1.Controls.Add(this.chUpdateClient);
            this.groupBox1.Controls.Add(this.chDeleteClient);
            this.groupBox1.Controls.Add(this.chSearchClient);
            this.groupBox1.Controls.Add(this.chViewClients);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(117, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(524, 316);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // chAddNewClient
            // 
            this.chAddNewClient.AutoSize = true;
            this.chAddNewClient.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chAddNewClient.Location = new System.Drawing.Point(171, 217);
            this.chAddNewClient.Name = "chAddNewClient";
            this.chAddNewClient.Size = new System.Drawing.Size(254, 38);
            this.chAddNewClient.TabIndex = 11;
            this.chAddNewClient.Text = "Add New Client";
            this.chAddNewClient.UseVisualStyleBackColor = true;
            // 
            // chUpdateClient
            // 
            this.chUpdateClient.AutoSize = true;
            this.chUpdateClient.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chUpdateClient.Location = new System.Drawing.Point(171, 167);
            this.chUpdateClient.Name = "chUpdateClient";
            this.chUpdateClient.Size = new System.Drawing.Size(230, 38);
            this.chUpdateClient.TabIndex = 10;
            this.chUpdateClient.Text = "Update Client";
            this.chUpdateClient.UseVisualStyleBackColor = true;
            // 
            // chDeleteClient
            // 
            this.chDeleteClient.AutoSize = true;
            this.chDeleteClient.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chDeleteClient.Location = new System.Drawing.Point(171, 117);
            this.chDeleteClient.Name = "chDeleteClient";
            this.chDeleteClient.Size = new System.Drawing.Size(211, 38);
            this.chDeleteClient.TabIndex = 9;
            this.chDeleteClient.Text = "DeleteClient";
            this.chDeleteClient.UseVisualStyleBackColor = true;
            // 
            // chSearchClient
            // 
            this.chSearchClient.AutoSize = true;
            this.chSearchClient.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chSearchClient.Location = new System.Drawing.Point(171, 67);
            this.chSearchClient.Name = "chSearchClient";
            this.chSearchClient.Size = new System.Drawing.Size(224, 38);
            this.chSearchClient.TabIndex = 8;
            this.chSearchClient.Text = "Search Client";
            this.chSearchClient.UseVisualStyleBackColor = true;
            // 
            // chViewClients
            // 
            this.chViewClients.AutoSize = true;
            this.chViewClients.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chViewClients.Location = new System.Drawing.Point(171, 17);
            this.chViewClients.Name = "chViewClients";
            this.chViewClients.Size = new System.Drawing.Size(202, 38);
            this.chViewClients.TabIndex = 7;
            this.chViewClients.Text = "ViewClients";
            this.chViewClients.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.BackgroundImage = global::frmPermissions0.Properties.Resources.old_1;
            this.button1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(339, 433);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 54);
            this.button1.TabIndex = 4;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // chManageUsers
            // 
            this.chManageUsers.AutoSize = true;
            this.chManageUsers.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chManageUsers.Location = new System.Drawing.Point(171, 267);
            this.chManageUsers.Name = "chManageUsers";
            this.chManageUsers.Size = new System.Drawing.Size(235, 38);
            this.chManageUsers.TabIndex = 12;
            this.chManageUsers.Text = "Manage Users";
            this.chManageUsers.UseVisualStyleBackColor = true;
            // 
            // frmPermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::frmPermissions0.Properties.Resources.old_1;
            this.ClientSize = new System.Drawing.Size(800, 510);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbSelectPermissions);
            this.Name = "frmPermissions";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmPermissions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbSelectPermissions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chAddNewClient;
        private System.Windows.Forms.CheckBox chUpdateClient;
        private System.Windows.Forms.CheckBox chDeleteClient;
        private System.Windows.Forms.CheckBox chSearchClient;
        private System.Windows.Forms.CheckBox chViewClients;
        private System.Windows.Forms.CheckBox chManageUsers;
    }
}

