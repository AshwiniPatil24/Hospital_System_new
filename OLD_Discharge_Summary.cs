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
    public partial class OLD_Discharge_Summary : Form
    {
        public OLD_Discharge_Summary()
        {
            InitializeComponent();
        }

        private void IPD_Discharge_Summary_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
