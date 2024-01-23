using System;
using System.Collections;
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
    public partial class IPD_Daily_Procedure_main : Form
    {
        AutoCompleteStringCollection drugNamesCollection = new AutoCompleteStringCollection();
        public int Public_Ipd_ProcedureCharges;
        int a;//PID
        int b;//IPDID
        int LoadSave = 0;
        public int DeleteId;
        public int AddSave;
        public int TotalASave;
        public decimal TotaIPDpro;
        public decimal TotaIPDpro1; 
        public decimal TotaIPDRadiology; 
        public string Public_HosProcCharges;
        //int id;
        public int DeleteID;
        public int Public_IPD_procedureID = 0;
        public string Public_IPD_ProcedureCharges = "";
        public int Public_LabTestTypeID;
        public int AddLab;
        //public int id;
        public int RadiologyTestId;
        public string RadiologyCharges;
        int Radiology = 0;
        public decimal RVerifyAmount = 0;
        public decimal Public_Charges = 0;
        public decimal VerifyAmount = 0;
        public IPD_Daily_Procedure_main()
        {
            InitializeComponent();
          //  AdjustFormSize();
        }

        public IPD_Daily_Procedure_main(int PID,int IPDID)
        {
            InitializeComponent();
            a = PID;
            b = IPDID;
           // datatr();
            //  AdjustFormSize();
        }
        private void AdjustFormSize()
        {
            Rectangle screen = Screen.PrimaryScreen.Bounds;
            int screenWidth = screen.Width;
            int screenHeight = screen.Height;

            // Set the form size to match the screen resolution
            this.Width = screenWidth;
            this.Height = screenHeight;

            // Center the form on the screen
            this.StartPosition = FormStartPosition.CenterScreen;
        }


//        public void showdata_lab()
//        {
//            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
//            con.Open();
//            SqlCommand cmd = new SqlCommand(@"SELECT Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Age, Ruby_Jamner123.Patient_Registration.Mobile_Number, Ruby_Jamner123.Patient_Registration.Doctors_Name, 
//                         Ruby_Jamner123.IPD_Registration.Date_Of_Admission
//FROM            Ruby_Jamner123.IPD_Registration INNER JOIN
//                         Ruby_Jamner123.Patient_Registration ON Ruby_Jamner123.IPD_Registration.Patient_Id = Ruby_Jamner123.Patient_Registration.PID
//WHERE        (Ruby_Jamner123.IPD_Registration.Patient_Id = @Patient_Id)", con);
//            cmd.Parameters.AddWithValue(@"Patient_Id", a);
//            SqlDataAdapter adt = new SqlDataAdapter(cmd);
//            DataTable o = new DataTable();
//            adt.Fill(o);
//            if (o.Rows.Count > 0)
//            {
//                dataGridView1.DataSource = o;
//            }
//        }
        public void Save_lab()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"Insert into AssignIPDLabTest (IPDID,LabTestTypeID,labTestID,LabTest,Charges,TestDate) Values(@IPDID,@LabTestTypeID,@labTestID,@LabTest,@Charges,@TestDate)", con);
                cmd.Parameters.AddWithValue("@IPDID", b);
                cmd.Parameters.AddWithValue("@LabTestTypeID", Public_LabTestTypeID);
                cmd.Parameters.AddWithValue("@labTestID", Public_IPD_procedureID);
                cmd.Parameters.AddWithValue("@LabTest", comlab.Text);
                cmd.Parameters.AddWithValue("@Charges", Public_IPD_ProcedureCharges);
                cmd.Parameters.AddWithValue("@TestDate", datelab.Text);
                // cmd.Parameters.AddWithValue("@DleStatus", "1");
                cmd.ExecuteNonQuery();
                AddLab = 1;
                VerifyAmount = Convert.ToDecimal(lbLabTest.Text) + Convert.ToDecimal(Public_IPD_ProcedureCharges.ToString());

                lbLabTest.Text = VerifyAmount.ToString();
                show_ADD_lab();
                button16.Enabled = true;
                button16.BackColor = Color.DarkGreen;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void show_ADD_lab()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * From AssignIPDLabTest where IPDID=@b", con);
            cmd.Parameters.AddWithValue(@"b", b);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dtPublic = new DataTable();
            adt.Fill(dtPublic);
            if (dtPublic.Rows.Count > 0)
            {
                dataGridView5.DataSource = dtPublic;
                dataGridView5.Columns["ID"].Visible = false;
                dataGridView5.Columns["IPDID"].Visible = false;
                dataGridView5.Columns["LabTestTypeID"].Visible = false;
                dataGridView5.Columns["labTestID"].Visible = false;
                dataGridView5.Columns["Charges"].Visible = true;
                dataGridView5.Columns["TestDate"].Visible = false;
                dataGridView5.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView2.Font, FontStyle.Bold);
            }
           
        }
        public void showdata_lab()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Age, Ruby_Jamner123.Patient_Registration.Mobile_Number, Ruby_Jamner123.Patient_Registration.Doctors_Name, 
                         Ruby_Jamner123.IPD_Registration.Date_Of_Admission
