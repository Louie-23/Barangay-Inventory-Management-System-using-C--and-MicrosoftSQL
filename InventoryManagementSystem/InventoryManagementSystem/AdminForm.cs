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
using System.Xml.Linq;

namespace InventoryManagementSystem
{
    public partial class AdminForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mark Louie Jamco\Documents\dBIMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public AdminForm()
        {
            InitializeComponent();
            LoadUser();
        }

        public void LoadUser()
        {
            int i = 0;
            dgvUser.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbUser",con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvUser.Rows.Add(i,dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (LoginForm.adminusername =="admin")
            {
                AdminModuleForm userModule = new AdminModuleForm();
                userModule.btnSave.Enabled = true;
                userModule.btnUpdate.Enabled = false;
                userModule.ShowDialog();
                LoadUser();
            }
            else
            {
                MessageBox.Show("You don't have permission to add a new admin.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvUser.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
               
                if ((LoginForm.adminusername == dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString() || (LoginForm.adminusername == "admin")))
                {

                    AdminModuleForm userModule = new AdminModuleForm();
                    userModule.txtUserName.Text = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                    userModule.txtFullName.Text = dgvUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                    userModule.txtPass.Text = dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                    userModule.txtPhone.Text = dgvUser.Rows[e.RowIndex].Cells[4].Value.ToString();

                    userModule.btnSave.Enabled = false;
                    userModule.btnUpdate.Enabled = true;
                    userModule.txtUserName.Enabled = false;
                    userModule.ShowDialog();
                }
                else
                {
                    MessageBox.Show("You don't have permission to edit this admin.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (colName == "Delete")
            {
                if (LoginForm.adminusername == "admin")
                {
                    if (MessageBox.Show("Are you sure you want to delete this user?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        con.Open();
                        cm = new SqlCommand("DELETE FROM tbUser WHERE username LIKE '" + dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                        cm.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Record has been successfully deleted!");
                    }
                }
                else
                {
                    MessageBox.Show("You don't have permission to delete this admin.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            LoadUser();

        }

        private void dgvUser_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.Value != null)
            {
                e.Value = new string('*', e.Value.ToString().Length);
            }
        }
    }
}
