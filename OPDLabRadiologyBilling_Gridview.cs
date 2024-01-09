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
    public partial class OPDLabRadiologyBilling_Gridview : Form
    {
        public OPDLabRadiologyBilling_Gridview()
        {
            InitializeComponent();
        }

        private void OPDLabRadiologyBilling_Gridview_Load(object sender, EventArgs e)
        {
            show();
        }
        public void show()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"SELECT        Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Billing_OPDTotalALabTest.TotalLabAmount, Ruby_Jamner123.OPD_Patient_Registration.Treatement
FROM            Ruby_Jamner123.OPD_Patient_Registration INNER JOIN
                         Ruby_Jamner123.Billing_OPDTotalALabTest ON Ruby_Jamner123.OPD_Patient_Registration.PatientOPDId = Ruby_Jamner123.Billing_OPDTotalALabTest.OPDID INNER JOIN
                         Ruby_Jamner123.Patient_Registration ON Ruby_Jamner123.OPD_Patient_Registration.PatientId = Ruby_Jamner123.Patient_Registration.PID", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable o = new DataTable();
            adt.Fill(o);
            if (o.Rows.Count > 0)
            {
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                dataGridView1.DataSource = o;

            }
        }
    }
}
