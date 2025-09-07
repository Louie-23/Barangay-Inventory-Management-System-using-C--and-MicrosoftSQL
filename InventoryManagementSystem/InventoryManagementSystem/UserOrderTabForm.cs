using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class UserOrderTabForm : Form
    {
        public UserOrderTabForm()
        {
            InitializeComponent();
            openChildForm(new UserOrderForm()); 
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
            OrderTabPanel.Controls.Add(childForm);
            OrderTabPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnWaitingForApproval_Click(object sender, EventArgs e)
        {
            openChildForm(new UserOrderWaitForm());
        }

        private void btnNotApproved_Click(object sender, EventArgs e)
        {
            openChildForm(new UserOrderNotApprovedForm());
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            openChildForm(new UserOrderApprovedForm());
        }

        private void btnTimeExpired_Click(object sender, EventArgs e)
        {
            openChildForm(new UserOrderExpiredForm());
        }

        private void btnReturned_Click(object sender, EventArgs e)
        {
            openChildForm(new UserOrderReturnedForm());
        }
    }
}
