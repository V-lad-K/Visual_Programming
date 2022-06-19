using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace schedule
{
    public partial class Form1 : Form
    {
        public double parametr_a = 0;
        public Form1()
        {
            InitializeComponent();
 
        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();

            chart1.Series[0].Points.Clear();

            double h = (double.Parse(textBox3.Text) - double.Parse(textBox2.Text) )/double.Parse(textBox1.Text);
            for (int i = 1; i < Int32.Parse(textBox1.Text); i++)
            {
                users.Add(new User(i, double.Parse(textBox2.Text)+i*h));
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("номер", typeof(int));
            dt.Columns.Add("y", typeof(double));
            dt.Columns.Add("x", typeof(double));

            double min;
            double max;
            min = users[0].func(users[0].x);
            max = users[0].func(users[0].x);
            for (int i = 0; i < users.Count; i++)
            {
                if(users[i].func(users[i].x)<min)
                {
                    min = users[i].func(users[i].x);
                }
                if (users[i].func(users[i].x) > max)
                {
                    max = users[i].func(users[i].x);
                }
                dt.Rows.Add(users[i].count, users[i].func(users[i].x), users[i].x);
                chart1.Series["Series1"].Points.AddXY(users[i].x, users[i].func(users[i].x));
            }

            dataGridView1.DataSource = dt;

            label1.Text = min.ToString();
            label5.Text = max.ToString();
        }
        
        public class User{
            public int count;
            public double x;
            public User(int _count, double _x)
            {
                count = _count;
                x = _x;
            }
            ~User()
            {
                
            }
            public double func(double x)
            {
                return (Math.Pow(x+2, 2.0/3.0) - Math.Pow(x-2, 2.0/3.0));
            }
            
            public double func_x_t(double x, double parametr_a)
            {
                return (parametr_a / (Math.Pow(Math.Cos(x), 3.0))); 
            }
            public double func_y_t(double x, double parametr_a)
            {
                return parametr_a * Math.Pow(Math.Tan(x), 3);
            }
            public double func_y_x(double x, double parametr_a)
            {
                return parametr_a * Math.Pow(Math.Tan(Math.Acos(Math.Pow(parametr_a / x, 1.0 / 3.0))), 3.0);
            }


        }
        List<User> users = new List<User>();
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void check(string value)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(value, "[^-0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                value = value.Remove(value.Length - 1);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            check(textBox1.Text);
            
        }

        private void cartesianChart1_ChildChanged_1(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void btn_func(string value3, string value2, string value1)
        {
            double h = (double.Parse(value3) - double.Parse(value2)) / double.Parse(value1);
            for (int i = 1; i < Int32.Parse(value1); i++)
            {
                users.Add(new User(i, double.Parse(value2) + i * h));
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("номер", typeof(int));
            dt.Columns.Add("y", typeof(double));
            dt.Columns.Add("t", typeof(double));


            for (int i = 0; i < users.Count; i++)
            {
                dt.Rows.Add(users[i].count, users[i].func_y_t(users[i].x, parametr_a), users[i].x);
                chart1.Series["Series1"].Points.AddXY(users[i].x, users[i].func_y_t(users[i].x, parametr_a));
            }

            dataGridView1.DataSource = dt;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Clear();

            chart1.Series["Series1"].Points.Clear();
            
            
            double h = (double.Parse(textBox3.Text) - double.Parse(textBox2.Text)) / double.Parse(textBox1.Text);
            for (int i = 1; i < Int32.Parse(textBox1.Text); i++)
            {
                users.Add(new User(i, double.Parse(textBox2.Text) + i * h));
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("номер", typeof(int));
            dt.Columns.Add("y", typeof(double));
            dt.Columns.Add("t", typeof(double));

            double min;
            double max;
            min = users[0].func_y_t(users[0].x, parametr_a);
            max = users[0].func_y_t(users[0].x, parametr_a);
            for (int i = users.Count-int.Parse(textBox1.Text)+1; i < users.Count; i++)
            {
                if (users[i].func_y_t(users[i].x, parametr_a) < min)
                {
                    min = users[i].func_y_t(users[i].x, parametr_a);
                }
                if (users[i].func_y_t(users[i].x, parametr_a) > max)
                {
                    max = users[i].func_y_t(users[i].x, parametr_a);
                }
                dt.Rows.Add(users[i].count, users[i].func_y_t(users[i].x, parametr_a), users[i].x);
                chart1.Series["Series1"].Points.AddXY(users[i].x, users[i].func_y_t(users[i].x, parametr_a));
            }

            dataGridView1.DataSource = dt;


            label1.Text = min.ToString();
            label5.Text = max.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
            parametr_a = double.Parse(textBox4.Text);

            chart1.Series[0].Points.Clear();
            double h = (double.Parse(textBox3.Text) - double.Parse(textBox2.Text)) / double.Parse(textBox1.Text);
            for (int i = 1; i < Int32.Parse(textBox1.Text); i++)
            {
                users.Add(new User(i, double.Parse(textBox2.Text) + i * h));
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("номер", typeof(int));
            dt.Columns.Add("x", typeof(double));
            dt.Columns.Add("t", typeof(double));

            double min;
            double max;
            min = users[0].func_x_t(users[0].x, parametr_a);
            max = users[0].func_x_t(users[0].x, parametr_a);
            for (int i = users.Count - int.Parse(textBox1.Text) + 1; i < users.Count; i++)
            {
                if (users[i].func_x_t(users[i].x, parametr_a) < min)
                {
                    min = users[i].func_x_t(users[i].x, parametr_a);
                }
                if (users[i].func_x_t(users[i].x, parametr_a) > max)
                {
                    max = users[i].func_x_t(users[i].x, parametr_a);
                }
                dt.Rows.Add(users[i].count, users[i].func_x_t(users[i].x, parametr_a), users[i].x);
                chart1.Series["Series1"].Points.AddXY(users[i].x, users[i].func_x_t(users[i].x, parametr_a));
            }

            dataGridView1.DataSource = dt;

            label1.Text = min.ToString();
            label5.Text = max.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();

            chart1.Series[0].Points.Clear();
            double h = (double.Parse(textBox3.Text) - double.Parse(textBox2.Text)) / double.Parse(textBox1.Text);
            for (int i = 1; i < Int32.Parse(textBox1.Text); i++)
            {
                users.Add(new User(i, double.Parse(textBox2.Text) + i * h));
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("номер", typeof(int));
            dt.Columns.Add("y", typeof(double));
            dt.Columns.Add("x", typeof(double));


            double min;
            double max;
            min = users[0].func_y_x(users[0].x, parametr_a);
            max = users[0].func_y_x(users[0].x, parametr_a);
            for (int i = users.Count - int.Parse(textBox1.Text) + 1; i < users.Count; i++)
            {
                if (users[i].func_y_x(users[i].x, parametr_a) < min)
                {
                    min = users[i].func_y_x(users[i].x, parametr_a);
                }
                if (users[i].func_y_x(users[i].x, parametr_a) > max)
                {
                    max = users[i].func_y_x(users[i].x, parametr_a);
                }
                dt.Rows.Add(users[i].count, users[i].func_y_x(users[i].x, parametr_a), users[i].x);
                chart1.Series["Series1"].Points.AddXY(users[i].x, users[i].func_y_x(users[i].x, parametr_a));
            }

            dataGridView1.DataSource = dt;

            label1.Text = min.ToString();
            label5.Text = max.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            parametr_a = double.Parse(textBox4.Text);

            Clear();

            double h = (double.Parse(textBox3.Text) - double.Parse(textBox2.Text)) / double.Parse(textBox1.Text);
            for (int i = 1; i < Int32.Parse(textBox1.Text); i++)
            {
                users.Add(new User(i, double.Parse(textBox2.Text) + i * h));
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("номер", typeof(int));
            dt.Columns.Add("x", typeof(double));
            dt.Columns.Add("y", typeof(double));


            double min;
            double max;
            min = users[0].func_y_t(users[0].x, parametr_a);
            max = users[0].func_y_t(users[0].x, parametr_a);
            for (int i = users.Count - int.Parse(textBox1.Text) + 1; i < users.Count; i++)
            {
                if (users[i].func_y_t(users[i].x, parametr_a) < min)
                {
                    min = users[i].func_y_t(users[i].x, parametr_a);
                }
                if (users[i].func_y_t(users[i].x, parametr_a) > max)
                {
                    max = users[i].func_y_t(users[i].x, parametr_a);
                }
                dt.Rows.Add(users[i].count, users[i].func_y_t(users[i].x, parametr_a), users[i].x);
                chart1.Series["Series1"].Points.AddXY(users[i].x, users[i].func_y_t(users[i].x, parametr_a));
            }

            dataGridView1.DataSource = dt;

            label1.Text = min.ToString();
            label5.Text = max.ToString();
        }

        public void empty_check()
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0)
            {
                MessageBox.Show("parametrs should be not empty");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            check(textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            check(textBox3.Text);
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }
        void Clear()
        {
            if (this.dataGridView1.DataSource != null)
            {
                this.dataGridView1.DataSource = null;
            }
            else
            {
                this.dataGridView1.Rows.Clear();
            }
            dataGridView1.Rows.Clear();
            chart1.Series["Series1"].Points.Clear();
            chart1.Series[0].Points.Clear();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
