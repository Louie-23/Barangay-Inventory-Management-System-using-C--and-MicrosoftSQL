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
    public partial class LoginForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mark Louie Jamco\Documents\dBIMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public static string adminusername = "";
        public static string adminfullname = "";

        public LoginForm()
        {
            InitializeComponent();
            LoadUsername();
        }

        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPass.Checked == false)
                txtPass.UseSystemPasswordChar = true;
            else
                txtPass.UseSystemPasswordChar = false;
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            cmbName.SelectedItem = null;
            txtPass.Clear();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Exit Application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                cm = new SqlCommand("SELECT * FROM tbUser WHERE username=@username AND password=@password", con);
                cm.Parameters.AddWithValue("@username", cmbName.Text);
                cm.Parameters.AddWithValue("@password", txtPass.Text);
                con.Open();
                dr = cm.ExecuteReader();
                dr.Read();
                if(dr.HasRows)
                {
                    MessageBox.Show("Welcome " + dr["fullname"].ToString() + " ! ", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    adminusername = dr["username"].ToString();  
                    adminfullname = dr["fullname"].ToString();
                    WelcomeForm welcome = new WelcomeForm();
                    this.Hide();
                    welcome.ShowDialog();
                }
                else
                {
                    MessageBox.Show("INVALID username or password!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            cmbLogin.SelectedIndex = 1;

        }

        private void cmbLogin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLogin.SelectedIndex == 0)
            {
                UserLoginForm userloginform = new UserLoginForm();
                userloginform.Show();
                this.Hide();
            }
        }
        public void LoadUsername()
        {
            cmbName.Items.Clear();
            cm = new SqlCommand("SELECT username FROM tbUser", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                cmbName.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
    }
}
