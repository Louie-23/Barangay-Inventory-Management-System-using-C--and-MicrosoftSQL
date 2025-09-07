using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class OrderModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mark Louie Jamco\Documents\dBIMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        int qty = 0;

        public OrderModuleForm()
        {
            InitializeComponent();
            LoadCustomer();
            LoadProduct();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }
        public void LoadCustomer()
        {
            int i = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT cid, cname FROM tbCustomer WHERE CONCAT(cid, cname) LIKE '%" + txtSearchCust.Text + "%'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            con.Close();
        }

        public void LoadProduct()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbProduct WHERE CONCAT(pid, pname, pprice, pdescription, pcategory) LIKE '%" + txtSearchProd.Text + "%'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void txtSearchCust_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void txtSearchProd_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            GetQty();

            if (Convert.ToInt32(UDQty.Value) > qty)
            {
                MessageBox.Show("Instock quantity is not enough!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UDQty.Value = qty;
                return;
            }
            if (Convert.ToInt32(UDQty.Value) > 0)
            {
                int total = Convert.ToInt32(txtPrice.Text) * Convert.ToInt32(UDQty.Value);
                txtTotal.Text = total.ToString();
            }
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCId.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCName.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPid.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCId.Text == "")
                {
                    MessageBox.Show("Please select Client!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtPid.Text == "")
                {
                    MessageBox.Show("Please select product!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Convert.ToInt32(UDQty.Value) == 0)
                {
                    MessageBox.Show("Please select quantity!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Are you sure you want to insert this activity?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("INSERT INTO tbOrder(odate, pid, cid, qty, price, total, rdate, status)VALUES(@odate, @pid, @cid, @qty, @price, @total, @rdate, @status)", con);
                    cm.Parameters.AddWithValue("@odate", DateTime.Now);
                    cm.Parameters.AddWithValue("@pid", Convert.ToInt32(txtPid.Text));
                    cm.Parameters.AddWithValue("@cid", Convert.ToInt32(txtCId.Text));
                    cm.Parameters.AddWithValue("@qty", Convert.ToInt32(UDQty.Value));
                    cm.Parameters.AddWithValue("@price", Convert.ToInt32(txtPrice.Text));
                    cm.Parameters.AddWithValue("@total", Convert.ToInt32(txtTotal.Text));
                    cm.Parameters.AddWithValue("@rdate", dtOrder.Value);
                    cm.Parameters.AddWithValue("@status", "Waiting");
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Activity has been successfully inserted.");

                    cm = new SqlCommand("UPDATE tbProduct SET pqty=(pqty-@pqty) WHERE pid LIKE '" + txtPid.Text + "' ", con);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt32(UDQty.Text));

                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();




                    cm = new SqlCommand("INSERT INTO tblog(loginfo, logdate)VALUES(@loginfo, @logdate)", con);
                    cm.Parameters.AddWithValue("@loginfo", ("NOTE: Admin  \" " + LoginForm.adminfullname.ToString() + "\" ADDED a Client  \" " + txtCName.Text + "\"  request. Please Check the Waiting List for Approval"));
                    cm.Parameters.AddWithValue("@logdate", DateTime.Now);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();



                    Clear();
                    LoadProduct();




                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Clear()
        {
            txtCId.Clear();
            txtCName.Clear();

            txtPid.Clear();
            txtPName.Clear();

            txtPrice.Clear();
            UDQty.Value = 0;
            txtTotal.Clear();
            dtOrder.Value = DateTime.Now.AddSeconds(1);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void GetQty()
        {
            cm = new SqlCommand("SELECT pqty FROM tbProduct WHERE pid= '" + txtPid.Text + "'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                qty = Convert.ToInt32(dr[0].ToString());
            }

            dr.Close();
            con.Close();
        }

        private void dtOrder_ValueChanged(object sender, EventArgs e)
        {
            dtOrder.ValueChanged -= dtOrder_ValueChanged;


            OrderForm orderform = new OrderForm();

            DateTime selectedDate = dtOrder.Value;
            DateTime currentDate = DateTime.Now;


            DateTime minDate = currentDate;
            DateTime maxDate = currentDate.AddDays(Convert.ToInt32(orderform.maxday));


            if (selectedDate < minDate)
            {
                dtOrder.Value = minDate;
                MessageBox.Show("You can't select Time less than today.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (selectedDate > maxDate)
            {
                dtOrder.Value = maxDate;
                MessageBox.Show("Maximum allowed time is " + orderform.maxday.ToString() + " day(s).", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            dtOrder.ValueChanged += dtOrder_ValueChanged;
        }
    }
}
