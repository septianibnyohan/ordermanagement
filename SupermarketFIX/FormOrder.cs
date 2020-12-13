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
        public FormOrder()
        {
            InitializeComponent();
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void gridOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = gridProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Action")
            {
                var product_id = gridProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
                var item_name = gridProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                var category = gridProduct.Rows[e.RowIndex].Cells[2].Value.ToString();

                gridOrder.Rows.Add(product_id, item_name, 0, 0, 0);
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
