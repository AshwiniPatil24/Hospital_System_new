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
    public partial class MLC_Details : Form
    {
        public MLC_Details()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"Insert Into MLC_Details (Patient_IPD_id,Time,Location,N_Broughted_Person,
                    Name_Opposite_Patry,Nearst_Landmark,Health_Condition,Nearst_Police_Station,Other_Details,Date) 
                Values(@Patient_IPD_id,@Time,@Location,@N_Broughted_Person,@Name_Opposite_Patry,@Nearst_Landmark,@Health_Condition, 
               @Nearst_Police_Station,@Other_Details,@Date)", con);
                cmd.Parameters.AddWithValue("@Patient_IPD_id","RSHJ0001");
                cmd.Parameters.AddWithValue("@Time", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@Location", txtLocation.Text);
                cmd.Parameters.AddWithValue("@N_Broughted_Person", txtName.Text);
                cmd.Parameters.AddWithValue("@Name_Opposite_Patry", txtname_Opposite.Text);
                cmd.Parameters.AddWithValue("@Nearst_Landmark", txtLandmark.Text);
                cmd.Parameters.AddWithValue("@Health_Condition", txtHealthCondition.Text);
                cmd.Parameters.AddWithValue("@Nearst_Police_Station", txtPolice_station.Text);
                cmd.Parameters.AddWithValue("@Other_Details", txtOtherDetails.Text);
                cmd.Parameters.AddWithValue("@Date", System.DateTime.Now);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Added Successfully");
                //cmd.Parameters.AddWithValue("@Reserred_By", cmbReferredBy.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void MLC_Details_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtLocation_MouseClick(object sender, MouseEventArgs e)
        {
            txtLocation.Clear();
        }

        private void txtName_MouseClick(object sender, MouseEventArgs e)
        {
            txtName.Clear();
        }

        private void txtname_Opposite_MouseClick(object sender, MouseEventArgs e)
        {
            txtname_Opposite.Clear();
        }

        private void txtLandmark_MouseClick(object sender, MouseEventArgs e)
        {
            txtLandmark.Clear();
        }

        private void txtHealthCondition_MouseClick(object sender, MouseEventArgs e)
        {
            txtHealthCondition.Clear();
        }

        private void txtPolice_station_MouseClick(object sender, MouseEventArgs e)
        {
            txtPolice_station.Clear();
        }

        private void txtOtherDetails_MouseClick(object sender, MouseEventArgs e)
        {
            txtOtherDetails.Clear();
        }
    }
}
