namespace frmUpdateClient
{
    partial class frmUpdateClient
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnUpdateClient = new System.Windows.Forms.Button();
            this.txtTotalPurchaseValue = new System.Windows.Forms.TextBox();
            this.txtTotalOrders = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbPhone = new System.Windows.Forms.Label();
            this.lbTotalPurchaseValue = new System.Windows.Forms.Label();
            this.lbTotalOrders = new System.Windows.Forms.Label();
            this.lbClientName = new System.Windows.Forms.Label();
            this.lbClientID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Image = global::frmUpdateClient.Properties.Resources.old_1;
            this.label1.Location = new System.Drawing.Point(235, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Update Client ID ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.BackgroundImage = global::frmUpdateClient.Properties.Resources.old_1;
            this.pictureBox1.Image = global::frmUpdateClient.Properties.Resources.ppp;
            this.pictureBox1.Location = new System.Drawing.Point(-28, -12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 153);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // btnUpdateClient
            // 
            this.btnUpdateClient.BackgroundImage = global::frmUpdateClient.Properties.Resources.old_1;
            this.btnUpdateClient.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateClient.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdateClient.Location = new System.Drawing.Point(368, 467);
            this.btnUpdateClient.Name = "btnUpdateClient";
            this.btnUpdateClient.Size = new System.Drawing.Size(127, 44);
            this.btnUpdateClient.TabIndex = 24;
            this.btnUpdateClient.Text = "Submit";
            this.btnUpdateClient.UseVisualStyleBackColor = true;
            this.btnUpdateClient.Click += new System.EventHandler(this.btnUpdateClient_Click);
            // 
            // txtTotalPurchaseValue
            // 
            this.txtTotalPurchaseValue.Location = new System.Drawing.Point(316, 418);
            this.txtTotalPurchaseValue.Name = "txtTotalPurchaseValue";
            this.txtTotalPurchaseValue.Size = new System.Drawing.Size(248, 24);
            this.txtTotalPurchaseValue.TabIndex = 23;
            // 
            // txtTotalOrders
            // 
            this.txtTotalOrders.Location = new System.Drawing.Point(316, 352);
            this.txtTotalOrders.Name = "txtTotalOrders";
            this.txtTotalOrders.Size = new System.Drawing.Size(248, 24);
            this.txtTotalOrders.TabIndex = 22;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(319, 282);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(248, 24);
            this.txtEmail.TabIndex = 21;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(319, 216);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(248, 24);
            this.txtPhone.TabIndex = 20;
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(316, 146);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(248, 24);
            this.txtClientName.TabIndex = 19;
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.BackColor = System.Drawing.Color.Transparent;
            this.lbEmail.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmail.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbEmail.Location = new System.Drawing.Point(223, 282);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(59, 24);
            this.lbEmail.TabIndex = 18;
            this.lbEmail.Text = "Email";
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.BackColor = System.Drawing.Color.Transparent;
            this.lbPhone.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhone.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbPhone.Location = new System.Drawing.Point(217, 216);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(65, 24);
            this.lbPhone.TabIndex = 17;
            this.lbPhone.Text = "Phone";
            // 
            // lbTotalPurchaseValue
            // 
            this.lbTotalPurchaseValue.AutoSize = true;
            this.lbTotalPurchaseValue.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalPurchaseValue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalPurchaseValue.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbTotalPurchaseValue.Location = new System.Drawing.Point(84, 414);
            this.lbTotalPurchaseValue.Name = "lbTotalPurchaseValue";
            this.lbTotalPurchaseValue.Size = new System.Drawing.Size(198, 24);
            this.lbTotalPurchaseValue.TabIndex = 16;
            this.lbTotalPurchaseValue.Text = "Total Purchase Value";
            // 
            // lbTotalOrders
            // 
            this.lbTotalOrders.AutoSize = true;
            this.lbTotalOrders.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalOrders.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalOrders.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbTotalOrders.Location = new System.Drawing.Point(161, 348);
            this.lbTotalOrders.Name = "lbTotalOrders";
            this.lbTotalOrders.Size = new System.Drawing.Size(121, 24);
            this.lbTotalOrders.TabIndex = 15;
            this.lbTotalOrders.Text = "Total Orders";
            // 
            // lbClientName
            // 
            this.lbClientName.AutoSize = true;
            this.lbClientName.BackColor = System.Drawing.Color.Transparent;
            this.lbClientName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClientName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbClientName.Location = new System.Drawing.Point(156, 150);
            this.lbClientName.Name = "lbClientName";
            this.lbClientName.Size = new System.Drawing.Size(126, 24);
            this.lbClientName.TabIndex = 14;
            this.lbClientName.Text = "Cleint Name:";
            // 
            // lbClientID
            // 
            this.lbClientID.AutoSize = true;
            this.lbClientID.BackColor = System.Drawing.Color.Transparent;
            this.lbClientID.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClientID.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbClientID.Location = new System.Drawing.Point(521, 40);
            this.lbClientID.Name = "lbClientID";
            this.lbClientID.Size = new System.Drawing.Size(55, 40);
            this.lbClientID.TabIndex = 26;
            this.lbClientID.Text = "??";
            // 
            // frmUpdateClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::frmUpdateClient.Properties.Resources.old_1;
            this.ClientSize = new System.Drawing.Size(800, 564);
            this.Controls.Add(this.lbClientID);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnUpdateClient);
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
            this.Name = "frmUpdateClient";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmUpdateClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnUpdateClient;
        private System.Windows.Forms.TextBox txtTotalPurchaseValue;
        private System.Windows.Forms.TextBox txtTotalOrders;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.Label lbTotalPurchaseValue;
        private System.Windows.Forms.Label lbTotalOrders;
        private System.Windows.Forms.Label lbClientName;
        private System.Windows.Forms.Label lbClientID;
    }
}

