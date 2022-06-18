namespace RestaurantChapeau
{
    partial class TableViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableViewForm));
            this.pnl_Reservation = new System.Windows.Forms.Panel();
            this.reservationTableNumber = new System.Windows.Forms.NumericUpDown();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pbMakeReservationGoBack = new System.Windows.Forms.PictureBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lbl_ReservationIsReserved = new System.Windows.Forms.Label();
            this.lbl_ReservationTableid = new System.Windows.Forms.Label();
            this.lbl_ReservationEmail = new System.Windows.Forms.Label();
            this.lbl_ReservationLastName = new System.Windows.Forms.Label();
            this.lbl_ReservationFirstName = new System.Windows.Forms.Label();
            this.txt_ReservationFirstName = new System.Windows.Forms.TextBox();
            this.txt_ReservationLastName = new System.Windows.Forms.TextBox();
            this.txt_ReservationEmail = new System.Windows.Forms.TextBox();
            this.btn_MakeReservation = new System.Windows.Forms.Button();
            this.pnl_ViewReservation = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pb_TableAgenda = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_ViewReservationCancel = new System.Windows.Forms.Button();
            this.btn_ViewReservationMake = new System.Windows.Forms.Button();
            this.lV_ReservationDisplay = new System.Windows.Forms.ListView();
            this.pbTableInfo = new System.Windows.Forms.PictureBox();
            this.pnl_TableDetailView = new System.Windows.Forms.Panel();
            this.btn_Occupy = new System.Windows.Forms.Button();
            this.btn_TableDetailViewChangeStatus = new System.Windows.Forms.Button();
            this.btn_TableDetailViewCheckOut = new System.Windows.Forms.Button();
            this.btn_TableDetailViewAddOrder = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lbl_DisplayTableNr = new System.Windows.Forms.Label();
            this.lv_TableDetailView = new System.Windows.Forms.ListView();
            this.pbTableDetailViewGoBack = new System.Windows.Forms.PictureBox();
            this.btn_TableViewManageReservation = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btn_LogOut = new System.Windows.Forms.Button();
            this.pb_drink10 = new System.Windows.Forms.PictureBox();
            this.pb_Food9 = new System.Windows.Forms.PictureBox();
            this.pnl_Reservation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reservationTableNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMakeReservationGoBack)).BeginInit();
            this.pnl_ViewReservation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_TableAgenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTableInfo)).BeginInit();
            this.pnl_TableDetailView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTableDetailViewGoBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_drink10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Food9)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_Reservation
            // 
            this.pnl_Reservation.Controls.Add(this.reservationTableNumber);
            this.pnl_Reservation.Controls.Add(this.picLogo);
            this.pnl_Reservation.Controls.Add(this.lblHeader);
            this.pnl_Reservation.Controls.Add(this.pbMakeReservationGoBack);
            this.pnl_Reservation.Controls.Add(this.dateTimePicker1);
            this.pnl_Reservation.Controls.Add(this.lbl_ReservationIsReserved);
            this.pnl_Reservation.Controls.Add(this.lbl_ReservationTableid);
            this.pnl_Reservation.Controls.Add(this.lbl_ReservationEmail);
            this.pnl_Reservation.Controls.Add(this.lbl_ReservationLastName);
            this.pnl_Reservation.Controls.Add(this.lbl_ReservationFirstName);
            this.pnl_Reservation.Controls.Add(this.txt_ReservationFirstName);
            this.pnl_Reservation.Controls.Add(this.txt_ReservationLastName);
            this.pnl_Reservation.Controls.Add(this.txt_ReservationEmail);
            this.pnl_Reservation.Controls.Add(this.btn_MakeReservation);
            this.pnl_Reservation.Location = new System.Drawing.Point(0, 0);
            this.pnl_Reservation.Name = "pnl_Reservation";
            this.pnl_Reservation.Size = new System.Drawing.Size(726, 1055);
            this.pnl_Reservation.TabIndex = 32;
            // 
            // reservationTableNumber
            // 
            this.reservationTableNumber.Location = new System.Drawing.Point(144, 593);
            this.reservationTableNumber.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.reservationTableNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.reservationTableNumber.Name = "reservationTableNumber";
            this.reservationTableNumber.Size = new System.Drawing.Size(227, 27);
            this.reservationTableNumber.TabIndex = 50;
            this.reservationTableNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Black;
            this.picLogo.Image = global::RestaurantChapeau.Properties.Resources.hat;
            this.picLogo.Location = new System.Drawing.Point(612, 0);
            this.picLogo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(116, 80);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 49;
            this.picLogo.TabStop = false;
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHeader.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblHeader.Location = new System.Drawing.Point(84, 0);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(529, 80);
            this.lblHeader.TabIndex = 48;
            this.lblHeader.Text = "Reservation";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.UseCompatibleTextRendering = true;
            // 
            // pbMakeReservationGoBack
            // 
            this.pbMakeReservationGoBack.BackColor = System.Drawing.Color.Transparent;
            this.pbMakeReservationGoBack.Image = global::RestaurantChapeau.Properties.Resources.backbutton;
            this.pbMakeReservationGoBack.Location = new System.Drawing.Point(7, 8);
            this.pbMakeReservationGoBack.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pbMakeReservationGoBack.Name = "pbMakeReservationGoBack";
            this.pbMakeReservationGoBack.Size = new System.Drawing.Size(62, 62);
            this.pbMakeReservationGoBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMakeReservationGoBack.TabIndex = 47;
            this.pbMakeReservationGoBack.TabStop = false;
            this.pbMakeReservationGoBack.Click += new System.EventHandler(this.picBackButton_Click_1);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "ddMMMM yyyy | HH:mm";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(145, 502);
            this.dateTimePicker1.MaxDate = new System.DateTime(2022, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2022, 5, 25, 23, 59, 59, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(224, 27);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.Value = new System.DateTime(2022, 5, 25, 23, 59, 59, 0);
            // 
            // lbl_ReservationIsReserved
            // 
            this.lbl_ReservationIsReserved.AutoSize = true;
            this.lbl_ReservationIsReserved.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_ReservationIsReserved.Location = new System.Drawing.Point(145, 479);
            this.lbl_ReservationIsReserved.Name = "lbl_ReservationIsReserved";
            this.lbl_ReservationIsReserved.Size = new System.Drawing.Size(123, 20);
            this.lbl_ReservationIsReserved.TabIndex = 42;
            this.lbl_ReservationIsReserved.Text = "Reservation Time";
            // 
            // lbl_ReservationTableid
            // 
            this.lbl_ReservationTableid.AutoSize = true;
            this.lbl_ReservationTableid.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_ReservationTableid.Location = new System.Drawing.Point(145, 554);
            this.lbl_ReservationTableid.Name = "lbl_ReservationTableid";
            this.lbl_ReservationTableid.Size = new System.Drawing.Size(99, 20);
            this.lbl_ReservationTableid.TabIndex = 41;
            this.lbl_ReservationTableid.Text = "Table number";
            // 
            // lbl_ReservationEmail
            // 
            this.lbl_ReservationEmail.AutoSize = true;
            this.lbl_ReservationEmail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_ReservationEmail.Location = new System.Drawing.Point(145, 356);
            this.lbl_ReservationEmail.Name = "lbl_ReservationEmail";
            this.lbl_ReservationEmail.Size = new System.Drawing.Size(46, 20);
            this.lbl_ReservationEmail.TabIndex = 40;
            this.lbl_ReservationEmail.Text = "Email";
            // 
            // lbl_ReservationLastName
            // 
            this.lbl_ReservationLastName.AutoSize = true;
            this.lbl_ReservationLastName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_ReservationLastName.Location = new System.Drawing.Point(144, 216);
            this.lbl_ReservationLastName.Name = "lbl_ReservationLastName";
            this.lbl_ReservationLastName.Size = new System.Drawing.Size(76, 20);
            this.lbl_ReservationLastName.TabIndex = 39;
            this.lbl_ReservationLastName.Text = "Last name";
            // 
            // lbl_ReservationFirstName
            // 
            this.lbl_ReservationFirstName.AutoSize = true;
            this.lbl_ReservationFirstName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_ReservationFirstName.Location = new System.Drawing.Point(144, 80);
            this.lbl_ReservationFirstName.Name = "lbl_ReservationFirstName";
            this.lbl_ReservationFirstName.Size = new System.Drawing.Size(77, 20);
            this.lbl_ReservationFirstName.TabIndex = 38;
            this.lbl_ReservationFirstName.Text = "First name";
            // 
            // txt_ReservationFirstName
            // 
            this.txt_ReservationFirstName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_ReservationFirstName.Location = new System.Drawing.Point(145, 111);
            this.txt_ReservationFirstName.Multiline = true;
            this.txt_ReservationFirstName.Name = "txt_ReservationFirstName";
            this.txt_ReservationFirstName.Size = new System.Drawing.Size(452, 58);
            this.txt_ReservationFirstName.TabIndex = 0;
            // 
            // txt_ReservationLastName
            // 
            this.txt_ReservationLastName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_ReservationLastName.Location = new System.Drawing.Point(145, 248);
            this.txt_ReservationLastName.Multiline = true;
            this.txt_ReservationLastName.Name = "txt_ReservationLastName";
            this.txt_ReservationLastName.Size = new System.Drawing.Size(452, 58);
            this.txt_ReservationLastName.TabIndex = 1;
            // 
            // txt_ReservationEmail
            // 
            this.txt_ReservationEmail.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_ReservationEmail.Location = new System.Drawing.Point(145, 389);
            this.txt_ReservationEmail.Multiline = true;
            this.txt_ReservationEmail.Name = "txt_ReservationEmail";
            this.txt_ReservationEmail.Size = new System.Drawing.Size(452, 58);
            this.txt_ReservationEmail.TabIndex = 2;
            // 
            // btn_MakeReservation
            // 
            this.btn_MakeReservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(179)))), ((int)(((byte)(215)))));
            this.btn_MakeReservation.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_MakeReservation.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_MakeReservation.Location = new System.Drawing.Point(145, 731);
            this.btn_MakeReservation.Name = "btn_MakeReservation";
            this.btn_MakeReservation.Size = new System.Drawing.Size(452, 58);
            this.btn_MakeReservation.TabIndex = 5;
            this.btn_MakeReservation.Text = "Make Reservation";
            this.btn_MakeReservation.UseVisualStyleBackColor = false;
            this.btn_MakeReservation.Click += new System.EventHandler(this.btn_MakeReservation_Click);
            // 
            // pnl_ViewReservation
            // 
            this.pnl_ViewReservation.Controls.Add(this.pictureBox2);
            this.pnl_ViewReservation.Controls.Add(this.label1);
            this.pnl_ViewReservation.Controls.Add(this.pictureBox1);
            this.pnl_ViewReservation.Controls.Add(this.btn_ViewReservationCancel);
            this.pnl_ViewReservation.Controls.Add(this.btn_ViewReservationMake);
            this.pnl_ViewReservation.Controls.Add(this.lV_ReservationDisplay);
            this.pnl_ViewReservation.Location = new System.Drawing.Point(0, 0);
            this.pnl_ViewReservation.Name = "pnl_ViewReservation";
            this.pnl_ViewReservation.Size = new System.Drawing.Size(726, 1055);
            this.pnl_ViewReservation.TabIndex = 33;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Image = global::RestaurantChapeau.Properties.Resources.hat;
            this.pictureBox2.Location = new System.Drawing.Point(612, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(116, 80);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 50;
            this.pictureBox2.TabStop = false;
            // 
            // pb_TableAgenda
            // 
            this.pb_TableAgenda.Image = ((System.Drawing.Image)(resources.GetObject("pb_TableAgenda.Image")));
            this.pb_TableAgenda.Location = new System.Drawing.Point(97, 86);
            this.pb_TableAgenda.Name = "pb_TableAgenda";
            this.pb_TableAgenda.Size = new System.Drawing.Size(215, 150);
            this.pb_TableAgenda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_TableAgenda.TabIndex = 63;
            this.pb_TableAgenda.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(84, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(529, 80);
            this.label1.TabIndex = 49;
            this.label1.Text = "Reservation";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::RestaurantChapeau.Properties.Resources.backbutton;
            this.pictureBox1.Location = new System.Drawing.Point(7, 8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(62, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 48;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btn_ViewReservationCancel
            // 
            this.btn_ViewReservationCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(179)))), ((int)(((byte)(215)))));
            this.btn_ViewReservationCancel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_ViewReservationCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_ViewReservationCancel.Location = new System.Drawing.Point(145, 853);
            this.btn_ViewReservationCancel.Name = "btn_ViewReservationCancel";
            this.btn_ViewReservationCancel.Size = new System.Drawing.Size(452, 58);
            this.btn_ViewReservationCancel.TabIndex = 35;
            this.btn_ViewReservationCancel.Text = "Cancel reservation";
            this.btn_ViewReservationCancel.UseVisualStyleBackColor = false;
            this.btn_ViewReservationCancel.Click += new System.EventHandler(this.btn_ViewReservationCancel_Click);
            // 
            // btn_ViewReservationMake
            // 
            this.btn_ViewReservationMake.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(179)))), ((int)(((byte)(215)))));
            this.btn_ViewReservationMake.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_ViewReservationMake.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_ViewReservationMake.Location = new System.Drawing.Point(145, 731);
            this.btn_ViewReservationMake.Name = "btn_ViewReservationMake";
            this.btn_ViewReservationMake.Size = new System.Drawing.Size(452, 58);
            this.btn_ViewReservationMake.TabIndex = 34;
            this.btn_ViewReservationMake.Text = "Make reservation";
            this.btn_ViewReservationMake.UseVisualStyleBackColor = false;
            this.btn_ViewReservationMake.Click += new System.EventHandler(this.btn_ViewReservationMake_Click);
            // 
            // lV_ReservationDisplay
            // 
            this.lV_ReservationDisplay.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lV_ReservationDisplay.FullRowSelect = true;
            this.lV_ReservationDisplay.HideSelection = false;
            this.lV_ReservationDisplay.Location = new System.Drawing.Point(0, 90);
            this.lV_ReservationDisplay.Name = "lV_ReservationDisplay";
            this.lV_ReservationDisplay.Size = new System.Drawing.Size(723, 439);
            this.lV_ReservationDisplay.TabIndex = 0;
            this.lV_ReservationDisplay.UseCompatibleStateImageBehavior = false;
            // 
            // pbTableInfo
            // 
            this.pbTableInfo.Image = global::RestaurantChapeau.Properties.Resources.agendaTable221;
            this.pbTableInfo.Location = new System.Drawing.Point(357, 90);
            this.pbTableInfo.Name = "pbTableInfo";
            this.pbTableInfo.Size = new System.Drawing.Size(327, 152);
            this.pbTableInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTableInfo.TabIndex = 89;
            this.pbTableInfo.TabStop = false;
            // 
            // pnl_TableDetailView
            // 
            this.pnl_TableDetailView.Controls.Add(this.btn_Occupy);
            this.pnl_TableDetailView.Controls.Add(this.btn_TableDetailViewChangeStatus);
            this.pnl_TableDetailView.Controls.Add(this.btn_TableDetailViewCheckOut);
            this.pnl_TableDetailView.Controls.Add(this.btn_TableDetailViewAddOrder);
            this.pnl_TableDetailView.Controls.Add(this.pictureBox3);
            this.pnl_TableDetailView.Controls.Add(this.lbl_DisplayTableNr);
            this.pnl_TableDetailView.Controls.Add(this.lv_TableDetailView);
            this.pnl_TableDetailView.Controls.Add(this.pbTableDetailViewGoBack);
            this.pnl_TableDetailView.Location = new System.Drawing.Point(0, 0);
            this.pnl_TableDetailView.Name = "pnl_TableDetailView";
            this.pnl_TableDetailView.Size = new System.Drawing.Size(726, 1055);
            this.pnl_TableDetailView.TabIndex = 51;
            // 
            // btn_Occupy
            // 
            this.btn_Occupy.Location = new System.Drawing.Point(412, 704);
            this.btn_Occupy.Name = "btn_Occupy";
            this.btn_Occupy.Size = new System.Drawing.Size(120, 29);
            this.btn_Occupy.TabIndex = 55;
            this.btn_Occupy.Text = "button1";
            this.btn_Occupy.UseVisualStyleBackColor = true;
            // 
            // btn_TableDetailViewChangeStatus
            // 
            this.btn_TableDetailViewChangeStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(179)))), ((int)(((byte)(215)))));
            this.btn_TableDetailViewChangeStatus.Location = new System.Drawing.Point(57, 703);
            this.btn_TableDetailViewChangeStatus.Name = "btn_TableDetailViewChangeStatus";
            this.btn_TableDetailViewChangeStatus.Size = new System.Drawing.Size(148, 29);
            this.btn_TableDetailViewChangeStatus.TabIndex = 54;
            this.btn_TableDetailViewChangeStatus.Text = "Mark as served";
            this.btn_TableDetailViewChangeStatus.UseVisualStyleBackColor = false;
            this.btn_TableDetailViewChangeStatus.Click += new System.EventHandler(this.btn_TableDetailViewChangeStatus_Click);
            // 
            // btn_TableDetailViewCheckOut
            // 
            this.btn_TableDetailViewCheckOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(179)))), ((int)(((byte)(215)))));
            this.btn_TableDetailViewCheckOut.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_TableDetailViewCheckOut.Location = new System.Drawing.Point(412, 886);
            this.btn_TableDetailViewCheckOut.Name = "btn_TableDetailViewCheckOut";
            this.btn_TableDetailViewCheckOut.Size = new System.Drawing.Size(255, 58);
            this.btn_TableDetailViewCheckOut.TabIndex = 53;
            this.btn_TableDetailViewCheckOut.Text = "Check out";
            this.btn_TableDetailViewCheckOut.UseVisualStyleBackColor = false;
            this.btn_TableDetailViewCheckOut.Click += new System.EventHandler(this.btn_TableDetailViewCheckOut_Click);
            // 
            // btn_TableDetailViewAddOrder
            // 
            this.btn_TableDetailViewAddOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(179)))), ((int)(((byte)(215)))));
            this.btn_TableDetailViewAddOrder.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_TableDetailViewAddOrder.Location = new System.Drawing.Point(57, 886);
            this.btn_TableDetailViewAddOrder.Name = "btn_TableDetailViewAddOrder";
            this.btn_TableDetailViewAddOrder.Size = new System.Drawing.Size(255, 58);
            this.btn_TableDetailViewAddOrder.TabIndex = 52;
            this.btn_TableDetailViewAddOrder.Text = "Add order(s)";
            this.btn_TableDetailViewAddOrder.UseVisualStyleBackColor = false;
            this.btn_TableDetailViewAddOrder.Click += new System.EventHandler(this.btn_TableDetailViewAddOrder_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Black;
            this.pictureBox3.Image = global::RestaurantChapeau.Properties.Resources.hat;
            this.pictureBox3.Location = new System.Drawing.Point(612, 0);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(116, 80);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 51;
            this.pictureBox3.TabStop = false;
            // 
            // lbl_DisplayTableNr
            // 
            this.lbl_DisplayTableNr.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_DisplayTableNr.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_DisplayTableNr.Location = new System.Drawing.Point(84, 0);
            this.lbl_DisplayTableNr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_DisplayTableNr.Name = "lbl_DisplayTableNr";
            this.lbl_DisplayTableNr.Size = new System.Drawing.Size(529, 80);
            this.lbl_DisplayTableNr.TabIndex = 50;
            this.lbl_DisplayTableNr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_DisplayTableNr.UseCompatibleTextRendering = true;
            // 
            // lv_TableDetailView
            // 
            this.lv_TableDetailView.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lv_TableDetailView.FullRowSelect = true;
            this.lv_TableDetailView.HideSelection = false;
            this.lv_TableDetailView.Location = new System.Drawing.Point(0, 92);
            this.lv_TableDetailView.Name = "lv_TableDetailView";
            this.lv_TableDetailView.Size = new System.Drawing.Size(726, 605);
            this.lv_TableDetailView.TabIndex = 49;
            this.lv_TableDetailView.UseCompatibleStateImageBehavior = false;
            // 
            // pbTableDetailViewGoBack
            // 
            this.pbTableDetailViewGoBack.BackColor = System.Drawing.Color.Transparent;
            this.pbTableDetailViewGoBack.Image = global::RestaurantChapeau.Properties.Resources.backbutton;
            this.pbTableDetailViewGoBack.Location = new System.Drawing.Point(7, 8);
            this.pbTableDetailViewGoBack.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pbTableDetailViewGoBack.Name = "pbTableDetailViewGoBack";
            this.pbTableDetailViewGoBack.Size = new System.Drawing.Size(62, 62);
            this.pbTableDetailViewGoBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTableDetailViewGoBack.TabIndex = 48;
            this.pbTableDetailViewGoBack.TabStop = false;
            this.pbTableDetailViewGoBack.Click += new System.EventHandler(this.pbTableDetailViewGoBack_Click);
            // 
            // btn_TableViewManageReservation
            // 
            this.btn_TableViewManageReservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(179)))), ((int)(((byte)(215)))));
            this.btn_TableViewManageReservation.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_TableViewManageReservation.Location = new System.Drawing.Point(145, 958);
            this.btn_TableViewManageReservation.Name = "btn_TableViewManageReservation";
            this.btn_TableViewManageReservation.Size = new System.Drawing.Size(452, 58);
            this.btn_TableViewManageReservation.TabIndex = 33;
            this.btn_TableViewManageReservation.Text = "Manage reservation";
            this.btn_TableViewManageReservation.UseVisualStyleBackColor = false;
            this.btn_TableViewManageReservation.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(84, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(529, 80);
            this.label2.TabIndex = 50;
            this.label2.Text = "Table view";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.UseCompatibleTextRendering = true;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Black;
            this.pictureBox4.Image = global::RestaurantChapeau.Properties.Resources.hat;
            this.pictureBox4.Location = new System.Drawing.Point(612, 0);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(116, 80);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 51;
            this.pictureBox4.TabStop = false;
            // 
            // btn_LogOut
            // 
            this.btn_LogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(179)))), ((int)(((byte)(215)))));
            this.btn_LogOut.Location = new System.Drawing.Point(9, 12);
            this.btn_LogOut.Name = "btn_LogOut";
            this.btn_LogOut.Size = new System.Drawing.Size(70, 68);
            this.btn_LogOut.TabIndex = 52;
            this.btn_LogOut.Text = "Log out";
            this.btn_LogOut.UseVisualStyleBackColor = false;
            this.btn_LogOut.Click += new System.EventHandler(this.btn_LogOut_Click);
            // 
            // pb_drink10
            // 
            this.pb_drink10.Image = ((System.Drawing.Image)(resources.GetObject("pb_drink10.Image")));
            this.pb_drink10.InitialImage = ((System.Drawing.Image)(resources.GetObject("pb_drink10.InitialImage")));
            this.pb_drink10.Location = new System.Drawing.Point(632, 970);
            this.pb_drink10.Name = "pb_drink10";
            this.pb_drink10.Size = new System.Drawing.Size(52, 51);
            this.pb_drink10.TabIndex = 79;
            this.pb_drink10.TabStop = false;
            // 
            // pb_Food9
            // 
            this.pb_Food9.Image = global::RestaurantChapeau.Properties.Resources.food4;
            this.pb_Food9.Location = new System.Drawing.Point(62, 992);
            this.pb_Food9.Name = "pb_Food9";
            this.pb_Food9.Size = new System.Drawing.Size(52, 51);
            this.pb_Food9.TabIndex = 88;
            this.pb_Food9.TabStop = false;
            // 
            // TableViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(726, 1055);
            this.Controls.Add(this.pb_TableAgenda);
            this.Controls.Add(this.pbTableInfo);
            this.Controls.Add(this.pnl_ViewReservation);
            this.Controls.Add(this.pnl_Reservation);
            this.Controls.Add(this.pb_Food9);
            this.Controls.Add(this.pb_drink10);
            this.Controls.Add(this.pnl_TableDetailView);
            this.Controls.Add(this.btn_LogOut);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_TableViewManageReservation);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "TableViewForm";
            this.Text = "TableViewForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TableViewForm_FormClosed);
            this.Load += new System.EventHandler(this.TableViewForm_Load);
            this.pnl_Reservation.ResumeLayout(false);
            this.pnl_Reservation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reservationTableNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMakeReservationGoBack)).EndInit();
            this.pnl_ViewReservation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_TableAgenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTableInfo)).EndInit();
            this.pnl_TableDetailView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTableDetailViewGoBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_drink10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Food9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnl_Reservation;
        private System.Windows.Forms.Button btn_MakeReservation;
        private System.Windows.Forms.TextBox txt_ReservationFirstName;
        private System.Windows.Forms.TextBox txt_ReservationLastName;
        private System.Windows.Forms.TextBox txt_ReservationEmail;
        private System.Windows.Forms.Label lbl_ReservationIsReserved;
        private System.Windows.Forms.Label lbl_ReservationTableid;
        private System.Windows.Forms.Label lbl_ReservationEmail;
        private System.Windows.Forms.Label lbl_ReservationLastName;
        private System.Windows.Forms.Label lbl_ReservationFirstName;
        private System.Windows.Forms.Panel pnl_ViewReservation;
        private System.Windows.Forms.ListView lV_ReservationDisplay;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btn_TableViewManageReservation;
        private System.Windows.Forms.Button btn_ViewReservationMake;
        private System.Windows.Forms.Button btn_ViewReservationCancel;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbMakeReservationGoBack;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnl_TableDetailView;
        private System.Windows.Forms.PictureBox pbTableDetailViewGoBack;
        private System.Windows.Forms.ListView lv_TableDetailView;
        private System.Windows.Forms.Label lbl_DisplayTableNr;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btn_TableDetailViewCheckOut;
        private System.Windows.Forms.Button btn_TableDetailViewAddOrder;
        private System.Windows.Forms.Button btn_TableDetailViewChangeStatus;
        private System.Windows.Forms.Button btn_LogOut;
        private System.Windows.Forms.PictureBox pb_TableAgenda;
        private System.Windows.Forms.Button btn_Occupy;
        private System.Windows.Forms.PictureBox pb_drink10;
        private System.Windows.Forms.PictureBox pb_Food9;
        private System.Windows.Forms.NumericUpDown reservationTableNumber;
        private System.Windows.Forms.PictureBox pbTableInfo;
    }
}