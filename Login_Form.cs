using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Ruby_Hospital
{
    public partial class Login_Form : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
      (
          int nLeftRect,
          int nTopRect,
          int nRightRect,
          int nBottomRect,
          int nWidthEllipse,
          int nHeightEllipse
      );
        public Login_Form()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtid_Enter(object sender, EventArgs e)
        {
            if(txtid.Text == "Enter Username")
            {
                txtid.Text = "";
                txtid.ForeColor = Color.Black;
            }
        }

        private void txtid_Leave(object sender, EventArgs e)
        {

            if (txtid.Text == "")
            {
                txtid.Text = "Enter Username";
                txtid.ForeColor = Color.Gray;
            }


        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if(txtpass.Text == "Enter Password")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.Black;

            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if(txtpass.Text == " ")
            {
                txtpass.Text = "Enter Password";
                txtpass.ForeColor = Color.Gray;
            }
        }
    }
}
