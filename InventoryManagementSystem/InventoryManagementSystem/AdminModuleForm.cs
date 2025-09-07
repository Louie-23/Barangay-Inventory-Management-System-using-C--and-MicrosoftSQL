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
using System.Xml.Linq;

namespace InventoryManagementSystem
{
    public partial class AdminModuleForm : Form
    {

        SqlConnection con= new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mark Louie Jamco\Documents\dBIMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        public AdminModuleForm()
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
                

                if (txtRepass.Text != txtPass.Text)
                {
                    MessageBox.Show("Password did not match!", "Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtUserName.Text == "")
                {
                    MessageBox.Show("Please add Username!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtFullName.Text == "")
                {
                    MessageBox.Show("Please add Name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtPass.Text == "")
                {
                    MessageBox.Show("Please add Password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtPhone.Text == "")
                {
                    MessageBox.Show("Please add Contact Info!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }



                con.Open();
                SqlCommand checkUserID = new SqlCommand("SELECT username FROM tbuser WHERE username = @username", con);
                checkUserID.Parameters.AddWithValue("@username", txtUserName.Text);
                SqlDataReader reader = checkUserID.ExecuteReader();
                bool checkusername = reader.Read();
                con.Close();

                if (checkusername)
                {
                    MessageBox.Show("User Name Already Exists, Please Enter a New Username", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else

                if (MessageBox.Show("Are you sure you want to save this user?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbUser(username,fullname,password,phone)VALUES(@username,@fullname,@password,@phone)", con);
                    cm.Parameters.AddWithValue("@username", txtUserName.Text);
                    cm.Parameters.AddWithValue("@fullname", txtFullName.Text);
                    cm.Parameters.AddWithValue("@password", txtPass.Text);
                    cm.Parameters.AddWithValue("@phone", txtPhone.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User has been successfully saved.");
                    Clear();
                    txtUserName.Clear();
                }
            
                
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
   
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();

        }
        public void Clear()
        {
            txtFullName.Clear();
            txtPass.Clear();
            txtRepass.Clear();
            txtPhone.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRepass.Text != txtPass.Text)
                {
                    MessageBox.Show("Password did not match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtUserName.Text == "")
                {
                    MessageBox.Show("Please add Username!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtFullName.Text == "")
                {
                    MessageBox.Show("Please add Name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtPass.Text == "")
                {
                    MessageBox.Show("Please add Password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtPhone.Text == "")
                {
                    MessageBox.Show("Please add Contact Info!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Are you sure you want to update this user?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE tbUser SET fullname=@fullname, password=@password, phone=@phone WHERE username LIKE '"+txtUserName.Text+"'", con);
                    cm.Parameters.AddWithValue("@fullname", txtFullName.Text);
                    cm.Parameters.AddWithValue("@password", txtPass.Text);
                    cm.Parameters.AddWithValue("@phone", txtPhone.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User has been successfully updated!");
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
