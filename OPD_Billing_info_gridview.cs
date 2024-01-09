using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruby_Hospital
{
    public partial class OPD_Billing_info_gridview : Form
    {
        public OPD_Billing_info_gridview()
        {
            InitializeComponent();
        }

        private void OPD_Billing_info_gridview_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            OPD_Billing_Details o = new OPD_Billing_Details();
            o.ShowDialog();
        }
    }
}
