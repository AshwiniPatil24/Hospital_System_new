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
    public partial class Master_Radiology : Form
    {
        int RadiologyID;
        int Save;
        public Master_Radiology()
        {
            InitializeComponent();
        }
        public void SaveDetails()
        {
              
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"Insert into Master_Radiology_Test (Name,Charges,Date)Values (@Name,@Charges,@Date)", con);
                cmd.Parameters.AddWithValue("@Name", txtRadiologyName.Text);
                cmd.Parameters.AddWithValue("@Charges", txtCharges.Text);
                cmd.Parameters.AddWithValue("@Date", txtdate.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Added Successfully..");
                txtRadiologyName.Clear();
                txtCharges.Clear();
           
            
        }
        public void update()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Update Master_Radiology_Test Set Name=@Name,Charges=@Charges,UpdatedOn=@UpdatedOn where Radiology_ID=@RadiologyID", con);
            cmd.Parameters.AddWithValue("@RadiologyID", RadiologyID);
            cmd.Parameters.AddWithValue("@Name", txtRadiologyName.Text);
            cmd.Parameters.AddWithValue("@Charges", txtCharges.Text);
            cmd.Parameters.AddWithValue("@UpdatedOn", txtdate.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record update Successfully..");

            txtRadiologyName.Clear();
            txtCharges.Clear();
        }
        public void Search()
        {

            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();

            SqlCommand cmd = new SqlCommand("Select * from Master_Radiology_Test where Name LIKE '" + txtSearchName.Text + "%'", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            RadiologyID = Convert.ToInt32(dt.Rows[0]["Radiology_ID"]);
            if (dt.Rows.Count > 0)
            {
                txtRadiologyName.DataBindings.Add("Text", dt, "Name");
                txtCharges.DataBindings.Add("Text", dt, "Charges");

                txtdate.DataBindings.Add("Text", dt, "UpdatedOn");
            }
        }
        public void RadiologyName()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand CMD = new SqlCommand("Select Name FROM Master_Radiology_Test WHERE Name=@Name", con);
            CMD.Parameters.AddWithValue("Name", txtRadiologyName.Text);
            SqlDataReader SQLreader1;

            SQLreader1 = CMD.ExecuteReader();
            if (SQLreader1.Read())
            {
                MessageBox.Show("The Radiology Test is already taken. Please Enter a different Radiology Test");
                //txtProcedureName.Focus();
                txtRadiologyName.Clear();
                con.Close();
            }
            else
            {
                con.Close();
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtSearchName.Text=="")
                {
                    

                        RadiologyName();
                    
                        SaveDetails();
                }
                else
                {
                    update();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }

        private void txtRadiologyName_MouseClick(object sender, MouseEventArgs e)
        {
            txtRadiologyName.Clear();
        }

        private void txtCharges_MouseClick(object sender, MouseEventArgs e)
        {
            txtCharges.Clear();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Master_Radiology_Load(object sender, EventArgs e)
        {

        }

        private void txtCharges_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please Enter Only Number");
            }
        }
    }
}
