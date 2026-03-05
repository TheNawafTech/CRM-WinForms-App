namespace nfrmAddNewClient
{
    partial class frmAddNewClient
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbClientName = new System.Windows.Forms.Label();
            this.lbTotalOrders = new System.Windows.Forms.Label();
            this.lbTotalPurchaseValue = new System.Windows.Forms.Label();
            this.lbPhone = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTotalOrders = new System.Windows.Forms.TextBox();
            this.txtTotalPurchaseValue = new System.Windows.Forms.TextBox();
            this.btnAddNewClient = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(261, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adding new client";
            // 
            // lbClientName
            // 
            this.lbClientName.AutoSize = true;
            this.lbClientName.BackColor = System.Drawing.Color.Transparent;
            this.lbClientName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClientName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbClientName.Location = new System.Drawing.Point(160, 127);
            this.lbClientName.Name = "lbClientName";
            this.lbClientName.Size = new System.Drawing.Size(119, 24);
            this.lbClientName.TabIndex = 1;
            this.lbClientName.Text = "Client Name";
            // 
            // lbTotalOrders
            // 
            this.lbTotalOrders.AutoSize = true;
            this.lbTotalOrders.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalOrders.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalOrders.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbTotalOrders.Location = new System.Drawing.Point(158, 325);
            this.lbTotalOrders.Name = "lbTotalOrders";
            this.lbTotalOrders.Size = new System.Drawing.Size(121, 24);
            this.lbTotalOrders.TabIndex = 2;
            this.lbTotalOrders.Text = "Total Orders";
            // 
            // lbTotalPurchaseValue
            // 
            this.lbTotalPurchaseValue.AutoSize = true;
            this.lbTotalPurchaseValue.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalPurchaseValue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalPurchaseValue.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbTotalPurchaseValue.Location = new System.Drawing.Point(81, 391);
            this.lbTotalPurchaseValue.Name = "lbTotalPurchaseValue";
            this.lbTotalPurchaseValue.Size = new System.Drawing.Size(198, 24);
            this.lbTotalPurchaseValue.TabIndex = 3;
            this.lbTotalPurchaseValue.Text = "Total Purchase Value";
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.BackColor = System.Drawing.Color.Transparent;
            this.lbPhone.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhone.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbPhone.Location = new System.Drawing.Point(214, 193);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(65, 24);
            this.lbPhone.TabIndex = 4;
            this.lbPhone.Text = "Phone";
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.BackColor = System.Drawing.Color.Transparent;
            this.lbEmail.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmail.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbEmail.Location = new System.Drawing.Point(220, 259);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(59, 24);
            this.lbEmail.TabIndex = 5;
            this.lbEmail.Text = "Email";
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(320, 123);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(248, 24);
            this.txtClientName.TabIndex = 6;
            this.txtClientName.Enter += new System.EventHandler(this.txtClientName_Enter);
            this.txtClientName.Leave += new System.EventHandler(this.txtClientName_Leave);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(323, 193);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(248, 24);
            this.txtPhone.TabIndex = 7;
            this.txtPhone.Enter += new System.EventHandler(this.txtPhone_Enter);
            this.txtPhone.Leave += new System.EventHandler(this.txtPhone_Leave);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(323, 259);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(248, 24);
            this.txtEmail.TabIndex = 8;
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // txtTotalOrders
            // 
            this.txtTotalOrders.Location = new System.Drawing.Point(320, 329);
            this.txtTotalOrders.Name = "txtTotalOrders";
            this.txtTotalOrders.Size = new System.Drawing.Size(248, 24);
            this.txtTotalOrders.TabIndex = 9;
            this.txtTotalOrders.Enter += new System.EventHandler(this.txtTotalOrders_Enter);
            this.txtTotalOrders.Leave += new System.EventHandler(this.txtTotalOrders_Leave);
            // 
            // txtTotalPurchaseValue
            // 
            this.txtTotalPurchaseValue.Location = new System.Drawing.Point(320, 395);
            this.txtTotalPurchaseValue.Name = "txtTotalPurchaseValue";
            this.txtTotalPurchaseValue.Size = new System.Drawing.Size(248, 24);
            this.txtTotalPurchaseValue.TabIndex = 10;
            this.txtTotalPurchaseValue.Enter += new System.EventHandler(this.txtTotalPurchaseValue_Enter);
            this.txtTotalPurchaseValue.Leave += new System.EventHandler(this.txtTotalPurchaseValue_Leave);
            // 
            // btnAddNewClient
            // 
            this.btnAddNewClient.BackgroundImage = global::frmAddNewClient.Properties.Resources.old_1;
            this.btnAddNewClient.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewClient.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddNewClient.Location = new System.Drawing.Point(377, 463);
            this.btnAddNewClient.Name = "btnAddNewClient";
            this.btnAddNewClient.Size = new System.Drawing.Size(127, 44);
            this.btnAddNewClient.TabIndex = 11;
            this.btnAddNewClient.Text = "Submit";
            this.btnAddNewClient.UseVisualStyleBackColor = true;
            this.btnAddNewClient.Click += new System.EventHandler(this.btnSubmitNewClient_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::frmAddNewClient.Properties.Resources.old_1;
            this.pictureBox1.Image = global::frmAddNewClient.Properties.Resources.ppp;
            this.pictureBox1.Location = new System.Drawing.Point(-28, -12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 153);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // frmAddNewClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::frmAddNewClient.Properties.Resources.old_1;
            this.ClientSize = new System.Drawing.Size(780, 536);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAddNewClient);
            this.Controls.Add(this.txtTotalPurchaseValue);
            this.Controls.Add(this.txtTotalOrders);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtClientName);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.lbPhone);
            this.Controls.Add(this.lbTotalPurchaseValue);
            this.Controls.Add(this.lbTotalOrders);
            this.Controls.Add(this.lbClientName);
            this.Controls.Add(this.label1);
            this.Name = "frmAddNewClient";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frnAddNewClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbClientName;
        private System.Windows.Forms.Label lbTotalOrders;
        private System.Windows.Forms.Label lbTotalPurchaseValue;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTotalOrders;
        private System.Windows.Forms.TextBox txtTotalPurchaseValue;
        private System.Windows.Forms.Button btnAddNewClient;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

