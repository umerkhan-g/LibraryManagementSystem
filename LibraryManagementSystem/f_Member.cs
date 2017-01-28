using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using BALayer;
using BELayer;

namespace LibraryManagementSystem
{
    public partial class f_Member : Form
    {
        BAL business = new BAL();
        Member member = new Member();
        string option;

        //Parameterized Constructor to Initialize Private Feilds
        public f_Member(string myOption, Member otherMember)
        {
            InitializeComponent();

            option = myOption;
            member = otherMember;
        }

        ///////////////////////////////////////////////
        //        Loading/Closing Member Form        //
        ///////////////////////////////////////////////

        private void f_Member_Load(object sender, EventArgs e)
        {
            //Setting Maximum Size of Textboxes
            tb_Name.MaxLength = 30;
            tb_MemberType.MaxLength = 10;
            tb_Address.MaxLength = 100;
            tb_Contact.MaxLength = 15;

            //Setting the Values of All Textboxes
            tb_MemberID.Text = member.MemberID;
            tb_Name.Text = member.Name;
            tb_MemberType.Text = member.MemberType;
            tb_Address.Text = member.Address;
            tb_Contact.Text = member.Contact;

            //Assigning string Date to DateTimePicker Control 
            dtp_Expiry.Value = Convert.ToDateTime(member.MembershipExpiryDate);

            //Setting the Layout According to the Option Private Feild Value
            tb_MemberID.ReadOnly = true;

            if(option == "Update")
            {
                this.Text = "Update Member";

                btn_OK.Enabled = false;

                gb_Details.Visible = false;
            }
            else if(option == "ViewDetails")
            {
                this.Text = "Details of Member";

                tb_Name.ReadOnly = true;
                tb_MemberType.ReadOnly = true;
                tb_Address.ReadOnly = true;
                tb_Contact.ReadOnly = true;

                dtp_Expiry.Enabled = false;

                btn_Update.Enabled = false;
                btn_Clear.Enabled = false;
                btn_Back.Enabled = false;

                gb_Details.Visible = true;
            }
        }

        ///////////////////////////////////////////////
        //           Validating User Input           //
        ///////////////////////////////////////////////

        private void tb_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void tb_MemberType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tb_Address_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void tb_Contact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        ///////////////////////////////////////////////
        //     Adding Functionality to Buttons       //
        ///////////////////////////////////////////////

        private void btn_Update_Click(object sender, EventArgs e)
        {
            Member amember = new Member();

            amember.MemberID = tb_MemberID.Text;
            amember.Name = tb_Name.Text;
            amember.MemberType = tb_MemberType.Text;
            amember.MembershipIssueDate = member.MembershipIssueDate;
            amember.MembershipExpiryDate = dtp_Expiry.Value.ToString("yyyy-MM-dd");
            amember.Address = tb_Address.Text;
            amember.Contact = tb_Contact.Text;

            if(business.UpdateMember_Scure(amember)==1)
            {
                MessageBox.Show("The Member info. is Updated Successfully...!", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            tb_Name.Clear();
            tb_MemberType.Clear();
            tb_Address.Clear();
            tb_Contact.Clear();

            dtp_Expiry.Value = DateTime.Now;

            tb_Name.Focus();
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