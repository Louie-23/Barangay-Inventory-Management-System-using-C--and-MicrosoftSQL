using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class OrderExpiredModuleForm : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mark Louie Jamco\Documents\dBIMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        public OrderExpiredModuleForm()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to Extend Time?", "Extend Time", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE tbOrder SET rdate=@rdate, status=@status WHERE orderid LIKE '" + lblOrderId.Text + "'", con);
                    cm.Parameters.AddWithValue("@rdate", dtExtendOrder.Value);
                    cm.Parameters.AddWithValue("@status", "Waiting");

                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();

                    cm = new SqlCommand("INSERT INTO tblog(loginfo, logdate)VALUES(@loginfo, @logdate)", con);
                    cm.Parameters.AddWithValue("@loginfo", ("NOTE: Admin \" " + LoginForm.adminfullname.ToString() + "\"  requested to EXTEND TIME of Client  \"" + lblCname.Text + " \"  from " + txtReturnOrder.Text + " to " + dtExtendOrder.Text + ". Please Check the Waiting List for Approval"));
                    cm.Parameters.AddWithValue("@logdate", DateTime.Now);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Time has been successfully Extended!. Please Wait for Admin Approval");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void dtExtendOrder_ValueChanged(object sender, EventArgs e)
        {
            OrderExpiredForm orderexpiredform = new OrderExpiredForm();


            DateTime selectedDate = dtExtendOrder.Value;

            if (DateTime.TryParseExact(txtReturnOrder.Text, "MMM d, yyyy | h:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime returndate))
            {
                DateTime minDate = returndate;
                DateTime maxDate = returndate.AddDays((Convert.ToInt32(orderexpiredform.extendday)));

                if (selectedDate < minDate)
                {
                    dtExtendOrder.Value = minDate;
                    MessageBox.Show("You cannot select time that is less than your return date!", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnUpdate.Enabled = false;
                }
                else if (selectedDate > maxDate)
                {
                    dtExtendOrder.Value = maxDate;
                    MessageBox.Show("Maximum extend time is " + orderexpiredform.extendday.ToString() + " days.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    btnUpdate.Enabled = true;
                }
            }
        }
    }
}
