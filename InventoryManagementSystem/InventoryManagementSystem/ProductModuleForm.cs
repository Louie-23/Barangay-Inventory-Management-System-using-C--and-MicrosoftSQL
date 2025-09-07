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
    public partial class ProductModuleForm : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mark Louie Jamco\Documents\dBIMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public ProductModuleForm()
        {
            InitializeComponent();
            LoadCategory();
        }
        public void LoadCategory()
        {
            comboCat.Items.Clear();
            cm = new SqlCommand("SELECT catname FROM tbCategory",con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                comboCat.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPName.Text == "")
                {
                    MessageBox.Show("Please add Product Name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtPQty.Text == "" || txtPQty.Text == "0")
                {
                    MessageBox.Show("Please add Product Quantity!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtPPrice.Text == "" || txtPPrice.Text == "0") 
                {
                    MessageBox.Show("Please add Product Price!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtPDes.Text == "")
                {
                    MessageBox.Show("Please add Product Description!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (comboCat.Text == "")
                {
                    MessageBox.Show("Please add Product Category!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Are you sure you want to add this item?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbProduct(pname,pqty,pprice,pdescription,pcategory)VALUES(@pname, @pqty, @pprice, @pdescription, @pcategory)", con);
                    cm.Parameters.AddWithValue("@pname", txtPName.Text);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt32(txtPQty.Text));
                    cm.Parameters.AddWithValue("@pprice", Convert.ToInt32(txtPPrice.Text));
                    cm.Parameters.AddWithValue("@pdescription", txtPDes.Text);
                    cm.Parameters.AddWithValue("@pcategory", comboCat.Text);

                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();



                    cm = new SqlCommand("INSERT INTO tblog(loginfo, logdate)VALUES(@loginfo, @logdate)", con);
                    cm.Parameters.AddWithValue("@loginfo", ("Admin  \" " + LoginForm.adminfullname.ToString() + "\"  ADDED a New Item with a name of  \" " + txtPName.Text + "\"."));
                    cm.Parameters.AddWithValue("@logdate", DateTime.Now);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();


                    MessageBox.Show("Product has been successfully saved.");
                    Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Clear()
        {
            txtPName.Clear();
            txtPQty.Clear();
            txtPPrice.Clear();
            txtPDes.Clear();
            comboCat.SelectedIndex = -1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtPName.Text == "")
                {
                    MessageBox.Show("Please add Product Name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtPQty.Text == "" || txtPQty.Text == "0")
                {
                    MessageBox.Show("Please add Product Quantity!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtPPrice.Text == "" || txtPPrice.Text == "0")
                {
                    MessageBox.Show("Please add Product Price!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtPDes.Text == "")
                {
                    MessageBox.Show("Please add Product Description!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (comboCat.Text == "")
                {
                    MessageBox.Show("Please add Product Category!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to update this product?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE tbProduct SET pname=@pname, pqty=@pqty, pprice=@pprice, pdescription=@pdescription, pcategory=@pcategory WHERE pid LIKE '" + lblPid.Text + "'", con);
                    cm.Parameters.AddWithValue("@pname", txtPName.Text);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt32(txtPQty.Text));
                    cm.Parameters.AddWithValue("@pprice", Convert.ToInt32(txtPPrice.Text));
                    cm.Parameters.AddWithValue("@pdescription", txtPDes.Text);
                    cm.Parameters.AddWithValue("@pcategory", comboCat.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();


                    cm = new SqlCommand("INSERT INTO tblog(loginfo, logdate)VALUES(@loginfo, @logdate)", con);
                    cm.Parameters.AddWithValue("@loginfo", ("Admin  \" " + LoginForm.adminfullname.ToString() + "\"  UPDATED an Item with a name of  \" " + txtPName.Text + "\"."));
                    cm.Parameters.AddWithValue("@logdate", DateTime.Now);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Product has been successfully updated!");
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
