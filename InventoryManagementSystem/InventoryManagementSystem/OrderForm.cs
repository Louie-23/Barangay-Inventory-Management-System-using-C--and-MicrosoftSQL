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
    public partial class OrderForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mark Louie Jamco\Documents\dBIMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public OrderForm()
        {
            InitializeComponent();
            LoadOrder();

            OrderApprovedForm orderapprovedform = new OrderApprovedForm();
            orderapprovedform.calculateTime();
            txtMaxDay.Enabled = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
        }

        public string maxday;
        public void LoadOrder()
        {
            double total = 0;
            int i = 0;
            dgvOrder.Rows.Clear();
            cm = new SqlCommand("SELECT orderid, odate, O.pid, P.pname, O.cid, C.cname, qty, price, total, rdate, status FROM tbOrder AS O JOIN tbCustomer AS C ON O.cid=C.cid JOIN tbProduct AS P ON O.pid=P.pid WHERE CONCAT(orderid, odate, O.pid, P.pname, O.cid, C.cname, qty, price, status) LIKE '%" + txtSearch.Text + "%'", con);
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




            cm = new SqlCommand("SELECT Day FROM tbDay", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                txtMaxDay.Text = dr[0].ToString();
                maxday = dr[0].ToString();
            }
            dr.Close();
            con.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OrderModuleForm moduleForm = new OrderModuleForm();
            moduleForm.ShowDialog();
            LoadOrder();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadOrder();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (LoginForm.adminusername == "admin")
            {
                txtMaxDay.Enabled = true;
                btnSave.Visible = true;
                btnCancel.Visible = true;
                btnEdit.Visible = false;
            }
            else
            {
                MessageBox.Show("You don't have permission to Edit return time.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this Return Time?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE tbDay SET Day=@Day ", con);
                    cm.Parameters.AddWithValue("@Day", txtMaxDay.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Day(s) of Return has been successfully updated!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtMaxDay.Enabled = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            btnEdit.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtMaxDay.Enabled = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            btnEdit.Visible = true;
            LoadOrder();
        }
    }
}
