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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCities = new System.Windows.Forms.DataGridView();
            this.dgvZipCode = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCities.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCities.Location = new System.Drawing.Point(93, 90);
            this.dgvCities.MultiSelect = false;
            this.dgvCities.Name = "dgvCities";
            this.dgvCities.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCities.RowTemplate.Height = 24;
            this.dgvCities.Size = new System.Drawing.Size(271, 323);
            this.dgvCities.TabIndex = 0;
            this.dgvCities.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCities_CellClick);
            // 
            // dgvZipCode
            // 
            this.dgvZipCode.AllowUserToResizeColumns = false;
            this.dgvZipCode.AllowUserToResizeRows = false;
            this.dgvZipCode.BackgroundColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvZipCode.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvZipCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvZipCode.Location = new System.Drawing.Point(437, 90);
            this.dgvZipCode.MultiSelect = false;
            this.dgvZipCode.Name = "dgvZipCode";
            this.dgvZipCode.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvZipCode.RowTemplate.Height = 24;
            this.dgvZipCode.Size = new System.Drawing.Size(271, 323);
            this.dgvZipCode.TabIndex = 1;
            this.dgvZipCode.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvZipCode_CellClick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(732, 434);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = true;
            this.lblRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegion.Location = new System.Drawing.Point(119, 50);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(59, 17);
            this.lblRegion.TabIndex = 3;
            this.lblRegion.Text = "Region";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(434, 50);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(46, 17);
            this.lblState.TabIndex = 4;
            this.lblState.Text = "State";
            // 
            // cmbRegion
            // 
            this.cmbRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegion.FormattingEnabled = true;
            this.cmbRegion.Location = new System.Drawing.Point(178, 47);
            this.cmbRegion.Name = "cmbRegion";
            this.cmbRegion.Size = new System.Drawing.Size(186, 24);
            this.cmbRegion.TabIndex = 5;
            this.cmbRegion.SelectedIndexChanged += new System.EventHandler(this.cmbRegion_SelectedIndexChanged);
            // 
            // cmbState
            // 
            this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(506, 50);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(202, 24);
            this.cmbState.TabIndex = 6;
            this.cmbState.SelectedIndexChanged += new System.EventHandler(this.cmbState_SelectedIndexChanged);
            // 
            // btnChooseCode
            // 
            this.btnChooseCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseCode.Location = new System.Drawing.Point(568, 434);
            this.btnChooseCode.Name = "btnChooseCode";
            this.btnChooseCode.Size = new System.Drawing.Size(149, 28);
            this.btnChooseCode.TabIndex = 7;
            this.btnChooseCode.Text = "Choose Zip Code";
            this.btnChooseCode.UseVisualStyleBackColor = true;
            this.btnChooseCode.Click += new System.EventHandler(this.btnChooseCode_Click);
            // 
            // SelectZipCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(847, 485);
            this.ControlBox = false;
            this.Controls.Add(this.btnChooseCode);
            this.Controls.Add(this.cmbState);
            this.Controls.Add(this.cmbRegion);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblRegion);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvZipCode);
            this.Controls.Add(this.dgvCities);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(865, 532);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(865, 532);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.ComboBox cmbRegion;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.Button btnChooseCode;
    }
}