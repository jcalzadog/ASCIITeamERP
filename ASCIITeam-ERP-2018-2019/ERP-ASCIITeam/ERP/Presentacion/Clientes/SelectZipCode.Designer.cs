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
            this.btnClose = new System.Windows.Forms.Button();
            this.lblRegion = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.cmbRegion = new System.Windows.Forms.ComboBox();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.btnChooseCode = new System.Windows.Forms.Button();
            this.cmbZipCode = new System.Windows.Forms.ComboBox();
            this.cmbCities = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(737, 229);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            this.btnClose.MouseEnter += new System.EventHandler(this.style_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.style_MouseLeave);
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
            this.lblState.Location = new System.Drawing.Point(435, 50);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(46, 17);
            this.lblState.TabIndex = 4;
            this.lblState.Text = "State";
            // 
            // cmbRegion
            // 
            this.cmbRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegion.FormattingEnabled = true;
            this.cmbRegion.Location = new System.Drawing.Point(179, 47);
            this.cmbRegion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbRegion.Name = "cmbRegion";
            this.cmbRegion.Size = new System.Drawing.Size(185, 24);
            this.cmbRegion.TabIndex = 5;
            this.cmbRegion.SelectedIndexChanged += new System.EventHandler(this.cmbRegion_SelectedIndexChanged);
            // 
            // cmbState
            // 
            this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(507, 50);
            this.cmbState.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(201, 24);
            this.cmbState.TabIndex = 6;
            this.cmbState.SelectedIndexChanged += new System.EventHandler(this.cmbState_SelectedIndexChanged);
            // 
            // btnChooseCode
            // 
            this.btnChooseCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseCode.Location = new System.Drawing.Point(550, 229);
            this.btnChooseCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChooseCode.Name = "btnChooseCode";
            this.btnChooseCode.Size = new System.Drawing.Size(168, 28);
            this.btnChooseCode.TabIndex = 7;
            this.btnChooseCode.Text = "Choose Zip Code";
            this.btnChooseCode.UseVisualStyleBackColor = true;
            this.btnChooseCode.Click += new System.EventHandler(this.btnChooseCode_Click);
            this.btnChooseCode.MouseEnter += new System.EventHandler(this.style_MouseEnter);
            this.btnChooseCode.MouseLeave += new System.EventHandler(this.style_MouseLeave);
            // 
            // cmbZipCode
            // 
            this.cmbZipCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZipCode.FormattingEnabled = true;
            this.cmbZipCode.Location = new System.Drawing.Point(507, 149);
            this.cmbZipCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbZipCode.Name = "cmbZipCode";
            this.cmbZipCode.Size = new System.Drawing.Size(201, 24);
            this.cmbZipCode.TabIndex = 11;
            this.cmbZipCode.SelectedIndexChanged += new System.EventHandler(this.cmbZipCode_SelectedIndexChanged);
            // 
            // cmbCities
            // 
            this.cmbCities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCities.FormattingEnabled = true;
            this.cmbCities.Location = new System.Drawing.Point(179, 149);
            this.cmbCities.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCities.Name = "cmbCities";
            this.cmbCities.Size = new System.Drawing.Size(185, 24);
            this.cmbCities.TabIndex = 10;
            this.cmbCities.SelectedIndexChanged += new System.EventHandler(this.cmbCities_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(428, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Zip Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(119, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Cities";
            // 
            // SelectZipCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(840, 268);
            this.ControlBox = false;
            this.Controls.Add(this.cmbZipCode);
            this.Controls.Add(this.cmbCities);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnChooseCode);
            this.Controls.Add(this.cmbState);
            this.Controls.Add(this.cmbRegion);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblRegion);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(858, 315);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(858, 315);
            this.Name = "SelectZipCode";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Zip Code";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.ComboBox cmbRegion;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.Button btnChooseCode;
        private System.Windows.Forms.ComboBox cmbZipCode;
        private System.Windows.Forms.ComboBox cmbCities;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}