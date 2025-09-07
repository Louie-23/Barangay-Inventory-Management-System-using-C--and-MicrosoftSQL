namespace InventoryManagementSystem
{
    partial class UserOrderModuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserOrderModuleForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUserCName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUserCId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvUserProduct = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearchProd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserPid = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUserPrice = new System.Windows.Forms.TextBox();
            this.txtUserTotal = new System.Windows.Forms.TextBox();
            this.txtUserPName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dtUserOrder = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.btnUserInsert = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.UDUserQty = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UDUserQty)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(674, 437);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 16);
            this.label11.TabIndex = 20;
            this.label11.Text = "Total :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(681, 404);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 16);
            this.label10.TabIndex = 18;
            this.label10.Text = "Qty :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(672, 376);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "Price :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Violet;
            this.panel1.Controls.Add(this.pictureBoxClose);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 50);
            this.panel1.TabIndex = 4;
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxClose.Image")));
            this.pictureBoxClose.Location = new System.Drawing.Point(903, 0);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxClose.TabIndex = 11;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Product and Customer Activity";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 467);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Name:";
            // 
            // txtUserCName
            // 
            this.txtUserCName.Enabled = false;
            this.txtUserCName.Location = new System.Drawing.Point(26, 486);
            this.txtUserCName.Name = "txtUserCName";
            this.txtUserCName.Size = new System.Drawing.Size(236, 22);
            this.txtUserCName.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 404);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "User Id :";
            // 
            // txtUserCId
            // 
            this.txtUserCId.Enabled = false;
            this.txtUserCId.Location = new System.Drawing.Point(26, 425);
            this.txtUserCId.Name = "txtUserCId";
            this.txtUserCId.Size = new System.Drawing.Size(236, 22);
            this.txtUserCId.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Purple;
            this.label2.Location = new System.Drawing.Point(23, 373);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "PERSON";
            // 
            // dgvUserProduct
            // 
            this.dgvUserProduct.AllowUserToAddRows = false;
            this.dgvUserProduct.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvUserProduct.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Violet;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUserProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUserProduct.ColumnHeadersHeight = 30;
            this.dgvUserProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUserProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column7});
            this.dgvUserProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvUserProduct.EnableHeadersVisualStyles = false;
            this.dgvUserProduct.Location = new System.Drawing.Point(0, 50);
            this.dgvUserProduct.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvUserProduct.Name = "dgvUserProduct";
            this.dgvUserProduct.RowHeadersVisible = false;
            this.dgvUserProduct.Size = new System.Drawing.Size(933, 264);
            this.dgvUserProduct.TabIndex = 9;
            this.dgvUserProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserProduct_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 47;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.HeaderText = "Product Id";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 91;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 68;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "Qty";
            this.Column3.Name = "Column3";
            this.Column3.Width = 51;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "Price";
            this.Column4.Name = "Column4";
            this.Column4.Width = 60;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.HeaderText = "Description";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column7.HeaderText = "Category";
            this.Column7.Name = "Column7";
            this.Column7.Width = 87;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Purple;
            this.label3.Location = new System.Drawing.Point(332, 373);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "ITEM";
            // 
            // txtSearchProd
            // 
            this.txtSearchProd.Location = new System.Drawing.Point(255, 320);
            this.txtSearchProd.Name = "txtSearchProd";
            this.txtSearchProd.Size = new System.Drawing.Size(422, 22);
            this.txtSearchProd.TabIndex = 11;
            this.txtSearchProd.TextChanged += new System.EventHandler(this.txtSearchProd_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(171, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Search Box :";
            // 
            // txtUserPid
            // 
            this.txtUserPid.Enabled = false;
            this.txtUserPid.Location = new System.Drawing.Point(335, 425);
            this.txtUserPid.Name = "txtUserPid";
            this.txtUserPid.Size = new System.Drawing.Size(236, 22);
            this.txtUserPid.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(332, 406);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Item Id :";
            // 
            // txtUserPrice
            // 
            this.txtUserPrice.Enabled = false;
            this.txtUserPrice.Location = new System.Drawing.Point(721, 373);
            this.txtUserPrice.Name = "txtUserPrice";
            this.txtUserPrice.Size = new System.Drawing.Size(150, 22);
            this.txtUserPrice.TabIndex = 15;
            // 
            // txtUserTotal
            // 
            this.txtUserTotal.Enabled = false;
            this.txtUserTotal.Location = new System.Drawing.Point(721, 434);
            this.txtUserTotal.Name = "txtUserTotal";
            this.txtUserTotal.Size = new System.Drawing.Size(150, 22);
            this.txtUserTotal.TabIndex = 19;
            // 
            // txtUserPName
            // 
            this.txtUserPName.Enabled = false;
            this.txtUserPName.Location = new System.Drawing.Point(335, 486);
            this.txtUserPName.Name = "txtUserPName";
            this.txtUserPName.Size = new System.Drawing.Size(236, 22);
            this.txtUserPName.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(332, 467);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 16);
            this.label12.TabIndex = 22;
            this.label12.Text = "Item Name :";
            // 
            // dtUserOrder
            // 
            this.dtUserOrder.CustomFormat = "MMM d, yyyy | h:mm tt";
            this.dtUserOrder.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtUserOrder.Location = new System.Drawing.Point(335, 539);
            this.dtUserOrder.Name = "dtUserOrder";
            this.dtUserOrder.Size = new System.Drawing.Size(200, 22);
            this.dtUserOrder.TabIndex = 23;
            this.dtUserOrder.ValueChanged += new System.EventHandler(this.dtOrder_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(332, 520);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 16);
            this.label13.TabIndex = 24;
            this.label13.Text = "Return Date :";
            // 
            // btnUserInsert
            // 
            this.btnUserInsert.BackColor = System.Drawing.Color.OliveDrab;
            this.btnUserInsert.FlatAppearance.BorderSize = 0;
            this.btnUserInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserInsert.ForeColor = System.Drawing.Color.White;
            this.btnUserInsert.Location = new System.Drawing.Point(672, 526);
            this.btnUserInsert.Margin = new System.Windows.Forms.Padding(4);
            this.btnUserInsert.Name = "btnUserInsert";
            this.btnUserInsert.Size = new System.Drawing.Size(120, 35);
            this.btnUserInsert.TabIndex = 25;
            this.btnUserInsert.Text = "Insert Activity";
            this.btnUserInsert.UseVisualStyleBackColor = false;
            this.btnUserInsert.Click += new System.EventHandler(this.btnUserInsert_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Red;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(800, 526);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 35);
            this.btnClear.TabIndex = 27;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // UDUserQty
            // 
            this.UDUserQty.Location = new System.Drawing.Point(721, 402);
            this.UDUserQty.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.UDUserQty.Name = "UDUserQty";
            this.UDUserQty.Size = new System.Drawing.Size(149, 22);
            this.UDUserQty.TabIndex = 28;
            this.UDUserQty.ValueChanged += new System.EventHandler(this.UDUserQty_ValueChanged);
            // 
            // UserOrderModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 588);
            this.Controls.Add(this.UDUserQty);
            this.Controls.Add(this.dgvUserProduct);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUserInsert);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtUserTotal);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtUserOrder);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUserPrice);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUserCName);
            this.Controls.Add(this.txtSearchProd);
            this.Controls.Add(this.txtUserPName);
            this.Controls.Add(this.txtUserCId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUserPid);
            this.Controls.Add(this.label8);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserOrderModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserOrdelModuleForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UDUserQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUserCName;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtUserCId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvUserProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearchProd;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtUserPid;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtUserPrice;
        private System.Windows.Forms.TextBox txtUserTotal;
        private System.Windows.Forms.TextBox txtUserPName;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.DateTimePicker dtUserOrder;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.Button btnUserInsert;
        public System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.NumericUpDown UDUserQty;
    }
}