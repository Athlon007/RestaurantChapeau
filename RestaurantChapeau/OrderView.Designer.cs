﻿namespace RestaurantChapeau
{
    partial class OrderView
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.flwMenuTypes = new System.Windows.Forms.FlowLayoutPanel();
            this.flwMenuCategory = new System.Windows.Forms.FlowLayoutPanel();
            this.flwMenuItems = new System.Windows.Forms.FlowLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.theTabControl = new System.Windows.Forms.TabControl();
            this.tabConnecting = new System.Windows.Forms.TabPage();
            this.lblConnecting = new System.Windows.Forms.Label();
            this.tabPageMenu = new System.Windows.Forms.TabPage();
            this.pnlColumns = new System.Windows.Forms.Panel();
            this.lblNumber = new System.Windows.Forms.Label();
            this.tlpPlaceCancelOrder = new System.Windows.Forms.TableLayoutPanel();
            this.tabPageCheckout = new System.Windows.Forms.TabPage();
            this.flwCheckout = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlColumnsCheckout = new System.Windows.Forms.Panel();
            this.lblQuantityCheckout = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.theTabControl.SuspendLayout();
            this.tabConnecting.SuspendLayout();
            this.tabPageMenu.SuspendLayout();
            this.pnlColumns.SuspendLayout();
            this.tlpPlaceCancelOrder.SuspendLayout();
            this.tabPageCheckout.SuspendLayout();
            this.pnlColumnsCheckout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Black;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(180, 98);
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // flwMenuTypes
            // 
            this.flwMenuTypes.Dock = System.Windows.Forms.DockStyle.Top;
            this.flwMenuTypes.Location = new System.Drawing.Point(2, 2);
            this.flwMenuTypes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flwMenuTypes.Name = "flwMenuTypes";
            this.flwMenuTypes.Size = new System.Drawing.Size(754, 48);
            this.flwMenuTypes.TabIndex = 2;
            // 
            // flwMenuCategory
            // 
            this.flwMenuCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.flwMenuCategory.Location = new System.Drawing.Point(2, 50);
            this.flwMenuCategory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flwMenuCategory.Name = "flwMenuCategory";
            this.flwMenuCategory.Size = new System.Drawing.Size(754, 36);
            this.flwMenuCategory.TabIndex = 3;
            // 
            // flwMenuItems
            // 
            this.flwMenuItems.AutoScroll = true;
            this.flwMenuItems.BackColor = System.Drawing.Color.White;
            this.flwMenuItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flwMenuItems.Location = new System.Drawing.Point(2, 111);
            this.flwMenuItems.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flwMenuItems.Name = "flwMenuItems";
            this.flwMenuItems.Size = new System.Drawing.Size(754, 587);
            this.flwMenuItems.TabIndex = 4;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(50, 2);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 20);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name";
            // 
            // lblSub
            // 
            this.lblSub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSub.AutoSize = true;
            this.lblSub.Location = new System.Drawing.Point(549, 2);
            this.lblSub.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(65, 20);
            this.lblSub.TabIndex = 6;
            this.lblSub.Text = "Quantity";
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlaceOrder.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPlaceOrder.Location = new System.Drawing.Point(379, 2);
            this.btnPlaceOrder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(373, 67);
            this.btnPlaceOrder.TabIndex = 7;
            this.btnPlaceOrder.Text = "Basket";
            this.btnPlaceOrder.UseVisualStyleBackColor = true;
            this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(2, 2);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(373, 67);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // theTabControl
            // 
            this.theTabControl.Controls.Add(this.tabConnecting);
            this.theTabControl.Controls.Add(this.tabPageMenu);
            this.theTabControl.Controls.Add(this.tabPageCheckout);
            this.theTabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.theTabControl.Location = new System.Drawing.Point(0, -145);
            this.theTabControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.theTabControl.Name = "theTabControl";
            this.theTabControl.SelectedIndex = 0;
            this.theTabControl.Size = new System.Drawing.Size(766, 804);
            this.theTabControl.TabIndex = 9;
            // 
            // tabConnecting
            // 
            this.tabConnecting.Controls.Add(this.lblConnecting);
            this.tabConnecting.Location = new System.Drawing.Point(4, 29);
            this.tabConnecting.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabConnecting.Name = "tabConnecting";
            this.tabConnecting.Size = new System.Drawing.Size(758, 771);
            this.tabConnecting.TabIndex = 2;
            this.tabConnecting.Text = "tabConnecting";
            this.tabConnecting.UseVisualStyleBackColor = true;
            // 
            // lblConnecting
            // 
            this.lblConnecting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConnecting.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblConnecting.Location = new System.Drawing.Point(0, 0);
            this.lblConnecting.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConnecting.Name = "lblConnecting";
            this.lblConnecting.Size = new System.Drawing.Size(758, 771);
            this.lblConnecting.TabIndex = 0;
            this.lblConnecting.Text = "Connecting to server...";
            this.lblConnecting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblConnecting.Click += new System.EventHandler(this.lblConnecting_Click);
            // 
            // tabPageMenu
            // 
            this.tabPageMenu.Controls.Add(this.flwMenuItems);
            this.tabPageMenu.Controls.Add(this.pnlColumns);
            this.tabPageMenu.Controls.Add(this.tlpPlaceCancelOrder);
            this.tabPageMenu.Controls.Add(this.flwMenuCategory);
            this.tabPageMenu.Controls.Add(this.flwMenuTypes);
            this.tabPageMenu.Location = new System.Drawing.Point(4, 29);
            this.tabPageMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageMenu.Name = "tabPageMenu";
            this.tabPageMenu.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageMenu.Size = new System.Drawing.Size(758, 771);
            this.tabPageMenu.TabIndex = 0;
            this.tabPageMenu.Text = "tabPageMenu";
            this.tabPageMenu.UseVisualStyleBackColor = true;
            // 
            // pnlColumns
            // 
            this.pnlColumns.BackColor = System.Drawing.Color.PowderBlue;
            this.pnlColumns.Controls.Add(this.lblNumber);
            this.pnlColumns.Controls.Add(this.lblSub);
            this.pnlColumns.Controls.Add(this.lblName);
            this.pnlColumns.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlColumns.Location = new System.Drawing.Point(2, 86);
            this.pnlColumns.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlColumns.Name = "pnlColumns";
            this.pnlColumns.Size = new System.Drawing.Size(754, 25);
            this.pnlColumns.TabIndex = 10;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(2, 2);
            this.lblNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(29, 20);
            this.lblNumber.TabIndex = 7;
            this.lblNumber.Text = "No";
            // 
            // tlpPlaceCancelOrder
            // 
            this.tlpPlaceCancelOrder.ColumnCount = 2;
            this.tlpPlaceCancelOrder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlaceCancelOrder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlaceCancelOrder.Controls.Add(this.btnCancel, 0, 0);
            this.tlpPlaceCancelOrder.Controls.Add(this.btnPlaceOrder, 1, 0);
            this.tlpPlaceCancelOrder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpPlaceCancelOrder.Location = new System.Drawing.Point(2, 698);
            this.tlpPlaceCancelOrder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tlpPlaceCancelOrder.Name = "tlpPlaceCancelOrder";
            this.tlpPlaceCancelOrder.RowCount = 1;
            this.tlpPlaceCancelOrder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlaceCancelOrder.Size = new System.Drawing.Size(754, 71);
            this.tlpPlaceCancelOrder.TabIndex = 10;
            // 
            // tabPageCheckout
            // 
            this.tabPageCheckout.Controls.Add(this.flwCheckout);
            this.tabPageCheckout.Controls.Add(this.pnlColumnsCheckout);
            this.tabPageCheckout.Controls.Add(this.lblComment);
            this.tabPageCheckout.Controls.Add(this.txtComment);
            this.tabPageCheckout.Controls.Add(this.tableLayoutPanel1);
            this.tabPageCheckout.Location = new System.Drawing.Point(4, 29);
            this.tabPageCheckout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageCheckout.Name = "tabPageCheckout";
            this.tabPageCheckout.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageCheckout.Size = new System.Drawing.Size(758, 771);
            this.tabPageCheckout.TabIndex = 1;
            this.tabPageCheckout.Text = "tabPageCheckout";
            this.tabPageCheckout.UseVisualStyleBackColor = true;
            // 
            // flwCheckout
            // 
            this.flwCheckout.AutoScroll = true;
            this.flwCheckout.BackColor = System.Drawing.Color.White;
            this.flwCheckout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flwCheckout.Location = new System.Drawing.Point(2, 27);
            this.flwCheckout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flwCheckout.Name = "flwCheckout";
            this.flwCheckout.Size = new System.Drawing.Size(754, 535);
            this.flwCheckout.TabIndex = 11;
            // 
            // pnlColumnsCheckout
            // 
            this.pnlColumnsCheckout.BackColor = System.Drawing.Color.PowderBlue;
            this.pnlColumnsCheckout.Controls.Add(this.lblQuantityCheckout);
            this.pnlColumnsCheckout.Controls.Add(this.label2);
            this.pnlColumnsCheckout.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlColumnsCheckout.Location = new System.Drawing.Point(2, 2);
            this.pnlColumnsCheckout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlColumnsCheckout.Name = "pnlColumnsCheckout";
            this.pnlColumnsCheckout.Size = new System.Drawing.Size(754, 25);
            this.pnlColumnsCheckout.TabIndex = 12;
            // 
            // lblQuantityCheckout
            // 
            this.lblQuantityCheckout.AutoSize = true;
            this.lblQuantityCheckout.Location = new System.Drawing.Point(547, 2);
            this.lblQuantityCheckout.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuantityCheckout.Name = "lblQuantityCheckout";
            this.lblQuantityCheckout.Size = new System.Drawing.Size(65, 20);
            this.lblQuantityCheckout.TabIndex = 6;
            this.lblQuantityCheckout.Text = "Quantity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 2);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Name";
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblComment.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblComment.Location = new System.Drawing.Point(2, 562);
            this.lblComment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(163, 41);
            this.lblComment.TabIndex = 11;
            this.lblComment.Text = "Comments";
            // 
            // txtComment
            // 
            this.txtComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtComment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtComment.Location = new System.Drawing.Point(2, 603);
            this.txtComment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.PlaceholderText = "Insert comment here...";
            this.txtComment.Size = new System.Drawing.Size(754, 95);
            this.txtComment.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnBack, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFinish, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 698);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(754, 71);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // btnBack
            // 
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBack.Location = new System.Drawing.Point(2, 2);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(373, 67);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFinish.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFinish.Location = new System.Drawing.Point(379, 2);
            this.btnFinish.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(373, 67);
            this.btnFinish.TabIndex = 7;
            this.btnFinish.Text = "Place Order";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHeader.Location = new System.Drawing.Point(197, 18);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(95, 41);
            this.lblHeader.TabIndex = 10;
            this.lblHeader.Text = "Menu";
            // 
            // OrderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 659);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.theTabControl);
            this.Controls.Add(this.picLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "OrderView";
            this.Text = "OrderView";
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.theTabControl.ResumeLayout(false);
            this.tabConnecting.ResumeLayout(false);
            this.tabPageMenu.ResumeLayout(false);
            this.pnlColumns.ResumeLayout(false);
            this.pnlColumns.PerformLayout();
            this.tlpPlaceCancelOrder.ResumeLayout(false);
            this.tabPageCheckout.ResumeLayout(false);
            this.tabPageCheckout.PerformLayout();
            this.pnlColumnsCheckout.ResumeLayout(false);
            this.pnlColumnsCheckout.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.FlowLayoutPanel flwMenuTypes;
        private System.Windows.Forms.FlowLayoutPanel flwMenuCategory;
        private System.Windows.Forms.FlowLayoutPanel flwMenuItems;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Button btnPlaceOrder;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl theTabControl;
        private System.Windows.Forms.TabPage tabPageMenu;
        private System.Windows.Forms.TabPage tabPageCheckout;
        private System.Windows.Forms.TableLayoutPanel tlpPlaceCancelOrder;
        private System.Windows.Forms.Panel pnlColumns;
        private System.Windows.Forms.FlowLayoutPanel flwCheckout;
        private System.Windows.Forms.Panel pnlColumnsCheckout;
        private System.Windows.Forms.Label lblQuantityCheckout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.TabPage tabConnecting;
        private System.Windows.Forms.Label lblConnecting;
    }
}