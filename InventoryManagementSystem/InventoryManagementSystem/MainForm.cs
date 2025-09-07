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
    public partial class MainForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mark Louie Jamco\Documents\dBIMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        public MainForm()
        {
            InitializeComponent();


            cm = new SqlCommand("INSERT INTO tblog(loginfo, logdate)VALUES(@loginfo, @logdate)", con);
            cm.Parameters.AddWithValue("@loginfo", ("Admin  \" " + LoginForm.adminfullname.ToString() + "\"  Logged In"));
            cm.Parameters.AddWithValue("@logdate", DateTime.Now);
            con.Open();
            cm.ExecuteNonQuery();
            con.Close();
        }

       private Form activeform = null;
       private void openChildForm(Form childForm)
        {
            if (activeform != null)
                activeform.Close();
            activeform = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            openChildForm(new AdminForm());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            openChildForm(new ProductTabForm());
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            openChildForm(new CustomerForm());
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            openChildForm(new OrderTabForm());
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            openChildForm(new AboutUsForm());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if(LoginForm.adminusername != null)
            {
                lblUserN.Text = LoginForm.adminfullname;
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Log Out?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               this.Close();
            }
            
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            cm = new SqlCommand("INSERT INTO tblog(loginfo, logdate)VALUES(@loginfo, @logdate)", con);
            cm.Parameters.AddWithValue("@loginfo", ("Admin  \" " + LoginForm.adminfullname.ToString() + "\"  Logged Out"));
            cm.Parameters.AddWithValue("@logdate", DateTime.Now);
            con.Open();
            cm.ExecuteNonQuery();
            con.Close();

            this.Close();
            LoginForm login = new LoginForm();
            login.Show();

            

        }

        private void btnInbox_Click(object sender, EventArgs e)
        {
            openChildForm(new LogForm());
        }
    }
}
