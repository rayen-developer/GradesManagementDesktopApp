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

namespace Notes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=(local);Initial Catalog=projet;Integrated Security=True";
            scn.Open();
            SqlCommand scmd2 = new SqlCommand("update users set connected=0", scn);
            scmd2.ExecuteNonQuery();
            SqlCommand scmd = new SqlCommand("select count (*) as cnt from users where username=@usr and password=@pwd", scn);
            scmd.Parameters.Clear();
            scmd.Parameters.AddWithValue("@usr", textBox1.Text);
            scmd.Parameters.AddWithValue("@pwd", textBox2.Text);

            

            if (scmd.ExecuteScalar().ToString() == "1")
            {
                SqlCommand scmd1 = new SqlCommand("update users set connected=1 where username=@usr and password=@pwd", scn);
                scmd1.Parameters.AddWithValue("@usr", textBox1.Text);
                scmd1.Parameters.AddWithValue("@pwd", textBox2.Text);
                scmd1.ExecuteNonQuery();
                MessageBox.Show("YOU ARE GRANTED WITH ACCESS");
                this.Hide();
                Form3 frm = new Form3();
                frm.ShowDialog();

            }

            else
            {


                MessageBox.Show("YOU ARE NOT GRANTED WITH ACCESS");

            }
            scn.Close();




        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frm = new Form2();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 frm =new Form5();
            frm.ShowDialog();
        }
    }
}