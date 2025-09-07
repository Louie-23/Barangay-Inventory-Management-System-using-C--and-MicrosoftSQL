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
    public partial class OrderReturnedForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mark Louie Jamco\Documents\dBIMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public OrderReturnedForm()
        {
            InitializeComponent();
            LoadOrder();
        }
        public void LoadOrder()
        {
            double total = 0;
            int i = 0;
            dgvOrder.Rows.Clear();
            cm = new SqlCommand("SELECT orderid, odate, O.pid, P.pname, O.cid, C.cname, qty, price, total, rdate, status FROM tbOrder AS O JOIN tbCustomer AS C ON O.cid=C.cid JOIN tbProduct AS P ON O.pid=P.pid WHERE CONCAT(orderid, odate, O.pid, P.pname, O.cid, C.cname, qty, price) LIKE '%" + txtSearch.Text + "%'AND status = @status", con);
            cm.Parameters.AddWithValue("@status", "Returned");
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvOrder.Rows.Add(i, dr[0].ToString(), Convert.ToDateTime(dr[1].ToString()).ToString("MMM d, yyyy | h:mm tt"), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), Convert.ToDateTime(dr[9].ToString()).ToString("MMM d, yyyy | h:mm tt"), dr[10].ToString());
                total += Convert.ToInt32(dr[8].ToString());
            }
            dr.Close();
            con.Close();

            lblQty.Text = i.ToString();
            lblTotal.Text = total.ToString();
        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvOrder.Columns[e.ColumnIndex].Name;

            if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this activity?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbOrder WHERE orderid LIKE '" + dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Activity has been successfully deleted!");



                    cm = new SqlCommand("INSERT INTO tblog(loginfo, logdate)VALUES(@loginfo, @logdate)", con);
                    cm.Parameters.AddWithValue("@loginfo", ("Admin  \" " + LoginForm.adminfullname.ToString() + "\"  has been DELETED the RETURNED Client  \" " + dgvOrder.Rows[e.RowIndex].Cells[6].Value.ToString() + "\"  request with Activity ID #" + dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString()));
                    cm.Parameters.AddWithValue("@logdate", DateTime.Now);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();

                }
            }
            else if (colName == "Status")
            {
                DialogResult result = MessageBox.Show("Do you Want to Return to Approved this Activity?", "Return to Approve Activity", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("UPDATE tbOrder SET status =@status WHERE orderid LIKE @orderid", con);
                    cm.Parameters.AddWithValue("@orderid", dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString());
                    cm.Parameters.AddWithValue("@status", "Approved");
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Activity has been set to Approved!");

                    cm = new SqlCommand("UPDATE tbProduct SET pqty=(pqty-@pqty) WHERE pid LIKE '" + dgvOrder.Rows[e.RowIndex].Cells[3].Value.ToString() + "' ", con);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt32(dgvOrder.Rows[e.RowIndex].Cells[7].Value.ToString()));
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();

                    cm = new SqlCommand("INSERT INTO tblog(loginfo, logdate)VALUES(@loginfo, @logdate)", con);
                    cm.Parameters.AddWithValue("@loginfo", ("Admin  \" " + LoginForm.adminfullname.ToString() + "\"  has been MOVED RETURNED Client  \" " + dgvOrder.Rows[e.RowIndex].Cells[6].Value.ToString() + "\"  request to APPROVED LIST with Activity ID #" + dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString()));
                    cm.Parameters.AddWithValue("@logdate", DateTime.Now);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                }

            }
            LoadOrder();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadOrder();
        }
    }
}
