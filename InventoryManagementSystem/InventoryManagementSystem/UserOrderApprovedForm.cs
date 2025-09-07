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
    public partial class UserOrderApprovedForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mark Louie Jamco\Documents\dBIMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public UserOrderApprovedForm()
        {
            InitializeComponent();
            LoadUserOrder();


            OrderApprovedForm orderapprovedform = new OrderApprovedForm();
            orderapprovedform.calculateTime();
        }
        public void LoadUserOrder()
        {
            double total = 0;
            int i = 0;
            dgvUserOrder.Rows.Clear();
            cm = new SqlCommand("SELECT orderid, odate, O.pid, P.pname, qty, price, total, rdate, status FROM tbOrder AS O JOIN tbCustomer AS C ON O.cid=C.cid JOIN tbProduct AS P ON O.pid=P.pid WHERE O.cid = @cid AND CONCAT(orderid, odate, O.pid, P.pname, qty, price, status) LIKE '%" + txtSearch.Text + "%'AND status = @status", con);
            cm.Parameters.AddWithValue("@cid", UserLoginForm.CId);
            cm.Parameters.AddWithValue("@status", "Approved");
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;

                DateTime requiredDate = Convert.ToDateTime(dr[7]);
                TimeSpan remainingTime = requiredDate - DateTime.Now;
                string remainingTimeString = remainingTime.TotalMilliseconds > 0 ? $"{remainingTime.Days} days, {remainingTime.Hours} hours, {remainingTime.Minutes} minutes" : "Expired";


                dgvUserOrder.Rows.Add(i, dr[0].ToString(), Convert.ToDateTime(dr[1].ToString()).ToString("MMM d, yyyy | h:mm tt"), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), Convert.ToDateTime(dr[7].ToString()).ToString("MMM d, yyyy | h:mm tt"), dr[8].ToString(), remainingTimeString);
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

            if (colName == "Return")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to Return Items?", "Return Items", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("UPDATE tbOrder SET status = @status WHERE orderid LIKE @orderid", con);
                    cm.Parameters.AddWithValue("@orderid", dgvUserOrder.Rows[e.RowIndex].Cells[1].Value.ToString());
                    cm.Parameters.AddWithValue("@status", "Returned");
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Items Have Been Returned. Thank you!");


                    cm = new SqlCommand("UPDATE tbProduct SET pqty=(pqty+@pqty) WHERE pid LIKE '" + dgvUserOrder.Rows[e.RowIndex].Cells[3].Value.ToString() + "' ", con);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt32(dgvUserOrder.Rows[e.RowIndex].Cells[5].Value.ToString()));
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();


                    cm = new SqlCommand("INSERT INTO tblog(loginfo, logdate)VALUES(@loginfo, @logdate)", con);
                    cm.Parameters.AddWithValue("@loginfo", ("NOTE: Client  \"" + UserLoginForm.CName.ToString() + " \"  with Activity ID # " + dgvUserOrder.Rows[e.RowIndex].Cells[1].Value.ToString()) + "  RETURNED a APPROVED request . Please Check the Returned List for Confirmation");
                    cm.Parameters.AddWithValue("@logdate", DateTime.Now);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();



                }
                LoadUserOrder();
            }
        }
    }
}
