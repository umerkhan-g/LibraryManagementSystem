namespace LibraryManagementSystem
{
    partial class f_Book2Member
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_Book2Member));
            this.btn_Back = new System.Windows.Forms.Button();
            this.btn_Issue = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_BookID = new System.Windows.Forms.TextBox();
            this.dtp_Expiry = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tb_SearchString = new System.Windows.Forms.TextBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Search = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rbn_Name = new System.Windows.Forms.RadioButton();
            this.rbn_MemberType = new System.Windows.Forms.RadioButton();
            this.rbn_ID = new System.Windows.Forms.RadioButton();
            this.dgv_Members = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Members)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(304, 409);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(91, 23);
            this.btn_Back.TabIndex = 9;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // btn_Issue
            // 
            this.btn_Issue.Location = new System.Drawing.Point(304, 380);
            this.btn_Issue.Name = "btn_Issue";
            this.btn_Issue.Size = new System.Drawing.Size(91, 23);
            this.btn_Issue.TabIndex = 8;
            this.btn_Issue.Text = "Issue";
            this.btn_Issue.UseVisualStyleBackColor = true;
            this.btn_Issue.Click += new System.EventHandler(this.btn_Issue_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_BookID);
            this.groupBox1.Controls.Add(this.dtp_Expiry);
            this.groupBox1.Location = new System.Drawing.Point(12, 363);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 77);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Book";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Expiry Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "BookID";
            // 
            // tb_BookID
            // 
            this.tb_BookID.Location = new System.Drawing.Point(65, 19);
            this.tb_BookID.Name = "tb_BookID";
            this.tb_BookID.Size = new System.Drawing.Size(184, 20);
            this.tb_BookID.TabIndex = 10;
            // 
            // dtp_Expiry
            // 
            this.dtp_Expiry.Location = new System.Drawing.Point(65, 45);
            this.dtp_Expiry.Name = "dtp_Expiry";
            this.dtp_Expiry.Size = new System.Drawing.Size(184, 20);
            this.dtp_Expiry.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.dgv_Members);
            this.groupBox2.Location = new System.Drawing.Point(12, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 343);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Members";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tb_SearchString);
            this.groupBox3.Controls.Add(this.btn_Clear);
            this.groupBox3.Controls.Add(this.btn_Search);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.rbn_Name);
            this.groupBox3.Controls.Add(this.rbn_MemberType);
            this.groupBox3.Controls.Add(this.rbn_ID);
            this.groupBox3.Location = new System.Drawing.Point(6, 249);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(398, 88);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search By";
            // 
            // tb_SearchString
            // 
            this.tb_SearchString.Location = new System.Drawing.Point(245, 17);
            this.tb_SearchString.Name = "tb_SearchString";
            this.tb_SearchString.Size = new System.Drawing.Size(147, 20);
            this.tb_SearchString.TabIndex = 4;
            this.tb_SearchString.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_SearchString_KeyPress);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(301, 44);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(91, 23);
            this.btn_Clear.TabIndex = 6;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(195, 44);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(91, 23);
            this.btn_Search.TabIndex = 5;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(171, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Search String";
            // 
            // rbn_Name
            // 
            this.rbn_Name.AutoSize = true;
            this.rbn_Name.Location = new System.Drawing.Point(76, 20);
            this.rbn_Name.Name = "rbn_Name";
            this.rbn_Name.Size = new System.Drawing.Size(53, 17);
            this.rbn_Name.TabIndex = 2;
            this.rbn_Name.TabStop = true;
            this.rbn_Name.Text = "Name";
            this.rbn_Name.UseVisualStyleBackColor = true;
            // 
            // rbn_MemberType
            // 
            this.rbn_MemberType.AutoSize = true;
            this.rbn_MemberType.Location = new System.Drawing.Point(6, 43);
            this.rbn_MemberType.Name = "rbn_MemberType";
            this.rbn_MemberType.Size = new System.Drawing.Size(90, 17);
            this.rbn_MemberType.TabIndex = 3;
            this.rbn_MemberType.TabStop = true;
            this.rbn_MemberType.Text = "Member Type";
            this.rbn_MemberType.UseVisualStyleBackColor = true;
            // 
            // rbn_ID
            // 
            this.rbn_ID.AutoSize = true;
            this.rbn_ID.Location = new System.Drawing.Point(7, 20);
            this.rbn_ID.Name = "rbn_ID";
            this.rbn_ID.Size = new System.Drawing.Size(36, 17);
            this.rbn_ID.TabIndex = 1;
            this.rbn_ID.TabStop = true;
            this.rbn_ID.Text = "ID";
            this.rbn_ID.UseVisualStyleBackColor = true;
            // 
            // dgv_Members
            // 
            this.dgv_Members.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv_Members.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Members.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv_Members.Location = new System.Drawing.Point(3, 19);
            this.dgv_Members.Name = "dgv_Members";
            this.dgv_Members.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Members.Size = new System.Drawing.Size(401, 224);
            this.dgv_Members.TabIndex = 0;
            // 
            // f_Book2Member
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 454);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.btn_Issue);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "f_Book2Member";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue Book";
            this.Load += new System.EventHandler(this.f_Book2Member_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Members)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Button btn_Issue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_BookID;
        private System.Windows.Forms.DateTimePicker dtp_Expiry;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tb_SearchString;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbn_Name;
        private System.Windows.Forms.RadioButton rbn_MemberType;
        private System.Windows.Forms.RadioButton rbn_ID;
        private System.Windows.Forms.DataGridView dgv_Members;
    }
}