using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BELayer;

namespace DALayer
{
    public class DAL
    {
        //Declaring Private SqlConnenction Object to Manipulate with the DataBase
        private SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LibraryManagementSystem.Properties.Settings.dbConnectionString"].ConnectionString);
        
        public void closeConnection()
        {
            connection.Close();
        }

        /////////////////////////////////////////////////////////////////////////////////////////
        //       List Of FUNCTIONS Available in DAL Class to Manipulate with LMS Database      //
        /////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////
        //AddAdmin(Administrator admin)
        //UpdateAdmin(Administrator admin)
        //DeleteAdmin(Administrator admin)
        //////////////////////////
        //    Admin QUERIES     //
        //////////////////////////
        //LoadAdmin()
        //Login()
        ///////////////////////////////////

        ///////////////////////////////////
        //AddBook(Book myBook)
        //UpdateBook(Book myBook)
        //DeleteBook(Book myBook)
        //////////////////////////
        //    BOOK QUERIES      //
        //////////////////////////
        //LoadBook()
        //LoadIssuedBooks()
        //LoadNonIssuedBooks()
        //SearchBookByCategory()
        //--------------------------------
        //SearchBookByID_Exact()
        //SearchBookByTitle_Exact()
        //SearchBookByPublisher_Exact()
        //SearchBookByAuthor_Exact()
        //--------------------------------
        //SearchBookByID_Cantains()
        //SearchBookByTitle_Contains()
        //SearchBookByPublisher_Contains()
        //SearchBookByAuthor_Contains()
        //--------------------------------
        //SearchIssuedBookByBID()
        //SearchIssuedBookByMID()
        ///////////////////////////////////

        ///////////////////////////////////
        //AddMember(Member aMember)
        //UpdateMember(Member aMember)
        //DeleteMember(Member aMember)
        //////////////////////////
        //    MEMBER QUERIES    //
        //////////////////////////
        //LoadMember()
        //LoadIssuedMembers()
        //SearchMemberByType()
        //--------------------------------
        //SearchMemberByID_Exact()
        //SearchMemberByName_Exact()
        //--------------------------------
        //SearchMemberByID_Contains()
        //SearchMemberByName_Contains()
        ///////////////////////////////////

        ///////////////////////////////////
        //IssueBook(StatusOfIssue IssueStatus)
        //LoadIssueStatus()
        //ReturnStatus(StatusOfReturn returnStatus)
        ///////////////////////////////////


        /////////////////////////////////////////////////////////////////////////////////////////
        // Defining Functions which we will use to Manipulate with Admin Table of DataBase LMS //
        /////////////////////////////////////////////////////////////////////////////////////////

