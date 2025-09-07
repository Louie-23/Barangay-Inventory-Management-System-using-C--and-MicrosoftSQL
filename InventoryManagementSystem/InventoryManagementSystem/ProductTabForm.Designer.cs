namespace InventoryManagementSystem
{
    partial class ProductTabForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductTabForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnProduct = new InventoryManagementSystem.CustomerButton();
            this.btnCategory = new InventoryManagementSystem.CustomerButton();
            this.ProductTabPanel = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Plum;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnProduct);
            this.panel2.Controls.Add(this.btnCategory);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 432);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(992, 74);
            this.panel2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(250, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "ITEMS";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(739, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "CATEGORIES";
            // 
            // btnProduct
            // 
            this.btnProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnProduct.Image")));
            this.btnProduct.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnProduct.ImageHover")));
            this.btnProduct.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnProduct.ImageNormal")));
            this.btnProduct.Location = new System.Drawing.Point(251, 7);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(40, 40);
            this.btnProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnProduct.TabIndex = 14;
            this.btnProduct.TabStop = false;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCategory.Image = ((System.Drawing.Image)(resources.GetObject("btnCategory.Image")));
            this.btnCategory.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnCategory.ImageHover")));
            this.btnCategory.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnCategory.ImageNormal")));
            this.btnCategory.Location = new System.Drawing.Point(762, 7);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(40, 40);
            this.btnCategory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCategory.TabIndex = 16;
            this.btnCategory.TabStop = false;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // ProductTabPanel
            // 
            this.ProductTabPanel.BackColor = System.Drawing.SystemColors.Control;
            this.ProductTabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductTabPanel.Location = new System.Drawing.Point(0, 0);
            this.ProductTabPanel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ProductTabPanel.Name = "ProductTabPanel";
            this.ProductTabPanel.Size = new System.Drawing.Size(992, 432);
            this.ProductTabPanel.TabIndex = 2;
            // 
            // ProductTabForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 506);
            this.Controls.Add(this.ProductTabPanel);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ProductTabForm";
            this.Text = "ProductTabForm";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCategory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel ProductTabPanel;
        private System.Windows.Forms.Label label6;
        public CustomerButton btnCategory;
        private System.Windows.Forms.Label label4;
        private CustomerButton btnProduct;
    }
}