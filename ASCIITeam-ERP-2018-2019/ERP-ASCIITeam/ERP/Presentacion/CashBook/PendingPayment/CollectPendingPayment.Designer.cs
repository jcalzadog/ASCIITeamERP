namespace ERP.Presentacion.CashBook.PendingPayment
{
    partial class CollectPendingPayment
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxTotal = new System.Windows.Forms.TextBox();
            this.tbxNewPp = new System.Windows.Forms.TextBox();
            this.tbxAmount = new System.Windows.Forms.TextBox();
            this.chbCollectTotal = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(396, 214);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 30);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnCancel.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(279, 214);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnSave.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(134, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(118, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Amount";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "New Pending Payment";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tbxTotal
            // 
            this.tbxTotal.Enabled = false;
            this.tbxTotal.Location = new System.Drawing.Point(186, 54);
            this.tbxTotal.Name = "tbxTotal";
            this.tbxTotal.Size = new System.Drawing.Size(127, 22);
            this.tbxTotal.TabIndex = 5;
            // 
            // tbxNewPp
            // 
            this.tbxNewPp.Enabled = false;
            this.tbxNewPp.Location = new System.Drawing.Point(186, 134);
            this.tbxNewPp.Name = "tbxNewPp";
            this.tbxNewPp.Size = new System.Drawing.Size(127, 22);
            this.tbxNewPp.TabIndex = 6;
            // 
            // tbxAmount
            // 
            this.tbxAmount.Location = new System.Drawing.Point(186, 95);
            this.tbxAmount.Name = "tbxAmount";
            this.tbxAmount.Size = new System.Drawing.Size(127, 22);
            this.tbxAmount.TabIndex = 7;
            this.tbxAmount.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.tbxAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxAmount_KeyPress);
            this.tbxAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxAmount_KeyUp);
            // 
            // chbCollectTotal
            // 
            this.chbCollectTotal.AutoSize = true;
            this.chbCollectTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbCollectTotal.Location = new System.Drawing.Point(358, 97);
            this.chbCollectTotal.Name = "chbCollectTotal";
            this.chbCollectTotal.Size = new System.Drawing.Size(149, 21);
            this.chbCollectTotal.TabIndex = 8;
            this.chbCollectTotal.Text = "Collect the Total";
            this.chbCollectTotal.UseVisualStyleBackColor = true;
            this.chbCollectTotal.CheckedChanged += new System.EventHandler(this.chbCollectTotal_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(319, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "€";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(319, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "€";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(319, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "€";
            // 
            // CollectPendingPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(519, 256);
            this.ControlBox = false;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chbCollectTotal);
            this.Controls.Add(this.tbxAmount);
            this.Controls.Add(this.tbxNewPp);
            this.Controls.Add(this.tbxTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(537, 303);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(537, 303);
            this.Name = "CollectPendingPayment";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Collect Pending Payment";
            this.Load += new System.EventHandler(this.CollectPendingPayment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxTotal;
        private System.Windows.Forms.TextBox tbxNewPp;
        private System.Windows.Forms.TextBox tbxAmount;
        private System.Windows.Forms.CheckBox chbCollectTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}