        //Function AddAdmin() to Add a New Admin to DataBase
        public int AddAdmin(Administrator admin)
        {
            int check1;
            int check2;
            int check3;

            connection.Open();

            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandType = CommandType.Text;

            //Inserting Admin.(AdminID, Name, UserName, Password) in Administrator Table
            insertCommand.CommandText = "INSERT INTO Administrator VALUES(@AdminID1, @Name, @UserName, @Password)";

            insertCommand.Parameters.AddWithValue("@AdminID1", admin.AdminID);
            insertCommand.Parameters.AddWithValue("@Name", admin.Name);
            insertCommand.Parameters.AddWithValue("@UserName", admin.UserName);
            insertCommand.Parameters.AddWithValue("@Password", admin.UserPassword);

            check1 = insertCommand.ExecuteNonQuery();

            //Inserting Admin.(AdminID, Contact) in ContactNo Table 
            insertCommand.CommandText = "INSERT INTO ContactNo(adminID, theContactNo) VALUES(@AdminID2, @ContactNo)";

            insertCommand.Parameters.AddWithValue("@AdminID2", admin.AdminID);
            insertCommand.Parameters.AddWithValue("@ContactNo", admin.Contact);

            check2 = insertCommand.ExecuteNonQuery();

            //Inserting Admin.(AdminID, Address) in Address Table 
            insertCommand.CommandText = "INSERT INTO Address(adminID, theAddress) VALUES(@AdminID3, @Address)";

            insertCommand.Parameters.AddWithValue("@AdminID3", admin.AdminID);
            insertCommand.Parameters.AddWithValue("@Address", admin.Address);

            check3 = insertCommand.ExecuteNonQuery();

            connection.Close();

            return (check1 > 0 && check2 > 0 && check3 > 0) ? 1 : 0;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Function UpdateAdmin() to Change the Password of Existing Admin
        public int UpdateAdmin(Administrator admin)
        {
            int check1;

            connection.Open();

            SqlCommand updateCommand = new SqlCommand();
            updateCommand.Connection = connection;
            updateCommand.CommandType = CommandType.Text;

            //Updating Admin.Password in Administrator Table
            updateCommand.CommandText = @"UPDATE Administrator 
                                        SET userPassword = @UserPassword
                                        WHERE userName = @UserName";

            updateCommand.Parameters.AddWithValue("@UserPassword", admin.UserPassword);
            updateCommand.Parameters.AddWithValue("@UserName", admin.UserName);

            check1 = updateCommand.ExecuteNonQuery();

            connection.Close();

            return (check1 > 0) ? 1 : 0;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Function UpdateAdmin() to Change the Password of Existing Admin
        public int DeleteAdmin(Administrator admin)
        {
            int check1;
            int check2;
            int check3;

            connection.Open();

            SqlCommand deleteCommand = new SqlCommand();
            deleteCommand.Connection = connection;
            deleteCommand.CommandType = CommandType.Text;

            //Deleting Admin.(AdminID, Contact) from , Contact Table
            deleteCommand.CommandText = @"DELETE 
                                          FROM ContactNo 
                                          WHERE adminID = @AdminID1";

            deleteCommand.Parameters.AddWithValue("@AdminID1", admin.AdminID);

            check1 = deleteCommand.ExecuteNonQuery();

            //Deleting Admin.(AdminID, Address) from , Addresss Table
            deleteCommand.CommandText = @"DELETE 
                                          FROM Address 
                                          WHERE adminID = @AdminID2";

            deleteCommand.Parameters.AddWithValue("@AdminID2", admin.AdminID);

            check2 = deleteCommand.ExecuteNonQuery();

            //Deleting Admin.(AdminID, Name, UserName, Password) from Administrator Table
            deleteCommand.CommandText = @"DELETE 
                                          FROM Administrator 
                                          WHERE adminID = @AdminID3";

            deleteCommand.Parameters.AddWithValue("@AdminID3", admin.AdminID);

            check3 = deleteCommand.ExecuteNonQuery();

            connection.Close();

            return (check1 > 0 && check2 > 0 && check3 > 0) ? 1 : 0;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //////////////////////////
        //    Admin QUERIES     //
        //////////////////////////

        //Function LoadAdmin() to Load All Records of Admin 
        public DataTable LoadAdmin()
        {
            DataTable admin = new DataTable();
            SqlCommand loadCommand = new SqlCommand();
            loadCommand.Connection = connection;
            loadCommand.CommandType = CommandType.Text;
            loadCommand.CommandText = @"SELECT Administrator.adminID AS [Admin ID], name AS Name, theAddress AS Address, theContactNo AS [Phone No], userName AS [User Name]
                                        FROM Administrator JOIN Address
                                        ON
                                        Administrator.adminID = Address.adminID JOIN ContactNo
                                        ON 
                                        Address.adminID = ContactNo.adminID";

            SqlDataAdapter adapter = new SqlDataAdapter(loadCommand);
            adapter.Fill(admin);

            return admin;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        public bool Login(Administrator admin)
        {
            bool check;
            DataTable table = new DataTable();

            SqlCommand loginCommand = new SqlCommand();
            loginCommand.Connection = connection;
            loginCommand.CommandType = CommandType.Text;
            loginCommand.CommandText = @"SELECT adminID 
                                      FROM Administrator
                                      WHERE userName = @UserName AND userPassword = @Password";

            loginCommand.Parameters.AddWithValue("@UserName", admin.UserName);
            loginCommand.Parameters.AddWithValue("@Password", admin.UserPassword);

            SqlDataAdapter adapter = new SqlDataAdapter(loginCommand);
            adapter.Fill(table);

            if (table.Rows.Count > 0)
                check = true;
            else
                check = false;

            return check;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        /////////////////////////////////////////////////////////////////////////////////////////
        // Defining Functions which we will use to Manipulate with Book Table of DataBase LMS  //
        /////////////////////////////////////////////////////////////////////////////////////////

        //Function AddBook() to Add a New Book to DataBase
        public int AddBook(Book myBook)
        {
            int check1;
            int check2;
            int check3;

            connection.Open();

            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandType = CommandType.Text;

            //Inserting Book.(BookID, Title, SubjectCode, Price, RackNo) in Table Book
            insertCommand.CommandText = "INSERT INTO Book(bookID, title, subjectCode, price, rackNo) VALUES(@BookID1, @Title, @SubjectCode, @Price, @RackNo)";

            insertCommand.Parameters.AddWithValue("@BookID1", myBook.BookID);
            insertCommand.Parameters.AddWithValue("@Title", myBook.Title);
            insertCommand.Parameters.AddWithValue("@SubjectCode", myBook.SubjectCode);
            insertCommand.Parameters.AddWithValue("@Price", myBook.Price);
            insertCommand.Parameters.AddWithValue("@RackNo", myBook.RackNo);

            check1 = insertCommand.ExecuteNonQuery();

            //Inserting Book.(BookID, PublisherName) in Table Publisher
            insertCommand.CommandText = "INSERT INTO Publisher(bookID, name) VALUES(@BookID2, @Publisher)";

            insertCommand.Parameters.AddWithValue("@BookID2", myBook.BookID);
            insertCommand.Parameters.AddWithValue("@Publisher", myBook.Publisher);

            check2 = insertCommand.ExecuteNonQuery();

            //Inserting Book.(BookID, AuthorNAme) in Table Author
            insertCommand.CommandText = "INSERT INTO Author(bookID, authorName) VALUES(@BookID3, @Author)";

            insertCommand.Parameters.AddWithValue("@BookID3", myBook.BookID);
            insertCommand.Parameters.AddWithValue("@Author", myBook.Author);

            check3 = insertCommand.ExecuteNonQuery();

            connection.Close();

            return (check1 > 0 && check2 > 0 && check3 > 0) ? 1 : 0;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Function UpdateBook() to Change the Details of a Book
        public int UpdateBook(Book myBook)
        {
            int check1;
            int check2;
            int check3;

            connection.Open();

            SqlCommand updateCommand = new SqlCommand();
            updateCommand.Connection = connection;
            updateCommand.CommandType = CommandType.Text;

            //Updating Book.(Title, SubjectCode, Price, RackNo) in Book Table
            updateCommand.CommandText = @"UPDATE Book
                                        SET title = @Title
                                        , subjectCode = @SubjectCode
                                        , price = @Price
                                        , rackNo = @RackNo
                                        WHERE bookID = @bookID1";

            updateCommand.Parameters.AddWithValue("@Title", myBook.Title);
            updateCommand.Parameters.AddWithValue("@SubjectCode", myBook.SubjectCode);
            updateCommand.Parameters.AddWithValue("@Price", myBook.Price);
            updateCommand.Parameters.AddWithValue("@RackNo", myBook.RackNo);
            updateCommand.Parameters.AddWithValue("@BookID1", myBook.BookID);

            check1 = updateCommand.ExecuteNonQuery();

            //Updating Book.(AuthorName) in Author Table
            updateCommand.CommandText = @"UPDATE Author
                                        SET authorName = @AuthorName
                                        WHERE BookID = @BookID2";

            updateCommand.Parameters.AddWithValue("@AuthorName", myBook.Author);
            updateCommand.Parameters.AddWithValue("@BookID2", myBook.BookID);

            check2 = updateCommand.ExecuteNonQuery();

            //Updating Book.(PublisherName) in Publisher Table
            updateCommand.CommandText = @"UPDATE Publisher
                                        SET name = @Publisher
                                        WHERE bookID = @BookID3";

            updateCommand.Parameters.AddWithValue("@Publisher", myBook.Publisher);
            updateCommand.Parameters.AddWithValue("@BookID3", myBook.BookID);

            check3 = updateCommand.ExecuteNonQuery();

            connection.Close();

            return (check1 > 0 && check2 > 0 && check3 > 0) ? 1 : 0;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Function DeleteBook() to Delete the Details of a Book
        public int DeleteBook(Book myBook)
        {
            int check1;
            int check2;
            int check3;

            connection.Open();

            SqlCommand deleteCommand = new SqlCommand();
            deleteCommand.Connection = connection;
            deleteCommand.CommandType = CommandType.Text;

            //Deleting Book.(AuthorName) from Author Table
            deleteCommand.CommandText = @"DELETE 
                                        FROM Author
                                        WHERE bookID = @BookID1";

            deleteCommand.Parameters.AddWithValue("@BookID1", myBook.BookID);

            check1 = deleteCommand.ExecuteNonQuery();

            //Deleting Book.(PublisherName) from Publisher Table
            deleteCommand.CommandText = @"DELETE 
                                        FROM Publisher 
                                        WHERE bookID = @BookID2";

            deleteCommand.Parameters.AddWithValue("@BookID2", myBook.BookID);

            check2 = deleteCommand.ExecuteNonQuery();

            //Deleting Book.(BookID, Title, SubjectCode, Price, RackNo) from Book Table
            deleteCommand.CommandText = @"DELETE 
                                        FROM Book 
                                        WHERE bookID = @BookID3";

            deleteCommand.Parameters.AddWithValue("@BookID3", myBook.BookID);

            check3 = deleteCommand.ExecuteNonQuery();


            connection.Close();

            return (check1 > 0 && check2 > 0 && check3 > 0) ? 1 : 0;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //////////////////////////
        //     BOOK QUERIES     //
        //////////////////////////

        //Function LoadBook() to Load All Records of Book 
        public DataTable LoadBook()
        {
            DataTable book = new DataTable();
            SqlCommand loadCommand = new SqlCommand();
            loadCommand.Connection = connection;
            loadCommand.CommandType = CommandType.Text;
            loadCommand.CommandText = @"SELECT Book.bookID AS [Book ID], title AS Title, subjectCode AS [Subject Code], authorName AS [Author Name], rackNo AS [Rack No], name AS Publisher, price AS [Price(Rs)], issuedTo AS [Issued To]
                                       FROM Book JOIN Author
                                       ON
                                       Book.bookID = Author.bookID JOIN Publisher
                                       ON
                                       Author.bookID = Publisher.BookID";

            SqlDataAdapter adapter = new SqlDataAdapter(loadCommand);
            adapter.Fill(book);

            return book;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Function LoadIssuedBook() to Load Issued Books Records  
        public DataTable LoadIssuedBook()
        {
            DataTable issuedBook = new DataTable();
            SqlCommand loadCommand = new SqlCommand();
            loadCommand.Connection = connection;
            loadCommand.CommandType = CommandType.Text;
            loadCommand.CommandText = @"SELECT Book.bookID AS [Book ID], title AS Title, subjectCode AS [Subject Code], authorName AS [Author Name], rackNo AS [Rack No], name AS Publisher, price AS [Price(Rs)], issuedTo AS [Issued To]
                                       FROM Book JOIN Author
                                       ON
                                       Book.bookID = Author.bookID JOIN Publisher
                                       ON
                                       Author.bookID = Publisher.BookID
                                       WHERE Book.bookID IN (SELECT bookID FROM StatusOfIssue)";

            SqlDataAdapter adapter = new SqlDataAdapter(loadCommand);
            adapter.Fill(issuedBook);

            return issuedBook;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Funtion LoadNonIssuedBook() to load Non Issued Books only
        public DataTable LoadNonIssuedBook()
        {
            DataTable nonIssuedBook = new DataTable();
            SqlCommand loadCommand = new SqlCommand();
            loadCommand.Connection = connection;
            loadCommand.CommandType = CommandType.Text;
            loadCommand.CommandText = @"SELECT Book.bookID AS [Book ID], title AS Title, subjectCode AS [Subject Code], authorName AS [Author Name], rackNo AS [Rack No], name AS Publisher, price AS [Price(Rs)], issuedTo AS [Issued To]
                                       FROM Book JOIN Author
                                       ON
                                       Book.bookID = Author.bookID JOIN Publisher
                                       ON
                                       Author.bookID = Publisher.BookID
                                       WHERE Book.bookID NOT IN (SELECT bookID FROM StatusOfIssue)";

            SqlDataAdapter adapter = new SqlDataAdapter(loadCommand);
            adapter.Fill(nonIssuedBook);

            return nonIssuedBook;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Function SearchBookByCategory() to search any Books of Some Category
        public DataTable SearchBookByRackNo(string searchString)
        {
            DataTable bookByCategory = new DataTable();
            SqlCommand searchCommand = new SqlCommand();
            searchCommand.Connection = connection;
            searchCommand.CommandType = CommandType.Text;
            searchCommand.CommandText = @"SELECT Book.bookID AS [Book ID], title AS Title, subjectCode AS [Subject Code], authorName AS [Author Name], rackNo AS [Rack No], name AS Publisher, price AS [Price(Rs)], issuedTo AS [Issued To]
                                       FROM Book JOIN Author
                                       ON
                                       Book.bookID = Author.bookID JOIN Publisher
                                       ON
                                       Author.bookID = Publisher.BookID
                                       WHERE rackNo = '" + searchString + "'";

            SqlDataAdapter adapter = new SqlDataAdapter(searchCommand);
            adapter.Fill(bookByCategory);

            return bookByCategory;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Function SearchBookByID_Exact() to Find the Book with some Exacct ID
        public DataTable SearchBookByID_Exact(string searchString)
        {
            DataTable bookByID_Exact = new DataTable();
            SqlCommand searchcommand = new SqlCommand();
            searchcommand.Connection = connection;
            searchcommand.CommandType = CommandType.Text;
            searchcommand.CommandText = @"SELECT Book.bookID AS [Book ID], title AS Title, subjectCode AS [Subject Code], authorName AS [Author Name], rackNo AS [Rack No], name AS Publisher, price AS [Price(Rs)], issuedTo AS [Issued To]
                                       FROM Book JOIN Author
                                       ON
                                       Book.bookID = Author.bookID JOIN Publisher
                                       ON
                                       Author.bookID = Publisher.BookID
                                       WHERE Book.bookID = '" + searchString + "'";

            SqlDataAdapter adapter = new SqlDataAdapter(searchcommand);
            adapter.Fill(bookByID_Exact);

            return bookByID_Exact;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Function SearchBookByTitle_Exact() to Find Book with some Exact Title
        public DataTable SearchBookByTitle_Exact(string searchString)
        {
            DataTable bookByTitle_Exact = new DataTable();
            SqlCommand searchCommand = new SqlCommand();
            searchCommand.Connection = connection;
            searchCommand.CommandType = CommandType.Text;
            searchCommand.CommandText = @"SELECT Book.bookID AS [Book ID], title AS Title, subjectCode AS [Subject Code], authorName AS [Author Name], rackNo AS [Rack No], name AS Publisher, price AS [Price(Rs)], issuedTo AS [Issued To]
                                       FROM Book JOIN Author
                                       ON
                                       Book.bookID = Author.bookID JOIN Publisher
                                       ON
                                       Author.bookID = Publisher.BookID
                                       WHERE title = '" + searchString + "'";

            SqlDataAdapter adapter = new SqlDataAdapter(searchCommand);
            adapter.Fill(bookByTitle_Exact);

            return bookByTitle_Exact;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Function SearchBookByPublisher_Exact() to Find Book with some Exact Publisher
        public DataTable SearchBookByPublisher_Exact(string searchString)
        {
            DataTable bookByPublisher_Exact = new DataTable();
            SqlCommand searchCommand = new SqlCommand();
            searchCommand.Connection = connection;
            searchCommand.CommandType = CommandType.Text;
            searchCommand.CommandText = @"SELECT Book.bookID AS [Book ID], title AS Title, subjectCode AS [Subject Code], authorName AS [Author Name], rackNo AS [Rack No], name AS Publisher, price AS [Price(Rs)], issuedTo AS [Issued To]
                                       FROM Book JOIN Author
                                       ON
                                       Book.bookID = Author.bookID JOIN Publisher
                                       ON
                                       Author.bookID = Publisher.BookID
                                       WHERE Publisher.name = '" + searchString + "'";

            SqlDataAdapter adapter = new SqlDataAdapter(searchCommand);
            adapter.Fill(bookByPublisher_Exact);

            return bookByPublisher_Exact;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Function SearchBookByAuthor_Exact() to Find Book with some Exact Author
        public DataTable SearchBookByAuthor_Exact(string searchString)
        {
            DataTable bookByAuthor_Exact = new DataTable();
            SqlCommand searchCommand = new SqlCommand();
            searchCommand.Connection = connection;
            searchCommand.CommandType = CommandType.Text;
            searchCommand.CommandText = @"SELECT Book.bookID AS [Book ID], title AS Title, subjectCode AS [Subject Code], authorName AS [Author Name], rackNo AS [Rack No], name AS Publisher, price AS [Price(Rs)], issuedTo AS [Issued To]
                                       FROM Book JOIN Author
                                       ON
                                       Book.bookID = Author.bookID JOIN Publisher
                                       ON
                                       Author.bookID = Publisher.BookID
                                       WHERE authorName = '" + searchString + "'";

            SqlDataAdapter adapter = new SqlDataAdapter(searchCommand);
            adapter.Fill(bookByAuthor_Exact);

            return bookByAuthor_Exact;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Function SearchBookByID_Contains() to Find Book with some ID Hint
        public DataTable SearchBookByID_Contain(string searchString)
        {
            DataTable bookByID_Contain = new DataTable();
            SqlCommand searchCommand = new SqlCommand();
            searchCommand.Connection = connection;
            searchCommand.CommandType = CommandType.Text;
            searchCommand.CommandText = @"SELECT Book.bookID AS [Book ID], title AS Title, subjectCode AS [Subject Code], authorName AS [Author Name], rackNo AS [Rack No], name AS Publisher, price AS [Price(Rs)], issuedTo AS [Issued To]
                                       FROM Book JOIN Author
                                       ON
                                       Book.bookID = Author.bookID JOIN Publisher
                                       ON
                                       Author.bookID = Publisher.BookID
                                       WHERE Book.bookID LIKE '%" + searchString + "%'";

            SqlDataAdapter adapter = new SqlDataAdapter(searchCommand);
            adapter.Fill(bookByID_Contain);

            return bookByID_Contain;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Function SearchBookByTitle_Contains() to Find Book with some Title Hint
        public DataTable SearchBookByTitle_Contain(string searchString)
        {
            DataTable bookByTitle_Contain = new DataTable();
            SqlCommand searchCommand = new SqlCommand();
            searchCommand.Connection = connection;
            searchCommand.CommandType = CommandType.Text;
            searchCommand.CommandText = @"SELECT Book.bookID AS [Book ID], title AS Title, subjectCode AS [Subject Code], authorName AS [Author Name], rackNo AS [Rack No], name AS Publisher, price AS [Price(Rs)], issuedTo AS [Issued To]
                                       FROM Book JOIN Author
                                       ON
                                       Book.bookID = Author.bookID JOIN Publisher
                                       ON
                                       Author.bookID = Publisher.BookID
                                       WHERE title LIKE '%" + searchString + "%'";

            SqlDataAdapter adapter = new SqlDataAdapter(searchCommand);
            adapter.Fill(bookByTitle_Contain);

            return bookByTitle_Contain;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Function SearchBookByPublisher_Contains() to Find Book with some Publisher Hint
        public DataTable SearchBookByPublisher_Contain(string searchString)
        {
            DataTable bookByPublisher_Contain = new DataTable();
            SqlCommand searchCommand = new SqlCommand();
            searchCommand.Connection = connection;
            searchCommand.CommandType = CommandType.Text;
            searchCommand.CommandText = @"SELECT Book.bookID AS [Book ID], title AS Title, subjectCode AS [Subject Code], authorName AS [Author Name], rackNo AS [Rack No], name AS Publisher, price AS [Price(Rs)], issuedTo AS [Issued To]
                                       FROM Book JOIN Author
                                       ON
                                       Book.bookID = Author.bookID JOIN Publisher
                                       ON
                                       Author.bookID = Publisher.BookID
                                       WHERE Publisher.name LIKE '%" + searchString + "%'";

            SqlDataAdapter adapter = new SqlDataAdapter(searchCommand);
            adapter.Fill(bookByPublisher_Contain);

            return bookByPublisher_Contain;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Function SearchBookByAuthor_Contains() to Find Book with some Author Hint
        public DataTable SearchBookByAuthor_Contain(string searchString)
        {
            DataTable bookByAuthor_Contain = new DataTable();
            SqlCommand searchCommand = new SqlCommand();
            searchCommand.Connection = connection;
            searchCommand.CommandType = CommandType.Text;
            searchCommand.CommandText = @"SELECT Book.bookID AS [Book ID], title AS Title, subjectCode AS [Subject Code], authorName AS [Author Name], rackNo AS [Rack No], name AS Publisher, price AS [Price(Rs)], issuedTo AS [Issued To]
                                       FROM Book JOIN Author
                                       ON
                                       Book.bookID = Author.bookID JOIN Publisher
                                       ON
                                       Author.bookID = Publisher.BookID
                                       WHERE authorName LIKE '%" + searchString + "%'";

            SqlDataAdapter adapter = new SqlDataAdapter(searchCommand);
            adapter.Fill(bookByAuthor_Contain);

            return bookByAuthor_Contain;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Function SearchIssuedBookByBID() to Find Issued Book with some Book ID
        public DataTable SearchIssuedBookByBID(string searchString)
        {
            DataTable issuedBookByBID = new DataTable();
            SqlCommand searchCommand = new SqlCommand();
            searchCommand.Connection = connection;
            searchCommand.CommandType = CommandType.Text;
            searchCommand.CommandText = @"SELECT Book.bookID AS [Book ID], title AS Title, subjectCode AS [Subject Code], authorName AS [Author Name], rackNo AS [Rack No], name AS Publisher, price AS [Price(Rs)], issuedTo AS [Issued To]
                                       FROM Book JOIN Author
                                       ON
                                       Book.bookID = Author.bookID JOIN Publisher
                                       ON
                                       Author.bookID = Publisher.BookID
                                       WHERE Book.bookID IN (SELECT bookID FROM StatusOFIssue)";

            SqlDataAdapter adapter = new SqlDataAdapter(searchCommand);
            adapter.Fill(issuedBookByBID);

            return issuedBookByBID;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Function SearchIssuedBookByMID() to Find Issued Book with some Member ID
        public DataTable SearchIssuedBookByMID(string searchString)
        {
            DataTable issuedBookByMID = new DataTable();
            SqlCommand searchCommand = new SqlCommand();
            searchCommand.Connection = connection;
            searchCommand.CommandType = CommandType.Text;
            searchCommand.CommandText = @"SELECT Book.bookID AS [Book ID], title AS Title, subjectCode AS [Subject Code], authorName AS [Author Name], rackNo AS [Rack No], name AS Publisher, price AS [Price(Rs)], issuedTo AS [Issued To]
                                       FROM Book JOIN Author
                                       ON
                                       Book.bookID = Author.bookID JOIN Publisher
                                       ON
                                       Author.bookID = Publisher.BookID JOIN StatusOfIssue
                                       ON
                                       Publisher.bookID = StatusOfIssue.bookID
                                       WHERE memberID = '" + searchString + "'";

            SqlDataAdapter adapter = new SqlDataAdapter(searchCommand);
            adapter.Fill(issuedBookByMID);

            return issuedBookByMID;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Function SearchNonIssuedBookByBID() to Find Non Issued Book with some Book ID
        public DataTable SearchNonIssuedBookByBID(string searchString)
        {
            DataTable nonIssuedBookByBID = new DataTable();
            SqlCommand searchCommand = new SqlCommand();
            searchCommand.Connection = connection;
            searchCommand.CommandType = CommandType.Text;
            searchCommand.CommandText = @"SELECT Book.bookID AS [Book ID], title AS Title, subjectCode AS [Subject Code], authorName AS [Author Name], rackNo AS [Rack No], name AS Publisher, price AS [Price(Rs)], issuedTo AS [Issued To]
                                       FROM Book JOIN Author
                                       ON
                                       Book.bookID = Author.bookID JOIN Publisher
                                       ON
                                       Author.bookID = Publisher.BookID JOIN StatusOfIssue
                                       ON
                                       Publisher.bookID = StatusOfIssue.bookID
                                       WHERE Book.bookID = '" + searchString + "'";

            SqlDataAdapter adapter = new SqlDataAdapter(searchCommand);
            adapter.Fill(nonIssuedBookByBID);

            return nonIssuedBookByBID;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Function SearchNonIssuedBookByTitle() to Find Issued Book with some Title
        public DataTable SearchNonIssuedBookByTitle(string searchString)
        {
            DataTable issuedBookByTitle = new DataTable();
            SqlCommand searchCommand = new SqlCommand();
            searchCommand.Connection = connection;
            searchCommand.CommandType = CommandType.Text;
            searchCommand.CommandText = @"SELECT Book.bookID AS [Book ID], title AS Title, subjectCode AS [Subject Code], authorName AS [Author Name], rackNo AS [Rack No], name AS Publisher, price AS [Price(Rs)], issuedTo AS [Issued To]
                                       FROM Book JOIN Author
                                       ON
                                       Book.bookID = Author.bookID JOIN Publisher
                                       ON
                                       Author.bookID = Publisher.BookID JOIN StatusOfIssue
                                       ON
                                       Publisher.bookID = StatusOfIssue.bookID
                                       WHERE title = '" + searchString + "'";

            SqlDataAdapter adapter = new SqlDataAdapter(searchCommand);
            adapter.Fill(issuedBookByTitle);

            return issuedBookByTitle;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        /////////////////////////////////////////////////////////////////////////////////////////
        // Defining Functions which we will use to Manipulate with Member Table of DataBase LMS//
        /////////////////////////////////////////////////////////////////////////////////////////

        //Function AddMember() to Add a New Book to DataBase
        public int AddMember(Member aMember)
        {
            int check1;
            int check2;
            int check3;

            connection.Open();

            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandType = CommandType.Text;

            //Inserting Member.(MemberID, Name, MemberType, MembershipIssueDate, MembershipExpiryDate) in Table Member
            insertCommand.CommandText = "INSERT INTO Member VALUES(@MemberID1, @Name, @MemberType, @IssueDate, @ExpiryDate)";

            insertCommand.Parameters.AddWithValue("@MemberID1", aMember.MemberID);
            insertCommand.Parameters.AddWithValue("@Name", aMember.Name);
            insertCommand.Parameters.AddWithValue("@MemberType", aMember.MemberType);
            insertCommand.Parameters.AddWithValue("@IssueDate", aMember.MembershipIssueDate);
            insertCommand.Parameters.AddWithValue("@ExpiryDate", aMember.MembershipExpiryDate);

            check1 = insertCommand.ExecuteNonQuery();

            //Inserting Member.(Address) in Table Address
            insertCommand.CommandText = "INSERT INTO Address(memberID, theAddress) VALUES(@MemberID2, @Address)";

            insertCommand.Parameters.AddWithValue("@MemberID2", aMember.MemberID);
            insertCommand.Parameters.AddWithValue("@Address", aMember.Address);

            check2 = insertCommand.ExecuteNonQuery();

            //Inserting Member.(Contact) in Table ContactNo
            insertCommand.CommandText = "INSERT INTO ContactNo(memberID, theContactNo) VALUES(@MemberID3, @Contact)";

            insertCommand.Parameters.AddWithValue("@MemberID3", aMember.MemberID);
            insertCommand.Parameters.AddWithValue("@Contact", aMember.Contact);

            check3 = insertCommand.ExecuteNonQuery();

            connection.Close();

            return (check1 > 0 && check2 > 0 && check3 > 0) ? 1 : 0;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Function UpdateMember() to Change the Details of a Member
        public int UpdateMember(Member aMember)
        {
            int check1;
            int check2;
            int check3;

            connection.Open();

            SqlCommand updateCommand = new SqlCommand();
            updateCommand.Connection = connection;
            updateCommand.CommandType = CommandType.Text;

            //Updating Member.(MemberID, Name, MemberType, MembershipIssueDate, MembershipExpiryDate) in Table Member
            updateCommand.CommandText = @"UPDATE Member
                                        SET name = @Name
                                        , memType = @MemberType
                                        , membershipIssueDate = @IssueDate
                                        , membershipExpiryDate = @ExpiryDate
                                        WHERE memberID = @MemberID1";

            updateCommand.Parameters.AddWithValue("@Name", aMember.Name);
            updateCommand.Parameters.AddWithValue("@MemberType", aMember.MemberType);
            updateCommand.Parameters.AddWithValue("@IssueDate", aMember.MembershipIssueDate);
            updateCommand.Parameters.AddWithValue("@ExpiryDate", aMember.MembershipExpiryDate);
            updateCommand.Parameters.AddWithValue("@MemberID1", aMember.MemberID);

            check1 = updateCommand.ExecuteNonQuery();

            //Updating Member.(Address) in Table Address
            updateCommand.CommandText = @"UPDATE Address
                                        SET theAddress = @Address
                                        WHERE memberID = @MemberID2";

            updateCommand.Parameters.AddWithValue("@Address", aMember.Address);
            updateCommand.Parameters.AddWithValue("@MemberID2", aMember.MemberID);

            check2 = updateCommand.ExecuteNonQuery();

            //Updating Member.(Contact) in Table ContactNo
            updateCommand.CommandText = @"UPDATE ContactNo
                                        SET theContactNo = @Contact
                                        WHERE memberID = @MemberID3";

            updateCommand.Parameters.AddWithValue("@Contact", aMember.Contact);
            updateCommand.Parameters.AddWithValue("@MemberID3", aMember.MemberID);

            check3 = updateCommand.ExecuteNonQuery();

            connection.Close();

            return (check1 > 0 && check2 > 0 && check3 > 0) ? 1 : 0;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Function DeleteMember() to Delete the Details of a Member
        public int DeleteMember(Member aMember)
        {
            int check1;
            int check2;
            int check3;

            connection.Open();

            SqlCommand deleteCommand = new SqlCommand();
            deleteCommand.Connection = connection;
            deleteCommand.CommandType = CommandType.Text;

            //Deleting Member.(Address) in Table Address
            deleteCommand.CommandText = @"DELETE
                                        FROM Address
                                        WHERE memberID = @MemberID1";

            deleteCommand.Parameters.AddWithValue("@MemberID1", aMember.MemberID);

            check1 = deleteCommand.ExecuteNonQuery();

            //Deleting Member.(Contact) in Table ContactNo
            deleteCommand.CommandText = @"DELETE
                                        FROM ContactNo
                                        WHERE memberID = @MemberID2";

            deleteCommand.Parameters.AddWithValue("@MemberID2", aMember.MemberID);

            check2 = deleteCommand.ExecuteNonQuery();

            //Deleting Member.(MemberID, Name, MemberType, MembershipIssueDate, MembershipExpiryDate) in Table Member
            deleteCommand.CommandText = @"DELETE
                                        FROM Member
                                        WHERE memberID = @MemberID3";

            deleteCommand.Parameters.AddWithValue("@MemberID3", aMember.MemberID);

            check3 = deleteCommand.ExecuteNonQuery();

            connection.Close();
            return (check1 > 0 && check2 > 0 && check3 > 0) ? 1 : 0;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //////////////////////////
        //    Member QUERIES    //
        //////////////////////////

        //Function LoadMember() to Load All Records of Member 
        public DataTable LoadMember()
        {
            DataTable member = new DataTable();
            SqlCommand loadCommand = new SqlCommand();
            loadCommand.Connection = connection;
            loadCommand.CommandType = CommandType.Text;
            loadCommand.CommandText = @"SELECT Member.memberID AS [Member ID], name AS Name, memType AS [Member Type], membershipIssueDate AS [Membership Issue Date], membershipExpiryDate AS [Membership Expiry Date], theAddress AS [Address], theContactNo AS [Contact]
                                      FROM Member JOIN Address
                                      ON
                                      Member.memberID = Address.memberID JOIN ContactNo
                                      ON
                                      Address.memberID = ContactNo.memberID";

            SqlDataAdapter adapter = new SqlDataAdapter(loadCommand);
            adapter.Fill(member);

            return member;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Function LoadIssuedMember() to Load Isued Member Records  
        public DataTable LoadIssuedMember()
        {
            DataTable issuedMember = new DataTable();
            SqlCommand loadCommand = new SqlCommand();
            loadCommand.Connection = connection;
            loadCommand.CommandType = CommandType.Text;
            loadCommand.CommandText = @"SELECT Member.memberID AS [Member ID], name AS Name, memType AS [Member Type], membershipIssueDate AS [Membership Issue Date], membershipExpiryDate AS [Membership Expiry Date], theAddress AS [Address], theContactNo AS [Contact]
                                      FROM Member JOIN Address
                                      ON
                                      Member.memberID = Address.memberID JOIN ContactNo
                                      ON
                                      Address.memberID = ContactNo.memberID
                                      WHERE Member.memberID IN (SELECT memberID FROM StatusOfIssue)";

            SqlDataAdapter adapter = new SqlDataAdapter(loadCommand);
            adapter.Fill(issuedMember);

            return issuedMember;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Function SearchMemberByType() to Find Member by Some Type 
        public DataTable SearchMemberByType(string searchString)
        {
            DataTable memberByType = new DataTable();
            SqlCommand searchCommand = new SqlCommand();
            searchCommand.Connection = connection;
            searchCommand.CommandType = CommandType.Text;
            searchCommand.CommandText = @"SELECT Member.memberID AS [Member ID], name AS Name, memType AS [Member Type], membershipIssueDate AS [Membership Issue Date], membershipExpiryDate AS [Membership Expiry Date], theAddress AS [Address], theContactNo AS [Contact]
                                      FROM Member JOIN Address
                                      ON
                                      Member.memberID = Address.memberID JOIN ContactNo
                                      ON
                                      Address.memberID = ContactNo.memberID
                                      WHERE memtype = '" + searchString + "'";

            SqlDataAdapter adapter = new SqlDataAdapter(searchCommand);
            adapter.Fill(memberByType);

            return memberByType;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Function SearchMemberByID_Exact() to Find Member by Some Exact ID 
        public DataTable SearchMemberByID_Exact(string searchString)
        {
            DataTable memberByID_Exact = new DataTable();
            SqlCommand searchCommand = new SqlCommand();
            searchCommand.Connection = connection;
            searchCommand.CommandType = CommandType.Text;
            searchCommand.CommandText = @"SELECT Member.memberID AS [Member ID], name AS Name, memType AS [Member Type], membershipIssueDate AS [Membership Issue Date], membershipExpiryDate AS [Membership Expiry Date], theAddress AS [Address], theContactNo AS [Contact]
                                      FROM Member JOIN Address
                                      ON
                                      Member.memberID = Address.memberID JOIN ContactNo
                                      ON
                                      Address.memberID = ContactNo.memberID
                                      WHERE Member.memberID = '" + searchString + "'";

            SqlDataAdapter adapter = new SqlDataAdapter(searchCommand);
            adapter.Fill(memberByID_Exact);

            return memberByID_Exact;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Function SearchMemberByName_Exact() to Find Member by Some Exact Name  
        public DataTable SearchMemberByName_Exact(string searchString)
        {
            DataTable memberByName_Exact = new DataTable();
            SqlCommand searchCommand = new SqlCommand();
            searchCommand.Connection = connection;
            searchCommand.CommandType = CommandType.Text;
            searchCommand.CommandText = @"SELECT Member.memberID AS [Member ID], name AS Name, memType AS [Member Type], membershipIssueDate AS [Membership Issue Date], membershipExpiryDate AS [Membership Expiry Date], theAddress AS [Address], theContactNo AS [Contact]
                                      FROM Member JOIN Address
                                      ON
                                      Member.memberID = Address.memberID JOIN ContactNo
                                      ON
                                      Address.memberID = ContactNo.memberID
                                      WHERE name = '" + searchString + "'";

            SqlDataAdapter adapter = new SqlDataAdapter(searchCommand);
            adapter.Fill(memberByName_Exact);

            return memberByName_Exact;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Function SearchMemberByID_Contain() to Find Member by Some ID Hint  
        public DataTable SearchMemberByID_Contain(string searchString)
        {
            DataTable memberByID_Contain = new DataTable();
            SqlCommand searchCommand = new SqlCommand();
            searchCommand.Connection = connection;
            searchCommand.CommandType = CommandType.Text;
            searchCommand.CommandText = @"SELECT Member.memberID AS [Member ID], name AS Name, memType AS [Member Type], membershipIssueDate AS [Membership Issue Date], membershipExpiryDate AS [Membership Expiry Date], theAddress AS [Address], theContactNo AS [Contact]
                                      FROM Member JOIN Address
                                      ON
                                      Member.memberID = Address.memberID JOIN ContactNo
                                      ON
                                      Address.memberID = ContactNo.memberID
                                      WHERE Member.memberID LIKE '%" + searchString + "%'";

            SqlDataAdapter adapter = new SqlDataAdapter(searchCommand);
            adapter.Fill(memberByID_Contain);

            return memberByID_Contain;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Function SearchMemberByName_Contain() to Find Member by Some Name Hint  
        public DataTable SearchMemberByName_Contain(string searchString)
        {
            DataTable memberByName_Contain = new DataTable();
            SqlCommand searchCommand = new SqlCommand();
            searchCommand.Connection = connection;
            searchCommand.CommandType = CommandType.Text;
            searchCommand.CommandText = @"SELECT Member.memberID AS [Member ID], name AS Name, memType AS [Member Type], membershipIssueDate AS [Membership Issue Date], membershipExpiryDate AS [Membership Expiry Date], theAddress AS [Address], theContactNo AS [Contact]
                                      FROM Member JOIN Address
                                      ON
                                      Member.memberID = Address.memberID JOIN ContactNo
                                      ON
                                      Address.memberID = ContactNo.memberID
                                      WHERE name LIKE '%" + searchString + "%'";

            SqlDataAdapter adapter = new SqlDataAdapter(searchCommand);
            adapter.Fill(memberByName_Contain);

            return memberByName_Contain;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        /////////////////////////////////////////////////////////////////////////////////////////
        //     Defining Functions to Manipulate the StatusOfIssue Table of DataBase LMS        //
        /////////////////////////////////////////////////////////////////////////////////////////

        public int IssueBook(StatusOfIssue issueStatus)
        {
            int check1;
            int check2;
            connection.Open();

            SqlCommand issueCommand = new SqlCommand();
            issueCommand.Connection = connection;
            issueCommand.CommandType = CommandType.Text;

            //Issuing a Book to a Member of Library
            issueCommand.CommandText = "INSERT INTO StatusOfIssue VALUES(@BookID1, @MemberID1, @IssueDate, @ExpiryDate)";

            issueCommand.Parameters.AddWithValue("@BookID1", issueStatus.BookID);
            issueCommand.Parameters.AddWithValue("@MemberID1", issueStatus.MemberID);
            issueCommand.Parameters.AddWithValue("@IssueDate", issueStatus.IssueDate);
            issueCommand.Parameters.AddWithValue("@ExpiryDate", issueStatus.ExpiryDate);

            check1 = issueCommand.ExecuteNonQuery();

            //Updating Issued Status in Book Table
            issueCommand.CommandText = @"UPDATE Book
                                       SET issuedTo = @MemberID2
                                       WHERE bookID = @BookID2";

            issueCommand.Parameters.AddWithValue("@BookID2", issueStatus.BookID);
            issueCommand.Parameters.AddWithValue("@MemberID2", issueStatus.MemberID);

            check2 = issueCommand.ExecuteNonQuery();

            return (check1 > 0 && check2 > 0) ? 1 : 0;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        /////////////////////////////////////////////////////////////////////////////////////////
        //                         Load Book Issue Status' Records                             //
        /////////////////////////////////////////////////////////////////////////////////////////

        public DataTable LoadIssueStatus()
        {
            DataTable issueStatus = new DataTable();
            SqlCommand loadCommand = new SqlCommand();
            loadCommand.Connection = connection;
            loadCommand.CommandType = CommandType.Text;
            loadCommand.CommandText = @"SELECT bookID AS [Book ID], memberID AS [Member ID], issueDate AS [Book Issue Date], expiryDate AS [Book Expiry Date]
                                       FROM StatusOfIssue";

            SqlDataAdapter adapter = new SqlDataAdapter(loadCommand);
            adapter.Fill(issueStatus);

            return issueStatus;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        /////////////////////////////////////////////////////////////////////////////////////////
        //                       Search Book Issue Status' Records                             //
        /////////////////////////////////////////////////////////////////////////////////////////

        //Searching issue status' by BookID
        public DataTable SearchIssueStatusByBID(string searchString)
        {
            DataTable issueStatus = new DataTable();
            SqlCommand searchCommand = new SqlCommand();
            searchCommand.Connection = connection;
            searchCommand.CommandType = CommandType.Text;
            searchCommand.CommandText = @"SELECT bookID AS [Book ID], memberID AS [Member ID], issueDate AS [Book Issue Date], expiryDate AS [Book Expiry Date]
                                       FROM StatusOfIssue
                                       WHERE bookID = '" + searchString + "'";

            SqlDataAdapter adapter = new SqlDataAdapter(searchCommand);
            adapter.Fill(issueStatus);

            return issueStatus;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        //Searching issue status' by BookID
        public DataTable SearchIssueStatusByMID(string searchString)
        {
            DataTable issueStatus = new DataTable();
            SqlCommand searchCommand = new SqlCommand();
            searchCommand.Connection = connection;
            searchCommand.CommandType = CommandType.Text;
            searchCommand.CommandText = @"SELECT bookID AS [Book ID], memberID AS [Member ID], issueDate AS [Book Issue Date], expiryDate AS [Book Expiry Date]
                                       FROM StatusOfIssue
                                       WHERE memberID = '" + searchString + "'";

            SqlDataAdapter adapter = new SqlDataAdapter(searchCommand);
            adapter.Fill(issueStatus);

            return issueStatus;
            /////////////////////////////////////////////////////////////////////////////////////
        }

        /////////////////////////////////////////////////////////////////////////////////////////
        //     Defining Functions to Manipulate the StatusOfReturn Table of DataBase LMS       //
        /////////////////////////////////////////////////////////////////////////////////////////

        public int ReturnBook(StatusOfReturn returnStatus)
        {
            int check1;
            int check2;
            int check3;

            connection.Open();
            SqlCommand returnCommand = new SqlCommand();
            returnCommand.Connection = connection;
            returnCommand.CommandType = CommandType.Text;

            //Returning Book to the Library
            returnCommand.CommandText = "INSERT INTO StatusOfReturn VALUES(@BookID1, @MemberID, @IssueDate, @ExpiryDate, @FineAmount)";

            returnCommand.Parameters.AddWithValue("@BookID1", returnStatus.BookID);
            returnCommand.Parameters.AddWithValue("@MemberID", returnStatus.MemberID);
            returnCommand.Parameters.AddWithValue("@IssueDate", returnStatus.IssueDate);
            returnCommand.Parameters.AddWithValue("@ExpiryDate", returnStatus.ExpiryDate);
            returnCommand.Parameters.AddWithValue("@FineAmount", returnStatus.FineAmount);

            check1 = returnCommand.ExecuteNonQuery();

            //Deleting From the Issued Status
            returnCommand.CommandText = @"DELETE
                                        FROM StatusOfIssue
                                        WHERE BookID = @BookID2";

            returnCommand.Parameters.AddWithValue("@BookID2", returnStatus.BookID);

            check2 = returnCommand.ExecuteNonQuery();
            
            //Updating Issued Status in Book Table
            returnCommand.CommandText = @"UPDATE Book
                                       SET issuedTo = NULL
                                       WHERE bookID = @BookID3";

            returnCommand.Parameters.AddWithValue("@BookID3", returnStatus.BookID);

            check3 = returnCommand.ExecuteNonQuery();

            return (check1 > 0 && check2 > 0 && check3 > 0) ? 1 : 0;
            /////////////////////////////////////////////////////////////////////////////////////
        }
    }
}