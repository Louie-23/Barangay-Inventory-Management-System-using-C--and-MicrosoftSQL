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
    public partial class UserOrderModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mark Louie Jamco\Documents\dBIMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        int qty = 0;

        public UserOrderModuleForm()
        {
            InitializeComponent();
            LoadUserProduct();
            txtUserCId.Text = UserLoginForm.CId;
            txtUserCName.Text = UserLoginForm.CName;
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void LoadUserProduct()
        {
            int i = 0;
            dgvUserProduct.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbProduct WHERE CONCAT(pid, pname, pprice, pdescription, pcategory) LIKE '%" + txtSearchProd.Text + "%'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvUserProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void txtSearchProd_TextChanged(object sender, EventArgs e)
        {
            LoadUserProduct();
        }

        private void UDUserQty_ValueChanged(object sender, EventArgs e)
        {
            GetQty();

            if (Convert.ToInt32(UDUserQty.Value) > qty)
            {
                MessageBox.Show("Instock quantity is not enough!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UDUserQty.Value = qty;
                return;
            }
            if (Convert.ToInt32(UDUserQty.Value) > 0)
            {
                int total = Convert.ToInt32(txtUserPrice.Text) * Convert.ToInt32(UDUserQty.Value);
                txtUserTotal.Text = total.ToString();
            }
        }
        public void GetQty()
        {
            cm = new SqlCommand("SELECT pqty FROM tbProduct WHERE pid= '" + txtUserPid.Text + "'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                qty = Convert.ToInt32(dr[0].ToString());
            }

            dr.Close();
            con.Close();
        }

        private void dgvUserProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUserPid.Text = dgvUserProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtUserPName.Text = dgvUserProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtUserPrice.Text = dgvUserProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnUserInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserPid.Text == "")
                {
                    MessageBox.Show("Please select product!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Convert.ToInt32(UDUserQty.Value) == 0)
                {
                    MessageBox.Show("Please select quantity!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Are you sure you want to insert this activity?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbOrder(odate, pid, cid, qty, price, total, rdate, status)VALUES(@odate, @pid, @cid, @qty, @price, @total, @rdate, @status)", con);
                    cm.Parameters.AddWithValue("@odate", DateTime.Now);
                    cm.Parameters.AddWithValue("@pid", Convert.ToInt32(txtUserPid.Text));
                    cm.Parameters.AddWithValue("@cid", Convert.ToInt32(txtUserCId.Text));
                    cm.Parameters.AddWithValue("@qty", Convert.ToInt32(UDUserQty.Value));
                    cm.Parameters.AddWithValue("@price", Convert.ToInt32(txtUserPrice.Text));
                    cm.Parameters.AddWithValue("@total", Convert.ToInt32(txtUserTotal.Text));
                    cm.Parameters.AddWithValue("@rdate", dtUserOrder.Value);
                    cm.Parameters.AddWithValue("@status", "Waiting");
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Activity has been successfully inserted.");

                    cm = new SqlCommand("UPDATE tbProduct SET pqty=(pqty-@pqty) WHERE pid LIKE '" + txtUserPid.Text + "' ", con);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt32(UDUserQty.Text));

                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();



                    cm = new SqlCommand("INSERT INTO tblog(loginfo, logdate)VALUES(@loginfo, @logdate)", con);
                    cm.Parameters.AddWithValue("@loginfo", ("NOTE: Client  \"" + UserLoginForm.CName.ToString() + " \"  ADDED a request . Please Check the Waiting List for Approval"));
                    cm.Parameters.AddWithValue("@logdate", DateTime.Now);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();


                    Clear();
                    LoadUserProduct();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        { 
            txtUserPid.Clear();
            txtUserPName.Clear();

            txtUserPrice.Clear();
            UDUserQty.Value = 0;
            txtUserTotal.Clear();
            dtUserOrder.Value = DateTime.Now.AddSeconds(1);
        }

        private void dtOrder_ValueChanged(object sender, EventArgs e)
        {
            dtUserOrder.ValueChanged -= dtOrder_ValueChanged;

            OrderForm orderform = new OrderForm();

            DateTime selectedDate = dtUserOrder.Value;
            DateTime currentDate = DateTime.Now;

           
            DateTime minDate = currentDate;
            DateTime maxDate = currentDate.AddDays(Convert.ToInt32(orderform.maxday));

       
            if (selectedDate < minDate)
            {
                dtUserOrder.Value = minDate;
                MessageBox.Show("You can't select Time less than today.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (selectedDate > maxDate)
            {
                dtUserOrder.Value = maxDate;
                MessageBox.Show("Maximum allowed time is "+ orderform.maxday.ToString() +" day(s).", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            dtUserOrder.ValueChanged += dtOrder_ValueChanged;
        }
    }
}
