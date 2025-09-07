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
    public partial class UserProfileForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mark Louie Jamco\Documents\dBIMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public UserProfileForm()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtCName.Enabled = true;
            txtCPhone.Enabled = true;
            txtCEmail.Enabled = true;
            txtCAddress.Enabled = true;
            txtCPassword.Enabled = true;

            lblRepass.Visible = true;
            txtCRepass.Visible = true;
            btnSave.Enabled = true;

            btnEdit.Enabled = false;
            btnCancel.Visible = true;
            checkBoxPass.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCRepass.Text == "")
                {
                    MessageBox.Show("Please Confirm Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
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


                if (MessageBox.Show("Are you sure you want to update your Information?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                    cm.Parameters.AddWithValue("@loginfo", ("Client with a name of  \" " + txtCName.Text + "\"   UPDATED it's profile"));
                    cm.Parameters.AddWithValue("@logdate", DateTime.Now);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Profile been successfully updated! \nChanges will apply after you Log In again.","Update Successful!");



                    txtCName.Enabled = false;
                    txtCPhone.Enabled = false;
                    txtCEmail.Enabled = false;
                    txtCAddress.Enabled = false;
                    txtCUserName.Enabled = false;
                    txtCPassword.Enabled = false;

                    lblRepass.Visible = false;
                    txtCRepass.Visible = false;
                    btnSave.Enabled = false;
                    btnEdit.Enabled = true;
                    btnCancel.Visible = false;
                    checkBoxPass.Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

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
                usercphone = dr["cphone"].ToString();
                usercemail = dr["cemail"].ToString();
                usercaddress = dr["caddress"].ToString();
                usercusername = dr["cusername"].ToString();
                usercpassword = dr["cpassword"].ToString();

            }
            dr.Close();
            con.Close();
            lblCld.Text = UserLoginForm.CId;
            txtCName.Text = usercname;
            txtCPhone.Text = usercphone;
            txtCEmail.Text = usercemail;
            txtCAddress.Text = usercaddress;
            txtCUserName.Text = usercusername;
            txtCPassword.Text = usercpassword;



            txtCName.Enabled = false;
            txtCPhone.Enabled = false;
            txtCEmail.Enabled = false;
            txtCAddress.Enabled = false;
            txtCUserName.Enabled = false;
            txtCPassword.Enabled = false;

            lblRepass.Visible = false;
            txtCRepass.Visible = false;
            btnSave.Enabled = false;
            btnEdit.Enabled = true;
            btnCancel.Visible = false;
            checkBoxPass.Visible = false;
            checkBoxPass.Checked = false;

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
