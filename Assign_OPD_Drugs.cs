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
    public partial class Assign_OPD_Drugs : Form
    {
        AutoCompleteStringCollection drugNamesCollection = new AutoCompleteStringCollection();
        public int AddSave;
        public int DeleteID;
        public Assign_OPD_Drugs()
        {
            InitializeComponent();
        }
        public Assign_OPD_Drugs(int OPDFillID)
        {
            InitializeComponent();
            txtOPDID.Text = OPDFillID.ToString();
            //OPDPatientID = Convert.ToInt32(txtOPDID.Text);
            show_PatientDrugsDetails();

            BindDrugList();
        }

        public void show_PatientDrugsDetails()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT OPD_Patient_Registration.PatientOPDIdWithSr,Patient_Registration.Name, Patient_Registration.Mobile_Number, Patient_Registration.Doctors_Name, Patient_Registration.Referred_By
                      FROM Patient_Registration INNER JOIN OPD_Patient_Registration ON Patient_Registration.PID = OPD_Patient_Registration.PatientId where IsCheck = 0 and PatientOPDId=@OPDFillID", con);
            cmd.Parameters.AddWithValue(@"OPDFillID", txtOPDID.Text);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable o = new DataTable();
            adt.Fill(o);
            if (o.Rows.Count > 0)
            {
                dataGridView1.DataSource = o;
                dataGridView1.Columns["PatientOPDIdWithSr"].HeaderText = "OPD_ID";
            }
        }
            private void Assign_OPD_Drugs_Load(object sender, EventArgs e)
            {
            //if (txtGenericSelection.Text == "Select Drug Name")
            //{
            //    //txtEnterDrug.Text == "";
            //}
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
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtGenericSelection_TextChanged(object sender, EventArgs e)
        {
            txtEnterDrug.Text = txtGenericSelection.Text;
        }

        private void cmbOPDDrugList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEnterDrug.Text = cmbOPDDrugList.Text;
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

        public void show_GrideviewDetails()
        {
            try
            {

                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"Select * From OPD_PatientDrugList where OPDID=@OPDFillID", con);
                cmd.Parameters.AddWithValue(@"OPDFillID", txtOPDID.Text);
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                adt.Fill(dt);
                dataGridView2.DataSource = dt;
                dataGridView2.Columns["ID"].Visible = false;
                dataGridView2.Columns["Date"].Visible = false;
                dataGridView2.Columns["OPDID"].Visible = false;
                dataGridView2.Columns["MorningDose"].HeaderText = "AfterBreakfast";
                dataGridView2.Columns["AfternoonDose"].HeaderText = "AfterLunch";
                dataGridView2.Columns["NightDose"].HeaderText = "AfterDinner";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }



        }
        public void Save()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Insert into OPD_PatientDrugList (OPDID,Date,DrugName,ForDays,BeforeBreakfast,BeforeLunch,BeforeDinner,MorningDose,AfternoonDose,NightDose) Values(@OPDID,@Date,@DrugName,@ForDays,@BeforeBreakfast,@BeforeLunch,@BeforeDinner,@MorningDose,@AfternoonDose,@NightDose)", con);
            cmd.Parameters.AddWithValue("@OPDID", txtOPDID.Text);
            cmd.Parameters.AddWithValue("@Date", System.DateTime.Now);
            cmd.Parameters.AddWithValue("@DrugName", txtEnterDrug.Text);
            cmd.Parameters.AddWithValue("@ForDays", txtDays.Text);
            if(Chk1BeforeBreakfast.Checked==true)
            {
                cmd.Parameters.AddWithValue("@BeforeBreakfast", "1");


            }
            else
            {
                cmd.Parameters.AddWithValue("@BeforeBreakfast", "0");

            }
            if (chk1BeforeLunch.Checked == true)
            {
                cmd.Parameters.AddWithValue("@BeforeLunch","1");

            }
            else
            {
                cmd.Parameters.AddWithValue("@BeforeLunch", "0");
            }
            if (chk1BeforeDinner.Checked == true)
            {
                cmd.Parameters.AddWithValue("@BeforeDinner","1");

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
            

            #endregion
            show_GrideviewDetails();
            AddSave = 1;
           

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(AddSave == 1)
            {
                MessageBox.Show("Record Added SuccessFully");
            }
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int RowIndex = dataGridView2.CurrentCell.RowIndex;
            //dataGridView2.Rows.RemoveAt(RowIndex);
            
            //MessageBox.Show("Record Delete Successfully");
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            string columnName = this.dataGridView2.Columns[e.ColumnIndex].Name;


            if (columnName.Equals("btnDelete") == true)
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    DeleteID = Convert.ToInt32(dataGridView2.CurrentRow.Cells["ID"].Value);

                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"delete from OPD_PatientDrugList where ID=@DeleteID", con);
                    cmd.Parameters.AddWithValue("@DeleteID", DeleteID);

                    MessageBox.Show("Record Deleted Successfully..");

                }
                //this.Load(object sender, EventArgs e);
            }

        }
       
        private void txtGenericSelection_MouseClick(object sender, MouseEventArgs e)
        {
            txtGenericSelection.Clear();
        }

        private void txtEnterDrug_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
