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
    public partial class RadiologyPatientList : Form
    {
        int OPDId;
        public string Purpose;
        public string OnlyTest;
        public int IPDId;
        public int OPDOnlyTest;
        public RadiologyPatientList()
        {
            InitializeComponent();
        }

        private void OPDdatagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RadiologyPatientList_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }
        public void showOPD()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"SELECT        Ruby_Jamner123.Patient_Registration.Patient_ID, Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Doctors_Name, Ruby_Jamner123.Patient_Registration.Referred_By, 
                         Ruby_Jamner123.RadiologyPatientList.Purpose, Ruby_Jamner123.Patient_Registration.Date AS [Addmission Date],Ruby_Jamner123.RadiologyPatientList.OPDID

FROM            Ruby_Jamner123.Patient_Registration INNER JOIN
                         Ruby_Jamner123.RadiologyPatientList ON Ruby_Jamner123.Patient_Registration.PID = Ruby_Jamner123.RadiologyPatientList.OPDID Where RadiologyPatientList.Purpose='OPD'", con);
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

        public void showOnlyTest()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"SELECT        Ruby_Jamner123.Patient_Registration.Patient_ID, Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Doctors_Name, Ruby_Jamner123.Patient_Registration.Referred_By, 
                         Ruby_Jamner123.RadiologyPatientList.Purpose, Ruby_Jamner123.Patient_Registration.Date AS [Addmission Date],Ruby_Jamner123.RadiologyPatientList.OPDID
FROM            Ruby_Jamner123.Patient_Registration INNER JOIN
                         Ruby_Jamner123.RadiologyPatientList ON Ruby_Jamner123.Patient_Registration.PID = Ruby_Jamner123.RadiologyPatientList.OPDID  Where RadiologyPatientList.Purpose='Only Test'", con);
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
        public void showIPD()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"SELECT        Ruby_Jamner123.Patient_Registration.Patient_ID, Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Doctors_Name, Ruby_Jamner123.Patient_Registration.Referred_By, 
                         Ruby_Jamner123.RadiologyPatientList.Purpose, Ruby_Jamner123.Patient_Registration.Date AS [Addmission Date],Ruby_Jamner123.RadiologyPatientList.IPDID
FROM            Ruby_Jamner123.Patient_Registration INNER JOIN
                         Ruby_Jamner123.RadiologyPatientList ON Ruby_Jamner123.Patient_Registration.PID = Ruby_Jamner123.RadiologyPatientList.IPDID Where RadiologyPatientList.Purpose='IPD'", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["IPDID"].Visible = false;
                Purpose = Convert.ToString(dataGridView1.CurrentRow.Cells["Purpose"].Value);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            showOPD();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showIPD();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showOnlyTest();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;
                string columnName = this.dataGridView1.Columns[e.ColumnIndex].Name;

                if (columnName.Equals("Name") == true)
                {
                    try
                    {
                        if (Purpose == "OPD" || Purpose == "Only Test")
                        {

                            OPDId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["OPDID"].Value);

                            OPD_ECG_and_Radiology_list o = new OPD_ECG_and_Radiology_list(OPDId, Purpose);
                            o.Show();
                        }

                       if(Purpose=="IPD")
                       {
                        IPDId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IPDID"].Value);
                        OPD_ECG_and_Radiology_list o = new OPD_ECG_and_Radiology_list(IPDId);
                        o.Show();
                    }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            

           
        }
    }
}
