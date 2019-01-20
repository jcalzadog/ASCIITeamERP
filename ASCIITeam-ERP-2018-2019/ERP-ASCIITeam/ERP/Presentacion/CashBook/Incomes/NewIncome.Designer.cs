namespace ERP.Presentacion.CashBook.Incomes
{
    partial class NewIncome
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
            this.lblSource = new System.Windows.Forms.Label();
            this.lblEuro = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblConcept = new System.Windows.Forms.Label();
            this.cmbSource = new System.Windows.Forms.ComboBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.tbxAmount = new System.Windows.Forms.TextBox();
            this.rtbConcept = new System.Windows.Forms.RichTextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSource.Location = new System.Drawing.Point(79, 71);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(59, 17);
            this.lblSource.TabIndex = 0;
            this.lblSource.Text = "Source";
            // 
            // lblEuro
            // 
            this.lblEuro.AutoSize = true;
            this.lblEuro.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEuro.Location = new System.Drawing.Point(289, 265);
            this.lblEuro.Name = "lblEuro";
            this.lblEuro.Size = new System.Drawing.Size(17, 17);
            this.lblEuro.TabIndex = 1;
            this.lblEuro.Text = "€";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(93, 207);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(42, 17);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Date";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(92, 130);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(44, 17);
            this.lblType.TabIndex = 3;
            this.lblType.Text = "Type";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(76, 265);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(62, 17);
            this.lblAmount.TabIndex = 4;
            this.lblAmount.Text = "Amount";
            // 
            // lblConcept
            // 
            this.lblConcept.AutoSize = true;
            this.lblConcept.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConcept.Location = new System.Drawing.Point(392, 69);
            this.lblConcept.Name = "lblConcept";
            this.lblConcept.Size = new System.Drawing.Size(67, 17);
            this.lblConcept.TabIndex = 5;
            this.lblConcept.Text = "Concept";
            // 
            // cmbSource
            // 
            this.cmbSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSource.FormattingEnabled = true;
            this.cmbSource.Location = new System.Drawing.Point(149, 69);
            this.cmbSource.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSource.Name = "cmbSource";
            this.cmbSource.Size = new System.Drawing.Size(143, 24);
            this.cmbSource.TabIndex = 6;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(149, 130);
            this.cmbType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(143, 24);
            this.cmbType.TabIndex = 7;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(149, 207);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 22);
            this.dtpDate.TabIndex = 8;
            // 
            // tbxAmount
            // 
            this.tbxAmount.Location = new System.Drawing.Point(149, 262);
            this.tbxAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxAmount.Name = "tbxAmount";
            this.tbxAmount.Size = new System.Drawing.Size(133, 22);
            this.tbxAmount.TabIndex = 9;
            this.tbxAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxAmount_KeyPress);
            // 
            // rtbConcept
            // 
            this.rtbConcept.Location = new System.Drawing.Point(395, 97);
            this.rtbConcept.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbConcept.Name = "rtbConcept";
            this.rtbConcept.Size = new System.Drawing.Size(243, 132);
            this.rtbConcept.TabIndex = 10;
            this.rtbConcept.Text = "";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(560, 346);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 30);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button1_Click);
            this.btnCancel.MouseEnter += new System.EventHandler(this.btnCancel_MouseEnter);
            this.btnCancel.MouseLeave += new System.EventHandler(this.btnCancel_MouseLeave);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(463, 346);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 30);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseEnter += new System.EventHandler(this.btnSave_MouseEnter);
            this.btnSave.MouseLeave += new System.EventHandler(this.btnSave_MouseLeave);
            // 
            // NewIncome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(661, 393);
            this.ControlBox = false;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.rtbConcept);
            this.Controls.Add(this.tbxAmount);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.cmbSource);
            this.Controls.Add(this.lblConcept);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblEuro);
            this.Controls.Add(this.lblSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(679, 440);
            this.MinimumSize = new System.Drawing.Size(679, 440);
            this.Name = "NewIncome";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Income";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblEuro;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblConcept;
        private System.Windows.Forms.ComboBox cmbSource;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox tbxAmount;
        private System.Windows.Forms.RichTextBox rtbConcept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}