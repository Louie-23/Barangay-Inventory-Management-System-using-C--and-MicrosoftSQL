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
    public partial class UserProductForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mark Louie Jamco\Documents\dBIMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public UserProductForm()
        {
            InitializeComponent();
            LoadUserProduct();

        }
        public void LoadUserProduct()
        {
            int i = 0;
            dgvUserProduct.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbProduct WHERE CONCAT(pid, pqty, pname, pprice, pdescription, pcategory)LIKE '%" + txtSearch.Text + "%'", con);
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadUserProduct();
        }
    }
}
