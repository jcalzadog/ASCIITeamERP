namespace ERP.Presentacion.Orders
{
    partial class NewOrder
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtNameCustomer = new System.Windows.Forms.TextBox();
            this.cboPayMethods = new System.Windows.Forms.ComboBox();
            this.btnSelectCustomer = new System.Windows.Forms.Button();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.productName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.lbltextototal = new System.Windows.Forms.Label();
            this.btnRemoveProduct = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrepaid = new System.Windows.Forms.TextBox();
            this.ckTotallyPaid = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(501, 540);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnSave.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(621, 540);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnCancel.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // txtNameCustomer
            // 
            this.txtNameCustomer.Enabled = false;
            this.txtNameCustomer.Location = new System.Drawing.Point(78, 55);
            this.txtNameCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.txtNameCustomer.Name = "txtNameCustomer";
            this.txtNameCustomer.ReadOnly = true;
            this.txtNameCustomer.Size = new System.Drawing.Size(180, 20);
            this.txtNameCustomer.TabIndex = 2;
            // 
            // cboPayMethods
            // 
            this.cboPayMethods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPayMethods.FormattingEnabled = true;
            this.cboPayMethods.Location = new System.Drawing.Point(78, 118);
            this.cboPayMethods.Margin = new System.Windows.Forms.Padding(4);
            this.cboPayMethods.Name = "cboPayMethods";
            this.cboPayMethods.Size = new System.Drawing.Size(180, 21);
            this.cboPayMethods.TabIndex = 3;
            this.cboPayMethods.SelectedValueChanged += new System.EventHandler(this.cboPayMethods_SelectedValueChanged);
            // 
            // btnSelectCustomer
            // 
            this.btnSelectCustomer.Location = new System.Drawing.Point(270, 55);
            this.btnSelectCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectCustomer.Name = "btnSelectCustomer";
            this.btnSelectCustomer.Size = new System.Drawing.Size(177, 30);
            this.btnSelectCustomer.TabIndex = 4;
            this.btnSelectCustomer.Text = "Select Customer";
            this.btnSelectCustomer.UseVisualStyleBackColor = true;
            this.btnSelectCustomer.Click += new System.EventHandler(this.btnSelectCustomer_Click);
            this.btnSelectCustomer.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnSelectCustomer.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productName,
            this.amount,
            this.salePrice,
            this.total});
            this.dgvCart.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCart.Location = new System.Drawing.Point(78, 188);
            this.dgvCart.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCart.MultiSelect = false;
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Size = new System.Drawing.Size(604, 317);
            this.dgvCart.TabIndex = 5;
            this.dgvCart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCart_CellContentClick);
            // 
            // productName
            // 
            this.productName.Frozen = true;
            this.productName.HeaderText = "Product Name";
            this.productName.Name = "productName";
            this.productName.ReadOnly = true;
            this.productName.Width = 151;
            // 
            // amount
            // 
            this.amount.Frozen = true;
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            this.amount.Width = 151;
            // 
            // salePrice
            // 
            this.salePrice.Frozen = true;
            this.salePrice.HeaderText = "Sale Price";
            this.salePrice.Name = "salePrice";
            this.salePrice.ReadOnly = true;
            this.salePrice.Width = 151;
            // 
            // total
            // 
            this.total.Frozen = true;
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 151;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(334, 118);
            this.btnAddProduct.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(112, 30);
            this.btnAddProduct.TabIndex = 6;
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            this.btnAddProduct.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnAddProduct.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // lbltextototal
            // 
            this.lbltextototal.AutoSize = true;
            this.lbltextototal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltextototal.Location = new System.Drawing.Point(504, 96);
            this.lbltextototal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltextototal.Name = "lbltextototal";
            this.lbltextototal.Size = new System.Drawing.Size(43, 13);
            this.lbltextototal.TabIndex = 7;
            this.lbltextototal.Text = "Total=";
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.Location = new System.Drawing.Point(500, 117);
            this.btnRemoveProduct.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(181, 30);
            this.btnRemoveProduct.TabIndex = 8;
            this.btnRemoveProduct.Text = "Remove Selected";
            this.btnRemoveProduct.UseVisualStyleBackColor = true;
            this.btnRemoveProduct.Click += new System.EventHandler(this.btnRemoveProduct_Click);
            this.btnRemoveProduct.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnRemoveProduct.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(495, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Date:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(561, 58);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(89, 13);
            this.lblDate.TabIndex = 10;
            this.lblDate.Text = "DD/MM/YYYY";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(561, 96);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(32, 13);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "0.00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(76, 540);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Prepaid =";
            // 
            // txtPrepaid
            // 
            this.txtPrepaid.Location = new System.Drawing.Point(144, 537);
            this.txtPrepaid.Name = "txtPrepaid";
            this.txtPrepaid.Size = new System.Drawing.Size(100, 20);
            this.txtPrepaid.TabIndex = 13;
            this.txtPrepaid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrepaid_KeyPress);
            this.txtPrepaid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPrepaid_KeyUp);
            // 
            // ckTotallyPaid
            // 
            this.ckTotallyPaid.AutoSize = true;
            this.ckTotallyPaid.Location = new System.Drawing.Point(256, 542);
            this.ckTotallyPaid.Name = "ckTotallyPaid";
            this.ckTotallyPaid.Size = new System.Drawing.Size(92, 17);
            this.ckTotallyPaid.TabIndex = 14;
            this.ckTotallyPaid.Text = "Totally paid";
            this.ckTotallyPaid.UseVisualStyleBackColor = true;
            this.ckTotallyPaid.CheckedChanged += new System.EventHandler(this.ckTotallyPaid_CheckedChanged);
            // 
            // NewOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(752, 585);
            this.ControlBox = false;
            this.Controls.Add(this.ckTotallyPaid);
            this.Controls.Add(this.txtPrepaid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRemoveProduct);
            this.Controls.Add(this.lbltextototal);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.btnSelectCustomer);
            this.Controls.Add(this.cboPayMethods);
            this.Controls.Add(this.txtNameCustomer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewOrder";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "New Order";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtNameCustomer;
        private System.Windows.Forms.ComboBox cboPayMethods;
        private System.Windows.Forms.Button btnSelectCustomer;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Label lbltextototal;
        private System.Windows.Forms.Button btnRemoveProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn productName;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn salePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrepaid;
        private System.Windows.Forms.CheckBox ckTotallyPaid;
    }
}