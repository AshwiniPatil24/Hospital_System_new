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
    public partial class Master_Procedures : Form
    {
        public Master_Procedures()
        {
            InitializeComponent();
        }

        private void Master_Procedures_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text == "")
            {
                save();
            }
            else
            {

                update();
            }
        }
        public void save()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"INSERT into Master_IPDHospitalProcedure (ProcedureType,ProcedureName,ProcedureDetails,ProcedureCharge,HospCharge,Createdby)
values      (@ProcedureType,@ProcedureName,@ProcedureDetails,@ProcedureCharge,@HospCharge,@Createdby)", con);
            cmb.Parameters.AddWithValue("@ProcedureType", txttype.SelectedIndex);
            cmb.Parameters.AddWithValue("@ProcedureName", txtname.Text);
            cmb.Parameters.AddWithValue("@ProcedureDetails", txtdetails.Text);
            cmb.Parameters.AddWithValue("@ProcedureCharge", txtprocedure.Text);
            cmb.Parameters.AddWithValue("@HospCharge", txthospcharge.Text);
            cmb.Parameters.AddWithValue("@Createdby", txtdate.Text);
            cmb.ExecuteNonQuery();
            MessageBox.Show("inserted successfully.....!");
            con.Close();
        }
        public void update()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Update Master_IPDHospitalProcedure set (ProcedureType=@ProcedureType,ProcedureName=@ProcedureName,ProcedureDetails=@ProcedureDetails,ProcedureCharge=@ProcedureCharge,HospCharge=@HospCharge,Createdby=@Createdby)
WHERE  (ProcedureName=@ProcedureName)", con);
            cmb.Parameters.AddWithValue("@ProcedureType", txttype.SelectedIndex);
            cmb.Parameters.AddWithValue("@ProcedureName", txtsearch.Text);
            cmb.Parameters.AddWithValue("@ProcedureDetails", txtdetails.Text);
            cmb.Parameters.AddWithValue("@ProcedureCharge", txtprocedure.Text);
            cmb.Parameters.AddWithValue("@HospCharge", txthospcharge.Text);
            cmb.Parameters.AddWithValue("@Createdby", txtdate.Text);
            cmb.ExecuteNonQuery();
            MessageBox.Show("inserted successfully.....!");
            con.Close();
        }
    }
}
