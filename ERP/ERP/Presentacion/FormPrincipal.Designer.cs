namespace ERP
{
    partial class FormPrincipal
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
            this.tbcMenuPrincipal = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnLogs = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnRoles = new System.Windows.Forms.Button();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tbcMenuPrincipal.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcMenuPrincipal
            // 
            this.tbcMenuPrincipal.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tbcMenuPrincipal.Controls.Add(this.tabPage1);
            this.tbcMenuPrincipal.Controls.Add(this.tabPage2);
            this.tbcMenuPrincipal.Controls.Add(this.tabPage3);
            this.tbcMenuPrincipal.Controls.Add(this.tabPage4);
            this.tbcMenuPrincipal.Controls.Add(this.tabPage5);
            this.tbcMenuPrincipal.Controls.Add(this.tabPage6);
            this.tbcMenuPrincipal.Controls.Add(this.tabPage7);
            this.tbcMenuPrincipal.Controls.Add(this.tabPage8);
            this.tbcMenuPrincipal.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tbcMenuPrincipal.ItemSize = new System.Drawing.Size(25, 100);
            this.tbcMenuPrincipal.Location = new System.Drawing.Point(-5, 0);
            this.tbcMenuPrincipal.Multiline = true;
            this.tbcMenuPrincipal.Name = "tbcMenuPrincipal";
            this.tbcMenuPrincipal.SelectedIndex = 0;
            this.tbcMenuPrincipal.Size = new System.Drawing.Size(754, 400);
            this.tbcMenuPrincipal.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbcMenuPrincipal.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(104, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(646, 392);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Start";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.btnLogs);
            this.tabPage2.Controls.Add(this.btnDeleteUser);
            this.tabPage2.Controls.Add(this.btnRoles);
            this.tabPage2.Controls.Add(this.btnNewUser);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(104, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(646, 392);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Users";
            this.tabPage2.Resize += new System.EventHandler(this.tabPage2_Resize);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(420, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(188, 20);
            this.textBox1.TabIndex = 8;
            // 
            // btnLogs
            // 
            this.btnLogs.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnLogs.Location = new System.Drawing.Point(307, 5);
            this.btnLogs.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(56, 24);
            this.btnLogs.TabIndex = 7;
            this.btnLogs.Text = "Logs";
            this.btnLogs.UseVisualStyleBackColor = false;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnDeleteUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteUser.Location = new System.Drawing.Point(189, 6);
            this.btnDeleteUser.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(105, 23);
            this.btnDeleteUser.TabIndex = 6;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.UseVisualStyleBackColor = false;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnRoles
            // 
            this.btnRoles.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnRoles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoles.Location = new System.Drawing.Point(111, 7);
            this.btnRoles.Margin = new System.Windows.Forms.Padding(2);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(65, 23);
            this.btnRoles.TabIndex = 5;
            this.btnRoles.Text = "Roles";
            this.btnRoles.UseVisualStyleBackColor = false;
            // 
            // btnNewUser
            // 
            this.btnNewUser.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewUser.Location = new System.Drawing.Point(20, 7);
            this.btnNewUser.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(87, 23);
            this.btnNewUser.TabIndex = 4;
            this.btnNewUser.Text = "New User";
            this.btnNewUser.UseVisualStyleBackColor = false;
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Location = new System.Drawing.Point(6, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(602, 325);
            this.dataGridView1.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(104, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(646, 392);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Customers";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(104, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(646, 392);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Orders";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(104, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(646, 392);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Products";
            this.tabPage5.UseVisualStyleBackColor = true;
            this.tabPage5.Click += new System.EventHandler(this.tabPage5_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(104, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(646, 392);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Categories";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(104, 4);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(646, 392);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Platforms";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(104, 4);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(646, 392);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "System";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 395);
            this.Controls.Add(this.tbcMenuPrincipal);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ">";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SizeChanged += new System.EventHandler(this.FormPrincipal_SizeChanged);
            this.tbcMenuPrincipal.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcMenuPrincipal;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLogs;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnRoles;
        private System.Windows.Forms.Button btnNewUser;
        private System.Windows.Forms.TextBox textBox1;
    }
}