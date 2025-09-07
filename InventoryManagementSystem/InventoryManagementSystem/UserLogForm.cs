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
    public partial class UserLogForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mark Louie Jamco\Documents\dBIMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public UserLogForm()
        {
            InitializeComponent();
            LoadUserLog();
        }
        public void LoadUserLog()
        {
            int i = 0;
            dgvUserInbox.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbUserlog  WHERE usercid = @usercid AND CONCAT(userlogid, usercid, userloginfo, userlogdate)LIKE '%" + txtSearch.Text + "%' ORDER BY userlogdate DESC", con);
            cm.Parameters.AddWithValue("@usercid", UserLoginForm.CId);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvUserInbox.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), Convert.ToDateTime(dr[3].ToString()).ToString("MMM d, yyyy | h:mm tt"));
            }
            dr.Close();
            con.Close();

            dgvUserInbox.Columns["userlogid"].Visible = false;
            dgvUserInbox.Columns["usercid"].Visible = false;
        }

        private void dgvUserInbox_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvUserInbox.Columns[e.ColumnIndex].Name;

            if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this Message?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbUserlog WHERE userlogid LIKE '" + dgvUserInbox.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Message has been successfully deleted!");
                }
            }
            LoadUserLog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadUserLog();
        }
    }
    
}
