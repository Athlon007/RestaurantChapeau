namespace RestaurantChapeau
{
    partial class KitchenViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KitchenViewForm));
            this.pnlKitchen_NewOrders = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.listViewNewOrders = new System.Windows.Forms.ListView();
            this.colHeadOrders = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTime = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTable = new System.Windows.Forms.ColumnHeader();
            this.lbl_newOrders = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlKitchen_CompleteOrders = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lbl_completedOrders = new System.Windows.Forms.Label();
            this.listViewKitchen_CompleteOrders = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.btn_readyOrder = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnKitchen_newOrders = new System.Windows.Forms.Button();
            this.btnKitchen_ActiveOrder = new System.Windows.Forms.Button();
            this.btnKitchen_CompleteOrders = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.sidebarPanelCompleteOrder = new System.Windows.Forms.Panel();
            this.pnlKitchen_ActiveOrder = new System.Windows.Forms.Panel();
            this.btn_preparingOrder = new System.Windows.Forms.Button();
            this.lblSecs = new System.Windows.Forms.Label();
            this.lblHours = new System.Windows.Forms.Label();
            this.lblMins = new System.Windows.Forms.Label();
            this.lbl_OrderComments = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblKitchenn_OrderNo = new System.Windows.Forms.Label();
            this.lblKitchen_OrderTime = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbl_tableNo = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.listViewKitchen_ActiveOrder = new System.Windows.Forms.ListView();
            this.Order_item = new System.Windows.Forms.ColumnHeader();
            this.Quantity = new System.Windows.Forms.ColumnHeader();
            this.colMenuItemStatus = new System.Windows.Forms.ColumnHeader();
            this.lbl_activeOrder = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlKitchen_NewOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlKitchen_CompleteOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.sidebarPanelCompleteOrder.SuspendLayout();
            this.pnlKitchen_ActiveOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlKitchen_NewOrders
            // 
            this.pnlKitchen_NewOrders.Controls.Add(this.pictureBox2);
            this.pnlKitchen_NewOrders.Controls.Add(this.listViewNewOrders);
            this.pnlKitchen_NewOrders.Controls.Add(this.lbl_newOrders);
            this.pnlKitchen_NewOrders.Controls.Add(this.label4);
            this.pnlKitchen_NewOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKitchen_NewOrders.Location = new System.Drawing.Point(0, 0);
            this.pnlKitchen_NewOrders.Name = "pnlKitchen_NewOrders";
            this.pnlKitchen_NewOrders.Size = new System.Drawing.Size(1874, 1157);
            this.pnlKitchen_NewOrders.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Image = global::RestaurantChapeau.Properties.Resources.hat;
            this.pictureBox2.Location = new System.Drawing.Point(1657, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(187, 127);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // listViewNewOrders
            // 
            this.listViewNewOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeadOrders,
            this.columnHeaderTime,
            this.columnHeaderTable});
            this.listViewNewOrders.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listViewNewOrders.FullRowSelect = true;
            this.listViewNewOrders.HideSelection = false;
            this.listViewNewOrders.HoverSelection = true;
            this.listViewNewOrders.Location = new System.Drawing.Point(323, 174);
            this.listViewNewOrders.Name = "listViewNewOrders";
            this.listViewNewOrders.Size = new System.Drawing.Size(1440, 819);
            this.listViewNewOrders.TabIndex = 8;
            this.listViewNewOrders.UseCompatibleStateImageBehavior = false;
            this.listViewNewOrders.View = System.Windows.Forms.View.Details;
            this.listViewNewOrders.Click += new System.EventHandler(this.listViewNewOrders_Click);
            // 
            // colHeadOrders
            // 
            this.colHeadOrders.Text = "Orders";
            this.colHeadOrders.Width = 500;
            // 
            // columnHeaderTime
            // 
            this.columnHeaderTime.Text = "Time";
            this.columnHeaderTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderTime.Width = 500;
            // 
            // columnHeaderTable
            // 
            this.columnHeaderTable.Text = "Status";
            this.columnHeaderTable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderTable.Width = 500;
            // 
            // lbl_newOrders
            // 
            this.lbl_newOrders.AutoSize = true;
            this.lbl_newOrders.Font = new System.Drawing.Font("Segoe Script", 19.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lbl_newOrders.Location = new System.Drawing.Point(764, 66);
            this.lbl_newOrders.Name = "lbl_newOrders";
            this.lbl_newOrders.Size = new System.Drawing.Size(358, 87);
            this.lbl_newOrders.TabIndex = 7;
            this.lbl_newOrders.Text = "New Orders";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(796, 101);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 32);
            this.label4.TabIndex = 6;
            // 
            // pnlKitchen_CompleteOrders
            // 
            this.pnlKitchen_CompleteOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlKitchen_CompleteOrders.Controls.Add(this.picLogo);
            this.pnlKitchen_CompleteOrders.Controls.Add(this.lbl_completedOrders);
            this.pnlKitchen_CompleteOrders.Controls.Add(this.listViewKitchen_CompleteOrders);
            this.pnlKitchen_CompleteOrders.Location = new System.Drawing.Point(30, 0);
            this.pnlKitchen_CompleteOrders.Name = "pnlKitchen_CompleteOrders";
            this.pnlKitchen_CompleteOrders.Size = new System.Drawing.Size(1844, 1157);
            this.pnlKitchen_CompleteOrders.TabIndex = 10;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Black;
            this.picLogo.Image = global::RestaurantChapeau.Properties.Resources.hat;
            this.picLogo.Location = new System.Drawing.Point(1657, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(187, 127);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 10;
            this.picLogo.TabStop = false;
            // 
            // lbl_completedOrders
            // 
            this.lbl_completedOrders.AutoSize = true;
            this.lbl_completedOrders.Font = new System.Drawing.Font("Segoe Script", 19.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lbl_completedOrders.Location = new System.Drawing.Point(816, 46);
            this.lbl_completedOrders.Name = "lbl_completedOrders";
            this.lbl_completedOrders.Size = new System.Drawing.Size(500, 87);
            this.lbl_completedOrders.TabIndex = 8;
            this.lbl_completedOrders.Text = "Complete Orders";
            // 
            // listViewKitchen_CompleteOrders
            // 
            this.listViewKitchen_CompleteOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewKitchen_CompleteOrders.BackColor = System.Drawing.Color.White;
            this.listViewKitchen_CompleteOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewKitchen_CompleteOrders.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listViewKitchen_CompleteOrders.FullRowSelect = true;
            this.listViewKitchen_CompleteOrders.HideSelection = false;
            this.listViewKitchen_CompleteOrders.Location = new System.Drawing.Point(310, 174);
            this.listViewKitchen_CompleteOrders.Name = "listViewKitchen_CompleteOrders";
            this.listViewKitchen_CompleteOrders.Size = new System.Drawing.Size(1440, 819);
            this.listViewKitchen_CompleteOrders.TabIndex = 8;
            this.listViewKitchen_CompleteOrders.UseCompatibleStateImageBehavior = false;
            this.listViewKitchen_CompleteOrders.View = System.Windows.Forms.View.Details;
            this.listViewKitchen_CompleteOrders.SelectedIndexChanged += new System.EventHandler(this.listViewKitchen_CompleteOrders_SelectedIndexChanged);
            this.listViewKitchen_CompleteOrders.Click += new System.EventHandler(this.listViewKitchen_CompleteOrders_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Orders";
            this.columnHeader1.Width = 450;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Time";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 500;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 500;
            // 
            // btn_readyOrder
            // 
            this.btn_readyOrder.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_readyOrder.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_readyOrder.ForeColor = System.Drawing.Color.Black;
            this.btn_readyOrder.Image = ((System.Drawing.Image)(resources.GetObject("btn_readyOrder.Image")));
            this.btn_readyOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_readyOrder.Location = new System.Drawing.Point(1217, 1017);
            this.btn_readyOrder.Name = "btn_readyOrder";
            this.btn_readyOrder.Size = new System.Drawing.Size(235, 64);
            this.btn_readyOrder.TabIndex = 9;
            this.btn_readyOrder.Text = "Ready";
            this.btn_readyOrder.UseVisualStyleBackColor = false;
            this.btn_readyOrder.Click += new System.EventHandler(this.btn_readyOrder_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label10.Location = new System.Drawing.Point(801, 104);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 32);
            this.label10.TabIndex = 6;
            // 
            // btnKitchen_newOrders
            // 
            this.btnKitchen_newOrders.BackColor = System.Drawing.Color.White;
            this.btnKitchen_newOrders.Image = ((System.Drawing.Image)(resources.GetObject("btnKitchen_newOrders.Image")));
            this.btnKitchen_newOrders.Location = new System.Drawing.Point(37, 171);
            this.btnKitchen_newOrders.Margin = new System.Windows.Forms.Padding(4);
            this.btnKitchen_newOrders.Name = "btnKitchen_newOrders";
            this.btnKitchen_newOrders.Size = new System.Drawing.Size(145, 141);
            this.btnKitchen_newOrders.TabIndex = 1;
            this.btnKitchen_newOrders.UseVisualStyleBackColor = false;
            this.btnKitchen_newOrders.Click += new System.EventHandler(this.btnKitchen_newOrders_Click);
            // 
            // btnKitchen_ActiveOrder
            // 
            this.btnKitchen_ActiveOrder.BackColor = System.Drawing.Color.White;
            this.btnKitchen_ActiveOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnKitchen_ActiveOrder.Image")));
            this.btnKitchen_ActiveOrder.Location = new System.Drawing.Point(37, 449);
            this.btnKitchen_ActiveOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btnKitchen_ActiveOrder.Name = "btnKitchen_ActiveOrder";
            this.btnKitchen_ActiveOrder.Size = new System.Drawing.Size(145, 141);
            this.btnKitchen_ActiveOrder.TabIndex = 1;
            this.btnKitchen_ActiveOrder.UseVisualStyleBackColor = false;
            this.btnKitchen_ActiveOrder.Click += new System.EventHandler(this.btnKitchen_ActiveOrder_Click);
            // 
            // btnKitchen_CompleteOrders
            // 
            this.btnKitchen_CompleteOrders.BackColor = System.Drawing.Color.White;
            this.btnKitchen_CompleteOrders.Image = ((System.Drawing.Image)(resources.GetObject("btnKitchen_CompleteOrders.Image")));
            this.btnKitchen_CompleteOrders.Location = new System.Drawing.Point(37, 732);
            this.btnKitchen_CompleteOrders.Margin = new System.Windows.Forms.Padding(4);
            this.btnKitchen_CompleteOrders.Name = "btnKitchen_CompleteOrders";
            this.btnKitchen_CompleteOrders.Size = new System.Drawing.Size(145, 141);
            this.btnKitchen_CompleteOrders.TabIndex = 1;
            this.btnKitchen_CompleteOrders.UseVisualStyleBackColor = false;
            this.btnKitchen_CompleteOrders.Click += new System.EventHandler(this.btnKitchen_CompleteOrders_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(25, 316);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(157, 37);
            this.label8.TabIndex = 2;
            this.label8.Text = "New Orders";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(29, 594);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 37);
            this.label7.TabIndex = 2;
            this.label7.Text = "Active Order";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(-7, 877);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(219, 37);
            this.label6.TabIndex = 2;
            this.label6.Text = "Complete Orders";
            // 
            // sidebarPanelCompleteOrder
            // 
            this.sidebarPanelCompleteOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sidebarPanelCompleteOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.sidebarPanelCompleteOrder.Controls.Add(this.label6);
            this.sidebarPanelCompleteOrder.Controls.Add(this.label7);
            this.sidebarPanelCompleteOrder.Controls.Add(this.label8);
            this.sidebarPanelCompleteOrder.Controls.Add(this.btnKitchen_CompleteOrders);
            this.sidebarPanelCompleteOrder.Controls.Add(this.btnKitchen_ActiveOrder);
            this.sidebarPanelCompleteOrder.Controls.Add(this.btnKitchen_newOrders);
            this.sidebarPanelCompleteOrder.Location = new System.Drawing.Point(5, 3);
            this.sidebarPanelCompleteOrder.Margin = new System.Windows.Forms.Padding(4);
            this.sidebarPanelCompleteOrder.Name = "sidebarPanelCompleteOrder";
            this.sidebarPanelCompleteOrder.Size = new System.Drawing.Size(208, 1157);
            this.sidebarPanelCompleteOrder.TabIndex = 5;
            // 
            // pnlKitchen_ActiveOrder
            // 
            this.pnlKitchen_ActiveOrder.Controls.Add(this.btn_preparingOrder);
            this.pnlKitchen_ActiveOrder.Controls.Add(this.lblSecs);
            this.pnlKitchen_ActiveOrder.Controls.Add(this.lblHours);
            this.pnlKitchen_ActiveOrder.Controls.Add(this.lblMins);
            this.pnlKitchen_ActiveOrder.Controls.Add(this.lbl_OrderComments);
            this.pnlKitchen_ActiveOrder.Controls.Add(this.label9);
            this.pnlKitchen_ActiveOrder.Controls.Add(this.pictureBox1);
            this.pnlKitchen_ActiveOrder.Controls.Add(this.btn_readyOrder);
            this.pnlKitchen_ActiveOrder.Controls.Add(this.lblKitchenn_OrderNo);
            this.pnlKitchen_ActiveOrder.Controls.Add(this.lblKitchen_OrderTime);
            this.pnlKitchen_ActiveOrder.Controls.Add(this.label14);
            this.pnlKitchen_ActiveOrder.Controls.Add(this.lbl_tableNo);
            this.pnlKitchen_ActiveOrder.Controls.Add(this.label13);
            this.pnlKitchen_ActiveOrder.Controls.Add(this.listViewKitchen_ActiveOrder);
            this.pnlKitchen_ActiveOrder.Controls.Add(this.lbl_activeOrder);
            this.pnlKitchen_ActiveOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pnlKitchen_ActiveOrder.Location = new System.Drawing.Point(215, 3);
            this.pnlKitchen_ActiveOrder.Name = "pnlKitchen_ActiveOrder";
            this.pnlKitchen_ActiveOrder.Size = new System.Drawing.Size(1629, 1154);
            this.pnlKitchen_ActiveOrder.TabIndex = 10;
            // 
            // btn_preparingOrder
            // 
            this.btn_preparingOrder.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_preparingOrder.Location = new System.Drawing.Point(1217, 932);
            this.btn_preparingOrder.Name = "btn_preparingOrder";
            this.btn_preparingOrder.Size = new System.Drawing.Size(235, 62);
            this.btn_preparingOrder.TabIndex = 3;
            this.btn_preparingOrder.Text = "Start Order";
            this.btn_preparingOrder.UseVisualStyleBackColor = true;
            this.btn_preparingOrder.Click += new System.EventHandler(this.btn_preparingOrder_Click);
            // 
            // lblSecs
            // 
            this.lblSecs.AutoSize = true;
            this.lblSecs.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSecs.Location = new System.Drawing.Point(1324, 83);
            this.lblSecs.Name = "lblSecs";
            this.lblSecs.Size = new System.Drawing.Size(88, 72);
            this.lblSecs.TabIndex = 13;
            this.lblSecs.Text = "00";
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHours.Location = new System.Drawing.Point(1253, 83);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(88, 72);
            this.lblHours.TabIndex = 13;
            this.lblHours.Text = "00";
            // 
            // lblMins
            // 
            this.lblMins.AutoSize = true;
            this.lblMins.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMins.Location = new System.Drawing.Point(1287, 83);
            this.lblMins.Name = "lblMins";
            this.lblMins.Size = new System.Drawing.Size(88, 72);
            this.lblMins.TabIndex = 13;
            this.lblMins.Text = "00";
            // 
            // lbl_OrderComments
            // 
            this.lbl_OrderComments.AutoSize = true;
            this.lbl_OrderComments.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_OrderComments.Location = new System.Drawing.Point(249, 951);
            this.lbl_OrderComments.Name = "lbl_OrderComments";
            this.lbl_OrderComments.Size = new System.Drawing.Size(0, 72);
            this.lbl_OrderComments.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(29, 969);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(234, 54);
            this.label9.TabIndex = 12;
            this.label9.Text = "Comments: ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Image = global::RestaurantChapeau.Properties.Resources.hat;
            this.pictureBox1.Location = new System.Drawing.Point(1442, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 127);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // lblKitchenn_OrderNo
            // 
            this.lblKitchenn_OrderNo.AutoSize = true;
            this.lblKitchenn_OrderNo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblKitchenn_OrderNo.Location = new System.Drawing.Point(692, 67);
            this.lblKitchenn_OrderNo.Name = "lblKitchenn_OrderNo";
            this.lblKitchenn_OrderNo.Size = new System.Drawing.Size(0, 72);
            this.lblKitchenn_OrderNo.TabIndex = 10;
            // 
            // lblKitchen_OrderTime
            // 
            this.lblKitchen_OrderTime.AutoSize = true;
            this.lblKitchen_OrderTime.Location = new System.Drawing.Point(1266, 121);
            this.lblKitchen_OrderTime.Name = "lblKitchen_OrderTime";
            this.lblKitchen_OrderTime.Size = new System.Drawing.Size(0, 45);
            this.lblKitchen_OrderTime.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(1087, 83);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(173, 72);
            this.label14.TabIndex = 10;
            this.label14.Text = "Time: ";
            // 
            // lbl_tableNo
            // 
            this.lbl_tableNo.AutoSize = true;
            this.lbl_tableNo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_tableNo.Location = new System.Drawing.Point(231, 83);
            this.lbl_tableNo.Name = "lbl_tableNo";
            this.lbl_tableNo.Size = new System.Drawing.Size(0, 72);
            this.lbl_tableNo.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(61, 78);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(164, 72);
            this.label13.TabIndex = 10;
            this.label13.Text = "Table:";
            // 
            // listViewKitchen_ActiveOrder
            // 
            this.listViewKitchen_ActiveOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Order_item,
            this.Quantity,
            this.colMenuItemStatus});
            this.listViewKitchen_ActiveOrder.Font = new System.Drawing.Font("Segoe UI", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listViewKitchen_ActiveOrder.FullRowSelect = true;
            this.listViewKitchen_ActiveOrder.GridLines = true;
            this.listViewKitchen_ActiveOrder.HideSelection = false;
            this.listViewKitchen_ActiveOrder.Location = new System.Drawing.Point(124, 174);
            this.listViewKitchen_ActiveOrder.Name = "listViewKitchen_ActiveOrder";
            this.listViewKitchen_ActiveOrder.Size = new System.Drawing.Size(1401, 743);
            this.listViewKitchen_ActiveOrder.TabIndex = 9;
            this.listViewKitchen_ActiveOrder.UseCompatibleStateImageBehavior = false;
            this.listViewKitchen_ActiveOrder.View = System.Windows.Forms.View.Details;
            // 
            // Order_item
            // 
            this.Order_item.Text = "Order Item";
            this.Order_item.Width = 600;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.Width = 300;
            // 
            // colMenuItemStatus
            // 
            this.colMenuItemStatus.Text = "Status";
            this.colMenuItemStatus.Width = 600;
            // 
            // lbl_activeOrder
            // 
            this.lbl_activeOrder.AutoSize = true;
            this.lbl_activeOrder.Font = new System.Drawing.Font("Segoe Script", 19.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lbl_activeOrder.Location = new System.Drawing.Point(539, 63);
            this.lbl_activeOrder.Name = "lbl_activeOrder";
            this.lbl_activeOrder.Size = new System.Drawing.Size(202, 87);
            this.lbl_activeOrder.TabIndex = 8;
            this.lbl_activeOrder.Text = "Order";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // KitchenViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1874, 1157);
            this.Controls.Add(this.sidebarPanelCompleteOrder);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pnlKitchen_ActiveOrder);
            this.Controls.Add(this.pnlKitchen_NewOrders);
            this.Controls.Add(this.pnlKitchen_CompleteOrders);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "KitchenViewForm";
            this.Text = "KitchenViewForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.KitchenViewForm_FormClosed);
            this.Load += new System.EventHandler(this.KitchenViewForm_Load);
            this.pnlKitchen_NewOrders.ResumeLayout(false);
            this.pnlKitchen_NewOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlKitchen_CompleteOrders.ResumeLayout(false);
            this.pnlKitchen_CompleteOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.sidebarPanelCompleteOrder.ResumeLayout(false);
            this.sidebarPanelCompleteOrder.PerformLayout();
            this.pnlKitchen_ActiveOrder.ResumeLayout(false);
            this.pnlKitchen_ActiveOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlKitchen_NewOrders;
        private System.Windows.Forms.Panel pnlKitchen_CompleteOrders;
        private System.Windows.Forms.Label lbl_completedOrders;
        private System.Windows.Forms.ListView listViewKitchen_CompleteOrders;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView listViewNewOrders;
        private System.Windows.Forms.ColumnHeader colHeadOrders;
        private System.Windows.Forms.ColumnHeader columnHeaderTime;
        private System.Windows.Forms.ColumnHeader columnHeaderTable;
        private System.Windows.Forms.Label lbl_newOrders;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_readyOrder;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnKitchen_newOrders;
        private System.Windows.Forms.Button btnKitchen_ActiveOrder;
        private System.Windows.Forms.Button btnKitchen_CompleteOrders;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel sidebarPanelCompleteOrder;
        private System.Windows.Forms.Panel pnlKitchen_ActiveOrder;
        private System.Windows.Forms.ListView listViewKitchen_ActiveOrder;
        private System.Windows.Forms.Label lbl_activeOrder;
        private System.Windows.Forms.Label lblKitchenn_OrderNo;
        private System.Windows.Forms.Label lblKitchen_OrderTime;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ColumnHeader Order_item;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_OrderComments;
        private System.Windows.Forms.Label lblSecs;
        private System.Windows.Forms.Label lblMins;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.Label lbl_tableNo;
        private System.Windows.Forms.ColumnHeader colMenuItemStatus;
        private System.Windows.Forms.Button btn_preparingOrder;
    }
}