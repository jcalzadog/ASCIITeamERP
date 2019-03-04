namespace ERP.Presentacion.Usuarios
{
    partial class EditarRol
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblPermissions = new System.Windows.Forms.Label();
            this.dgvPermissions = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDeny = new System.Windows.Forms.Button();
            this.btnAllow = new System.Windows.Forms.Button();
            this.lblRole = new System.Windows.Forms.Label();
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.btnNewRole = new System.Windows.Forms.Button();
            this.btnDeleteRol = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissions)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPermissions
            // 
            this.lblPermissions.AutoSize = true;
            this.lblPermissions.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPermissions.Location = new System.Drawing.Point(73, 112);
            this.lblPermissions.Name = "lblPermissions";
            this.lblPermissions.Size = new System.Drawing.Size(95, 17);
            this.lblPermissions.TabIndex = 15;
            this.lblPermissions.Text = "Permissions";
            // 
            // dgvPermissions
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPermissions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPermissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermissions.Location = new System.Drawing.Point(76, 132);
            this.dgvPermissions.Name = "dgvPermissions";
            this.dgvPermissions.RowTemplate.Height = 24;
            this.dgvPermissions.Size = new System.Drawing.Size(444, 216);
            this.dgvPermissions.TabIndex = 14;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(475, 369);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 29);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            this.btnSave.MouseEnter += new System.EventHandler(this.style_MouseEnter);
            this.btnSave.MouseLeave += new System.EventHandler(this.style_MouseLeave);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(556, 369);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 29);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnCancel_Click_1);
            this.btnClose.MouseEnter += new System.EventHandler(this.style_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.style_MouseLeave);
            // 
            // btnDeny
            // 
            this.btnDeny.BackColor = System.Drawing.Color.White;
            this.btnDeny.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeny.Location = new System.Drawing.Point(425, 87);
            this.btnDeny.Name = "btnDeny";
            this.btnDeny.Size = new System.Drawing.Size(95, 27);
            this.btnDeny.TabIndex = 11;
            this.btnDeny.Text = "Deny All";
            this.btnDeny.UseVisualStyleBackColor = false;
            this.btnDeny.Click += new System.EventHandler(this.btnDeny_Click_1);
            this.btnDeny.MouseEnter += new System.EventHandler(this.style_MouseEnter);
            this.btnDeny.MouseLeave += new System.EventHandler(this.style_MouseLeave);
            // 
            // btnAllow
            // 
            this.btnAllow.BackColor = System.Drawing.Color.White;
            this.btnAllow.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllow.Location = new System.Drawing.Point(319, 87);
            this.btnAllow.Name = "btnAllow";
            this.btnAllow.Size = new System.Drawing.Size(100, 27);
            this.btnAllow.TabIndex = 10;
            this.btnAllow.Text = "Allow All";
            this.btnAllow.UseVisualStyleBackColor = false;
            this.btnAllow.Click += new System.EventHandler(this.btnAllow_Click_1);
            this.btnAllow.MouseEnter += new System.EventHandler(this.style_MouseEnter);
            this.btnAllow.MouseLeave += new System.EventHandler(this.style_MouseLeave);
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.Location = new System.Drawing.Point(119, 49);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(41, 17);
            this.lblRole.TabIndex = 8;
            this.lblRole.Text = "Role";
            // 
            // cmbRoles
            // 
            this.cmbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoles.FormattingEnabled = true;
            this.cmbRoles.Location = new System.Drawing.Point(166, 46);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(201, 24);
            this.cmbRoles.TabIndex = 16;
            this.cmbRoles.SelectedIndexChanged += new System.EventHandler(this.cmbRoles_SelectedIndexChanged);
            // 
            // btnNewRole
            // 
            this.btnNewRole.BackColor = System.Drawing.Color.White;
            this.btnNewRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewRole.Location = new System.Drawing.Point(374, 43);
            this.btnNewRole.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewRole.Name = "btnNewRole";
            this.btnNewRole.Size = new System.Drawing.Size(100, 28);
            this.btnNewRole.TabIndex = 17;
            this.btnNewRole.Text = "New Role";
            this.btnNewRole.UseVisualStyleBackColor = false;
            this.btnNewRole.Click += new System.EventHandler(this.btnNewRole_Click);
            this.btnNewRole.MouseEnter += new System.EventHandler(this.style_MouseEnter);
            this.btnNewRole.MouseLeave += new System.EventHandler(this.style_MouseLeave);
            // 
            // btnDeleteRol
            // 
            this.btnDeleteRol.BackColor = System.Drawing.Color.White;
            this.btnDeleteRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteRol.Location = new System.Drawing.Point(76, 369);
            this.btnDeleteRol.Name = "btnDeleteRol";
            this.btnDeleteRol.Size = new System.Drawing.Size(127, 28);
            this.btnDeleteRol.TabIndex = 18;
            this.btnDeleteRol.Text = "Delete Role";
            this.btnDeleteRol.UseVisualStyleBackColor = false;
            this.btnDeleteRol.Click += new System.EventHandler(this.btnDeleteRol_Click);
            this.btnDeleteRol.MouseEnter += new System.EventHandler(this.style_MouseEnter);
            this.btnDeleteRol.MouseLeave += new System.EventHandler(this.style_MouseLeave);
            // 
            // EditarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(663, 410);
            this.ControlBox = false;
            this.Controls.Add(this.btnDeleteRol);
            this.Controls.Add(this.btnNewRole);
            this.Controls.Add(this.cmbRoles);
            this.Controls.Add(this.lblPermissions);
            this.Controls.Add(this.dgvPermissions);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDeny);
            this.Controls.Add(this.btnAllow);
            this.Controls.Add(this.lblRole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(681, 457);
            this.MinimumSize = new System.Drawing.Size(681, 457);
            this.Name = "EditarRol";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Rol";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPermissions;
        private System.Windows.Forms.DataGridView dgvPermissions;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDeny;
        private System.Windows.Forms.Button btnAllow;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cmbRoles;
        private System.Windows.Forms.Button btnNewRole;
        private System.Windows.Forms.Button btnDeleteRol;
    }
}