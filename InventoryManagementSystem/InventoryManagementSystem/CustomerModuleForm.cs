using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InventoryManagementSystem
{
    public partial class CustomerModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mark Louie Jamco\Documents\dBIMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        public CustomerModuleForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCRepass.Text != txtCPassword.Text)
                {
                    MessageBox.Show("Password did not match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtCName.Text == "")
                {
                    MessageBox.Show("Please add Name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtCPhone.Text == "")
                {
                    MessageBox.Show("Please add User Phone!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtCEmail.Text == "")
                {
                    MessageBox.Show("Please add User Email!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtCAddress.Text == "")
                {
                    MessageBox.Show("Please add User Address!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtCUserName.Text == "")
                {
                    MessageBox.Show("Please add Username!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtCPassword.Text == "")
                {
                    MessageBox.Show("Please add User Password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                con.Open();
                SqlCommand checkUserID = new SqlCommand("SELECT cusername FROM tbcustomer WHERE cusername = @cusername", con);
                checkUserID.Parameters.AddWithValue("@cusername", txtCUserName.Text);
                SqlDataReader reader = checkUserID.ExecuteReader();
                bool checkusername = reader.Read();
                con.Close();

                if (checkusername)
                {
                    MessageBox.Show("User Name Already Exists, Please Enter a New Username", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else

                if (MessageBox.Show("Are you sure you want to save this client?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbCustomer(cname, cphone, cemail, caddress, cusername, cpassword)VALUES(@cname, @cphone, @cemail, @caddress, @cusername, @cpassword)", con);
                    cm.Parameters.AddWithValue("@cname", txtCName.Text);
                    cm.Parameters.AddWithValue("@cphone", txtCPhone.Text);
                    cm.Parameters.AddWithValue("@cemail", txtCEmail.Text);
                    cm.Parameters.AddWithValue("@caddress", txtCAddress.Text);
                    cm.Parameters.AddWithValue("@cusername", txtCUserName.Text);
                    cm.Parameters.AddWithValue("@cpassword", txtCPassword.Text);

                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Client has been successfully saved.");


                    cm = new SqlCommand("INSERT INTO tblog(loginfo, logdate)VALUES(@loginfo, @logdate)", con);
                    cm.Parameters.AddWithValue("@loginfo", ("Admin  \" " + LoginForm.adminfullname.ToString() + "\"  ADDED a New Client with a name of  \" " + txtCName.Text + "\"."));
                    cm.Parameters.AddWithValue("@logdate", DateTime.Now);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();


                    Clear();
                    txtCUserName.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Clear()
        {
            txtCName.Clear();
            txtCPhone.Clear();
            txtCEmail.Clear();
            txtCAddress.Clear();
            txtCPassword.Clear();
            txtCRepass.Clear();
          
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try 
            {
                if (txtCRepass.Text != txtCPassword.Text)
                {
                    MessageBox.Show("Password did not match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtCName.Text == "")
                {
                    MessageBox.Show("Please add Name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtCPhone.Text == "")
                {
                    MessageBox.Show("Please add User Phone!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtCEmail.Text == "")
                {
                    MessageBox.Show("Please add User Email!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtCAddress.Text == "")
                {
                    MessageBox.Show("Please add User Address!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtCUserName.Text == "")
                {
                    MessageBox.Show("Please add Username!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtCPassword.Text == "")
                {
                    MessageBox.Show("Please add User Password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (MessageBox.Show("Are you sure you want to update this Client?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                cm = new SqlCommand("UPDATE tbCustomer SET cname=@cname, cphone=@cphone, cemail=@cemail, caddress=@caddress WHERE cid LIKE '" + lblCld.Text + "'", con);
                cm.Parameters.AddWithValue("@cname", txtCName.Text);
                cm.Parameters.AddWithValue("@cphone", txtCPhone.Text);
                cm.Parameters.AddWithValue("@cemail", txtCEmail.Text);
                cm.Parameters.AddWithValue("@caddress", txtCAddress.Text);
                cm.Parameters.AddWithValue("@cusername", txtCUserName.Text);
                cm.Parameters.AddWithValue("@cpassword", txtCPassword.Text);
                con.Open();
                cm.ExecuteNonQuery();
                con.Close();



                cm = new SqlCommand("INSERT INTO tblog(loginfo, logdate)VALUES(@loginfo, @logdate)", con);
                cm.Parameters.AddWithValue("@loginfo", ("Admin  \" " + LoginForm.adminfullname.ToString() + "\"  UPDATED a Client with a name of  \" " + txtCName.Text + "\"."));
                cm.Parameters.AddWithValue("@logdate", DateTime.Now);
                con.Open();
                cm.ExecuteNonQuery();
                con.Close();

                    MessageBox.Show("Client has been successfully updated!");
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
