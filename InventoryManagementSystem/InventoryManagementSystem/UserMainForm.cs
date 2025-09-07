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
    public partial class UserMainForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mark Louie Jamco\Documents\dBIMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public UserMainForm()
        {
            InitializeComponent();
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
            userpanelMain.Controls.Add(childForm);
            userpanelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            openChildForm(new UserProductForm());
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            openChildForm(new UserOrderTabForm());
        }

        private void UserMainForm_Load(object sender, EventArgs e)
        {
            if (UserLoginForm.CName != null)
            {
                lblUMFName.Text = UserLoginForm.CName;
            }
            if (UserLoginForm.CId != null)
            {
                lblUMFId.Text = UserLoginForm.CId;
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Log Out?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void UserMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
                this.Close();
                UserLoginForm userlogin = new UserLoginForm();
                userlogin.Show();  
        }

        private void btnInbox_Click(object sender, EventArgs e)
        {
            openChildForm(new UserLogForm());
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            
            UserProfileForm userprofile = new UserProfileForm();

            string usercname = "";
            string usercphone = "";
            string usercemail = "";
            string usercaddress = "";
            string usercusername = "";
            string usercpassword = "";

            con.Open();
            cm = new SqlCommand("SELECT * FROM tbCustomer WHERE cid=@cid", con);
            cm.Parameters.AddWithValue("@cid", UserLoginForm.CId);
            dr = cm.ExecuteReader();
            if (dr.Read())
            {

                 usercname = dr["cname"].ToString();
                 usercphone= dr["cphone"].ToString();
                 usercemail = dr["cemail"].ToString();
                 usercaddress = dr["caddress"].ToString();
                 usercusername = dr["cusername"].ToString();
                 usercpassword = dr["cpassword"].ToString();

            }
            dr.Close();
            con.Close();
            userprofile.lblCld.Text = UserLoginForm.CId;
            userprofile.txtCName.Text = usercname;
            userprofile.txtCPhone.Text = usercphone;
            userprofile.txtCEmail.Text = usercemail;
            userprofile.txtCAddress.Text = usercaddress ;
            userprofile.txtCUserName.Text = usercusername ;
            userprofile.txtCPassword.Text = usercpassword;


            userprofile.txtCName.Enabled = false;
            userprofile.txtCPhone.Enabled = false;
            userprofile.txtCEmail.Enabled = false;
            userprofile.txtCAddress.Enabled = false;
            userprofile.txtCUserName.Enabled = false;
            userprofile.txtCPassword.Enabled = false;
            
            userprofile.lblRepass.Visible = false;
            userprofile.txtCRepass.Visible = false;
            userprofile.btnSave.Enabled = false;
            userprofile.btnCancel.Visible = false;
            userprofile.checkBoxPass.Visible = false;



            openChildForm(userprofile);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            openChildForm(new AboutUsForm());
        }
    }
}
