namespace InventoryManagementSystem
{
    partial class OrderTabForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnApproved = new Guna.UI2.WinForms.Guna2Button();
            this.btnReturned = new Guna.UI2.WinForms.Guna2Button();
            this.btnTimeExpired = new Guna.UI2.WinForms.Guna2Button();
            this.btnNotApproved = new Guna.UI2.WinForms.Guna2Button();
            this.btnWaitingForApproval = new Guna.UI2.WinForms.Guna2Button();
            this.OrderTabPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Plum;
            this.panel1.Controls.Add(this.btnApproved);
            this.panel1.Controls.Add(this.btnReturned);
            this.panel1.Controls.Add(this.btnTimeExpired);
            this.panel1.Controls.Add(this.btnNotApproved);
            this.panel1.Controls.Add(this.btnWaitingForApproval);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 450);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(992, 56);
            this.panel1.TabIndex = 2;
            // 
            // btnApproved
            // 
            this.btnApproved.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnApproved.CheckedState.CustomBorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnApproved.CustomBorderThickness = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnApproved.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnApproved.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnApproved.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnApproved.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnApproved.FillColor = System.Drawing.Color.MediumOrchid;
            this.btnApproved.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApproved.ForeColor = System.Drawing.Color.White;
            this.btnApproved.HoverState.CustomBorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnApproved.Location = new System.Drawing.Point(397, 3);
            this.btnApproved.Name = "btnApproved";
            this.btnApproved.Size = new System.Drawing.Size(191, 50);
            this.btnApproved.TabIndex = 1;
            this.btnApproved.Text = "Approved";
            this.btnApproved.Click += new System.EventHandler(this.btnApproved_Click);
            // 
            // btnReturned
            // 
            this.btnReturned.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReturned.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnReturned.CheckedState.CustomBorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReturned.CustomBorderThickness = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnReturned.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReturned.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReturned.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReturned.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReturned.FillColor = System.Drawing.Color.MediumOrchid;
            this.btnReturned.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturned.ForeColor = System.Drawing.Color.White;
            this.btnReturned.HoverState.CustomBorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReturned.Location = new System.Drawing.Point(798, 3);
            this.btnReturned.Name = "btnReturned";
            this.btnReturned.Size = new System.Drawing.Size(191, 50);
            this.btnReturned.TabIndex = 2;
            this.btnReturned.Text = "Returned";
            this.btnReturned.Click += new System.EventHandler(this.btnReturned_Click);
            // 
            // btnTimeExpired
            // 
            this.btnTimeExpired.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimeExpired.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTimeExpired.CheckedState.CustomBorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTimeExpired.CustomBorderThickness = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnTimeExpired.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTimeExpired.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTimeExpired.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTimeExpired.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTimeExpired.FillColor = System.Drawing.Color.MediumOrchid;
            this.btnTimeExpired.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimeExpired.ForeColor = System.Drawing.Color.White;
            this.btnTimeExpired.HoverState.CustomBorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTimeExpired.Location = new System.Drawing.Point(601, 3);
            this.btnTimeExpired.Name = "btnTimeExpired";
            this.btnTimeExpired.Size = new System.Drawing.Size(191, 50);
            this.btnTimeExpired.TabIndex = 2;
            this.btnTimeExpired.Text = "Time Expired";
            this.btnTimeExpired.Click += new System.EventHandler(this.btnTimeExpired_Click);
            // 
            // btnNotApproved
            // 
            this.btnNotApproved.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnNotApproved.CheckedState.CustomBorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNotApproved.CustomBorderThickness = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnNotApproved.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNotApproved.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNotApproved.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNotApproved.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNotApproved.FillColor = System.Drawing.Color.MediumOrchid;
            this.btnNotApproved.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotApproved.ForeColor = System.Drawing.Color.White;
            this.btnNotApproved.HoverState.CustomBorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNotApproved.Location = new System.Drawing.Point(200, 3);
            this.btnNotApproved.Name = "btnNotApproved";
            this.btnNotApproved.Size = new System.Drawing.Size(191, 50);
            this.btnNotApproved.TabIndex = 1;
            this.btnNotApproved.Text = "Not Approved";
            this.btnNotApproved.Click += new System.EventHandler(this.btnNotApproved_Click);
            // 
            // btnWaitingForApproval
            // 
            this.btnWaitingForApproval.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnWaitingForApproval.CheckedState.CustomBorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnWaitingForApproval.CustomBorderThickness = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnWaitingForApproval.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnWaitingForApproval.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnWaitingForApproval.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnWaitingForApproval.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnWaitingForApproval.FillColor = System.Drawing.Color.MediumOrchid;
            this.btnWaitingForApproval.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWaitingForApproval.ForeColor = System.Drawing.Color.White;
            this.btnWaitingForApproval.HoverState.CustomBorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnWaitingForApproval.Location = new System.Drawing.Point(3, 3);
            this.btnWaitingForApproval.Name = "btnWaitingForApproval";
            this.btnWaitingForApproval.Size = new System.Drawing.Size(191, 50);
            this.btnWaitingForApproval.TabIndex = 0;
            this.btnWaitingForApproval.Text = "Waiting For Approval";
            this.btnWaitingForApproval.Click += new System.EventHandler(this.btnWaitingForApproval_Click);
            // 
            // OrderTabPanel
            // 
            this.OrderTabPanel.BackColor = System.Drawing.SystemColors.Control;
            this.OrderTabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrderTabPanel.Location = new System.Drawing.Point(0, 0);
            this.OrderTabPanel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.OrderTabPanel.Name = "OrderTabPanel";
            this.OrderTabPanel.Size = new System.Drawing.Size(992, 450);
            this.OrderTabPanel.TabIndex = 3;
            // 
            // OrderTabForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 506);
            this.Controls.Add(this.OrderTabPanel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "OrderTabForm";
            this.Text = "OrderTabForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel OrderTabPanel;
        private Guna.UI2.WinForms.Guna2Button btnWaitingForApproval;
        private Guna.UI2.WinForms.Guna2Button btnNotApproved;
        private Guna.UI2.WinForms.Guna2Button btnApproved;
        private Guna.UI2.WinForms.Guna2Button btnReturned;
        private Guna.UI2.WinForms.Guna2Button btnTimeExpired;
    }
}