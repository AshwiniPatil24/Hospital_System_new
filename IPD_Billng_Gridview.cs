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
    public partial class IPD_Billng_Gridview : Form
    {
        public int PID;
        public int ID;
        public IPD_Billng_Gridview()
        {
            InitializeComponent();
        }

        private void IPD_Billng_Gridview_Load(object sender, EventArgs e)
        {
            show();
        }
        public void show()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"SELECT        Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Gender, Ruby_Jamner123.IPD_Registration.Patient_Id AS Expr1, Ruby_Jamner123.Patient_Registration.Patient_ID, 
                         Ruby_Jamner123.Patient_Registration.PID,Ruby_Jamner123.IPD_Registration.IPDID, Ruby_Jamner123.Patient_Registration.Mobile_Number, Ruby_Jamner123.Patient_Registration.Adhaar_ID
FROM            Ruby_Jamner123.Patient_Registration INNER JOIN
                         Ruby_Jamner123.IPD_Registration ON Ruby_Jamner123.Patient_Registration.PID = Ruby_Jamner123.IPD_Registration.Patient_Id", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable o = new DataTable();
            adt.Fill(o);
            if (o.Rows.Count > 0)
            {
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                dataGridView1.DataSource = o;

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            string columnName = this.dataGridView1.Columns[e.ColumnIndex].Name;
            if (columnName.Equals("Name") == true)
            {
                try
                {
                    PID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PID"].Value);
                    ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IPDID"].Value);
                    Fill_IPD_Billing o = new Fill_IPD_Billing(PID, ID);
                    o.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
