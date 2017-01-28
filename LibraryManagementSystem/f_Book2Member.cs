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
    public partial class f_Book2Member : Form
    {
        BAL business = new BAL();
        Book book = new Book();

        public f_Book2Member(Book otherBook)
        {
            InitializeComponent();

            book = otherBook;
        }

        ///////////////////////////////////////////////
        //     Loading/Closing Issue Book Form       //
        ///////////////////////////////////////////////

        private void f_Book2Member_Load(object sender, EventArgs e)
        {
            dgv_Members.AllowUserToAddRows = false;
            dgv_Members.ReadOnly = true;
            dgv_Members.DataSource = business.LoadMember_Scure();

            tb_BookID.ReadOnly = true;
            tb_BookID.Text = book.BookID;

            rbn_ID.Checked = true;
        }

        ///////////////////////////////////////////////
        //   Validating User Search String Input     //
        ///////////////////////////////////////////////

        private void tb_SearchString_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        ///////////////////////////////////////////////
        //           Searching for Records           //
        ///////////////////////////////////////////////

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_SearchString.Text))
            {
                MessageBox.Show("Please Enter Some String First to Search for...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(rbn_ID.Checked)
            {
                dgv_Members.DataSource = business.SearchMember_Scure("ByID_Exact", tb_SearchString.Text);
            }
            else if(rbn_MemberType.Checked)
            {
                dgv_Members.DataSource = business.SearchMember_Scure("ByType", tb_SearchString.Text);
            }
            else if(rbn_Name.Checked)
            {
                dgv_Members.DataSource = business.SearchMember_Scure("ByName_Exact", tb_SearchString.Text);
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            tb_SearchString.Clear();
            tb_SearchString.Focus();
        }

        ///////////////////////////////////////////////
        //        Issuing the Book to Member         //
        ///////////////////////////////////////////////

        private void btn_Issue_Click(object sender, EventArgs e)
        {
            if (dgv_Members.SelectedRows.Count == 0)
            {
                MessageBox.Show("Must select Some Member First to issue it...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            //Verifing the Member's Membership Validity
            if(DateTime.Now >= Convert.ToDateTime(dgv_Members.SelectedRows[0].Cells[4].Value))
            {
                MessageBox.Show("Membership of Selected Member Expired...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StatusOfIssue issueStatus = new StatusOfIssue();

            issueStatus.BookID = book.BookID;
            issueStatus.MemberID = dgv_Members.SelectedRows[0].Cells[0].Value.ToString();
            issueStatus.IssueDate = DateTime.Now.ToString("yyyy-MM-dd");
            issueStatus.ExpiryDate = dtp_Expiry.Value.ToString("yyyy-MM-dd");

            if (business.IssueBook_Scure(issueStatus) == 1)
            {
                MessageBox.Show("Book Issued to Member Successfully...!", "Book Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}