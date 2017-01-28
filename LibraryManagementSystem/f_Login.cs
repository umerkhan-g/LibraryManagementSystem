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
    public partial class f_Login : Form
    {
        BAL business = new BAL();

        public f_Login()
        {
            InitializeComponent();
        }

        ///////////////////////////////////////////////
        //      Loading/Closing the Login Form       //
        ///////////////////////////////////////////////

        private void f_Login_Load(object sender, EventArgs e)
        {
            tb_Password.UseSystemPasswordChar = true;
        }

        private void f_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        ///////////////////////////////////////////////
        //        Validating Textboxes Input         //
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

        ///////////////////////////////////////////////
        //       Adding Functionality to Buttons     //
        ///////////////////////////////////////////////

        private void btn_Login_Click(object sender, EventArgs e)
        {
            Administrator admin = new Administrator();

            admin.UserName = tb_UserName.Text;
            admin.UserPassword = tb_Password.Text;

            if (business.Login_Scure(admin))
            {
                f_Menu mainMenu = new f_Menu();
                this.Hide();
                mainMenu.Show();
            }
            else
            {
                MessageBox.Show("Invalid User Name or Password, Please Enter valid details...!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbl_Cuation.Text = "Invalid UserName/Password...!";

                tb_UserName.Clear();
                tb_Password.Clear();
                tb_UserName.Focus();
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            tb_UserName.Clear();
            tb_Password.Clear();
            tb_UserName.Focus();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
