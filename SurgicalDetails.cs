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
    public partial class SurgicalDetails : Form
    {
        int charge = 0;
        int pid;
        int IPD_ID;
        SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");

        public SurgicalDetails()
        {
            InitializeComponent();
        }
        public SurgicalDetails(int id, int pid)
        {
            InitializeComponent();
            IPD_ID = id;
            this.pid = pid;
            show();
            billingDetails();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void show()
        {
            con.Open();
            SqlCommand cmb = new SqlCommand(@"SELECT       Ruby_Jamner123.IPD_Registration.IPD_Id, Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Gender,  
                         Ruby_Jamner123.Patient_Registration.Mobile_Number, Ruby_Jamner123.Patient_Registration.Adhaar_ID
FROM            Ruby_Jamner123.Patient_Registration INNER JOIN
                         Ruby_Jamner123.IPD_Registration ON Ruby_Jamner123.Patient_Registration.PID = Ruby_Jamner123.IPD_Registration.Patient_Id
WHERE        (Ruby_Jamner123.IPD_Registration.Patient_Id = @Patient_Id)", con);
            cmb.Parameters.AddWithValue("@Patient_Id", pid);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
            con.Close();
        }

        public void billingDetails()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select ID,Surgical_Category,Surgery_Name,SurgeonCharges,SevoFlurenceCharges,OTCharges,OTAssistant,OutsideOTWithoutAnesthesia,OTInstruments,BoylesMachineCharges,AnesthetistCharges,OtherCharges from AssignIPDSurgicalProcedure where ipdid = @Iid", con);
            cmd.Parameters.AddWithValue("@Iid", IPD_ID);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dtPublic = new DataTable();
            adt.Fill(dtPublic);
            if (dtPublic.Rows.Count > 0)
            {
                dataGridView2.DataSource = dtPublic;
            }
            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SurgicalDetails_Load(object sender, EventArgs e)
        {
            dataGridView1.Show();
            dataGridView2.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            string colName = this.dataGridView2.Columns[e.ColumnIndex].Name;
            if (colName.Equals("Update") == true)
            {
                int id = Convert.ToInt32(dataGridView2.CurrentRow.Cells["ID"].Value);
                int totalCharges = Convert.ToInt32(dataGridView2.CurrentRow.Cells["SurgeonCharges"].Value) + Convert.ToInt32(dataGridView2.CurrentRow.Cells["SevoFlurenceCharges"].Value) + Convert.ToInt32(dataGridView2.CurrentRow.Cells["OTCharges"].Value) + Convert.ToInt32(dataGridView2.CurrentRow.Cells["OTAssistant"].Value) + Convert.ToInt32(dataGridView2.CurrentRow.Cells["OutsideOTWithoutAnesthesia"].Value) + Convert.ToInt32(dataGridView2.CurrentRow.Cells["OTInstruments"].Value) + Convert.ToInt32(dataGridView2.CurrentRow.Cells["BoylesMachineCharges"].Value) + Convert.ToInt32(dataGridView2.CurrentRow.Cells["AnesthetistCharges"].Value) + Convert.ToInt32(dataGridView2.CurrentRow.Cells["OtherCharges"].Value);
                con.Open();
                SqlCommand cmd = new SqlCommand(@"update  AssignIPDSurgicalProcedure set SurgeonCharges = " + Convert.ToDecimal(dataGridView2.CurrentRow.Cells["SurgeonCharges"].Value) + ",SevoFlurenceCharges=" + Convert.ToDecimal(dataGridView2.CurrentRow.Cells["SevoFlurenceCharges"].Value) + ",OTCharges=" + Convert.ToDecimal(dataGridView2.CurrentRow.Cells["OTCharges"].Value) + ",OTAssistant=" + Convert.ToDecimal(dataGridView2.CurrentRow.Cells["OTAssistant"].Value) + ",OutsideOTWithoutAnesthesia=" + Convert.ToDecimal(dataGridView2.CurrentRow.Cells["OutsideOTWithoutAnesthesia"].Value) + ",OTInstruments=" + Convert.ToDecimal(dataGridView2.CurrentRow.Cells["OTInstruments"].Value) + ",BoylesMachineCharges=" + Convert.ToDecimal(dataGridView2.CurrentRow.Cells["BoylesMachineCharges"].Value) + ",AnesthetistCharges=" + Convert.ToDecimal(dataGridView2.CurrentRow.Cells["AnesthetistCharges"].Value) + ",OtherCharges=" + Convert.ToDecimal(dataGridView2.CurrentRow.Cells["OtherCharges"].Value) + ",TotalAmount = " + Convert.ToDecimal(totalCharges) + " where ID = " + id, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Updated successfully!!!");
                charge = totalCharges;
                billingDetails();
            }
        }
    }
}
