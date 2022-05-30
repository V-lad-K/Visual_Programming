using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Schema;
namespace Lab4
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

          
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
            dataGridView1.Rows[n].Cells[1].Value = textBox2.Text;
            dataGridView1.Rows[n].Cells[2].Value = textBox3.Text;
            dataGridView1.Rows[n].Cells[3].Value = textBox4.Text;
            dataGridView1.Rows[n].Cells[4].Value = textBox5.Text;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Columns.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
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

        private void button7_Click(object sender, EventArgs e)
        {

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            add_columns();

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

        private void button8_Click(object sender, EventArgs e)
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
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                    dt.Columns.Add();
                }
            }

            object[] cellValues = new object[dgv.Columns.Count];

            foreach (DataGridViewRow row in dgv.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[i] = row.Cells[i].Value;

                }
                dt.Rows.Add(cellValues);
            }

            return dt;
        }
        public void add_columns()
        {
            dataGridView1.Columns.Add("Column1", "Column1");
            dataGridView1.Columns.Add("Column2", "Column2");
            dataGridView1.Columns.Add("Column3", "Column3");
            dataGridView1.Columns.Add("Column4", "Column4");
            dataGridView1.Columns.Add("Column5", "Column5");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                name = openFileDialog1.FileName;

                XmlSchemaSet xmlSchemaSet = new XmlSchemaSet();
                xmlSchemaSet.Add("", @"D:\Візуальне програмування\Labs\Lab4\Validation.xsd");
                XDocument doc = XDocument.Load(name);

                bool validationError = false;
                doc.Validate(xmlSchemaSet, (s, g) =>
                {
                    MessageBox.Show(g.Message);
                    //Console.WriteLine(g.Message);
                    validationError = true;
                });

                if (validationError)
                {
                    MessageBox.Show("validation failed");
                    //Console.WriteLine("validation failed");
                }
                else
                {
                    MessageBox.Show("validation acces");
                    //Console.WriteLine("validation acces");
                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.Columns.Clear();
            dataGridView2.Columns.Add("Column1", "Column1");
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value.ToString() == textBox6.Text)
                {
                    int n = dataGridView2.Rows.Add();

                    dataGridView2.Rows[n].Cells[0].Value = dataGridView1.Rows[i].Cells[3].Value.ToString();
                }
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.Columns.Clear();
            dataGridView2.Columns.Add("Column1", "Column1");
            dataGridView2.Columns.Add("Column2", "Column2");

            List<string> list = new List<string>();

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                list.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());               
            }

            List<string> uniqueList = list.Distinct().ToList();

            for (int j = 0; j < uniqueList.Count; j++)
            {
                List<int> arr = new List<int>();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[1].Value.ToString() == uniqueList[j])
                    {
                        arr.Add((int.Parse(DateTime.Now.Year.ToString()) - int.Parse(DateTime.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()).Year.ToString())));
                    }
                }
                int n = dataGridView2.Rows.Add();

                dataGridView2.Rows[n].Cells[0].Value = double.Parse(arr.Sum().ToString())/double.Parse(arr.Count().ToString());
                dataGridView2.Rows[n].Cells[1].Value = uniqueList[j];
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.Columns.Clear();
            dataGridView2.Columns.Add("Column1", "Column1");
            dataGridView2.Columns.Add("Column2", "Column2");

            List<string> list = new List<string>();

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                list.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
            }

            List<string> uniqueList = list.Distinct().ToList();

            
            for (int j = 0; j < uniqueList.Count; j++)
            {
                List<string> profession = new List<string>();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {                   
                    if (uniqueList[j] == dataGridView1.Rows[i].Cells[1].Value.ToString())
                    {                       
                        profession.Add(dataGridView1.Rows[i].Cells[4].Value.ToString());                       
                    }
                }
                List<string> uniqueProfession = profession.Distinct().ToList();
                int[] array = new int[uniqueProfession.Count];

                for(int m = 0; m<uniqueProfession.Count; m++)
                {
                    int S = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {

                        if ((uniqueProfession[m] == dataGridView1.Rows[i].Cells[4].Value.ToString()) && (dataGridView1.Rows[i].Cells[1].Value.ToString() == uniqueList[j]))
                        {
                            S++;
                            
                        }
                    }
                    array[m] = S;
                }
                int n = dataGridView2.Rows.Add();
                dataGridView2.Rows[n].Cells[0].Value = array.Max();
                dataGridView2.Rows[n].Cells[1].Value = uniqueList[j];

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            add_columns();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("поле номер округу не вірно вказане");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^A-я]"))
            {
                MessageBox.Show("поле назва округу не вірно вказане");
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "[^A-я]"))
            {
                MessageBox.Show("поле біографія не вірно вказане");
                textBox4.Text = textBox4.Text.Remove(textBox4.Text.Length - 1);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, "[^A-я]"))
            {
                MessageBox.Show("поле професія не вірно вказане");
                textBox5.Text = textBox5.Text.Remove(textBox5.Text.Length - 1);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[^.,0-9]"))
            {
                MessageBox.Show("поле дата народження не вірно вказане");
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
            }
        }
    }
}
 