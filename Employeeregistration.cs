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
    public partial class Employeeregistration : Form
    {
        public Employeeregistration()
        {
            InitializeComponent();
        }

       

       

        private void Employee_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
            show();
            Department();
            Designation();
            panel1.Visible = false;
        }
        public void Department()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * From Department", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtDepartment.DataSource = dt;
                txtDepartment.DisplayMember = "Department";
                txtDepartment.ValueMember = "ID";
            }

        }
        public void Designation()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * From Designation where (DepartmentID=@DepartmentID) ", con);
            cmb.Parameters.AddWithValue("@DepartmentID", txtDepartment.SelectedIndex);
            cmb.ExecuteNonQuery();
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtDesignation.DataSource = dt;
                txtDesignation.DisplayMember = "Designation";
                txtDesignation.ValueMember = "ID";
            }
        }
        private void radiocontractor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtcontractor.Checked == true)
            {
                Login_Form lm = new Login_Form();
                 lm.Show();
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            show();
            if (txtDesignation.Text == "Doctor")
            {
                doctors();
                savedata();        
            }
            else
            {
                savedata();
            }
        }
        public void savedata()
        {
            try
            { 
                  SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                  con.Open();


                  SqlCommand cmb = new SqlCommand(@"INSERT INTO Employee_registration (Employee_of,MR_M,Name,Gender,Current_Address,Permanent_Address,Mobile_Number,MaritalStatus,Experience,Alternate_Mobile_number,Date_Of_Birth,Department,Designation,Joining_Date,Probation,Status,Remark)
                                    Values (@Employee_of,@MR_M,@Name,@Gender,@Current_Address,@Permanent_Address,@Mobile_Number,@MaritalStatus,@Experience,@Alternate_Mobile_number,@Date_Of_Birth,@Department,@Designation,@Joining_Date,@Probation,@Status,@Remark)", con);
                  if (rbtrubystarhospital.Checked == true)

                  {
                     cmb.Parameters.AddWithValue("@Employee_of", "Ruby Star Hospital");
                  }
                  else
                  {
                       cmb.Parameters.AddWithValue("@Employee_of", "Contractor");
                  }
                  cmb.Parameters.AddWithValue("@MR_M", txtmr.Text);
                  cmb.Parameters.AddWithValue("@Name", txtname.Text);
                  cmb.Parameters.AddWithValue("@Gender", txtgender.Text);
                  cmb.Parameters.AddWithValue("@Current_Address", txtcurrentAddress.Text);

                 // cmb.Parameters.AddWithValue("@Post", txtpost.Text);

                //  cmb.Parameters.AddWithValue("@Nearest_Landmark", txtpost.Text);

                  cmb.Parameters.AddWithValue("@Permanent_Address", txtPermanentAddress.Text);
                  cmb.Parameters.AddWithValue("@Mobile_Number", txtMobileNumber.Text);
                  cmb.Parameters.AddWithValue("@MaritalStatus", txtMaritalStatus.Text);
                  cmb.Parameters.AddWithValue("@Experience", txtExperience.Text);
                  cmb.Parameters.AddWithValue("@Alternate_Mobile_number", txtAlternateNumber.Text);
                  cmb.Parameters.AddWithValue("@Date_Of_Birth", txtDateOfBirth.Text);
                  cmb.Parameters.AddWithValue("@Department", txtDepartment.Text);
                  cmb.Parameters.AddWithValue("@Designation", txtDesignation.Text);
                  cmb.Parameters.AddWithValue("@Joining_Date", txtJoinDate.Text);
                  cmb.Parameters.AddWithValue("@Probation", txtprobationDate.Text);
                  if (checkStatus.Enabled == true)
                  {
                     cmb.Parameters.AddWithValue("@Status", "Active");
                  }
                  cmb.Parameters.AddWithValue("@Remark", txtremark.Text);
                  cmb.ExecuteNonQuery();
                show();
                MessageBox.Show("Employee successfully Added...");
                  clearData();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
       
        }
        public void doctors()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Insert INTO Doctors (Dr_Name,Contact_Number,Is_Active)
            values(@Dr_Name,@Contact_Number,@Is_Active)",con);
            cmb.Parameters.AddWithValue("@Dr_Name", txtname.Text);
            cmb.Parameters.AddWithValue("@Contact_Number", txtMobileNumber.Text);
            if (checkStatus.Enabled == true)
            {
                cmb.Parameters.AddWithValue("@Is_Active", "Active");
            }
            else
            {
                cmb.Parameters.AddWithValue("@Is_Active", "Inactive");
            }
            cmb.ExecuteNonQuery();

           // MessageBox.Show("Employee successfully Added...");
           // clearData();
        }
        public void clearData()
        {
            txtAlternateNumber.Text = "";
            txtcurrentAddress.Text = "";
            txtDateOfBirth.Text = "";
            txtDepartment.Text = "";
            txtDesignation.Text = "";
            txtExperience.Text = "";
            txtgender.Text = "";
            txtJoinDate.Text = "";

            //txtpost.Text = "";

            txtMaritalStatus.Text = "";
            txtMobileNumber.Text = "";
            txtmr.Text = "";
            txtname.Text = "";
            txtPermanentAddress.Text = "";
            txtprobationDate.Text = "";
            txtremark.Text = "";
        }
        public void show()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select Employee_Of,Name,Current_Address,Mobile_Number,Department,Designation,Status From Employee_registration",con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable o = new DataTable();
            adt.Fill(o);
            if(o.Rows.Count>0)
            {
                dataGridView1.DataSource = o;
            }

        }
        private void txtDateOfBirth_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           // try
           // {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();

                SqlCommand cmb = new SqlCommand(@"UPDATE INTO Employee_registration 
                                    SET (Employee_of=@Employee_of,MR_M=@MR_M,Gender=@Gender,Current_Address=@Current_Address,Post=@Post,Permanent_Address=@Permanent_Address,MaritalStatus=@MaritalStatus,Experience=@Experience,Alternate_Mobile_number=@Alternate_Mobile_number,Date_Of_Birth=@Date_Of_Birth,Department=@Department,Designation=@Designation,Joining_Date=@Joining_Date,Probation=@Probation,Status=@Status,Remark=@Remark Where Mobile_Number=@Mobile_Number and name=@name)
                                    ", con);
                if (rbtrubystarhospital.Checked == true)
                {
                    cmb.Parameters.AddWithValue("@Employee_of", "Ruby Star Hospital");
                }
                else
                {
                    cmb.Parameters.AddWithValue("@Employee_of", "Contractor");
                }
                cmb.Parameters.AddWithValue("@MR_M", txtmr.Text);
                cmb.Parameters.AddWithValue("@Name", txtname.Text);
                cmb.Parameters.AddWithValue("@Gender", txtgender.Text);
                cmb.Parameters.AddWithValue("@Current_Address", txtcurrentAddress.Text);
              //  cmb.Parameters.AddWithValue("@Post", txtpost.Text);
                cmb.Parameters.AddWithValue("@Permanent_Address", txtPermanentAddress.Text);
                cmb.Parameters.AddWithValue("@Mobile_Number", txtMobileNumber.Text);
                cmb.Parameters.AddWithValue("@MaritalStatus", txtMaritalStatus.Text);
                cmb.Parameters.AddWithValue("@Experience", txtExperience.Text);
                cmb.Parameters.AddWithValue("@Alternate_Mobile_number", txtAlternateNumber.Text);
                cmb.Parameters.AddWithValue("@Date_Of_Birth", txtDateOfBirth.Text);
                cmb.Parameters.AddWithValue("@Department", txtDepartment.Text);
                cmb.Parameters.AddWithValue("@Designation", txtDesignation.Text);
                cmb.Parameters.AddWithValue("@Joining_Date", txtJoinDate.Text);
                cmb.Parameters.AddWithValue("@Probation", txtprobationDate.Text);
                if (checkStatus.Enabled == true)
                {
                    cmb.Parameters.AddWithValue("@Status", "Active");
                }
                cmb.Parameters.AddWithValue("@Remark", txtremark.Text);
                cmb.ExecuteNonQuery();

            MessageBox.Show("Employee Added Successfully ...");
                clearData();
           // }
           // catch
           // {

           // }
            show();


        }

        private void txtname_MouseClick(object sender, MouseEventArgs e)
        {
            if(txtname.Text== "Fisrtname                    Middle                  Lastname")
            txtname.Clear();
        }

        private void txtname_MouseLeave(object sender, EventArgs e)
        {
            if (txtname.Text == "")
                txtname.Text = "Fisrtname                    Middle                  Lastname";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtDesignation.Text=="Doctor")
            {
                panel1.Visible=true;
            }
            else
            {
                panel1.Visible = false;
            }
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (panel1.Visible ==true)
            {
                if((rbResidentialDoctor.Checked) || (rbVisitingDotor.Checked))
                {

                }
                else
                {
                    panel1.Focus();
                }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            show();
            if (txtDesignation.Text == "Doctor")
            {
                doctors();
                savedata();
            }
            else
            {
                savedata();
            }
        }

        private void txtDesignation_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtDepartment_TextChanged(object sender, EventArgs e)
        {
            Designation();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
