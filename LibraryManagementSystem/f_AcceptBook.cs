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
    public partial class f_AcceptBook : Form
    {
        BAL business = new BAL();
        Book book = new Book();

        public f_AcceptBook(Book otherBook)
        {
            InitializeComponent();

            book = otherBook;
        }

        private void f_AcceptBook_Load(object sender, EventArgs e)
        {
            dgv_IssueStatus.AllowUserToAddRows = false;
            dgv_IssueStatus.ReadOnly = true;
            dgv_IssueStatus.DataSource = business.SearchIssueStatus_Scure("ByBookID", book.BookID);
        }

        private void btn_Accept_Click(object sender, EventArgs e)
        {
            if (dgv_IssueStatus.SelectedRows.Count == 0)
            {
                MessageBox.Show("Must select Some Book First to Accept it...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StatusOfReturn returnStatus = new StatusOfReturn();

            returnStatus.BookID = dgv_IssueStatus.SelectedRows[0].Cells[0].Value.ToString();
            returnStatus.MemberID = dgv_IssueStatus.SelectedRows[0].Cells[1].Value.ToString();
            returnStatus.IssueDate = dgv_IssueStatus.SelectedRows[0].Cells[2].Value.ToString();
            returnStatus.ExpiryDate =  dgv_IssueStatus.SelectedRows[0].Cells[3].Value.ToString();
            
            if(Convert.ToDateTime(returnStatus.ExpiryDate) > Convert.ToDateTime(returnStatus.IssueDate))
            {
                returnStatus.FineAmount = 100;
            }

            if (business.ReturnBook_Scure(returnStatus) == 1) 
            {
                if(returnStatus.FineAmount==100)
                  MessageBox.Show("Expiry Date has Passed, Issue Fine of 100...!", "Fine Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              
                MessageBox.Show("Book Accepted Successfully...!", "Book Accepted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}