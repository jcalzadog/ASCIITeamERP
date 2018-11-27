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
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.dgvCategorie = new System.Windows.Forms.DataGridView();
            this.btnDeleteCategorie = new System.Windows.Forms.Button();
            this.btnUpdateCategorie = new System.Windows.Forms.Button();
            this.btnNewCategorie = new System.Windows.Forms.Button();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.tbcMenuPrincipal.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorie)).BeginInit();
            this.tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
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
            this.tbcMenuPrincipal.Location = new System.Drawing.Point(-7, 0);
            this.tbcMenuPrincipal.Margin = new System.Windows.Forms.Padding(4);
            this.tbcMenuPrincipal.Multiline = true;
            this.tbcMenuPrincipal.Name = "tbcMenuPrincipal";
            this.tbcMenuPrincipal.SelectedIndex = 0;
            this.tbcMenuPrincipal.Size = new System.Drawing.Size(1005, 492);
            this.tbcMenuPrincipal.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbcMenuPrincipal.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightGreen;
            this.tabPage1.Location = new System.Drawing.Point(104, 4);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(897, 484);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Start";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.btnLogs);
            this.tabPage2.Controls.Add(this.btnDeleteUser);
            this.tabPage2.Controls.Add(this.btnRoles);
            this.tabPage2.Controls.Add(this.btnNewUser);
            this.tabPage2.Controls.Add(this.dgvUsers);
            this.tabPage2.Location = new System.Drawing.Point(104, 4);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(897, 484);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Users";
            this.tabPage2.Resize += new System.EventHandler(this.tabPage2_Resize);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(496, 13);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(249, 22);
            this.textBox1.TabIndex = 8;
            // 
            // btnLogs
            // 
            this.btnLogs.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnLogs.Location = new System.Drawing.Point(387, 9);
            this.btnLogs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(75, 30);
            this.btnLogs.TabIndex = 7;
            this.btnLogs.Text = "Logs";
            this.btnLogs.UseVisualStyleBackColor = false;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnDeleteUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteUser.Location = new System.Drawing.Point(241, 10);
            this.btnDeleteUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(140, 28);
            this.btnDeleteUser.TabIndex = 6;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.UseVisualStyleBackColor = false;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnRoles
            // 
            this.btnRoles.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnRoles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoles.Location = new System.Drawing.Point(148, 9);
            this.btnRoles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(87, 28);
            this.btnRoles.TabIndex = 5;
            this.btnRoles.Text = "Roles";
            this.btnRoles.UseVisualStyleBackColor = false;
            this.btnRoles.Click += new System.EventHandler(this.btnRoles_Click);
            // 
            // btnNewUser
            // 
            this.btnNewUser.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewUser.Location = new System.Drawing.Point(27, 9);
            this.btnNewUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(116, 28);
            this.btnNewUser.TabIndex = 4;
            this.btnNewUser.Text = "New User";
            this.btnNewUser.UseVisualStyleBackColor = false;
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
            // 
            // dgvUsers
            // 
            this.dgvUsers.Location = new System.Drawing.Point(8, 43);
            this.dgvUsers.Margin = new System.Windows.Forms.Padding(4);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.Size = new System.Drawing.Size(803, 400);
            this.dgvUsers.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPage3.Controls.Add(this.dgvCustomers);
            this.tabPage3.Location = new System.Drawing.Point(104, 4);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(897, 484);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Customers";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPage4.Location = new System.Drawing.Point(104, 4);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage4.Size = new System.Drawing.Size(897, 484);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Orders";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPage5.Location = new System.Drawing.Point(104, 4);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage5.Size = new System.Drawing.Size(897, 484);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Products";
            this.tabPage5.Click += new System.EventHandler(this.tabPage5_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPage6.Controls.Add(this.dgvCategorie);
            this.tabPage6.Controls.Add(this.btnDeleteCategorie);
            this.tabPage6.Controls.Add(this.btnUpdateCategorie);
            this.tabPage6.Controls.Add(this.btnNewCategorie);
            this.tabPage6.Location = new System.Drawing.Point(104, 4);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage6.Size = new System.Drawing.Size(897, 484);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Categories";
            // 
            // dgvCategorie
            // 
            this.dgvCategorie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategorie.Location = new System.Drawing.Point(8, 43);
            this.dgvCategorie.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCategorie.Name = "dgvCategorie";
            this.dgvCategorie.Size = new System.Drawing.Size(803, 400);
            this.dgvCategorie.TabIndex = 3;
            // 
            // btnDeleteCategorie
            // 
            this.btnDeleteCategorie.Location = new System.Drawing.Point(228, 9);
            this.btnDeleteCategorie.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteCategorie.Name = "btnDeleteCategorie";
            this.btnDeleteCategorie.Size = new System.Drawing.Size(100, 28);
            this.btnDeleteCategorie.TabIndex = 2;
            this.btnDeleteCategorie.Text = "Delete";
            this.btnDeleteCategorie.UseVisualStyleBackColor = true;
            this.btnDeleteCategorie.Click += new System.EventHandler(this.btnDeleteCategorie_Click);
            // 
            // btnUpdateCategorie
            // 
            this.btnUpdateCategorie.Location = new System.Drawing.Point(119, 10);
            this.btnUpdateCategorie.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateCategorie.Name = "btnUpdateCategorie";
            this.btnUpdateCategorie.Size = new System.Drawing.Size(100, 28);
            this.btnUpdateCategorie.TabIndex = 1;
            this.btnUpdateCategorie.Text = "Update";
            this.btnUpdateCategorie.UseVisualStyleBackColor = true;
            this.btnUpdateCategorie.Click += new System.EventHandler(this.btnUpdateCategorie_Click);
            // 
            // btnNewCategorie
            // 
            this.btnNewCategorie.Location = new System.Drawing.Point(9, 11);
            this.btnNewCategorie.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewCategorie.Name = "btnNewCategorie";
            this.btnNewCategorie.Size = new System.Drawing.Size(100, 28);
            this.btnNewCategorie.TabIndex = 0;
            this.btnNewCategorie.Text = "New ";
            this.btnNewCategorie.UseVisualStyleBackColor = true;
            this.btnNewCategorie.Click += new System.EventHandler(this.btnNewCategorie_Click);
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPage7.Location = new System.Drawing.Point(104, 4);
            this.tabPage7.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage7.Size = new System.Drawing.Size(897, 484);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Platforms";
            // 
            // tabPage8
            // 
            this.tabPage8.BackColor = System.Drawing.Color.PaleGreen;
            this.tabPage8.Controls.Add(this.btnExit);
            this.tabPage8.Location = new System.Drawing.Point(104, 4);
            this.tabPage8.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage8.Size = new System.Drawing.Size(897, 484);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "System";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnExit.Location = new System.Drawing.Point(32, 36);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 28);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Location = new System.Drawing.Point(8, 43);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.RowTemplate.Height = 24;
            this.dgvCustomers.Size = new System.Drawing.Size(803, 400);
            this.dgvCustomers.TabIndex = 0;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 486);
            this.Controls.Add(this.tbcMenuPrincipal);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ERP Videogames";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SizeChanged += new System.EventHandler(this.FormPrincipal_SizeChanged);
            this.tbcMenuPrincipal.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorie)).EndInit();
            this.tabPage8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button btnLogs;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnRoles;
        private System.Windows.Forms.Button btnNewUser;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgvCategorie;
        private System.Windows.Forms.Button btnDeleteCategorie;
        private System.Windows.Forms.Button btnUpdateCategorie;
        private System.Windows.Forms.Button btnNewCategorie;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvCustomers;
    }
}