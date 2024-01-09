using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruby_Hospital
{
    public partial class Referred_doctor : Form
    {
        public Referred_doctor()
        {
            InitializeComponent();
        }

        private void Referred_doctor_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        private void txtdrrename_Enter(object sender, EventArgs e)
        {
            if(txtdrrename.Text == "Enter the Doctor Name")
            {
                txtdrrename.Text = "";
                txtdrrename.ForeColor = Color.Black;
            }
        }

        private void txtdrrename_Leave(object sender, EventArgs e)
        {
            if (txtdrrename.Text == "")
            {
                txtdrrename.Text = "Enter the Doctor Name";
                txtdrrename.ForeColor = Color.Gray;
            }
        }

        private void txtdigree_Enter(object sender, EventArgs e)
        {
           if(txtdegree.Text == "Degree")
            {
                txtdegree.Text = "";
                txtdegree.ForeColor = Color.Black;
            }
        }

        private void txtdigree_Leave(object sender, EventArgs e)
        {
            if (txtdegree.Text == "")
            {
                txtdegree.Text = "Degree";
                txtdegree.ForeColor = Color.Gray;
            }
        }

        private void txtdrremobileno_Enter(object sender, EventArgs e)
        {
            if(txtdrremobileno.Text== "Mobile No")
            {
                txtdrremobileno.Text = "";
                txtdrremobileno.ForeColor = Color.Black;
            }
        }

        private void txtdrremobileno_Leave(object sender, EventArgs e)
        {
            if (txtdrremobileno.Text == "")
            {
                txtdrremobileno.Text = "Mobile No";
                txtdrremobileno.ForeColor = Color.Gray;
            }
        }

        private void txtdrrgeaddress_Enter(object sender, EventArgs e)
        {
            if(txtdrrgeaddress.Text=="Address")
            {
                txtdrrgeaddress.Text = "";
                txtdrrgeaddress.ForeColor = Color.Black;

            }
        }

        private void txtdrrgeaddress_Leave(object sender, EventArgs e)
        {
            if (txtdrrgeaddress.Text == "")
            {
                txtdrrgeaddress.Text = "Address";
                txtdrrgeaddress.ForeColor = Color.Gray;

            }
        }

        private void txtdrrename_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void txtdigree_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void txtdrremobileno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled =  true;

            }
        }
        public void Save()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Insert into Referred_Doctor (Referred_Name,Degree,Mobile_no,Address,Status)Values (@Referred_Name,@Degree,@Mobile_no,@Address,@Status)", con);
            cmd.Parameters.AddWithValue("@Referred_Name", txtdrrename.Text);
            cmd.Parameters.AddWithValue("@Degree", txtdegree.Text);
            cmd.Parameters.AddWithValue("@Mobile_no", txtdrremobileno.Text);
            cmd.Parameters.AddWithValue("@Address", txtdrrgeaddress.Text);
            if (chbactive.Checked == true)
            {
                cmd.Parameters.AddWithValue("@Status", "Active");
            }
            else
            {
                cmd.Parameters.AddWithValue("@Status", "InActive");
            }
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Added Successfully..");
        }
        public void Update()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Update Referred_Doctor set Referred_Name=@Referred_Name,Degree=@Degree,Mobile_no=@Mobile_no,Address=@Address,Status=@Status where Referred_Name=@Referred_Name", con);
            cmd.Parameters.AddWithValue("@Referred_Name", txtdrrename.Text);
            cmd.Parameters.AddWithValue("@Degree", txtdegree.Text);
            cmd.Parameters.AddWithValue("@Mobile_no", txtdrremobileno.Text);
            cmd.Parameters.AddWithValue("@Address", txtdrrgeaddress.Text);
            if (chbactive.Checked == true)
            {
                cmd.Parameters.AddWithValue("@Status", "Active");
            }
            else
            {
                cmd.Parameters.AddWithValue("@Status", "InActive");
            }
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated Successfully..");
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text=="")
                {
                    Save();
                }
                else
                {
                    Update();
                }
                

                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
