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
    public partial class IPD_lab_test : Form
    {
        int id;
        public int DeleteID;
        public int Public_IPD_procedureID = 0;
        public string Public_IPD_ProcedureCharges = "";
        public int Public_LabTestTypeID;
        public int AddLab;
        public IPD_lab_test()
        {
            InitializeComponent();
        }
        public IPD_lab_test( int a)
        {
            InitializeComponent();
            id = a;
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {


        }
        //public void labtype()
        //{
        //    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(@"Select * from Master_LabTestType", con);
        //    SqlDataAdapter adt = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    adt.Fill(dt);
        //    if(dt.Rows.Count>0)
        //    {
        //        cmblabtest.DataSource = dt;
        //        cmblabtest.DisplayMember = "LabTestType_Name";
        //        cmblabtest.ValueMember = "LabTestTypeID";
        //    }          
        //}
        private void IPD_lab_test_Load(object sender, EventArgs e)
        {
            //labtype();
            //test();
            //showdata();
            //show_ADD();
            button7.Visible = false;
        }        
        //public void test()
        //{
        //    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(@"Select * from Master_LabTest WHERE  (LabTestTypeID=@LabTestTypeID)", con);
        //    cmd.Parameters.AddWithValue("@LabTestTypeID", cmblabtest.SelectedIndex);
        //    SqlDataAdapter adt = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    adt.Fill(dt);
        //    if (dt.Rows.Count > 0)
        //    {
        //        comlab.DataSource = dt;
        //        comlab.DisplayMember = "LabTestName";
        //        comlab.ValueMember = "LabTestID";
        //        Public_IPD_procedureID = Convert.ToInt32(dt.Rows[0]["LabTestID"]);
        //        Public_IPD_ProcedureCharges = Convert.ToString(dt.Rows[0]["HospCharge"]);
        //        Public_LabTestTypeID = Convert.ToInt32(dt.Rows[0]["LabTestTypeID"]);
        //    }
        //    //if (comlab.Text != "")
        //    //{
        //    //    Public_IPD_procedureID = Convert.ToInt32(dt.Rows[0]["LabTestID"]);
        //    //    Public_IPD_ProcedureCharges = Convert.ToString(dt.Rows[0]["HospCharge"]);
        //    //    Public_LabTestTypeID= Convert.ToInt32(dt.Rows[0]["LabTestTypeID"]);
        //    //}
        //}
//        public void showdata_lab()
//        {
//            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
//            con.Open();
//            SqlCommand cmd = new SqlCommand(@"SELECT Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Age, Ruby_Jamner123.Patient_Registration.Mobile_Number, Ruby_Jamner123.Patient_Registration.Doctors_Name, 
//                         Ruby_Jamner123.IPD_Registration.Date_Of_Admission
//FROM            Ruby_Jamner123.IPD_Registration INNER JOIN
//                         Ruby_Jamner123.Patient_Registration ON Ruby_Jamner123.IPD_Registration.Patient_Id = Ruby_Jamner123.Patient_Registration.PID
//WHERE        (Ruby_Jamner123.IPD_Registration.Patient_Id = @Patient_Id)", con);
//            cmd.Parameters.AddWithValue(@"Patient_Id", id);
//            SqlDataAdapter adt = new SqlDataAdapter(cmd);
//            DataTable o = new DataTable();
//            adt.Fill(o);
//            if (o.Rows.Count > 0)
//            {
//                dataGridView1.DataSource = o;
//            }
//        }
//        public void Save_lab()
//        {
//            try
//            {
//                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
//                con.Open();
//                SqlCommand cmd = new SqlCommand(@"Insert into AssignIPDLabTest (IPDID,LabTestTypeID,labTestID,LabTest,Charges,TestDate) Values(@IPDID,@LabTestTypeID,@labTestID,@LabTest,@Charges,@TestDate)", con);
//                cmd.Parameters.AddWithValue("@IPDID", id);
//                cmd.Parameters.AddWithValue("@LabTestTypeID", Public_LabTestTypeID);
//                cmd.Parameters.AddWithValue("@labTestID", Public_IPD_procedureID);
//                cmd.Parameters.AddWithValue("@LabTest", comlab.Text);
//                cmd.Parameters.AddWithValue("@Charges", Public_IPD_ProcedureCharges);
//                cmd.Parameters.AddWithValue("@TestDate", dtpTest.Text);
//                // cmd.Parameters.AddWithValue("@DleStatus", "1");
//                cmd.ExecuteNonQuery();
//                AddLab = 1;
//                //MessageBox.Show("Record Added");
//                show_ADD_lab();
//                button7.Visible = true;
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.ToString());
//            }
//        }
//        public void show_ADD_lab()
//        {
//            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
//            con.Open();
//            SqlCommand cmd = new SqlCommand(@"Select * From AssignIPDLabTest where IPDID=@a", con);
//            cmd.Parameters.AddWithValue(@"a", id);
//            SqlDataAdapter adt = new SqlDataAdapter(cmd);
//            DataTable dtPublic = new DataTable();
//            adt.Fill(dtPublic);
//            if (dtPublic.Rows.Count > 0)
//            {
//                dataGridView2.DataSource = dtPublic;
//                dataGridView2.Columns["ID"].Visible = false;
//                dataGridView2.Columns["IPDID"].Visible = false;
//                dataGridView2.Columns["LabTestTypeID"].Visible = false;
//                dataGridView2.Columns["labTestID"].Visible = false;
//                dataGridView2.Columns["Charges"].Visible = false;
//                dataGridView2.Columns["TestDate"].Visible = false;                
//                dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView2.Font, FontStyle.Bold);
//            }
//            //button5.Visible = true;
//        }
        private void cmblabtest_TextChanged(object sender, EventArgs e)
        {
            //test();
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Save();
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(AddLab==1)
            {
                MessageBox.Show("Record Added successfully");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            string columnName = this.dataGridView2.Columns[e.ColumnIndex].Name;
            if (columnName.Equals("Delete") == true)
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    DeleteID = Convert.ToInt32(dataGridView2.CurrentRow.Cells["ID"].Value);

                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"delete from AssignIPDLabTest where ID=@DeleteID", con);
                    cmd.Parameters.AddWithValue("@DeleteID", DeleteID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted Successfully..");
                    IPD_lab_test_Load(sender, e);
                }
                //this.Load(object sender, EventArgs e);
            }
        }
    }
}
