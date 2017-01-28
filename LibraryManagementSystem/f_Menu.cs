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
    public partial class f_Menu : Form
    {
        BAL business = new BAL();

        public f_Menu()
        {
            InitializeComponent();
        }

        ///////////////////////////////////////////////
        //      Loading/Closing Main Manu Form       //
        ///////////////////////////////////////////////

        private void f_Menu_Load(object sender, EventArgs e)
        {

            //Loading Default Settings for Admin Tab

            //Applying Password Masking on tb_A_Password
            tb_A_Password.UseSystemPasswordChar = true;
            //Specifing Lengths of all textboxes in Admin Tab
            tb_A_AdminId.MaxLength = 20;
            tb_A_Name.MaxLength = 30;
            tb_A_Address.MaxLength = 50;
            tb_A_Contact.MaxLength = 14;
            tb_A_UserName.MaxLength = 15;
            tb_A_Password.MaxLength = 15;
            //Setting DataGrid Properties and Initial Data
            dgv_A_AdminRecords.AllowUserToAddRows = false;
            dgv_A_AdminRecords.ReadOnly = true;
            dgv_A_AdminRecords.DataSource = business.LoadAdmin_Scure();
            //------------------------------------------------------------

            //Loading Default Settings for Search Tab

            tb_S_SearchString.MaxLength = 30;
            //Setting DataGrid Properties and Initial Data
            dgv_S_SearchResult.AllowUserToAddRows = false;
            dgv_S_SearchResult.ReadOnly = true;
            dgv_S_SearchResult.DataSource = business.LoadBook_Scure();
            //Setting Default Radio Buttons  
            rbn_S_SearchBooks.Checked = true;
            rbn_S_SearchBookBy_Id.Checked = true;
            rbn_S_SearchMethod_Exact.Checked = true;
            //------------------------------------------------------------

            //Loading Default Settings for Book Tab
            dgv_B_BookRecords.AllowUserToAddRows = false;
            dgv_B_BookRecords.ReadOnly = true;
            dgv_B_BookRecords.DataSource = business.LoadBook_Scure();

            //Loading Default Settings for Member Tab
            dgv_M_MemberRecords.AllowUserToAddRows = false;
            dgv_M_MemberRecords.ReadOnly = true;
            dgv_M_MemberRecords.DataSource = business.LoadMember_Scure();

            //Loading Default Settings for IssueAccept Tab
            dgv_IA.AllowUserToAddRows = false;
            dgv_IA.ReadOnly = true;
            dgv_IA.DataSource = business.LoadIssuedBook_Scure();

            rbn_IA_Issued.Checked = true;
            rbn_IA_A_BookId.Checked = true;
        }

        private void f_Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            (new f_Login()).Show();
        }

        ///////////////////////////////////////////////
        //      Adding Functionality to Admin Tab    //
        ///////////////////////////////////////////////

        ///////////////////////////////////////////////
        //       Delete Button to Delete Admin       //
        ///////////////////////////////////////////////

        private void btn_A_DeleteAdmin_Click(object sender, EventArgs e)
        {
            if(dgv_A_AdminRecords.SelectedRows.Count == 0)
            {
                MessageBox.Show("Must select Some Row First to Delete it...!", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgv_A_AdminRecords.Rows.Count > 1)
            {
                DialogResult result = MessageBox.Show("Do you really want to delete Selected Row From DataBase?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(result == DialogResult.Yes)
                {
                    Administrator admin = new Administrator();
                    admin.AdminID = dgv_A_AdminRecords.SelectedRows[0].Cells[0].Value.ToString();
                
                    if (business.DeleteAdmin_Scure(admin) == 1)
                    {
                         MessageBox.Show("Selected Admin Records Deleted Successfully...!", "Records Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("You can't Delete a Single Existing Record...!", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Loading dgv_A_AdminRecords Data again after Deleting Admin to Refresh
            dgv_A_AdminRecords.DataSource = business.LoadAdmin_Scure();
        }

        ///////////////////////////////////////////////
        //       Changes the Password of Admin       //
        ///////////////////////////////////////////////

        private void btn_A_ChangePassword_Click(object sender, EventArgs e)
        {
            (new f_A_CP()).ShowDialog();
        }

        ///////////////////////////////////////////////
        //              For Logout Admin             //
        ///////////////////////////////////////////////

        private void btn_A_LogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        ///////////////////////////////////////////////
        //        Adding New Admin to Database       //
        ///////////////////////////////////////////////

        //Validating Inputs of All the textboxes in admin tab
        private void tb_A_AdminId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tb_A_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void tb_A_Address_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void tb_A_Contact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tb_A_UserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tb_A_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        //Registering the Admin to Database
        private void btn_A_Register_Click(object sender, EventArgs e)
        {
            Administrator admin = new Administrator();

            if (!string.IsNullOrWhiteSpace(tb_A_AdminId.Text) && !string.IsNullOrWhiteSpace(tb_A_Name.Text) && !string.IsNullOrWhiteSpace(tb_A_Contact.Text) && !string.IsNullOrWhiteSpace(tb_A_UserName.Text) && !string.IsNullOrWhiteSpace(tb_A_Password.Text))  
            {
                admin.AdminID = tb_A_AdminId.Text;
                admin.Name = tb_A_Name.Text;
                admin.Address = tb_A_Address.Text;
                admin.Contact = tb_A_Contact.Text;
                admin.UserName = tb_A_UserName.Text;
                admin.UserPassword = tb_A_Password.Text;


                if (business.AddAdmin_Scure(admin) == 1)
                {
                    MessageBox.Show("New Admin is Successfully Added to the Database...!", "New Admin Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tb_A_AdminId.Clear();
                    tb_A_Name.Clear();
                    tb_A_Address.Clear();
                    tb_A_Contact.Clear();
                    tb_A_UserName.Clear();
                    tb_A_Password.Clear();

                    tb_A_AdminId.Focus();

                    dgv_A_AdminRecords.DataSource = business.LoadAdmin_Scure();
                }
                else
                {
                    MessageBox.Show("Error During Insertion...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Firstly fill all the Blanks then Click Save...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_A_Clear_Click(object sender, EventArgs e)
        {
            tb_A_AdminId.Clear();
            tb_A_Name.Clear();
            tb_A_Address.Clear();
            tb_A_Contact.Clear();
            tb_A_UserName.Clear();
            tb_A_Password.Clear();

            tb_A_AdminId.Focus();
        }

        ///////////////////////////////////////////////
        //      Adding Functionality to Admin Tab    //
        ///////////////////////////////////////////////

        ///////////////////////////////////////////////
        //Setting Radio Button Book/Member Click Eve.//
        ///////////////////////////////////////////////

        private void rbn_S_SearchBooks_MouseClick(object sender, MouseEventArgs e)
        {
            dgv_S_SearchResult.DataSource = business.LoadBook_Scure();

            gb_SearchBookBy.Visible = true;
            gb_SearchMemberBy.Visible = false;
        }

        private void rbn_S_SearchMembers_MouseClick(object sender, MouseEventArgs e)
        {
            dgv_S_SearchResult.DataSource = business.LoadMember_Scure();

            gb_SearchMemberBy.Visible = true;
            gb_SearchBookBy.Visible = false;

            rbn_SearchMemberBy_ID.Checked = true;
        }

        private void tb_S_SearchString_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rbn_S_SearchBookBy_Id.Checked || rbn_S_SearchBookBy_RackNo.Checked || rbn_SearchMemberBy_ID.Checked || rbn_SearchMemberrBy_Type.Checked)
            {
                if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    e.Handled = true;
            }
            else
            {
                if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                    e.Handled = true;
            }
        }

        ///////////////////////////////////////////////
        //    Searching for Book in Search TextBox   //
        ///////////////////////////////////////////////

        private void btn_S_Search_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tb_S_SearchString.Text))
            {
                MessageBox.Show("Please Enter Some String First to Search for...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(rbn_S_SearchBooks.Checked)
            {
                if(rbn_S_SearchBookBy_Id.Checked)
                {
                    if(rbn_S_SearchMethod_Exact.Checked)
                    {
                        dgv_S_SearchResult.DataSource = business.SearchBook_Scure("ByID_Exact", tb_S_SearchString.Text);
                    }
                    else
                    {
                        dgv_S_SearchResult.DataSource = business.SearchBook_Scure("ByID_Contain", tb_S_SearchString.Text);
                    }
                }
                else if(rbn_S_SearchBookBy_Title.Checked)
                {
                    if (rbn_S_SearchMethod_Exact.Checked)
                    {
                        dgv_S_SearchResult.DataSource = business.SearchBook_Scure("ByTitle_Exact", tb_S_SearchString.Text);
                    }
                    else
                    {
                        dgv_S_SearchResult.DataSource = business.SearchBook_Scure("ByTitle_Contain", tb_S_SearchString.Text);
                    }
                }
                else if(rbn_S_SearchBookBy_Publisher.Checked)
                {
                    if (rbn_S_SearchMethod_Exact.Checked)
                    {
                        dgv_S_SearchResult.DataSource = business.SearchBook_Scure("ByPublisher_Exact", tb_S_SearchString.Text);
                    }
                    else
                    {
                        dgv_S_SearchResult.DataSource = business.SearchBook_Scure("ByPublisher_Contain", tb_S_SearchString.Text);
                    }
                }
                else if(rbn_S_SearchBookBy_Author.Checked)
                {
                    if (rbn_S_SearchMethod_Exact.Checked)
                    {
                        dgv_S_SearchResult.DataSource = business.SearchBook_Scure("ByAuthor_Exact", tb_S_SearchString.Text);
                    }
                    else
                    {
                        dgv_S_SearchResult.DataSource = business.SearchBook_Scure("ByAuthor_Contain", tb_S_SearchString.Text);
                    }
                }
                else if(rbn_S_SearchBookBy_RackNo.Checked)
                {
                    dgv_S_SearchResult.DataSource = business.SearchBook_Scure("ByRackNo", tb_S_SearchString.Text);
                }
            }
            else if(rbn_S_SearchMembers.Checked)
            {
                if(rbn_SearchMemberBy_ID.Checked)
                {
                    if(rbn_S_SearchMethod_Exact.Checked)
                    {
                        dgv_S_SearchResult.DataSource = business.SearchMember_Scure("ByID_Exact", tb_S_SearchString.Text);
                    }
                    else if(rbn_S_SearchMethod_Contains.Checked)
                    {
                        dgv_S_SearchResult.DataSource = business.SearchMember_Scure("ByID_Contain", tb_S_SearchString.Text);
                    }
                }
                else if(rbn_SearchMemberBy_Name.Checked)
                {
                    if (rbn_S_SearchMethod_Exact.Checked)
                    {
                        dgv_S_SearchResult.DataSource = business.SearchMember_Scure("ByName_Exact", tb_S_SearchString.Text);
                    }
                    else if (rbn_S_SearchMethod_Contains.Checked)
                    {
                        dgv_S_SearchResult.DataSource = business.SearchMember_Scure("ByName_Contain", tb_S_SearchString.Text);
                    }
                }
                else if(rbn_SearchMemberrBy_Type.Checked)
                {
                    dgv_S_SearchResult.DataSource = business.SearchMember_Scure("ByType", tb_S_SearchString.Text);
                }
            }
        }

        //Clearing the TextBox SearchString      
        private void btn_S_Clear_Click(object sender, EventArgs e)
        {
            tb_S_SearchString.Clear();
            tb_S_SearchString.Focus();
        }

        ///////////////////////////////////////////////
        //        Deleting Selected Search Result    //
        ///////////////////////////////////////////////

        private void btn_S_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_S_SearchResult.SelectedRows.Count == 0)
            {
                MessageBox.Show("Must select Some Row First to Delete it...!", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Do you really want to Delete Selected Row From The DataBase?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if(result == DialogResult.Yes)
            {
                if(rbn_S_SearchBooks.Checked)
                {
                    Book book = new Book();
                    book.BookID = dgv_S_SearchResult.SelectedRows[0].Cells[0].Value.ToString();

                    if(business.DeleteBook_Scure(book)==1)
                    {
                        MessageBox.Show("Selected Book Records Deleted Successfully...!", "Records Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                
                    //Loading dgv_S_SearchResult Data again after Deleting Book to Refresh
                    dgv_S_SearchResult.DataSource = business.LoadBook_Scure();
                }
                else if(rbn_S_SearchMembers.Checked)
                {
                    Member member = new Member();
                    member.MemberID = dgv_S_SearchResult.SelectedRows[0].Cells[0].Value.ToString();

                    if(business.DeleteMember_Scure(member)==1)
                    {
                        MessageBox.Show("Selected Member Records Deleted Successfully...!", "Records Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    //Loading dgv_S_SearchResult Data again after Deleting Member to Refresh
                    dgv_S_SearchResult.DataSource = business.LoadMember_Scure();
                }
            }
            else
            {
                return;
            }
        }

        ///////////////////////////////////////////////
        //        Updating Selected Search Result    //
        ///////////////////////////////////////////////

        private void btn_S_Update_Click(object sender, EventArgs e)
        {
            if (dgv_S_SearchResult.SelectedRows.Count == 0)
            {
                MessageBox.Show("Must select Some Record First to Update it...!", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(rbn_S_SearchBooks.Checked)
            {
                Book book = new Book();

                book.BookID = dgv_S_SearchResult.SelectedRows[0].Cells[0].Value.ToString();
                book.Title = dgv_S_SearchResult.SelectedRows[0].Cells[1].Value.ToString();
                book.SubjectCode = dgv_S_SearchResult.SelectedRows[0].Cells[2].Value.ToString();
                book.Author = dgv_S_SearchResult.SelectedRows[0].Cells[3].Value.ToString();
                book.RackNo = dgv_S_SearchResult.SelectedRows[0].Cells[4].Value.ToString();
                book.Publisher = dgv_S_SearchResult.SelectedRows[0].Cells[5].Value.ToString();
                book.Price = Convert.ToDouble(dgv_S_SearchResult.SelectedRows[0].Cells[6].Value);

                (new f_Book("Update", book)).ShowDialog();

                //Loading dgv_S_SearchResult Data again after Deleting Book to Refresh
                dgv_S_SearchResult.DataSource = business.LoadBook_Scure();
            }
            else if(rbn_S_SearchMembers.Checked)
            {
                Member member = new Member();

                member.MemberID = dgv_S_SearchResult.SelectedRows[0].Cells[0].Value.ToString();
                member.Name = dgv_S_SearchResult.SelectedRows[0].Cells[1].Value.ToString();
                member.MemberType = dgv_S_SearchResult.SelectedRows[0].Cells[2].Value.ToString();
                member.MembershipIssueDate = dgv_S_SearchResult.SelectedRows[0].Cells[3].Value.ToString();
                member.MembershipExpiryDate =  dgv_S_SearchResult.SelectedRows[0].Cells[4].Value.ToString();
                member.Address = dgv_S_SearchResult.SelectedRows[0].Cells[5].Value.ToString();
                member.Contact = dgv_S_SearchResult.SelectedRows[0].Cells[6].Value.ToString();

                (new f_Member("Update", member)).ShowDialog();

                //Loading dgv_S_SearchResult Data again after Deleting Member to Refresh
                dgv_S_SearchResult.DataSource = business.LoadMember_Scure();
            }
        }

        ///////////////////////////////////////////////
        //  View Dedails of Selected Search Result   //
        ///////////////////////////////////////////////

        private void btn_S_ViewDetails_Click(object sender, EventArgs e)
        {
            if (dgv_S_SearchResult.SelectedRows.Count == 0)
            {
                MessageBox.Show("Must select Some Record First to View Details of it...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rbn_S_SearchBooks.Checked)
            {
                Book book = new Book();

                book.BookID = dgv_S_SearchResult.SelectedRows[0].Cells[0].Value.ToString();
                book.Title = dgv_S_SearchResult.SelectedRows[0].Cells[1].Value.ToString();
                book.SubjectCode = dgv_S_SearchResult.SelectedRows[0].Cells[2].Value.ToString();
                book.Author = dgv_S_SearchResult.SelectedRows[0].Cells[3].Value.ToString();
                book.RackNo = dgv_S_SearchResult.SelectedRows[0].Cells[4].Value.ToString();
                book.Publisher = dgv_S_SearchResult.SelectedRows[0].Cells[5].Value.ToString();
                book.Price = Convert.ToDouble(dgv_S_SearchResult.SelectedRows[0].Cells[6].Value);

                (new f_Book("ViewDetails", book)).ShowDialog();
            }
            else if (rbn_S_SearchMembers.Checked)
            {
                Member member = new Member();

                member.MemberID = dgv_S_SearchResult.SelectedRows[0].Cells[0].Value.ToString();
                member.Name = dgv_S_SearchResult.SelectedRows[0].Cells[1].Value.ToString();
                member.MemberType = dgv_S_SearchResult.SelectedRows[0].Cells[2].Value.ToString();
                member.MembershipIssueDate = dgv_S_SearchResult.SelectedRows[0].Cells[3].Value.ToString();
                member.MembershipExpiryDate = dgv_S_SearchResult.SelectedRows[0].Cells[4].Value.ToString();
                member.Address = dgv_S_SearchResult.SelectedRows[0].Cells[5].Value.ToString();
                member.Contact = dgv_S_SearchResult.SelectedRows[0].Cells[6].Value.ToString();

                (new f_Member("ViewDetails", member)).ShowDialog();
            }
        }

        ///////////////////////////////////////////////
        //        Issuing the Book to Member         //
        ///////////////////////////////////////////////

        private void btn_S_IssueBook_Click(object sender, EventArgs e)
        {
            if (dgv_S_SearchResult.SelectedRows.Count == 0)
            {
                MessageBox.Show("Must select Some Record First to Issue Book...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(rbn_S_SearchBooks.Checked)
            {
                //Checking Whether the Book is Issued to Some Member or Not
                if (!string.IsNullOrWhiteSpace(dgv_S_SearchResult.SelectedRows[0].Cells[7].Value.ToString())) 
                {
                    MessageBox.Show("The Selected Book Has Already been Issued to Some User...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Book book = new Book();
                book.BookID = dgv_S_SearchResult.SelectedRows[0].Cells[0].Value.ToString();

                (new f_Book2Member(book)).ShowDialog();
            }
            else if(rbn_S_SearchMembers.Checked)
            {
                //Verifing the Member's Membership Validity
                if (DateTime.Now >= Convert.ToDateTime(dgv_S_SearchResult.SelectedRows[0].Cells[4].Value))
                {
                    MessageBox.Show("Membership of Selected Member Expired...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Member member = new Member();

                member.MemberID = dgv_S_SearchResult.SelectedRows[0].Cells[0].Value.ToString();
                member.MembershipExpiryDate = dgv_S_SearchResult.SelectedRows[0].Cells[4].Value.ToString();

                (new f_Member2Book(member)).ShowDialog();
            }

            //Loading books Again After Issuing a Book to Some Memmber
            dgv_B_BookRecords.DataSource = business.LoadBook_Scure();
        }

        ///////////////////////////////////////////////
        //      Adding Functionality to Book Tab     //
        ///////////////////////////////////////////////

        ///////////////////////////////////////////////
        //    Deleting Selected Row From Database    //
        ///////////////////////////////////////////////

        private void btn_B_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_B_BookRecords.SelectedRows.Count == 0)
            {
                MessageBox.Show("Must select Some Row First to Delete it...!", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Do you really want to Delete Selected Row From The DataBase?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(result == DialogResult.Yes)
            {
                Book book = new Book();
                book.BookID = dgv_B_BookRecords.SelectedRows[0].Cells[0].Value.ToString();

                if (business.DeleteBook_Scure(book) == 1)
                {
                    MessageBox.Show("Selected Book Records Deleted Successfully...!", "Records Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //Loading dgv_B_BookRecords Data again after Deleting Book to Refresh
                dgv_B_BookRecords.DataSource = business.LoadBook_Scure();
            }
            else
            {
                return;
            }
        }

        ///////////////////////////////////////////////
        //        Updating Selected Book Records     //
        ///////////////////////////////////////////////

        private void btn_B_Update_Click(object sender, EventArgs e)
        {
            if (dgv_B_BookRecords.SelectedRows.Count == 0)
            {
                MessageBox.Show("Must select Some Row First to Update it...!", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Book book = new Book();

            book.BookID = dgv_B_BookRecords.SelectedRows[0].Cells[0].Value.ToString();
            book.Title = dgv_B_BookRecords.SelectedRows[0].Cells[1].Value.ToString();
            book.SubjectCode = dgv_B_BookRecords.SelectedRows[0].Cells[2].Value.ToString();
            book.Author = dgv_B_BookRecords.SelectedRows[0].Cells[3].Value.ToString();
            book.RackNo = dgv_B_BookRecords.SelectedRows[0].Cells[4].Value.ToString();
            book.Publisher = dgv_B_BookRecords.SelectedRows[0].Cells[5].Value.ToString();
            book.Price = Convert.ToDouble(dgv_B_BookRecords.SelectedRows[0].Cells[6].Value);

            (new f_Book("Update", book)).ShowDialog();

            //Loading dgv_B_BookRecords Data again after Updating Book to Refresh
            dgv_B_BookRecords.DataSource = business.LoadBook_Scure();
        }

        ///////////////////////////////////////////////
        //  View Dedails of Selected Book Records    //
        ///////////////////////////////////////////////

        private void btn_B_ViewDetails_Click(object sender, EventArgs e)
        {
            if (dgv_B_BookRecords.SelectedRows.Count == 0)
            {
                MessageBox.Show("Must select Some Record First to View Details of it...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Book book = new Book();

            book.BookID = dgv_B_BookRecords.SelectedRows[0].Cells[0].Value.ToString();
            book.Title = dgv_B_BookRecords.SelectedRows[0].Cells[1].Value.ToString();
            book.SubjectCode = dgv_B_BookRecords.SelectedRows[0].Cells[2].Value.ToString();
            book.Author = dgv_B_BookRecords.SelectedRows[0].Cells[3].Value.ToString();
            book.RackNo = dgv_B_BookRecords.SelectedRows[0].Cells[4].Value.ToString();
            book.Publisher = dgv_B_BookRecords.SelectedRows[0].Cells[5].Value.ToString();
            book.Price = Convert.ToDouble(dgv_B_BookRecords.SelectedRows[0].Cells[6].Value);

            (new f_Book("ViewDetails", book)).ShowDialog();
        }

        ///////////////////////////////////////////////
        //        Issuing the Book to Member         //
        ///////////////////////////////////////////////

        private void btn_B_IssueBook_Click(object sender, EventArgs e)
        {
            if (dgv_B_BookRecords.SelectedRows.Count == 0)
            {
                MessageBox.Show("Must select Some Record First to Issue Book...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Checking Whether the Book is Issued to Some Member or Not
            if (!string.IsNullOrWhiteSpace(dgv_B_BookRecords.SelectedRows[0].Cells[7].Value.ToString()))
            {
                MessageBox.Show("The Selected Book Has Already been Issued to Some User...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Book book = new Book();
            book.BookID = dgv_B_BookRecords.SelectedRows[0].Cells[0].Value.ToString();

            (new f_Book2Member(book)).ShowDialog();

            //Loading books Again After Issuing a Book to Refresh
            dgv_B_BookRecords.DataSource = business.LoadBook_Scure();
        }

        ///////////////////////////////////////////////
        //    Validating User Input From Textboxes   //
        ///////////////////////////////////////////////

        private void tb_B_BookID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tb_B_Title_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsSymbol(e.KeyChar))
                e.Handled = true;
        }

        private void tb_B_SubjectCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void tb_B_Author_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void tb_B_RackNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tb_B_Publisher_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void tb_B_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        //Saving the Book to The DataBase
        private void btn_B_Save_Click(object sender, EventArgs e)
        {
            Book book = new Book();

            if (!string.IsNullOrWhiteSpace(tb_B_BookID.Text) && !string.IsNullOrWhiteSpace(tb_B_Title.Text) && !string.IsNullOrWhiteSpace(tb_B_SubjectCode.Text) && !string.IsNullOrWhiteSpace(tb_B_Author.Text) && !string.IsNullOrWhiteSpace(tb_B_RackNo.Text) && !string.IsNullOrWhiteSpace(tb_B_Publisher.Text) && !string.IsNullOrWhiteSpace(tb_B_Price.Text))
            {
                book.BookID = tb_B_BookID.Text;
                book.Title = tb_B_Title.Text;
                book.SubjectCode = tb_B_SubjectCode.Text;
                book.Author = tb_B_Author.Text;
                book.RackNo = tb_B_RackNo.Text;
                book.Publisher = tb_B_Publisher.Text;
                book.Price = Convert.ToDouble(tb_B_Price.Text);

                if (business.AddBook_Scure(book) == 1)
                {
                    MessageBox.Show("New Book is Successfully Added to the Database...!", "New Admin Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tb_B_BookID.Clear();
                    tb_B_Title.Clear();
                    tb_B_SubjectCode.Clear();
                    tb_B_Author.Clear();
                    tb_B_RackNo.Clear();
                    tb_B_Publisher.Clear();
                    tb_B_Price.Clear();

                    tb_B_BookID.Focus();

                    dgv_B_BookRecords.DataSource = business.LoadBook_Scure();
                }
                else
                {
                    MessageBox.Show("Error During Insertion...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Firstly fill all the Blanks then Click Save...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_B_Clear_Click(object sender, EventArgs e)
        {
            tb_B_BookID.Clear();
            tb_B_Title.Clear();
            tb_B_SubjectCode.Clear();
            tb_B_Author.Clear();
            tb_B_RackNo.Clear();
            tb_B_Publisher.Clear();
            tb_B_Price.Clear();

            tb_B_BookID.Focus();
        }

        ///////////////////////////////////////////////
        //      Adding Functionality to Member Tab   //
        ///////////////////////////////////////////////

        ///////////////////////////////////////////////
        //       Delete Button to Delete Member      //
        ///////////////////////////////////////////////

        private void btn_M_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_M_MemberRecords.SelectedRows.Count == 0)
            {
                MessageBox.Show("Must select Some Row First to Delete it...!", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Do you really want to Delete Selected Row From The DataBase?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Member member = new Member();
                member.MemberID = dgv_M_MemberRecords.SelectedRows[0].Cells[0].Value.ToString();

                if (business.DeleteMember_Scure(member) == 1)
                {
                    MessageBox.Show("Selected Member Records Deleted Successfully...!", "Records Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //Loading dgv_M_MemberRecords Data again after Deleting Member to Refresh
                dgv_M_MemberRecords.DataSource = business.LoadMember_Scure();
            }
            else
            {
                return;
            }
        }

        ///////////////////////////////////////////////
        //       Update Button to Update Member      //
        ///////////////////////////////////////////////

        private void btn_M_Update_Click(object sender, EventArgs e)
        {
            if (dgv_M_MemberRecords.SelectedRows.Count == 0)
            {
                MessageBox.Show("Must select Some Row First to Update it...!", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Member member = new Member();

            member.MemberID = dgv_M_MemberRecords.SelectedRows[0].Cells[0].Value.ToString();
            member.Name = dgv_M_MemberRecords.SelectedRows[0].Cells[1].Value.ToString();
            member.MemberType = dgv_M_MemberRecords.SelectedRows[0].Cells[2].Value.ToString();
            member.MembershipIssueDate = dgv_M_MemberRecords.SelectedRows[0].Cells[3].Value.ToString();
            member.MembershipExpiryDate = dgv_M_MemberRecords.SelectedRows[0].Cells[4].Value.ToString();
            member.Address = dgv_M_MemberRecords.SelectedRows[0].Cells[5].Value.ToString();
            member.Contact = dgv_M_MemberRecords.SelectedRows[0].Cells[6].Value.ToString();

            (new f_Member("Update", member)).ShowDialog();

            //Loading dgv_M_MemberRecords Data again after Updating Book to Refresh
            dgv_M_MemberRecords.DataSource = business.LoadMember_Scure();
        }

        ///////////////////////////////////////////////
        // View Details Button to View Member Details//
        ///////////////////////////////////////////////

        private void btn_M_ViewDetails_Click(object sender, EventArgs e)
        {
            if (dgv_M_MemberRecords.SelectedRows.Count == 0)
            {
                MessageBox.Show("Must select Some Record First to View Details of it...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Member member = new Member();

            member.MemberID = dgv_M_MemberRecords.SelectedRows[0].Cells[0].Value.ToString();
            member.Name = dgv_M_MemberRecords.SelectedRows[0].Cells[1].Value.ToString();
            member.MemberType = dgv_M_MemberRecords.SelectedRows[0].Cells[2].Value.ToString();
            member.MembershipIssueDate = dgv_M_MemberRecords.SelectedRows[0].Cells[3].Value.ToString();
            member.MembershipExpiryDate = dgv_M_MemberRecords.SelectedRows[0].Cells[4].Value.ToString();
            member.Address = dgv_M_MemberRecords.SelectedRows[0].Cells[5].Value.ToString();
            member.Contact = dgv_M_MemberRecords.SelectedRows[0].Cells[6].Value.ToString();

            (new f_Member("ViewDetails", member)).ShowDialog();
        }

        ///////////////////////////////////////////////
        //        Issuing the Book to Member         //
        ///////////////////////////////////////////////

        private void btn_M_IssueBook_Click(object sender, EventArgs e)
        {
            if (dgv_M_MemberRecords.SelectedRows.Count == 0)
            {
                MessageBox.Show("Must select Some Record First to Issue Book...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            //Verifing the Member's Membership Validity
            if (DateTime.Now >= Convert.ToDateTime(dgv_M_MemberRecords.SelectedRows[0].Cells[4].Value))
            {
                MessageBox.Show("Membership of Selected Member Expired...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Member member = new Member();
            member.MemberID = dgv_M_MemberRecords.SelectedRows[0].Cells[0].Value.ToString();
            member.MembershipExpiryDate = dgv_M_MemberRecords.SelectedRows[0].Cells[4].Value.ToString();

            (new f_Member2Book(member)).ShowDialog();
        }

        ///////////////////////////////////////////////
        //   Validating User Inpput From Textboxes   //
        ///////////////////////////////////////////////

        private void tb_M_MemberID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tb_M_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void tb_M_MemberType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tb_M_Address_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void tb_M_Contact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        ///////////////////////////////////////////////
        //      Saving Member Records to Database    //
        ///////////////////////////////////////////////

        private void btn_M_Save_Click(object sender, EventArgs e)
        {
            Member member = new Member();

            if (!string.IsNullOrWhiteSpace(tb_M_MemberID.Text) && !string.IsNullOrWhiteSpace(tb_M_Name.Text) && !string.IsNullOrWhiteSpace(tb_M_MemberType.Text) && !string.IsNullOrWhiteSpace(tb_M_Address.Text) && !string.IsNullOrWhiteSpace(tb_M_Contact.Text))
            {
                member.MemberID = tb_M_MemberID.Text;
                member.Name = tb_M_Name.Text;
                member.MemberType = tb_M_MemberType.Text;
                member.MembershipIssueDate = DateTime.Now.ToString("yyyy-MM-dd");
                member.MembershipExpiryDate = dtp_M_Expiry.Value.ToString("yyyy-MM-dd");
                member.Address = tb_M_Address.Text;
                member.Contact = tb_M_Contact.Text;

                if (business.AddMember_Scure(member) == 1)
                {
                    MessageBox.Show("New Member is Successfully Added to the Database...!", "New Admin Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tb_M_MemberID.Clear();
                    tb_M_Name.Clear();
                    tb_M_MemberType.Clear();
                    tb_M_Address.Clear();
                    tb_M_Contact.Clear();
                    dtp_M_Expiry.Value = DateTime.Now;

                    tb_M_MemberID.Focus();

                    dgv_M_MemberRecords.DataSource = business.LoadMember_Scure(); 
                }
                else
                {
                    MessageBox.Show("Error During Insertion...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Firstly fill all the Blanks then Click Save...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_M_Clear_Click(object sender, EventArgs e)
        {
            tb_M_MemberID.Clear();
            tb_M_Name.Clear();
            tb_M_MemberType.Clear();
            tb_M_Address.Clear();
            tb_M_Contact.Clear();
            dtp_M_Expiry.Value = DateTime.Now;

            tb_M_MemberID.Focus();
        }

        ///////////////////////////////////////////////
        //  Adding Functionality to Issue/Accept Tab //
        ///////////////////////////////////////////////

        ///////////////////////////////////////////////
        //            Radio Button Setting           //
        ///////////////////////////////////////////////

        private void rbn_IA_Issued_CheckedChanged(object sender, EventArgs e)
        {
            gb_IssueBook.Visible = false;
            gb_AcceptBook.Visible = true;

            rbn_IA_A_BookId.Checked = true;

            dgv_IA.DataSource = business.LoadIssuedBook_Scure();
        }

        private void rbn_IA_NonIssued_CheckedChanged(object sender, EventArgs e)
        {
            gb_AcceptBook.Visible = false;
            gb_IssueBook.Visible = true;

            rbn_IA_I_BookId.Checked = true;

            dgv_IA.DataSource = business.LoadNonIssuedBook_Scure();
        }

        ///////////////////////////////////////////////
        //            Validating User Input          //
        ///////////////////////////////////////////////

        private void tb_IA_A_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        //Accepting A Book 
        private void btn_IA_A_Search_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(tb_IA_A_Search.Text))
            {
                MessageBox.Show("Please Enter Some String First to Search for...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(rbn_IA_A_BookId.Checked)
            {
                dgv_IA.DataSource = business.SearchIssuedBook_Scure("ByBookID", tb_IA_A_Search.Text);
            }
            else if(rbn_IA_A_MemberId.Checked)
            {
                dgv_IA.DataSource = business.SearchIssuedBook_Scure("ByMemberID", tb_IA_A_Search.Text);
            }
        }

        private void btn_IA_A_Clear_Click(object sender, EventArgs e)
        {
            tb_IA_A_Search.Clear();
            tb_IA_A_Search.Focus();
        }

        private void btn_IA_A_AcceptBook_Click(object sender, EventArgs e)
        {
            if(dgv_IA.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please Select Some Record First to Accept a Book...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Book book = new Book();
            book.BookID = dgv_IA.SelectedRows[0].Cells[0].Value.ToString();

            (new f_AcceptBook(book)).ShowDialog();

            dgv_IA.DataSource = business.LoadIssuedBook_Scure();
        }

        //Issuing A Book
        private void tb_IA_I_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void btn_IA_I_Search_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tb_IA_I_Search.Text))
            {
                MessageBox.Show("Please Enter Some String First to Search for...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rbn_IA_I_BookId.Checked)
            {
                dgv_IA.DataSource = business.SearchNonIssuedBook_Scure("ByBookID", tb_IA_I_Search.Text);
            }
            else if (rbn_IA_I_BookName.Checked)
            {
                dgv_IA.DataSource = business.SearchNonIssuedBook_Scure("ByTitle", tb_IA_I_Search.Text);
            }
        }

        private void btn_IA_I_Clear_Click(object sender, EventArgs e)
        {
            tb_IA_I_Search.Clear();
            tb_IA_I_Search.Focus();
        }

        private void btn_IA_I_IssueBook_Click(object sender, EventArgs e)
        {
            if (dgv_IA.SelectedRows.Count == 0)
            {
                MessageBox.Show("Must select Some Record First to Issue Book...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Book book = new Book();
            book.BookID = dgv_IA.SelectedRows[0].Cells[0].Value.ToString();

            (new f_Book2Member(book)).ShowDialog();

            //Loading books Again After Issuing a Book to Refresh
            dgv_B_BookRecords.DataSource = business.LoadBook_Scure();
        }

        ///////////////////////////////////////////////
        // Adding Functionality to File Menu Strip   //
        ///////////////////////////////////////////////

        private void fts_About_Click(object sender, EventArgs e)
        {
            (new f_About()).ShowDialog();
        }

        private void fts_LogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}