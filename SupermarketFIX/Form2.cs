using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SupermarketFIX
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SuperEntities db = new SuperEntities();

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int prodid = int.Parse(textBox1.Text);
            string itemame = textBox2.Text, categories = comboBox1.Text;
            DateTime expirydate = DateTime.Parse(dateTimePicker1.Text);

            var st = new ProductInfo_Tab
            {
                ProductID = prodid,
                itemName = itemame,
                Categories = categories,
                insertDate = DateTime.Now,
                ExpiryDate = expirydate,
            };

            db.ProductInfo_Tab.Add(st);
            db.SaveChanges();
            MessageBox.Show("Succesfully Inserted");
            loadData();
        }
        // adding method to load data in datagridview
        void loadData()
        {
            var st = from s in db.ProductInfo_Tab select s;
            dataGridView1.DataSource = st.ToList();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Update 
            string itemame = textBox2.Text, categories = comboBox1.Text;
            DateTime expirydate = DateTime.Parse(dateTimePicker1.Text);
            var product_id = int.Parse(textBox1.Text);
            var st = (from s in db.ProductInfo_Tab where s.ProductID == product_id select s).First();
            st.itemName = itemame;
            st.Categories = categories;
            st.UpdateDate = DateTime.Now;
            st.ExpiryDate = expirydate;
            db.SaveChanges();
            MessageBox.Show("Successfully Updated.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var product_id = int.Parse(textBox1.Text);
            var st = from s in db.ProductInfo_Tab where s.ProductID == product_id select s;
            dataGridView1.DataSource = st.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Delete
            if (MessageBox.Show("Are you sure to delete ?", "Delete record", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var product_id = int.Parse(textBox1.Text);

                var st = (from s in db.ProductInfo_Tab where s.ProductID == product_id select s).First();
                db.ProductInfo_Tab.Remove(st);
                db.SaveChanges();
                MessageBox.Show("Successfully deleted.");
                loadData();
            }
        }
    }
}
