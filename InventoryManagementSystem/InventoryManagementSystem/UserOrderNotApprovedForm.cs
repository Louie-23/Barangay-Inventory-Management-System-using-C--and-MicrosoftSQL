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
    public partial class UserOrderNotApprovedForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mark Louie Jamco\Documents\dBIMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public UserOrderNotApprovedForm()
        {
            InitializeComponent();
            LoadUserOrder();
        }
        public void LoadUserOrder()
        {
            double total = 0;
            int i = 0;
            dgvUserOrder.Rows.Clear();
            cm = new SqlCommand("SELECT orderid, odate, O.pid, P.pname, qty, price, total, rdate, status FROM tbOrder AS O JOIN tbCustomer AS C ON O.cid=C.cid JOIN tbProduct AS P ON O.pid=P.pid WHERE O.cid = @cid AND CONCAT(orderid, odate, O.pid, P.pname, qty, price, status) LIKE '%" + txtSearch.Text + "%'AND status = @status", con);
            cm.Parameters.AddWithValue("@cid", UserLoginForm.CId);
            cm.Parameters.AddWithValue("@status", "Not Approved");
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvUserOrder.Rows.Add(i, dr[0].ToString(), Convert.ToDateTime(dr[1].ToString()).ToString("MMM d, yyyy | h:mm tt"), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), Convert.ToDateTime(dr[7].ToString()).ToString("MMM d, yyyy | h:mm tt"), dr[8].ToString());
                total += Convert.ToInt32(dr[6].ToString());
            }
            dr.Close();
            con.Close();

            lblQty.Text = i.ToString();
            lblTotal.Text = total.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadUserOrder();
        }

        private void dgvUserOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvUserOrder.Columns[e.ColumnIndex].Name;

            if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this activity?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbOrder WHERE orderid LIKE '" + dgvUserOrder.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Activity has been successfully deleted!");
                }
            }
            LoadUserOrder();
        }
    }
}
