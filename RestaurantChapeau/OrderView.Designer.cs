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
            this.lblName = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.theTabControl = new System.Windows.Forms.TabControl();
            this.tabConnecting = new System.Windows.Forms.TabPage();
            this.lblConnecting = new System.Windows.Forms.Label();
            this.tabPageMenu = new System.Windows.Forms.TabPage();
            this.pnlColumns = new System.Windows.Forms.Panel();
            this.tlpPlaceCancelOrder = new System.Windows.Forms.TableLayoutPanel();
            this.tabPageCheckout = new System.Windows.Forms.TabPage();
            this.flwCheckout = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlColumnsCheckout = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblQuantityCheckout = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.pnlCommentTextBox = new System.Windows.Forms.Panel();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.tabOrderSucceeded = new System.Windows.Forms.TabPage();
            this.lblOrderPlaced = new System.Windows.Forms.Label();
            this.picTick = new System.Windows.Forms.PictureBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picBackButton = new System.Windows.Forms.PictureBox();
            this.lblTopBarText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.theTabControl.SuspendLayout();
            this.tabConnecting.SuspendLayout();
            this.tabPageMenu.SuspendLayout();
            this.pnlColumns.SuspendLayout();
            this.tlpPlaceCancelOrder.SuspendLayout();
            this.tabPageCheckout.SuspendLayout();
            this.pnlColumnsCheckout.SuspendLayout();
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
            this.picLogo.Location = new System.Drawing.Point(535, 0);
            this.picLogo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(101, 60);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // flwMenuTypes
            // 
            this.flwMenuTypes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.flwMenuTypes.Dock = System.Windows.Forms.DockStyle.Top;
            this.flwMenuTypes.Location = new System.Drawing.Point(2, 1);
            this.flwMenuTypes.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.flwMenuTypes.Name = "flwMenuTypes";
            this.flwMenuTypes.Size = new System.Drawing.Size(623, 56);
            this.flwMenuTypes.TabIndex = 2;
            // 
            // flwMenuItems
            // 
            this.flwMenuItems.AutoScroll = true;
            this.flwMenuItems.BackColor = System.Drawing.Color.White;
            this.flwMenuItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flwMenuItems.Location = new System.Drawing.Point(2, 82);
            this.flwMenuItems.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.flwMenuItems.Name = "flwMenuItems";
            this.flwMenuItems.Size = new System.Drawing.Size(623, 533);
            this.flwMenuItems.TabIndex = 4;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(2, 2);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(56, 21);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name";
            // 
            // lblSub
            // 
            this.lblSub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSub.AutoSize = true;
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSub.Location = new System.Drawing.Point(420, 1);
            this.lblSub.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(77, 21);
            this.lblSub.TabIndex = 6;
            this.lblSub.Text = "Quantity";
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(179)))), ((int)(((byte)(215)))));
            this.btnPlaceOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlaceOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlaceOrder.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPlaceOrder.ForeColor = System.Drawing.Color.White;
            this.btnPlaceOrder.Location = new System.Drawing.Point(333, 9);
            this.btnPlaceOrder.Margin = new System.Windows.Forms.Padding(22, 9, 22, 9);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(268, 35);
            this.btnPlaceOrder.TabIndex = 7;
            this.btnPlaceOrder.Text = "View Order";
            this.btnPlaceOrder.UseVisualStyleBackColor = false;
            this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(179)))), ((int)(((byte)(215)))));
            this.btnCancel.FlatAppearance.BorderSize = 4;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(22, 9);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(22, 9, 22, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(267, 35);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // theTabControl
            // 
            this.theTabControl.Controls.Add(this.tabConnecting);
            this.theTabControl.Controls.Add(this.tabPageMenu);
            this.theTabControl.Controls.Add(this.tabPageCheckout);
            this.theTabControl.Controls.Add(this.tabOrderSucceeded);
            this.theTabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.theTabControl.Location = new System.Drawing.Point(0, 94);
            this.theTabControl.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.theTabControl.Name = "theTabControl";
            this.theTabControl.Padding = new System.Drawing.Point(18, 3);
            this.theTabControl.SelectedIndex = 0;
            this.theTabControl.Size = new System.Drawing.Size(635, 697);
            this.theTabControl.TabIndex = 9;
            // 
            // tabConnecting
            // 
            this.tabConnecting.Controls.Add(this.lblConnecting);
            this.tabConnecting.Location = new System.Drawing.Point(4, 24);
            this.tabConnecting.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tabConnecting.Name = "tabConnecting";
            this.tabConnecting.Size = new System.Drawing.Size(627, 669);
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
            this.lblConnecting.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConnecting.Name = "lblConnecting";
            this.lblConnecting.Size = new System.Drawing.Size(627, 669);
            this.lblConnecting.TabIndex = 0;
            this.lblConnecting.Text = "Getting menu...";
            this.lblConnecting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPageMenu
            // 
            this.tabPageMenu.Controls.Add(this.flwMenuItems);
            this.tabPageMenu.Controls.Add(this.pnlColumns);
            this.tabPageMenu.Controls.Add(this.tlpPlaceCancelOrder);
            this.tabPageMenu.Controls.Add(this.flwMenuTypes);
            this.tabPageMenu.Location = new System.Drawing.Point(4, 24);
            this.tabPageMenu.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tabPageMenu.Name = "tabPageMenu";
            this.tabPageMenu.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tabPageMenu.Size = new System.Drawing.Size(627, 669);
            this.tabPageMenu.TabIndex = 0;
            this.tabPageMenu.Text = "tabPageMenu";
            this.tabPageMenu.UseVisualStyleBackColor = true;
            // 
            // pnlColumns
            // 
            this.pnlColumns.BackColor = System.Drawing.Color.White;
            this.pnlColumns.Controls.Add(this.lblSub);
            this.pnlColumns.Controls.Add(this.lblName);
            this.pnlColumns.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlColumns.Location = new System.Drawing.Point(2, 57);
            this.pnlColumns.Margin = new System.Windows.Forms.Padding(0);
            this.pnlColumns.Name = "pnlColumns";
            this.pnlColumns.Size = new System.Drawing.Size(623, 25);
            this.pnlColumns.TabIndex = 10;
            // 
            // tlpPlaceCancelOrder
            // 
            this.tlpPlaceCancelOrder.BackColor = System.Drawing.Color.White;
            this.tlpPlaceCancelOrder.ColumnCount = 2;
            this.tlpPlaceCancelOrder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlaceCancelOrder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlaceCancelOrder.Controls.Add(this.btnCancel, 0, 0);
            this.tlpPlaceCancelOrder.Controls.Add(this.btnPlaceOrder, 1, 0);
            this.tlpPlaceCancelOrder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpPlaceCancelOrder.Location = new System.Drawing.Point(2, 615);
            this.tlpPlaceCancelOrder.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tlpPlaceCancelOrder.Name = "tlpPlaceCancelOrder";
            this.tlpPlaceCancelOrder.RowCount = 1;
            this.tlpPlaceCancelOrder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlaceCancelOrder.Size = new System.Drawing.Size(623, 53);
            this.tlpPlaceCancelOrder.TabIndex = 10;
            // 
            // tabPageCheckout
            // 
            this.tabPageCheckout.BackColor = System.Drawing.Color.White;
            this.tabPageCheckout.Controls.Add(this.flwCheckout);
            this.tabPageCheckout.Controls.Add(this.pnlColumnsCheckout);
            this.tabPageCheckout.Controls.Add(this.lblComment);
            this.tabPageCheckout.Controls.Add(this.pnlCommentTextBox);
            this.tabPageCheckout.Controls.Add(this.tableLayoutPanel1);
            this.tabPageCheckout.Location = new System.Drawing.Point(4, 24);
            this.tabPageCheckout.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tabPageCheckout.Name = "tabPageCheckout";
            this.tabPageCheckout.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tabPageCheckout.Size = new System.Drawing.Size(627, 669);
            this.tabPageCheckout.TabIndex = 1;
            this.tabPageCheckout.Text = "tabPageCheckout";
            // 
            // flwCheckout
            // 
            this.flwCheckout.AutoScroll = true;
            this.flwCheckout.BackColor = System.Drawing.Color.White;
            this.flwCheckout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flwCheckout.Location = new System.Drawing.Point(2, 26);
            this.flwCheckout.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.flwCheckout.Name = "flwCheckout";
            this.flwCheckout.Size = new System.Drawing.Size(623, 474);
            this.flwCheckout.TabIndex = 11;
            // 
            // pnlColumnsCheckout
            // 
            this.pnlColumnsCheckout.BackColor = System.Drawing.Color.White;
            this.pnlColumnsCheckout.Controls.Add(this.label1);
            this.pnlColumnsCheckout.Controls.Add(this.lblQuantityCheckout);
            this.pnlColumnsCheckout.Controls.Add(this.label2);
            this.pnlColumnsCheckout.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlColumnsCheckout.Location = new System.Drawing.Point(2, 1);
            this.pnlColumnsCheckout.Margin = new System.Windows.Forms.Padding(0);
            this.pnlColumnsCheckout.Name = "pnlColumnsCheckout";
            this.pnlColumnsCheckout.Size = new System.Drawing.Size(623, 25);
            this.pnlColumnsCheckout.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(58, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Name";
            // 
            // lblQuantityCheckout
            // 
            this.lblQuantityCheckout.AutoSize = true;
            this.lblQuantityCheckout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblQuantityCheckout.Location = new System.Drawing.Point(420, 1);
            this.lblQuantityCheckout.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuantityCheckout.Name = "lblQuantityCheckout";
            this.lblQuantityCheckout.Size = new System.Drawing.Size(77, 21);
            this.lblQuantityCheckout.TabIndex = 6;
            this.lblQuantityCheckout.Text = "Quantity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(2, 1);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "No";
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblComment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblComment.Location = new System.Drawing.Point(2, 500);
            this.lblComment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(92, 21);
            this.lblComment.TabIndex = 11;
            this.lblComment.Text = "Comments";
            // 
            // pnlCommentTextBox
            // 
            this.pnlCommentTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(179)))), ((int)(((byte)(215)))));
            this.pnlCommentTextBox.Controls.Add(this.txtComment);
            this.pnlCommentTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCommentTextBox.Location = new System.Drawing.Point(2, 521);
            this.pnlCommentTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnlCommentTextBox.Name = "pnlCommentTextBox";
            this.pnlCommentTextBox.Padding = new System.Windows.Forms.Padding(2);
            this.pnlCommentTextBox.Size = new System.Drawing.Size(623, 94);
            this.pnlCommentTextBox.TabIndex = 14;
            // 
            // txtComment
            // 
            this.txtComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtComment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtComment.Location = new System.Drawing.Point(2, 2);
            this.txtComment.Margin = new System.Windows.Forms.Padding(5);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.PlaceholderText = "Insert comment or wishes here...";
            this.txtComment.Size = new System.Drawing.Size(619, 90);
            this.txtComment.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnBack, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFinish, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 615);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(623, 53);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // btnBack
            // 
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(179)))), ((int)(((byte)(215)))));
            this.btnBack.FlatAppearance.BorderSize = 4;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBack.Location = new System.Drawing.Point(22, 9);
            this.btnBack.Margin = new System.Windows.Forms.Padding(22, 9, 22, 9);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(267, 35);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(179)))), ((int)(((byte)(215)))));
            this.btnFinish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFinish.FlatAppearance.BorderSize = 0;
            this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinish.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFinish.ForeColor = System.Drawing.Color.White;
            this.btnFinish.Location = new System.Drawing.Point(333, 9);
            this.btnFinish.Margin = new System.Windows.Forms.Padding(22, 9, 22, 9);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(268, 35);
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
            this.tabOrderSucceeded.Location = new System.Drawing.Point(4, 24);
            this.tabOrderSucceeded.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tabOrderSucceeded.Name = "tabOrderSucceeded";
            this.tabOrderSucceeded.Size = new System.Drawing.Size(627, 669);
            this.tabOrderSucceeded.TabIndex = 3;
            this.tabOrderSucceeded.Text = "tabOrderSucceeded";
            // 
            // lblOrderPlaced
            // 
            this.lblOrderPlaced.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOrderPlaced.Location = new System.Drawing.Point(-4, 375);
            this.lblOrderPlaced.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOrderPlaced.Name = "lblOrderPlaced";
            this.lblOrderPlaced.Size = new System.Drawing.Size(636, 32);
            this.lblOrderPlaced.TabIndex = 11;
            this.lblOrderPlaced.Text = "Order placed";
            this.lblOrderPlaced.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picTick
            // 
            this.picTick.Image = global::RestaurantChapeau.Properties.Resources.tick;
            this.picTick.Location = new System.Drawing.Point(191, 130);
            this.picTick.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.picTick.Name = "picTick";
            this.picTick.Size = new System.Drawing.Size(244, 244);
            this.picTick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTick.TabIndex = 0;
            this.picTick.TabStop = false;
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHeader.Location = new System.Drawing.Point(0, 61);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(635, 32);
            this.lblHeader.TabIndex = 10;
            this.lblHeader.Text = "Menu";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picBackButton);
            this.panel1.Controls.Add(this.lblTopBarText);
            this.panel1.Controls.Add(this.picLogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 61);
            this.panel1.TabIndex = 11;
            // 
            // picBackButton
            // 
            this.picBackButton.BackColor = System.Drawing.Color.Transparent;
            this.picBackButton.Image = global::RestaurantChapeau.Properties.Resources.backbutton;
            this.picBackButton.Location = new System.Drawing.Point(6, 6);
            this.picBackButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.picBackButton.Name = "picBackButton";
            this.picBackButton.Size = new System.Drawing.Size(54, 47);
            this.picBackButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBackButton.TabIndex = 12;
            this.picBackButton.TabStop = false;
            this.picBackButton.Click += new System.EventHandler(this.picBackButton_Click);
            // 
            // lblTopBarText
            // 
            this.lblTopBarText.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTopBarText.Location = new System.Drawing.Point(73, 0);
            this.lblTopBarText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTopBarText.Name = "lblTopBarText";
            this.lblTopBarText.Size = new System.Drawing.Size(463, 60);
            this.lblTopBarText.TabIndex = 11;
            this.lblTopBarText.Text = "Order View";
            this.lblTopBarText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTopBarText.UseCompatibleTextRendering = true;
            // 
            // OrderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(635, 791);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.theTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "OrderView";
            this.Text = "OrderView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrderView_FormClosing);
            this.Load += new System.EventHandler(this.OrderView_Load);
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
            this.pnlCommentTextBox.ResumeLayout(false);
            this.pnlCommentTextBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabOrderSucceeded.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTick)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBackButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.FlowLayoutPanel flwMenuTypes;
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
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TabPage tabConnecting;
        private System.Windows.Forms.Label lblConnecting;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTopBarText;
        private System.Windows.Forms.PictureBox picBackButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlCommentTextBox;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.TabPage tabOrderSucceeded;
        private System.Windows.Forms.Label lblOrderPlaced;
        private System.Windows.Forms.PictureBox picTick;
    }
}