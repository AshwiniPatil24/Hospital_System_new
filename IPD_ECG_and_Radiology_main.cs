using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ruby_Hospital
{
    public partial class IPD_ECG_and_Radiology_main : Form
    {
        public int id;
        public int RadiologyTestId;
        public string RadiologyCharges;
        int Radiology = 0;
        public decimal RVerifyAmount = 0;
        public IPD_ECG_and_Radiology_main()
        {
            InitializeComponent();
        }
        public IPD_ECG_and_Radiology_main(int a)
        {
            InitializeComponent();
            id = a;
        }
        public void show_Radiology()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * From Master_Radiology_Test", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if(dt.Rows.Count>0)
            {
                comradiology.DataSource = dt;
                comradiology.DisplayMember = "Name";
                comradiology.ValueMember = "Radiology_ID";
                RadiologyTestId = Convert.ToInt32(dt.Rows[0]["Radiology_ID"]);
                RadiologyCharges = Convert.ToString(dt.Rows[0]["Charges"]);
            }

        }
        public void showdata_Radiology()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT        Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Age, Ruby_Jamner123.Patient_Registration.Mobile_Number, Ruby_Jamner123.Patient_Registration.Doctors_Name, 
                         Ruby_Jamner123.IPD_Registration.Date_Of_Admission
FROM            Ruby_Jamner123.IPD_Registration INNER JOIN
                         Ruby_Jamner123.Patient_Registration ON Ruby_Jamner123.IPD_Registration.Patient_Id = Ruby_Jamner123.Patient_Registration.PID
WHERE        (Ruby_Jamner123.IPD_Registration.Patient_Id = @Patient_Id)", con);
            cmd.Parameters.AddWithValue(@"Patient_Id", id);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable o = new DataTable();
            adt.Fill(o);
            if (o.Rows.Count > 0)
            {
              //  RadiologyGrid.DataSource = o;

            }
        }

        private void IPD_ECG_and_Radiology_main_Load(object sender, EventArgs e)
        {
            //int w = Screen.PrimaryScreen.Bounds.Width;
            //int h = Screen.PrimaryScreen.Bounds.Height;
            //this.Location = new Point(0, 0);
            //this.Size = new Size(w, h);
            show_Radiology();
            showdata_Radiology();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //RadiologySave();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //public void RadiologySave()
        //{
        //    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(@"Insert into Assign_IPDRadiology_test (IPDID,RadiologyID,RadiologyName,Charges,TestDate) Values(@IPDID,@RadiologyID,@RadiologyName,@Charges,@TestDate)", con);
        //    cmd.Parameters.AddWithValue("@IPDID", id);
        //    cmd.Parameters.AddWithValue("@RadiologyID", RadiologyTestId);
        //    cmd.Parameters.AddWithValue("@RadiologyName", comradiology.Text);
        //    cmd.Parameters.AddWithValue("@Charges", RadiologyCharges);
        //    cmd.Parameters.AddWithValue("@TestDate", dtptestDate.Text);
        //    cmd.ExecuteNonQuery();
        //    RVerifyAmount = Convert.ToDecimal(lbRadiologyAmount.Text) + Convert.ToDecimal(RadiologyCharges.ToString());
        //    lbRadiologyAmount.Text = RVerifyAmount.ToString();
        //    Radiologyshow_ADD();
        //    Radiology = 1;
        //    button2.Visible = true;


        //}
        //public void Radiologyshow_ADD()
        //{
        //    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(@"Select * From Assign_IPDRadiology_test where IPDID=@a", con);
        //    cmd.Parameters.AddWithValue(@"a", id);
        //    SqlDataAdapter adt = new SqlDataAdapter(cmd);
        //    DataTable dtPublic = new DataTable();

        //    adt.Fill(dtPublic);
        //    dataGridView4.DataSource = dtPublic;
        //    dataGridView4.Columns["ID"].Visible = false;
        //    dataGridView4.Columns["IPDID"].Visible = false;
        //    dataGridView4.Columns["RadiologyID"].Visible = false;

        //    // dataGridView4.Columns["Charges"].Visible = false;
        //    dataGridView4.Columns["TestDate"].Visible = false;

        //    dataGridView4.Columns["RadiologyName"].HeaderText = "Radiology Test";
        //    dataGridView4.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView4.Font, FontStyle.Bold);
        //}

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
