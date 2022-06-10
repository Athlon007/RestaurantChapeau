namespace RestaurantChapeau
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
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.flwMenuTypes = new System.Windows.Forms.FlowLayoutPanel();
            this.flwMenuItems = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.theTabControl = new System.Windows.Forms.TabControl();
            this.tabConnecting = new System.Windows.Forms.TabPage();
            this.lblConnecting = new System.Windows.Forms.Label();
            this.tabPageMenu = new System.Windows.Forms.TabPage();
            this.tlpPlaceCancelOrder = new System.Windows.Forms.TableLayoutPanel();
            this.tabPageCheckout = new System.Windows.Forms.TabPage();
            this.flwCheckout = new System.Windows.Forms.FlowLayoutPanel();
            this.lblComment = new System.Windows.Forms.Label();
            this.pnlCommentTextBox = new System.Windows.Forms.Panel();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnFinish = new System.Windows.Forms.Button();
            this.tabOrderSucceeded = new System.Windows.Forms.TabPage();
            this.lblOrderPlaced = new System.Windows.Forms.Label();
            this.picTick = new System.Windows.Forms.PictureBox();
            this.lblQuantityCheckout = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picBackButton = new System.Windows.Forms.PictureBox();
            this.lblHeader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.theTabControl.SuspendLayout();
            this.tabConnecting.SuspendLayout();
            this.tabPageMenu.SuspendLayout();
            this.tlpPlaceCancelOrder.SuspendLayout();
            this.tabPageCheckout.SuspendLayout();
            this.pnlCommentTextBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabOrderSucceeded.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTick)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackButton)).BeginInit();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Black;
            this.picLogo.Image = global::RestaurantChapeau.Properties.Resources.hat;
            this.picLogo.Location = new System.Drawing.Point(994, 0);
            this.picLogo.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(188, 128);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // flwMenuTypes
            // 
            this.flwMenuTypes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.flwMenuTypes.Dock = System.Windows.Forms.DockStyle.Top;
            this.flwMenuTypes.Location = new System.Drawing.Point(4, 2);
            this.flwMenuTypes.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.flwMenuTypes.Name = "flwMenuTypes";
            this.flwMenuTypes.Size = new System.Drawing.Size(1155, 119);
            this.flwMenuTypes.TabIndex = 2;
            // 
            // flwMenuItems
            // 
            this.flwMenuItems.AutoScroll = true;
            this.flwMenuItems.BackColor = System.Drawing.Color.White;
            this.flwMenuItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flwMenuItems.Location = new System.Drawing.Point(4, 121);
            this.flwMenuItems.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.flwMenuItems.Name = "flwMenuItems";
            this.flwMenuItems.Size = new System.Drawing.Size(1155, 1238);
            this.flwMenuItems.TabIndex = 4;
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(179)))), ((int)(((byte)(215)))));
            this.btnPlaceOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlaceOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlaceOrder.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPlaceOrder.ForeColor = System.Drawing.Color.White;
            this.btnPlaceOrder.Location = new System.Drawing.Point(41, 19);
            this.btnPlaceOrder.Margin = new System.Windows.Forms.Padding(41, 19, 41, 19);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(1073, 101);
            this.btnPlaceOrder.TabIndex = 7;
            this.btnPlaceOrder.Text = "View Order";
            this.btnPlaceOrder.UseVisualStyleBackColor = false;
            this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);
            // 
            // theTabControl
            // 
            this.theTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.theTabControl.Controls.Add(this.tabConnecting);
            this.theTabControl.Controls.Add(this.tabPageMenu);
            this.theTabControl.Controls.Add(this.tabPageCheckout);
            this.theTabControl.Controls.Add(this.tabOrderSucceeded);
            this.theTabControl.Location = new System.Drawing.Point(0, 134);
            this.theTabControl.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.theTabControl.Name = "theTabControl";
            this.theTabControl.Padding = new System.Drawing.Point(18, 3);
            this.theTabControl.SelectedIndex = 0;
            this.theTabControl.Size = new System.Drawing.Size(1179, 1554);
            this.theTabControl.TabIndex = 9;
            // 
            // tabConnecting
            // 
            this.tabConnecting.Controls.Add(this.lblConnecting);
            this.tabConnecting.Location = new System.Drawing.Point(8, 46);
            this.tabConnecting.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabConnecting.Name = "tabConnecting";
            this.tabConnecting.Size = new System.Drawing.Size(1163, 1500);
            this.tabConnecting.TabIndex = 2;
            this.tabConnecting.Text = "tabConnecting";
            this.tabConnecting.UseVisualStyleBackColor = true;
            // 
            // lblConnecting
            // 
            this.lblConnecting.BackColor = System.Drawing.Color.White;
            this.lblConnecting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConnecting.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblConnecting.Location = new System.Drawing.Point(0, 0);
            this.lblConnecting.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConnecting.Name = "lblConnecting";
            this.lblConnecting.Size = new System.Drawing.Size(1163, 1500);
            this.lblConnecting.TabIndex = 0;
            this.lblConnecting.Text = "Getting menu...";
            this.lblConnecting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPageMenu
            // 
            this.tabPageMenu.Controls.Add(this.flwMenuItems);
            this.tabPageMenu.Controls.Add(this.tlpPlaceCancelOrder);
            this.tabPageMenu.Controls.Add(this.flwMenuTypes);
            this.tabPageMenu.Location = new System.Drawing.Point(8, 46);
            this.tabPageMenu.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabPageMenu.Name = "tabPageMenu";
            this.tabPageMenu.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabPageMenu.Size = new System.Drawing.Size(1163, 1500);
            this.tabPageMenu.TabIndex = 0;
            this.tabPageMenu.Text = "tabPageMenu";
            this.tabPageMenu.UseVisualStyleBackColor = true;
            // 
            // tlpPlaceCancelOrder
            // 
            this.tlpPlaceCancelOrder.BackColor = System.Drawing.Color.White;
            this.tlpPlaceCancelOrder.ColumnCount = 1;
            this.tlpPlaceCancelOrder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlaceCancelOrder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlaceCancelOrder.Controls.Add(this.btnPlaceOrder, 1, 0);
            this.tlpPlaceCancelOrder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpPlaceCancelOrder.Location = new System.Drawing.Point(4, 1359);
            this.tlpPlaceCancelOrder.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tlpPlaceCancelOrder.Name = "tlpPlaceCancelOrder";
            this.tlpPlaceCancelOrder.RowCount = 1;
            this.tlpPlaceCancelOrder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlaceCancelOrder.Size = new System.Drawing.Size(1155, 139);
            this.tlpPlaceCancelOrder.TabIndex = 10;
            // 
            // tabPageCheckout
            // 
            this.tabPageCheckout.BackColor = System.Drawing.Color.White;
            this.tabPageCheckout.Controls.Add(this.flwCheckout);
            this.tabPageCheckout.Controls.Add(this.lblComment);
            this.tabPageCheckout.Controls.Add(this.pnlCommentTextBox);
            this.tabPageCheckout.Controls.Add(this.tableLayoutPanel1);
            this.tabPageCheckout.Location = new System.Drawing.Point(8, 46);
            this.tabPageCheckout.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabPageCheckout.Name = "tabPageCheckout";
            this.tabPageCheckout.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabPageCheckout.Size = new System.Drawing.Size(1163, 1500);
            this.tabPageCheckout.TabIndex = 1;
            this.tabPageCheckout.Text = "tabPageCheckout";
            // 
            // flwCheckout
            // 
            this.flwCheckout.AutoScroll = true;
            this.flwCheckout.BackColor = System.Drawing.Color.White;
            this.flwCheckout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flwCheckout.Location = new System.Drawing.Point(4, 2);
            this.flwCheckout.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.flwCheckout.Name = "flwCheckout";
            this.flwCheckout.Size = new System.Drawing.Size(1155, 1111);
            this.flwCheckout.TabIndex = 11;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblComment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblComment.Location = new System.Drawing.Point(4, 1113);
            this.lblComment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(108, 45);
            this.lblComment.TabIndex = 11;
            this.lblComment.Text = "Notes";
            // 
            // pnlCommentTextBox
            // 
            this.pnlCommentTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(179)))), ((int)(((byte)(215)))));
            this.pnlCommentTextBox.Controls.Add(this.txtComment);
            this.pnlCommentTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCommentTextBox.Location = new System.Drawing.Point(4, 1158);
            this.pnlCommentTextBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pnlCommentTextBox.Name = "pnlCommentTextBox";
            this.pnlCommentTextBox.Padding = new System.Windows.Forms.Padding(4);
            this.pnlCommentTextBox.Size = new System.Drawing.Size(1155, 201);
            this.pnlCommentTextBox.TabIndex = 14;
            // 
            // txtComment
            // 
            this.txtComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtComment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtComment.Location = new System.Drawing.Point(4, 4);
            this.txtComment.Margin = new System.Windows.Forms.Padding(9, 11, 9, 11);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.PlaceholderText = "Insert comment or wishes here...";
            this.txtComment.Size = new System.Drawing.Size(1147, 193);
            this.txtComment.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnFinish, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 1359);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1155, 139);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(179)))), ((int)(((byte)(215)))));
            this.btnFinish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFinish.FlatAppearance.BorderSize = 0;
            this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinish.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFinish.ForeColor = System.Drawing.Color.White;
            this.btnFinish.Location = new System.Drawing.Point(41, 19);
            this.btnFinish.Margin = new System.Windows.Forms.Padding(41, 19, 41, 19);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(1073, 101);
            this.btnFinish.TabIndex = 7;
            this.btnFinish.Text = "Place Order";
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // tabOrderSucceeded
            // 
            this.tabOrderSucceeded.BackColor = System.Drawing.Color.White;
            this.tabOrderSucceeded.Controls.Add(this.lblOrderPlaced);
            this.tabOrderSucceeded.Controls.Add(this.picTick);
            this.tabOrderSucceeded.Location = new System.Drawing.Point(8, 46);
            this.tabOrderSucceeded.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabOrderSucceeded.Name = "tabOrderSucceeded";
            this.tabOrderSucceeded.Size = new System.Drawing.Size(1163, 1500);
            this.tabOrderSucceeded.TabIndex = 3;
            this.tabOrderSucceeded.Text = "tabOrderSucceeded";
            // 
            // lblOrderPlaced
            // 
            this.lblOrderPlaced.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOrderPlaced.Location = new System.Drawing.Point(-7, 800);
            this.lblOrderPlaced.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrderPlaced.Name = "lblOrderPlaced";
            this.lblOrderPlaced.Size = new System.Drawing.Size(1181, 68);
            this.lblOrderPlaced.TabIndex = 11;
            this.lblOrderPlaced.Text = "Order placed";
            this.lblOrderPlaced.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picTick
            // 
            this.picTick.Image = global::RestaurantChapeau.Properties.Resources.tick;
            this.picTick.Location = new System.Drawing.Point(355, 277);
            this.picTick.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.picTick.Name = "picTick";
            this.picTick.Size = new System.Drawing.Size(453, 453);
            this.picTick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTick.TabIndex = 0;
            this.picTick.TabStop = false;
            // 
            // lblQuantityCheckout
            // 
            this.lblQuantityCheckout.AutoSize = true;
            this.lblQuantityCheckout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblQuantityCheckout.Location = new System.Drawing.Point(780, 85);
            this.lblQuantityCheckout.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuantityCheckout.Name = "lblQuantityCheckout";
            this.lblQuantityCheckout.Size = new System.Drawing.Size(0, 45);
            this.lblQuantityCheckout.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picBackButton);
            this.panel1.Controls.Add(this.lblQuantityCheckout);
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Controls.Add(this.picLogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1180, 130);
            this.panel1.TabIndex = 11;
            // 
            // picBackButton
            // 
            this.picBackButton.BackColor = System.Drawing.Color.Transparent;
            this.picBackButton.Image = global::RestaurantChapeau.Properties.Resources.backbutton;
            this.picBackButton.Location = new System.Drawing.Point(11, 13);
            this.picBackButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.picBackButton.Name = "picBackButton";
            this.picBackButton.Size = new System.Drawing.Size(100, 100);
            this.picBackButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBackButton.TabIndex = 12;
            this.picBackButton.TabStop = false;
            this.picBackButton.Click += new System.EventHandler(this.picBackButton_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHeader.Location = new System.Drawing.Point(136, 0);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(860, 128);
            this.lblHeader.TabIndex = 11;
            this.lblHeader.Text = "Order";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.UseCompatibleTextRendering = true;
            // 
            // OrderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1180, 1559);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.theTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "OrderView";
            this.Text = "OrderView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrderView_FormClosing);
            this.Load += new System.EventHandler(this.OrderView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.theTabControl.ResumeLayout(false);
            this.tabConnecting.ResumeLayout(false);
            this.tabPageMenu.ResumeLayout(false);
            this.tlpPlaceCancelOrder.ResumeLayout(false);
            this.tabPageCheckout.ResumeLayout(false);
            this.tabPageCheckout.PerformLayout();
            this.pnlCommentTextBox.ResumeLayout(false);
            this.pnlCommentTextBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabOrderSucceeded.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTick)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.FlowLayoutPanel flwMenuTypes;
        private System.Windows.Forms.FlowLayoutPanel flwMenuItems;
        private System.Windows.Forms.Button btnPlaceOrder;
        private System.Windows.Forms.TabControl theTabControl;
        private System.Windows.Forms.TabPage tabPageMenu;
        private System.Windows.Forms.TabPage tabPageCheckout;
        private System.Windows.Forms.TableLayoutPanel tlpPlaceCancelOrder;
        private System.Windows.Forms.FlowLayoutPanel flwCheckout;
        private System.Windows.Forms.Label lblQuantityCheckout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TabPage tabConnecting;
        private System.Windows.Forms.Label lblConnecting;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.PictureBox picBackButton;
        private System.Windows.Forms.Panel pnlCommentTextBox;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.TabPage tabOrderSucceeded;
        private System.Windows.Forms.Label lblOrderPlaced;
        private System.Windows.Forms.PictureBox picTick;
    }
}