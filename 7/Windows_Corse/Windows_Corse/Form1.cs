using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
namespace Windows_Corse
{
    public partial class Form1 : Form
    {
        відслідкування_оплати_товару_покупцям_або_виплата_товару_посчальнику вотпавтп = new відслідкування_оплати_товару_покупцям_або_виплата_товару_посчальнику();
        Товар товар = new Товар();
        система_повинна_зберігати_інформацію_про_юзера спзіпю = new система_повинна_зберігати_інформацію_про_юзера();
        замовлення_особи_товару замовлення_особи = new замовлення_особи_товару();
        додаткова_інформація_про_товар інформація_Про_Товар = new додаткова_інформація_про_товар();
         
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "last_Course_WorkDataSet.Товар". При необходимости она может быть перемещена или удалена.
            this.товарTableAdapter.Fill(this.last_Course_WorkDataSet.Товар);
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToDeleteRows = true;
            Clear();

            button2.Visible = true;

            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;

            if(Datacs.Login_Current == "Accountant")
            {
                button2.Visible = false;
            }

            if (Datacs.Login_Current == "Administrator")
            {
                comboBox1.Items.Add("Product");
                comboBox1.Items.Add("Доп_інфо");
                comboBox1.Items.Add("Замовлення");
                comboBox1.Items.Add("Client");
                comboBox1.Items.Add("Оплата");
            }

            if (Datacs.Login_Current == "Accountant")
            {
                comboBox1.Items.Add("Product");
                comboBox1.Items.Add("Доп_інфо");
                comboBox1.Items.Add("Замовлення");
                comboBox1.Items.Add("Client");
                comboBox1.Items.Add("Оплата");

                //button2.Visible = false;
            }

            if (Datacs.Login_Current == "Storekeeper")
            {
                comboBox1.Items.Add("Product");
                comboBox1.Items.Add("Доп_інфо");

                //button2.Visible = false;
            }

            if (Datacs.Login_Current == "Marketer")
            {
                comboBox1.Items.Add("Product");
                comboBox1.Items.Add("Доп_інфо");
                comboBox1.Items.Add("Client");

                comboBox1.Items.Add("Замовлення");
                comboBox1.Items.Add("Оплата");
            }
        }
        void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";

            button1.Text = "add";
            button2.Enabled = false;

