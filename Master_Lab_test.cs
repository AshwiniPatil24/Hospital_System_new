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
    public partial class Master_Lab_test : Form
    {
        public Master_Lab_test()
        {
            InitializeComponent();
        }

        private void Master_Lab_test_Load(object sender, EventArgs e)
        {
            show();
        }
        public void show()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * from Master_LabTestType", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if(dt.Rows.Count>0)
            {
                comtype.DataSource = dt;
                comtype.DisplayMember = "LabTestType_Name";
                comtype.ValueMember = "LabTestTypeID";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           if(txtsearch.Text=="")
            {
                insert();
            }
            else
            {
                
                update();
            }
        }
        public void insert()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT into Master_LabTest (LabTestTypeID,LabTestName,LabTestCharge,HospCharge,Lab_Test_Details,CreatedOn)
values            (@LabTestTypeID,@LabTestName,@LabTestCharge,@HospCharge,@Lab_Test_Details,@CreatedOn)  ", con);
            cmd.Parameters.AddWithValue("@LabTestTypeID", comtype.SelectedIndex);
            cmd.Parameters.AddWithValue("@LabTestName", txtname.Text);
            cmd.Parameters.AddWithValue("@LabTestCharge", txtcharge.Text);
            cmd.Parameters.AddWithValue("@HospCharge", txthosp_charge.Text);
            cmd.Parameters.AddWithValue("@Lab_Test_Details", txtdetails.Text);
            cmd.Parameters.AddWithValue("@CreatedOn", txtdate.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("inserted successfully.....!");
            con.Close();
        }
        public void update()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Update Master_LabTest set(LabTestTypeID=@LabTestTypeID,LabTestName=@LabTestName,LabTestCharge=@LabTestCharge,HospCharge=@HospCharge,Lab_Test_Details=@Lab_Test_Details,UpdatedOn=@UpdatedOn)
WHERE  (LabTestName=@LabTestName)", con);
            cmd.Parameters.AddWithValue("@LabTestTypeID", comtype.SelectedIndex);
            cmd.Parameters.AddWithValue("@LabTestName", txtsearch.Text);
            cmd.Parameters.AddWithValue("@LabTestCharge", txtcharge.Text);
            cmd.Parameters.AddWithValue("@HospCharge", txthosp_charge.Text);
            cmd.Parameters.AddWithValue("@Lab_Test_Details", txtdetails.Text);
            cmd.Parameters.AddWithValue("@UpdatedOn", txtdate.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("inserted successfully.....!");
            con.Close();
        }
        public void Search()
        {
           
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT        Ruby_Jamner123.Master_LabTestType.LabTestType_Name, Ruby_Jamner123.Master_LabTest.LabTestName, Ruby_Jamner123.Master_LabTest.LabTestCharge, Ruby_Jamner123.Master_LabTest.HospCharge, 
                         Ruby_Jamner123.Master_LabTest.Lab_Test_Details
FROM            Ruby_Jamner123.Master_LabTest INNER JOIN
                         Ruby_Jamner123.Master_LabTestType ON Ruby_Jamner123.Master_LabTest.LabTestTypeID = Ruby_Jamner123.Master_LabTestType.LabTestTypeID
WHERE        (Ruby_Jamner123.Master_LabTest.LabTestName = @LabTestName)", con);
            cmd.Parameters.AddWithValue("@LabTestName", txtsearch.Text);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
           // IDOPDProc = Convert.ToInt32(dt.Rows[0]["OPD_ProcedureID"]);
            if (dt.Rows.Count > 0)
            {
                txtname.DataBindings.Add("Text", dt, "LabTestName");
                txtcharge.DataBindings.Add("Text", dt, "LabTestCharge");
                txthosp_charge.DataBindings.Add("Text", dt, "HospCharge");
                txtdetails.DataBindings.Add("Text", dt, "Lab_Test_Details");
               
            }
            
            con.Close();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            clear();
            if (txtsearch.Text!="")
            {
                txtname.Enabled = false;
            }
            else
            {
                txtname.Enabled = true;
            }
            Search();
            
        }
        public void clear()
        {
            txtcharge.Clear();
            txtdetails.Clear();
            txthosp_charge.Clear();
            txtname.Clear();
            comtype.Text = "";
        }
    }
}
