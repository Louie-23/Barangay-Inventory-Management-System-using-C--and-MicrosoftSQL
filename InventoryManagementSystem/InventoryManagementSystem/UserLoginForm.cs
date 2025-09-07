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
    public partial class UserLoginForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mark Louie Jamco\Documents\dBIMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public static string CName = "";
        public static string CId = "";

        public UserLoginForm()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void UserLoginForm_Load(object sender, EventArgs e)
        {
            cmbLogin.SelectedIndex = 0;
        }

        private void cmbLogin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLogin.SelectedIndex == 1)
            {
                LoginForm loginform = new LoginForm();
                loginform.Show();
                this.Hide();
            }
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPass.Clear();
        }

        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPass.Checked == false)
                txtPass.UseSystemPasswordChar = true;
            else
                txtPass.UseSystemPasswordChar = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                cm = new SqlCommand("SELECT * FROM tbCustomer WHERE cusername=@cusername AND cpassword=@cpassword", con);
                cm.Parameters.AddWithValue("@cusername", txtName.Text);
                cm.Parameters.AddWithValue("@cpassword", txtPass.Text);
                con.Open();
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    MessageBox.Show("Welcome " + dr["cname"].ToString() + " ! ", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CName = dr["cname"].ToString();
                    CId = dr["cid"].ToString();
                    UserWelcomeForm userwelcome = new UserWelcomeForm();
                    this.Hide();
                    userwelcome.ShowDialog();
                }
                else
                {
                    MessageBox.Show("INVALID username or password!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {
            UserCreateAccountForm usercreateaccountform = new UserCreateAccountForm();
            usercreateaccountform.ShowDialog();
        }
    }
}
