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
    public partial class IPD_Registration : Form
    {
        string IIDA = "IPD/RSHJ";
        int countpatient;
        int abc;
        int A;
        public int Public_BEDID;
       public IPD_Registration()
        {
            InitializeComponent();
        }
      
        public IPD_Registration(int abc)
        {
            A = abc;
            InitializeComponent();

        }

        public void show_PatientDetails()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT  Name, Age, Mobile_Number, Doctors_Name
FROM           Patient_Registration
WHERE        (PID = @PID)", con);
            cmd.Parameters.AddWithValue("@PID", abc);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable o = new DataTable();
            adt.Fill(o);
            if (o.Rows.Count > 0)
            {
                DVGPatientInfo.DataSource = o;
                DVGPatientInfo.ColumnHeadersDefaultCellStyle.Font = new Font(DVGPatientInfo.Font, FontStyle.Bold);

            }
        }
        private void IPD_Registration_Load(object sender, EventArgs e)
        {
            rowcountipd();
            // txtidi.Text = A;
            generateAutoIId();
            //int w = Screen.PrimaryScreen.Bounds.Width;
            //int h = Screen.PrimaryScreen.Bounds.Height;
            //this.Location = new Point(0, 0);
            //this.Size = new Size(w, h);
            FetchDoctor();
            Referred_Doctor();
            show_PatientDetails();
            BindRoomsegment();
            BindbedNo();

        }
        public void rowcountipd()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select * from Patient_Registration", con);
            SqlDataAdapter s = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            s.Fill(dt);
            abc = dt.Rows.Count;
            //abc = abc + 6;
            txtidi.Text = abc.ToString();
        }
        public void generateAutoIId()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select Count(IPDID) From IPD_Registration", con);
            int i = Convert.ToInt32(cmb.ExecuteScalar());
            con.Close();
            i++;
            string a = i.ToString("0000");
            txtPatientIPDID.Text = IIDA + a;
        }
        public void BindRoomsegment()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Master_IPDRoomSegment", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                cmbRoomSegment.DataSource = dt;
                cmbRoomSegment.DisplayMember = "Name";
                cmbRoomSegment.ValueMember = "ID";
            }

        }
        public void BindbedNo()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Master_IPDBedNo where (RoomSegmentID=@RoomSegmentID) and IsVacant=0", con);
            cmd.Parameters.AddWithValue(@"RoomSegmentID", cmbRoomSegment.SelectedIndex);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                cmb_BedNo.DataSource = dt;
                cmb_BedNo.DisplayMember = "BedNo";
                cmb_BedNo.ValueMember = "ID";
                if (cmb_BedNo.Text != "")
                {
                    Public_BEDID = Convert.ToInt32(dt.Rows[0]["ID"]);
                    txtIDBed.Text = Public_BEDID.ToString();
                }

            }

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtmlc.Checked == true)
            {
                MLC_Details md = new MLC_Details();
                md.Show();
            }
        }
        public void rowcount()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select * from Patient_Registration", con);
            SqlDataAdapter s = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            s.Fill(dt);
            countpatient = dt.Rows.Count;
        }

        private void bunSave_Click(object sender, EventArgs e)
        {
            try
            {
                rowcount();
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"Insert into IPD_Registration (IPD_ID,Patient_Id,Relatives_Name,Relation,Relative_Mobile_No,
                                Date_Of_Admission,Type_Of_Admission,Mediclaim
                   ,Room_Segment,Bed_No,ConsultantID,Reserred_By,MLC_NonMLC,DischargeDate,Remark) Values(@IPD_ID,@Patient_Id,@Relatives_Name,@Relation,@Relative_Mobile_No,@Date_Of_Admission,@Type_Of_Admission,@Mediclaim
                   ,@Room_Segment,@Bed_No,@ConsultantID,@Reserred_By,@MLC_NonMLC,@DischargeDate,@Remark)", con);

                cmd.Parameters.AddWithValue("@IPD_ID",txtPatientIPDID.Text);
                cmd.Parameters.AddWithValue("@Patient_Id", countpatient);
                cmd.Parameters.AddWithValue("@Relatives_Name", txtReativeName.Text);
                cmd.Parameters.AddWithValue("@Relation", cmbRelation.Text);
                cmd.Parameters.AddWithValue("@Relative_Mobile_No", txtRelativeMobileNo.Text);
                cmd.Parameters.AddWithValue("@Date_Of_Admission", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@Type_Of_Admission", cmbTypeOfAddmission.Text);
                cmd.Parameters.AddWithValue("@Mediclaim", cmbMediclaim.Text);
                cmd.Parameters.AddWithValue("@Room_Segment", cmbRoomSegment.Text);
                cmd.Parameters.AddWithValue("@Bed_No", cmb_BedNo.Text);
                cmd.Parameters.AddWithValue("@ConsultantID", cmbConsultant.Text);
                cmd.Parameters.AddWithValue("@Reserred_By", cmbReferredBy.Text);
                cmd.Parameters.AddWithValue("@Remark", txtRemark.Text);

                if (rbtnonmlc.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@MLC_NonMLC", "NON MLC");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MLC_NonMLC", "MLC");
                }
                cmd.Parameters.AddWithValue("@DischargeDate", dateTimePicker1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Added Successfully ...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtReativeName_MouseClick(object sender, MouseEventArgs e)
        {
            txtReativeName.Clear();
        }

        private void txtRelativeMobileNo_MouseClick(object sender, MouseEventArgs e)
        {
            txtRelativeMobileNo.Clear();
        }

        private void cmbRoomSegment_Click(object sender, EventArgs e)
        {

        }




        private void txtPatientIPDID_Leave(object sender, EventArgs e)
        {
            if (txtPatientIPDID.Text == "")
            {
                txtPatientIPDID.Text = "123456789";
                txtPatientIPDID.ForeColor = Color.Gray;
            }
        }

        public void FetchDoctor()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand com = new SqlCommand(@"Select * From Doctors", con);
            SqlDataAdapter adt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                cmbConsultant.DataSource = dt;
                cmbConsultant.DisplayMember = "Dr_Name";
                cmbConsultant.ValueMember = "DR_ID";
            }
            con.Close();
        }
        public void Referred_Doctor()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand com = new SqlCommand(@"Select * From Referred_Doctor", con);
            SqlDataAdapter adt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                cmbReferredBy.DataSource = dt;
                cmbReferredBy.DisplayMember = "Referred_Name";
                cmbReferredBy.ValueMember = "ReferredID";
            }
            con.Close();
        }

        private void cmbRoomSegment_TextChanged(object sender, EventArgs e)
        {
            BindbedNo();
        }
    }
}


