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
            this.lblPayTo = new System.Windows.Forms.Label();
            this.lblChapeau = new System.Windows.Forms.Label();
            this.listViewInvoice = new System.Windows.Forms.ListView();
            this.headerName = new System.Windows.Forms.ColumnHeader();
            this.headerPrice = new System.Windows.Forms.ColumnHeader();
            this.headerQuantity = new System.Windows.Forms.ColumnHeader();
            this.headerSubtotal = new System.Windows.Forms.ColumnHeader();
            this.headerVat = new System.Windows.Forms.ColumnHeader();
            this.btnProcessPayment = new System.Windows.Forms.Button();
            this.groupBoxMoreInfo = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TotalValue = new System.Windows.Forms.Label();
            this.TaxValue = new System.Windows.Forms.Label();
            this.SubtotalValue = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblLine = new System.Windows.Forms.Label();
            this.lblTotals = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.paymentBackButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            this.groupBoxMoreInfo.SuspendLayout();
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
            this.lblInvoiceDate.Location = new System.Drawing.Point(134, 278);
            this.lblInvoiceDate.Name = "lblInvoiceDate";
            this.lblInvoiceDate.Size = new System.Drawing.Size(85, 37);
            this.lblInvoiceDate.TabIndex = 18;
            this.lblInvoiceDate.Text = "Date:";
            // 
            // lblInvoiceID
            // 
            this.lblInvoiceID.AutoSize = true;
            this.lblInvoiceID.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblInvoiceID.Location = new System.Drawing.Point(134, 315);
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
            // lblPayTo
            // 
            this.lblPayTo.AutoSize = true;
            this.lblPayTo.Font = new System.Drawing.Font("Segoe UI", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPayTo.Location = new System.Drawing.Point(869, 207);
            this.lblPayTo.Name = "lblPayTo";
            this.lblPayTo.Size = new System.Drawing.Size(160, 59);
            this.lblPayTo.TabIndex = 22;
            this.lblPayTo.Text = "PAY TO";
            // 
            // lblChapeau
            // 
            this.lblChapeau.AutoSize = true;
            this.lblChapeau.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblChapeau.Location = new System.Drawing.Point(869, 278);
            this.lblChapeau.Name = "lblChapeau";
            this.lblChapeau.Size = new System.Drawing.Size(128, 37);
            this.lblChapeau.TabIndex = 23;
            this.lblChapeau.Text = "Chapeau";
            // 
            // listViewInvoice
            // 
            this.listViewInvoice.BackColor = System.Drawing.Color.White;
            this.listViewInvoice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewInvoice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.headerName,
            this.headerPrice,
            this.headerQuantity,
            this.headerSubtotal,
            this.headerVat});
            this.listViewInvoice.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listViewInvoice.HideSelection = false;
            this.listViewInvoice.Location = new System.Drawing.Point(135, 390);
            this.listViewInvoice.Name = "listViewInvoice";
            this.listViewInvoice.Size = new System.Drawing.Size(862, 496);
            this.listViewInvoice.TabIndex = 24;
            this.listViewInvoice.UseCompatibleStateImageBehavior = false;
            this.listViewInvoice.View = System.Windows.Forms.View.Details;
            // 
            // headerName
            // 
            this.headerName.Text = "Name";
            this.headerName.Width = 350;
            // 
            // headerPrice
            // 
            this.headerPrice.Text = "Unit Price";
            this.headerPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.headerPrice.Width = 150;
            // 
            // headerQuantity
            // 
            this.headerQuantity.Text = "Quantity";
            this.headerQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.headerQuantity.Width = 110;
            // 
            // headerSubtotal
            // 
            this.headerSubtotal.Text = "Subtotal";
            this.headerSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.headerSubtotal.Width = 150;
            // 
            // headerVat
            // 
            this.headerVat.Text = "Vat";
            this.headerVat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.headerVat.Width = 100;
            // 
            // btnProcessPayment
            // 
            this.btnProcessPayment.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnProcessPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnProcessPayment.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnProcessPayment.Location = new System.Drawing.Point(393, 1227);
            this.btnProcessPayment.Margin = new System.Windows.Forms.Padding(5);
            this.btnProcessPayment.Name = "btnProcessPayment";
            this.btnProcessPayment.Size = new System.Drawing.Size(320, 93);
            this.btnProcessPayment.TabIndex = 25;
            this.btnProcessPayment.Text = "Process Payment";
            this.btnProcessPayment.UseVisualStyleBackColor = false;
            // 
            // groupBoxMoreInfo
            // 
            this.groupBoxMoreInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.groupBoxMoreInfo.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBoxMoreInfo.Controls.Add(this.label4);
            this.groupBoxMoreInfo.Controls.Add(this.TotalValue);
            this.groupBoxMoreInfo.Controls.Add(this.TaxValue);
            this.groupBoxMoreInfo.Controls.Add(this.SubtotalValue);
            this.groupBoxMoreInfo.Controls.Add(this.lblTotal);
            this.groupBoxMoreInfo.Controls.Add(this.lblTax);
            this.groupBoxMoreInfo.Controls.Add(this.lblSubtotal);
            this.groupBoxMoreInfo.Controls.Add(this.lblLine);
            this.groupBoxMoreInfo.Controls.Add(this.lblTotals);
            this.groupBoxMoreInfo.Controls.Add(this.lblInfo);
            this.groupBoxMoreInfo.Location = new System.Drawing.Point(130, 923);
            this.groupBoxMoreInfo.Name = "groupBoxMoreInfo";
            this.groupBoxMoreInfo.Size = new System.Drawing.Size(867, 264);
            this.groupBoxMoreInfo.TabIndex = 26;
            this.groupBoxMoreInfo.TabStop = false;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(26, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(816, 2);
            this.label4.TabIndex = 35;
            // 
            // TotalValue
            // 
            this.TotalValue.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TotalValue.Location = new System.Drawing.Point(549, 175);
            this.TotalValue.Name = "TotalValue";
            this.TotalValue.Size = new System.Drawing.Size(293, 37);
            this.TotalValue.TabIndex = 34;
            this.TotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TaxValue
            // 
            this.TaxValue.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TaxValue.Location = new System.Drawing.Point(549, 127);
            this.TaxValue.Name = "TaxValue";
            this.TaxValue.Size = new System.Drawing.Size(293, 37);
            this.TaxValue.TabIndex = 33;
            this.TaxValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SubtotalValue
            // 
            this.SubtotalValue.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SubtotalValue.Location = new System.Drawing.Point(549, 81);
            this.SubtotalValue.Name = "SubtotalValue";
            this.SubtotalValue.Size = new System.Drawing.Size(293, 37);
            this.SubtotalValue.TabIndex = 32;
            this.SubtotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotal.Location = new System.Drawing.Point(29, 175);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(89, 37);
            this.lblTotal.TabIndex = 31;
            this.lblTotal.Text = "Total:";
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTax.Location = new System.Drawing.Point(26, 127);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(60, 37);
            this.lblTax.TabIndex = 30;
            this.lblTax.Text = "Tax:";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubtotal.Location = new System.Drawing.Point(26, 81);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(123, 37);
            this.lblSubtotal.TabIndex = 27;
            this.lblSubtotal.Text = "Subtotal:";
            // 
            // lblLine
            // 
            this.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLine.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLine.Location = new System.Drawing.Point(26, 64);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(816, 2);
            this.lblLine.TabIndex = 29;
            // 
            // lblTotals
            // 
            this.lblTotals.AutoSize = true;
            this.lblTotals.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotals.Location = new System.Drawing.Point(748, 20);
            this.lblTotals.Name = "lblTotals";
            this.lblTotals.Size = new System.Drawing.Size(94, 37);
            this.lblTotals.TabIndex = 28;
            this.lblTotals.Text = "Totals";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblInfo.Location = new System.Drawing.Point(26, 20);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(314, 37);
            this.lblInfo.TabIndex = 27;
            this.lblInfo.Text = "Additional information";
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1138, 1362);
            this.Controls.Add(this.groupBoxMoreInfo);
            this.Controls.Add(this.btnProcessPayment);
            this.Controls.Add(this.listViewInvoice);
            this.Controls.Add(this.lblChapeau);
            this.Controls.Add(this.lblPayTo);
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
            this.Load += new System.EventHandler(this.Payment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.paymentBackButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            this.groupBoxMoreInfo.ResumeLayout(false);
            this.groupBoxMoreInfo.PerformLayout();
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
        private System.Windows.Forms.Label lblPayTo;
        private System.Windows.Forms.Label lblChapeau;
        private System.Windows.Forms.ListView listViewInvoice;
        private System.Windows.Forms.ColumnHeader headerName;
        private System.Windows.Forms.ColumnHeader headerPrice;
        private System.Windows.Forms.ColumnHeader headerQuantity;
        private System.Windows.Forms.ColumnHeader headerSubtotal;
        private System.Windows.Forms.Button btnProcessPayment;
        private System.Windows.Forms.GroupBox groupBoxMoreInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label TotalValue;
        private System.Windows.Forms.Label TaxValue;
        private System.Windows.Forms.Label SubtotalValue;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label lblTotals;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ColumnHeader headerVat;
    }
}