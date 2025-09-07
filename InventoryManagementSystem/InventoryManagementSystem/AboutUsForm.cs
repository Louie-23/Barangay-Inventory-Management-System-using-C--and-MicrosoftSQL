using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class AboutUsForm : Form
    {
        public AboutUsForm()
        {
            InitializeComponent();
            openChildForm(new GroupMates());

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
            panelAboutUs.Controls.Add(childForm);
            panelAboutUs.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnMLJ_Click(object sender, EventArgs e)
        {
            openChildForm(new GroupMates());
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            openChildForm(new AboutUs());
        }

        private void btnPurpose_Click(object sender, EventArgs e)
        {
            openChildForm(new Purpose());
        }

        private void btnMissionandVision_Click(object sender, EventArgs e)
        {
            openChildForm(new MissionandVision());
        }

        private void btnObjectives_Click(object sender, EventArgs e)
        {
            openChildForm(new Objectives());
        }
    }
}
