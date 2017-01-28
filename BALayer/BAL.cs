using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using BELayer;
using DALayer;

namespace BALayer
{
    public class BAL
    {
        private DAL dataAccess = new DAL();

        /////////////////////////////////////////////////////////////////////////////////////////
        //       List Of FUNCTIONS Available in BAL Class to Manipulate with LMS Database      //
        /////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////
        //AddAdmin_Scure(Administrator admin)
        //UpdateAdmin_Scure(Administrator admin)
        //DeleteAdmin_Scure(Administrator admin)
        //////////////////////////
        //    Admin QUERIES     //
        //////////////////////////
        //LoadAdmin_Scure()
        ///////////////////////////////////

        ///////////////////////////////////
        //AddBook_Scure(Book myBook)
        //UpdateBook_Scure(Book myBook)
        //DeleteBook_Scure(Book myBook)
        //////////////////////////
        //    BOOK QUERIES      //
        //////////////////////////
        //LoadBook_Scure()
        //LoadIssuedBooks_Scure()
        //SearchBook_Scure()
        //SearchIssuedBook_Scure()
        ///////////////////////////////////

        ///////////////////////////////////
        //AddMember_Scure(Member aMember)
        //UpdateMember_Scure(Member aMember)
        //DeleteMember_Scure(Member aMember)
        //////////////////////////
        //    MEMBER QUERIES    //
        //////////////////////////
        //LoadMember_Scure()
        //LoadIssuedMembers_Scure()
        //SearchMember_Scure()
        ///////////////////////////////////

        ///////////////////////////////////
        //IssueBook_Scure(StatusOfIssue IssueStatus)
        //ReturnStatus_Scure(StatusOfReturn returnStatus)
        ///////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////
        //      Defining Functions which we will use to Access Admin Table of DataBase LMS     //
        /////////////////////////////////////////////////////////////////////////////////////////

        //Funtion AddAdmin_Scure() to Add new Admin to Database in Scure Way
        public int AddAdmin_Scure(Administrator admin)
        {
            int check = 0;

            try
            {
                check = dataAccess.AddAdmin(admin);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataAccess.closeConnection();
            }

            return check;
            /////////////////////////////////////////////////////////////////////////////////////        
        }

        //Funtion UpdateAdmin_Scure() to Update Existing Admin to Database in Scure Way
        public int UpdateAdmin_Scure(Administrator admin)
        {
            int check = 0;

            try
            {
                check = dataAccess.UpdateAdmin(admin);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataAccess.closeConnection();
            }

            return check;
            /////////////////////////////////////////////////////////////////////////////////////        
        }

        //Funtion DeleteAdmin_Scure() to Delete an Admin to Database in Scure Way
        public int DeleteAdmin_Scure(Administrator admin)
        {
            int check = 0;

            try
            {
                check = dataAccess.DeleteAdmin(admin);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataAccess.closeConnection();
            }

            return check;
            /////////////////////////////////////////////////////////////////////////////////////        
        }

        //////////////////////////
        //    Admin QUERIES     //
        //////////////////////////

