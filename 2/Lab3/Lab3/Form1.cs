using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace Lab3
{
    public partial class Form1 : Form
    {
        private string name;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            users.Add(new User(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text), int.Parse(textBox4.Text), textBox5.Text));


            DataTable dt = new DataTable();
            dt.Columns.Add("бренд", typeof(string));
            dt.Columns.Add("ім'я", typeof(string));
            dt.Columns.Add("рік випуску", typeof(int));
            dt.Columns.Add("номер", typeof(int));
            dt.Columns.Add("дата техогляду", typeof(string));

            dt.Rows.Add(users[0].brand, users[0].name, users[0].grad_year, users[0].number, users[0].tech_date);


            dataGridView1.DataSource = dt;
        }

        public struct User
        {
            public string brand;
            public string name;
            public int grad_year;
            public int number;
            public string tech_date;

            public User(string _brand, string _name, int _grad_year, int _number, string _tech_date)
            {
                brand = _brand;
                name = _name;
                grad_year = _grad_year;         
                number = _number;
                tech_date = _tech_date;
            }
        }

        List<User> users = new List<User>();

        

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            

            Regex r = new Regex("^[A-Z]{2}[0-9]{4}[A-Z]{2}$");

            if (r.IsMatch(textBox4.Text) == false)
            {
                MessageBox.Show("номер машини запиано не вірно");
            }
            else
            {
                int n = dataGridView1.Rows.Add();

                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = textBox2.Text;
                dataGridView1.Rows[n].Cells[2].Value = textBox3.Text;
                dataGridView1.Rows[n].Cells[3].Value = textBox4.Text;
                dataGridView1.Rows[n].Cells[4].Value = textBox5.Text;
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = null;
                name = openFileDialog1.FileName;
                DataSet ds = new DataSet();
                ds.ReadXml(name);
                dataGridView1.DataSource = ds.Tables[0];

                for (int i = 1; i < dataGridView1.RowCount - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == "")
                    {
                        dataGridView1.Rows.RemoveAt(i);
                        i--;
                    }

                }

            }
      
        }
        private void button3_Click(object sender, EventArgs e)
        {

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                name = saveFileDialog1.FileName;

                DataTable dt = GetDataFromDGV(dataGridView1);
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                ds.WriteXml(name);
                
            }
        }
        private DataTable GetDataFromDGV(DataGridView dgv)
        {
            var dt = new DataTable();
            foreach(DataGridViewColumn column in dgv.Columns)
            {
                if(column.Visible)
                {
                    dt.Columns.Add();                  
                }
            }
            
            object[] cellValues = new object[dgv.Columns.Count];
           
            foreach (DataGridViewRow row in dgv.Rows)
            {
                for(int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[i] = row.Cells[i].Value;
                    
                }
                dt.Rows.Add(cellValues);
            }
           
            return dt;
        }

        /*private void button1_Click_1(object sender, EventArgs e)
        {
            for(int i = 0; i < dataGridView1.Rows.Count; i++ )
            {
                if (int.Parse(DateTime.Now.Year.ToString()) -int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString())<10)
                {
                    if (int.Parse(DateTime.Now.Year.ToString()) - int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()) < 10)
                    {
                        dataGridView1.Rows.Clear();
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells[0].Value = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        dataGridView1.Rows[n].Cells[1].Value = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        dataGridView1.Rows[n].Cells[2].Value = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        dataGridView1.Rows[n].Cells[3].Value = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        dataGridView1.Rows[n].Cells[4].Value = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    }   
                }
            }                       
        }*/

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //dataGridView1.Rows.Clear();
            //dataGridView1.Columns.Clear();
            //dataGridView1.DataSource = null;

            //dataGridView2.Columns.Clear();

        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView2.Columns.Clear();
            add_columnsgrid2();

            //dataGridView2.Rows.Clear();
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
               if ((int.Parse(DateTime.Now.Year.ToString()) - int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()))>10)
               {
                    if ((DateTime.Now.Year - DateTime.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()).Year) > 1)
                    {
                        add_columns2(i);
                    }                   
               }
               if ((int.Parse(DateTime.Now.Year.ToString()) - int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString())) < 10)
                {
                    if ((int.Parse(DateTime.Now.Year.ToString()) - int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString())) > 2)
                    {
                        add_columns2(i);
                    }
               }
            }
        }

        public void add_columns()
        {
            dataGridView1.Columns.Add("Column1", "Column1");
            dataGridView1.Columns.Add("Column2", "Column2");
            dataGridView1.Columns.Add("Column3", "Column3");
            dataGridView1.Columns.Add("Column4", "Column4");
            dataGridView1.Columns.Add("Column5", "Column5");
        }
        public void add_columnsgrid2()
        {
            dataGridView2.Columns.Add("Column1", "Column1");
            dataGridView2.Columns.Add("Column2", "Column2");
            dataGridView2.Columns.Add("Column3", "Column3");
            dataGridView2.Columns.Add("Column4", "Column4");
            dataGridView2.Columns.Add("Column5", "Column5");
        }

        public void add_columns2(int i)
        {
            int n = dataGridView2.Rows.Add();

            dataGridView2.Rows[n].Cells[0].Value = dataGridView1.Rows[i].Cells[0].Value.ToString();
            dataGridView2.Rows[n].Cells[1].Value = dataGridView1.Rows[i].Cells[1].Value.ToString();
            dataGridView2.Rows[n].Cells[2].Value = dataGridView1.Rows[i].Cells[2].Value.ToString();
            dataGridView2.Rows[n].Cells[3].Value = dataGridView1.Rows[i].Cells[3].Value.ToString();
            dataGridView2.Rows[n].Cells[4].Value = dataGridView1.Rows[i].Cells[4].Value.ToString();
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView2.Columns.Clear();
            add_columnsgrid2();

            int now = int.Parse(DateTime.Now.Year.ToString());

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                int old1 = int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                int old2 = int.Parse(DateTime.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()).Year.ToString());
                if (old1>10)
                {
                    if ((now-old2)<=1)
                    {
                        add_columns2(i);
                    }
                }
                if (old1 < 10)
                {
                    if ((now - old2) <= 2)
                    {
                        add_columns2(i);
                    }
                }

            }
        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {

        }

    
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^A-я]"))
            {
                MessageBox.Show("поле brand не вірно вказане");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
            
        }
       
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^A-я]"))
            {
                MessageBox.Show("поле name не вірно вказано");
                textBox2.Text = textBox1.Text.Remove(textBox2.Text.Length - 1);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[A-Z]{2}[0-9]{4}[A-Z]{2}$"))
            {
                MessageBox.Show("поле textbox1 не вірно вказане");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            add_columns();
            //DataSet ds = new DataSet();
            //ds.ReadXml(@"C:\Users\Vlad\OneDrive\Рабочий стол\6 семестр\Візуальне програмування\Лаби задачі\xml\vlad.xml");
           // dataGridView1.DataSource = ds.Tables[0];


        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            //dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            add_columns();
            for (int i = 1; i < dataGridView1.RowCount - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value.ToString() == "")
                {
                    dataGridView1.Rows.RemoveAt(i);
                    i--;
                }

            }
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            /*foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value == null)
                {
                    dataGridView1.Rows.RemoveAt(row.Index);
                }
            }
            */
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[^,,0-9]"))
            {
                MessageBox.Show("поле textbox3 не вірно вказане");
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
            }
        }
    }
}