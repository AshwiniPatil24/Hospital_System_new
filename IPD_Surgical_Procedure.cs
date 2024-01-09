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
    public partial class IPD_Surgical_Procedure : Form
    {
        int id;
        public int Public_ID;
        public IPD_Surgical_Procedure()
        {
            InitializeComponent();
        }
        public IPD_Surgical_Procedure(int a)
        {
            InitializeComponent();
            id = a;
        }
        public void PID()
        {
            try
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
                    dataGridView1.DataSource = o;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void IPD_Surgical_Procedure_Billing_Load(object sender, EventArgs e)
        {
            show();
            //show1();
            type();
            PID();
            Procedure();
            ShowSurgicalProcedure();
            ShowAssistantName();
            ShowSurgon();
            ShowAnesthetistName();
            showAssistantName();
            showAnesthethit();
        }
        public void show()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * from Doctors", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if(dt.Rows.Count>0)
            {
                cmbSurgen1.DataSource = dt;
                cmbSurgen1.DisplayMember = "Dr_Name";
                cmbSurgen1.ValueMember = "DR_ID";

                DataRow drr1;
                drr1 = dt.NewRow();
                drr1["DR_ID"] = "0";
                drr1["Dr_Name"] = "---Select Surgon Name---";
                dt.Rows.Add(drr1);
                dt.DefaultView.Sort = "DR_ID asc";


                //dt1.DefaultView.Sort = "PurposeId asc";
                cmbSurgen1.DataSource = dt;
                cmbSurgen1.DisplayMember = "Dr_Name";
                cmbSurgen1.ValueMember = "DR_ID";
                cmbSurgen1.Text = "--Select Surgon Name--";

            }
        }
        public void showAssistantName()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * from ListOfAssistants", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                cmbAssistant1.DataSource = dt;
                cmbAssistant1.DisplayMember = "Assistant_Name";
                cmbAssistant1.ValueMember = "ID";

                DataRow drr1;
                drr1 = dt.NewRow();
                drr1["ID"] = "0";
                drr1["Assistant_Name"] = "---Select Assistant Name---";
                dt.Rows.Add(drr1);
                dt.DefaultView.Sort = "ID asc";


                //dt1.DefaultView.Sort = "PurposeId asc";
                cmbAssistant1.DataSource = dt;
                cmbAssistant1.DisplayMember = "Assistant_Name";
                cmbAssistant1.ValueMember = "ID";
                cmbAssistant1.Text = "--Select Assistant Name--";

            }
        }
        public void showAnesthethit()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * from ListOfAnesthetist", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                cmbAnesthetist.DataSource = dt;
                cmbAnesthetist.DisplayMember = "Anesthetist";
                cmbAnesthetist.ValueMember = "ID";

                DataRow drr1;
                drr1 = dt.NewRow();
                drr1["ID"] = "0";
                drr1["Anesthetist"] = "---Select Anesthetist ---";
                dt.Rows.Add(drr1);
                dt.DefaultView.Sort = "ID asc";


                //dt1.DefaultView.Sort = "PurposeId asc";
                cmbAnesthetist.DataSource = dt;
                cmbAnesthetist.DisplayMember = "Anesthetist";
                cmbAnesthetist.ValueMember = "ID";
                cmbAnesthetist.Text = "--Select Anesthetist--";

            }
        }

        public void type()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * from Master_IPDSurgicalProcType", con);            
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "SurgicalTypeName";
                comboBox1.ValueMember = "ID";

                DataRow drr3;
                drr3 = dt.NewRow();
                drr3["ID"] = "0";
                drr3["SurgicalTypeName"] = "---Select---";
                dt.Rows.Add(drr3);
                dt.DefaultView.Sort = "ID asc";


                //dt1.DefaultView.Sort = "PurposeId asc";
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "SurgicalTypeName";
                comboBox1.ValueMember = "ID";
                comboBox1.Text = "--Select Surgery Category--";
            }            
        }
        public void Procedure()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * From Master_IPDSurgicalProcedure
