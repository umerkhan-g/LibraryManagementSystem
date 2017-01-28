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
    public partial class f_Member2Book : Form
    {
        BAL business = new BAL();
        Member member = new Member();

        public f_Member2Book(Member otherMember)
        {
            InitializeComponent();

            member = otherMember;
        }

        ///////////////////////////////////////////////
        //     Loading/Closing Issue Book Form       //
        ///////////////////////////////////////////////

        private void f_Member2Book_Load(object sender, EventArgs e)
        {
            dgv_Books.AllowUserToAddRows = false;
            dgv_Books.ReadOnly = true;
            dgv_Books.DataSource = business.LoadBook_Scure();

            tb_MemberID.ReadOnly = true;
            tb_MemberID.Text = member.MemberID;

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
                dgv_Books.DataSource = business.SearchBook_Scure("ByID_Exact", tb_SearchString.Text);
            }
            else if(rbn_Title.Checked)
            {
                dgv_Books.DataSource = business.SearchBook_Scure("ByTitle_Exact", tb_SearchString.Text);
            }
            else if(rbn_Publisher.Checked)
            {
                dgv_Books.DataSource = business.SearchBook_Scure("ByPublisher_Exact", tb_SearchString.Text);
            }
            else if(rbn_RackNo.Checked)
            {
                dgv_Books.DataSource = business.SearchBook_Scure("ByRackNo", tb_SearchString.Text);
            }
            else if(rbn_Author.Checked)
            {
                dgv_Books.DataSource = business.SearchBook_Scure("ByAuthor_Exact", tb_SearchString.Text);
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
            if (dgv_Books.SelectedRows.Count == 0)
            {
                MessageBox.Show("Must select Some Book First to issue it...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Verifing the Member's Membersihp Validity
            if (DateTime.Now >= Convert.ToDateTime(member.MembershipExpiryDate))
            {
                MessageBox.Show("Membership of Selected Member Expired...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Checking Whether the Book is Issued to Some Member or Not
            if (!string.IsNullOrWhiteSpace(dgv_Books.SelectedRows[0].Cells[7].Value.ToString()))
            {
                MessageBox.Show("The Selected Book Has Already been Issued to Some User...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StatusOfIssue issueStatus = new StatusOfIssue();

            issueStatus.BookID = dgv_Books.SelectedRows[0].Cells[0].Value.ToString();
            issueStatus.MemberID = member.MemberID;
            issueStatus.IssueDate = DateTime.Now.ToString("yyyy-MM-dd");
            issueStatus.ExpiryDate = dtp_Expiry.Value.ToString("yyyy-MM-dd");

            if(business.IssueBook_Scure(issueStatus)==1)
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