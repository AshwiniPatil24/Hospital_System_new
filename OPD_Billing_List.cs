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
    public partial class OPD_Billing_List : Form
    {
        public int ID;
        public OPD_Billing_List()
        {
            InitializeComponent();
        }

        private void OPD_Billing_List_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"SELECT        Ruby_Jamner123.OPD_Patient_Registration.PatientOPDId,Ruby_Jamner123.OPD_Patient_Registration.PatientOPDIdWithSr, Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Mobile_Number, Ruby_Jamner123.Patient_Registration.Purpose, 
                         Ruby_Jamner123.Billing_OPDProcedure.OPDProcedureAmount, Ruby_Jamner123.Billing_OPDTotalALabTest.TotalLabAmount, Ruby_Jamner123.Billing_OPDRadiologyTAmount.OPDRadiologyAmount
FROM            Ruby_Jamner123.OPD_Patient_Registration INNER JOIN
                         Ruby_Jamner123.Patient_Registration ON Ruby_Jamner123.OPD_Patient_Registration.PatientId = Ruby_Jamner123.Patient_Registration.PID INNER JOIN
                         Ruby_Jamner123.Billing_OPDTotalALabTest ON Ruby_Jamner123.OPD_Patient_Registration.PatientOPDId = Ruby_Jamner123.Billing_OPDTotalALabTest.OPDID INNER JOIN
                         Ruby_Jamner123.Billing_OPDProcedure ON Ruby_Jamner123.OPD_Patient_Registration.PatientOPDId = Ruby_Jamner123.Billing_OPDProcedure.OPDID INNER JOIN
                         Ruby_Jamner123.Billing_OPDRadiologyTAmount ON Ruby_Jamner123.OPD_Patient_Registration.PatientOPDId = Ruby_Jamner123.Billing_OPDRadiologyTAmount.OPDID", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable o = new DataTable();
            adt.Fill(o);
            if (o.Rows.Count > 0)
            {
                OPDdatagridview.ColumnHeadersDefaultCellStyle.Font = new Font(OPDdatagridview.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                OPDdatagridview.DataSource = o;
                OPDdatagridview.Columns["PatientOPDId"].Visible = false;
                OPDdatagridview.Columns["PatientOPDIdWithSr"].HeaderText = "Patient OPD ID";



            }
        }

        private void OPDdatagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {           
          
            try
            {
                ID = Convert.ToInt32(OPDdatagridview.CurrentRow.Cells["PatientOPDId"].Value);
                OPD_Billing_Details o = new OPD_Billing_Details(ID);
                o.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void OPDdatagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
