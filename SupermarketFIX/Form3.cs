using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SupermarketFIX
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Login Application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new SuperEntities())
            {
                var user = from login in context.tbl_Login
                           where login.username.Equals(txtUsername.Text.Trim().ToLower()) &&
                            login.password.Equals(txtPassword.Text.Trim())
                           select login;

                if (user.Count() > 0)
                {
                    Form1 objForm1 = new Form1();
                    this.Hide();
                    objForm1.Show();
                }
                else
                {
                    MessageBox.Show("Check your username and password");
                }
            }
            //SqlConnection sqlcon = new SqlConnection(@"Data Source=MIILENOVO\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");
            //string query = "Select*from tbl_Login where username ='" + txtUsername.Text.Trim() + "' and password = '" + txtPassword.Text.Trim() + "'";
            //SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            //DataTable dtbl = new DataTable();
            //sda.Fill(dtbl);
            //if (dtbl.Rows.Count == 1)
            //{
            //    Form1 objForm1 = new Form1();
            //    this.Hide();
            //    objForm1.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Check your username and password");
            //}
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
