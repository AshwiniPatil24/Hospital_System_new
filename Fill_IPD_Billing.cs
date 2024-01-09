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
    public partial class Fill_IPD_Billing : Form
    {
        public int A;
        public Fill_IPD_Billing()
        {
            InitializeComponent();
        }
        public Fill_IPD_Billing( int ID)
        {
            InitializeComponent();
            A = ID;
        }
        public void show()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"SELECT        Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Gender, Ruby_Jamner123.IPD_Registration.Patient_Id AS Expr1, Ruby_Jamner123.Patient_Registration.Patient_ID, 
                         Ruby_Jamner123.Patient_Registration.PID, Ruby_Jamner123.Patient_Registration.Mobile_Number, Ruby_Jamner123.Patient_Registration.Adhaar_ID
FROM            Ruby_Jamner123.Patient_Registration INNER JOIN
                         Ruby_Jamner123.IPD_Registration ON Ruby_Jamner123.Patient_Registration.PID = Ruby_Jamner123.IPD_Registration.Patient_Id
WHERE        (Ruby_Jamner123.IPD_Registration.Patient_Id = @Patient_Id)", con);
            cmb.Parameters.AddWithValue("@Patient_Id", A);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if(dt.Rows.Count>0)
            {
                infogrid.DataSource = dt;
            }
        }

        private void Fill_IPD_Billing_Load(object sender, EventArgs e)
        {
            show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        public void clear()
        {
            infogrid.Rows.Clear();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
