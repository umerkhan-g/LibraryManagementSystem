namespace LibraryManagementSystem
{
    partial class f_A_CP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_A_CP));
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Cuation = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_UserName = new System.Windows.Forms.TextBox();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.tb_ConfirmPass = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Change = new System.Windows.Forms.Button();
            this.btn_Clear2 = new System.Windows.Forms.Button();
            this.btn_Back2 = new System.Windows.Forms.Button();
            this.gb_CP = new System.Windows.Forms.GroupBox();
            this.btn_Back1 = new System.Windows.Forms.Button();
            this.btn_Clear1 = new System.Windows.Forms.Button();
            this.btn_Verify = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gb_CP.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Change Your Password";
            // 
            // lbl_Cuation
            // 
            this.lbl_Cuation.AutoSize = true;
            this.lbl_Cuation.Location = new System.Drawing.Point(12, 53);
            this.lbl_Cuation.Name = "lbl_Cuation";
            this.lbl_Cuation.Size = new System.Drawing.Size(144, 13);
            this.lbl_Cuation.TabIndex = 0;
            this.lbl_Cuation.Text = "First Verify Currrent Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "User Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Confirm Password";
            // 
            // tb_UserName
            // 
            this.tb_UserName.Location = new System.Drawing.Point(109, 113);
            this.tb_UserName.Name = "tb_UserName";
            this.tb_UserName.Size = new System.Drawing.Size(163, 20);
            this.tb_UserName.TabIndex = 0;
            this.tb_UserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_UserName_KeyPress);
            // 
            // tb_Password
            // 
            this.tb_Password.Location = new System.Drawing.Point(109, 151);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.Size = new System.Drawing.Size(163, 20);
            this.tb_Password.TabIndex = 1;
            this.tb_Password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Password_KeyPress);
            // 
            // tb_ConfirmPass
            // 
            this.tb_ConfirmPass.Location = new System.Drawing.Point(109, 189);
            this.tb_ConfirmPass.Name = "tb_ConfirmPass";
            this.tb_ConfirmPass.Size = new System.Drawing.Size(163, 20);
            this.tb_ConfirmPass.TabIndex = 5;
            this.tb_ConfirmPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_ConfirmPass_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LibraryManagementSystem.Properties.Resources._1432693097_gnome_keyring_manager;
            this.pictureBox1.Location = new System.Drawing.Point(162, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Change
            // 
            this.btn_Change.Location = new System.Drawing.Point(15, 226);
            this.btn_Change.Name = "btn_Change";
            this.btn_Change.Size = new System.Drawing.Size(75, 23);
            this.btn_Change.TabIndex = 6;
            this.btn_Change.Text = "Change";
            this.btn_Change.UseVisualStyleBackColor = true;
            this.btn_Change.Click += new System.EventHandler(this.btn_Change_Click);
            // 
            // btn_Clear2
            // 
            this.btn_Clear2.Location = new System.Drawing.Point(107, 226);
            this.btn_Clear2.Name = "btn_Clear2";
            this.btn_Clear2.Size = new System.Drawing.Size(75, 23);
            this.btn_Clear2.TabIndex = 7;
            this.btn_Clear2.Text = "Clear";
            this.btn_Clear2.UseVisualStyleBackColor = true;
            this.btn_Clear2.Click += new System.EventHandler(this.btn_Clear2_Click);
            // 
            // btn_Back2
            // 
            this.btn_Back2.Location = new System.Drawing.Point(197, 226);
            this.btn_Back2.Name = "btn_Back2";
            this.btn_Back2.Size = new System.Drawing.Size(75, 23);
            this.btn_Back2.TabIndex = 8;
            this.btn_Back2.Text = "Back";
            this.btn_Back2.UseVisualStyleBackColor = true;
            this.btn_Back2.Click += new System.EventHandler(this.btn_Back2_Click);
            // 
            // gb_CP
            // 
            this.gb_CP.Controls.Add(this.btn_Back1);
            this.gb_CP.Controls.Add(this.btn_Clear1);
            this.gb_CP.Controls.Add(this.btn_Verify);
            this.gb_CP.Location = new System.Drawing.Point(15, 189);
            this.gb_CP.Name = "gb_CP";
            this.gb_CP.Size = new System.Drawing.Size(257, 69);
            this.gb_CP.TabIndex = 4;
            this.gb_CP.TabStop = false;
            // 
            // btn_Back1
            // 
            this.btn_Back1.Location = new System.Drawing.Point(175, 27);
            this.btn_Back1.Name = "btn_Back1";
            this.btn_Back1.Size = new System.Drawing.Size(75, 23);
            this.btn_Back1.TabIndex = 4;
            this.btn_Back1.Text = "Back";
            this.btn_Back1.UseVisualStyleBackColor = true;
            this.btn_Back1.Click += new System.EventHandler(this.btn_Back1_Click);
            // 
            // btn_Clear1
            // 
            this.btn_Clear1.Location = new System.Drawing.Point(92, 27);
            this.btn_Clear1.Name = "btn_Clear1";
            this.btn_Clear1.Size = new System.Drawing.Size(75, 23);
            this.btn_Clear1.TabIndex = 3;
            this.btn_Clear1.Text = "Clear";
            this.btn_Clear1.UseVisualStyleBackColor = true;
            this.btn_Clear1.Click += new System.EventHandler(this.btn_Clear1_Click);
            // 
            // btn_Verify
            // 
            this.btn_Verify.Location = new System.Drawing.Point(8, 27);
            this.btn_Verify.Name = "btn_Verify";
            this.btn_Verify.Size = new System.Drawing.Size(75, 23);
            this.btn_Verify.TabIndex = 2;
            this.btn_Verify.Text = "Verify";
            this.btn_Verify.UseVisualStyleBackColor = true;
            this.btn_Verify.Click += new System.EventHandler(this.btn_Verify_Click);
            // 
            // f_A_CP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.gb_CP);
            this.Controls.Add(this.btn_Back2);
            this.Controls.Add(this.btn_Clear2);
            this.Controls.Add(this.btn_Change);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tb_ConfirmPass);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.tb_UserName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_Cuation);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "f_A_CP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.f_A_CP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gb_CP.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Cuation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_UserName;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.TextBox tb_ConfirmPass;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Change;
        private System.Windows.Forms.Button btn_Clear2;
        private System.Windows.Forms.Button btn_Back2;
        private System.Windows.Forms.GroupBox gb_CP;
        private System.Windows.Forms.Button btn_Back1;
        private System.Windows.Forms.Button btn_Clear1;
        private System.Windows.Forms.Button btn_Verify;
    }
}