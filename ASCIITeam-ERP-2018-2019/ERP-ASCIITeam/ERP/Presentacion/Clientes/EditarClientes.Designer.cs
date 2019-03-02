namespace ERP.Presentacion.Clientes
{
    partial class EditarClientes
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
            this.btnSelectZipCode = new System.Windows.Forms.Button();
            this.tbxZipCode = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblSurname = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.tbxPhone = new System.Windows.Forms.TextBox();
            this.tbxEmail = new System.Windows.Forms.TextBox();
            this.tbxAddress = new System.Windows.Forms.TextBox();
            this.tbxSurname = new System.Windows.Forms.TextBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.tbxDNI = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSelectZipCode
            // 
            this.btnSelectZipCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectZipCode.Location = new System.Drawing.Point(371, 337);
            this.btnSelectZipCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectZipCode.Name = "btnSelectZipCode";
            this.btnSelectZipCode.Size = new System.Drawing.Size(155, 28);
            this.btnSelectZipCode.TabIndex = 30;
            this.btnSelectZipCode.Text = "Select Zip Code";
            this.btnSelectZipCode.UseVisualStyleBackColor = true;
            this.btnSelectZipCode.Click += new System.EventHandler(this.btnSelectZipCode_Click);
            this.btnSelectZipCode.MouseEnter += new System.EventHandler(this.style_MouseEnter);
            this.btnSelectZipCode.MouseLeave += new System.EventHandler(this.style_MouseLeave);
            // 
            // tbxZipCode
            // 
            this.tbxZipCode.Enabled = false;
            this.tbxZipCode.Location = new System.Drawing.Point(223, 339);
            this.tbxZipCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxZipCode.Name = "tbxZipCode";
            this.tbxZipCode.Size = new System.Drawing.Size(125, 22);
            this.tbxZipCode.TabIndex = 27;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(541, 427);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 28);
            this.btnCancel.TabIndex = 41;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.MouseEnter += new System.EventHandler(this.style_MouseEnter);
            this.btnCancel.MouseLeave += new System.EventHandler(this.style_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkOrange;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(127, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Zip Code*";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(431, 427);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(105, 28);
            this.btnConfirm.TabIndex = 40;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnSaveClose_Click);
            this.btnConfirm.MouseEnter += new System.EventHandler(this.style_MouseEnter);
            this.btnConfirm.MouseLeave += new System.EventHandler(this.style_MouseLeave);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearAll.Location = new System.Drawing.Point(64, 427);
            this.btnClearAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(97, 28);
            this.btnClearAll.TabIndex = 39;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            this.btnClearAll.MouseEnter += new System.EventHandler(this.style_MouseEnter);
            this.btnClearAll.MouseLeave += new System.EventHandler(this.style_MouseLeave);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(147, 289);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(53, 17);
            this.lblEmail.TabIndex = 38;
            this.lblEmail.Text = "Email*";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(147, 242);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(60, 17);
            this.lblPhone.TabIndex = 37;
            this.lblPhone.Text = "Phone*";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(133, 191);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(73, 17);
            this.lblAddress.TabIndex = 36;
            this.lblAddress.Text = "Address*";
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurname.Location = new System.Drawing.Point(127, 142);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(78, 17);
            this.lblSurname.TabIndex = 35;
            this.lblSurname.Text = "Surname*";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(147, 93);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(55, 17);
            this.lblName.TabIndex = 34;
            this.lblName.Text = "Name*";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDNI.Location = new System.Drawing.Point(137, 50);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(68, 17);
            this.lblDNI.TabIndex = 33;
            this.lblDNI.Text = "CIF/DNI*";
            // 
            // tbxPhone
            // 
            this.tbxPhone.Location = new System.Drawing.Point(223, 239);
            this.tbxPhone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxPhone.Name = "tbxPhone";
            this.tbxPhone.Size = new System.Drawing.Size(125, 22);
            this.tbxPhone.TabIndex = 32;
            // 
            // tbxEmail
            // 
            this.tbxEmail.Location = new System.Drawing.Point(223, 286);
            this.tbxEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.Size = new System.Drawing.Size(256, 22);
            this.tbxEmail.TabIndex = 31;
            // 
            // tbxAddress
            // 
            this.tbxAddress.Location = new System.Drawing.Point(223, 188);
            this.tbxAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.Size = new System.Drawing.Size(256, 22);
            this.tbxAddress.TabIndex = 29;
            // 
            // tbxSurname
            // 
            this.tbxSurname.Location = new System.Drawing.Point(223, 138);
            this.tbxSurname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxSurname.Name = "tbxSurname";
            this.tbxSurname.Size = new System.Drawing.Size(125, 22);
            this.tbxSurname.TabIndex = 28;
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(223, 90);
            this.tbxName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(125, 22);
            this.tbxName.TabIndex = 26;
            // 
            // tbxDNI
            // 
            this.tbxDNI.Enabled = false;
            this.tbxDNI.Location = new System.Drawing.Point(223, 47);
            this.tbxDNI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxDNI.Name = "tbxDNI";
            this.tbxDNI.Size = new System.Drawing.Size(125, 22);
            this.tbxDNI.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(447, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 17);
            this.label1.TabIndex = 42;
            this.label1.Text = "Campos Obligatorios *";
            // 
            // EditarClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(640, 466);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelectZipCode);
            this.Controls.Add(this.tbxZipCode);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblSurname);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblDNI);
            this.Controls.Add(this.tbxPhone);
            this.Controls.Add(this.tbxEmail);
            this.Controls.Add(this.tbxAddress);
            this.Controls.Add(this.tbxSurname);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.tbxDNI);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(658, 513);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(658, 513);
            this.Name = "EditarClientes";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Customer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectZipCode;
        private System.Windows.Forms.TextBox tbxZipCode;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.TextBox tbxPhone;
        private System.Windows.Forms.TextBox tbxEmail;
        private System.Windows.Forms.TextBox tbxAddress;
        private System.Windows.Forms.TextBox tbxSurname;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.TextBox tbxDNI;
        private System.Windows.Forms.Label label1;
    }
}