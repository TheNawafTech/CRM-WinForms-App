namespace frmManageUsers
{
    partial class FrmFindAndUpdate
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.lbUserID = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbUpdateUser = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImage = global::frmManageUsers.Properties.Resources.old_1;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.Location = new System.Drawing.Point(382, 308);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(127, 44);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // lbUserID
            // 
            this.lbUserID.AutoSize = true;
            this.lbUserID.BackColor = System.Drawing.Color.Transparent;
            this.lbUserID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserID.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbUserID.Location = new System.Drawing.Point(170, 212);
            this.lbUserID.Name = "lbUserID";
            this.lbUserID.Size = new System.Drawing.Size(100, 24);
            this.lbUserID.TabIndex = 12;
            this.lbUserID.Text = "User ID :";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(314, 212);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(280, 24);
            this.txtUserID.TabIndex = 11;
            this.txtUserID.Enter += new System.EventHandler(this.txtUserID_Enter_1);
            this.txtUserID.Leave += new System.EventHandler(this.txtUserID_Leave_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 153);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // lbUpdateUser
            // 
            this.lbUpdateUser.AutoSize = true;
            this.lbUpdateUser.BackColor = System.Drawing.Color.Transparent;
            this.lbUpdateUser.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUpdateUser.ForeColor = System.Drawing.Color.Transparent;
            this.lbUpdateUser.Location = new System.Drawing.Point(326, 48);
            this.lbUpdateUser.Name = "lbUpdateUser";
            this.lbUpdateUser.Size = new System.Drawing.Size(222, 40);
            this.lbUpdateUser.TabIndex = 9;
            this.lbUpdateUser.Text = "Update User";
            // 
            // FrmFindAndUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::frmManageUsers.Properties.Resources.old_1;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lbUserID);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbUpdateUser);
            this.Name = "FrmFindAndUpdate";
            this.Text = "FrmFindAndUpdate";
            this.Load += new System.EventHandler(this.FrmFindAndUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lbUserID;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbUpdateUser;
    }
}