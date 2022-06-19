using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Corse
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Datacs.Login_Current = textBox1.Text;
            Datacs.Pasword_Current = textBox2.Text;

            if (Datacs.Login_Current == "Administrator" && Datacs.Pasword_Current == "Administrator")
            {
                Form1 menu = new Form1();
                this.Hide();
                menu.ShowDialog();
                this.Close();
            }
            if (Datacs.Login_Current == "Storekeeper" && Datacs.Pasword_Current == "Storekeeper")
            {
                Form1 menu = new Form1();
                this.Hide();
                menu.ShowDialog();
                this.Close();
            }
            if (Datacs.Login_Current == "Marketer" && Datacs.Pasword_Current == "Marketer")
            {
                Form1 menu = new Form1();
                this.Hide();
                menu.ShowDialog();
                this.Close();
            }
            if (Datacs.Login_Current == "Accountant" && Datacs.Pasword_Current == "Accountant")
            {
                Form1 menu = new Form1();
                this.Hide();
                menu.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильний пароль або логін");            
            }
           
        }
    
    }
}
