﻿using DesktopClient.Crypto.LAB_04;
using DesktopClient.Crypto.LAB_05;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox3.Text = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var time = Stopwatch.StartNew();
            richTextBox2.Text = MonoCrypt.Encrypt(textBox3.Text, richTextBox1.Text, Int32.Parse(textBox1.Text));
            time.Stop();
            label4.Text = time.Elapsed.TotalSeconds.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var time = Stopwatch.StartNew();
            richTextBox2.Text = MonoCrypt.Decrypt(textBox3.Text, richTextBox1.Text, Int32.Parse(textBox1.Text));
            time.Stop();
            label4.Text = time.Elapsed.TotalSeconds.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var clearPattern = new Regex(@"(\W|\d)", RegexOptions.IgnoreCase);
            var clearText = clearPattern.Replace(richTextBox1.Text.ToLower(), "");
            var crypt = new PolygamCrypt(textBox3.Text);
            var time = Stopwatch.StartNew();
            richTextBox2.Text = crypt.Encrypt(clearText);
            time.Stop();
            label4.Text = time.Elapsed.TotalSeconds.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var crypt = new PolygamCrypt(textBox3.Text);
            var time = Stopwatch.StartNew();
            richTextBox2.Text = crypt.Decrypt(richTextBox1.Text);
            time.Stop();
            label4.Text = time.Elapsed.TotalSeconds.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var crypt = new RouteCrypt(Int32.Parse(textBox1.Text));
            var time = Stopwatch.StartNew();
            richTextBox2.Text = crypt.Crypt(richTextBox1.Text);
            time.Stop();
            label4.Text = time.Elapsed.TotalSeconds.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var crypt = new RouteCrypt(Int32.Parse(textBox1.Text));
            var time = Stopwatch.StartNew();
            richTextBox2.Text = crypt.Crypt(richTextBox1.Text);
            time.Stop();
            label4.Text = time.Elapsed.TotalSeconds.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var crypt = new MultiPermCrypt(textBox3.Text, textBox1.Text, textBox2.Text);
            var time = Stopwatch.StartNew();
            richTextBox2.Text = crypt.Encrypt(richTextBox1.Text);
            time.Stop();
            label4.Text = time.Elapsed.TotalSeconds.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var crypt = new MultiPermCrypt(textBox3.Text, textBox1.Text, textBox2.Text);
            var time = Stopwatch.StartNew();
            richTextBox2.Text = crypt.Decrypt(richTextBox1.Text);
            time.Stop();
            label4.Text = time.Elapsed.TotalSeconds.ToString();
        }
    }
}
