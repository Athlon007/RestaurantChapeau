namespace RestaurantChapeau
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txt_LoginPassword = new System.Windows.Forms.TextBox();
            this.txt_LoginEmail = new System.Windows.Forms.TextBox();
            this.btn_LoginLogin = new System.Windows.Forms.Button();
            this.btn_LoginForgot = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnl_ForgotPassword = new System.Windows.Forms.Panel();
            this.lbl_ForgotConfirm = new System.Windows.Forms.Label();
            this.lbl_ForgotNew = new System.Windows.Forms.Label();
            this.lbl_ForgotEmail = new System.Windows.Forms.Label();
            this.btn_ForgotLogin = new System.Windows.Forms.Button();
            this.btn_ForgotChange = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pnl_Register = new System.Windows.Forms.Panel();
            this.lbl_RegisterPassword = new System.Windows.Forms.Label();
            this.txt_RegisterPassword = new System.Windows.Forms.TextBox();
            this.btn_RegisterLogin = new System.Windows.Forms.Button();
            this.btn_RegisterRegister = new System.Windows.Forms.Button();
            this.lbl_RegisterEmail = new System.Windows.Forms.Label();
            this.lbl_RegisterLastName = new System.Windows.Forms.Label();
            this.lbl_RegisterFirstName = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txt_RegisterEmail = new System.Windows.Forms.TextBox();
            this.txt_RegisterLastName = new System.Windows.Forms.TextBox();
            this.txt_RegisterFirstName = new System.Windows.Forms.TextBox();
            this.btn_LoginRegister = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_ForgotPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.pnl_Register.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_LoginPassword
            // 
            this.txt_LoginPassword.Location = new System.Drawing.Point(146, 495);
            this.txt_LoginPassword.Multiline = true;
            this.txt_LoginPassword.Name = "txt_LoginPassword";
            this.txt_LoginPassword.Size = new System.Drawing.Size(452, 58);
            this.txt_LoginPassword.TabIndex = 0;
            this.txt_LoginPassword.TextChanged += new System.EventHandler(this.txt_LoginPassword_TextChanged);
            // 
            // txt_LoginEmail
            // 
            this.txt_LoginEmail.Location = new System.Drawing.Point(146, 337);
            this.txt_LoginEmail.Multiline = true;
            this.txt_LoginEmail.Name = "txt_LoginEmail";
            this.txt_LoginEmail.Size = new System.Drawing.Size(452, 58);
            this.txt_LoginEmail.TabIndex = 1;
            this.txt_LoginEmail.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // btn_LoginLogin
            // 
            this.btn_LoginLogin.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_LoginLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_LoginLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_LoginLogin.Location = new System.Drawing.Point(146, 654);
            this.btn_LoginLogin.Name = "btn_LoginLogin";
            this.btn_LoginLogin.Size = new System.Drawing.Size(452, 58);
            this.btn_LoginLogin.TabIndex = 2;
            this.btn_LoginLogin.Text = "Login";
            this.btn_LoginLogin.UseVisualStyleBackColor = false;
            this.btn_LoginLogin.Click += new System.EventHandler(this.btn_LoginLogin_Click);
            // 
            // btn_LoginForgot
            // 
            this.btn_LoginForgot.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_LoginForgot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_LoginForgot.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_LoginForgot.Location = new System.Drawing.Point(146, 770);
            this.btn_LoginForgot.Name = "btn_LoginForgot";
            this.btn_LoginForgot.Size = new System.Drawing.Size(452, 58);
            this.btn_LoginForgot.TabIndex = 3;
            this.btn_LoginForgot.Text = "Forgot password";
            this.btn_LoginForgot.UseVisualStyleBackColor = false;
            this.btn_LoginForgot.Click += new System.EventHandler(this.btn_forgotPassword_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(146, 472);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Password";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RestaurantChapeau.Properties.Resources.hat;
            this.pictureBox1.Location = new System.Drawing.Point(171, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(401, 221);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // pnl_ForgotPassword
            // 
            this.pnl_ForgotPassword.Controls.Add(this.lbl_ForgotConfirm);
            this.pnl_ForgotPassword.Controls.Add(this.lbl_ForgotNew);
            this.pnl_ForgotPassword.Controls.Add(this.lbl_ForgotEmail);
            this.pnl_ForgotPassword.Controls.Add(this.btn_ForgotLogin);
            this.pnl_ForgotPassword.Controls.Add(this.btn_ForgotChange);
            this.pnl_ForgotPassword.Controls.Add(this.textBox3);
            this.pnl_ForgotPassword.Controls.Add(this.textBox2);
            this.pnl_ForgotPassword.Controls.Add(this.textBox1);
            this.pnl_ForgotPassword.Controls.Add(this.pictureBox3);
            this.pnl_ForgotPassword.Location = new System.Drawing.Point(0, 0);
            this.pnl_ForgotPassword.Name = "pnl_ForgotPassword";
            this.pnl_ForgotPassword.Size = new System.Drawing.Size(726, 1055);
            this.pnl_ForgotPassword.TabIndex = 9;
            // 
            // lbl_ForgotConfirm
            // 
            this.lbl_ForgotConfirm.AutoSize = true;
            this.lbl_ForgotConfirm.Location = new System.Drawing.Point(146, 631);
            this.lbl_ForgotConfirm.Name = "lbl_ForgotConfirm";
            this.lbl_ForgotConfirm.Size = new System.Drawing.Size(129, 20);
            this.lbl_ForgotConfirm.TabIndex = 16;
            this.lbl_ForgotConfirm.Text = "Confirm password";
            // 
            // lbl_ForgotNew
            // 
            this.lbl_ForgotNew.AutoSize = true;
            this.lbl_ForgotNew.Location = new System.Drawing.Point(146, 472);
            this.lbl_ForgotNew.Name = "lbl_ForgotNew";
            this.lbl_ForgotNew.Size = new System.Drawing.Size(106, 20);
            this.lbl_ForgotNew.TabIndex = 15;
            this.lbl_ForgotNew.Text = "New password";
            // 
            // lbl_ForgotEmail
            // 
            this.lbl_ForgotEmail.AutoSize = true;
            this.lbl_ForgotEmail.Location = new System.Drawing.Point(146, 314);
            this.lbl_ForgotEmail.Name = "lbl_ForgotEmail";
            this.lbl_ForgotEmail.Size = new System.Drawing.Size(46, 20);
            this.lbl_ForgotEmail.TabIndex = 14;
            this.lbl_ForgotEmail.Text = "Email";
            // 
            // btn_ForgotLogin
            // 
            this.btn_ForgotLogin.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_ForgotLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_ForgotLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_ForgotLogin.Location = new System.Drawing.Point(146, 871);
            this.btn_ForgotLogin.Name = "btn_ForgotLogin";
            this.btn_ForgotLogin.Size = new System.Drawing.Size(452, 58);
            this.btn_ForgotLogin.TabIndex = 12;
            this.btn_ForgotLogin.Text = "Go back to login";
            this.btn_ForgotLogin.UseVisualStyleBackColor = false;
            this.btn_ForgotLogin.Click += new System.EventHandler(this.btn_ForgotLogin_Click);
            // 
            // btn_ForgotChange
            // 
            this.btn_ForgotChange.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_ForgotChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_ForgotChange.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_ForgotChange.Location = new System.Drawing.Point(146, 770);
            this.btn_ForgotChange.Name = "btn_ForgotChange";
            this.btn_ForgotChange.Size = new System.Drawing.Size(452, 58);
            this.btn_ForgotChange.TabIndex = 12;
            this.btn_ForgotChange.Text = "Change password";
            this.btn_ForgotChange.UseVisualStyleBackColor = false;
            this.btn_ForgotChange.Click += new System.EventHandler(this.btn_ForgotChange_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(146, 654);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(452, 58);
            this.textBox3.TabIndex = 12;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(146, 495);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(452, 58);
            this.textBox2.TabIndex = 12;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(146, 337);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(452, 58);
            this.textBox1.TabIndex = 12;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::RestaurantChapeau.Properties.Resources.hat;
            this.pictureBox3.Location = new System.Drawing.Point(171, 34);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(401, 221);
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // pnl_Register
            // 
            this.pnl_Register.Controls.Add(this.lbl_RegisterPassword);
            this.pnl_Register.Controls.Add(this.txt_RegisterPassword);
            this.pnl_Register.Controls.Add(this.btn_RegisterLogin);
            this.pnl_Register.Controls.Add(this.btn_RegisterRegister);
            this.pnl_Register.Controls.Add(this.lbl_RegisterEmail);
            this.pnl_Register.Controls.Add(this.lbl_RegisterLastName);
            this.pnl_Register.Controls.Add(this.lbl_RegisterFirstName);
            this.pnl_Register.Controls.Add(this.pictureBox2);
            this.pnl_Register.Controls.Add(this.txt_RegisterEmail);
            this.pnl_Register.Controls.Add(this.txt_RegisterLastName);
            this.pnl_Register.Controls.Add(this.txt_RegisterFirstName);
            this.pnl_Register.Location = new System.Drawing.Point(0, 0);
            this.pnl_Register.Name = "pnl_Register";
            this.pnl_Register.Size = new System.Drawing.Size(726, 1055);
            this.pnl_Register.TabIndex = 11;
            this.pnl_Register.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_Register_Paint);
            // 
            // lbl_RegisterPassword
            // 
            this.lbl_RegisterPassword.AutoSize = true;
            this.lbl_RegisterPassword.Location = new System.Drawing.Point(146, 608);
            this.lbl_RegisterPassword.Name = "lbl_RegisterPassword";
            this.lbl_RegisterPassword.Size = new System.Drawing.Size(70, 20);
            this.lbl_RegisterPassword.TabIndex = 17;
            this.lbl_RegisterPassword.Text = "Password";
            // 
            // txt_RegisterPassword
            // 
            this.txt_RegisterPassword.Location = new System.Drawing.Point(146, 631);
            this.txt_RegisterPassword.Multiline = true;
            this.txt_RegisterPassword.Name = "txt_RegisterPassword";
            this.txt_RegisterPassword.Size = new System.Drawing.Size(452, 58);
            this.txt_RegisterPassword.TabIndex = 16;
            // 
            // btn_RegisterLogin
            // 
            this.btn_RegisterLogin.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_RegisterLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_RegisterLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_RegisterLogin.Location = new System.Drawing.Point(146, 871);
            this.btn_RegisterLogin.Name = "btn_RegisterLogin";
            this.btn_RegisterLogin.Size = new System.Drawing.Size(452, 58);
            this.btn_RegisterLogin.TabIndex = 15;
            this.btn_RegisterLogin.Text = "Go back to login";
            this.btn_RegisterLogin.UseVisualStyleBackColor = false;
            this.btn_RegisterLogin.Click += new System.EventHandler(this.btn_RegisterLogin_Click);
            // 
            // btn_RegisterRegister
            // 
            this.btn_RegisterRegister.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_RegisterRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_RegisterRegister.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_RegisterRegister.Location = new System.Drawing.Point(146, 770);
            this.btn_RegisterRegister.Name = "btn_RegisterRegister";
            this.btn_RegisterRegister.Size = new System.Drawing.Size(452, 58);
            this.btn_RegisterRegister.TabIndex = 12;
            this.btn_RegisterRegister.Text = "Register";
            this.btn_RegisterRegister.UseVisualStyleBackColor = false;
            this.btn_RegisterRegister.Click += new System.EventHandler(this.btn_RegisterRegister_Click);
            // 
            // lbl_RegisterEmail
            // 
            this.lbl_RegisterEmail.AutoSize = true;
            this.lbl_RegisterEmail.Location = new System.Drawing.Point(146, 509);
            this.lbl_RegisterEmail.Name = "lbl_RegisterEmail";
            this.lbl_RegisterEmail.Size = new System.Drawing.Size(46, 20);
            this.lbl_RegisterEmail.TabIndex = 14;
            this.lbl_RegisterEmail.Text = "Email";
            // 
            // lbl_RegisterLastName
            // 
            this.lbl_RegisterLastName.AutoSize = true;
            this.lbl_RegisterLastName.Location = new System.Drawing.Point(146, 407);
            this.lbl_RegisterLastName.Name = "lbl_RegisterLastName";
            this.lbl_RegisterLastName.Size = new System.Drawing.Size(76, 20);
            this.lbl_RegisterLastName.TabIndex = 13;
            this.lbl_RegisterLastName.Text = "Last name";
            // 
            // lbl_RegisterFirstName
            // 
            this.lbl_RegisterFirstName.AutoSize = true;
            this.lbl_RegisterFirstName.Location = new System.Drawing.Point(143, 314);
            this.lbl_RegisterFirstName.Name = "lbl_RegisterFirstName";
            this.lbl_RegisterFirstName.Size = new System.Drawing.Size(80, 20);
            this.lbl_RegisterFirstName.TabIndex = 12;
            this.lbl_RegisterFirstName.Text = "First Name";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::RestaurantChapeau.Properties.Resources.hat;
            this.pictureBox2.Location = new System.Drawing.Point(171, 34);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(401, 221);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // txt_RegisterEmail
            // 
            this.txt_RegisterEmail.Location = new System.Drawing.Point(146, 532);
            this.txt_RegisterEmail.Multiline = true;
            this.txt_RegisterEmail.Name = "txt_RegisterEmail";
            this.txt_RegisterEmail.Size = new System.Drawing.Size(452, 58);
            this.txt_RegisterEmail.TabIndex = 2;
            // 
            // txt_RegisterLastName
            // 
            this.txt_RegisterLastName.Location = new System.Drawing.Point(146, 430);
            this.txt_RegisterLastName.Multiline = true;
            this.txt_RegisterLastName.Name = "txt_RegisterLastName";
            this.txt_RegisterLastName.Size = new System.Drawing.Size(452, 58);
            this.txt_RegisterLastName.TabIndex = 1;
            // 
            // txt_RegisterFirstName
            // 
            this.txt_RegisterFirstName.Location = new System.Drawing.Point(146, 337);
            this.txt_RegisterFirstName.Multiline = true;
            this.txt_RegisterFirstName.Name = "txt_RegisterFirstName";
            this.txt_RegisterFirstName.Size = new System.Drawing.Size(452, 58);
            this.txt_RegisterFirstName.TabIndex = 0;
            // 
            // btn_LoginRegister
            // 
            this.btn_LoginRegister.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_LoginRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_LoginRegister.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_LoginRegister.Location = new System.Drawing.Point(146, 871);
            this.btn_LoginRegister.Name = "btn_LoginRegister";
            this.btn_LoginRegister.Size = new System.Drawing.Size(452, 58);
            this.btn_LoginRegister.TabIndex = 12;
            this.btn_LoginRegister.Text = "Register";
            this.btn_LoginRegister.UseVisualStyleBackColor = false;
            this.btn_LoginRegister.Click += new System.EventHandler(this.btn_LoginRegister_Click_1);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(726, 1055);
            this.Controls.Add(this.pnl_ForgotPassword);
            this.Controls.Add(this.pnl_Register);
            this.Controls.Add(this.btn_LoginRegister);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_LoginForgot);
            this.Controls.Add(this.btn_LoginLogin);
            this.Controls.Add(this.txt_LoginEmail);
            this.Controls.Add(this.txt_LoginPassword);
            this.Name = "LoginForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnl_ForgotPassword.ResumeLayout(false);
            this.pnl_ForgotPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.pnl_Register.ResumeLayout(false);
            this.pnl_Register.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_LoginPassword;
        private System.Windows.Forms.TextBox txt_LoginEmail;
        private System.Windows.Forms.Button btn_LoginLogin;
        private System.Windows.Forms.Button btn_LoginForgot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnl_ForgotPassword;
        private System.Windows.Forms.Button btn_ForgotLogin;
        private System.Windows.Forms.Button btn_ForgotChange;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel pnl_Register;
        private System.Windows.Forms.Button btn_RegisterRegister;
        private System.Windows.Forms.Label lbl_RegisterEmail;
        private System.Windows.Forms.Label lbl_RegisterLastName;
        private System.Windows.Forms.Label lbl_RegisterFirstName;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txt_RegisterEmail;
        private System.Windows.Forms.TextBox txt_RegisterLastName;
        private System.Windows.Forms.TextBox txt_RegisterFirstName;
        private System.Windows.Forms.Button btn_RegisterLogin;
        private System.Windows.Forms.Button btn_LoginRegister;
        private System.Windows.Forms.Label lbl_ForgotConfirm;
        private System.Windows.Forms.Label lbl_ForgotNew;
        private System.Windows.Forms.Label lbl_ForgotEmail;
        private System.Windows.Forms.Label lbl_RegisterPassword;
        private System.Windows.Forms.TextBox txt_RegisterPassword;
        private System.Windows.Forms.Panel pnl_TableView;
    }
}
