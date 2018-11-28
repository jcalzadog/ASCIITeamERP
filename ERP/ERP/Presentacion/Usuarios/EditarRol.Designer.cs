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
            this.lblPermissions = new System.Windows.Forms.Label();
            this.dgvPermissions = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDeny = new System.Windows.Forms.Button();
            this.btnAllow = new System.Windows.Forms.Button();
            this.lblRole = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnNewRole = new System.Windows.Forms.Button();
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
            this.lblPermissions.Click += new System.EventHandler(this.lblPermissions_Click);
            // 
            // dgvPermissions
            // 
            this.dgvPermissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermissions.Location = new System.Drawing.Point(76, 132);
            this.dgvPermissions.Name = "dgvPermissions";
            this.dgvPermissions.RowTemplate.Height = 24;
            this.dgvPermissions.Size = new System.Drawing.Size(444, 216);
            this.dgvPermissions.TabIndex = 14;
            this.dgvPermissions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPermissions_CellContentClick);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(475, 369);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 29);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(556, 369);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 29);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDeny
            // 
            this.btnDeny.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnDeny.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeny.Location = new System.Drawing.Point(425, 87);
            this.btnDeny.Name = "btnDeny";
            this.btnDeny.Size = new System.Drawing.Size(95, 27);
            this.btnDeny.TabIndex = 11;
            this.btnDeny.Text = "Deny All";
            this.btnDeny.UseVisualStyleBackColor = false;
            this.btnDeny.Click += new System.EventHandler(this.btnDeny_Click);
            // 
            // btnAllow
            // 
            this.btnAllow.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAllow.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllow.Location = new System.Drawing.Point(319, 87);
            this.btnAllow.Name = "btnAllow";
            this.btnAllow.Size = new System.Drawing.Size(100, 27);
            this.btnAllow.TabIndex = 10;
            this.btnAllow.Text = "Allow All";
            this.btnAllow.UseVisualStyleBackColor = false;
            this.btnAllow.Click += new System.EventHandler(this.btnAllow_Click);
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
            this.lblRole.Click += new System.EventHandler(this.lblRole_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(166, 46);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(201, 24);
            this.comboBox1.TabIndex = 16;
            // 
            // btnNewRole
            // 
            this.btnNewRole.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnNewRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewRole.Location = new System.Drawing.Point(374, 43);
            this.btnNewRole.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewRole.Name = "btnNewRole";
            this.btnNewRole.Size = new System.Drawing.Size(100, 28);
            this.btnNewRole.TabIndex = 17;
            this.btnNewRole.Text = "New Role";
            this.btnNewRole.UseVisualStyleBackColor = false;
            this.btnNewRole.Click += new System.EventHandler(this.btnNewRole_Click);
            // 
            // EditarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(663, 410);
            this.Controls.Add(this.btnNewRole);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblPermissions);
            this.Controls.Add(this.dgvPermissions);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDeny);
            this.Controls.Add(this.btnAllow);
            this.Controls.Add(this.lblRole);
            this.Name = "EditarRol";
            this.Text = "EditarRol";
            this.Load += new System.EventHandler(this.EditarRol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPermissions;
        private System.Windows.Forms.DataGridView dgvPermissions;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDeny;
        private System.Windows.Forms.Button btnAllow;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnNewRole;
    }
}