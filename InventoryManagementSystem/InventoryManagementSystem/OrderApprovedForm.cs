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
    public partial class OrderApprovedForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mark Louie Jamco\Documents\dBIMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public OrderApprovedForm()
        {
            InitializeComponent();
            LoadOrder();
            calculateTime();
         }


        public string clientname;
        public string activityid;

        public string clientid;

        public void LoadOrder()
        {
            double total = 0;
            int i = 0;
            dgvOrder.Rows.Clear();
            cm = new SqlCommand("SELECT orderid, odate, O.pid, P.pname, O.cid, C.cname, qty, price, total, rdate, status FROM tbOrder AS O JOIN tbCustomer AS C ON O.cid=C.cid JOIN tbProduct AS P ON O.pid=P.pid WHERE CONCAT(orderid, odate, O.pid, P.pname, O.cid, C.cname, qty, price) LIKE '%" + txtSearch.Text + "%'AND status = @status", con);
            cm.Parameters.AddWithValue("@status", "Approved");
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;

                DateTime requiredDate = Convert.ToDateTime(dr[9]);
                TimeSpan remainingTime = requiredDate - DateTime.Now;
                string remainingTimeString = remainingTime.TotalMilliseconds > 0 ? $"{remainingTime.Days} days, {remainingTime.Hours} hours, {remainingTime.Minutes} minutes" : "Expired";


                dgvOrder.Rows.Add(i, dr[0].ToString(), Convert.ToDateTime(dr[1].ToString()).ToString("MMM d, yyyy | h:mm tt"), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), Convert.ToDateTime(dr[9].ToString()).ToString("MMM d, yyyy | h:mm tt"), dr[10].ToString(), remainingTimeString);
                total += Convert.ToInt32(dr[8].ToString());

                clientname = dr[5].ToString();
                activityid = dr[0].ToString();

                clientid = dr[4].ToString();
            }
            dr.Close();
            con.Close();

            lblQty.Text = i.ToString();
            lblTotal.Text = total.ToString();
        }




        public void calculateTime()
        {
            con.Open();

            SqlCommand updateCmd = new SqlCommand("UPDATE tbOrder SET status = @status WHERE rdate < @currentDate AND status = 'Approved'", con);
            updateCmd.Parameters.AddWithValue("@currentDate", DateTime.Now);
            updateCmd.Parameters.AddWithValue("@status", "Time Expired");
            int rowsUpdated = updateCmd.ExecuteNonQuery();

            if (rowsUpdated > 0)
            {
                cm = new SqlCommand("INSERT INTO tblog(loginfo, logdate)VALUES(@loginfo, @logdate)", con);
                cm.Parameters.AddWithValue("@loginfo", ("WARNING! : Client  \" " + clientname.ToString() + "\"  request has been EXPIRED with Activity ID #" + activityid.ToString()));
                cm.Parameters.AddWithValue("@logdate", DateTime.Now);
                cm.ExecuteNonQuery();



                cm = new SqlCommand("INSERT INTO tbUserlog(usercid, userloginfo, userlogdate)VALUES(@usercid, @userloginfo, @userlogdate)", con);
                cm.Parameters.AddWithValue("@usercid", clientid.ToString());
                cm.Parameters.AddWithValue("@userloginfo", ("WARNING! : Your request has been EXPIRED with Activity ID #" + activityid.ToString() + "  . You can't add another Activity until you return the item(s) in your EXPIRED request"));
                cm.Parameters.AddWithValue("@userlogdate", DateTime.Now);
                cm.ExecuteNonQuery();
         
            }
     
            con.Close();


        }

       


            private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvOrder.Columns[e.ColumnIndex].Name;

            if (colName == "Return")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to Return Items?", "Return Items", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("UPDATE tbOrder SET status = @status WHERE orderid LIKE @orderid", con);
                    cm.Parameters.AddWithValue("@orderid", dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString());
                    cm.Parameters.AddWithValue("@status", "Returned");
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Items Have Been Returned. Thank you!");


                    cm = new SqlCommand("UPDATE tbProduct SET pqty=(pqty+@pqty) WHERE pid LIKE '" + dgvOrder.Rows[e.RowIndex].Cells[3].Value.ToString() + "' ", con);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt32(dgvOrder.Rows[e.RowIndex].Cells[7].Value.ToString()));
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();


                    cm = new SqlCommand("INSERT INTO tblog(loginfo, logdate)VALUES(@loginfo, @logdate)", con);
                    cm.Parameters.AddWithValue("@loginfo", ("Admin  \" " + LoginForm.adminfullname.ToString() + "\"  has been marked RETURNED the APPROVED Client  \" " + dgvOrder.Rows[e.RowIndex].Cells[6].Value.ToString() + "\"  request with Activity ID #" + dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString()));
                    cm.Parameters.AddWithValue("@logdate", DateTime.Now);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();

                }
            }
            else if (colName == "Status")
            {
                DialogResult result = MessageBox.Show("Do you Want to Cancel Approve this Activity?", "Approve Activity", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("UPDATE tbOrder SET status = @status WHERE orderid LIKE @orderid", con);
                    cm.Parameters.AddWithValue("@orderid", dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString());
                    cm.Parameters.AddWithValue("@status", "Waiting");
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Activity has been moved to Waiting List!");


                    cm = new SqlCommand("INSERT INTO tblog(loginfo, logdate)VALUES(@loginfo, @logdate)", con);
                    cm.Parameters.AddWithValue("@loginfo", ("Admin  \" " + LoginForm.adminfullname.ToString() + "\"  has been MOVED APPROVED Client  \" " + dgvOrder.Rows[e.RowIndex].Cells[6].Value.ToString() + "\"  request to WAITING LIST with Activity ID #" + dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString()));
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
