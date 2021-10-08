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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=projet;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update students set name=@nom, surname=@prenom, subject=@subject, mark=@mark where cin=@cin", con);
            cmd.Parameters.AddWithValue("@cin", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@nom", textBox2.Text);
            cmd.Parameters.AddWithValue("@prenom", textBox3.Text);
            cmd.Parameters.AddWithValue("@subject", textBox5.Text);
            cmd.Parameters.AddWithValue("@mark", float.Parse(textBox4.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Mark Edited Successfully !");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=projet;Integrated Security=True");
            con.Open();
            
            SqlCommand cmd2 = new SqlCommand("Select cin from users where connected=1",con);
            SqlDataReader reader = cmd2.ExecuteReader();
            reader.Read();

            int cin_prof = reader.GetInt32(0);
            reader.Close();
            SqlCommand cmd = new SqlCommand("insert into students values (@cin,@name,@surname,@subject,@mark,@cin_prof)", con);

            cmd.Parameters.AddWithValue("@cin", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@surname", textBox3.Text);
            cmd.Parameters.AddWithValue("@subject", textBox5.Text);
            cmd.Parameters.AddWithValue("@mark", float.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@cin_prof", cin_prof);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Mark added successfully !");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=projet;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete students where cin=@cin", con);
            cmd.Parameters.AddWithValue("@cin", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Mark deleted successfully !");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=projet;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from students where cin=@cin", con);
            cmd.Parameters.AddWithValue("@cin", int.Parse(textBox1.Text));
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            d.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=projet;Integrated Security=True");
            con.Open();
            SqlCommand cmd2 = new SqlCommand("Select cin from users where connected=1", con);
            SqlDataReader reader = cmd2.ExecuteReader();
            reader.Read();

            int cin_prof = reader.GetInt32(0);
            reader.Close();
            SqlCommand cmd = new SqlCommand("Select cin,name,surname,subject,mark from students where cin_prof=@cin_prof", con);
            cmd.Parameters.AddWithValue("@cin_prof", cin_prof);
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            d.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.ShowDialog();
        }
    }
}
