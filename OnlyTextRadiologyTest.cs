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
    public partial class OnlyTextRadiologyTest : Form
    {
        public int a;
        public int Radiology;
        public int RadiologyTestId;
        public string RadiologyCharges;
        public int Public_ID;
        public decimal OTTotalAmount;
        public decimal PublicRadiologyCharges;
        public int Radiologysave = 0;
        public decimal TotalRadiology = 0;
        public OnlyTextRadiologyTest()
        {
            InitializeComponent();
        }
        public OnlyTextRadiologyTest(int OpdTestID)
        {
            InitializeComponent();
             a = OpdTestID;

        }
        public void showPatientDetails()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();

            SqlCommand cmd = new SqlCommand(@" SELECT  Ruby_Jamner123.OPD_Patient_Registration.PatientOPDIdWithSr, Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Age, Ruby_Jamner123.Patient_Registration.Mobile_Number, 
                         Ruby_Jamner123.Patient_Registration.Doctors_Name, Ruby_Jamner123.Patient_Registration.Referred_By, Ruby_Jamner123.OPD_Patient_Registration.PatientOPDId
FROM            Ruby_Jamner123.OPD_Patient_Registration INNER JOIN
                         Ruby_Jamner123.Patient_Registration ON Ruby_Jamner123.OPD_Patient_Registration.PatientId = Ruby_Jamner123.Patient_Registration.PID where Ruby_Jamner123.OPD_Patient_Registration.PatientOPDId=@a ", con);
            cmd.Parameters.AddWithValue("@a", a);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable o = new DataTable();
            adt.Fill(o);
            if (o.Rows.Count > 0)
            {
                dataGridView1.DataSource = o;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                dataGridView1.Columns["PatientOPDIdWithSr"].HeaderText = "OPD_ID";
                dataGridView1.Columns["PatientOPDId"].Visible = false;
            }


        }
        private void OnlyTextRadiologyTest_Load(object sender, EventArgs e)
        {
            show();
            showPatientDetails();
            show_ADD();
            FetchingOnlyAmount_RadiologyTest();
            lbOnlyTest.Text=TotalRadiology.ToString();

        }
        public void show()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"SELECT * from Master_Radiology_Test", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if(dt.Rows.Count>0)
            {
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Radiology_ID";
                RadiologyTestId = Convert.ToInt32(dt.Rows[0]["Radiology_ID"]);
                RadiologyCharges = Convert.ToString(dt.Rows[0]["Charges"]);
            }

        }
        public void Save()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Insert into AssignOnlyTest_Radiology (OPDID,RadiologyID,RadiologyName,Charges,TestDate) Values(@OPDID,@RadiologyID,@RadiologyName,@Charges,@TestDate)", con);
            cmd.Parameters.AddWithValue("@OPDID", a);
            cmd.Parameters.AddWithValue("@RadiologyID", RadiologyTestId);
            cmd.Parameters.AddWithValue("@RadiologyName", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Charges", RadiologyCharges);
            cmd.Parameters.AddWithValue("@TestDate", dtptestDate.Text);
            cmd.ExecuteNonQuery();
            show_ADD();
            OTTotalAmount = Convert.ToDecimal(lbOnlyTest.Text) + Convert.ToDecimal(RadiologyCharges.ToString());
            lbOnlyTest.Text = OTTotalAmount.ToString();

            Radiology = 1;
            button2.Enabled = true;
            button2.BackColor = Color.DarkGreen;

        }
        public void show_ADD()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * From AssignOnlyTest_Radiology where OPDID=@a", con);
            cmd.Parameters.AddWithValue(@"a", a);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dtPublic = new DataTable();

            adt.Fill(dtPublic);
            dataGridView2.DataSource = dtPublic;
            dataGridView2.Columns["ID"].Visible = false;
            dataGridView2.Columns["OPDID"].Visible = false;
            dataGridView2.Columns["RadiologyID"].Visible = false;
            dataGridView2.Columns["Charges"].Visible = false;
            dataGridView2.Columns["TestDate"].Visible = false;

            dataGridView2.Columns["RadiologyName"].HeaderText = "Radiology Test";
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);


        }
        public void Save_AmountOnlyRadiology()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Insert into Billing_OnlyRTAmount (OPDID,OnlyRTotalAmount) Values(@OPDID,@OnlyRTotalAmount)", con);
            cmd.Parameters.AddWithValue("@OPDID", a);
            cmd.Parameters.AddWithValue("@OnlyRTotalAmount", lbOnlyTest.Text);
            cmd.ExecuteNonQuery();

        }
        public void Update_AmountOnlyRadiology()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Update Billing_OnlyRTAmount set OnlyRTotalAmount=@OnlyRTotalAmount where OPDID=@a", con);
            cmd.Parameters.AddWithValue("@a", a);
            cmd.Parameters.AddWithValue("@OnlyRTotalAmount", lbOnlyTest.Text);
            cmd.ExecuteNonQuery();


        }
        public void FetchingOnlyAmount_RadiologyTest()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * From Billing_OnlyRTAmount where OPDID=@a", con);
            cmd.Parameters.AddWithValue(@"a", a);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dtPublic = new DataTable();
            adt.Fill(dtPublic);
            if (dtPublic.Rows.Count > 0)
            {
                TotalRadiology = Convert.ToDecimal(dtPublic.Rows[0]["OnlyRTotalAmount"]);
            }
        }

        private void dtptestDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
                Radiologysave = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {


                if (Radiology == 1)
                {
                    Radiologysave = 1;
                    MessageBox.Show("Record Added Successfully");
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"Select * From Billing_OnlyRTAmount where OPDID=@a", con);
                    cmd.Parameters.AddWithValue(@"a",a);
                    SqlDataAdapter adt = new SqlDataAdapter(cmd);
                    DataTable dtPublic = new DataTable();
                    adt.Fill(dtPublic);
                    if (dtPublic.Rows.Count > 0)
                    {
                        Update_AmountOnlyRadiology();
                        button2.Enabled = false;
                        button2.BackColor = Color.Silver;
                    }
                    else
                    {
                        Save_AmountOnlyRadiology();
                        button2.Enabled = false;
                        button2.BackColor = Color.Silver;
                    }
                }
                else
                {
                    MessageBox.Show("First Add Test");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                    Public_ID = Convert.ToInt32(dataGridView2.CurrentRow.Cells["ID"].Value);
                    PublicRadiologyCharges= Convert.ToInt32(dataGridView2.CurrentRow.Cells["Charges"].Value);
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"Delete from AssignOnlyTest_Radiology where ID=@Public_ID", con);
                    cmd.Parameters.AddWithValue("@Public_ID", Public_ID);

                    cmd.ExecuteNonQuery();


                    MessageBox.Show("Record Deleted Successfully..");
                    if (Radiologysave == 1)
                    {
                        Radiologysave = 0;
                        FetchingOnlyAmount_RadiologyTest();
                        lbOnlyTest.Text = (TotalRadiology - PublicRadiologyCharges).ToString();

                    }
                    else
                    {
                        lbOnlyTest.Text = (Convert.ToDecimal(lbOnlyTest.Text) - PublicRadiologyCharges).ToString();

                    }
                    Update_AmountOnlyRadiology();
                    show_ADD();
                    //OnlyTextRadiologyTest_Load(sender, e);

                }

            }
        }
    }
}
