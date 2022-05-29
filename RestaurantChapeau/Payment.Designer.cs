namespace RestaurantChapeau
{
    partial class Payment
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
            this.paymentBackButton1 = new System.Windows.Forms.PictureBox();
            this.lblPaymentTopBarText = new System.Windows.Forms.Label();
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.lblPaymentHeader = new System.Windows.Forms.Label();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.lblInvoiceDate = new System.Windows.Forms.Label();
            this.lblInvoiceID = new System.Windows.Forms.Label();
            this.valueInvoiceID = new System.Windows.Forms.Label();
            this.valueInvoiceDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.paymentBackButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // paymentBackButton1
            // 
            this.paymentBackButton1.BackColor = System.Drawing.Color.Transparent;
            this.paymentBackButton1.Image = global::RestaurantChapeau.Properties.Resources.backbutton;
            this.paymentBackButton1.Location = new System.Drawing.Point(10, 12);
            this.paymentBackButton1.Name = "paymentBackButton1";
            this.paymentBackButton1.Size = new System.Drawing.Size(100, 100);
            this.paymentBackButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.paymentBackButton1.TabIndex = 16;
            this.paymentBackButton1.TabStop = false;
            // 
            // lblPaymentTopBarText
            // 
            this.lblPaymentTopBarText.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPaymentTopBarText.Location = new System.Drawing.Point(116, 0);
            this.lblPaymentTopBarText.Name = "lblPaymentTopBarText";
            this.lblPaymentTopBarText.Size = new System.Drawing.Size(839, 127);
            this.lblPaymentTopBarText.TabIndex = 15;
            this.lblPaymentTopBarText.Text = "Order View";
            this.lblPaymentTopBarText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPaymentTopBarText.UseCompatibleTextRendering = true;
            // 
            // imgLogo
            // 
            this.imgLogo.BackColor = System.Drawing.Color.Black;
            this.imgLogo.Image = global::RestaurantChapeau.Properties.Resources.hat;
            this.imgLogo.Location = new System.Drawing.Point(951, 0);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(187, 127);
            this.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLogo.TabIndex = 13;
            this.imgLogo.TabStop = false;
            // 
            // lblPaymentHeader
            // 
            this.lblPaymentHeader.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPaymentHeader.Location = new System.Drawing.Point(-23, 139);
            this.lblPaymentHeader.Name = "lblPaymentHeader";
            this.lblPaymentHeader.Size = new System.Drawing.Size(1180, 68);
            this.lblPaymentHeader.TabIndex = 14;
            this.lblPaymentHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInvoice
            // 
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.Font = new System.Drawing.Font("Segoe UI", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInvoice.Location = new System.Drawing.Point(130, 207);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(158, 59);
            this.lblInvoice.TabIndex = 17;
            this.lblInvoice.Text = "Invoice";
            // 
            // lblInvoiceDate
            // 
            this.lblInvoiceDate.AutoSize = true;
            this.lblInvoiceDate.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblInvoiceDate.Location = new System.Drawing.Point(141, 278);
            this.lblInvoiceDate.Name = "lblInvoiceDate";
            this.lblInvoiceDate.Size = new System.Drawing.Size(85, 37);
            this.lblInvoiceDate.TabIndex = 18;
            this.lblInvoiceDate.Text = "Date:";
            // 
            // lblInvoiceID
            // 
            this.lblInvoiceID.AutoSize = true;
            this.lblInvoiceID.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblInvoiceID.Location = new System.Drawing.Point(141, 315);
            this.lblInvoiceID.Name = "lblInvoiceID";
            this.lblInvoiceID.Size = new System.Drawing.Size(117, 37);
            this.lblInvoiceID.TabIndex = 19;
            this.lblInvoiceID.Text = "Invoice:";
            // 
            // valueInvoiceID
            // 
            this.valueInvoiceID.AutoSize = true;
            this.valueInvoiceID.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.valueInvoiceID.Location = new System.Drawing.Point(264, 315);
            this.valueInvoiceID.Name = "valueInvoiceID";
            this.valueInvoiceID.Size = new System.Drawing.Size(0, 37);
            this.valueInvoiceID.TabIndex = 21;
            // 
            // valueInvoiceDate
            // 
            this.valueInvoiceDate.AutoSize = true;
            this.valueInvoiceDate.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.valueInvoiceDate.Location = new System.Drawing.Point(232, 278);
            this.valueInvoiceDate.Name = "valueInvoiceDate";
            this.valueInvoiceDate.Size = new System.Drawing.Size(0, 37);
            this.valueInvoiceDate.TabIndex = 20;
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1138, 1362);
            this.Controls.Add(this.valueInvoiceID);
            this.Controls.Add(this.valueInvoiceDate);
            this.Controls.Add(this.lblInvoiceID);
            this.Controls.Add(this.lblInvoiceDate);
            this.Controls.Add(this.lblInvoice);
            this.Controls.Add(this.paymentBackButton1);
            this.Controls.Add(this.lblPaymentTopBarText);
            this.Controls.Add(this.imgLogo);
            this.Controls.Add(this.lblPaymentHeader);
            this.Name = "Payment";
            this.Text = "Payment";
            ((System.ComponentModel.ISupportInitialize)(this.paymentBackButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox paymentBackButton1;
        private System.Windows.Forms.Label lblPaymentTopBarText;
        private System.Windows.Forms.PictureBox imgLogo;
        private System.Windows.Forms.Label lblPaymentHeader;
        private System.Windows.Forms.Label lblInvoice;
        private System.Windows.Forms.Label lblInvoiceDate;
        private System.Windows.Forms.Label lblInvoiceID;
        private System.Windows.Forms.Label valueInvoiceID;
        private System.Windows.Forms.Label valueInvoiceDate;
    }
}