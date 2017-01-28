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
    public partial class f_A_CP : Form
    {
        BAL business = new BAL();

        public f_A_CP()
        {
            InitializeComponent();
        }

        ///////////////////////////////////////////////
        //      Loading the Change Password Form     //
        ///////////////////////////////////////////////

        private void f_A_CP_Load(object sender, EventArgs e)
        {
            tb_Password.UseSystemPasswordChar = true;
            tb_ConfirmPass.UseSystemPasswordChar = true;

            tb_ConfirmPass.Enabled = false;
            btn_Change.Enabled = false;
            btn_Clear2.Enabled = false;
            btn_Back2.Enabled = false;
        }

        ///////////////////////////////////////////////
        // Validating the User input From Textboxes  //
        ///////////////////////////////////////////////

        private void tb_UserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tb_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tb_ConfirmPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        ///////////////////////////////////////////////
        //    Adding Functionality To Buttons        //
        ///////////////////////////////////////////////

        //Verifies the UserName And Password Before Password Change
        private void btn_Verify_Click(object sender, EventArgs e)
        {
            Administrator admin = new Administrator();

            admin.UserName = tb_UserName.Text;
            admin.UserPassword = tb_Password.Text;

            if (business.Login_Scure(admin))
            {
                tb_UserName.Enabled = false;
                tb_Password.Clear();
                tb_Password.Focus();
                lbl_Cuation.Text = "By Giving Below Details";

                gb_CP.Visible = false;
                tb_ConfirmPass.Enabled = true;
                btn_Change.Enabled = true;
                btn_Clear2.Enabled = true;
                btn_Back2.Enabled = true;
            }
            else
            {
                MessageBox.Show("Invalid User Name or Password, Please Enter valid details...!", "Verify Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbl_Cuation.Text = "Enter Valid Details...!";

                tb_UserName.Clear();
                tb_Password.Clear();
                tb_UserName.Focus();
            }
        }

        private void btn_Clear1_Click(object sender, EventArgs e)
        {
            tb_UserName.Clear();
            tb_Password.Clear();
            tb_UserName.Focus();
        }

        private void btn_Back1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        //Changing the Password
        private void btn_Change_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_Password.Text) && string.IsNullOrWhiteSpace(tb_ConfirmPass.Text)) 
            {
                MessageBox.Show("Please Give a New Password First...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Administrator admin = new Administrator();

            admin.UserName = tb_UserName.Text;

            if (tb_Password.Text == tb_ConfirmPass.Text)
            {
                admin.UserPassword = tb_Password.Text;

                if (business.UpdateAdmin_Scure(admin) == 1)
                {
                    MessageBox.Show("Password Updated Sccessfully...!", "Password Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Passwords Not Matched...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Clear2_Click(object sender, EventArgs e)
        {
            tb_Password.Clear();
            tb_ConfirmPass.Clear();
            tb_Password.Focus();
        }

        private void btn_Back2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}