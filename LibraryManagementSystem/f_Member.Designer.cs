namespace LibraryManagementSystem
{
    partial class f_Member
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_Member));
            this.btn_Back = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Contact = new System.Windows.Forms.TextBox();
            this.tb_Address = new System.Windows.Forms.TextBox();
            this.tb_MemberType = new System.Windows.Forms.TextBox();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.tb_MemberID = new System.Windows.Forms.TextBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.dtp_Expiry = new System.Windows.Forms.DateTimePicker();
            this.gb_Details = new System.Windows.Forms.GroupBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.gb_Details.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(230, 290);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(87, 23);
            this.btn_Back.TabIndex = 8;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(26, 290);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(87, 23);
            this.btn_Update.TabIndex = 6;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Contact";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Expiry Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Member Type ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "MemberID";
            // 
            // tb_Contact
            // 
            this.tb_Contact.Location = new System.Drawing.Point(110, 232);
            this.tb_Contact.Name = "tb_Contact";
            this.tb_Contact.Size = new System.Drawing.Size(207, 20);
            this.tb_Contact.TabIndex = 5;
            this.tb_Contact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Contact_KeyPress);
            // 
            // tb_Address
            // 
            this.tb_Address.Location = new System.Drawing.Point(110, 192);
            this.tb_Address.Name = "tb_Address";
            this.tb_Address.Size = new System.Drawing.Size(207, 20);
            this.tb_Address.TabIndex = 4;
            this.tb_Address.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Address_KeyPress);
            // 
            // tb_MemberType
            // 
            this.tb_MemberType.Location = new System.Drawing.Point(110, 115);
            this.tb_MemberType.Name = "tb_MemberType";
            this.tb_MemberType.Size = new System.Drawing.Size(207, 20);
            this.tb_MemberType.TabIndex = 2;
            this.tb_MemberType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_MemberType_KeyPress);
            // 
            // tb_Name
            // 
            this.tb_Name.Location = new System.Drawing.Point(110, 79);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(207, 20);
            this.tb_Name.TabIndex = 1;
            this.tb_Name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Name_KeyPress);
            // 
            // tb_MemberID
            // 
            this.tb_MemberID.Location = new System.Drawing.Point(110, 44);
            this.tb_MemberID.Name = "tb_MemberID";
            this.tb_MemberID.Size = new System.Drawing.Size(207, 20);
            this.tb_MemberID.TabIndex = 0;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(129, 290);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(87, 23);
            this.btn_Clear.TabIndex = 7;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // dtp_Expiry
            // 
            this.dtp_Expiry.Location = new System.Drawing.Point(110, 153);
            this.dtp_Expiry.Name = "dtp_Expiry";
            this.dtp_Expiry.Size = new System.Drawing.Size(207, 20);
            this.dtp_Expiry.TabIndex = 3;
            // 
            // gb_Details
            // 
            this.gb_Details.Controls.Add(this.btn_OK);
            this.gb_Details.Location = new System.Drawing.Point(26, 267);
            this.gb_Details.Name = "gb_Details";
            this.gb_Details.Size = new System.Drawing.Size(291, 46);
            this.gb_Details.TabIndex = 21;
            this.gb_Details.TabStop = false;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(103, 13);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(95, 23);
            this.btn_OK.TabIndex = 9;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // f_Member
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 343);
            this.Controls.Add(this.gb_Details);
            this.Controls.Add(this.dtp_Expiry);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_Contact);
            this.Controls.Add(this.tb_Address);
            this.Controls.Add(this.tb_MemberType);
            this.Controls.Add(this.tb_Name);
            this.Controls.Add(this.tb_MemberID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "f_Member";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Member";
            this.Load += new System.EventHandler(this.f_Member_Load);
            this.gb_Details.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Contact;
        private System.Windows.Forms.TextBox tb_Address;
        private System.Windows.Forms.TextBox tb_MemberType;
        private System.Windows.Forms.TextBox tb_Name;
        private System.Windows.Forms.TextBox tb_MemberID;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.DateTimePicker dtp_Expiry;
        private System.Windows.Forms.GroupBox gb_Details;
        private System.Windows.Forms.Button btn_OK;
    }
}