        //Function LoadAdmin_Scure() to Load all Admin Records from Database in Scure way
        public DataTable LoadAdmin_Scure()
        {
            DataTable table = new DataTable();

            try
            {
                table = dataAccess.LoadAdmin();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return table;
            /////////////////////////////////////////////////////////////////////////////////////        
        }

        //Function Login_Scure() to Allow a Admin to login into the LMS
        public bool Login_Scure(Administrator admin)
        {
            bool check = false;

            try
            {
                check = dataAccess.Login(admin);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataAccess.closeConnection();
            }

            return check;
            /////////////////////////////////////////////////////////////////////////////////////        
        }

        /////////////////////////////////////////////////////////////////////////////////////////
        //      Defining Functions which we will use to Access Book  Table of DataBase LMS     //
        /////////////////////////////////////////////////////////////////////////////////////////

        //Funtion AddBook_Scure() to Add new Book to Database in Scure Way
        public int AddBook_Scure(Book book)
        {
            int check = 0;

            try
            {
                check = dataAccess.AddBook(book);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataAccess.closeConnection();
            }

            return check;
            /////////////////////////////////////////////////////////////////////////////////////        
        }

        //Funtion UpdateBook_Scure() to Update Existing Book to Database in Scure Way
        public int UpdateBook_Scure(Book book)
        {
            int check = 0;

            try
            {
                check = dataAccess.UpdateBook(book);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataAccess.closeConnection();
            }

            return check;
            /////////////////////////////////////////////////////////////////////////////////////        
        }

        //Funtion DeleteBook_Scure() to Delete a Book to Database in Scure Way
        public int DeleteBook_Scure(Book book)
        {
            int check = 0;

            try
            {
                check = dataAccess.DeleteBook(book);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataAccess.closeConnection();
            }

            return check;
            /////////////////////////////////////////////////////////////////////////////////////        
        }

        //////////////////////////
        //    BOOK QUERIES      //
        //////////////////////////

        //Function LoadBook_Scure() to Load all Book Records from Database in Scure way
        public DataTable LoadBook_Scure()
        {
            DataTable table = new DataTable();

            try
            {
                table = dataAccess.LoadBook();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return table;
            /////////////////////////////////////////////////////////////////////////////////////        
        }

        //Function LoadIssuedBook_Scure() to Load all Issued Book Records from Database in Scure way
        public DataTable LoadIssuedBook_Scure()
        {
            DataTable table = new DataTable();

            try
            {
                table = dataAccess.LoadIssuedBook();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return table;
            /////////////////////////////////////////////////////////////////////////////////////        
        }

        //Function LoadNonIssuedBook_Scure() to Load all Issued Book Records from Database in Scure way
        public DataTable LoadNonIssuedBook_Scure()
        {
            DataTable table = new DataTable();

            try
            {
                table = dataAccess.LoadNonIssuedBook();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return table;
            /////////////////////////////////////////////////////////////////////////////////////        
        }

        //Function SearchBook_Scure() to search for a Particular book or a Group of Books
        public DataTable SearchBook_Scure(string searchBy, string searchString)
        {
            DataTable table = new DataTable();

            switch (searchBy)
            {
                case "ByID_Exact":

                    try
                    {
                        table = dataAccess.SearchBookByID_Exact(searchString);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

                case "ByTitle_Exact":

                    try
                    {
                        table = dataAccess.SearchBookByTitle_Exact(searchString);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

                case "ByPublisher_Exact":

                    try
                    {
                        table = dataAccess.SearchBookByPublisher_Exact(searchString);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

                case "ByAuthor_Exact":

                    try
                    {
                        table = dataAccess.SearchBookByAuthor_Exact(searchString);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

                case "ByID_Contain":

                    try
                    {
                        table = dataAccess.SearchBookByID_Contain(searchString);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

                case "ByTitle_Contain":

                    try
                    {
                        table = dataAccess.SearchBookByTitle_Contain(searchString);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

                case "ByPublisher_Contain":

                    try
                    {
                        table = dataAccess.SearchBookByPublisher_Contain(searchString);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

                case "ByAuthor_Contain":

                    try
                    {
                        table = dataAccess.SearchBookByAuthor_Contain(searchString);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

                case "ByRackNo":

                    try
                    {
                        table = dataAccess.SearchBookByRackNo(searchString);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

                default:

                    MessageBox.Show("Search Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    break;
            }

            return table;
            /////////////////////////////////////////////////////////////////////////////////////        
        }

        //Function SearchIssuedBook_Scure() to search for a Particular book or a Group of Books
        public DataTable SearchIssuedBook_Scure(string searchBy, string searchString)
        {
            DataTable table = new DataTable();

            switch (searchBy)
            {
                case "ByBookID":

                    try
                    {
                        table = dataAccess.SearchIssuedBookByBID(searchString);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

                case "ByMemberID":

                    try
                    {
                        table = dataAccess.SearchIssuedBookByMID(searchString);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

                default:

                    MessageBox.Show("Search Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    break;
            }

            return table;
            /////////////////////////////////////////////////////////////////////////////////////        
        }

        //Function SearchNonIssuedBook_Scure() to search for a Particular book or a Group of Books
        public DataTable SearchNonIssuedBook_Scure(string searchBy, string searchString)
        {
            DataTable table = new DataTable();

            switch (searchBy)
            {
                case "ByBookID":

                    try
                    {
                        table = dataAccess.SearchNonIssuedBookByBID(searchString);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

                case "ByTitle":

                    try
                    {
                        table = dataAccess.SearchNonIssuedBookByTitle(searchString);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

                default:

                    MessageBox.Show("Search Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    break;
            }

            return table;
            /////////////////////////////////////////////////////////////////////////////////////        
        }

        /////////////////////////////////////////////////////////////////////////////////////////
        //      Defining Functions which we will use to Access Member Table of DataBase LMS    //
        /////////////////////////////////////////////////////////////////////////////////////////

        //Funtion AddMember_Scure() to Add new Member to Database in Scure Way
        public int AddMember_Scure(Member member)
        {
            int check = 0;

            try
            {
                check = dataAccess.AddMember(member);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataAccess.closeConnection();
            }

            return check;
            /////////////////////////////////////////////////////////////////////////////////////        
        }

        //Funtion UpdateMember_Scure() to Update Existing Member to Database in Scure Way
        public int UpdateMember_Scure(Member member)
        {
            int check = 0;

            try
            {
                check = dataAccess.UpdateMember(member);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataAccess.closeConnection();
            }

            return check;
            /////////////////////////////////////////////////////////////////////////////////////        
        }

        //Funtion DeleteMember_Scure() to Delete a Member to Database in Scure Way
        public int DeleteMember_Scure(Member member)
        {
            int check = 0;

            try
            {
                check = dataAccess.DeleteMember(member);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataAccess.closeConnection();
            }

            return check;
            /////////////////////////////////////////////////////////////////////////////////////        
        }

        //////////////////////////
        //    Member QUERIEs    //
        //////////////////////////

        //Function LoadMember_Scure() to Load all Members Records from Database in Scure way
        public DataTable LoadMember_Scure()
        {
            DataTable table = new DataTable();

            try
            {
                table = dataAccess.LoadMember();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return table;
            /////////////////////////////////////////////////////////////////////////////////////        
        }

        //Function LoadIssuedMember_Scure() to Load all Issued Members Records from Database in Scure way
        public DataTable LoadIssuedMember_Scure()
        {
            DataTable table = new DataTable();

            try
            {
                table = dataAccess.LoadIssuedMember();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return table;
            /////////////////////////////////////////////////////////////////////////////////////        
        }

        //Function SearchBook_Scure() to search for a Particular book or a Group of Books
        public DataTable SearchMember_Scure(string searchBy, string searchString)
        {
            DataTable table = new DataTable();

            switch (searchBy)
            {
                case "ByID_Exact":

                    try
                    {
                        table = dataAccess.SearchMemberByID_Exact(searchString);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

                case "ByName_Exact":

                    try
                    {
                        table = dataAccess.SearchMemberByName_Exact(searchString);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

                case "ByID_Contain":

                    try
                    {
                        table = dataAccess.SearchMemberByID_Contain(searchString);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

                case "ByName_Contain":

                    try
                    {
                        table = dataAccess.SearchMemberByName_Contain(searchString);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

                case "ByType":

                    try
                    {
                        table = dataAccess.SearchMemberByType(searchString);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

                default:

                    MessageBox.Show("Search Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    break;
            }

            return table;
            /////////////////////////////////////////////////////////////////////////////////////        
        }

        /////////////////////////////////////////////////////////////////////////////////////////
        //     Defining Functions to Manipulate the StatusOfIssue Table of DataBase LMS        //
        /////////////////////////////////////////////////////////////////////////////////////////

        public int IssueBook_Scure(StatusOfIssue issueStatus)
        {
            int check = 0;

            try
            {
                check = dataAccess.IssueBook(issueStatus);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataAccess.closeConnection();
            }

            return check;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        /////////////////////////////////////////////////////////////////////////////////////////
        //                         Load Book Issue Status' Records                             //
        /////////////////////////////////////////////////////////////////////////////////////////
       
        public DataTable LoadIssueStatus_Scure()
        {
            DataTable table = new DataTable();

            try
            {
                table = dataAccess.LoadIssueStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return table;
        }

        /////////////////////////////////////////////////////////////////////////////////////////
        //                       Search Book Issue Status' Records                             //
        /////////////////////////////////////////////////////////////////////////////////////////

        public DataTable SearchIssueStatus_Scure(string searchBy, string searchString)
        {
            DataTable table = new DataTable();

            switch (searchBy)
            {
                case "ByBookID":

                    try
                    {
                        table = dataAccess.SearchIssueStatusByBID(searchString);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

                case "ByMemberID":

                    try
                    {
                        table = dataAccess.SearchIssueStatusByMID(searchString);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

                default:

                    MessageBox.Show("Search Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    break;
            }

            return table;
            /////////////////////////////////////////////////////////////////////////////////////        
        }

        /////////////////////////////////////////////////////////////////////////////////////////
        //     Defining Functions to Manipulate the StatusOfReturn Table of DataBase LMS       //
        /////////////////////////////////////////////////////////////////////////////////////////

        public int ReturnBook_Scure(StatusOfReturn returnStatus)
        {
            int check = 0;

            try
            {
                check = dataAccess.ReturnBook(returnStatus);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataAccess.closeConnection();
            }

            return check;
            /////////////////////////////////////////////////////////////////////////////////////        
        }
    }
}