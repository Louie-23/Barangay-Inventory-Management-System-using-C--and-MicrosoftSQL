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
    public partial class UserCreateAccountForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mark Louie Jamco\Documents\dBIMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        public UserCreateAccountForm()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
                    MessageBox.Show("Please add Phone!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtCEmail.Text == "")
                {
                    MessageBox.Show("Please add Email!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtCAddress.Text == "")
                {
                    MessageBox.Show("Please add Address!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtCUserName.Text == "")
                {
                    MessageBox.Show("Please add Username!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtCPassword.Text == "")
                {
                    MessageBox.Show("Please add Password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                if (MessageBox.Show("Are you sure you want to Create this Account?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                    MessageBox.Show("Account has been Successfully Created!");
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCName.Clear();
            txtCPhone.Clear();
            txtCEmail.Clear();
            txtCAddress.Clear();
            txtCUserName.Clear();
            txtCPassword.Clear();
            txtCRepass.Clear();
        }

        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPass.Checked == false)
            {
                txtCPassword.UseSystemPasswordChar = true;
                txtCRepass.UseSystemPasswordChar = true;
            }

            else
            {
                txtCPassword.UseSystemPasswordChar = false;
                txtCRepass.UseSystemPasswordChar = false;
            }
        }
    }
}
