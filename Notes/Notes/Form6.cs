using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Notes
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            int cin = Form4.cin;
            SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=projet;Integrated Security=True");
            con.Open();

            SqlCommand cmd1 = new SqlCommand("select name,surname from students where cin=@cin ", con);
            cmd1.Parameters.AddWithValue("@cin", cin);
            SqlDataReader reader = cmd1.ExecuteReader();
            reader.Read();

            label2.Text = reader["surname"].ToString();
            label3.Text = reader["name"].ToString();
            
            reader.Close();

            SqlCommand cmd2 = new SqlCommand("select AVG(mark) as moy from students where cin=@cin ", con);
            cmd2.Parameters.AddWithValue("@cin", cin);
            SqlDataReader reader1 = cmd2.ExecuteReader();
            reader1.Read();

            label6.Text = reader1["moy"].ToString();

            if (float.Parse(label6.Text)>=10)
            {
                label8.Text = "Success";
            }
            else
            {
                label8.Text = "Failure";
            }
            

            reader1.Close();



            SqlCommand cmd = new SqlCommand("Select subject,mark from students where cin=@cin", con);
            cmd.Parameters.AddWithValue("@cin", cin);
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            d.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 frm = new Form4();
            frm.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
