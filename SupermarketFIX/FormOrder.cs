using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupermarketFIX
{
    public partial class FormOrder : Form
    {
        string stitle = "Supermarket System";

        public FormOrder()
        {
            InitializeComponent();
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            GetTransNo();
            LoadRecords();
        }

        private void GetTransNo()
        {
            try
            {
                string sdate = DateTime.Now.ToString("yyyyMMdd");
                string transno;
                int count;
                using (var context = new SuperEntities())
                {
                    var order = (from ord in context.Orders where ord.TransNo.Contains(sdate) select ord).FirstOrDefault();
                    if (order != null)
                    {
                        transno = order.TransNo;
                        count = int.Parse(transno.Substring(8, 4));
                        lblTransno.Text = sdate + (count + 1);
                    }
                    else
                    {
                        transno = sdate + "1001";
                        lblTransno.Text = transno;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, stitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = gridProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Action")
            {
                var product_id = Convert.ToInt32(gridProduct.Rows[e.RowIndex].Cells[0].Value.ToString());
                var item_name = gridProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                var category = gridProduct.Rows[e.RowIndex].Cells[2].Value.ToString();

                //gridOrder.Rows.Add(product_id, item_name, 0, 0, 0);
                frmQty frm = new frmQty(this);
                frm.ProductDetails(product_id, item_name, 1000);
                frm.ShowDialog();
            }
            using (var context = new SuperEntities())
            {

            }
        }

        public void LoadRecords()
        {
            using (var context = new SuperEntities())
            {
                gridCustomer.Rows.Clear();
                
                var customers = (from s in context.Customers select s);
                var products = (from p in context.ProductInfo_Tab select p);

                //int index = 0;
                foreach (var customer in customers)
                {
                    //++index;
                    gridCustomer.Rows.Add(customer.CustomerID, customer.FullName, customer.Email, customer.Address);
                }

                //index = 0;
                foreach (var product in products)
                {
                    //++index;
                    gridProduct.Rows.Add(product.ProductID, product.itemName, product.Categories, "Select");
                }
            }
        }
        
    }
}
