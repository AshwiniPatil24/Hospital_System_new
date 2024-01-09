using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace Ruby_Hospital
{
    public partial class SingUp : Form
    {
        public SingUp()
        {
            InitializeComponent();
            
        }

        private void SingUp_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login_Form ll = new Login_Form();
            ll.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string message = "Do you want to close this window?";
            string title = "Close Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char .IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmail_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(txtmail.Text, pattern))
            {
               // txtmail.Text = "";
                txtmail.BackColor = Color.White;
                errorProvider1.Clear();
            }
            else
            {
                txtmail.Text = "Enter email Id";
                txtmail.ForeColor = Color.Gray;
                errorProvider1.SetError(this.txtmail, "PLEASE PROVIDE VALID EMAIL ADDRESS...");
                txtmail.BackColor = Color.LightPink;
                return;
            }
            if(txtmail.Text=="Enter email Id")
            {
              //  txtmail.Text = "";
                txtmail.ForeColor = Color.Gray;
            }
        }

        private void txtname_Enter(object sender, EventArgs e)
        {
            if(txtname.Text == "Enter the full name ")
            {
                txtname.Text = "";
                txtname.ForeColor = Color.Black;
            }
        }

        private void txtname_Leave(object sender, EventArgs e)
        { 
            if(txtname.Text == "")
            {
                txtname.Text = "Enter the full name";
                txtname.ForeColor = Color.Gray;
            }    
        }

        private void txtusername_Enter(object sender, EventArgs e)
        {
            if (txtusername.Text == "Enter User name ") 
            {
                txtusername.Text = "";
                txtusername.ForeColor = Color.Black;
            }
        }

        private void txtusername_Leave(object sender, EventArgs e)
        {
            if(txtusername.Text == "")
            {
                txtusername.Text = "Enter user name";
                txtusername.ForeColor = Color.Gray;
            }
        }

        private void txtcpass_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtmail_Enter(object sender, EventArgs e)
        {
            if(txtmail.Text == "Enter email Id")
            {
                //txtmail.Text = "";
                txtmail.ForeColor = Color.Black;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "Enter new password")
            {
                txtpass.Text = "";
                txtpass.ForeColor= Color.Black;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {

            if (txtpass.Text == "")
            {
                txtpass.Text = "Enter new password";
                txtpass.ForeColor = Color.Gray;
            }
        }

        private void txtcpass_Enter(object sender, EventArgs e)
        {
            if(txtpass.Text == "Set new password")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.Gray;
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            //try
            //{
            if (txtcpass.Text == txtpass.Text)
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmb = new SqlCommand(@"INSERT INTO SingUp_mst (Role,Name,UserName,Email,Password)
                                                           Values(@Role,@Name,@UserName,@Email,@Password)", con);
                cmb.Parameters.AddWithValue("@Role", txtRole.Text);
                cmb.Parameters.AddWithValue("@Name", txtname.Text);
                cmb.Parameters.AddWithValue("@UserName", txtusername.Text);
                cmb.Parameters.AddWithValue("@Email", txtmail.Text);
                cmb.Parameters.AddWithValue("@Password", txtpass.Text);
                cmb.ExecuteNonQuery();
                MessageBox.Show("User registered successfully ..");
                cleardata();
                con.Close();
            }
            else
            {
                MessageBox.Show("Password and confirm password does not match... ");
                txtcpass.Clear();
            }
            
           // }
           // catch
          //  {

         //   }
            
        }
        public void cleardata()
        {
            txtRole.Text = "";
            txtname.Clear();
            txtusername.Clear();
            txtmail.Clear();
            txtpass.Clear();
            txtcpass.Clear();
        }
    }
}
