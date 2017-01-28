using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BELayer
{
    /////////////////////////////////////////////////////////////////////////////////////////
    //                 Public Class Administrator to store the Records of Admin            //
    /////////////////////////////////////////////////////////////////////////////////////////

    public class Administrator
    {
        //Auto Implemented Properties

        //AdminID
        //Name
        //Address
        //Contact
        //UserName
        //Password

        public string AdminID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public string Contact
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string UserPassword
        {
            get;
            set;
        }

        public Administrator()
        {
            AdminID = null;
            Name = "*No Name*";
            Address = "*No Address*";
            Contact = "0";
            UserName = "*No Name*";
            UserPassword = null;
        }
    }

    /////////////////////////////////////////////////////////////////////////////////////////
    //                       Public Class Book to store the Records of Book                //
    /////////////////////////////////////////////////////////////////////////////////////////

    public class Book
    {
        //Auto Implemented Properties

        //BookID
        //Title
        //SubjectCode
        //Author1
        //Author2
        //RackNo
        //Publisher
        //Price

        public string BookID
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string SubjectCode
        {
            get;
            set;
        }

        public string Author
        {
            get;
            set;
        }

        public string RackNo
        {
            get;
            set;
        }

        public string Publisher
        {
            get;
            set;
        }

        public double Price
        {
            get;
            set;
        }

        public Book()
        {
            BookID = null;
            Title = "*No Title*";
            SubjectCode = "*No Subject Code*";
            Author = "*No Author*";
            RackNo = null;
            Publisher = "*No Publisher*";
            Price = 0;
        }
    }

    /////////////////////////////////////////////////////////////////////////////////////////
    //                   Public Class Member to store the Records of Member                //
    /////////////////////////////////////////////////////////////////////////////////////////

    public class Member
    {
        //Auto Implemented Properties

        //MemberID
        //Name
        //MemberType
        //MembershipIssueDate
        //MembershipExpiryDate
        //Address
        //Contact

        public string MemberID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string MemberType
        {
            get;
            set;
        }

        public string MembershipIssueDate
        {
            get;
            set;
        }

        public string MembershipExpiryDate
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public string Contact
        {
            get;
            set;
        }

        //Public Constructor to Set the MembershipIssueDate Feild
        public Member()
        {
            MemberID = null;
            Name = "*No Name*";
            MemberType = "Student";
            MembershipIssueDate = DateTime.Today.ToString("d");
            MembershipExpiryDate = DateTime.Today.ToString("d");
            Contact = "0";
        }
    }

    /////////////////////////////////////////////////////////////////////////////////////////
    //        Public Class StatusOfIssue to store the Records of Book Issued               //
    /////////////////////////////////////////////////////////////////////////////////////////

    public class StatusOfIssue
    {
        //Auto Implemented Properties

        //BookID
        //MemberID
        //IssueDate
        //ExpiryDate

        public string BookID
        {
            get;
            set;
        }

        public string MemberID
        {
            get;
            set;
        }

        public string IssueDate
        {
            get;
            set;
        }

        public string ExpiryDate
        {
            get;
            set;
        }

        //Public Constructor to Set the IssueDate Feild
        public StatusOfIssue()
        {
            BookID = null;
            MemberID = null;
            IssueDate = DateTime.Today.ToString("d");
            ExpiryDate = DateTime.Today.ToString("d");
        }
    }

    /////////////////////////////////////////////////////////////////////////////////////////
    //        Public Class StatusOfReturn to store the Records of Book Returned            //
    /////////////////////////////////////////////////////////////////////////////////////////

    public class StatusOfReturn
    {
        //Auto Implemented Properties

        //BookID
        //MemberID
        //IssueDate
        //ExpiryDate
        //FineAmount

        public string BookID
        {
            get;
            set;
        }

        public string MemberID
        {
            get;
            set;
        }

        public string IssueDate
        {
            get;
            set;
        }

        public string ExpiryDate
        {
            get;
            set;
        }

        public double FineAmount
        {
            get;
            set;
        }

        //Public Constructor to Set the IssueDate Feild
        public StatusOfReturn()
        {
            BookID = null;
            MemberID = null;
            IssueDate = DateTime.Today.ToString("d");
            ExpiryDate = DateTime.Today.ToString("d");
            FineAmount = 0;
        }
    }
}