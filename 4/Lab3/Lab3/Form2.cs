using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //.DataSource = Datab.data_dt;
            //dataGridView1.DataSource = Datab.data_cl;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Datab.data_dt;

            dataGridView1.DataSource = Datab.dt;
            dataGridView1.DataSource = Datab.data_cl;
        }
    }
}
