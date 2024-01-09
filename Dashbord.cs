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
    public partial class Dashbord : Form
    {
        public Dashbord()
        {
            InitializeComponent();
            constomizedesing();

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

        }

        private void movepanel(Control btn)
        {
            //panel_slide.Width = btn.Width;
            //panel_slide.Left = btn.Left;
        }
        private void Dashbord_Load(object sender, EventArgs e)
        {
            
            
            Panel_admin_master_.Visible = false;
            panel_admin_misReport.Visible = false;
            //int w = Screen.PrimaryScreen.Bounds.Width;
            //int h = Screen.PrimaryScreen.Bounds.Height;
            //this.Location = new Point(0, 0);
            //this.Size = new Size(w, h);
            panel_Regi_down.Visible = false;
            panel_OPD_down.Visible = false;
            panel_IPD_down.Visible = false;
            panel_bill_down.Visible = false;
            panel_admin_down.Visible = false;
            panel4.Visible = false;



        }
        private void constomizedesing()
            {
            
            }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Click(object sender, EventArgs e)
        {
            //   panel_admin_misreprt.Visible = false;
        }

        private void Registration_Click(object sender, EventArgs e)
        {
            movepanel(Registration);
            panel_OPD_down.Visible = false;
            panel_IPD_down.Visible = false;
            panel_bill_down.Visible = false;
            panel_admin_down.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;

            //   panel_admin_misreprt.Visible = false;
        }

        private void OPD_Click(object sender, EventArgs e)
        {
            movepanel(OPD);
            panel_Regi_down.Visible = false;
            panel_OPD_down.Visible = true;
            panel_IPD_down.Visible = false;
            panel_admin_down.Visible = false;
            //panel4.Visible = false;
            panel_bill_down.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;

            //  panel_admin_misreprt.Visible = false;
        }

        private void IPD_Click(object sender, EventArgs e)
        {
            movepanel(IPD);
            panel_Regi_down.Visible = false;
            panel_OPD_down.Visible = false;
            panel_IPD_down.Visible = true;
            panel_bill_down.Visible = false;
            panel_admin_down.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
            //   panel_admin_misreprt.Visible = false;
        }

        private void Bill_Click(object sender, EventArgs e)
        {
            movepanel(Bill);
            panel_Regi_down.Visible = false;
            panel_OPD_down.Visible = false;
            panel_IPD_down.Visible = false;
            panel_bill_down.Visible = true;
            panel_admin_down.Visible = false;
            Panel_admin_master_.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
        }

        private void Admin_Click(object sender, EventArgs e)
        {
            movepanel(Admin);
            panel_Regi_down.Visible = false;
            panel_OPD_down.Visible = false;
            panel_IPD_down.Visible = false;
            panel_bill_down.Visible = false;
            panel4.Visible = false;
            panel_admin_down.Visible = true;
            panel3.Visible = false;
            panel5.Visible = false;
        }

        private void Help_Click(object sender, EventArgs e)
        {
            movepanel(Help);
            panel_OPD_down.Visible = false;
            panel_Regi_down.Visible = false;
            panel_IPD_down.Visible = false;
            panel_bill_down.Visible = false;
            panel_admin_down.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Registration_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Regi_down.Visible = true;
           
        }

        private void OPD_MouseClick(object sender, MouseEventArgs e)
        {
            panel_OPD_down.Visible = true;
            panel4.Visible = false; 
        }

        private void IPD_MouseClick(object sender, MouseEventArgs e)
        {
            panel_IPD_down.Visible = true;
            panel4.Visible = false;

        }

        private void button13_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
        }

        private void Bill_MouseClick(object sender, MouseEventArgs e)
        {
            panel_bill_down.Visible = true;
            panel4.Visible = false;

        }

        private void Admin_MouseClick(object sender, MouseEventArgs e)
        {
            panel_admin_down.Visible = true;

            panel4.Visible = false;
        }

        

        private void btnreport_Click(object sender, EventArgs e)
        {
            panel_admin_misReport.Visible = true;
            panel4.Visible = false;

        }

        private void btnempmanagement_Click(object sender, EventArgs e)
        {
            // panel_admin_misreprt.Visible = false;
            panel4.Visible = false;
            Panel_admin_master_.Visible = false;
        }

        private void btnapproval_Click(object sender, EventArgs e)
        {
            /// panel_admin_misreprt.Visible = false;
            
            Panel_admin_master_.Visible = false;
            panel4.Visible = false;
        }

        private void btnreport_MouseClick(object sender, MouseEventArgs e)
        {
            panel4.Visible = false;
            panel_admin_misReport.Visible = true;
            panel_bill_down.Visible = false;
           
        }

      

        private void Btnmaster_Click(object sender, EventArgs e)
        {
            Panel_admin_master_.Visible = true;
            panel_admin_misReport.Visible = false;
            panel4.Visible = false;
        }

        private void Btnmaster_MouseClick(object sender, MouseEventArgs e)
        {
            Panel_admin_master_.Visible = true;
            panel_admin_misReport.Visible = false;
            panel4.Visible = false;
        }

        private void btnipdadmin_Click(object sender, EventArgs e)
        {

        }

        

        private void btnopdd_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_regi_slid_Click(object sender, EventArgs e)
        {
            Patient_Registration o = new Patient_Registration();
            o.ShowDialog();
        }

        private void btnopdlist_Click(object sender, EventArgs e)
        {

        }

        private void btndaliyprocdure_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            IPD_Daily_Procedure_grid o = new IPD_Daily_Procedure_grid();
            o.ShowDialog();
        }

        private void btnopdregistration_Click(object sender, EventArgs e)
        {
            OPD_Consultaion_gridview o = new OPD_Consultaion_gridview();
            o.ShowDialog();
        }

        private void btn_opdpatinetlist_slid_Click(object sender, EventArgs e)
        {
            OPD_List o = new OPD_List();
            o.ShowDialog();
        }

        private void btnoldopdrecepites_Click(object sender, EventArgs e)
        {
            if(panel4.Visible==false)
            {
                panel4.Visible = true;
            }
            else
            {
                panel4.Visible = false;
            }

        }

        private void btnoldipdreport_Click(object sender, EventArgs e)
        {
            if (panel3.Visible == false)
            {
                panel3.Visible = true;
            }
            else
            {
                panel3.Visible = false;
            }

        }

        private void btn_ipdECGandraddiology_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
        }

        private void btnipdlabbill_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            Lab_And_Radiology_Billing o = new Lab_And_Radiology_Billing();
            o.ShowDialog();
        }

        private void btnipd_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            IPD_Billng_Gridview o = new IPD_Billng_Gridview();
            o.ShowDialog();
        }

        private void btnopd_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            OPD_Billing_List o = new OPD_Billing_List();
            o.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (panel5.Visible == false)
            {
                panel5.Visible = true;
            }
            else
            {
                panel5.Visible = false;
            }
        }

        private void btndischargesummary_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //movepanel(Dashboard);
            panel_Regi_down.Visible = false;
            panel_OPD_down.Visible = false;
            panel_IPD_down.Visible = false;
            panel_bill_down.Visible = false;
            panel4.Visible = false;
            panel_admin_down.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;

        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
           // pictureBox1.BackColor=""
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
           // pictureBox2.BackColor = "Transparent";
        }

        private void btnpending_MouseHover(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void BtnDrug_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_ipdregi_slid_Click(object sender, EventArgs e)
        {
            Transfer t = new Transfer();
                t.ShowDialog();
        }
    }
}
