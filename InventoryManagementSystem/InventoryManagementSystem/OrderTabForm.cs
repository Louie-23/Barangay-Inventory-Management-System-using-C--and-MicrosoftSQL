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
    public partial class OrderTabForm : Form
    {
        public OrderTabForm()
        {
            InitializeComponent();
            openChildForm(new OrderForm());
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
            openChildForm(new OrderWaitForm());
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            openChildForm(new OrderApprovedForm());
        }

        private void btnNotApproved_Click(object sender, EventArgs e)
        {
            openChildForm(new OrderNotApprovedForm());
        }

        private void btnTimeExpired_Click(object sender, EventArgs e)
        {
            openChildForm(new OrderExpiredForm());
        }

        private void btnReturned_Click(object sender, EventArgs e)
        {
            openChildForm(new OrderReturnedForm());
        }
    }
}