            //відгрузка.id = 0;
        }
        void PopulateDataGridProduct()
        {
            using (Last_Course_WorkEntities db = new Last_Course_WorkEntities())
            {
                dataGridView1.DataSource = db.Товар.ToList<Товар>();
                db.Товар.ToArray<Товар>();

                dataGridView1.Columns.Remove("відслідкування_оплати_товару_покупцям_або_виплата_товару_посчальнику");
                dataGridView1.Columns.Remove("додаткова_інформація_про_товар");
            }
        }
        void PopulateDataGridInfoProduct()
        {
            using(Last_Course_WorkEntities db = new Last_Course_WorkEntities())
            {
                dataGridView1.DataSource = db.додаткова_інформація_про_товар.ToList<додаткова_інформація_про_товар>();
                db.додаткова_інформація_про_товар.ToArray<додаткова_інформація_про_товар>();

                dataGridView1.Columns.Remove("Товар");
                dataGridView1.Columns.Remove("замовлення_особи_товару");
            }
        }
        void PopulateDataGridOrder()
        {
            using (Last_Course_WorkEntities db = new Last_Course_WorkEntities())
            {
                dataGridView1.DataSource = db.замовлення_особи_товару.ToList<замовлення_особи_товару>();
                db.замовлення_особи_товару.ToArray<замовлення_особи_товару>();

                dataGridView1.Columns.Remove("додаткова_інформація_про_товар");
                dataGridView1.Columns.Remove("система_повинна_зберігати_інформацію_про_юзера");
            }
        }
        void PopulateDataGridClient()
        {
            using (Last_Course_WorkEntities db = new Last_Course_WorkEntities())
            {
                dataGridView1.DataSource = db.система_повинна_зберігати_інформацію_про_юзера.ToList<система_повинна_зберігати_інформацію_про_юзера>();
                db.система_повинна_зберігати_інформацію_про_юзера.ToArray<система_повинна_зберігати_інформацію_про_юзера>();

                dataGridView1.Columns.Remove("відслідкування_оплати_товару_покупцям_або_виплата_товару_посчальнику");
                dataGridView1.Columns.Remove("замовлення_особи_товару");
            }
        }
        void PopulateDataGridPayment()
        {
            using (Last_Course_WorkEntities db = new Last_Course_WorkEntities())
            {
                dataGridView1.DataSource = db.відслідкування_оплати_товару_покупцям_або_виплата_товару_посчальнику.ToList<відслідкування_оплати_товару_покупцям_або_виплата_товару_посчальнику>();
                db.відслідкування_оплати_товару_покупцям_або_виплата_товару_посчальнику.ToArray<відслідкування_оплати_товару_покупцям_або_виплата_товару_посчальнику>();

                dataGridView1.Columns.Remove("система_повинна_зберігати_інформацію_про_юзера");
                dataGridView1.Columns.Remove("Товар");
            }
        }
        void VisibleTextboxOn()
        {
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
        }
        void VisibleLabelOn()
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try 
            {
                if (comboBox1.Text == "Product")
                {
                    товар.код = textBox1.Text;
                    товар.категорія_продукту = textBox2.Text;
                    товар.ім_я = textBox3.Text;
                    товар.одиниця = textBox4.Text;
                    товар.термін_придатності = DateTime.Parse(textBox5.Text);
                    товар.ціна_закупки = double.Parse(textBox6.Text);
                    товар.ціна_продажу = double.Parse(textBox7.Text);
                    товар.на_складі = int.Parse(textBox8.Text);
                    товар.id = int.Parse(textBox9.Text);

                    using (Last_Course_WorkEntities db = new Last_Course_WorkEntities())
                    {
                        if (button1.Text == "add")
                        {
                            db.Товар.Add(товар);
                            db.SaveChanges();
                        }
                        if (button1.Text == "update")
                        {
                            db.Entry(товар).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }

                    Clear();
                    PopulateDataGridProduct();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("не вірно введений індентифікатор або не вірно введені дані");
            }

            try
            {
                if (comboBox1.Text == "Доп_інфо")
                {
                    інформація_Про_Товар.номер_документу = int.Parse(textBox1.Text);
                    інформація_Про_Товар.операція = textBox2.Text;
                    інформація_Про_Товар.id = int.Parse(textBox3.Text);

                    using (Last_Course_WorkEntities db = new Last_Course_WorkEntities())
                    {
                        if (button1.Text == "add")
                        {
                            db.додаткова_інформація_про_товар.Add(інформація_Про_Товар);
                            db.SaveChanges();
                        }
                        if (button1.Text == "update")
                        {
                            db.Entry(інформація_Про_Товар).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }

                    Clear();
                    PopulateDataGridInfoProduct();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("не вірно введений індентифікатор або не вірно введені дані");
            }

            try 
            {
                if (comboBox1.Text == "Замовлення")
                {
                    замовлення_особи.кількість_товару = int.Parse(textBox1.Text);
                    замовлення_особи.дата = DateTime.Parse(textBox2.Text);
                    замовлення_особи.id = int.Parse(textBox3.Text);
                    замовлення_особи.new_info_product_id = int.Parse(textBox4.Text);
                    замовлення_особи.info_user_id = int.Parse(textBox5.Text);

                    using (Last_Course_WorkEntities db = new Last_Course_WorkEntities())
                    {
                        if (button1.Text == "add")
                        {
                            db.замовлення_особи_товару.Add(замовлення_особи);
                            db.SaveChanges();
                        }
                        if (button1.Text == "update")
                        {
                            db.Entry(замовлення_особи).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }

                    Clear();
                    PopulateDataGridOrder();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("не вірно введений індентифікатор або не вірно введені дані");
            }

            try
            {
                if (comboBox1.Text == "Client")
                {
                    спзіпю.ім_я = textBox1.Text;
                    спзіпю.код = int.Parse(textBox2.Text);
                    спзіпю.адреса = textBox3.Text;
                    спзіпю.категорія_особи = textBox4.Text;
                    спзіпю.знижка = double.Parse(textBox5.Text);
                    спзіпю.борг = double.Parse(textBox6.Text);
                    спзіпю.рахунок_за_місяць = double.Parse(textBox7.Text);
                    спзіпю.id = int.Parse(textBox8.Text);

                    using (Last_Course_WorkEntities db = new Last_Course_WorkEntities())
                    {
                        if (button1.Text == "add")
                        {
                            db.система_повинна_зберігати_інформацію_про_юзера.Add(спзіпю);
                            db.SaveChanges();
                        }
                        if (button1.Text == "update")
                        {
                            db.Entry(спзіпю).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }

                    Clear();
                    PopulateDataGridClient();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("не вірно введений індентифікатор або не вірно введені дані");
            }

            try
            {
                if (comboBox1.Text == "Оплата")
                {
                    вотпавтп.дата = DateTime.Parse(textBox1.Text);
                    вотпавтп.сума = double.Parse(textBox2.Text);
                    вотпавтп.id = int.Parse(textBox3.Text);
                    вотпавтп.info_user_id = int.Parse(textBox4.Text);
                    вотпавтп.product_id = int.Parse(textBox5.Text);

                    using (Last_Course_WorkEntities db = new Last_Course_WorkEntities())
                    {
                        if (button1.Text == "add")
                        {
                            db.відслідкування_оплати_товару_покупцям_або_виплата_товару_посчальнику.Add(вотпавтп);
                            db.SaveChanges();
                        }
                        if (button1.Text == "update")
                        {
                            db.Entry(вотпавтп).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }

                    Clear();
                    PopulateDataGridPayment();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("не вірно введений індентифікатор або не вірно введені дані");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Product" && MessageBox.Show("Are You Sure to Delete this Record ?", "EF CRUD Operation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (Last_Course_WorkEntities db = new Last_Course_WorkEntities())
                {
                    var entry = db.Entry(товар);
                    if (entry.State == EntityState.Detached)
                        db.Товар.Attach(товар);
                    
                    db.Товар.Remove(товар);
                    db.SaveChanges();

                    PopulateDataGridProduct();
                    Clear();
                    
                    MessageBox.Show("Deleted Successfully");
                }
            }
         
            if (comboBox1.Text == "Доп_інфо" && MessageBox.Show("Are You Sure to Delete this Record ?", "EF CRUD Operation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (Last_Course_WorkEntities db = new Last_Course_WorkEntities())
                {
                    var entry = db.Entry(інформація_Про_Товар);

                    if (entry.State == EntityState.Detached)
                        db.додаткова_інформація_про_товар.Attach(інформація_Про_Товар);

                    db.додаткова_інформація_про_товар.Remove(інформація_Про_Товар);
                    db.SaveChanges();

                    PopulateDataGridInfoProduct();
                    Clear();

                    MessageBox.Show("Deleted Successfully");
                }
            }

            if (comboBox1.Text == "Замовлення" && MessageBox.Show("Are You Sure to Delete this Record ?", "EF CRUD Operation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (Last_Course_WorkEntities db = new Last_Course_WorkEntities())
                {
                    var entry = db.Entry(замовлення_особи);

                    if (entry.State == EntityState.Detached)
                        db.замовлення_особи_товару.Attach(замовлення_особи);

                    db.замовлення_особи_товару.Remove(замовлення_особи);
                    db.SaveChanges();

                    PopulateDataGridOrder();
                    Clear();

                    MessageBox.Show("Deleted Successfully");
                }
            }

            if (comboBox1.Text == "Client" && MessageBox.Show("Are You Sure to Delete this Record ?", "EF CRUD Operation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (Last_Course_WorkEntities db = new Last_Course_WorkEntities())
                {
                    var entry = db.Entry(спзіпю);

                    if (entry.State == EntityState.Detached)
                        db.система_повинна_зберігати_інформацію_про_юзера.Attach(спзіпю);

                    db.система_повинна_зберігати_інформацію_про_юзера.Remove(спзіпю);
                    db.SaveChanges();

                    PopulateDataGridClient();
                    Clear();

                    MessageBox.Show("Deleted Successfully");
                }
            }

            if (comboBox1.Text == "Оплата" && MessageBox.Show("Are You Sure to Delete this Record ?", "EF CRUD Operation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (Last_Course_WorkEntities db = new Last_Course_WorkEntities())
                {
                    var entry = db.Entry(вотпавтп);

                    if (entry.State == EntityState.Detached)
                        db.відслідкування_оплати_товару_покупцям_або_виплата_товару_посчальнику.Attach(вотпавтп);

                    db.відслідкування_оплати_товару_покупцям_або_виплата_товару_посчальнику.Remove(вотпавтп);
                    db.SaveChanges();

                    PopulateDataGridPayment();
                    Clear();

                    MessageBox.Show("Deleted Successfully");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {        
            if (comboBox1.Text == "Product")
            {
                if (Datacs.Login_Current == "Storekeeper")
                {
                    button2.Visible = true;
                }

                VisibleTextboxOn();
                VisibleLabelOn();

                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;

                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;

                label1.Text = "код";
                label2.Text = "категорія продукту";
                label3.Text = "ім'я";
                label4.Text = "одиниця ";
                label5.Text = "термін придатності";
                label6.Text = "ціна закупки";
                label7.Text = "ціна продажу ";
                label8.Text = "на складі";
                label9.Text = "id";

                PopulateDataGridProduct(); 
                

            }

           

            if (comboBox1.Text == "Доп_інфо")
            {
                if (Datacs.Login_Current == "Storekeeper")
                {
                    button2.Visible = false;
                }

                VisibleTextboxOn();
                VisibleLabelOn();


                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                
                label1.Text = "номкр документу";
                label2.Text = "операція";
                label3.Text = "id ";

                PopulateDataGridInfoProduct();

            }

            if (comboBox1.Text == "Замовлення")
            {
                VisibleTextboxOn();
                VisibleLabelOn();


                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;

                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;

                label1.Text = "кількість товару";
                label2.Text = "дата";
                label3.Text = "id";
                label4.Text = "info_product";
                label5.Text = "info_user";
                
                PopulateDataGridOrder();
            }

            if (comboBox1.Text == "Client")
            {
                VisibleTextboxOn();
                VisibleLabelOn();


                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;

                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;

                label1.Text = "ім'я";
                label2.Text = "код";
                label3.Text = "адреса";
                label4.Text = "категорія особи ";
                label5.Text = "знижка";
                label6.Text = "борг";
                label7.Text = "рахунок за місяць";
                label8.Text = "id";
                
                PopulateDataGridClient();
            }

            if (comboBox1.Text == "Оплата")
            {
                VisibleTextboxOn();
                VisibleLabelOn();


                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;

                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;

                label1.Text = "дата";
                label2.Text = "сума";
                label3.Text = "id";
                label4.Text = "info_user";
                label5.Text = "product_id ";               

                PopulateDataGridPayment();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {         
            if(comboBox1.Text == "Product")
            {
                if (dataGridView1.CurrentRow.Index != -1)
                {
                    товар.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);

                    using (Last_Course_WorkEntities db = new Last_Course_WorkEntities())
                    {
                        товар = db.Товар.Where(x => x.id == товар.id).FirstOrDefault();
                        textBox1.Text = товар.код;
                        textBox2.Text = товар.категорія_продукту;
                        textBox3.Text = товар.ім_я;
                        textBox4.Text = товар.одиниця;
                        textBox5.Text = товар.термін_придатності.ToString();
                        textBox6.Text = товар.ціна_закупки.ToString();
                        textBox7.Text = товар.ціна_продажу.ToString();
                        textBox8.Text = товар.на_складі.ToString();
                        textBox9.Text = товар.id.ToString();
                    }

                    button1.Text = "update";
                    button2.Enabled = true;
                }
            }        

            if (comboBox1.Text == "Доп_інфо")
            {
                if (dataGridView1.CurrentRow.Index != -1)
                {
                    інформація_Про_Товар.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);

                    using (Last_Course_WorkEntities db = new Last_Course_WorkEntities())
                    {
                        інформація_Про_Товар = db.додаткова_інформація_про_товар.Where(x => x.id == інформація_Про_Товар.id).FirstOrDefault();
                        textBox1.Text = інформація_Про_Товар.номер_документу.ToString();
                        textBox2.Text = інформація_Про_Товар.операція.ToString();
                        textBox3.Text = інформація_Про_Товар.id.ToString();                  
                    }

                    button1.Text = "update";
                    button2.Enabled = true;
                }
            }

            if (comboBox1.Text == "Client")
            {
                if (dataGridView1.CurrentRow.Index != -1)
                {
                    спзіпю.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);

                    using (Last_Course_WorkEntities db = new Last_Course_WorkEntities())
                    {
                        спзіпю = db.система_повинна_зберігати_інформацію_про_юзера.Where(x => x.id == спзіпю.id).FirstOrDefault();
                        textBox1.Text = спзіпю.ім_я;
                        textBox2.Text = спзіпю.код.ToString();
                        textBox3.Text = спзіпю.адреса;
                        textBox4.Text = спзіпю.категорія_особи;
                        textBox5.Text = спзіпю.знижка.ToString();
                        textBox6.Text = спзіпю.борг.ToString();
                        textBox7.Text = спзіпю.рахунок_за_місяць.ToString();
                        textBox8.Text = спзіпю.id.ToString();
                    }

                    button1.Text = "update";
                    button2.Enabled = true;
                }
            }

            if (comboBox1.Text == "Замовлення")
            {
                замовлення_особи.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);

                using (Last_Course_WorkEntities db = new Last_Course_WorkEntities())
                {
                    замовлення_особи = db.замовлення_особи_товару.Where(x => x.id == замовлення_особи.id).FirstOrDefault();
                    textBox1.Text = замовлення_особи.кількість_товару.ToString();
                    textBox2.Text = замовлення_особи.дата.ToString();
                    textBox3.Text = замовлення_особи.id.ToString();
                    textBox4.Text = замовлення_особи.new_info_product_id.ToString();
                    textBox5.Text = замовлення_особи.info_user_id.ToString();
                }

                button1.Text = "update";
                button2.Enabled = true;
            }

            if (comboBox1.Text == "Оплата")
            {
                if (dataGridView1.CurrentRow.Index != -1)
                {
                    вотпавтп.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);

                    using (Last_Course_WorkEntities db = new Last_Course_WorkEntities())
                    {
                        вотпавтп = db.відслідкування_оплати_товару_покупцям_або_виплата_товару_посчальнику.Where(x => x.id == вотпавтп.id).FirstOrDefault();
                        textBox1.Text = вотпавтп.дата.ToString();
                        textBox2.Text = вотпавтп.сума.ToString();
                        textBox3.Text = вотпавтп.id.ToString();
                        textBox4.Text = вотпавтп.info_user_id.ToString();
                        textBox5.Text = вотпавтп.product_id.ToString();
                    }

                    
                    button1.Text = "update";
                    button2.Enabled = true;
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.товарTableAdapter.FillBy(this.last_Course_WorkDataSet.Товар);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-QL6KBJM\SQLEXPRESS;Initial Catalog=Last_Course_Work;Integrated Security=True";

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conn;
            sqlCommand.CommandText = "select * from Товар where [категорія продукту] = " +"'"+ comboBox2.Text+"'";

            DataTable dt = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-QL6KBJM\SQLEXPRESS;Initial Catalog=Last_Course_Work;Integrated Security=True";

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conn;
            sqlCommand.CommandText = "select [система повинна зберігати інформацію про юзера].[ім'я] as 'імя постачальника', Товар.[ім'я], [замовлення особи товару].[кількість товару] from [замовлення особи товару] inner join [система повинна зберігати інформацію про юзера] on [замовлення особи товару].info_user_id = [система повинна зберігати інформацію про юзера].id inner join Товар on [замовлення особи товару].new_info_product_id = Товар.id where [система повинна зберігати інформацію про юзера].[категорія особи] = 'постачальник'";

            DataTable dt = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-QL6KBJM\SQLEXPRESS;Initial Catalog=Last_Course_Work;Integrated Security=True";

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conn;
            sqlCommand.CommandText = "declare @seller float declare @client float set @seller = (select sum(Товар.[ціна продажу]*[замовлення особи товару].[кількість товару]) from [замовлення особи товару] inner join [система повинна зберігати інформацію про юзера] on [замовлення особи товару].info_user_id = [система повинна зберігати інформацію про юзера].id inner join Товар on [замовлення особи товару].new_info_product_id = Товар.id where [система повинна зберігати інформацію про юзера].[категорія особи] = 'постачальник' and [замовлення особи товару].дата BETWEEN (GETDATE() - DAY(30) ) and GETDATE()) set @client = (select sum(Товар.[ціна продажу]*[замовлення особи товару].[кількість товару]) from [замовлення особи товару] inner join [система повинна зберігати інформацію про юзера] on [замовлення особи товару].info_user_id = [система повинна зберігати інформацію про юзера].id inner join Товар on [замовлення особи товару].new_info_product_id = Товар.id  where [система повинна зберігати інформацію про юзера].[категорія особи] = 'покупець' and [замовлення особи товару].дата BETWEEN (GETDATE() - DAY(30) ) and GETDATE() ) select @seller as 'сума приходу товару', @client as 'сума продаж товару'";
            DataTable dt = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;


            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form2 menu = new Form2();
            this.Hide();
            menu.ShowDialog();
            this.Close();
        }
    }
}
