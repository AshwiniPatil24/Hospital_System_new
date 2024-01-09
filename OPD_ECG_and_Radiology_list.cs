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
    public partial class OPD_ECG_and_Radiology_list : Form
    {
       public string Purpose; 
        public OPD_ECG_and_Radiology_list()
        {
            InitializeComponent();
        }
        public OPD_ECG_and_Radiology_list(int OPDId,string Purpose)
        {
            InitializeComponent();
        }
        public OPD_ECG_and_Radiology_list(int IPDId)
        {
            InitializeComponent();
        }
        private void OPD_ECG_and_Radiology_list_Load(object sender, EventArgs e)
        {
            //int w = Screen.PrimaryScreen.Bounds.Width;
            //int h = Screen.PrimaryScreen.Bounds.Height;
            //this.Location = new Point(0, 0);
            //this.Size = new Size(w, h);
            OPD_RadiologyTest_show();
        }
        public void OPD_RadiologyTest_show()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * From Master_Radiology_Test", con);

            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Radiology_ID";
            }


        }
        public void showOPD()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"SELECT        Ruby_Jamner123.Patient_Registration.Patient_ID, Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Doctors_Name, Ruby_Jamner123.Patient_Registration.Referred_By, 
                         Ruby_Jamner123.RadiologyPatientList.Purpose, Ruby_Jamner123.Patient_Registration.Date AS [Addmission Date],Ruby_Jamner123.RadiologyPatientList.OPDID

FROM            Ruby_Jamner123.Patient_Registration INNER JOIN
                         Ruby_Jamner123.RadiologyPatientList ON Ruby_Jamner123.Patient_Registration.PID = Ruby_Jamner123.RadiologyPatientList.OPDID Where RadiologyPatientList.Purpose='OPD' ", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["OPDID"].Visible = false;
                Purpose = Convert.ToString(dataGridView1.CurrentRow.Cells["Purpose"].Value);
            }

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
