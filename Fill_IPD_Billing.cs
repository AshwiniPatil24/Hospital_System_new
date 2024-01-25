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
    public partial class Fill_IPD_Billing : Form
    {
        int IPDID, PID;
        string Patient_ID, IPD_ID;
        int rows=0;
        int roomCharge = 0;
        int nursingCharge = 0;
        DateTime d;
        public int A;//IPDID
        int Pid;//PID
        public Fill_IPD_Billing()
        {
            InitializeComponent();
            this.Show();
            
        }

        public Fill_IPD_Billing(int PID, int ID)
        {
            InitializeComponent();
            A = ID;
            Pid = PID;
        }

        public void show()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"SELECT       Ruby_Jamner123.IPD_Registration.IPDID,Ruby_Jamner123.IPD_Registration.IPD_ID,Ruby_Jamner123.Patient_Registration.Patient_ID,Ruby_Jamner123.Patient_Registration.PID, Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Gender, Ruby_Jamner123.IPD_Registration.Patient_Id,Ruby_Jamner123.IPD_Registration.IPDID, Ruby_Jamner123.Patient_Registration.Patient_ID, 
                             Ruby_Jamner123.Patient_Registration.PID, Ruby_Jamner123.Patient_Registration.Mobile_Number, Ruby_Jamner123.Patient_Registration.Adhaar_ID
    FROM            Ruby_Jamner123.Patient_Registration INNER JOIN
                             Ruby_Jamner123.IPD_Registration ON Ruby_Jamner123.Patient_Registration.PID = @Patient_Id and ipdid = @ipdid", con);
            cmb.Parameters.AddWithValue("@Patient_Id", Pid);
            cmb.Parameters.AddWithValue("@ipdid", A);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                infogrid.DataSource = dt;
                IPDID = Convert.ToInt32(infogrid.Rows[0].Cells["IPDID"].Value);
                PID = Convert.ToInt32(infogrid.Rows[0].Cells["PID"].Value);
                Patient_ID = infogrid.Rows[0].Cells["Patient_ID"].Value.ToString();
                IPD_ID = infogrid.Rows[0].Cells["IPD_ID"].Value.ToString();
                infogrid.Columns["IPDID"].Visible = false;
                infogrid.Columns["IPD_ID"].Visible = false;
                infogrid.Columns["Patient_ID"].Visible = false;
                infogrid.Columns["PID"].Visible = false;
            }
            con.Close();
        }

        private void Fill_IPD_Billing_Load(object sender, EventArgs e)
        {
            show();
            regCharges_consltCharges();
            fn1();
            hospProcCharge();
            showSurgProcCharge();
            showMedicalRecordCharges();
            showAdminCharges();
            showBioMedWasteCharges();
            showConsultantVisitingCharges();
            showTotalBill();
            showPayableAmt();
            showBalanceAmt();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        public void clear()
        {
            infogrid.Rows.Clear();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }
        public void hospProcCharges()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Billing_IPDHosProc where IPDID = @amt", con);
            cmd.Parameters.AddWithValue("@amt", A);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                HospProcedureCharges.Text = sdr["IPDHosProcAmount"].ToString();
            }
            con.Close();
        }

        public void regCharges_consltCharges()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand("select Registration_Charges,Consultation_Charges from Patient_Registration where pid = @pid", con);
            cmd.Parameters.AddWithValue("@pid", A);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                registrationCharges.Text = sdr["Registration_Charges"].ToString();
                consultantCharges.Text = sdr["Consultation_Charges"].ToString();

            }
            sdr.Close();
            con.Close();
        }

        public void fn1()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select From_Date,To_Date,Charges,Nursing_Charge from ipd_assignedbeddetails where ipdid = @ipdid", con);
            cmd.Parameters.AddWithValue("@ipdid", A);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                DateTime from = Convert.ToDateTime(sdr[0]);
                DateTime? to = sdr.IsDBNull(1) ? DateTime.Now : Convert.ToDateTime(sdr[1]);
                int charge = Convert.ToInt32(sdr[2]);
                int nCharge = Convert.ToInt32(sdr[3]);
                if (to.HasValue)
                {
                    DateTime To = to.Value;
                    fn2(from, To, charge, nCharge);
                }
                rows++;
            }
            BedCharges.Text = roomCharge.ToString();
            NursingCharges.Text = nursingCharge.ToString();
            sdr.Close();
            con.Close();
        }

        public void fn2(DateTime from, DateTime to, int charge,int nCharge)
        {
            TimeSpan difference = to - from;
            int numberOfDays = (int)difference.TotalDays;
            if (numberOfDays <= 0)
            {
                numberOfDays = 1;
            }
            roomCharge = roomCharge + (charge * numberOfDays);
            nursingCharge = nursingCharge + (nCharge * numberOfDays);
        }

        public void hospProcCharge()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select * from Billing_IPDHosProc where IPDID = @id", con);
            cmd.Parameters.AddWithValue("@id", A);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                HospProcedureCharges.Text = rdr["IPDHosProcAmount"].ToString();
            }
            rdr.Close();
            con.Close();
        }

        public void showSurgProcCharge()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select totalamount from AssignIPDSurgicalProcedure where ipdid = @id", con);
            cmd.Parameters.AddWithValue("@id", A);
            SqlDataReader rdr = cmd.ExecuteReader();
            int surProcCharge = 0;
            while (rdr.Read())
            {
                surProcCharge = surProcCharge + Convert.ToInt32(rdr[0]);
            }
            surgProcedureCharges.Text = surProcCharge.ToString();
            rdr.Close();
            con.Close();
        }

        public void showMedicalRecordCharges()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select MedicalRecord_Charges from Master_IPDFixedCharges", con);
            medicalRecordCharges.Text = (cmd.ExecuteScalar()).ToString();
            con.Close();
        }

        public void showConsultantVisitingCharges()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select ConsultantVisiting_Charges from Master_IPDFixedCharges", con);
            consultantVisitingCharges.Text = (cmd.ExecuteScalar()).ToString();
            con.Close();
        }

        public void showBioMedWasteCharges()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select BioMedicalWaste_Charges from Master_IPDFixedCharges", con);
            bioMedicalWasteCharges.Text = (cmd.ExecuteScalar()).ToString();
            con.Close();
        }

        public void showAdminCharges()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select Administrative_Charges from Master_IPDFixedCharges", con);
            adminCharges.Text = (cmd.ExecuteScalar()).ToString();
            con.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SurgicalDetails sd = new SurgicalDetails(A, Pid);
            sd.Show();
        }

        public void showTotalBill()
        {
            totalBill.Text = (Convert.ToDecimal(registrationCharges.Text) + Convert.ToDecimal(consultantCharges.Text) + Convert.ToDecimal(NursingCharges.Text) + Convert.ToDecimal(BedCharges.Text) + Convert.ToDecimal(HospProcedureCharges.Text) + Convert.ToDecimal(surgProcedureCharges.Text) + Convert.ToDecimal(medicalRecordCharges.Text) + Convert.ToDecimal(bioMedicalWasteCharges.Text) + Convert.ToDecimal(consultantVisitingCharges.Text) + Convert.ToDecimal(adminCharges.Text)).ToString();

            billAmt.Text = totalBill.Text;
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // If not a digit, cancel the key press
                e.Handled = true;
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (discount.Text == "")
            {
                amtAfterDiscount.Text = (Convert.ToInt32(billAmt.Text) - 0).ToString();
                billAfterDiscount.Text = (Convert.ToInt32(billAmt.Text) - 0).ToString();
            }
            else
            {
                amtAfterDiscount.Text = (Convert.ToInt32(billAmt.Text) - Convert.ToInt32(discount.Text)).ToString();
                billAfterDiscount.Text = (Convert.ToInt32(billAmt.Text) - Convert.ToInt32(discount.Text)).ToString();
                showPayableAmt();
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // If not a digit, cancel the key press
                e.Handled = true;
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            showPayableAmt();
        }

        public void showPayableAmt()
        {
            if (billAfterDiscount.Text == "" && advance.Text == "")
            {
                payableAmount.Text = totalBill.Text;
            }
            else if (billAfterDiscount.Text == "")
            {
                payableAmount.Text = (Convert.ToInt32(totalBill.Text) - Convert.ToInt32(advance.Text)).ToString();
            }
            else if (advance.Text == "")
            {
                payableAmount.Text = (Convert.ToInt32(billAfterDiscount.Text)).ToString();
            }
            else
            {
                payableAmount.Text = (Convert.ToInt32(billAfterDiscount.Text) - Convert.ToInt32(advance.Text)).ToString();
            }
            showBalanceAmt();
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            showPayableAmt();
        }

        private void textBox10_MouseLeave(object sender, EventArgs e)
        {
            showPayableAmt();
        }

        public void showBalanceAmt()
        {
            if (paidAmount.Text == "")
            {
                balanceAmount.Text = payableAmount.Text;
            }
            else
            {
                balanceAmount.Text = (Convert.ToInt32(payableAmount.Text) - Convert.ToInt32(paidAmount.Text)).ToString();
            }
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // If not a digit, cancel the key press
                e.Handled = true;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void BedCharges_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void consultantVisitingCharges_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged_1(object sender, EventArgs e)
        {
            showBalanceAmt();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {


                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"insert into MainIPDBillingDetails(IPDID,IPDID_with_str,PID,PID_with_str,RegistrationCharges,ConsultantCharges,NursingCharges,BedCharges,HospitalProcCharges,SurgicalProcCharges,MedicalRecordCharges,BioMedicalWasteCharges,ConsultantVisitingCharges,AdministrativeCharges,TotalBillAmount,Discount,DiscountAuthorityName,AmountAfterDiscount,Advance,PayableAmount,PaidAmount,BalanceAmount,BillerName,PaymentMode,Remark,BillDate)
values (@IPDID,@IPD_ID,@PID,@P_ID,@regisCharges,@consltCharges,@nursingCharges,@bedCharges,@hospPcharge,@surgPcharge,@medicalRecordCharge,@bioMedWasteCharge,@consVisitingCharges,@adminCharges,@totalBillAmt,@disc,@discAuthName,@amtAfterDisc,@adv,@payableAmt,@paidAmt,@balAmt,@billerName,@paymntMode,@remark,@billDate)", con);
                cmd.Parameters.AddWithValue("@IPDID", IPDID);
                cmd.Parameters.AddWithValue("@IPD_ID", IPD_ID);
                cmd.Parameters.AddWithValue("@PID", PID);
                cmd.Parameters.AddWithValue("@P_ID", Patient_ID);
                cmd.Parameters.AddWithValue("@regisCharges", registrationCharges.Text);
                cmd.Parameters.AddWithValue("@consltCharges", consultantCharges.Text);
                cmd.Parameters.AddWithValue("@nursingCharges", NursingCharges.Text);
                cmd.Parameters.AddWithValue("@bedCharges", BedCharges.Text);
                cmd.Parameters.AddWithValue("@hospPcharge", HospProcedureCharges.Text);
                cmd.Parameters.AddWithValue("@surgPcharge", surgProcedureCharges.Text);
                cmd.Parameters.AddWithValue("@medicalRecordCharge", medicalRecordCharges.Text);
                cmd.Parameters.AddWithValue("@bioMedWasteCharge", bioMedicalWasteCharges.Text);
                cmd.Parameters.AddWithValue("@consVisitingCharges", consultantVisitingCharges.Text);
                cmd.Parameters.AddWithValue("@adminCharges", adminCharges.Text);
                cmd.Parameters.AddWithValue("@totalBillAmt", totalBill.Text);
                cmd.Parameters.AddWithValue("@disc", discount.Text);
                if (discount.Text != "" && discAuthorityName.Text == "")
                {
                    MessageBox.Show("Please enter Discount Authority Name...");
                    return;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@discAuthName", discAuthorityName.Text);
                }
                cmd.Parameters.AddWithValue("@amtAfterDisc", amtAfterDiscount.Text);
                cmd.Parameters.AddWithValue("@adv", advance.Text);
                cmd.Parameters.AddWithValue("@payableAmt", payableAmount.Text);
                cmd.Parameters.AddWithValue("@paidAmt", paidAmount.Text);
                cmd.Parameters.AddWithValue("@balAmt", balanceAmount.Text);
                if (billerName.Text == "")
                {
                    MessageBox.Show("Please enter Biller Name...");
                    return;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@billerName", billerName.Text);
                }
                if (paymentMode.Text == "")
                {
                    MessageBox.Show("Please select Payment Mode...");
                    return;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@paymntMode", paymentMode.Text);
                }
                cmd.Parameters.AddWithValue("@remark", remark.Text);
                cmd.Parameters.AddWithValue("@billDate", billDate.Value.ToString("dd-MM-yyyy HH:mm:ss"));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Billing Details Added Successfully...");
                con.Close();
                save.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
