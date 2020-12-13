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
    public partial class FormRptList : Form
    {
        public FormRptList()
        {
            InitializeComponent();
        }

        private void crvList_Load(object sender, EventArgs e)
        {
            //Declare Datatable
            DataTable order = new DataTable();
            order.Columns.Add("TransNo", typeof(string));
            order.Columns.Add("ProductId", typeof(string));
            order.Columns.Add("ProductName", typeof(string));
            order.Columns.Add("Price", typeof(int));
            order.Columns.Add("Quantity", typeof(int));
            order.Columns.Add("Total", typeof(int));
            order.Columns.Add("Tanggal", typeof(DateTime));

            //Insert Test Rows
            using (var context = new SuperEntities())
            {
                var list_order = context.Orders.ToList();
                foreach (var data in list_order)
                {
                    var product_name = context.ProductInfo_Tab.FirstOrDefault(o => o.ProductID == data.ProductId).itemName;
                    var price_total = data.Price * data.Qty;
                    order.Rows.Add(data.TransNo, data.ProductId, product_name, data.Price, data.Qty, price_total, data.SDate);
                }
                //order.Rows.Add(1, "1", "Satu", 10000, 1, 100000, DateTime.Now);
                //order.Rows.Add(2, "2", "Dua", 10003, 1, 100000, DateTime.Now);
                //order.Rows.Add(3, "3", "Tiga", 10002, 1, 100000, DateTime.Now);
                //order.Rows.Add(4, "4", "Empat", 10004, 1, 100000, DateTime.Now);
                //order.Rows.Add(5, "5", "Lima", 100005, 1, 100000, DateTime.Now);
            }

            crptOrderList crpt = new crptOrderList();
            crpt.Database.Tables["Order"].SetDataSource(order);
            crvList.ReportSource = null;
            crvList.ReportSource = crpt;
        }
    }
}
