using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Notes
{
    public partial class Form4 : Form
    {
        public static int cin ;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            cin = int.Parse(textBox1.Text);
            this.Hide();
            Form6 frm = new Form6();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 frm = new Form5();
            frm.ShowDialog();
        }
    }
}
