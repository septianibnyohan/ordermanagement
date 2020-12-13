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
    public partial class frmQty : Form
    {
        FormOrder _frmOrder;
        int _product_id;
        string _product_name;
        int _product_price;

        public frmQty(FormOrder frm)
        {
            InitializeComponent();
            this._frmOrder = frm;
        }

        

        public void ProductDetails(int product_id, string product_name, int product_price)
        {
            _product_id = product_id;
            _product_name = product_name;
            _product_price = product_price;
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == 13) && (txtQty.Text != String.Empty))
            {
                int qty = Convert.ToInt32(txtQty.Text);
                int total_price = _product_price * qty;

                _frmOrder.gridOrder.Rows.Add(_product_id, _product_name, _product_price, qty, total_price);
                this.Dispose();
            }
        }
    }
}
