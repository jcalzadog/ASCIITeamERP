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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbcMenuPrincipal = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbxSearchUser = new System.Windows.Forms.TextBox();
            this.btnLogs = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnRoles = new System.Windows.Forms.Button();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.dgvCategorie = new System.Windows.Forms.DataGridView();
            this.btnDeleteCategorie = new System.Windows.Forms.Button();
            this.btnUpdateCategorie = new System.Windows.Forms.Button();
            this.btnNewCategorie = new System.Windows.Forms.Button();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.tbcMenuPrincipal.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorie)).BeginInit();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
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
            this.tbcMenuPrincipal.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tbcMenuPrincipal_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPage1.Location = new System.Drawing.Point(104, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(646, 392);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Start";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPage2.Controls.Add(this.tbxSearchUser);
            this.tabPage2.Controls.Add(this.btnLogs);
            this.tabPage2.Controls.Add(this.btnDeleteUser);
            this.tabPage2.Controls.Add(this.btnRoles);
            this.tabPage2.Controls.Add(this.btnNewUser);
            this.tabPage2.Controls.Add(this.dgvUsers);
            this.tabPage2.Location = new System.Drawing.Point(104, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(646, 392);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Users";
            this.tabPage2.Resize += new System.EventHandler(this.tabPage2_Resize);
            // 
            // tbxSearchUser
            // 
            this.tbxSearchUser.Location = new System.Drawing.Point(368, 11);
            this.tbxSearchUser.Name = "tbxSearchUser";
            this.tbxSearchUser.Size = new System.Drawing.Size(188, 20);
            this.tbxSearchUser.TabIndex = 8;
            this.tbxSearchUser.Enter += new System.EventHandler(this.tbxSearchUser_Enter);
            this.tbxSearchUser.Leave += new System.EventHandler(this.tbxSearchUser_Leave);
            // 
            // btnLogs
            // 
            this.btnLogs.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogs.Location = new System.Drawing.Point(290, 7);
            this.btnLogs.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(56, 24);
            this.btnLogs.TabIndex = 7;
            this.btnLogs.Text = "Logs";
            this.btnLogs.UseVisualStyleBackColor = false;
            this.btnLogs.MouseEnter += new System.EventHandler(this.btnLogs_MouseEnter);
            this.btnLogs.MouseLeave += new System.EventHandler(this.btnLogs_MouseLeave);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnDeleteUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteUser.Location = new System.Drawing.Point(181, 7);
            this.btnDeleteUser.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(105, 24);
            this.btnDeleteUser.TabIndex = 6;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.UseVisualStyleBackColor = false;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            this.btnDeleteUser.MouseEnter += new System.EventHandler(this.btnDeleteUser_MouseEnter);
            this.btnDeleteUser.MouseLeave += new System.EventHandler(this.btnDeleteUser_MouseLeave);
            // 
            // btnRoles
            // 
            this.btnRoles.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoles.Location = new System.Drawing.Point(111, 7);
            this.btnRoles.Margin = new System.Windows.Forms.Padding(2);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(65, 23);
            this.btnRoles.TabIndex = 5;
            this.btnRoles.Text = "Roles";
            this.btnRoles.UseVisualStyleBackColor = false;
            this.btnRoles.Click += new System.EventHandler(this.btnRoles_Click);
            this.btnRoles.MouseEnter += new System.EventHandler(this.btnRoles_MouseEnter);
            this.btnRoles.MouseLeave += new System.EventHandler(this.btnRoles_MouseLeave);
            // 
            // btnNewUser
            // 
            this.btnNewUser.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewUser.Location = new System.Drawing.Point(20, 7);
            this.btnNewUser.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(87, 23);
            this.btnNewUser.TabIndex = 4;
            this.btnNewUser.Text = "New User";
            this.btnNewUser.UseVisualStyleBackColor = false;
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
            this.btnNewUser.MouseEnter += new System.EventHandler(this.btnNewUser_MouseEnter);
            this.btnNewUser.MouseLeave += new System.EventHandler(this.btnNewUser_MouseLeave);
            // 
            // dgvUsers
            // 
            this.dgvUsers.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.dgvUsers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsers.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvUsers.Location = new System.Drawing.Point(6, 35);
            this.dgvUsers.Name = "dgvUsers";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsers.Size = new System.Drawing.Size(602, 325);
            this.dgvUsers.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.dgvCustomers);
            this.tabPage3.Location = new System.Drawing.Point(104, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(646, 392);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Customers";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 19);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Location = new System.Drawing.Point(6, 35);
            this.dgvCustomers.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.RowTemplate.Height = 24;
            this.dgvCustomers.Size = new System.Drawing.Size(602, 325);
            this.dgvCustomers.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPage4.Controls.Add(this.button2);
            this.tabPage4.Location = new System.Drawing.Point(104, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(646, 392);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Orders";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(5, 20);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 19);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPage5.Controls.Add(this.button3);
            this.tabPage5.Location = new System.Drawing.Point(104, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(646, 392);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Products";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(45, 32);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(56, 19);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPage6.Controls.Add(this.dgvCategorie);
            this.tabPage6.Controls.Add(this.btnDeleteCategorie);
            this.tabPage6.Controls.Add(this.btnUpdateCategorie);
            this.tabPage6.Controls.Add(this.btnNewCategorie);
            this.tabPage6.Location = new System.Drawing.Point(104, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(646, 392);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Categories";
            // 
            // dgvCategorie
            // 
            this.dgvCategorie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategorie.Location = new System.Drawing.Point(6, 35);
            this.dgvCategorie.Name = "dgvCategorie";
            this.dgvCategorie.Size = new System.Drawing.Size(602, 325);
            this.dgvCategorie.TabIndex = 3;
            // 
            // btnDeleteCategorie
            // 
            this.btnDeleteCategorie.Location = new System.Drawing.Point(171, 7);
            this.btnDeleteCategorie.Name = "btnDeleteCategorie";
            this.btnDeleteCategorie.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteCategorie.TabIndex = 2;
            this.btnDeleteCategorie.Text = "Delete";
            this.btnDeleteCategorie.UseVisualStyleBackColor = true;
            this.btnDeleteCategorie.Click += new System.EventHandler(this.btnDeleteCategorie_Click);
            // 
            // btnUpdateCategorie
            // 
            this.btnUpdateCategorie.Location = new System.Drawing.Point(89, 8);
            this.btnUpdateCategorie.Name = "btnUpdateCategorie";
            this.btnUpdateCategorie.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateCategorie.TabIndex = 1;
            this.btnUpdateCategorie.Text = "Update";
            this.btnUpdateCategorie.UseVisualStyleBackColor = true;
            this.btnUpdateCategorie.Click += new System.EventHandler(this.btnUpdateCategorie_Click);
            // 
            // btnNewCategorie
            // 
            this.btnNewCategorie.Location = new System.Drawing.Point(7, 9);
            this.btnNewCategorie.Name = "btnNewCategorie";
            this.btnNewCategorie.Size = new System.Drawing.Size(75, 23);
            this.btnNewCategorie.TabIndex = 0;
            this.btnNewCategorie.Text = "New ";
            this.btnNewCategorie.UseVisualStyleBackColor = true;
            this.btnNewCategorie.Click += new System.EventHandler(this.btnNewCategorie_Click);
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPage7.Controls.Add(this.button4);
            this.tabPage7.Location = new System.Drawing.Point(104, 4);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(646, 392);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Platforms";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(27, 22);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(56, 19);
            this.button4.TabIndex = 2;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPage8.Controls.Add(this.btnLogOut);
            this.tabPage8.Controls.Add(this.btnExit);
            this.tabPage8.Location = new System.Drawing.Point(104, 4);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(646, 392);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "System";
            // 
            // btnLogOut
            // 
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Location = new System.Drawing.Point(24, 43);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(211, 23);
            this.btnLogOut.TabIndex = 1;
            this.btnLogOut.Text = "Log out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            this.btnLogOut.MouseEnter += new System.EventHandler(this.btnLogOut_MouseEnter);
            this.btnLogOut.MouseLeave += new System.EventHandler(this.btnLogOut_MouseLeave);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(24, 80);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(211, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseEnter += new System.EventHandler(this.btnExit_MouseEnter);
            this.btnExit.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 395);
            this.ControlBox = false;
            this.Controls.Add(this.tbcMenuPrincipal);
            this.Name = "FormPrincipal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ERP Videogames";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SizeChanged += new System.EventHandler(this.FormPrincipal_SizeChanged);
            this.tbcMenuPrincipal.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorie)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox tbxSearchUser;
        private System.Windows.Forms.DataGridView dgvCategorie;
        private System.Windows.Forms.Button btnDeleteCategorie;
        private System.Windows.Forms.Button btnUpdateCategorie;
        private System.Windows.Forms.Button btnNewCategorie;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnLogOut;
    }
}