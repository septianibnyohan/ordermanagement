using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SupermarketFIX
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                if(string.IsNullOrEmpty(txtSearch.Text))
                {
                    dataGridView1.DataSource = customerBindingSource;
                }
                else
                {
                    var query = from o in customerBindingSource.DataSource as List<Customer>
                                where o.CustomerID == txtSearch.Text || o.FullName.Contains(txtSearch.Text) || o.Email == txtSearch.Text || o.Address.Contains(txtSearch.Text)
                                select o;
                    dataGridView1.DataSource = query.ToList();

                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                //panel1.Enabled = true;
                //txtCustomerID.Focus();
                //Customer c = new Customer();
                //supermarket.Customers.Add(c);
                //customerBindingSource.MoveLast();

                using (var supermarket = new SuperEntities())
                {
                    var customer_id = txtCustomerID.Text;
                    var fullname = txtFullName.Text;
                    var email = txtEmail.Text;
                    var address = txtAddress.Text;

                    var st = new SupermarketFIX.Customer
                    {
                        CustomerID = customer_id,
                        FullName = fullname,
                        Email = email,
                        Address = address
                    };

                    supermarket.Customers.Add(st);
                    supermarket.SaveChanges();
                    MessageBox.Show("Succesfully Inserted");
                    LoadData();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete ?", "Delete record", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var supermarket = new SuperEntities())
                {
                    var customer_id = txtCustomerID.Text;
                    var fullname = txtFullName.Text;
                    var email = txtEmail.Text;
                    var address = txtAddress.Text;

                    var st = (from s in supermarket.Customers where s.CustomerID == customer_id select s).First();
                    supermarket.Customers.Remove(st);
                    supermarket.SaveChanges();
                    MessageBox.Show("Successfully deleted.");
                    LoadData();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            txtCustomerID.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            using (var supermarket = new SuperEntities())
            {
                panel1.Enabled = false;
                customerBindingSource.ResetBindings(false);
                foreach (DbEntityEntry entry in supermarket.ChangeTracker.Entries())
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.State = System.Data.Entity.EntityState.Detached;
                            break;
                        case EntityState.Modified:
                            entry.State = EntityState.Unchanged;
                            break;
                        case EntityState.Deleted:
                            entry.Reload();
                            break;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var supermarket = new SuperEntities())
                {
                    customerBindingSource.EndEdit();
                    supermarket.SaveChangesAsync();
                    panel1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show (ex.Message,"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                customerBindingSource.ResetBindings(false);

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (var supermarket = new SuperEntities())
                {
                    var customer_id = txtCustomerID.Text;
                    var st = from s in supermarket.Customers where s.CustomerID == customer_id select s;
                    dataGridView1.DataSource = st.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                customerBindingSource.ResetBindings(false);

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Update 
            var customer_id = txtCustomerID.Text;
            var fullname = txtFullName.Text;
            var email = txtEmail.Text;
            var address = txtAddress.Text;
            using (var supermarket = new SuperEntities())
            {
                var st = (from s in supermarket.Customers where s.CustomerID == customer_id select s).First();
                st.CustomerID = customer_id;
                st.FullName = fullname;
                st.Email = email;
                st.Address = address;
                supermarket.SaveChanges();
                MessageBox.Show("Successfully Updated.");
                LoadData();
            }
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            //panel1.Enabled = false;
            using (var supermarket = new SuperEntities())
            {
                customerBindingSource.DataSource = supermarket.Customers.ToList();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            using (var supermarket = new SuperEntities())
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (MessageBox.Show("Are you sure want to delete this record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        supermarket.Customers.Remove(customerBindingSource.Current as Customer);
                        customerBindingSource.RemoveCurrent();
                    }
                }
            }
        }

        private void LoadData()
        {
            using (var supermarket = new SuperEntities())
            {
                customerBindingSource.DataSource = supermarket.Customers.ToList();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (var db = new SuperEntities())
            {
                var list_data = (from s in db.Customers select s);

                var csv = new StringBuilder();
                var newLine = string.Format("{0},{1},{2},{3}", "Customer ID", "Fullname", "Email", "Address");
                csv.AppendLine(newLine);

                foreach (var data in list_data)
                {
                    var newLine2 = string.Format("{0},{1},{2},{3}", data.CustomerID, data.FullName, data.Email, data.Address);
                    csv.AppendLine(newLine2);
                }

                File.WriteAllText("customerresult.csv", csv.ToString());
            }
            
        }
    }
}
