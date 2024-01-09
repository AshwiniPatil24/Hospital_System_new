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
    public partial class Master_OPD_Procedures : Form
    {
        AutoCompleteStringCollection namesOPDCollection = new AutoCompleteStringCollection();
        int IDOPDProc;
        public Master_OPD_Procedures()
        {
            InitializeComponent();
        }
        int Save = 0;
        public void Search()
        {
            
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
           
            SqlCommand cmd = new SqlCommand("Select * from Master_OPD_Procedures where Name LIKE '" + txtSearchName.Text + "%'", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            IDOPDProc = Convert.ToInt32(dt.Rows[0]["OPD_ProcedureID"]);
            if (dt.Rows.Count > 0)
            {
                txtProcedureName.DataBindings.Add("Text", dt, "Name");
                txtCharges.DataBindings.Add("Text", dt, "Charges");

                txtDate.DataBindings.Add("Text", dt, "Date");
            }
        }
        public void OPDName()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand CMD = new SqlCommand("Select Name FROM Master_OPD_Procedures WHERE Name=@Name", con);
            CMD.Parameters.AddWithValue("Name", txtProcedureName.Text);
            SqlDataReader SQLreader1;
           
            SQLreader1 = CMD.ExecuteReader();
            if (SQLreader1.Read())
            {
                MessageBox.Show("The Procedure is already taken. Please Enter a different Procedure");
                //txtProcedureName.Focus();
                txtProcedureName.Clear();
                con.Close();
            }
            else
            {
                con.Close();
            }
        }
        public void  AutoCompleted()
        {
            #region Auto Complete Property
            ArrayList ListArray = new ArrayList();
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * From Master_OPD_Procedures", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                namesOPDCollection.Add(dt.Rows[i]["Name"].ToString());
            }

            txtSearchName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtSearchName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSearchName.AutoCompleteCustomSource = namesOPDCollection;
            #endregion
        }
        public void update()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Update Master_OPD_Procedures Set Name=@Name,Charges=@Charges,UpdatedDate=@UpdatedDate where OPD_ProcedureID=@IDOPDProc", con);
            cmd.Parameters.AddWithValue("@IDOPDProc", IDOPDProc);
            cmd.Parameters.AddWithValue("@Name", txtProcedureName.Text);
            cmd.Parameters.AddWithValue("@Charges", txtCharges.Text);
            cmd.Parameters.AddWithValue("@UpdatedDate", txtDate.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record update Successfully..");
           
            txtProcedureName.Clear();
            txtCharges.Clear();
        }
        public void BindOPDListList()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * From Master_OPD_Procedures order by Name", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "OPD_ProcedureID";
            }

        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtSearchName.Text !="")
                {
                    update();
                }
                else
                {
                    
                    OPDName();
                    
                   
                        SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                        con.Open();
                        SqlCommand cmd = new SqlCommand(@"Insert into Master_OPD_Procedures (Name,Charges,Date)Values (@Name,@Charges,@Date)", con);
                        cmd.Parameters.AddWithValue("@Name", txtProcedureName.Text);
                        cmd.Parameters.AddWithValue("@Charges", txtCharges.Text);
                        cmd.Parameters.AddWithValue("@Date", txtDate.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Added Successfully..");
                        txtProcedureName.Clear();
                        txtCharges.Clear();
                                           
                    
                }     
                    
                    
                

                txtSearchName.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Master_OPD_Procedures_Load(object sender, EventArgs e)
        {
            //if (txtSearchName.Text=="")
            //{
            //    txtProcedureName.Clear();
            //    txtCharges.Clear();
            //}
            //BindOPDListList();
            #region Auto Complete Property
            ArrayList ListArray = new ArrayList();
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * From Master_OPD_Procedures", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                namesOPDCollection.Add(dt.Rows[i]["Name"].ToString());
            }

            txtSearchName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtSearchName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSearchName.AutoCompleteCustomSource = namesOPDCollection;
            #endregion
        }

        private void txtProcedureName_MouseClick(object sender, MouseEventArgs e)
        {
            txtProcedureName.Clear();
        }

        private void txtCharges_MouseClick(object sender, MouseEventArgs e)
        {
            txtCharges.Clear();
        }

        private void txtCharges_TextChanged(object sender, EventArgs e)
        {
            try
            {
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtCharges_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please Enter Only Number");
            }
        }

        

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            Search();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchName.Text = comboBox1.Text;
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            //textBox1.Text = txtSearchName.Text;
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProcedureName_MouseEnter(object sender, EventArgs e)
        {

        }

        private void txtProcedureName_MouseMove(object sender, MouseEventArgs e)
        {
           

        }

        private void txtProcedureName_TextChanged(object sender, EventArgs e)
        {
           

            
        }
    }
}
