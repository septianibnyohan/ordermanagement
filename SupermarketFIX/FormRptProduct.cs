using SupermarketFIX.ReportGenerator.CrystalReport;
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
    public partial class FormRptProduct : Form
    {
        public FormRptProduct()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            var timespan = new TimeSpan(23, 59, 59);
            var expired = dtmExpired.Value;
            expired = expired.Date + timespan;

            //Declare Datatable
            DataTable order = new DataTable();
            order.Columns.Add("ProductID", typeof(string));
            order.Columns.Add("ItemName", typeof(string));
            order.Columns.Add("Price", typeof(int));
            order.Columns.Add("Category", typeof(string));
            order.Columns.Add("ExpiryDate", typeof(DateTime));;

            //Insert Test Rows
            using (var context = new SuperEntities())
            {
                var list_product = context.ProductInfo_Tab.Where(o => o.ExpiryDate <= expired).ToList();
                foreach (var data in list_product)
                {
                    //var product_name = context.ProductInfo_Tab.FirstOrDefault(o => o.ProductID == data.ProductId).itemName;
                    //var price_total = data.Price * data.Qty;
                    order.Rows.Add(data.ProductID, data.itemName, data.Price, data.Categories, data.ExpiryDate);
                }
                //order.Rows.Add(1, "1", "Satu", 10000, 1, 100000, DateTime.Now);
                //order.Rows.Add(2, "2", "Dua", 10003, 1, 100000, DateTime.Now);
                //order.Rows.Add(3, "3", "Tiga", 10002, 1, 100000, DateTime.Now);
                //order.Rows.Add(4, "4", "Empat", 10004, 1, 100000, DateTime.Now);
                //order.Rows.Add(5, "5", "Lima", 100005, 1, 100000, DateTime.Now);
            }

            crptProduct crpt = new crptProduct();
            crpt.Database.Tables["product"].SetDataSource(order);
            crvProduct.ReportSource = null;
            crvProduct.ReportSource = crpt;
        }
    }
}