FROM            Ruby_Jamner123.IPD_Registration INNER JOIN
                         Ruby_Jamner123.Patient_Registration ON Ruby_Jamner123.IPD_Registration.Patient_Id = Ruby_Jamner123.Patient_Registration.PID
WHERE        (Ruby_Jamner123.IPD_Registration.Patient_Id = @Patient_Id)", con);
            cmd.Parameters.AddWithValue(@"Patient_Id", a);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable o = new DataTable();
            adt.Fill(o);
            if (o.Rows.Count > 0)
            {
                dataGridView1.DataSource = o;
            }
        }
        public void labtype()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * from Master_LabTestType", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                cmblabtest.DataSource = dt;
                cmblabtest.DisplayMember = "LabTestType_Name";
                cmblabtest.ValueMember = "LabTestTypeID";
            }
        }
        public void test()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * from Master_LabTest WHERE  (LabTestTypeID=@LabTestTypeID)", con);
            cmd.Parameters.AddWithValue("@LabTestTypeID", cmblabtest.SelectedIndex);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                comlab.DataSource = dt;
                comlab.DisplayMember = "LabTestName";
                comlab.ValueMember = "LabTestID";
                Public_IPD_procedureID = Convert.ToInt32(dt.Rows[0]["LabTestID"]);
                Public_IPD_ProcedureCharges = Convert.ToString(dt.Rows[0]["HospCharge"]);
                Public_LabTestTypeID = Convert.ToInt32(dt.Rows[0]["LabTestTypeID"]);
            }
            //if (comlab.Text != "")
            //{
            //    Public_IPD_procedureID = Convert.ToInt32(dt.Rows[0]["LabTestID"]);
            //    Public_IPD_ProcedureCharges = Convert.ToString(dt.Rows[0]["HospCharge"]);
            //    Public_LabTestTypeID= Convert.ToInt32(dt.Rows[0]["LabTestTypeID"]);
            //}
        }
        public void RadiologySave()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Insert into Assign_IPDRadiology_test (IPDID,RadiologyID,RadiologyName,Charges,TestDate) Values(@IPDID,@RadiologyID,@RadiologyName,@Charges,@TestDate)", con);
            cmd.Parameters.AddWithValue("@IPDID", b);
            cmd.Parameters.AddWithValue("@RadiologyID", RadiologyTestId);
            cmd.Parameters.AddWithValue("@RadiologyName", comradiology.Text);
            cmd.Parameters.AddWithValue("@Charges", RadiologyCharges);
            cmd.Parameters.AddWithValue("@TestDate", datelab.Text);
            cmd.ExecuteNonQuery();
            RVerifyAmount = Convert.ToDecimal(lbRadiologyAmount.Text) + Convert.ToDecimal(RadiologyCharges.ToString());
            lbRadiologyAmount.Text = RVerifyAmount.ToString();
            Radiologyshow_ADD();
            Radiology = 1;

            button15.Enabled = true;
            button15.BackColor = Color.DarkGreen;


        }
        public void Radiologyshow_ADD()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * From Assign_IPDRadiology_test where IPDID=@b", con);
            cmd.Parameters.AddWithValue(@"b", b);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dtPublic = new DataTable();

            adt.Fill(dtPublic);
            RadiologyGrid.DataSource = dtPublic;
            RadiologyGrid.Columns["ID"].Visible = false;
            RadiologyGrid.Columns["IPDID"].Visible = false;
            RadiologyGrid.Columns["RadiologyID"].Visible = false;

            // dataGridView4.Columns["Charges"].Visible = false;
            RadiologyGrid.Columns["TestDate"].Visible = false;

            RadiologyGrid.Columns["RadiologyName"].HeaderText = "Radiology Test";
            RadiologyGrid.ColumnHeadersDefaultCellStyle.Font = new Font(RadiologyGrid.Font, FontStyle.Bold);
        }
        public void show_Radiology()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * From Master_Radiology_Test", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
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
WHERE        (Ruby_Jamner123.IPD_Registration.Patient_Id = @Patient_Id) and Ruby_Jamner123.IPD_Registration.IPDID = @ipdid", con);
            cmd.Parameters.AddWithValue(@"Patient_Id", a);
            cmd.Parameters.AddWithValue(@"ipdid", b);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable o = new DataTable();
            adt.Fill(o);
            if (o.Rows.Count > 0)
            {
                dataGridView1.DataSource = o;

            }
        }
        public void IPDHocprocSave()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Insert into Billing_IPDHosProc(IPDID,IPDHosProcAmount) Values(@IPDID,@IPDHosProcAmount)", con);
            cmd.Parameters.AddWithValue("@IPDID", b);
            cmd.Parameters.AddWithValue("@IPDHosProcAmount", lbhospTotalAmount.Text);
            cmd.ExecuteNonQuery();
        }
        
        public void IPDHocprocUpdate()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Update Billing_IPDHosProc set IPDHosProcAmount=@IPDHosProcAmount where IPDID=@IPDID", con);
            cmd.Parameters.AddWithValue("@IPDID", b);
            cmd.Parameters.AddWithValue("@IPDHosProcAmount", lbhospTotalAmount.Text);
            cmd.ExecuteNonQuery();

        }
        public void FetchingAmount_Procedure()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * From Billing_IPDHosProc where IPDID=@b", con);
            cmd.Parameters.AddWithValue(@"b", b);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dtPublic = new DataTable();
            adt.Fill(dtPublic);
            if (dtPublic.Rows.Count > 0)
            {
                TotaIPDpro1 = Convert.ToDecimal(dtPublic.Rows[0]["IPDHosProcAmount"]);
            }
        }
        public void IPDLabAmountSave()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Insert into Billing_IPDTotal_LabAmount(IPDID,TotalLabAmount) Values(@IPDID,@TotalLabAmount)", con);
            cmd.Parameters.AddWithValue("@IPDID", b);
            cmd.Parameters.AddWithValue("@TotalLabAmount", lbLabTest.Text);
            cmd.ExecuteNonQuery();
        }

        public void IPDLabAmountUpdate()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Update Billing_IPDTotal_LabAmount set TotalLabAmount=@TotalLabAmount where IPDID=@IPDID", con);
            cmd.Parameters.AddWithValue("@IPDID", b);
            cmd.Parameters.AddWithValue("@TotalLabAmount", lbLabTest.Text);
            cmd.ExecuteNonQuery();

        }
        public void FetchingAmount_Labtest()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * From Billing_IPDTotal_LabAmount where IPDID=@b", con);
            cmd.Parameters.AddWithValue(@"b", b);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dtPublic = new DataTable();
            adt.Fill(dtPublic);
            if (dtPublic.Rows.Count > 0)
            {
                TotaIPDpro = Convert.ToDecimal(dtPublic.Rows[0]["TotalLabAmount"]);
            }
        }
        public void IPDRadiologyAmountSave()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Insert into Billing_IPDTotal_RadiologyA(IPDID,TotalRadiologyAmount) Values(@IPDID,@TotalRadiologyAmount)", con);
            cmd.Parameters.AddWithValue("@IPDID", b);
            cmd.Parameters.AddWithValue("@TotalRadiologyAmount", lbRadiologyAmount.Text);
            cmd.ExecuteNonQuery();
        }

        public void IPDRadiologyAmountUpdate()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Update Billing_IPDTotal_RadiologyA set TotalRadiologyAmount=@TotalRadiologyAmount where IPDID=@IPDID", con);
            cmd.Parameters.AddWithValue("@IPDID", b);
            cmd.Parameters.AddWithValue("@TotalRadiologyAmount", lbRadiologyAmount.Text);
            cmd.ExecuteNonQuery();

        }
        public void FetchingAmount_Radiologytest()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * From Billing_IPDTotal_RadiologyA where IPDID=@b", con);
            cmd.Parameters.AddWithValue(@"b", b);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dtPublic = new DataTable();
            adt.Fill(dtPublic);
            if (dtPublic.Rows.Count > 0)
            {
                TotaIPDRadiology = Convert.ToDecimal(dtPublic.Rows[0]["TotalRadiologyAmount"]);
            }
        }
        private void IPD_Daily_Procedure_main_Load_1(object sender, EventArgs e)
        {
            //datatr();
            AdjustFormSize();
            showdata();
            Roomshowdata();
            Roomsegment();
            Beddata();
            AddHospital_procedure();
            ShowHospitalProcedure();
            BindDrugList();
            test();
            labtype();
            show_ADD_lab();
            showdata_lab();
            show_Radiology();
            showdata_Radiology();
            Radiologyshow_ADD();
            FetchingAmount_Procedure();
            FetchingAmount_Labtest();
            lbhospTotalAmount.Text = TotaIPDpro1.ToString();
            lbLabTest.Text = TotaIPDpro.ToString();
            lbRadiologyAmount.Text = TotaIPDRadiology.ToString();
            #region Auto Complete Property
            ArrayList ListArray = new ArrayList();
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * From Master_OPD_DrugsList", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);

           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                drugNamesCollection.Add(dt.Rows[i]["Name"].ToString());
            }

            txtGenericSelection.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtGenericSelection.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtGenericSelection.AutoCompleteCustomSource = drugNamesCollection;
            #endregion

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
        public void showdata()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT        Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Age, Ruby_Jamner123.Patient_Registration.Mobile_Number, Ruby_Jamner123.Patient_Registration.Doctors_Name, 
                         Ruby_Jamner123.IPD_Registration.Date_Of_Admission
