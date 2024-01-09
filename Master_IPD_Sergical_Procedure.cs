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
    public partial class Master_IPD_Sergical_Procedure : Form
    {
        public decimal A=0;     //Surgeon
        public decimal B=0;     //otcharges
        public decimal C=0;     //txtboylesMachine
        public decimal D=0;     //txtSevoFluence
        public decimal E=0;     //txtOtAssistant
        public decimal F=0;     //txtOtInstruments
        public decimal G=0;     //txtOutsiedOTWithoutAnesthesia

        public decimal H=0;
        public Master_IPD_Sergical_Procedure()
        {
            InitializeComponent();
        }

        private void Master_IPD_Sergical_Procedure_Load(object sender, EventArgs e)
        {
            show();
        }
        public void show()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"select * From Master_IPDSurgicalProcType", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if(dt.Rows.Count>0)
            {
                comType.DataSource = dt;
                comType.DisplayMember = "SurgicalTypeName";
                comType.ValueMember = "ID";
            }
        }
        public void save()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"INSERT into Master_IPDSurgicalProcedure(ProcedureTypeID,Name,Duration,Details,SurgeonCharges,OperationTheatreCharges,BoylesMachineCharges,SevoFlurenceCharges,OTAssistantCharges,OTInstrumentsCharges,OutsideOTWithoutAnesthesia,TotalCharges,SurgicalAdmin,Createdby)
values          (@ProcedureTypeID,@Name,@Duration,@Details,@SurgeonCharges,@OperationTheatreCharges,@BoylesMachineCharges,@SevoFlurenceCharges,@OTAssistantCharges,@OTInstrumentsCharges,@OutsideOTWithoutAnesthesia,@TotalCharges,@SurgicalAdmin,@Createdby)", con);
            cmb.Parameters.AddWithValue("@ProcedureTypeID",comType.SelectedIndex);
            cmb.Parameters.AddWithValue("@Name",txtname.Text);
            cmb.Parameters.AddWithValue("@Duration",txtduration.Text);
            cmb.Parameters.AddWithValue("@Details",txtDetails.Text);
            cmb.Parameters.AddWithValue("@SurgeonCharges",txtsurgeon.Text);
            cmb.Parameters.AddWithValue("@OperationTheatreCharges",txtotcharges.Text);
            cmb.Parameters.AddWithValue("@BoylesMachineCharges",txtboylesMachine.Text);
            cmb.Parameters.AddWithValue("@SevoFlurenceCharges",txtSevoFluence.Text);
            cmb.Parameters.AddWithValue("@OTAssistantCharges",txtOtAssistant.Text);
            cmb.Parameters.AddWithValue("@OTInstrumentsCharges",txtOtInstruments.Text);
            cmb.Parameters.AddWithValue("@OutsideOTWithoutAnesthesia",txtOutsiedOTWithoutAnesthesia.Text);
            cmb.Parameters.AddWithValue("@TotalCharges",txtTotal.Text);
            cmb.Parameters.AddWithValue("@SurgicalAdmin",txtSurgicalAdmin.Text);
            cmb.Parameters.AddWithValue("@Createdby",txtdate.Text);
            cmb.ExecuteNonQuery();
            MessageBox.Show("inserted successfully.....!");
            con.Close();
        }
        public void update()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"INSERT into Master_IPDSurgicalProcedure set (ProcedureTypeID=@ProcedureTypeID,Name=@Name,Duration=@Duration,Details=@Details,SurgeonCharges=@SurgeonCharges,OperationTheatreCharges=@OperationTheatreCharges,BoylesMachineCharges=@BoylesMachineCharges,SevoFlurenceCharges=@SevoFlurenceCharges,OTAssistantCharges=@OTAssistantCharges,OTInstrumentsCharges=@OTInstrumentsCharges,OutsideOTWithoutAnesthesia=@OutsideOTWithoutAnesthesia,TotalCharges=@TotalCharges,SurgicalAdmin=@SurgicalAdmin,Createdby=@Createdby)
