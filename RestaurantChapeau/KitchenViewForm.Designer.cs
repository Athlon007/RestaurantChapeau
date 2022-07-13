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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_Secs = new System.Windows.Forms.Label();
            this.lbl_Mins = new System.Windows.Forms.Label();
            this.lbl_Hours = new System.Windows.Forms.Label();
            this.btn_newOrders = new System.Windows.Forms.Button();
            this.lbl_CompletedOrders = new System.Windows.Forms.Label();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.btn_Ready = new System.Windows.Forms.Button();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.lbl_waitTime = new System.Windows.Forms.Label();
            this.btn_CompletedOrders = new System.Windows.Forms.Button();
            this.pnl_completeOrders = new System.Windows.Forms.Panel();
            this.listview_CompletedOrders = new System.Windows.Forms.ListView();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.pnl_newOrders = new System.Windows.Forms.Panel();
            this.listview_NewOrders = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_completeOrders.SuspendLayout();
            this.pnl_newOrders.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_Secs
            // 
            this.lbl_Secs.AutoSize = true;
            this.lbl_Secs.Location = new System.Drawing.Point(1108, 962);
            this.lbl_Secs.Name = "lbl_Secs";
            this.lbl_Secs.Size = new System.Drawing.Size(40, 32);
            this.lbl_Secs.TabIndex = 19;
            this.lbl_Secs.Text = "00";
            // 
            // lbl_Mins
            // 
            this.lbl_Mins.AutoSize = true;
            this.lbl_Mins.Location = new System.Drawing.Point(1072, 962);
            this.lbl_Mins.Name = "lbl_Mins";
            this.lbl_Mins.Size = new System.Drawing.Size(40, 32);
            this.lbl_Mins.TabIndex = 20;
            this.lbl_Mins.Text = "00";
            // 
            // lbl_Hours
            // 
            this.lbl_Hours.AutoSize = true;
            this.lbl_Hours.Location = new System.Drawing.Point(1037, 962);
            this.lbl_Hours.Name = "lbl_Hours";
            this.lbl_Hours.Size = new System.Drawing.Size(40, 32);
            this.lbl_Hours.TabIndex = 21;
            this.lbl_Hours.Text = "00";
            // 
            // btn_newOrders
            // 
            this.btn_newOrders.Location = new System.Drawing.Point(111, 951);
            this.btn_newOrders.Name = "btn_newOrders";
            this.btn_newOrders.Size = new System.Drawing.Size(279, 46);
            this.btn_newOrders.TabIndex = 16;
            this.btn_newOrders.Text = "New orders";
            this.btn_newOrders.UseVisualStyleBackColor = true;
            this.btn_newOrders.Click += new System.EventHandler(this.btn_newOrders_Click);
            // 
            // lbl_CompletedOrders
            // 
            this.lbl_CompletedOrders.AutoSize = true;
            this.lbl_CompletedOrders.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_CompletedOrders.Location = new System.Drawing.Point(739, 0);
            this.lbl_CompletedOrders.Name = "lbl_CompletedOrders";
            this.lbl_CompletedOrders.Size = new System.Drawing.Size(350, 54);
            this.lbl_CompletedOrders.TabIndex = 0;
            this.lbl_CompletedOrders.Text = "Completed Orders";
            // 
            // columnHeader16
            // 
            this.columnHeader16.DisplayIndex = 5;
            this.columnHeader16.Text = "Table";
            this.columnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader16.Width = 120;
            // 
            // columnHeader14
            // 
            this.columnHeader14.DisplayIndex = 7;
            this.columnHeader14.Text = "Status";
            this.columnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader14.Width = 275;
            // 
            // columnHeader12
            // 
            this.columnHeader12.DisplayIndex = 6;
            this.columnHeader12.Text = "Time";
            this.columnHeader12.Width = 200;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Comment";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader11.Width = 260;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Menu Type";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader10.Width = 210;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Quantity";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 200;
            // 
            // btn_Ready
            // 
            this.btn_Ready.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_Ready.Location = new System.Drawing.Point(1369, 948);
            this.btn_Ready.Name = "btn_Ready";
            this.btn_Ready.Size = new System.Drawing.Size(279, 46);
            this.btn_Ready.TabIndex = 14;
            this.btn_Ready.Text = "Ready";
            this.btn_Ready.UseVisualStyleBackColor = false;
            this.btn_Ready.Click += new System.EventHandler(this.btn_Ready_Click);
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Item Name";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 500;
            // 
            // lbl_waitTime
            // 
            this.lbl_waitTime.AutoSize = true;
            this.lbl_waitTime.Location = new System.Drawing.Point(905, 962);
            this.lbl_waitTime.Name = "lbl_waitTime";
            this.lbl_waitTime.Size = new System.Drawing.Size(126, 32);
            this.lbl_waitTime.TabIndex = 22;
            this.lbl_waitTime.Text = "Wait Time:";
            // 
            // btn_CompletedOrders
            // 
            this.btn_CompletedOrders.Location = new System.Drawing.Point(445, 951);
            this.btn_CompletedOrders.Name = "btn_CompletedOrders";
            this.btn_CompletedOrders.Size = new System.Drawing.Size(279, 46);
            this.btn_CompletedOrders.TabIndex = 15;
            this.btn_CompletedOrders.Text = "Completed orders";
            this.btn_CompletedOrders.UseVisualStyleBackColor = true;
            this.btn_CompletedOrders.Click += new System.EventHandler(this.btn_CompletedOrders_Click);
            // 
            // pnl_completeOrders
            // 
            this.pnl_completeOrders.Controls.Add(this.listview_CompletedOrders);
            this.pnl_completeOrders.Controls.Add(this.lbl_CompletedOrders);
            this.pnl_completeOrders.Location = new System.Drawing.Point(0, 0);
            this.pnl_completeOrders.Name = "pnl_completeOrders";
            this.pnl_completeOrders.Size = new System.Drawing.Size(1896, 945);
            this.pnl_completeOrders.TabIndex = 18;
            // 
            // listview_CompletedOrders
            // 
            this.listview_CompletedOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader14,
            this.columnHeader16,
            this.columnHeader12});
            this.listview_CompletedOrders.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listview_CompletedOrders.FullRowSelect = true;
            this.listview_CompletedOrders.HideSelection = false;
            this.listview_CompletedOrders.Location = new System.Drawing.Point(11, 49);
            this.listview_CompletedOrders.Name = "listview_CompletedOrders";
            this.listview_CompletedOrders.Size = new System.Drawing.Size(1870, 893);
            this.listview_CompletedOrders.TabIndex = 1;
            this.listview_CompletedOrders.UseCompatibleStateImageBehavior = false;
            this.listview_CompletedOrders.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Order no";
            this.columnHeader7.Width = 180;
            // 
            // pnl_newOrders
            // 
            this.pnl_newOrders.Controls.Add(this.listview_NewOrders);
            this.pnl_newOrders.Controls.Add(this.label1);
            this.pnl_newOrders.Location = new System.Drawing.Point(1, 0);
            this.pnl_newOrders.Name = "pnl_newOrders";
            this.pnl_newOrders.Size = new System.Drawing.Size(1896, 945);
            this.pnl_newOrders.TabIndex = 17;
            // 
            // listview_NewOrders
            // 
            this.listview_NewOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader15,
            this.columnHeader6,
            this.columnHeader13});
            this.listview_NewOrders.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listview_NewOrders.FullRowSelect = true;
            this.listview_NewOrders.HideSelection = false;
            this.listview_NewOrders.Location = new System.Drawing.Point(11, 49);
            this.listview_NewOrders.Name = "listview_NewOrders";
            this.listview_NewOrders.Size = new System.Drawing.Size(1870, 893);
            this.listview_NewOrders.TabIndex = 1;
            this.listview_NewOrders.UseCompatibleStateImageBehavior = false;
            this.listview_NewOrders.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Order no";
            this.columnHeader1.Width = 175;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Item Name";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 500;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Quantity";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Menu Type";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 210;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Comment";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 275;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Table ";
            this.columnHeader15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader15.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Time";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 180;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Status";
            this.columnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader13.Width = 275;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(739, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Orders";
            // 
            // KitchenViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1894, 1009);
            this.Controls.Add(this.lbl_Secs);
            this.Controls.Add(this.lbl_Mins);
            this.Controls.Add(this.lbl_Hours);
            this.Controls.Add(this.btn_newOrders);
            this.Controls.Add(this.btn_Ready);
            this.Controls.Add(this.lbl_waitTime);
            this.Controls.Add(this.btn_CompletedOrders);
            this.Controls.Add(this.pnl_completeOrders);
            this.Controls.Add(this.pnl_newOrders);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "KitchenViewForm";
            this.Text = "KitchenViewForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.KitchenViewForm_FormClosed);
            this.Load += new System.EventHandler(this.KitchenViewForm_Load);
            this.pnl_completeOrders.ResumeLayout(false);
            this.pnl_completeOrders.PerformLayout();
            this.pnl_newOrders.ResumeLayout(false);
            this.pnl_newOrders.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_Secs;
        private System.Windows.Forms.Label lbl_Mins;
        private System.Windows.Forms.Label lbl_Hours;
        private System.Windows.Forms.Button btn_newOrders;
        private System.Windows.Forms.Label lbl_CompletedOrders;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button btn_Ready;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Label lbl_waitTime;
        private System.Windows.Forms.Button btn_CompletedOrders;
        private System.Windows.Forms.Panel pnl_completeOrders;
        private System.Windows.Forms.ListView listview_CompletedOrders;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Panel pnl_newOrders;
        private System.Windows.Forms.ListView listview_NewOrders;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.Label label1;
    }
}