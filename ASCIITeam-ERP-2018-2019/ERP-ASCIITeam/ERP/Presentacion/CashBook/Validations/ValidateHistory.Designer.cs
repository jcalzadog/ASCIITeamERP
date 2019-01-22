namespace ERP.Presentacion.CashBook.Validations
{
    partial class ValidateHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnValidation = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvValidate = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValidate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnValidation
            // 
            this.btnValidation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidation.Location = new System.Drawing.Point(889, 336);
            this.btnValidation.Margin = new System.Windows.Forms.Padding(4);
            this.btnValidation.Name = "btnValidation";
            this.btnValidation.Size = new System.Drawing.Size(205, 42);
            this.btnValidation.TabIndex = 0;
            this.btnValidation.Text = "Validation Phase";
            this.btnValidation.UseVisualStyleBackColor = true;
            this.btnValidation.Click += new System.EventHandler(this.button1_Click);
            this.btnValidation.MouseEnter += new System.EventHandler(this.btnValidation_MouseEnter);
            this.btnValidation.MouseLeave += new System.EventHandler(this.btnValidation_MouseLeave);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1119, 336);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(147, 42);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            // 
            // dgvValidate
            // 
            this.dgvValidate.AllowUserToAddRows = false;
            this.dgvValidate.AllowUserToDeleteRows = false;
            this.dgvValidate.AllowUserToResizeColumns = false;
            this.dgvValidate.AllowUserToResizeRows = false;
            this.dgvValidate.BackgroundColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvValidate.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvValidate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValidate.Location = new System.Drawing.Point(16, 28);
            this.dgvValidate.Margin = new System.Windows.Forms.Padding(4);
            this.dgvValidate.MultiSelect = false;
            this.dgvValidate.Name = "dgvValidate";
            this.dgvValidate.ReadOnly = true;
            this.dgvValidate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvValidate.Size = new System.Drawing.Size(1249, 300);
            this.dgvValidate.TabIndex = 2;
            // 
            // ValidateHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1279, 383);
            this.ControlBox = false;
            this.Controls.Add(this.dgvValidate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnValidation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1297, 430);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1297, 430);
            this.Name = "ValidateHistory";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Validate History";
            ((System.ComponentModel.ISupportInitialize)(this.dgvValidate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnValidation;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvValidate;
    }
}