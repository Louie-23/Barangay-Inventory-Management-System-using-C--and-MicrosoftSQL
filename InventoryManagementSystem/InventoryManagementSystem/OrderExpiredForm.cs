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
    public partial class OrderExpiredForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mark Louie Jamco\Documents\dBIMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public OrderExpiredForm()
        {
            InitializeComponent();
            LoadOrder();


            txtExtendDay.Enabled = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
        }

        public string extendday;

        public void LoadOrder()
        {
            double total = 0;
            int i = 0;
            dgvOrder.Rows.Clear();
            cm = new SqlCommand("SELECT orderid, odate, O.pid, P.pname, O.cid, C.cname, qty, price, total, rdate, status FROM tbOrder AS O JOIN tbCustomer AS C ON O.cid=C.cid JOIN tbProduct AS P ON O.pid=P.pid WHERE CONCAT(orderid, odate, O.pid, P.pname, O.cid, C.cname, qty, price) LIKE '%" + txtSearch.Text + "%'AND status = @status", con);
            cm.Parameters.AddWithValue("@status", "Time Expired");
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;

                DateTime requiredDate = Convert.ToDateTime(dr[9]);
                TimeSpan remainingTime = DateTime.Now - requiredDate;
                string remainingTimeString = remainingTime.TotalMilliseconds > 0 ? $"{remainingTime.Days} days, {remainingTime.Hours} hours, {remainingTime.Minutes} minutes" : "Expired";

                dgvOrder.Rows.Add(i, dr[0].ToString(), Convert.ToDateTime(dr[1].ToString()).ToString("MMM d, yyyy | h:mm tt"), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), Convert.ToDateTime(dr[9].ToString()).ToString("MMM d, yyyy | h:mm tt"), dr[10].ToString(), remainingTimeString);
                total += Convert.ToInt32(dr[8].ToString());
            }
            dr.Close();
            con.Close();

            lblQty.Text = i.ToString();
            lblTotal.Text = total.ToString();



            cm = new SqlCommand("SELECT Extend FROM tbExtend", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                txtExtendDay.Text = dr[0].ToString();
                extendday = dr[0].ToString();
            }
            dr.Close();
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
                    cm.Parameters.AddWithValue("@loginfo", ("Admin  \" " + LoginForm.adminfullname.ToString() + "\"  has been marked RETURNED the EXPIRED Client  \" " + dgvOrder.Rows[e.RowIndex].Cells[6].Value.ToString() + "\"  request with Activity ID #" + dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString()));
                    cm.Parameters.AddWithValue("@logdate", DateTime.Now);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                }
                LoadOrder();
            }
            else if (colName == "Extend")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to Extend Time?", "Extend Time", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    OrderExpiredModuleForm orderexpiredmoduleform = new OrderExpiredModuleForm();

                    orderexpiredmoduleform.lblCname.Text = dgvOrder.Rows[e.RowIndex].Cells[6].Value.ToString();
                    orderexpiredmoduleform.lblOrderId.Text = dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString();
                    orderexpiredmoduleform.txtReturnOrder.Text = dgvOrder.Rows[e.RowIndex].Cells[10].Value.ToString();
                    orderexpiredmoduleform.dtExtendOrder.Text = DateTime.Now.ToString();
                    orderexpiredmoduleform.ShowDialog();
                    LoadOrder();
                }

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadOrder();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            if (LoginForm.adminusername == "admin")
            {
                txtExtendDay.Enabled = true;
                btnSave.Visible = true;
                btnCancel.Visible = true;
                btnEdit.Visible = false;
            }
            else
            {
                MessageBox.Show("You don't have permission to Edit extend time.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this Extend Time?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE tbExtend SET Extend=@Extend ", con);
                    cm.Parameters.AddWithValue("@Extend", txtExtendDay.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Day(s) of Extend has been successfully updated!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtExtendDay.Enabled = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            btnEdit.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtExtendDay.Enabled = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            btnEdit.Visible = true;
            LoadOrder();
        }
    }
    
}
