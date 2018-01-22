using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G_Unit_Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupFindKunde.Visible = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupFindKunde.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Kunde.OpretKunde(textBox1.Text, textBox2.Text);
            textBox1.Clear(); textBox2.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kunde.FindKunde(textBox3.Text, comboBox1.SelectedIndex+1);
        }


        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