WHERE        ProcedureTypeID = @ProcedureTypeID", con);
            cmb.Parameters.AddWithValue("@ProcedureTypeID", comboBox1.SelectedIndex);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if(dt.Rows.Count>0)
            {
                comsurgeryname.DataSource = dt;
                comsurgeryname.DisplayMember = "Name";
                comsurgeryname.ValueMember = "ID";

                DataRow drr2;
                drr2 = dt.NewRow();
                drr2["ID"] = "0";
                drr2["Name"] = "---Select---";
                dt.Rows.Add(drr2);
                dt.DefaultView.Sort = "ID asc";


                //dt1.DefaultView.Sort = "PurposeId asc";
                comsurgeryname.DataSource = dt;
                comsurgeryname.DisplayMember = "Name";
                comsurgeryname.ValueMember = "ID";
                comsurgeryname.Text = "--Select Surgery --";
            }
        }
        public void ShowSurgicalProcedure()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select ID,Surgical_Category,Surgery_Name From AssignIPDSurgicalProcedure where IPDID=@id", con);
            cmd.Parameters.AddWithValue(@"id", id);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dtPublic = new DataTable();
            adt.Fill(dtPublic);
            if (dtPublic.Rows.Count > 0)
            {
                dataGridView2.DataSource = dtPublic;
                dataGridView2.Columns["ID"].Visible = false;
            }
           
        }
        public void Save_SurgicalProcedure()
        {
            try
            {
                if (comboBox1.Text != "---Select---" && comsurgeryname.Text != "---Select---")
                {
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"Insert into AssignIPDSurgicalProcedure (IPDID,Surgical_Category,Surgery_Name,Surgeon_Name1,Surgeon_Name2,Assistant_Name_1,Assistant_Name_2,AnesthetistName,SurgeonCharges,SevoFlurenceCharges,OTCharges,OTAssistant,OutsideOTWithoutAnesthesia,OTInstruments,BoylesMachineCharges,AnesthetistCharges,OtherCharges,TotalAmount,Remark,SurgeryDate) 
Values(@IPDID,@Surgical_Category,@Surgery_Name,@Surgeon_Name1,@Surgeon_Name2,@Assistant_Name_1,@Assistant_Name_2,@AnesthetistName,@SurgeonCharges,@SevoFlurenceCharges,@OTCharges,@OTAssistant,@OutsideOTWithoutAnesthesia,@OTInstruments,@BoylesMachineCharges,@AnesthetistCharges,@OtherCharges,@TotalAmount,@Remark,@SurgeryDate)", con);
                    cmd.Parameters.AddWithValue("@IPDID", id);
                    cmd.Parameters.AddWithValue("@Surgical_Category", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Surgery_Name", comsurgeryname.Text);
                    cmd.Parameters.AddWithValue("@Surgeon_Name1", cmbSurgen1.Text);
                    cmd.Parameters.AddWithValue("@Surgeon_Name2", "");
                    cmd.Parameters.AddWithValue("@Assistant_Name_1", cmbAssistant1.Text);
                    cmd.Parameters.AddWithValue("@Assistant_Name_2", "");
                    cmd.Parameters.AddWithValue("@AnesthetistName", cmbAnesthetist.Text);
                    cmd.Parameters.AddWithValue("@SurgeonCharges", 0);
                    cmd.Parameters.AddWithValue("@SevoFlurenceCharges", 0);
                    cmd.Parameters.AddWithValue("@OTCharges", 0);
                    cmd.Parameters.AddWithValue("@OTAssistant", 0);
                    cmd.Parameters.AddWithValue("@OutsideOTWithoutAnesthesia", 0);
                    cmd.Parameters.AddWithValue("@OTInstruments", 0);
                    cmd.Parameters.AddWithValue("@BoylesMachineCharges", 0);
                    cmd.Parameters.AddWithValue("@AnesthetistCharges", 0);
                    cmd.Parameters.AddWithValue("@OtherCharges", 0);
                    cmd.Parameters.AddWithValue("@TotalAmount", 0);
                    cmd.Parameters.AddWithValue("@Remark", txtRemark.Text);
                    cmd.Parameters.AddWithValue("@SurgeryDate", dtpTestDate.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Added Successfully");
                    ShowSurgicalProcedure();
                    button17.Enabled = false;
                    button17.BackColor = Color.Silver;
                    button4.Enabled = true;
                    button4.BackColor = Color.DarkGoldenrod;

                    button5.Enabled = true;
                    button5.BackColor = Color.DarkGoldenrod;

                    button6.Enabled = true;
                    button6.BackColor = Color.DarkGoldenrod;
                    Procedure();
                }
                else
                {
                    MessageBox.Show("Select Surgery Details");
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void ShowSurgon()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select ID,SurgeonName From SurgeonName where SurgeryName=@SurgeryName and IPDID=@id", con);
            cmd.Parameters.AddWithValue(@"id", id);
            cmd.Parameters.AddWithValue(@"SurgeryName", comsurgeryname.Text);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dtPublic = new DataTable();
            adt.Fill(dtPublic);
            if (dtPublic.Rows.Count > -1)
            {
                dataGridView3.DataSource = dtPublic;
                dataGridView3.Columns["ID"].Visible = false;
            }

        }
        public void SaveSurgonName()
        {
            if (cmbSurgen1.Text != "---Select Surgon Name---")
            {

                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"Insert into SurgeonName (IPDID,SurgeryName,SurgeonName) Values(@IPDID,@SurgeryName,@SurgeonName)", con);
                cmd.Parameters.AddWithValue("@IPDID", id);
                cmd.Parameters.AddWithValue("@SurgeryName", comsurgeryname.Text);
                cmd.Parameters.AddWithValue("@SurgeonName", cmbSurgen1.Text);

                cmd.ExecuteNonQuery();
                ShowSurgon();
                button16.Enabled = true;
                button16.BackColor = Color.DarkGreen;
                show();

            }
            else
            {
                MessageBox.Show("Select Surgon Name");
            }

        }

        public void ShowAssistantName()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select ID,AssistantName From AssistantName_Table where SurgeryName=@SurgeryName and IPDID=@id", con);
            cmd.Parameters.AddWithValue(@"id", id);
            cmd.Parameters.AddWithValue(@"SurgeryName", comsurgeryname.Text);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dtPublic = new DataTable();
            adt.Fill(dtPublic);
            if (dtPublic.Rows.Count > -1)
            {
                dataGridView4.DataSource = dtPublic;
                dataGridView4.Columns["ID"].Visible = false;
                dataGridView4.Columns["AssistantName"].HeaderText= "Assistant_Name";
            }

        }
        public void SaveAssistantName()
        {
            if (cmbAssistant1.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"Insert into AssistantName_Table (IPDID,SurgeryName,AssistantName) Values(@IPDID,@SurgeryName,@AssistantName)", con);
                cmd.Parameters.AddWithValue("@IPDID", id);
                cmd.Parameters.AddWithValue("@SurgeryName", comsurgeryname.Text);
                cmd.Parameters.AddWithValue("@AssistantName", cmbAssistant1.Text);

                cmd.ExecuteNonQuery();
                ShowAssistantName();
                button16.Enabled = true;
                button16.BackColor = Color.DarkGreen;
            }
            else
            {
                MessageBox.Show("Select Assistant Name");
            }
                

        }

        public void ShowAnesthetistName()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select ID,Anesthetist From  Anesthetit_SurgeryName where SurgeryName=@SurgeryName and IPDID=@id", con);
            cmd.Parameters.AddWithValue(@"id", id);
            cmd.Parameters.AddWithValue(@"SurgeryName", comsurgeryname.Text);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dtPublic = new DataTable();
            adt.Fill(dtPublic);
            if (dtPublic.Rows.Count > -1)
            {
                dataGridView5.DataSource = dtPublic;
                dataGridView5.Columns["ID"].Visible = false;
            }

        }
        public void SaveAnesthetistName()
        {
            if (cmbAnesthetist.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"Insert into Anesthetit_SurgeryName(IPDID,SurgeryName,Anesthetist) Values(@IPDID,@SurgeryName,@Anesthetist)", con);
                cmd.Parameters.AddWithValue("@IPDID", id);
                cmd.Parameters.AddWithValue("@SurgeryName", comsurgeryname.Text);
                cmd.Parameters.AddWithValue("@Anesthetist", cmbAnesthetist.Text);

                cmd.ExecuteNonQuery();
                ShowAnesthetistName();
                button16.Enabled = true;
                button16.BackColor = Color.DarkGreen;
            }
            else
            {
                MessageBox.Show("Select Anesthetist");
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Procedure();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comsurgeryname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            Save_SurgicalProcedure();
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

                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"Delete from AssignIPDSurgicalProcedure where ID=@Public_ID", con);
                    cmd.Parameters.AddWithValue("@Public_ID", Public_ID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted Successfully..");


                    ShowSurgicalProcedure();

                }
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveSurgonName();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            string columnName = this.dataGridView3.Columns[e.ColumnIndex].Name;
            if (columnName.Equals("delete1") == true)
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    Public_ID = Convert.ToInt32(dataGridView3.CurrentRow.Cells["ID"].Value);

                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"Delete from SurgeonName where ID=@Public_ID", con);
                    cmd.Parameters.AddWithValue("@Public_ID", Public_ID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted Successfully..");
                    ShowSurgon();

                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveAssistantName();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            string columnName = this.dataGridView4.Columns[e.ColumnIndex].Name;
            if (columnName.Equals("delete2") == true)
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    Public_ID = Convert.ToInt32(dataGridView4.CurrentRow.Cells["ID"].Value);

                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"Delete from AssistantName_Table where ID=@Public_ID", con);
                    cmd.Parameters.AddWithValue("@Public_ID", Public_ID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted Successfully..");
                    ShowAssistantName();

                }
            }
        }
       
        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            string columnName = this.dataGridView5.Columns[e.ColumnIndex].Name;
            if (columnName.Equals("delete3") == true)
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    Public_ID = Convert.ToInt32(dataGridView5.CurrentRow.Cells["ID"].Value);

                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"Delete from Anesthetit_SurgeryName where ID=@Public_ID", con);
                    cmd.Parameters.AddWithValue("@Public_ID", Public_ID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted Successfully..");
                    //ShowAssistantName();
                    ShowAnesthetistName();

                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveAnesthetistName();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Record Added Successfully");
            show();
            type();
            Procedure();
            ShowAssistantName();
            ShowSurgon();
            ShowAnesthetistName();
            button17.Enabled = true;
            button17.BackColor = Color.DarkGoldenrod;
            button16.Enabled = false;
            button16.BackColor = Color.Silver;
        }
    }
}
