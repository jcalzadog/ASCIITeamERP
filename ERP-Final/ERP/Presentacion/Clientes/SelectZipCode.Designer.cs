namespace ERP.Presentacion.Clientes
{
    partial class SelectZipCode
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCities = new System.Windows.Forms.DataGridView();
            this.dgvZipCode = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblRegion = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.cmbRegion = new System.Windows.Forms.ComboBox();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.btnChooseCode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZipCode)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCities
            // 
            this.dgvCities.AllowUserToResizeColumns = false;
            this.dgvCities.AllowUserToResizeRows = false;
            this.dgvCities.BackgroundColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCities.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvCities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCities.Location = new System.Drawing.Point(70, 73);
            this.dgvCities.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvCities.MultiSelect = false;
            this.dgvCities.Name = "dgvCities";
            this.dgvCities.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCities.RowTemplate.Height = 24;
            this.dgvCities.Size = new System.Drawing.Size(203, 262);
            this.dgvCities.TabIndex = 0;
            this.dgvCities.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCities_CellClick);
            // 
            // dgvZipCode
            // 
            this.dgvZipCode.AllowUserToResizeColumns = false;
            this.dgvZipCode.AllowUserToResizeRows = false;
            this.dgvZipCode.BackgroundColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvZipCode.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvZipCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvZipCode.Location = new System.Drawing.Point(328, 73);
            this.dgvZipCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvZipCode.MultiSelect = false;
            this.dgvZipCode.Name = "dgvZipCode";
            this.dgvZipCode.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvZipCode.RowTemplate.Height = 24;
            this.dgvZipCode.Size = new System.Drawing.Size(203, 262);
            this.dgvZipCode.TabIndex = 1;
            this.dgvZipCode.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvZipCode_CellClick);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(549, 353);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = true;
            this.lblRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegion.Location = new System.Drawing.Point(89, 41);
            this.lblRegion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(47, 13);
            this.lblRegion.TabIndex = 3;
            this.lblRegion.Text = "Region";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(326, 41);
            this.lblState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(37, 13);
            this.lblState.TabIndex = 4;
            this.lblState.Text = "State";
            // 
            // cmbRegion
            // 
            this.cmbRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegion.FormattingEnabled = true;
            this.cmbRegion.Location = new System.Drawing.Point(134, 38);
            this.cmbRegion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbRegion.Name = "cmbRegion";
            this.cmbRegion.Size = new System.Drawing.Size(140, 21);
            this.cmbRegion.TabIndex = 5;
            this.cmbRegion.SelectedIndexChanged += new System.EventHandler(this.cmbRegion_SelectedIndexChanged);
            // 
            // cmbState
            // 
            this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(380, 41);
            this.cmbState.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(152, 21);
            this.cmbState.TabIndex = 6;
            this.cmbState.SelectedIndexChanged += new System.EventHandler(this.cmbState_SelectedIndexChanged);
            // 
            // btnChooseCode
            // 
            this.btnChooseCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseCode.Location = new System.Drawing.Point(426, 353);
            this.btnChooseCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChooseCode.Name = "btnChooseCode";
            this.btnChooseCode.Size = new System.Drawing.Size(112, 23);
            this.btnChooseCode.TabIndex = 7;
            this.btnChooseCode.Text = "Choose Zip Code";
            this.btnChooseCode.UseVisualStyleBackColor = true;
            this.btnChooseCode.Click += new System.EventHandler(this.btnChooseCode_Click);
            this.btnChooseCode.MouseEnter += new System.EventHandler(this.btnChooseCode_MouseEnter);
            this.btnChooseCode.MouseLeave += new System.EventHandler(this.btnChooseCode_MouseLeave);
            // 
            // SelectZipCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(637, 401);
            this.ControlBox = false;
            this.Controls.Add(this.btnChooseCode);
            this.Controls.Add(this.cmbState);
            this.Controls.Add(this.cmbRegion);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblRegion);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvZipCode);
            this.Controls.Add(this.dgvCities);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(653, 440);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(653, 440);
            this.Name = "SelectZipCode";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Zip Code";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZipCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCities;
        private System.Windows.Forms.DataGridView dgvZipCode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.ComboBox cmbRegion;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.Button btnChooseCode;
    }
}