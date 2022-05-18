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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KitchenViewForm));
            this.pnlKitchen_NewOrders = new System.Windows.Forms.Panel();
            this.pnlKitchen_CompleteOrders = new System.Windows.Forms.Panel();
            this.btnKitchen_ClearOrders = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.listViewKitchen_CompleteOrders = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_completeOrders = new System.Windows.Forms.Button();
            this.btn_ActiveOrders = new System.Windows.Forms.Button();
            this.btn_newOrders = new System.Windows.Forms.Button();
            this.listViewNewOrders = new System.Windows.Forms.ListView();
            this.colHeadOrders = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTime = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTable = new System.Windows.Forms.ColumnHeader();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_readyOrder = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.btnKitchen_newOrders = new System.Windows.Forms.Button();
            this.btnKitchen_ActiveOrder = new System.Windows.Forms.Button();
            this.btnKitchen_CompleteOrders = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.sidebarPanelCompleteOrder = new System.Windows.Forms.Panel();
            this.pnlKitchen_ActiveOrder = new System.Windows.Forms.Panel();
            this.pnlKitchen_NewOrders.SuspendLayout();
            this.pnlKitchen_CompleteOrders.SuspendLayout();
            this.panel1.SuspendLayout();
            this.sidebarPanelCompleteOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlKitchen_NewOrders
            // 
            this.pnlKitchen_NewOrders.Controls.Add(this.panel1);
            this.pnlKitchen_NewOrders.Controls.Add(this.listViewNewOrders);
            this.pnlKitchen_NewOrders.Controls.Add(this.label5);
            this.pnlKitchen_NewOrders.Controls.Add(this.label4);
            this.pnlKitchen_NewOrders.Controls.Add(this.btn_readyOrder);
            this.pnlKitchen_NewOrders.Controls.Add(this.pnlKitchen_CompleteOrders);
            this.pnlKitchen_NewOrders.Location = new System.Drawing.Point(5, 3);
            this.pnlKitchen_NewOrders.Name = "pnlKitchen_NewOrders";
            this.pnlKitchen_NewOrders.Size = new System.Drawing.Size(1840, 1154);
            this.pnlKitchen_NewOrders.TabIndex = 0;
            // 
            // pnlKitchen_CompleteOrders
            // 
            this.pnlKitchen_CompleteOrders.Controls.Add(this.btnKitchen_ClearOrders);
            this.pnlKitchen_CompleteOrders.Controls.Add(this.label12);
            this.pnlKitchen_CompleteOrders.Controls.Add(this.listViewKitchen_CompleteOrders);
            this.pnlKitchen_CompleteOrders.Controls.Add(this.pnlKitchen_ActiveOrder);
            this.pnlKitchen_CompleteOrders.Location = new System.Drawing.Point(0, 0);
            this.pnlKitchen_CompleteOrders.Name = "pnlKitchen_CompleteOrders";
            this.pnlKitchen_CompleteOrders.Size = new System.Drawing.Size(1837, 1151);
            this.pnlKitchen_CompleteOrders.TabIndex = 10;
            // 
            // btnKitchen_ClearOrders
            // 
            this.btnKitchen_ClearOrders.BackColor = System.Drawing.Color.Salmon;
            this.btnKitchen_ClearOrders.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnKitchen_ClearOrders.Location = new System.Drawing.Point(1457, 1053);
            this.btnKitchen_ClearOrders.Name = "btnKitchen_ClearOrders";
            this.btnKitchen_ClearOrders.Size = new System.Drawing.Size(235, 46);
            this.btnKitchen_ClearOrders.TabIndex = 9;
            this.btnKitchen_ClearOrders.Text = "Clear Orders";
            this.btnKitchen_ClearOrders.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe Script", 19.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(816, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(500, 87);
            this.label12.TabIndex = 8;
            this.label12.Text = "Complete Orders";
            // 
            // listViewKitchen_CompleteOrders
            // 
            this.listViewKitchen_CompleteOrders.BackColor = System.Drawing.Color.White;
            this.listViewKitchen_CompleteOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewKitchen_CompleteOrders.HideSelection = false;
            this.listViewKitchen_CompleteOrders.Location = new System.Drawing.Point(310, 174);
            this.listViewKitchen_CompleteOrders.Name = "listViewKitchen_CompleteOrders";
            this.listViewKitchen_CompleteOrders.Size = new System.Drawing.Size(1440, 819);
            this.listViewKitchen_CompleteOrders.TabIndex = 8;
            this.listViewKitchen_CompleteOrders.UseCompatibleStateImageBehavior = false;
            this.listViewKitchen_CompleteOrders.View = System.Windows.Forms.View.Details;
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
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 500;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_completeOrders);
            this.panel1.Controls.Add(this.btn_ActiveOrders);
            this.panel1.Controls.Add(this.btn_newOrders);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 1157);
            this.panel1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 885);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Complete Orders";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 597);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Active Order";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 319);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "New Orders";
            // 
            // btn_completeOrders
            // 
            this.btn_completeOrders.BackColor = System.Drawing.Color.White;
            this.btn_completeOrders.Image = ((System.Drawing.Image)(resources.GetObject("btn_completeOrders.Image")));
            this.btn_completeOrders.Location = new System.Drawing.Point(35, 740);
            this.btn_completeOrders.Margin = new System.Windows.Forms.Padding(4);
            this.btn_completeOrders.Name = "btn_completeOrders";
            this.btn_completeOrders.Size = new System.Drawing.Size(145, 141);
            this.btn_completeOrders.TabIndex = 1;
            this.btn_completeOrders.UseVisualStyleBackColor = false;
            // 
            // btn_ActiveOrders
            // 
            this.btn_ActiveOrders.BackColor = System.Drawing.Color.White;
            this.btn_ActiveOrders.Image = ((System.Drawing.Image)(resources.GetObject("btn_ActiveOrders.Image")));
            this.btn_ActiveOrders.Location = new System.Drawing.Point(35, 453);
            this.btn_ActiveOrders.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ActiveOrders.Name = "btn_ActiveOrders";
            this.btn_ActiveOrders.Size = new System.Drawing.Size(145, 141);
            this.btn_ActiveOrders.TabIndex = 1;
            this.btn_ActiveOrders.UseVisualStyleBackColor = false;
            // 
            // btn_newOrders
            // 
            this.btn_newOrders.BackColor = System.Drawing.Color.White;
            this.btn_newOrders.Image = ((System.Drawing.Image)(resources.GetObject("btn_newOrders.Image")));
            this.btn_newOrders.Location = new System.Drawing.Point(35, 174);
            this.btn_newOrders.Margin = new System.Windows.Forms.Padding(4);
            this.btn_newOrders.Name = "btn_newOrders";
            this.btn_newOrders.Size = new System.Drawing.Size(145, 141);
            this.btn_newOrders.TabIndex = 1;
            this.btn_newOrders.UseVisualStyleBackColor = false;
            // 
            // listViewNewOrders
            // 
            this.listViewNewOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeadOrders,
            this.columnHeaderTime,
            this.columnHeaderTable});
            this.listViewNewOrders.HideSelection = false;
            this.listViewNewOrders.Location = new System.Drawing.Point(310, 174);
            this.listViewNewOrders.Name = "listViewNewOrders";
            this.listViewNewOrders.Size = new System.Drawing.Size(1440, 819);
            this.listViewNewOrders.TabIndex = 8;
            this.listViewNewOrders.UseCompatibleStateImageBehavior = false;
            this.listViewNewOrders.View = System.Windows.Forms.View.Details;
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
            this.columnHeaderTable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderTable.Width = 500;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe Script", 19.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(764, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(358, 87);
            this.label5.TabIndex = 7;
            this.label5.Text = "New Orders";
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
            // btn_readyOrder
            // 
            this.btn_readyOrder.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_readyOrder.ForeColor = System.Drawing.Color.Black;
            this.btn_readyOrder.Image = ((System.Drawing.Image)(resources.GetObject("btn_readyOrder.Image")));
            this.btn_readyOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_readyOrder.Location = new System.Drawing.Point(1381, 1030);
            this.btn_readyOrder.Name = "btn_readyOrder";
            this.btn_readyOrder.Size = new System.Drawing.Size(205, 64);
            this.btn_readyOrder.TabIndex = 9;
            this.btn_readyOrder.Text = "Ready";
            this.btn_readyOrder.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label9.Font = new System.Drawing.Font("Segoe Script", 19.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(769, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(253, 87);
            this.label9.TabIndex = 7;
            this.label9.Text = "Kitchen";
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
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(1386, 1033);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(205, 64);
            this.button4.TabIndex = 9;
            this.button4.Text = "Ready";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // btnKitchen_newOrders
            // 
            this.btnKitchen_newOrders.BackColor = System.Drawing.Color.White;
            this.btnKitchen_newOrders.Image = ((System.Drawing.Image)(resources.GetObject("btnKitchen_newOrders.Image")));
            this.btnKitchen_newOrders.Location = new System.Drawing.Point(43, 174);
            this.btnKitchen_newOrders.Margin = new System.Windows.Forms.Padding(4);
            this.btnKitchen_newOrders.Name = "btnKitchen_newOrders";
            this.btnKitchen_newOrders.Size = new System.Drawing.Size(145, 141);
            this.btnKitchen_newOrders.TabIndex = 1;
            this.btnKitchen_newOrders.UseVisualStyleBackColor = false;
            this.btnKitchen_newOrders.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnKitchen_ActiveOrder
            // 
            this.btnKitchen_ActiveOrder.BackColor = System.Drawing.Color.White;
            this.btnKitchen_ActiveOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnKitchen_ActiveOrder.Image")));
            this.btnKitchen_ActiveOrder.Location = new System.Drawing.Point(35, 453);
            this.btnKitchen_ActiveOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btnKitchen_ActiveOrder.Name = "btnKitchen_ActiveOrder";
            this.btnKitchen_ActiveOrder.Size = new System.Drawing.Size(145, 141);
            this.btnKitchen_ActiveOrder.TabIndex = 1;
            this.btnKitchen_ActiveOrder.UseVisualStyleBackColor = false;
            // 
            // btnKitchen_CompleteOrders
            // 
            this.btnKitchen_CompleteOrders.BackColor = System.Drawing.Color.White;
            this.btnKitchen_CompleteOrders.Image = ((System.Drawing.Image)(resources.GetObject("btnKitchen_CompleteOrders.Image")));
            this.btnKitchen_CompleteOrders.Location = new System.Drawing.Point(35, 740);
            this.btnKitchen_CompleteOrders.Margin = new System.Windows.Forms.Padding(4);
            this.btnKitchen_CompleteOrders.Name = "btnKitchen_CompleteOrders";
            this.btnKitchen_CompleteOrders.Size = new System.Drawing.Size(145, 141);
            this.btnKitchen_CompleteOrders.TabIndex = 1;
            this.btnKitchen_CompleteOrders.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 319);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 32);
            this.label8.TabIndex = 2;
            this.label8.Text = "New Orders";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 597);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 32);
            this.label7.TabIndex = 2;
            this.label7.Text = "Active Order";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 885);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 32);
            this.label6.TabIndex = 2;
            this.label6.Text = "Complete Orders";
            // 
            // sidebarPanelCompleteOrder
            // 
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
            this.pnlKitchen_ActiveOrder.Location = new System.Drawing.Point(561, 46);
            this.pnlKitchen_ActiveOrder.Name = "pnlKitchen_ActiveOrder";
            this.pnlKitchen_ActiveOrder.Size = new System.Drawing.Size(1055, 733);
            this.pnlKitchen_ActiveOrder.TabIndex = 10;
            // 
            // KitchenViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1844, 1157);
            this.Controls.Add(this.pnlKitchen_NewOrders);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.sidebarPanelCompleteOrder);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "KitchenViewForm";
            this.Text = "KitchenViewForm";
            this.pnlKitchen_NewOrders.ResumeLayout(false);
            this.pnlKitchen_NewOrders.PerformLayout();
            this.pnlKitchen_CompleteOrders.ResumeLayout(false);
            this.pnlKitchen_CompleteOrders.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.sidebarPanelCompleteOrder.ResumeLayout(false);
            this.sidebarPanelCompleteOrder.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlKitchen_NewOrders;
        private System.Windows.Forms.Panel pnlKitchen_CompleteOrders;
        private System.Windows.Forms.Button btnKitchen_ClearOrders;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListView listViewKitchen_CompleteOrders;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_completeOrders;
        private System.Windows.Forms.Button btn_ActiveOrders;
        private System.Windows.Forms.Button btn_newOrders;
        private System.Windows.Forms.ListView listViewNewOrders;
        private System.Windows.Forms.ColumnHeader colHeadOrders;
        private System.Windows.Forms.ColumnHeader columnHeaderTime;
        private System.Windows.Forms.ColumnHeader columnHeaderTable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_readyOrder;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnKitchen_newOrders;
        private System.Windows.Forms.Button btnKitchen_ActiveOrder;
        private System.Windows.Forms.Button btnKitchen_CompleteOrders;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel sidebarPanelCompleteOrder;
        private System.Windows.Forms.Panel pnlKitchen_ActiveOrder;
    }
}