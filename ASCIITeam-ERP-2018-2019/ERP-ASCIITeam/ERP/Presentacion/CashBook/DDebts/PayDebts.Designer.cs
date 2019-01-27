namespace ERP.Presentacion.CashBook.DDebts
{
    partial class PayDebts
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chbCollectTotal = new System.Windows.Forms.CheckBox();
            this.tbxAmount = new System.Windows.Forms.TextBox();
            this.txtNewDebt = new System.Windows.Forms.TextBox();
            this.tbxTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(257, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 17);
            this.label6.TabIndex = 23;
            this.label6.Text = "€";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(257, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "€";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(257, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "€";
            // 
            // chbCollectTotal
            // 
            this.chbCollectTotal.AutoSize = true;
            this.chbCollectTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbCollectTotal.Location = new System.Drawing.Point(296, 83);
            this.chbCollectTotal.Name = "chbCollectTotal";
            this.chbCollectTotal.Size = new System.Drawing.Size(149, 21);
            this.chbCollectTotal.TabIndex = 20;
            this.chbCollectTotal.Text = "Collect the Total";
            this.chbCollectTotal.UseVisualStyleBackColor = true;
            this.chbCollectTotal.CheckedChanged += new System.EventHandler(this.chbCollectTotal_CheckedChanged);
            // 
            // tbxAmount
            // 
            this.tbxAmount.Location = new System.Drawing.Point(124, 81);
            this.tbxAmount.Name = "tbxAmount";
            this.tbxAmount.Size = new System.Drawing.Size(127, 22);
            this.tbxAmount.TabIndex = 19;
            this.tbxAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxAmount_KeyPress);
            this.tbxAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxAmount_KeyUp);
            // 
            // txtNewDebt
            // 
            this.txtNewDebt.Enabled = false;
            this.txtNewDebt.Location = new System.Drawing.Point(124, 120);
            this.txtNewDebt.Name = "txtNewDebt";
            this.txtNewDebt.Size = new System.Drawing.Size(127, 22);
            this.txtNewDebt.TabIndex = 18;
            // 
            // tbxTotal
            // 
            this.tbxTotal.Enabled = false;
            this.tbxTotal.Location = new System.Drawing.Point(124, 40);
            this.tbxTotal.Name = "tbxTotal";
            this.tbxTotal.Size = new System.Drawing.Size(127, 22);
            this.tbxTotal.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "New Debt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Total";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(217, 200);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 30);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnSave.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(334, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 30);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnCancel.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // PayDebts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(491, 264);
            this.ControlBox = false;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chbCollectTotal);
            this.Controls.Add(this.tbxAmount);
            this.Controls.Add(this.txtNewDebt);
            this.Controls.Add(this.tbxTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(509, 311);
            this.MinimumSize = new System.Drawing.Size(509, 311);
            this.Name = "PayDebts";
            this.Text = "Pay Debt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chbCollectTotal;
        private System.Windows.Forms.TextBox tbxAmount;
        private System.Windows.Forms.TextBox txtNewDebt;
        private System.Windows.Forms.TextBox tbxTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}