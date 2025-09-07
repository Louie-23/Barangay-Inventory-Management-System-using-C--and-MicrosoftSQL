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
    public partial class LogForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mark Louie Jamco\Documents\dBIMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public LogForm()
        {
            InitializeComponent();
            LoadLog();
        }
        public void LoadLog()
        {
            int i = 0;
            dgvInbox.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tblog  WHERE CONCAT(logid, loginfo, logdate)LIKE '%" + txtSearch.Text + "%' ORDER BY logdate DESC", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvInbox.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), Convert.ToDateTime(dr[2].ToString()).ToString("MMM d, yyyy | h:mm tt"));
            }
            dr.Close();
            con.Close();
        }

        private void dgvInbox_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvInbox.Columns[e.ColumnIndex].Name;

            if (colName == "Delete")
            {
                if (LoginForm.adminusername == "admin")
                {
                    if (MessageBox.Show("Are you sure you want to delete this Message?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        con.Open();
                        cm = new SqlCommand("DELETE FROM tblog WHERE logid LIKE '" + dgvInbox.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                        cm.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Message has been successfully deleted!");
                    }
                }
                else
                {
                    MessageBox.Show("You don't have permission to delete this information.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            LoadLog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadLog();
        }
    }
    
}
