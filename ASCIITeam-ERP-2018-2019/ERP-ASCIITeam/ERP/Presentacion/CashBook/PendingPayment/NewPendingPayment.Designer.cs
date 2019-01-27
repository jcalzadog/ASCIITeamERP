namespace ERP.Presentacion.CashBook.PendingPayment
{
    partial class NewPendingPayment
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.tbxAmount = new System.Windows.Forms.TextBox();
            this.rtbConcept = new System.Windows.Forms.RichTextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(95, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(92, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(88, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Concept";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(176, 44);
            this.cmbType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(208, 24);
            this.cmbType.TabIndex = 3;
            // 
            // tbxAmount
            // 
            this.tbxAmount.Location = new System.Drawing.Point(176, 84);
            this.tbxAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxAmount.Name = "tbxAmount";
            this.tbxAmount.Size = new System.Drawing.Size(135, 22);
            this.tbxAmount.TabIndex = 4;
            this.tbxAmount.TextChanged += new System.EventHandler(this.tbxAmount_TextChanged);
            this.tbxAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxAmount_KeyPress);
            // 
            // rtbConcept
            // 
            this.rtbConcept.Location = new System.Drawing.Point(176, 129);
            this.rtbConcept.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbConcept.Name = "rtbConcept";
            this.rtbConcept.Size = new System.Drawing.Size(328, 96);
            this.rtbConcept.TabIndex = 5;
            this.rtbConcept.Text = "";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(517, 268);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 31);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnCancel.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(424, 268);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 31);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnSave.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(317, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "€";
            // 
            // NewPendingPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(609, 311);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.rtbConcept);
            this.Controls.Add(this.tbxAmount);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(627, 358);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(627, 358);
            this.Name = "NewPendingPayment";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Pending Payment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox tbxAmount;
        private System.Windows.Forms.RichTextBox rtbConcept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
    }
}