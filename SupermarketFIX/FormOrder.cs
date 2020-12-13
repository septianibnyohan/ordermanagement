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
                    var order = (from ord in context.Orders where ord.TransNo.Contains(sdate) 
                                 orderby ord.Id descending select ord).FirstOrDefault();
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
                var price = Convert.ToInt32(gridProduct.Rows[e.RowIndex].Cells[3].Value.ToString());

                //gridOrder.Rows.Add(product_id, item_name, 0, 0, 0);
                frmQty frm = new frmQty(this);
                frm.ProductDetails(product_id, item_name, price);
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
                    gridProduct.Rows.Add(product.ProductID, product.itemName, product.Categories, product.Price, "Select");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var transno = lblTransno.Text;
            var customerid = gridCustomer.CurrentRow.Cells[0];
            using (var context = new SuperEntities())
            {
                foreach (DataGridViewRow row in gridOrder.Rows)
                {
                    if (row.IsNewRow) continue;
                    var product_id = row.Cells[0].Value.ToString();
                    var item_name = row.Cells[1].Value.ToString();
                    var price = row.Cells[2].Value.ToString();
                    var quantity = row.Cells[3].Value.ToString();
                    var price_total = row.Cells[4].Value.ToString();

                    var order = new Order();
                    order.TransNo = transno;
                    order.ProductId = int.Parse(product_id);
                    order.Price = int.Parse(price);
                    order.Qty = int.Parse(quantity);
                    order.Total = int.Parse(price_total);
                    order.SDate = DateTime.Now;

                    context.Orders.Add(order);
                    context.SaveChanges();
                }
                
            }

            gridOrder.Rows.Clear();
            gridOrder.Refresh();
            GetTransNo();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow row in gridOrder.Rows)
            //{
            //    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[5];

            //    if (chk.Value == chk.TrueValue)
            //    {
            //        gridOrder.Rows.Remove(row);
            //    }
            //}

            for (int i = 0; i < gridOrder.Rows.Count; i++)
            {

                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)gridOrder.Rows[i].Cells[5];

                if (chk.Value != null)
                {
                    DataGridViewRow dgvDelRow = gridOrder.Rows[i];
                    gridOrder.Rows.RemoveAt(i);
                }
            }

            gridOrder.Refresh();

        }
            
    }
}
