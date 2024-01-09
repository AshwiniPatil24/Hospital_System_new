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
    public partial class Master_Drugs : Form
    {
        public Master_Drugs()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txtsearch.Text!="")
            {
                update();
            }
            else
            {
                save();
            }

        }
        public void save()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"INSERT into Master_OPD_DrugsList (Name,Description,Createdby)
values      (@Name,@Description,@Createdby)", con);
            cmb.Parameters.AddWithValue("@Name", txtname.Text);
            cmb.Parameters.AddWithValue("@Description", txtDescription.Text);
            cmb.Parameters.AddWithValue("@Createdby", txtdate.Text);
            cmb.ExecuteNonQuery();
            MessageBox.Show("inserted successfully.....!");
            con.Close();
        }
        public void update()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Update Master_OPD_DrugsList set Name=@Name,Description=@Description,Updatedby=@Updatedby
WHERE  (Name=@Name)", con);
            cmb.Parameters.AddWithValue("@Name", txtname.Text);
            cmb.Parameters.AddWithValue("@Description", txtDescription.Text);
            cmb.Parameters.AddWithValue("@Updatedby", txtdate.Text);
            cmb.ExecuteNonQuery();
            MessageBox.Show("inserted successfully.....!");
            con.Close();
        }
    }
}
