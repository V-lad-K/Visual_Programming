using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string str = "";
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                label7.Text = (0.5 * (Math.Pow(2 * Math.Pow(double.Parse(textBox2.Text), 2) + 2 * Math.Pow(double.Parse(textBox3.Text), 2) - Math.Pow(double.Parse(textBox1.Text), 2), 0.5))).ToString();
                label6.Text = (double.Parse(textBox1.Text) + double.Parse(textBox2.Text) + double.Parse(textBox3.Text)).ToString();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            catch
            {
                MessageBox.Show("parametrs is not int or double");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^,,0-9]"))
            {
                MessageBox.Show("поле textbox1 не вірно вказане");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^,,0-9]"))
            {
                MessageBox.Show("поле textbox2 не вірно вказане");
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[^,,0-9]"))
            {
                MessageBox.Show("поле textbox3 не вірно вказане");
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (str == "textbox1") textBox1.Text += button2.Text;
            if (str == "textbox2") textBox2.Text += button2.Text;
            if (str == "textbox3") textBox3.Text += button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (str == "textbox1") textBox1.Text += button3.Text;
            if (str == "textbox2") textBox2.Text += button3.Text;
            if (str == "textbox3") textBox3.Text += button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (str == "textbox1") textBox1.Text += button4.Text;
            if (str == "textbox2") textBox2.Text += button4.Text;
            if (str == "textbox3") textBox3.Text += button4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (str == "textbox1") textBox1.Text += button5.Text;
            if (str == "textbox2") textBox2.Text += button5.Text;
            if (str == "textbox3") textBox3.Text += button5.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (str == "textbox1") textBox1.Text += button6.Text;
            if (str == "textbox2") textBox2.Text += button6.Text;
            if (str == "textbox3") textBox3.Text += button6.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (str == "textbox1") textBox1.Text += button7.Text;
            if (str == "textbox2") textBox2.Text += button7.Text;
            if (str == "textbox3") textBox3.Text += button7.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (str == "textbox1") textBox1.Text += button8.Text;
            if (str == "textbox2") textBox2.Text += button8.Text;
            if (str == "textbox3") textBox3.Text += button8.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (str == "textbox1") textBox1.Text += button9.Text;
            if (str == "textbox2") textBox2.Text += button9.Text;
            if (str == "textbox3") textBox3.Text += button9.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (str == "textbox1") textBox1.Text += button10.Text;
            if (str == "textbox2") textBox2.Text += button10.Text;
            if (str == "textbox3") textBox3.Text += button10.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (str == "textbox1") textBox1.Text += button11.Text;
            if (str == "textbox2") textBox2.Text += button11.Text;
            if (str == "textbox3") textBox3.Text += button11.Text;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            str = "textbox1";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            str = "textbox2";
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            str = "textbox3";
        }
    }
}
