using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.CheckedListBox;

namespace LAB_03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            long number = 0;
            if (String.IsNullOrEmpty(textBox1.Text) || !Int64.TryParse(textBox1.Text, out number) || number <= 0)
            {
                label2.Text = "Enter a natular number above";
                return;
            }

            label2.Text = Crypto.IsPrimeNum(number).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            long from = Int64.Parse(textBox2.Text);
            long to = Int64.Parse(textBox3.Text);
            listBox1.Items.Clear();
            foreach(var num in Crypto.PrimeNumbersList(from, to))
            {
                listBox1.Items.Add(num);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            long a = Int64.Parse(textBox4.Text);
            long b = Int64.Parse(textBox5.Text);
            long c = 0;
            Int64.TryParse(textBox6.Text, out c);
            if (c == 0)
            {
                label4.Text = Crypto.GCD(a, b).ToString();
                return;
            }

            label4.Text = Crypto.GCD(Crypto.GCD(a, b), c).ToString();
        }
    }
}
