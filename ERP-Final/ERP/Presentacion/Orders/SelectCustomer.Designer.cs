namespace ERP.Presentacion.Orders
{
    partial class SelectCustomer
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
            this.dgvSelectCustomer = new System.Windows.Forms.DataGridView();
            this.txtSearchCustomer = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSelectCustomer
            // 
            this.dgvSelectCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectCustomer.Location = new System.Drawing.Point(12, 42);
            this.dgvSelectCustomer.Name = "dgvSelectCustomer";
            this.dgvSelectCustomer.Size = new System.Drawing.Size(487, 241);
            this.dgvSelectCustomer.TabIndex = 0;
            this.dgvSelectCustomer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSelectCustomer_CellDoubleClick);
            // 
            // txtSearchCustomer
            // 
            this.txtSearchCustomer.Location = new System.Drawing.Point(12, 13);
            this.txtSearchCustomer.Name = "txtSearchCustomer";
            this.txtSearchCustomer.Size = new System.Drawing.Size(284, 20);
            this.txtSearchCustomer.TabIndex = 1;
            this.txtSearchCustomer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearchCustomer_KeyUp);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(424, 13);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SelectCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 295);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtSearchCustomer);
            this.Controls.Add(this.dgvSelectCustomer);
            this.Name = "SelectCustomer";
            this.Text = "SelectCustomer";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSelectCustomer;
        private System.Windows.Forms.TextBox txtSearchCustomer;
        private System.Windows.Forms.Button btnCancel;
    }
}