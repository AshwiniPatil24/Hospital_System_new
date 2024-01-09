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
    public partial class OPD_Consultaion_mainform : Form
    {
        public int a;
        public int OPDFillID;
        private DataTable dtPublic;
        public int Public_Opd_procedureID=0;
        public string Public_Opd_ProcedureCharges="";
        public int Addsave = 0;
        public int updateSave = 0;
        public decimal TotalOPDPro;
        public int Public_ID;
        public int RadiologyTestId;
        public string RadiologyCharges;
        int Radiology = 0;
        public int RadiologyPublic_ID;
        public decimal Public_RadiologyCharges = 0;
        public decimal TotalRadiology = 0;
        public int Radiologysave = 0;
        public int Public_LabTestID;
        public int Public_LabTestTypeID;
        public int Public_LabTestName;
        public string Public_HospCharge;
        public int LabPublic_ID;
        public int AddLab = 0;
        public decimal LABVerifyAmount;
        public decimal Public_LABCharges;
        public int Labsave = 0;
        public decimal TotalLabAmount = 0;
        AutoCompleteStringCollection drugNamesCollection = new AutoCompleteStringCollection();
        public int AddSave;
        public int DeleteID;
        public decimal VerifyAmount=0; 
        public decimal Public_Charges = 0;
        public decimal RVerifyAmount = 0;
       


        public OPD_Consultaion_mainform()
        {
            InitializeComponent();
        }
        public OPD_Consultaion_mainform(int OPDId)
        {
            InitializeComponent();
            a = OPDId;
            txtID.Text = OPDId.ToString();
            OPDFillID = Convert.ToInt32(txtID.Text);
            show_PatientDetails();


        }
        public void show_ADD()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * From Patient_OPDProcedures where Patient_OPDID=@OPDId", con);
            cmd.Parameters.AddWithValue(@"OPDId", txtID.Text);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dtPublic = new DataTable();
            adt.Fill(dtPublic);
            dataGridView3.DataSource = dtPublic;
            dataGridView3.Columns["ID"].Visible = false;
            dataGridView3.Columns["Patient_OPDID"].Visible = false;
            dataGridView3.Columns["OPDProcedure_ID"].Visible = false;
            //dataGridView3.Columns["Charges"].Visible = false;
            dataGridView3.Columns["Name"].HeaderText = "Procedure_Name";
            dataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView3.Font, FontStyle.Bold);           

        }
        public void Save()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Insert into Patient_OPDProcedures (Patient_OPDID,OPDProcedure_ID,Name,Charges) Values(@Patient_OPDID,@OPDProcedure_ID,@Name,@Charges)", con);
            cmd.Parameters.AddWithValue("@Patient_OPDID", txtID.Text);
            cmd.Parameters.AddWithValue("@OPDProcedure_ID", Public_Opd_procedureID);
            cmd.Parameters.AddWithValue("@Name", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Charges", Public_Opd_ProcedureCharges);
            cmd.ExecuteNonQuery();
            VerifyAmount = Convert.ToDecimal(label16.Text) + Convert.ToDecimal(Public_Opd_ProcedureCharges.ToString());
                        
            label16.Text = VerifyAmount.ToString();
            
            show_ADD();
            Addsave = 1;
            button5.Enabled = true;
            
            button5.BackColor = Color.DarkGreen;

        }
        public void AmountOPD_ProcedureSave()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Insert into Billing_OPDProcedure (OPDID,Illeness,Treatment,OPDProcedureAmount) Values(@OPDID,@Illeness,@Treatment,@OPDProcedureAmount)", con);
            cmd.Parameters.AddWithValue("@OPDID", txtID.Text);
            cmd.Parameters.AddWithValue("@Illeness", txtIllness.Text);
            cmd.Parameters.AddWithValue("@Treatment", txtTreatment.Text);
            cmd.Parameters.AddWithValue("@OPDProcedureAmount", label16.Text);
            cmd.ExecuteNonQuery();       
        }
        public void AmountOPD_ProcedureUpdate()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Update Billing_OPDProcedure set OPDProcedureAmount=@OPDProcedureAmount where OPDID=@OPDID", con);
            cmd.Parameters.AddWithValue("@OPDID", txtID.Text);         
            cmd.Parameters.AddWithValue("@OPDProcedureAmount", label16.Text);
            cmd.ExecuteNonQuery();
        }
        public void FetchingAmount_Procedure()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * From Billing_OPDProcedure where OPDID=@OPDId", con);
            cmd.Parameters.AddWithValue(@"OPDId", txtID.Text);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dtPublic = new DataTable();
            adt.Fill(dtPublic);
            if (dtPublic.Rows.Count > 0)
            {
                TotalOPDPro = Convert.ToDecimal(dtPublic.Rows[0]["OPDProcedureAmount"]);
            }
        }
        public void UpdateAmountOPD_Procedure()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"UPDATE Billing_OPDProcedure SET OPDProcedureAmount=@OPDProcedureAmount where (OPDID=@OPDId)", con);
            cmd.Parameters.AddWithValue("@OPDId", txtID.Text);
            cmd.Parameters.AddWithValue("@OPDProcedureAmount", label16.Text);
            cmd.ExecuteNonQuery();
        }
        public void show_PatientDetails()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT OPD_Patient_Registration.PatientOPDIdWithSr,Patient_Registration.Name, Patient_Registration.Mobile_Number, Patient_Registration.Doctors_Name, Patient_Registration.Referred_By
                      FROM Patient_Registration INNER JOIN OPD_Patient_Registration ON Patient_Registration.PID = OPD_Patient_Registration.PatientId where IsCheck = 0 and PatientOPDId=@OPDId", con);
            cmd.Parameters.AddWithValue(@"OPDId", txtID.Text);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable o = new DataTable();
            adt.Fill(o);
            if (o.Rows.Count > 0)
            {
                dataGridView1.DataSource = o;
                dataGridView1.Columns["PatientOPDIdWithSr"].HeaderText = "OPD_ID";
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
            }
        }
        public void OPD_Procedure_show()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * From Master_OPD_Procedures", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "OPD_ProcedureID";
                if(comboBox1.Text != "")
                {
                    Public_Opd_procedureID = Convert.ToInt32(dt.Rows[0]["OPD_ProcedureID"]);
                    Public_Opd_ProcedureCharges = Convert.ToString(dt.Rows[0]["Charges"]);
                }
            }
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
                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "Radiology_ID";
                RadiologyTestId = Convert.ToInt32(dt.Rows[0]["Radiology_ID"]);
                RadiologyCharges = Convert.ToString(dt.Rows[0]["Charges"]);
            }
        }
        public void RadiologySave()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Insert into AssignRadiologyTest (OPDID,RadiologyID,RadiologyName,Charges,TestDate) Values(@OPDID,@RadiologyID,@RadiologyName,@Charges,@TestDate)", con);
            cmd.Parameters.AddWithValue("@OPDID", a);
            cmd.Parameters.AddWithValue("@RadiologyID", RadiologyTestId);
            cmd.Parameters.AddWithValue("@RadiologyName", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Charges", RadiologyCharges);
            cmd.Parameters.AddWithValue("@TestDate", dtptestDate.Text);
            cmd.ExecuteNonQuery();
            RVerifyAmount = Convert.ToDecimal(lbRadiologyAmount.Text) + Convert.ToDecimal(RadiologyCharges.ToString());
            lbRadiologyAmount.Text = RVerifyAmount.ToString();
            Radiologyshow_ADD();
            Radiology = 1;
            button6.Enabled= true;
            button6.BackColor = Color.DarkGreen;
        }
        public void Radiologyshow_ADD()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * From AssignRadiologyTest where OPDID=@a", con);
            cmd.Parameters.AddWithValue(@"a", a);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dtPublic = new DataTable();
            adt.Fill(dtPublic);
            dataGridView4.DataSource = dtPublic;
            dataGridView4.Columns["ID"].Visible = false;
            dataGridView4.Columns["OPDID"].Visible = false;
            dataGridView4.Columns["RadiologyID"].Visible = false;
           // dataGridView4.Columns["Charges"].Visible = false;
            dataGridView4.Columns["TestDate"].Visible = false;
            dataGridView4.Columns["RadiologyName"].HeaderText = "Radiology Test";
            dataGridView4.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView4.Font, FontStyle.Bold);
        }
        public void AmountOPD_RadiologySave()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Insert into Billing_OPDRadiologyTAmount (OPDID,OPDRadiologyAmount) Values(@OPDID,@OPDRadiologyAmount)", con);
            cmd.Parameters.AddWithValue("@OPDID", txtID.Text);
            cmd.Parameters.AddWithValue("@OPDRadiologyAmount", lbRadiologyAmount.Text);
            cmd.ExecuteNonQuery();
        }
        public void UpdateAmountRadiologyTest()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"UPDATE Billing_OPDRadiologyTAmount SET OPDRadiologyAmount=@OPDRadiologyAmount where (OPDID=@OPDId)", con);

            cmd.Parameters.AddWithValue("@OPDId", txtID.Text);
            cmd.Parameters.AddWithValue("@OPDRadiologyAmount", lbRadiologyAmount.Text);
            cmd.ExecuteNonQuery();          
        }
        public void FetchingAmount_RadiologyTest()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * From Billing_OPDRadiologyTAmount where OPDID=@OPDId", con);
            cmd.Parameters.AddWithValue(@"OPDId", txtID.Text);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dtPublic = new DataTable();
            adt.Fill(dtPublic);
            if (dtPublic.Rows.Count > 0)
            {
                TotalRadiology = Convert.ToDecimal(dtPublic.Rows[0]["OPDRadiologyAmount"]);
            }
        }
        public void  UpdateChargesRadiology()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"update Billing_OPDRadiologyTAmount set OPDRadiologyAmount=@OPDRadiologyAmount where OPDID=@OPDId", con);
            cmd.Parameters.AddWithValue(@"OPDId", txtID.Text);
            cmd.Parameters.AddWithValue(@"OPDRadiologyAmount", lbRadiologyAmount.Text);
            cmd.ExecuteNonQuery();        
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
                LTest.DataSource = dt;
                LTest.DisplayMember = "LabTestName";
                Public_LabTestID = Convert.ToInt32(dt.Rows[0]["LabTestID"]);
                Public_LabTestTypeID = Convert.ToInt32(dt.Rows[0]["LabTestTypeID"]);
                Public_HospCharge = Convert.ToString(dt.Rows[0]["HospCharge"]);               
            }
        }
        public void LabSave()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"Insert into AssignOPDLabTest (OPDID,LabTestTypeID,labTestID,LabTest,Charges,TestDate) Values(@OPDID,@LabTestTypeID,@labTestID,@LabTest,@Charges,@TestDate)", con);
                cmd.Parameters.AddWithValue("@OPDID", a);
                cmd.Parameters.AddWithValue("@LabTestTypeID", Public_LabTestTypeID);
                cmd.Parameters.AddWithValue("@labTestID", Public_LabTestID);
                cmd.Parameters.AddWithValue("@LabTest", LTest.Text);
                cmd.Parameters.AddWithValue("@Charges", Public_HospCharge);
                cmd.Parameters.AddWithValue("@TestDate", dtpLabtestDate.Text);               
                cmd.ExecuteNonQuery();
                AddLab = 1;
                LABVerifyAmount = Convert.ToDecimal(lbTotalLab.Text) + Convert.ToDecimal(Public_HospCharge.ToString());
                lbTotalLab.Text = LABVerifyAmount.ToString();
                Labshow_ADD();
               // button8.Visible = true;
                button8.Enabled = true;
                button8.BackColor = Color.DarkGreen;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void Labshow_ADD()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * From AssignOPDLabTest where OPDID=@a", con);
            cmd.Parameters.AddWithValue(@"a", a);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dtPublic = new DataTable();
            adt.Fill(dtPublic);
            if (dtPublic.Rows.Count > 0)
            {
                dataGridView5.DataSource = dtPublic;
                dataGridView5.Columns["ID"].Visible = false;
                dataGridView5.Columns["OPDID"].Visible = false;
                dataGridView5.Columns["LabTestTypeID"].Visible = false;
                dataGridView5.Columns["labTestID"].Visible = false;
                dataGridView5.Columns["Charges"].Visible = false;
                dataGridView5.Columns["TestDate"].Visible = false;
                dataGridView5.Columns["DleStatus"].Visible = false;
                dataGridView5.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView5.Font, FontStyle.Bold);
            }           
        }
        public void AmountOPD_LabSave()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Insert into Billing_OPDTotalALabTest (OPDID,TotalLabAmount) Values(@OPDID,@TotalLabAmount)", con);
            cmd.Parameters.AddWithValue("@OPDID", txtID.Text);
            cmd.Parameters.AddWithValue("@TotalLabAmount", lbTotalLab.Text);
            cmd.ExecuteNonQuery();
        }
        public void UpdateChargesLab()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"update Billing_OPDTotalALabTest set TotalLabAmount=@TotalLabAmount where OPDID=@OPDId", con);
            cmd.Parameters.AddWithValue(@"OPDId", txtID.Text);
            cmd.Parameters.AddWithValue(@"TotalLabAmount", lbTotalLab.Text);
            cmd.ExecuteNonQuery();
        }
        public void FetchingAmount_LabTest()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * From Billing_OPDTotalALabTest where OPDID=@OPDId", con);
            cmd.Parameters.AddWithValue(@"OPDId", txtID.Text);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dtPublic = new DataTable();
            adt.Fill(dtPublic);
            if (dtPublic.Rows.Count > 0)
            {
                TotalLabAmount = Convert.ToDecimal(dtPublic.Rows[0]["TotalLabAmount"]);
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
                cmbOPDDrugList.DataSource = dt;
                cmbOPDDrugList.DisplayMember = "Name";
                cmbOPDDrugList.ValueMember = "ID";
            }
        }
        public void show_GrideviewDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"Select * From OPD_PatientDrugList where OPDID=@a", con);
                cmd.Parameters.AddWithValue(@"a", a);
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adt.Fill(dt);
                dataGridView6.DataSource = dt;
                dataGridView6.Columns["ID"].Visible = false;
                dataGridView6.Columns["Date"].Visible = false;
                dataGridView6.Columns["OPDID"].Visible = false;
                dataGridView6.Columns["MorningDose"].HeaderText = "AfterBreakfast";
                dataGridView6.Columns["AfternoonDose"].HeaderText = "AfterLunch";
                dataGridView6.Columns["NightDose"].HeaderText = "AfterDinner";
                dataGridView6.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView6.Font, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void OPD_Consultaion_mainform_Load(object sender, EventArgs e)
        {
            FetchingAmount_Procedure();
            FetchingAmount_RadiologyTest();
            FetchingAmount_LabTest();
            

            OPD_Procedure_show();
            show_ADD();
            OPD_RadiologyTest_show();
            Radiologyshow_ADD();
            // button6.Visible = false;            
            labtype();
            test();
            Labshow_ADD();
           // button8.Visible = false;
            BindDrugList();
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
            //button11.Visible = false;
            show_GrideviewDetails();
            label17.Text = TotalOPDPro.ToString();
            lbRadiologyAmount.Text = TotalRadiology.ToString();
            lbTotalLab.Text = TotalLabAmount.ToString();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            //Assgin_lab_test alt = new Assgin_lab_test();
            //alt.Show();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
        private void button6_Click(object sender, EventArgs e)
        {
            Assign_OPD_Drugs aod = new Assign_OPD_Drugs(OPDFillID);
            aod.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OPD_Print_Certificate opc = new OPD_Print_Certificate();
            opc.Show();
        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button8_Click(object sender, EventArgs e)
        {            
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"Insert into RadiologyPatientList (IPDID,OPDID,Purpose) Values(@IPDID,@OPDID,@Purpose)", con);
                cmd.Parameters.AddWithValue("@IPDID", 0);
                cmd.Parameters.AddWithValue("@OPDID", txtID.Text);
                cmd.Parameters.AddWithValue("@Purpose", "OPD");               
                cmd.ExecuteNonQuery();
                //show_ADD();
                MessageBox.Show("Record Send to Rediology");        
            //OPD_ECG_and_Radiology_list o = new OPD_ECG_and_Radiology_list();
           // o.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "")
                {

                    MessageBox.Show("and Select OPD Procedure Name");
                }

                else
                {
                    Save();
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Updatedata();           
        }
        public void Updatedata()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"UPDATE OPD_Patient_Registration SET Summary=@Summary,Treatement=@Treatement,ChargesId=@ChargesId,XRay=@XRay,OPDSurgicalProcedureID=@OPDSurgicalProcedureID,VisitDate=@VisitDate,IsCheck=@IsCheck,FollowUpDate=@FollowUpDate where (PatientOPDId=@OPDId)", con);
            cmd.Parameters.AddWithValue("@OPDId", txtID.Text);
            cmd.Parameters.AddWithValue("@Summary", txtIllness.Text);
            cmd.Parameters.AddWithValue("@Treatement", txtTreatment.Text);
            cmd.Parameters.AddWithValue("@ChargesId", "0");
            cmd.Parameters.AddWithValue("@XRay", "0");
            cmd.Parameters.AddWithValue("@OPDSurgicalProcedureID", "1");
            cmd.Parameters.AddWithValue("@VisitDate", System.DateTime.Now);
            cmd.Parameters.AddWithValue("@IsCheck", "0");
            cmd.Parameters.AddWithValue("@FollowUpDate", System.DateTime.Now);
            cmd.ExecuteNonQuery();
            //MessageBox.Show("Record Added Successfully");
        }
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                Save();
                updateSave = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Updatedata();
            try
            {
                if (Addsave == 1)
                {
                    updateSave = 1;
                    MessageBox.Show("Record Added Successfully");

                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"Select * From Billing_OPDProcedure where OPDID=@OPDId", con);
                    cmd.Parameters.AddWithValue(@"OPDId", txtID.Text);
                    SqlDataAdapter adt = new SqlDataAdapter(cmd);
                    DataTable dtPublic = new DataTable();
                    adt.Fill(dtPublic);
                    if (dtPublic.Rows.Count > 0)
                    {
                        AmountOPD_ProcedureUpdate();
                        button5.Enabled = false;
                        button5.BackColor = Color.Silver;
                    }
                    else
                    {
                        AmountOPD_ProcedureSave();
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
        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            string columnName = this.dataGridView3.Columns[e.ColumnIndex].Name;
            if (columnName.Equals("Delete") == true)
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    Public_ID = Convert.ToInt32(dataGridView3.CurrentRow.Cells["ID"].Value);
                    Public_Charges = Convert.ToInt32(dataGridView3.CurrentRow.Cells["Charges"].Value);
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"Delete from Patient_OPDProcedures where ID=@Public_ID", con);
                    cmd.Parameters.AddWithValue("@Public_ID", Public_ID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted Successfully..");
                    if (updateSave == 1)
                    {
                        updateSave = 0;
                        FetchingAmount_Procedure();
                        label16.Text = (TotalOPDPro - Public_Charges).ToString();                       
                    }
                    else
                    {
                        label16.Text = (Convert.ToDecimal(label16.Text) - Public_Charges).ToString("0.00");
                    }                   
                    UpdateAmountOPD_Procedure();
                    show_ADD();
                    //OPD_Consultaion_mainform_Load(sender, e);             
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                RadiologySave();
                Radiologysave = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            string columnName = this.dataGridView4.Columns[e.ColumnIndex].Name;
            if (columnName.Equals("btnDelete") == true)
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    RadiologyPublic_ID = Convert.ToInt32(dataGridView4.CurrentRow.Cells["ID"].Value);
                    Public_RadiologyCharges = Convert.ToInt32(dataGridView4.CurrentRow.Cells["Charges"].Value);
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"Delete from AssignRadiologyTest where ID=@RadiologyPublic_ID", con);
                    cmd.Parameters.AddWithValue("@RadiologyPublic_ID", RadiologyPublic_ID);
                    cmd.ExecuteNonQuery();
                     MessageBox.Show("Record Deleted Successfully..");                   
                    if (Radiologysave == 1)
                    {
                        Radiologysave = 0;
                        FetchingAmount_RadiologyTest();
                        lbRadiologyAmount.Text = (TotalLabAmount - Public_RadiologyCharges).ToString();                        
                    }
                    else
                    {
                        lbRadiologyAmount.Text = (Convert.ToDecimal(lbRadiologyAmount.Text) - Public_RadiologyCharges).ToString("0.00");
                    }
                    UpdateAmountRadiologyTest();
                    Radiologyshow_ADD();
                    //OPD_Consultaion_mainform_Load(sender, e);
                }
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Radiology == 1)
                {
                    Radiologysave = 1;
                    MessageBox.Show("Record Added Successfully");
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"Select * From Billing_OPDRadiologyTAmount where OPDID=@OPDId", con);
                    cmd.Parameters.AddWithValue(@"OPDId", txtID.Text);
                    SqlDataAdapter adt = new SqlDataAdapter(cmd);
                    DataTable dtPublic = new DataTable();
                    adt.Fill(dtPublic);
                    if (dtPublic.Rows.Count > 0)
                    {
                        UpdateChargesRadiology();
                        button6.Enabled = false;
                        button6.BackColor = Color.Silver;
                    }
                    else
                    {
                        AmountOPD_RadiologySave();
                        button6.Enabled = false;
                        button6.BackColor = Color.Silver;
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

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                LabSave();
                Labsave = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void button8_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (AddLab == 1)
                {
                    Labsave = 1;
                    MessageBox.Show("Record Added Successfully");
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"Select * From Billing_OPDTotalALabTest where OPDID=@OPDId", con);
                    cmd.Parameters.AddWithValue(@"OPDId", txtID.Text);
                    SqlDataAdapter adt = new SqlDataAdapter(cmd);
                    DataTable dtPublic = new DataTable();
                    adt.Fill(dtPublic);
                    if (dtPublic.Rows.Count > 0)
                    {
                        UpdateChargesLab();
                        button8.Enabled = false;
                        button8.BackColor = Color.Silver;
                    }
                    else
                    {
                        AmountOPD_LabSave();
                        button8.Enabled = false;
                        button8.BackColor = Color.Silver;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            string columnName = this.dataGridView5.Columns[e.ColumnIndex].Name;
            if (columnName.Equals("BtnlDelete") == true)
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    LabPublic_ID = Convert.ToInt32(dataGridView5.CurrentRow.Cells["ID"].Value);
                    Public_LABCharges = Convert.ToInt32(dataGridView5.CurrentRow.Cells["Charges"].Value);
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"Delete from AssignOPDLabTest where ID=@LabPublic_ID", con);
                    cmd.Parameters.AddWithValue("@LabPublic_ID", LabPublic_ID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted Successfully..");
                    if (Labsave == 1)
                    {
                        Labsave = 0;
                        FetchingAmount_LabTest();
                        lbTotalLab.Text = (TotalLabAmount - Public_LABCharges).ToString();
                    }
                    else
                    {
                        lbTotalLab.Text = (Convert.ToDecimal(lbTotalLab.Text) - Public_LABCharges).ToString("0.00");
                    }
                    UpdateChargesLab();
                    Labshow_ADD();
                   // OPD_Consultaion_mainform_Load(sender, e);

                }

            }

        }
        public void OPDDrugSave()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Insert into OPD_PatientDrugList (OPDID,Date,DrugName,ForDays,BeforeBreakfast,BeforeLunch,BeforeDinner,MorningDose,AfternoonDose,NightDose,Remark) Values(@OPDID,@Date,@DrugName,@ForDays,@BeforeBreakfast,@BeforeLunch,@BeforeDinner,@MorningDose,@AfternoonDose,@NightDose,@Remark)", con);
            cmd.Parameters.AddWithValue("@OPDID", a);
            cmd.Parameters.AddWithValue("@Date", System.DateTime.Now);
            cmd.Parameters.AddWithValue("@DrugName", txtEnterDrug.Text);
            cmd.Parameters.AddWithValue("@ForDays", txtDays.Text);
            cmd.Parameters.AddWithValue("@Remark", txtRemark.Text);
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

            button11.Enabled = true;
            button11.BackColor = Color.DarkGreen;

            #endregion
            show_GrideviewDetails();
            AddSave = 1;           
        }
        private void txtGenericSelection_MouseClick(object sender, MouseEventArgs e)
        {
            txtGenericSelection.Clear();
        }

        private void txtGenericSelection_TextChanged(object sender, EventArgs e)
        {
            txtEnterDrug.Text = txtGenericSelection.Text;
        }

        private void cmbOPDDrugList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEnterDrug.Text = cmbOPDDrugList.Text;
        }

        private void button12_Click(object sender, EventArgs e)
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

                        OPDDrugSave();


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

        private void button11_Click(object sender, EventArgs e)
        {
            if (AddSave == 1)
            {
                MessageBox.Show("Record Added SuccessFully");
                button11.BackColor = Color.Silver;
            }
            else
            {
                MessageBox.Show("First Add Drugs");
                button11.BackColor = Color.Silver;
            }

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            string columnName = this.dataGridView6.Columns[e.ColumnIndex].Name;


            if (columnName.Equals("btnDrugDelete") == true)
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    DeleteID = Convert.ToInt32(dataGridView6.CurrentRow.Cells["ID"].Value);

                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"delete from OPD_PatientDrugList where ID=@DeleteID", con);
                    cmd.Parameters.AddWithValue("@DeleteID", DeleteID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted Successfully..");
                    OPD_Consultaion_mainform_Load(sender, e);
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
        }
        private void panel6_Paint_1(object sender, PaintEventArgs e)
        {
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }
    }
}
