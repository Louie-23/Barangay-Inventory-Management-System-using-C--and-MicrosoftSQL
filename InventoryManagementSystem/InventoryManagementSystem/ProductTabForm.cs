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
    public partial class ProductTabForm : Form
    {
        public ProductTabForm()
        {
            InitializeComponent();
            openChildForm(new ProductForm());
            
            btnProduct.Enabled = false;
            btnCategory.Enabled = true;
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
            ProductTabPanel.Controls.Add(childForm);
            ProductTabPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            openChildForm(new ProductForm());
            btnProduct.Enabled = false;
            btnCategory.Enabled = true;
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            openChildForm(new CategoryForm());

            btnProduct.Enabled = true;
            btnCategory.Enabled = false;
        }
    }
}
