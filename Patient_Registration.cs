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
using System.Text.RegularExpressions;
using System.Collections;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;

namespace Ruby_Hospital
{
    public partial class Patient_Registration : Form
    {
        public int P_ID;
        String PID = "RSHJ";
        string OIDA = "OPD/RSHJ";
        public int PatientBindIPD;
       public  int countpatient;
        public int opdID;
        public int Patient_ID;
        //SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SpecalistHospitalSystem.Properties.Settings.Db_BNHConnectionString"].ConnectionString);
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
       // String selectedby;
        public Patient_Registration()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void txtmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmail_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(txtmail.Text, pattern))
            {
                errorProvider1.Clear();
                txtmail.BackColor = Color.White;
            }
            else
            {

                errorProvider1.SetError(this.txtmail, "PLEASE PROVIDE VALID EMAIL ADDRESS...");
                txtmail.BackColor = Color.LightPink;
                return;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void txtmobilenumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtaadhaar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtweight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void txtalternateno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtremark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtpatient_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtreferred_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Patient_Registration_Load(object sender, EventArgs e)
        {
            btnGOTOIPD.Visible = false;
            button4.Visible = false;
            cbmmaritalstatus.SelectedIndex = 0;
            txtpurpose.SelectedIndex = 0;
            txtnationality.SelectedIndex = 0;
            txtpatientsearch.SelectedIndex = 0;
            #region Auto Complete Property
            System.Collections.ArrayList ListArray = new ArrayList();
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Patient_Registration", con);

            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
                namesCollection.Add(dt.Rows[i]["Name"].ToString());

            txtpatient.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtpatient.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtpatient.AutoCompleteCustomSource = namesCollection;
            #endregion
            // if(!IsPostBack)
            generateAutoId();
            FetchDoctor();
            Referred_Doctor();
            State();
            District();
            Taluka();
        }

        public void generateAutoId()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select Count(PID) From Patient_Registration", con);
            int i = Convert.ToInt32(cmb.ExecuteScalar());
            con.Close();
            i++;
            P_ID = i;
            string a = i.ToString("0000");
            textBox1.Text = PID + a;

            //PatientBindIPD = textBox1.ToString();

        }
        public void generateAutoOId()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select Count(PatientOPDId) From OPD_Patient_Registration", con);
            int i = Convert.ToInt32(cmb.ExecuteScalar());
            con.Close();
            i++;
            string a = i.ToString("0000");
            textBox2.Text = OIDA + a;
            //opdID = textBox2.ToString();
        }
        public void State()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * From States", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtstate.DataSource = dt;
                txtstate.DisplayMember = "State";
                txtstate.ValueMember = "SID";
            }

        }
        public void District()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * From District where (SID=@SID) ", con);
            cmb.Parameters.AddWithValue("@SID", txtstate.SelectedIndex);
            cmb.ExecuteNonQuery();
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtdistrict.DataSource = dt;
                txtdistrict.DisplayMember = "District";
                txtdistrict.ValueMember = "DID";
            }
        }
        public void Taluka()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * From Taluka where (DID=@DID) ", con);
            cmb.Parameters.AddWithValue("@DID", txtdistrict.SelectedIndex);
            cmb.ExecuteNonQuery();
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txttaluka.DataSource = dt;
                txttaluka.DisplayMember = "Taluka";
                txttaluka.ValueMember = "TID";
            }

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtpurpose.SelectedItem.Equals("---Select---"))
                {
                    MessageBox.Show("Please select Purpose...");
                    return;
                }
                else
                {
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"Insert Into Patient_Registration (Patient_ID,Prefixes,Name,Gender,DOB,Age,Marital_Status,Mobile_Number,
                                               Email,Adhaar_ID,Weight,Purpose,Alternate_Mobile,Nationality,Remark,Dr_Name,AROGYA_Card,Registration_Charges,Consultation_Charges,
                                               Address,State,District,Taluka,City,Doctors_Name,Referred_By,Date) Values (@Patient_ID,@Prefixes,@Name,@Gender,@DOB,@Age,@Marital_Status,@Mobile_Number,
                                               @Email,@Adhaar_ID,@Weight,@Purpose,@Alternate_Mobile,@Nationality,@Remark,@Dr_Name,@AROGYA_Card,@Registration_Charges,@Consultation_Charges,

                                               @Address,@State,@District,@Taluka,@City,@Doctors_Name,@Referred_By,@Date)", con);
                    cmd.Parameters.AddWithValue("@Patient_ID", textBox1.Text);

                    //cmd.Parameters.AddWithValue("@Patient_ID", "RSHJ001");b

                    cmd.Parameters.AddWithValue("@Prefixes", txtprofix.Text);

                    if (txtweight.Text.Equals("Enter the Weight "))
                    {
                        cmd.Parameters.AddWithValue("@Weight", txtweight.Text = "0");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Weight", txtweight.Text);
                    }
                    if (txtname.Text.Equals("Fisrtname           Middle             Lastname\n"))
                    {
                        MessageBox.Show("Please enter name...");
                        return;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Name", txtname.Text);
                    }

                    if (btnmale.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@Gender", "Male");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Gender", "Female");
                    }
                    cmd.Parameters.AddWithValue("@DOB", txtdate.Text);
                    if (txtage.Text.Equals("Enter the Age"))
                    {
                        cmd.Parameters.AddWithValue("@Age", txtage.Text = "0");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Age", txtage.Text);
                    }
                    cmd.Parameters.AddWithValue("@Marital_Status", cbmmaritalstatus.Text);
                    cmd.Parameters.AddWithValue("@Mobile_Number", txtmobilenumber.Text);
                    cmd.Parameters.AddWithValue("@Email", txtmail.Text);
                    cmd.Parameters.AddWithValue("@Adhaar_ID", txtaadhaar.Text);
                    cmd.Parameters.AddWithValue("@Alternate_Mobile", txtalternateno.Text);
                    cmd.Parameters.AddWithValue("@Nationality", txtnationality.Text);
                    cmd.Parameters.AddWithValue("@Remark", txtremark.Text);
                    cmd.Parameters.AddWithValue("@Dr_Name", txtDrName.Text);
                    cmd.Parameters.AddWithValue("@AROGYA_Card", txtarogyacard.Text);
                    cmd.Parameters.AddWithValue("@Registration_Charges", txtregicharges.Text);

                    if (txtconsultacharges.Text.Equals("Enter Charges"))
                    {
                        cmd.Parameters.AddWithValue("@Consultation_Charges", txtconsultacharges.Text = "0");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Consultation_Charges", txtconsultacharges.Text);
                    }

                    cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                    cmd.Parameters.AddWithValue("@State", txtstate.Text);
                    cmd.Parameters.AddWithValue("@District", txtdistrict.Text);
                    cmd.Parameters.AddWithValue("@Taluka", txttaluka.Text);
                    cmd.Parameters.AddWithValue("@City", txtcity.Text);
                    if (cmbDoctor.Text.Equals("---Select---"))
                    {
                        MessageBox.Show("Please select Doctor...");
                        return;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Doctors_Name", cmbDoctor.Text);
                    }
                    if (cmbReferred.Text.Equals("---Select---"))
                    {
                        MessageBox.Show("Please select Reffered Doctor...");
                        return;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Referred_By", cmbReferred.Text);
                    }
                    cmd.Parameters.AddWithValue("@Date", dtpAdmissonDate.Text);
                    cmd.Parameters.AddWithValue("@Purpose", txtpurpose.Text);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    if (txtpurpose.Text == "IPD")
                    {
                        MessageBox.Show("Record Added Successfully to IPD...");
                        btnGOTOIPD.Visible = true;
                        btnsave.Visible = false;
                        btnPrint.Visible = false;
                    }
                    if (txtpurpose.Text == "Only Test")
                    {
                        generateAutoOId();
                        MessageBox.Show("Record Added Successfully ...");
                        OPDRegistration();
                        btnGOTOIPD.Visible = false;
                        btnsave.Visible = false;
                        btnPrint.Visible = false;
                        button4.Visible = true;
                    }
                    if (txtpurpose.Text == "OPD")
                    {
                        generateAutoOId();
                        MessageBox.Show("Record Added Successfully");
                        //btnPrint_Click(sender, e);
                        OPDRegistration();
                        btnGOTOIPD.Visible = false;
                        btnsave.Visible = false;
                        btnPrint.Visible = false;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
            txtNew.Text = countpatient.ToString();
            Patient_ID = countpatient;
        }

        public void rowopdcount()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select * from OPD_Patient_Registration", con);
            SqlDataAdapter s = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            s.Fill(dt);
            opdID = dt.Rows.Count;
            //txtNew.Text = countpatient.ToString();
        }

        public void OPDRegistration()
        {
            try
            {
                rowcount();
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"Insert into OPD_Patient_Registration (PatientId,Summary,Treatement,ChargesId,XRay,OPDSurgicalProcedureID,ConsultantID,ReferredId,VisitDate,IsCheck,FollowUpDate,PatientOPDIdWithSr)Values(@PatientId,@Summary,@Treatement,@ChargesId,@XRay,@OPDSurgicalProcedureID,@ConsultantID,@ReferredId,@VisitDate,@IsCheck,@FollowUpDate,@PatientOPDIdWithSr)", con);
                cmd.Parameters.AddWithValue("@PatientId", countpatient);
                cmd.Parameters.AddWithValue("@Summary", "");
                cmd.Parameters.AddWithValue("@Treatement", "");
                cmd.Parameters.AddWithValue("@ChargesId", "");
                cmd.Parameters.AddWithValue("@XRay", "");
                cmd.Parameters.AddWithValue("@OPDSurgicalProcedureID", "");
                cmd.Parameters.AddWithValue("@ConsultantID", cmbDoctor.Text);
                cmd.Parameters.AddWithValue("@ReferredId", cmbReferred.Text);
                cmd.Parameters.AddWithValue("@VisitDate", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@IsCheck", 0);
                cmd.Parameters.AddWithValue("@FollowUpDate", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@PatientOPDIdWithSr", textBox2.Text);
                cmd.ExecuteNonQuery();
                rowopdcount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void UpdateRegistration()
        {
            try
            {

                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"Update Patient_Registration set (Prefixes=@Prefixes,Name=@Name,Gender=@Gende,DOB=@DOB,Age=@Age,Marital_Status=@Marital_Status,Mobile_Number=@Mobile_Number,
                                               Email=@Email,Adhaar_ID=@Adhaar_ID,Weight=@Weight,Purpose=@Purpose,Alternate_Mobile=@Alternate_Mobile,Nationality=@Nationality,Remark=@Remark,AROGYA_Card=@AROGYA_Card,Registration_Charges=@Registration_Charges,Consultation_Charges=@Consultation_Charges,
                                               Address=@Address,State=@State,District=@District,Taluka=@Taluka,City=@City,Doctors_Name=@Doctors_Name,Referred_By=@Referred_By,Date=@Date)  where Patient_ID=@Patient_ID)", con);


                cmd.Parameters.AddWithValue("@Patient_ID", textBox1.Text);
                cmd.Parameters.AddWithValue("@Prefixes", txtprofix.Text);
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                if (btnmale.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@Gender", "Male");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Gender", "Female");
                }

                cmd.Parameters.AddWithValue("@DOB", txtdate.Text);
                cmd.Parameters.AddWithValue("@Age", txtage.Text);
                cmd.Parameters.AddWithValue("@Marital_Status", cbmmaritalstatus.Text);
                cmd.Parameters.AddWithValue("@Mobile_Number", txtmobilenumber.Text);
                cmd.Parameters.AddWithValue("@Email", txtmail.Text);
                cmd.Parameters.AddWithValue("@Adhaar_ID", txtaadhaar.Text);
                cmd.Parameters.AddWithValue("@Weight", txtweight.Text);
                cmd.Parameters.AddWithValue("@Purpose", txtpurpose.Text);
                cmd.Parameters.AddWithValue("@Alternate_Mobile", txtalternateno.Text);
                cmd.Parameters.AddWithValue("@Nationality", txtnationality.Text);
                cmd.Parameters.AddWithValue("@Remark", txtDrName.Text);
                cmd.Parameters.AddWithValue("@AROGYA_Card", txtarogyacard.Text);
                cmd.Parameters.AddWithValue("@Registration_Charges", txtregicharges.Text);
                cmd.Parameters.AddWithValue("@Consultation_Charges", txtconsultacharges.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@State", txtstate.Text);
                cmd.Parameters.AddWithValue("@District", txtdistrict.Text);
                cmd.Parameters.AddWithValue("@Taluka", txttaluka.Text);
                cmd.Parameters.AddWithValue("@City", txtcity.Text);
                cmd.Parameters.AddWithValue("@Doctors_Name", cmbDoctor.Text);
                cmd.Parameters.AddWithValue("@Referred_By", cmbReferred.Text);
                cmd.Parameters.AddWithValue("@Date", dtpAdmissonDate);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtmobilenumber_TextChanged(object sender, EventArgs e)
        {

        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            btnsave.Visible = false;

            try
            {
                if (txtpatientsearch.Text == "Name")
                {



                    if (txtpatient.Text == "")
                    {
                        MessageBox.Show("Please Enter Patient Name!!!");
                    }
                    else
                    {
                        String PatientName = txtpatient.Text;
                        SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                        con.Open();
                        //Select * from Patient_Registration where Name LIKE '%PatientName%'
                        SqlCommand cmd = new SqlCommand("Select * from Patient_Registration where Name LIKE '" + txtpatient.Text + "%'", con);
                        SqlDataAdapter adt = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adt.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            txtprofix.DataBindings.Add("Text", dt, "Prefixes");
                            txtname.DataBindings.Add("Text", dt, "Name");

                            txtdate.DataBindings.Add("Text", dt, "DOB");
                            txtage.DataBindings.Add("Text", dt, "Age");
                            cbmmaritalstatus.DataBindings.Add("Text", dt, "Marital_Status");
                            txtmobilenumber.DataBindings.Add("Text", dt, "Mobile_Number");
                            txtmail.DataBindings.Add("Text", dt, "Email");
                            txtaadhaar.DataBindings.Add("Text", dt, "Adhaar_ID");
                            txtweight.DataBindings.Add("Text", dt, "Weight");
                            txtpurpose.DataBindings.Add("Text", dt, "Purpose");
                            txtalternateno.DataBindings.Add("Text", dt, "Alternate_Mobile");
                            txtnationality.DataBindings.Add("Text", dt, "Nationality");
                            txtDrName.DataBindings.Add("Text", dt, "Remark");
                            txtregicharges.DataBindings.Add("Text", dt, "Registration_Charges");
                            txtconsultacharges.DataBindings.Add("Text", dt, "Consultation_Charges");
                            txtaddress.DataBindings.Add("Text", dt, "Address");
                            txtstate.DataBindings.Add("Text", dt, "State");
                            txtdistrict.DataBindings.Add("Text", dt, "District");
                            txttaluka.DataBindings.Add("Text", dt, "Taluka");
                            txtcity.DataBindings.Add("Text", dt, "City");
                            cmbDoctor.DataBindings.Add("Text", dt, "Doctors_Name");
                            cmbReferred.DataBindings.Add("Text", dt, "Referred_By");

                            //DataBindings();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtpatient_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpatientsearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtname_Enter(object sender, EventArgs e)
        {
            if (txtname.Text == "Fisrtname           Middle             Lastname\n")
            {
                txtname.Text = "";
                txtname.ForeColor = Color.Black;
            }
        }

        private void txtname_Leave(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                txtname.Text = "Fisrtname           Middle             Lastname\n";
                txtname.ForeColor = Color.Gray;
            }
        }

        private void txtmobilenumber_Enter(object sender, EventArgs e)
        {
            if (txtmobilenumber.Text == "123456789")
            {
                txtmobilenumber.Text = "";
                txtmobilenumber.ForeColor = Color.Black;
            }
        }

        private void txtmobilenumber_Leave(object sender, EventArgs e)
        {
            if (txtmobilenumber.Text == "")
            {
                txtmobilenumber.Text = "123456789";
                txtmobilenumber.ForeColor = Color.Gray;
            }
        }

        private void txtpatient_Enter(object sender, EventArgs e)
        {
            if (txtpatient.Text == "Enter the Patient Info")
            {
                txtpatient.Text = "";
                txtpatient.ForeColor = Color.Black;
            }
        }

        private void txtpatient_Leave(object sender, EventArgs e)
        {
            if (txtpatient.Text == "")
            {
                txtpatient.Text = "Enter the Patient Info";
                txtpatient.ForeColor = Color.Gray;
            }
        }

        private void txtmail_Enter(object sender, EventArgs e)
        {
            if (txtmail.Text == "Enter Your Email")
            {
                txtmail.Text = "";
                txtmail.ForeColor = Color.Black;
            }
        }

        private void txtaadhaar_Enter(object sender, EventArgs e)
        {
            if (txtaadhaar.Text == "1233456789012")
            {
                txtaadhaar.Text = "";
                txtaadhaar.ForeColor = Color.Black;

            }
        }

        private void txtaadhaar_Leave(object sender, EventArgs e)
        {
            if (txtaadhaar.Text == "")
            {
                txtaadhaar.Text = "1233456789012";
                txtaadhaar.ForeColor = Color.Gray;

            }
        }

        private void txtregicharges_Enter(object sender, EventArgs e)
        {
            if (txtregicharges.Text == "Enter Registration Charges")
            {
                txtregicharges.Text = "";
                txtregicharges.ForeColor = Color.Black;
            }
        }

        private void txtregicharges_Leave(object sender, EventArgs e)
        {

            if (txtregicharges.Text == "")
            {
                txtregicharges.Text = "Enter Registration Charges";
                txtregicharges.ForeColor = Color.Gray;
            }
        }

        private void txtconsultacharges_Enter(object sender, EventArgs e)
        {

            if (txtconsultacharges.Text == "Enter Charges")
            {
                txtconsultacharges.Text = "0";
                txtconsultacharges.ForeColor = Color.Black;
            }
        }

        private void txtconsultacharges_Leave(object sender, EventArgs e)
        {
            if (txtconsultacharges.Text == "")
            {
                txtconsultacharges.Text = "Enter Charges";
                txtconsultacharges.ForeColor = Color.Gray;
            }
        }

        private void txtarogyacard_Enter(object sender, EventArgs e)
        {
            if (txtarogyacard.Text == "1233456789012")
            {
                txtarogyacard.Text = "";
                txtarogyacard.ForeColor = Color.Black;
            }
        }

        private void txtarogyacard_Leave(object sender, EventArgs e)
        {
            if (txtarogyacard.Text == "")
            {
                txtarogyacard.Text = "1233456789012";
                txtarogyacard.ForeColor = Color.Gray;
            }
        }

        private void txtage_Enter(object sender, EventArgs e)
        {

        }

        private void txtdate_ValueChanged(object sender, EventArgs e)
        {
            int AgeYear = DateTime.Today.Year - txtdate.Value.Year;
            txtage.Text = AgeYear.ToString();
        }

        private void txtname_Click(object sender, EventArgs e)
        {

        }

        private void txtname_MouseClick(object sender, MouseEventArgs e)
        {
            txtname.Clear();
        }

        private void txtmobilenumber_MouseClick(object sender, MouseEventArgs e)
        {
            txtmobilenumber.Clear();
        }

        private void txtarogyacard_MouseClick(object sender, MouseEventArgs e)
        {
            txtarogyacard.Clear();
        }

        private void txtage_MouseClick(object sender, MouseEventArgs e)
        {
            txtage.Clear();
        }

        private void txtweight_MouseClick(object sender, MouseEventArgs e)
        {
            txtweight.Clear();
        }

        private void txtalternateno_MouseClick(object sender, MouseEventArgs e)
        {
            txtalternateno.Clear();
        }

        private void txtremark_MouseClick(object sender, MouseEventArgs e)
        {
            txtDrName.Clear();
        }

        private void txtaddress_MouseClick(object sender, MouseEventArgs e)
        {
            txtaddress.Clear();
        }

        private void btnGOTOIPD_Click(object sender, EventArgs e)
        {
            rowcount();
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select * from Patient_Registration where PID=@countpatient", con);
            cmd.Parameters.AddWithValue("@countpatient", txtNew.Text);
            SqlDataAdapter s = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            s.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                PatientBindIPD = Convert.ToInt32(dt.Rows[0]["PID"]);
            }
            IPD_Registration o = new IPD_Registration(PatientBindIPD);
            o.Show();
        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtage_Enter_1(object sender, EventArgs e)
        {
            if (txtage.Text == "Enter the Age")
            {
                txtage.Text = "";
                txtage.ForeColor = Color.Black;
            }
        }

        private void txtage_Leave(object sender, EventArgs e)
        {
            if (txtage.Text == "")
            {
                txtage.Text = "Enter the Age";
                txtage.ForeColor = Color.Gray;
            }
        }

        private void txtweight_Enter(object sender, EventArgs e)
        {
            if (txtweight.Text == "Enter the Weight")
            {
                txtweight.Text = "";
                txtweight.ForeColor = Color.Black;
            }
        }

        private void txtweight_Leave(object sender, EventArgs e)
        {
            if (txtweight.Text == "")
            {
                txtweight.Text = "Enter the Weight";
                txtweight.ForeColor = Color.Gray;
            }
        }

        private void txtalternateno_Enter(object sender, EventArgs e)
        {
            if (txtalternateno.Text == "1234567890")
            {
                txtalternateno.Text = "";
                txtalternateno.ForeColor = Color.Black;
            }

        }

        private void txtremark_Enter(object sender, EventArgs e)
        {
            if (txtDrName.Text == "Enter the Remark")
            {
                txtDrName.Text = "";
                txtDrName.ForeColor = Color.Black;
            }
        }

        private void txtalternateno_Leave(object sender, EventArgs e)
        {
            if (txtalternateno.Text == "")
            {
                txtalternateno.Text = "1234567890";
                txtalternateno.ForeColor = Color.Gray;
            }
        }

        private void txtremark_Leave(object sender, EventArgs e)
        {
            if (txtDrName.Text == "")
            {
                txtDrName.Text = "Enter the Remark";

                txtDrName.ForeColor = Color.Gray;
            }
        }

        private void txtaddress_Enter(object sender, EventArgs e)
        {
            if (txtaddress.Text == "Enter the Address")
            {
                txtaddress.Text = "";
                txtaddress.ForeColor = Color.Black;
            }
        }


        private void txtconsultacharges_MouseClick(object sender, MouseEventArgs e)
        {
            txtconsultacharges.Clear();
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
                cmbDoctor.DataSource = dt;
                cmbDoctor.DisplayMember = "Dr_Name";
                cmbDoctor.ValueMember = "DR_ID";
                

                DataRow drr3;
                drr3 = dt.NewRow();
                drr3["DR_ID"] = "0";
                drr3["Dr_Name"] = "---Select---";
                dt.Rows.Add(drr3);
                dt.DefaultView.Sort = "DR_ID asc";


                //dt1.DefaultView.Sort = "PurposeId asc";
                //cmbDoctor.DataSource = dt;
                //cmbDoctor.DisplayMember = "Dr_Name";
                //cmbDoctor.ValueMember = "DR_ID";
               

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
                cmbReferred.DataSource = dt;
                cmbReferred.DisplayMember = "Referred_Name";
                cmbReferred.ValueMember = "ReferredID";

                DataRow drr1;
                drr1 = dt.NewRow();
                drr1["ReferredID"] = "0";
                drr1["Referred_Name"] = "---Select---";
                dt.Rows.Add(drr1);
                dt.DefaultView.Sort = "ReferredID asc";


                //dt1.DefaultView.Sort = "PurposeId asc";
                //cmbReferred.DataSource = dt;
                //cmbReferred.DisplayMember = "Referred_Name";
                //cmbReferred.ValueMember = "ReferredID";
                //cmbReferred.Text = "--Select Doctor--";
            }
            con.Close();
        }

        private void txtdistrict_TextChanged(object sender, EventArgs e)
        {
            //if(txtstate.Text.Trim)
            //{

            //}
            Taluka();
        }

        private void txtstate_TextChanged(object sender, EventArgs e)
        {
            District();

        }

        private void NN(object sender, PaintEventArgs e)
        {

        }

        private void txtconsultacharges_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpurpose_TextChanged(object sender, EventArgs e)
        {
            if (txtpurpose.Text == "OPD")
            {
                generateAutoOId();
            }
            else 
            {
                textBox2.Text = "";
            }

            if (txtpurpose.Text == "Only Test")
            {
                txtDrName.Visible = true;
                label17.Visible = true;
                cmbReferred.Visible = false;
                label23.Visible = false;
                cmbDoctor.Visible = false;
                label16.Visible = false;
            }
            else
            {
                txtDrName.Visible = false;
                label17.Visible = false;
                cmbReferred.Visible = true;
                label23.Visible = true;
                cmbDoctor.Visible = true;
                label16.Visible = true;
            }
        }
        public void onlytest()
        {
            txtDrName.Visible = true;
        }

        private void txtstate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtdistrict_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtconsultacharges_MouseClick_1(object sender, MouseEventArgs e)
        {
            txtconsultacharges.Clear();
        }

        private void txtpatient_MouseClick(object sender, MouseEventArgs e)
        {
            txtpatient.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            SelectOnlyTest o = new SelectOnlyTest(opdID);
            o.Show();

        }

        private void txtpurpose_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpAdmissonDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtaddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttaluka_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void CasePaper()
        {
            Report.OPDCase_Paper cryRpt = new Report.OPDCase_Paper();


            TableLogOnInfos crtableLogoninfosNew = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfoNew = new TableLogOnInfo();
            ConnectionInfo crConnectionInfoNew = new ConnectionInfo();
            Tables CrTablesNew;
            crConnectionInfoNew.ServerName = ConfigurationSettings.AppSettings["SreverName"].ToString();
            crConnectionInfoNew.DatabaseName = ConfigurationSettings.AppSettings["DatabaseName"].ToString();
            crConnectionInfoNew.UserID = ConfigurationSettings.AppSettings["UsernameForReport"].ToString();
            crConnectionInfoNew.Password = ConfigurationSettings.AppSettings["PasswordForReport"].ToString();

            CrTablesNew = cryRpt.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTablesNew)
            {
                crtableLogoninfoNew = CrTable.LogOnInfo;
                crtableLogoninfoNew.ConnectionInfo = crConnectionInfoNew;
                CrTable.ApplyLogOnInfo(crtableLogoninfoNew);
            }



            cryRpt.SetParameterValue("PID", P_ID);

            ReportViewerForOPD obj = new ReportViewerForOPD();

            obj.crystalReportViewer1.ReportSource = cryRpt;
            obj.Refresh();
            obj.Show();

            this.Close();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Report.OPDRegistrationBilling cryRptNew = new Report.OPDRegistrationBilling();

           
            TableLogOnInfos crtableLogoninfosNew = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfoNew = new TableLogOnInfo();
            ConnectionInfo crConnectionInfoNew = new ConnectionInfo();
            Tables CrTablesNew;
            crConnectionInfoNew.ServerName = ConfigurationSettings.AppSettings["SreverName"].ToString();
            crConnectionInfoNew.DatabaseName = ConfigurationSettings.AppSettings["DatabaseName"].ToString();
            crConnectionInfoNew.UserID = ConfigurationSettings.AppSettings["UsernameForReport"].ToString();
            crConnectionInfoNew.Password = ConfigurationSettings.AppSettings["PasswordForReport"].ToString();

            CrTablesNew = cryRptNew.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTablesNew)
            {
                crtableLogoninfoNew = CrTable.LogOnInfo;
                crtableLogoninfoNew.ConnectionInfo = crConnectionInfoNew;
                CrTable.ApplyLogOnInfo(crtableLogoninfoNew);
            }

           

            cryRptNew.SetParameterValue("PID", P_ID);

            ReportViewerForOPD obj = new ReportViewerForOPD();

            obj.crystalReportViewer1.ReportSource = cryRptNew;
            obj.Refresh();
            obj.Show();

            this.Close();

            CasePaper();
        }

        private void txtweight_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void txtconsultacharges_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmbReferred_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbReferred.Text = cmbReferred.SelectedItem.ToString();
            //Referred_Doctor();
        }

        private void cmbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoctor.Text = cmbDoctor.SelectedItem.ToString();
            //FetchDoctor();
        }

        private void cmbDoctor_Leave(object sender, EventArgs e)
        {
            if(cmbDoctor.Text == "")
            {
                cmbDoctor.Text = "---Select---";
            }
        }

        private void cmbReferred_Leave(object sender, EventArgs e)
        {
            if(cmbReferred.Text == "")
            {
                cmbReferred.Text = "---Select---";
            }
        }

        private void cmbDoctor_Enter(object sender, EventArgs e)
        {
            if(cmbDoctor.Text == "---Select---")
            {
                cmbDoctor.Text = "";
            }
        }

        private void cmbReferred_Enter(object sender, EventArgs e)
        {
            if (cmbReferred.Text == "---Select---")
            {
                cmbReferred.Text = "";
            }
        }
    }
}
