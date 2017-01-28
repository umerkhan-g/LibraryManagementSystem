using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BALayer;
using BELayer;

namespace LibraryManagementSystem
{
    public partial class f_Book : Form
    {
        private BAL business = new BAL();
        private string option;
        private Book book = new Book();

        //The Parameterized Constructor to initialize Private Feilds
        public f_Book(string myOption, Book otherBook)
        {
            InitializeComponent();

            option = myOption;
            book = otherBook;
        }

        ///////////////////////////////////////////////
        //        Loading/Closing Book Form          //
        ///////////////////////////////////////////////

        private void f_Book_Load(object sender, EventArgs e)
        {
            //Setting Maximum Size of Textboxes
            tb_Title.MaxLength = 100;
            tb_SubjectCode.MaxLength = 20;
            tb_Author.MaxLength = 30;
            tb_RackNo.MaxLength = 10;
            tb_Publisher.MaxLength = 30;

            //Setting the Values of all textboxes in Book Form
            tb_BookID.Text = book.BookID;
            tb_Title.Text = book.Title;
            tb_SubjectCode.Text = book.SubjectCode;
            tb_Author.Text = book.Author;
            tb_RackNo.Text = book.RackNo;
            tb_Publisher.Text = book.Publisher;
            tb_Price.Text = Convert.ToString(book.Price);

            //Setting the Layout According to the Option Private Feild Value
            tb_BookID.ReadOnly = true;

            if (option == "Update")
            {
                this.Text = "Update Book";

                btn_OK.Enabled = false;

                gb_Details.Visible = false;
            }
            else if(option == "ViewDetails")
            {
                this.Text = "Details of Book";

                tb_Title.ReadOnly = true;
                tb_SubjectCode.ReadOnly = true;
                tb_Author.ReadOnly = true;
                tb_RackNo.ReadOnly = true;
                tb_Publisher.ReadOnly = true;
                tb_Price.ReadOnly = true;

                btn_Update.Enabled = false;
                btn_Clear.Enabled = false;
                btn_Back.Enabled = false;

                gb_Details.Visible = true;
            }
        }

        ///////////////////////////////////////////////
        //           Validating User Input           //
        ///////////////////////////////////////////////

        //Validating the Textboxes Input From the User  
        private void tb_Title_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)) 
                e.Handled = true;
        }

        private void tb_SubjectCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void tb_Author_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void tb_RackNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tb_Publisher_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void tb_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        ///////////////////////////////////////////////
        //     Adding Functionality to Buttons       //
        ///////////////////////////////////////////////

        private void btn_Update_Click(object sender, EventArgs e)
        {
            Book abook = new Book();

            abook.BookID = tb_BookID.Text;
            abook.Title = tb_Title.Text;
            abook.SubjectCode = tb_SubjectCode.Text;
            abook.Author = tb_Author.Text;
            abook.RackNo = tb_RackNo.Text;
            abook.Publisher = tb_Publisher.Text;
            abook.Price = Convert.ToDouble(tb_Price.Text);

            if(business.UpdateBook_Scure(abook)==1)
            {
                MessageBox.Show("The Book info. is Updated Successfully...!", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            tb_Title.Clear();
            tb_SubjectCode.Clear();
            tb_Author.Clear();
            tb_RackNo.Clear();
            tb_Publisher.Clear();
            tb_Price.Clear();

            tb_Title.Focus();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}