namespace LibraryManagementSystem
{
    partial class f_Book
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_Book));
            this.tb_BookID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Title = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_SubjectCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Author = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_RackNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_Publisher = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_Price = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.gb_Details = new System.Windows.Forms.GroupBox();
            this.gb_Details.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_BookID
            // 
            this.tb_BookID.Location = new System.Drawing.Point(110, 25);
            this.tb_BookID.Name = "tb_BookID";
            this.tb_BookID.Size = new System.Drawing.Size(207, 20);
            this.tb_BookID.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "BookID";
            // 
            // tb_Title
            // 
            this.tb_Title.Location = new System.Drawing.Point(110, 60);
            this.tb_Title.Name = "tb_Title";
            this.tb_Title.Size = new System.Drawing.Size(207, 20);
            this.tb_Title.TabIndex = 1;
            this.tb_Title.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Title_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Title";
            // 
            // tb_SubjectCode
            // 
            this.tb_SubjectCode.Location = new System.Drawing.Point(110, 96);
            this.tb_SubjectCode.Name = "tb_SubjectCode";
            this.tb_SubjectCode.Size = new System.Drawing.Size(207, 20);
            this.tb_SubjectCode.TabIndex = 2;
            this.tb_SubjectCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_SubjectCode_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Subject Code";
            // 
            // tb_Author
            // 
            this.tb_Author.Location = new System.Drawing.Point(110, 133);
            this.tb_Author.Name = "tb_Author";
            this.tb_Author.Size = new System.Drawing.Size(207, 20);
            this.tb_Author.TabIndex = 3;
            this.tb_Author.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Author_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Author";
            // 
            // tb_RackNo
            // 
            this.tb_RackNo.Location = new System.Drawing.Point(110, 173);
            this.tb_RackNo.Name = "tb_RackNo";
            this.tb_RackNo.Size = new System.Drawing.Size(207, 20);
            this.tb_RackNo.TabIndex = 4;
            this.tb_RackNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_RackNo_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Rack No.";
            // 
            // tb_Publisher
            // 
            this.tb_Publisher.Location = new System.Drawing.Point(110, 213);
            this.tb_Publisher.Name = "tb_Publisher";
            this.tb_Publisher.Size = new System.Drawing.Size(207, 20);
            this.tb_Publisher.TabIndex = 5;
            this.tb_Publisher.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Publisher_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Publisher";
            // 
            // tb_Price
            // 
            this.tb_Price.Location = new System.Drawing.Point(110, 250);
            this.tb_Price.Name = "tb_Price";
            this.tb_Price.Size = new System.Drawing.Size(207, 20);
            this.tb_Price.TabIndex = 6;
            this.tb_Price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Price_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 257);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Price (Rs)";
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(26, 297);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(87, 23);
            this.btn_Update.TabIndex = 7;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(230, 297);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(87, 23);
            this.btn_Back.TabIndex = 9;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(129, 297);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(87, 23);
            this.btn_Clear.TabIndex = 8;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(103, 13);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(95, 23);
            this.btn_OK.TabIndex = 10;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // gb_Details
            // 
            this.gb_Details.Controls.Add(this.btn_OK);
            this.gb_Details.Location = new System.Drawing.Point(26, 285);
            this.gb_Details.Name = "gb_Details";
            this.gb_Details.Size = new System.Drawing.Size(291, 46);
            this.gb_Details.TabIndex = 22;
            this.gb_Details.TabStop = false;
            // 
            // f_Book
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 343);
            this.Controls.Add(this.gb_Details);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_Price);
            this.Controls.Add(this.tb_Publisher);
            this.Controls.Add(this.tb_RackNo);
            this.Controls.Add(this.tb_Author);
            this.Controls.Add(this.tb_SubjectCode);
            this.Controls.Add(this.tb_Title);
            this.Controls.Add(this.tb_BookID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "f_Book";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Book";
            this.Load += new System.EventHandler(this.f_Book_Load);
            this.gb_Details.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_BookID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_SubjectCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Author;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_RackNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_Publisher;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_Price;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.GroupBox gb_Details;
    }
}