WHERE        (Name=@Name)", con);
            cmb.Parameters.AddWithValue("@ProcedureTypeID", comType.SelectedIndex);
            cmb.Parameters.AddWithValue("@Name", txtname.Text);
            cmb.Parameters.AddWithValue("@Duration", txtduration.Text);
            cmb.Parameters.AddWithValue("@Details", txtDetails.Text);
            cmb.Parameters.AddWithValue("@SurgeonCharges", txtsurgeon.Text);
            cmb.Parameters.AddWithValue("@OperationTheatreCharges", txtotcharges.Text);
            cmb.Parameters.AddWithValue("@BoylesMachineCharges", txtboylesMachine.Text);
            cmb.Parameters.AddWithValue("@SevoFlurenceCharges", txtSevoFluence.Text);
            cmb.Parameters.AddWithValue("@OTAssistantCharges", txtOtAssistant.Text);
            cmb.Parameters.AddWithValue("@OTInstrumentsCharges", txtOtInstruments.Text);
            cmb.Parameters.AddWithValue("@OutsideOTWithoutAnesthesia", txtOutsiedOTWithoutAnesthesia.Text);
            cmb.Parameters.AddWithValue("@TotalCharges", txtTotal.Text);
            cmb.Parameters.AddWithValue("@SurgicalAdmin", txtSurgicalAdmin.Text);
            cmb.Parameters.AddWithValue("@Createdby", txtdate.Text);
            cmb.ExecuteNonQuery();
            MessageBox.Show("Updated successfully.....!");
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text=="")
            {
                save();
            }
            else
            {
                update();
            }
        }
        public void sum()
        {
            if(txtsurgeon.Text=="")
            {
                txtsurgeon.Text = "0";
            }
            if (txtotcharges.Text == "")
            {
                txtotcharges.Text = "0";
            }
            if (txtboylesMachine.Text == "")
            {
                txtboylesMachine.Text = "0";
            }
            if (txtSevoFluence.Text == "")
            {
                txtSevoFluence.Text = "0";
            }
            if (txtOtAssistant.Text == "")
            {
                txtOtAssistant.Text = "0";
            }
            if (txtOtInstruments.Text == "")
            {
                txtOtInstruments.Text = "0";
            }
            if (txtOutsiedOTWithoutAnesthesia.Text == "")
            {
                txtOutsiedOTWithoutAnesthesia.Text = "0";
            }
            A = Convert.ToDecimal(txtsurgeon.Text);
            B = Convert.ToDecimal(txtotcharges.Text);
            C = Convert.ToDecimal(txtboylesMachine.Text);
            D = Convert.ToDecimal(txtSevoFluence.Text);
            E = Convert.ToDecimal(txtOtAssistant.Text);
            F = Convert.ToDecimal(txtOtInstruments.Text);
            G = Convert.ToDecimal(txtOutsiedOTWithoutAnesthesia.Text);

            H = A + B + C + D + E + F + G;
            txtTotal.Text = H.ToString();
        }

        private void txtsurgeon_TextChanged(object sender, EventArgs e)
        {
            if(txtsurgeon.Text!="")
            {
                sum();
            }
            else
            {
                txtsurgeon.Text = "0";
                sum();
            }
            
        }

        private void txtotcharges_TextChanged(object sender, EventArgs e)
        {
            if (txtotcharges.Text != "")
            {
                sum();
            }
            else
            {
                txtotcharges.Text = "0";
                sum();
            }
        }

        private void txtboylesMachine_TextChanged(object sender, EventArgs e)
        {
            sum();
        }

        private void txtSevoFluence_TextChanged(object sender, EventArgs e)
        {
            sum();
        }

        private void txtOtAssistant_TextChanged(object sender, EventArgs e)
        {
            sum();
        }

        private void txtOtInstruments_TextChanged(object sender, EventArgs e)
        {
            sum();
        }

        private void txtOutsiedOTWithoutAnesthesia_TextChanged(object sender, EventArgs e)
        {
            sum();
        }

        private void txtsurgeon_MouseClick(object sender, MouseEventArgs e)
        {
            //txtsurgeon.Clear();
        }
    }
}
