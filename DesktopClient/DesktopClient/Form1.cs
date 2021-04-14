using DesktopClient.Crypto.LAB_04;
using DesktopClient.Crypto.LAB_05;
using DesktopClient.Crypto.LAB_06;
using DesktopClient.Crypto.LAB_08;
using DesktopClient.Crypto.LAB_09;
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
        private int _knapsackM = 0;
        private int _knapsackN = 0;

        public Form1()
        {
            InitializeComponent();
            textBox3.Text = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
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

        private void button9_Click(object sender, EventArgs e)
        {
            Enigma enigma = new Enigma();
            int offsetR = Int32.Parse(textBox6.Text) % 26;
            int offsetM = Int32.Parse(textBox5.Text) % 26;
            int offsetL = Int32.Parse(textBox4.Text) % 26;
            var time = Stopwatch.StartNew();
            richTextBox2.Text = enigma.Crypt(richTextBox1.Text, offsetR, offsetM, offsetL);
            time.Stop();
            label4.Text = time.Elapsed.TotalSeconds.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var rand = new Random();

            // Windows-1251
            var privateKey = SuperIncreasingSequence.Generate(8);
            _knapsackM = privateKey.Sum() + rand.Next(1, 20);
            var mutuallySimpleWithM = Enumerable.Range(0, (int)Math.Floor(2.52 * Math.Sqrt((double)_knapsackM) / Math.Log((double)_knapsackM))).Aggregate(
                Enumerable.Range(2, _knapsackM - 1).ToList(),
                (result, index) => {
                    var bp = result[index]; var sqr = bp * bp;
                    result.RemoveAll(i => i >= sqr && i % bp == 0);
                    return result;
                }
            );
            _knapsackN = mutuallySimpleWithM.ElementAt(rand.Next(0, mutuallySimpleWithM.Count - 1));
            var publicKey = SuperIncreasingSequence.GetNormalSequence(privateKey, _knapsackN, _knapsackM);

            textBox7.Text = String.Join(',', privateKey);
            textBox8.Text = String.Join(',', publicKey);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var time = Stopwatch.StartNew();

            IEnumerable<int> publicKey = textBox8.Text.Split(',').Select(s => Int32.Parse(s));
            richTextBox2.Text = String.Join(',', KnapsackCrypto.Encrypt(richTextBox1.Text, publicKey));

            time.Stop();
            label4.Text = time.Elapsed.TotalSeconds.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var time = Stopwatch.StartNew();

            IEnumerable<int> privateKey = textBox7.Text.Split(',').Select(s => Int32.Parse(s));
            richTextBox2.Text = KnapsackCrypto.Decrypt(richTextBox1.Text.Split(',').Select(s => Int32.Parse(s)), privateKey, _knapsackN, _knapsackM);

            time.Stop();
            label4.Text = time.Elapsed.TotalSeconds.ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var time = Stopwatch.StartNew();

            var key = textBox9.Text.Split(',').Select(s => Byte.Parse(s)).ToArray();
            richTextBox2.Text = RC4Crypt.Crypt(richTextBox1.Text, key);

            time.Stop();
            label4.Text = time.Elapsed.TotalSeconds.ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            var time = Stopwatch.StartNew();

            var key = textBox9.Text.Split(',').Select(s => Byte.Parse(s)).AsEnumerable().ToArray();
            richTextBox2.Text = RC4Crypt.Crypt(richTextBox1.Text, key);

            time.Stop();
            label4.Text = time.Elapsed.TotalSeconds.ToString();
        }
    }
}
