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
    public partial class IPD_Daily_Procedure_grid : Form
    {
       public int IPDI;
        public IPD_Daily_Procedure_grid()
        {
            InitializeComponent();
        }

        private void IPD_Daily_Procedure_Load(object sender, EventArgs e)
        {        
            show();
        }
        public void show()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"SELECT Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Age, Ruby_Jamner123.Patient_Registration.Mobile_Number, Ruby_Jamner123.Patient_Registration.Adhaar_ID, Ruby_Jamner123.IPD_Registration.Patient_Id,
                         Ruby_Jamner123.Patient_Registration.Doctors_Name
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

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    //int a = Convert.ToInt32(dataGridView1..Rows[else.RowIndex].Cells["a"].FormattedValue.Tostring());

           
        //}

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            string columnName = this.dataGridView1.Columns[e.ColumnIndex].Name;

            if (columnName.Equals("Name") == true)
            {
                try
                {
                    IPDI = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Patient_Id"].Value);
                    IPD_Daily_Procedure_main o = new IPD_Daily_Procedure_main(IPDI);
                    o.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void panel_head_Paint(object sender, PaintEventArgs e)
        {

        }
        // int a = datagei


    }
}

