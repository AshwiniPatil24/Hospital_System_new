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
    public partial class SelectOnlyTest : Form
    {
        public int OpdTestID;
        public SelectOnlyTest()
        {
            InitializeComponent();
        }
        public SelectOnlyTest(int opdID)
        {
            InitializeComponent();
            OpdTestID = opdID;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OnlyTextRadiologyTest o = new OnlyTextRadiologyTest(OpdTestID);
            o.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OnlyTestLabTest o = new OnlyTestLabTest(OpdTestID);
            o.Show();
        }

        private void ttmOPDLab_Click(object sender, EventArgs e)
        {

        }

        private void ttmIPDLab_Click(object sender, EventArgs e)
        {

        }
    }
}
