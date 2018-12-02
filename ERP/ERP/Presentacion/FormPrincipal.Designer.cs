﻿namespace ERP
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbcMenuPrincipal = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.cbxUserDeleted = new System.Windows.Forms.CheckBox();
            this.tbxSearchUser = new System.Windows.Forms.TextBox();
            this.btnLogs = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnRoles = new System.Windows.Forms.Button();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbxDeleted = new System.Windows.Forms.CheckBox();
            this.tbxSearchCustomer = new System.Windows.Forms.TextBox();
            this.btnDeleteCustomer = new System.Windows.Forms.Button();
            this.btnEditCustomer = new System.Windows.Forms.Button();
            this.btnNewCustomer = new System.Windows.Forms.Button();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.ckbDeleted = new System.Windows.Forms.CheckBox();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.cmbFilPlatform = new System.Windows.Forms.ComboBox();
            this.cmbFilCategory = new System.Windows.Forms.ComboBox();
            this.txtSearchProd = new System.Windows.Forms.TextBox();
            this.btnDeleteProd = new System.Windows.Forms.Button();
            this.btnUpdateProd = new System.Windows.Forms.Button();
            this.btnNewProd = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.dgvCategorie = new System.Windows.Forms.DataGridView();
            this.btnDeleteCategorie = new System.Windows.Forms.Button();
            this.btnUpdateCategorie = new System.Windows.Forms.Button();
            this.btnNewCategorie = new System.Windows.Forms.Button();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.tbcMenuPrincipal.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
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
            this.tabPage1.BackColor = System.Drawing.Color.DarkOrange;
            this.tabPage1.Location = new System.Drawing.Point(104, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(646, 392);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Start";
            //
            // tabPage2
            //
            this.tabPage2.BackColor = System.Drawing.Color.DarkOrange;
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.btnEditUser);
            this.tabPage2.Controls.Add(this.cbxUserDeleted);
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
            // panel1
            //
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 366);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(676, 28);
            this.panel1.TabIndex = 11;
            //
            // btnEditUser
            //
            this.btnEditUser.BackColor = System.Drawing.Color.White;
            this.btnEditUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditUser.Location = new System.Drawing.Point(83, 8);
            this.btnEditUser.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(70, 23);
            this.btnEditUser.TabIndex = 10;
            this.btnEditUser.Text = "Edit User";
            this.btnEditUser.UseVisualStyleBackColor = false;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            this.btnEditUser.MouseEnter += new System.EventHandler(this.btnEditUser_MouseEnter);
            this.btnEditUser.MouseLeave += new System.EventHandler(this.btnEditUser_MouseLeave);
            //
            // cbxUserDeleted
            //
            this.cbxUserDeleted.AutoSize = true;
            this.cbxUserDeleted.BackColor = System.Drawing.Color.DarkOrange;
            this.cbxUserDeleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxUserDeleted.ForeColor = System.Drawing.Color.Black;
            this.cbxUserDeleted.Location = new System.Drawing.Point(566, 11);
            this.cbxUserDeleted.Margin = new System.Windows.Forms.Padding(2);
            this.cbxUserDeleted.Name = "cbxUserDeleted";
            this.cbxUserDeleted.Size = new System.Drawing.Size(70, 17);
            this.cbxUserDeleted.TabIndex = 9;
            this.cbxUserDeleted.Text = "Deleted";
            this.cbxUserDeleted.UseVisualStyleBackColor = false;
            this.cbxUserDeleted.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            //
            // tbxSearchUser
            //
            this.tbxSearchUser.Location = new System.Drawing.Point(399, 11);
            this.tbxSearchUser.Name = "tbxSearchUser";
            this.tbxSearchUser.Size = new System.Drawing.Size(156, 20);
            this.tbxSearchUser.TabIndex = 8;
            this.tbxSearchUser.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.tbxSearchUser.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxSearchUser_KeyUp);
            this.tbxSearchUser.Leave += new System.EventHandler(this.txtSearch_Leave);
            //
            // btnLogs
            //
            this.btnLogs.BackColor = System.Drawing.Color.White;
            this.btnLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogs.Location = new System.Drawing.Point(338, 8);
            this.btnLogs.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(56, 24);
            this.btnLogs.TabIndex = 7;
            this.btnLogs.Text = "Logs";
            this.btnLogs.UseVisualStyleBackColor = false;
            this.btnLogs.Click += new System.EventHandler(this.btnLogs_Click);
            this.btnLogs.MouseEnter += new System.EventHandler(this.btnLogs_MouseEnter);
            this.btnLogs.MouseLeave += new System.EventHandler(this.btnLogs_MouseLeave);
            //
            // btnDeleteUser
            //
            this.btnDeleteUser.BackColor = System.Drawing.Color.White;
            this.btnDeleteUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteUser.Location = new System.Drawing.Point(228, 8);
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
            this.btnRoles.BackColor = System.Drawing.Color.White;
            this.btnRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoles.Location = new System.Drawing.Point(158, 8);
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
            this.btnNewUser.BackColor = System.Drawing.Color.White;
            this.btnNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewUser.Location = new System.Drawing.Point(6, 8);
            this.btnNewUser.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(73, 23);
            this.btnNewUser.TabIndex = 4;
            this.btnNewUser.Text = "New User";
            this.btnNewUser.UseVisualStyleBackColor = false;
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
            this.btnNewUser.MouseEnter += new System.EventHandler(this.btnNewUser_MouseEnter);
            this.btnNewUser.MouseLeave += new System.EventHandler(this.btnNewUser_MouseLeave);
            //
            // dgvUsers
            //
            this.dgvUsers.AllowUserToResizeColumns = false;
            this.dgvUsers.AllowUserToResizeRows = false;
            this.dgvUsers.BackgroundColor = System.Drawing.SystemColors.Desktop;
            this.dgvUsers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUsers.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvUsers.Location = new System.Drawing.Point(6, 35);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(602, 325);
            this.dgvUsers.TabIndex = 3;
            this.dgvUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellClick);
            //
            // tabPage3
            //
            this.tabPage3.BackColor = System.Drawing.Color.DarkOrange;
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Controls.Add(this.cbxDeleted);
            this.tabPage3.Controls.Add(this.tbxSearchCustomer);
            this.tabPage3.Controls.Add(this.btnDeleteCustomer);
            this.tabPage3.Controls.Add(this.btnEditCustomer);
            this.tabPage3.Controls.Add(this.btnNewCustomer);
            this.tabPage3.Controls.Add(this.dgvCustomers);
            this.tabPage3.Location = new System.Drawing.Point(104, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(646, 392);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Customers";
            //
            // panel3
            //
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel3.Location = new System.Drawing.Point(0, 450);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1005, 492);
            this.panel3.TabIndex = 11;
            //
            // cbxDeleted
            //
            this.cbxDeleted.AutoSize = true;
            this.cbxDeleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxDeleted.Location = new System.Drawing.Point(752, 13);
            this.cbxDeleted.Name = "cbxDeleted";
            this.cbxDeleted.Size = new System.Drawing.Size(86, 21);
            this.cbxDeleted.TabIndex = 10;
            this.cbxDeleted.Text = "Deleted";
            this.cbxDeleted.UseVisualStyleBackColor = true;
            //
            // tbxSearchCustomer
            //
            this.tbxSearchCustomer.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tbxSearchCustomer.Location = new System.Drawing.Point(372, 9);
            this.tbxSearchCustomer.Name = "tbxSearchCustomer";
            this.tbxSearchCustomer.Size = new System.Drawing.Size(188, 20);
            this.tbxSearchCustomer.TabIndex = 9;
            this.tbxSearchCustomer.Enter += new System.EventHandler(this.tbxSearchCustomer_Enter);
            this.tbxSearchCustomer.Leave += new System.EventHandler(this.tbxSearchCustomer_Leave);
            //
            // btnDeleteCustomer
            //
            this.btnDeleteCustomer.BackColor = System.Drawing.Color.White;
            this.btnDeleteCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCustomer.Location = new System.Drawing.Point(254, 7);
            this.btnDeleteCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteCustomer.Name = "btnDeleteCustomer";
            this.btnDeleteCustomer.Size = new System.Drawing.Size(113, 23);
            this.btnDeleteCustomer.TabIndex = 7;
            this.btnDeleteCustomer.Text = "Delete Customer";
            this.btnDeleteCustomer.UseVisualStyleBackColor = false;
            this.btnDeleteCustomer.MouseEnter += new System.EventHandler(this.btnDeleteCustomer_MouseEnter);
            this.btnDeleteCustomer.MouseLeave += new System.EventHandler(this.btnDeleteCustomer_MouseLeave);
            //
            // btnEditCustomer
            //
            this.btnEditCustomer.BackColor = System.Drawing.Color.White;
            this.btnEditCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditCustomer.Location = new System.Drawing.Point(137, 7);
            this.btnEditCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditCustomer.Name = "btnEditCustomer";
            this.btnEditCustomer.Size = new System.Drawing.Size(113, 23);
            this.btnEditCustomer.TabIndex = 6;
            this.btnEditCustomer.Text = "Edit Customer";
            this.btnEditCustomer.UseVisualStyleBackColor = false;
            this.btnEditCustomer.MouseEnter += new System.EventHandler(this.btnEditCustomer_MouseEnter);
            this.btnEditCustomer.MouseLeave += new System.EventHandler(this.btnEditCustomer_MouseLeave);
            //
            // btnNewCustomer
            //
            this.btnNewCustomer.BackColor = System.Drawing.Color.White;
            this.btnNewCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewCustomer.Location = new System.Drawing.Point(20, 7);
            this.btnNewCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.Size = new System.Drawing.Size(113, 23);
            this.btnNewCustomer.TabIndex = 5;
            this.btnNewCustomer.Text = "New Customer";
            this.btnNewCustomer.UseVisualStyleBackColor = false;
            this.btnNewCustomer.Click += new System.EventHandler(this.btnNewCustomer_Click);
            this.btnNewCustomer.MouseEnter += new System.EventHandler(this.btnNewCustomer_MouseEnter);
            this.btnNewCustomer.MouseLeave += new System.EventHandler(this.btnNewCustomer_MouseLeave);
            //
            // dgvCustomers
            //
            this.dgvCustomers.BackgroundColor = System.Drawing.Color.Black;
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
            this.tabPage4.BackColor = System.Drawing.Color.DarkOrange;
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
            this.tabPage5.BackColor = System.Drawing.Color.DarkOrange;
            this.tabPage5.Controls.Add(this.ckbDeleted);
            this.tabPage5.Controls.Add(this.dgvProducts);
            this.tabPage5.Controls.Add(this.cmbFilPlatform);
            this.tabPage5.Controls.Add(this.cmbFilCategory);
            this.tabPage5.Controls.Add(this.txtSearchProd);
            this.tabPage5.Controls.Add(this.btnDeleteProd);
            this.tabPage5.Controls.Add(this.btnUpdateProd);
            this.tabPage5.Controls.Add(this.btnNewProd);
            this.tabPage5.Location = new System.Drawing.Point(104, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(646, 392);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Products";
            this.tabPage5.Resize += new System.EventHandler(this.tabPage5_Resize);
            //
            // ckbDeleted
            //
            this.ckbDeleted.AutoSize = true;
            this.ckbDeleted.BackColor = System.Drawing.Color.DarkOrange;
            this.ckbDeleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbDeleted.ForeColor = System.Drawing.Color.Black;
            this.ckbDeleted.Location = new System.Drawing.Point(586, 14);
            this.ckbDeleted.Margin = new System.Windows.Forms.Padding(2);
            this.ckbDeleted.Name = "ckbDeleted";
            this.ckbDeleted.Size = new System.Drawing.Size(70, 17);
            this.ckbDeleted.TabIndex = 20;
            this.ckbDeleted.Text = "Deleted";
            this.ckbDeleted.UseVisualStyleBackColor = false;
            //
            // dgvProducts
            //
            this.dgvProducts.AllowUserToResizeColumns = false;
            this.dgvProducts.AllowUserToResizeRows = false;
            this.dgvProducts.BackgroundColor = System.Drawing.SystemColors.Desktop;
            this.dgvProducts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProducts.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvProducts.Location = new System.Drawing.Point(6, 35);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(602, 325);
            this.dgvProducts.TabIndex = 19;
            //
            // cmbFilPlatform
            //
            this.cmbFilPlatform.FormattingEnabled = true;
            this.cmbFilPlatform.Location = new System.Drawing.Point(705, 13);
            this.cmbFilPlatform.Name = "cmbFilPlatform";
            this.cmbFilPlatform.Size = new System.Drawing.Size(62, 21);
            this.cmbFilPlatform.TabIndex = 18;
            this.cmbFilPlatform.SelectedIndexChanged += new System.EventHandler(this.cmbFilPlatform_SelectedIndexChanged);
            //
            // cmbFilCategory
            //
            this.cmbFilCategory.FormattingEnabled = true;
            this.cmbFilCategory.Location = new System.Drawing.Point(613, 13);
            this.cmbFilCategory.Name = "cmbFilCategory";
            this.cmbFilCategory.Size = new System.Drawing.Size(66, 21);
            this.cmbFilCategory.TabIndex = 17;
            this.cmbFilCategory.SelectedIndexChanged += new System.EventHandler(this.cmbFilCategory_SelectedIndexChanged);
            //
            // txtSearchProd
            //
            this.txtSearchProd.Location = new System.Drawing.Point(400, 13);
            this.txtSearchProd.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchProd.Name = "txtSearchProd";
            this.txtSearchProd.Size = new System.Drawing.Size(156, 20);
            this.txtSearchProd.TabIndex = 16;
            this.txtSearchProd.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearchProd.Leave += new System.EventHandler(this.txtSearch_Leave);
            //
            // btnDeleteProd
            //
            this.btnDeleteProd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDeleteProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteProd.Location = new System.Drawing.Point(261, 10);
            this.btnDeleteProd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteProd.Name = "btnDeleteProd";
            this.btnDeleteProd.Size = new System.Drawing.Size(134, 28);
            this.btnDeleteProd.TabIndex = 14;
            this.btnDeleteProd.Text = "Delete Product";
            this.btnDeleteProd.UseVisualStyleBackColor = false;
            this.btnDeleteProd.Click += new System.EventHandler(this.btnDeleteProd_Click);
            this.btnDeleteProd.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnDeleteProd.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            //
            // btnUpdateProd
            //
            this.btnUpdateProd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnUpdateProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateProd.Location = new System.Drawing.Point(124, 10);
            this.btnUpdateProd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdateProd.Name = "btnUpdateProd";
            this.btnUpdateProd.Size = new System.Drawing.Size(136, 28);
            this.btnUpdateProd.TabIndex = 13;
            this.btnUpdateProd.Text = "Update Product";
            this.btnUpdateProd.UseVisualStyleBackColor = false;
            this.btnUpdateProd.Click += new System.EventHandler(this.btnUpdateProd_Click);
            this.btnUpdateProd.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnUpdateProd.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            //
            // btnNewProd
            //
            this.btnNewProd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNewProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewProd.Location = new System.Drawing.Point(6, 8);
            this.btnNewProd.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewProd.Name = "btnNewProd";
            this.btnNewProd.Size = new System.Drawing.Size(115, 28);
            this.btnNewProd.TabIndex = 12;
            this.btnNewProd.Text = "New Product";
            this.btnNewProd.UseVisualStyleBackColor = false;
            this.btnNewProd.Click += new System.EventHandler(this.btnNewProd_Click);
            this.btnNewProd.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnNewProd.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            //
            // tabPage6
            //
            this.tabPage6.BackColor = System.Drawing.Color.DarkOrange;
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
            this.tabPage6.Click += new System.EventHandler(this.tabPage6_Click);
            //
            // dgvCategorie
            //
            this.dgvCategorie.BackgroundColor = System.Drawing.Color.Black;
            this.dgvCategorie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategorie.Location = new System.Drawing.Point(6, 35);
            this.dgvCategorie.Name = "dgvCategorie";
            this.dgvCategorie.ReadOnly = true;
            this.dgvCategorie.Size = new System.Drawing.Size(602, 325);
            this.dgvCategorie.TabIndex = 3;
            this.dgvCategorie.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategorie_CellContentClick);
            this.dgvCategorie.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategorie_CellContentClick);
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
            this.tabPage7.BackColor = System.Drawing.Color.DarkOrange;
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
            this.tabPage8.BackColor = System.Drawing.Color.DarkOrange;
            this.tabPage8.Controls.Add(this.panel2);
            this.tabPage8.Controls.Add(this.btnLogOut);
            this.tabPage8.Controls.Add(this.btnExit);
            this.tabPage8.Location = new System.Drawing.Point(104, 4);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(646, 392);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "System";
            //
            // panel2
            //
            this.panel2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel2.Location = new System.Drawing.Point(266, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(407, 393);
            this.panel2.TabIndex = 2;
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
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
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
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnDeleteCustomer;
        private System.Windows.Forms.Button btnEditCustomer;
        private System.Windows.Forms.Button btnNewCustomer;
        private System.Windows.Forms.TextBox tbxSearchCustomer;
        private System.Windows.Forms.CheckBox cbxUserDeleted;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbFilPlatform;
        private System.Windows.Forms.ComboBox cmbFilCategory;
        private System.Windows.Forms.TextBox txtSearchProd;
        private System.Windows.Forms.Button btnDeleteProd;
        private System.Windows.Forms.Button btnUpdateProd;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnNewProd;
        private System.Windows.Forms.CheckBox ckbDeleted;
        private System.Windows.Forms.CheckBox cbxDeleted;
        private System.Windows.Forms.Panel panel3;
    }
}
