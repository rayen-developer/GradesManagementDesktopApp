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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=projet;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into users(username,password,cin) values (@u,@mdp,@cin)", con);
            cmd.Parameters.AddWithValue("@u", textBox1.Text);
            cmd.Parameters.AddWithValue("@mdp", textBox3.Text);
            cmd.Parameters.AddWithValue("@cin", textBox2.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Registered successfully !");
            this.Hide();
            Form1 log = new Form1();
            log.ShowDialog();
        }
    }
}