FROM            Ruby_Jamner123.IPD_Registration INNER JOIN
                         Ruby_Jamner123.Patient_Registration ON Ruby_Jamner123.IPD_Registration.Patient_Id = Ruby_Jamner123.Patient_Registration.PID
WHERE        (Ruby_Jamner123.IPD_Registration.Patient_Id = @Patient_Id)  and Ruby_Jamner123.IPD_Registration.IPDID = @ipdid", con);
            cmd.Parameters.AddWithValue(@"Patient_Id", a);
            cmd.Parameters.AddWithValue(@"ipdid", b);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable o = new DataTable();
            adt.Fill(o);
            if (o.Rows.Count > 0)
            {
                dataGridView1.DataSource = o;

            }
        }
        public void Roomshowdata()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT        Ruby_Jamner123.IPD_Registration.Room_Segment, Ruby_Jamner123.IPD_Registration.Bed_No
FROM            Ruby_Jamner123.IPD_Registration INNER JOIN
                         Ruby_Jamner123.Patient_Registration ON Ruby_Jamner123.IPD_Registration.Patient_Id = Ruby_Jamner123.Patient_Registration.PID
WHERE        (Ruby_Jamner123.IPD_Registration.Patient_Id = @Patient_Id) and Ruby_Jamner123.IPD_Registration.IPDID = @ipdid", con);
            cmd.Parameters.AddWithValue(@"Patient_Id", a);
            cmd.Parameters.AddWithValue(@"ipdid", b);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable o = new DataTable();
            adt.Fill(o);
            if (o.Rows.Count > 0)
            {

                oldroom.DataSource = o;
                oldroom.DisplayMember = "Room_Segment";
                // oldroom.ValueMember = "Patient_Id";
                BedNo.DataSource = o;
                BedNo.DisplayMember = "Bed_No";
            }
        }
        public void Roomsegment()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * from Master_IPDRoomSegment", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable o = new DataTable();
            adt.Fill(o);
            if (o.Rows.Count > 0)
            {

                newRoomS.DataSource = o;
                newRoomS.DisplayMember = "Name";
                newRoomS.ValueMember = "id";
               
            }
        }   
        public void Beddata()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT BedNo, RoomSegmentID FROM Ruby_Jamner123.Master_IPDBedNo WHERE (RoomSegmentID = @RoomSegmentID) and isvacant = 0", con);
            cmd.Parameters.AddWithValue(@"RoomSegmentID", newRoomS.SelectedIndex + 1);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable o = new DataTable();
            adt.Fill(o);
            if (o.Rows.Count > 0)
            {
                comboBox3.DataSource = o;
                comboBox3.DisplayMember = "BedNo";
                //comboBox3.ValueMember = "id";
            }
        }
        public void ShowHospitalProcedure()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * From Master_IPDHospitalProcedure", con);

            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {


                cmbHospitalMain.DataSource = dt;
                cmbHospitalMain.DisplayMember = "ProcedureName";
                cmbHospitalMain.ValueMember = "ProcedureId";
                if (cmbHospitalMain.Text != "")

                {

                    Public_HosProcCharges = Convert.ToString(dt.Rows[0]["HospCharge"]);
                }
            }
        }
        public void datatr()
        {
            //IPD_lab_test o = new IPD_lab_test(a);
            //o.ShowDialog();
        }
       
        public void saveProcedure()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Insert into IpdPatient_HospitalProc (IPD_ID,HospitalProc_Name,Charges,ISActive) Values(@IPD_ID,@HospitalProc_Name,@Charges,@ISActive)", con);
            cmd.Parameters.AddWithValue("@IPD_ID", b);
            cmd.Parameters.AddWithValue("@HospitalProc_Name", cmbHospitalMain.Text);
            cmd.Parameters.AddWithValue("@Charges", Public_HosProcCharges);
            cmd.Parameters.AddWithValue("@ISActive", "1");
            cmd.ExecuteNonQuery();
            VerifyAmount = Convert.ToDecimal(lbhospTotalAmount.Text) + Convert.ToDecimal(Public_HosProcCharges.ToString());

           lbhospTotalAmount.Text = VerifyAmount.ToString();
            AddHospital_procedure();
            AddSave = 1;
            button5.Enabled = true;

            button5.BackColor = Color.DarkGreen;

        }

        public void AddHospital_procedure()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * From IpdPatient_HospitalProc where IPD_ID=@b", con);
            cmd.Parameters.AddWithValue(@"b", b);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dtPublic = new DataTable();

            adt.Fill(dtPublic);
            
            if(dtPublic.Rows.Count>0)
            {
                dataGridView3.DataSource = dtPublic;
                dataGridView3.Columns["HosPatient_ID"].Visible = false;
                dataGridView3.Columns["IPD_ID"].Visible = false;
                dataGridView3.Columns["Charges"].Visible = false;
               dataGridView3.Columns["ISActive"].Visible = false;
                LoadSave = 1;
            }

        }
        public void BindDrugList()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * From Master_OPD_DrugsList order by Name", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                cmbIPDDrugList.DataSource = dt;
                cmbIPDDrugList.DisplayMember = "Name";
                cmbIPDDrugList.ValueMember = "ID";
            }

        }
        public void show_GrideviewDetails()
        {
            try
            {

                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"Select * From IPD_PatientDrugList where IPDID=@b", con);
                cmd.Parameters.AddWithValue(@"b", b);
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                adt.Fill(dt);
                dataGridView2.DataSource = dt;
                dataGridView2.Columns["ID"].Visible = false;
                dataGridView2.Columns["Date"].Visible = false;
                dataGridView2.Columns["IPDID"].Visible = false;
                dataGridView2.Columns["MorningDose"].HeaderText = "AfterBreakfast";
                dataGridView2.Columns["AfternoonDose"].HeaderText = "AfterLunch";
                dataGridView2.Columns["NightDose"].HeaderText = "AfterDinner";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }



        }

        private void newRoomS_TextChanged(object sender, EventArgs e)
        {
            Beddata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "")
            {
                MessageBox.Show("No Bed available...");
                return;
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"update   IPD_Registration  set  Room_Segment=@Room_Segment, Bed_No=@Bed_No

WHERE        IPDID = @Id", con);
                cmd.Parameters.AddWithValue("@Id", b);
                cmd.Parameters.AddWithValue("@Room_Segment", newRoomS.Text);
                cmd.Parameters.AddWithValue("@Bed_No", comboBox3.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                updateBed();
                updateOldBed();
                assignBed();
                MessageBox.Show(" Room Segment and Bed NUmber Updated..");
                Roomsegment();
                Beddata();
                Roomshowdata();
            }
        }

        public void updateBed()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"update Master_IPDBedNo set isvacant = 1 where roomsegmentid = @rs and bedno = @bno", con);
            cmd.Parameters.AddWithValue("@rs", newRoomS.SelectedIndex + 1);
            cmd.Parameters.AddWithValue("@bno", comboBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public int getID()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select max(ID) from ipd_assignedbeddetails where ipdid = @id", con);
            cmd.Parameters.AddWithValue("@id", b);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return id;
        }
        public void updateOldBed()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"update ipd_assignedbeddetails set To_Date = @date where id=@id", con);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.Date.ToString("dd-MM-yyyy"));
            cmd.Parameters.AddWithValue("@id", getID());
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void assignBed()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            int charge = 0;
            SqlCommand cmd = new SqlCommand(@"select charge from Master_IPDRoomSegment where name = @name", con);
            cmd.Parameters.AddWithValue("@name", newRoomS.Text);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                charge = Convert.ToInt32(r[0]);
            }
            r.Close();
            SqlCommand cmd2 = new SqlCommand(@"insert into ipd_assignedbeddetails(IPDID,Bed_Segment,Bed_No,From_Date,Charges,Nursing_Charge) values(@ipdid,@room_seg,@bed_no,@bedassign_date,@charge,@nursingChrge)", con);
            cmd2.Parameters.AddWithValue("@ipdid", b);
            cmd2.Parameters.AddWithValue("@room_seg", newRoomS.Text);
            cmd2.Parameters.AddWithValue("@bed_no", comboBox3.Text);
            cmd2.Parameters.AddWithValue("@bedassign_date", System.DateTime.Now.Date.ToString("dd-MM-yyyy"));
            cmd2.Parameters.AddWithValue("@charge", charge);
            if (newRoomS.Text == "ICU")
            {
                cmd2.Parameters.AddWithValue("@nursingChrge", 500);
            }
            if (newRoomS.Text == "Genral Ward")
            {
                cmd2.Parameters.AddWithValue("@nursingChrge", 300);
            }
            cmd2.ExecuteNonQuery();
            con.Close();
        }

        public void Save()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Insert into IPD_PatientDrugList (IPDID,Date,DrugName,ForDays,BeforeBreakfast,BeforeLunch,BeforeDinner,MorningDose,AfternoonDose,NightDose) Values(@IPDID,@Date,@DrugName,@ForDays,@BeforeBreakfast,@BeforeLunch,@BeforeDinner,@MorningDose,@AfternoonDose,@NightDose)", con);
            cmd.Parameters.AddWithValue("@IPDID", b);
            cmd.Parameters.AddWithValue("@Date", System.DateTime.Now);
            cmd.Parameters.AddWithValue("@DrugName", txtEnterDrug.Text);
            cmd.Parameters.AddWithValue("@ForDays", txtDays.Text);
            if (Chk1BeforeBreakfast.Checked == true)
            {
                cmd.Parameters.AddWithValue("@BeforeBreakfast", "1");


            }
            else
            {
                cmd.Parameters.AddWithValue("@BeforeBreakfast", "0");

            }
            if (chk1BeforeLunch.Checked == true)
            {
                cmd.Parameters.AddWithValue("@BeforeLunch", "1");

            }
            else
            {
                cmd.Parameters.AddWithValue("@BeforeLunch", "0");
            }
            if (chk1BeforeDinner.Checked == true)
            {
                cmd.Parameters.AddWithValue("@BeforeDinner", "1");

            }
            else
            {
                cmd.Parameters.AddWithValue("@BeforeDinner", "0");
            }
            if (chkboxMorningDose.Checked == true)
            {
                cmd.Parameters.AddWithValue("@MorningDose", "1");

            }
            else
            {
                cmd.Parameters.AddWithValue("@MorningDose", "0");
            }
            if (chkboxAfternoonDose.Checked == true)
            {
                cmd.Parameters.AddWithValue("@AfternoonDose", "1");

            }
            else
            {
                cmd.Parameters.AddWithValue("@AfternoonDose", "0");
            }
            if (chkboxNightDose.Checked == true)
            {
                cmd.Parameters.AddWithValue("@NightDose", "1");

            }
            else
            {
                cmd.Parameters.AddWithValue("@NightDose", "0");
            }
            // cmd.Parameters.AddWithValue("@BeforeBreakfast", Chk1BeforeBreakfast.Checked);
            //cmd.Parameters.AddWithValue("@BeforeLunch", chk1BeforeLunch.Checked);
            //cmd.Parameters.AddWithValue("@BeforeDinner", chk1BeforeDinner.Checked);
            //cmd.Parameters.AddWithValue("@MorningDose", chkboxMorningDose.Checked);
            //cmd.Parameters.AddWithValue("@AfternoonDose", chkboxAfternoonDose.Checked);
            //cmd.Parameters.AddWithValue("@NightDose", chkboxNightDose.Checked);

            cmd.ExecuteNonQuery();
            #region  Clear All
            txtEnterDrug.Clear();
            txtDays.Clear();


            txtDays.Clear();

            txtGenericSelection.Clear();

            Chk1BeforeBreakfast.Checked = false;
            chk1BeforeLunch.Checked = false;
            chk1BeforeDinner.Checked = false;
            chkboxMorningDose.Checked = false;
            chkboxAfternoonDose.Checked = false;
            chkboxNightDose.Checked = false;


            #endregion
            show_GrideviewDetails();
            AddSave = 1;


        }
        private void button4_Click(object sender, EventArgs e)
        {
            saveProcedure();
            TotalASave = 0;


        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            string columnName = this.dataGridView3.Columns[e.ColumnIndex].Name;


            if (columnName.Equals("Delete") == true)
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {


                    DeleteId = Convert.ToInt32(dataGridView3.CurrentRow.Cells["HosPatient_ID"].Value);
                    Public_Charges = Convert.ToInt32(dataGridView3.CurrentRow.Cells["Charges"].Value);
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();

                    //SqlCommand cmd = new SqlCommand(@"Update IpdPatient_HospitalProc set ISActive=@ISActive where HosPatient_ID=@DeleteId", con);
                    SqlCommand cmd = new SqlCommand(@"Delete from IpdPatient_HospitalProc where HosPatient_ID=@DeleteId", con);
                    cmd.Parameters.AddWithValue("@DeleteId", DeleteId);
                    //cmd.Parameters.AddWithValue("@ISActive", "0");
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted Successfully..");

                    if (TotalASave == 1)
                    {
                        TotalASave = 0;
                        FetchingAmount_Procedure();
                        lbhospTotalAmount.Text = (TotaIPDpro1 - Public_Charges).ToString();
                        IPDHocprocUpdate();

                    }
                    else
                    {
                        lbhospTotalAmount.Text = (Convert.ToDecimal(lbhospTotalAmount.Text) - Public_Charges).ToString("0.00");
                        IPDHocprocUpdate();
                    }
                    
                }
               
                AddHospital_procedure();
                
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
           if(LoadSave==1)
            {
                MessageBox.Show("Record Added Successfully");
                
                dataGridView3.DataSource=null;
                   

            }
            
        }

        private void txtGenericSelection_TextChanged(object sender, EventArgs e)
        {
            txtEnterDrug.Text = txtGenericSelection.Text;
        }

        private void cmbIPDDrugList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEnterDrug.Text = cmbIPDDrugList.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEnterDrug.Text != "" && txtDays.Text != "")
                {
                    if (Chk1BeforeBreakfast.CheckState == CheckState.Unchecked && chk1BeforeLunch.CheckState == CheckState.Unchecked && chk1BeforeDinner.CheckState == CheckState.Unchecked
                     && chkboxMorningDose.CheckState == CheckState.Unchecked && chkboxAfternoonDose.CheckState == CheckState.Unchecked && chkboxNightDose.CheckState == CheckState.Unchecked)
                    {
                        MessageBox.Show("Check Dosage Fields.");
                    }

                    else
                    {

                        Save();


                    }
                }
                else
                    MessageBox.Show("Check All Fields.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddSave = 1;
            
                MessageBox.Show("Record Added SuccessFully");
            
        }

        private void txtGenericSelection_MouseClick(object sender, MouseEventArgs e)
        {
            txtGenericSelection.Clear();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            //SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            //con.Open();
            //SqlCommand cmd = new SqlCommand(@"Insert into Lab_testOPDIPD (OPDID,IPDID,Purpose)Values(,@OPDID,@IPDID@Purpose)", con);
           
            //cmd.Parameters.AddWithValue("@OPDID", 0);
            //cmd.Parameters.AddWithValue("@IPDID", a);
            //cmd.Parameters.AddWithValue("@Purpose", "IPD");

            //cmd.ExecuteNonQuery();

            datatr();

            //MessageBox.Show("Record Send to Rediology");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            //con.Open();
            //SqlCommand cmd = new SqlCommand(@"Insert into RadiologyPatientList (IPDID,OPDID,Purpose)Values(@IPDID,@OPDID,@Purpose)", con);
            //cmd.Parameters.AddWithValue("@IPDID", a);
            //cmd.Parameters.AddWithValue("@OPDID", 0);
            //cmd.Parameters.AddWithValue("@Purpose", "IPD");

            //cmd.ExecuteNonQuery();

            //MessageBox.Show("Record Send to Rediology");

            //IPD_ECG_and_Radiology_main o = new IPD_ECG_and_Radiology_main(a);
            //o.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IPD_Surgical_Procedure o = new IPD_Surgical_Procedure(a,b);
            o.ShowDialog();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void LabTest_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                Save_lab();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex < 0 || e.ColumnIndex < 0)
        //        return;
        //    string columnName = this.RadiologyGrid.Columns[e.ColumnIndex].Name;
        //    if (columnName.Equals("Delete") == true)
        //    {
        //        var senderGrid = (DataGridView)sender;

        //        if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
        //        {
        //            DeleteID = Convert.ToInt32(RadiologyGrid.CurrentRow.Cells["ID"].Value);

        //            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
        //            con.Open();
        //            SqlCommand cmd = new SqlCommand(@"delete from AssignIPDLabTest where ID=@DeleteID", con);
        //            cmd.Parameters.AddWithValue("@DeleteID", DeleteID);
        //            cmd.ExecuteNonQuery();
        //            MessageBox.Show("Record Deleted Successfully..");
        //            IPD_Daily_Procedure_main_Load_1(sender, e);
        //        }
        //        //this.Load(object sender, EventArgs e);
        //    }
        //}

        private void button16_Click(object sender, EventArgs e)
        {
                try
                {
                    if (AddLab == 1)
                    {
                        TotalASave = 1;
                        MessageBox.Show("Record Added Successfully");

                        SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                        con.Open();
                        SqlCommand cmd = new SqlCommand(@"Select * From Billing_IPDTotal_LabAmount where IPDID=@b", con);
                        cmd.Parameters.AddWithValue(@"b", b);
                        SqlDataAdapter adt = new SqlDataAdapter(cmd);
                        DataTable dtPublic = new DataTable();
                        adt.Fill(dtPublic);
                        if (dtPublic.Rows.Count > 0)
                        {
                            IPDLabAmountUpdate();
                            button16.Enabled = false;
                            button16.BackColor = Color.Silver;

                        }
                        else
                        {
                            IPDLabAmountSave();
                            button16.Enabled = false;
                            button16.BackColor = Color.Silver;
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
        }

        private void cmblabtest_TextChanged(object sender, EventArgs e)
        {
            test();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                RadiologySave();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RadiologyGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            string columnName = this.RadiologyGrid.Columns[e.ColumnIndex].Name;
            if (columnName.Equals("Delete1") == true)
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    DeleteID = Convert.ToInt32(RadiologyGrid.CurrentRow.Cells["ID"].Value);
                    Public_Charges = Convert.ToInt32(RadiologyGrid.CurrentRow.Cells["Charges"].Value);
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"delete from Assign_IPDRadiology_test where ID=@DeleteID", con);
                    cmd.Parameters.AddWithValue("@DeleteID", DeleteID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted Successfully..");
                    if (TotalASave == 1)
                    {
                        TotalASave = 0;
                        FetchingAmount_Radiologytest();
                        lbRadiologyAmount.Text = (TotaIPDRadiology - Public_Charges).ToString();
                        IPDRadiologyAmountUpdate();

                    }
                    else
                    {
                        lbRadiologyAmount.Text = (Convert.ToDecimal(lbRadiologyAmount.Text) - Public_Charges).ToString("0.00");
                        IPDRadiologyAmountUpdate();
                    }
                    
                    Radiologyshow_ADD();
                }
                //this.Load(object sender, EventArgs e);
            }
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            string columnName = this.dataGridView5.Columns[e.ColumnIndex].Name;
            if (columnName.Equals("dataGridViewImageColumn1") == true)
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    DeleteID = Convert.ToInt32(dataGridView5.CurrentRow.Cells["ID"].Value);
                    Public_Charges = Convert.ToInt32(dataGridView5.CurrentRow.Cells["Charges"].Value);
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"delete from AssignIPDLabTest where ID=@DeleteID", con);
                    cmd.Parameters.AddWithValue("@DeleteID", DeleteID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted Successfully..");
                    if (TotalASave == 1)
                    {
                        TotalASave = 0;
                        FetchingAmount_Labtest();
                        lbLabTest.Text = (TotaIPDpro - Public_Charges).ToString();
                        IPDLabAmountUpdate();

                    }
                    else
                    {
                        lbLabTest.Text = (Convert.ToDecimal(lbLabTest.Text) - Public_Charges).ToString("0.00");
                        IPDLabAmountUpdate();
                    }
                    show_ADD_lab();
                    //IPD_Daily_Procedure_main_Load_1(sender, e);
                }
                //this.Load(object sender, EventArgs e);
            }
        }

        private void cmbHospitalMain_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (AddSave == 1)
                {
                    TotalASave = 1;
                    MessageBox.Show("Record Added Successfully");

                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"Select * From Billing_IPDHosProc where IPDID=@b", con);
                    cmd.Parameters.AddWithValue(@"b", b);
                    SqlDataAdapter adt = new SqlDataAdapter(cmd);
                    DataTable dtPublic = new DataTable();
                    adt.Fill(dtPublic);
                    if (dtPublic.Rows.Count > 0)
                    {
                        IPDHocprocUpdate();
                        button5.Enabled = false;
                        button5.BackColor = Color.Silver;

                    }
                    else
                    {
                        IPDHocprocSave();
                        button5.Enabled = false;
                        button5.BackColor = Color.Silver;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                if (Radiology == 1)
                {
                    TotalASave = 1;
                    MessageBox.Show("Record Added Successfully");

                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"Select * From Billing_IPDTotal_RadiologyA where IPDID=@b", con);
                    cmd.Parameters.AddWithValue(@"b", b);
                    SqlDataAdapter adt = new SqlDataAdapter(cmd);
                    DataTable dtPublic = new DataTable();
                    adt.Fill(dtPublic);
                    if (dtPublic.Rows.Count > 0)
                    {
                        IPDRadiologyAmountUpdate();
                        button15.Enabled = false;
                        button15.BackColor = Color.Silver;

                    }
                    else
                    {
                        IPDRadiologyAmountSave();
                        button15.Enabled = false;
                        button15.BackColor = Color.Silver;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void newRoomS_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.DataSource = null;
            comboBox3.Items.Clear();
            Beddata();
        }
    }
}
