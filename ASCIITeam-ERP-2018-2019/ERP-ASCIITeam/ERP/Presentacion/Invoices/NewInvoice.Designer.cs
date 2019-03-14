namespace ERP.Presentacion.Invoices
{
    partial class NewInvoice
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
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.txtPriceProduct = new System.Windows.Forms.TextBox();
            this.amountProducts = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtTotalNeto = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.amount = new System.Windows.Forms.NumericUpDown();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnRemoveSelected = new System.Windows.Forms.Button();
            this.txtProdSelecc = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.amountProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(589, 79);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(75, 23);
            this.btnAddProduct.TabIndex = 57;
            this.btnAddProduct.Text = "Add";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            this.btnAddProduct.MouseEnter += new System.EventHandler(this.btn_MouseEnterStyle);
            this.btnAddProduct.MouseLeave += new System.EventHandler(this.btn_MouseLeaveStyle);
            // 
            // txtPriceProduct
            // 
            this.txtPriceProduct.Location = new System.Drawing.Point(474, 79);
            this.txtPriceProduct.Name = "txtPriceProduct";
            this.txtPriceProduct.Size = new System.Drawing.Size(100, 20);
            this.txtPriceProduct.TabIndex = 56;
            this.txtPriceProduct.TextChanged += new System.EventHandler(this.txtPriceProduct_TextChanged);
            this.txtPriceProduct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPriceProduct_KeyPress);
            // 
            // amountProducts
            // 
            this.amountProducts.Location = new System.Drawing.Point(332, 79);
            this.amountProducts.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.amountProducts.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.amountProducts.Name = "amountProducts";
            this.amountProducts.Size = new System.Drawing.Size(75, 20);
            this.amountProducts.TabIndex = 55;
            this.amountProducts.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(434, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Price:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "Amount:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-134, -12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "Product:";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(543, 487);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 51;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            this.btnAccept.MouseEnter += new System.EventHandler(this.btn_MouseEnterStyle);
            this.btnAccept.MouseLeave += new System.EventHandler(this.btn_MouseLeaveStyle);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(624, 487);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 50;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.MouseEnter += new System.EventHandler(this.btn_MouseEnterStyle);
            this.btnCancel.MouseLeave += new System.EventHandler(this.btn_MouseLeaveStyle);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(329, 440);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Total Net:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(505, 440);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 48;
            this.label8.Text = "Total with Taxes:";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(599, 437);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 47;
            // 
            // txtTotalNeto
            // 
            this.txtTotalNeto.Enabled = false;
            this.txtTotalNeto.Location = new System.Drawing.Point(389, 437);
            this.txtTotalNeto.Name = "txtTotalNeto";
            this.txtTotalNeto.ReadOnly = true;
            this.txtTotalNeto.Size = new System.Drawing.Size(100, 20);
            this.txtTotalNeto.TabIndex = 46;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(-131, 70);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(101, 23);
            this.btnRemove.TabIndex = 45;
            this.btnRemove.Text = "Remove Selected";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 205);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(689, 206);
            this.dataGridView1.TabIndex = 44;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(589, 121);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 43;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.MouseEnter += new System.EventHandler(this.btn_MouseEnterStyle);
            this.btnAdd.MouseLeave += new System.EventHandler(this.btn_MouseLeaveStyle);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(474, 121);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 42;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // amount
            // 
            this.amount.Location = new System.Drawing.Point(332, 121);
            this.amount.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.amount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(75, 20);
            this.amount.TabIndex = 41;
            this.amount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(76, 121);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(181, 20);
            this.txtDescription.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(434, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Price:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(280, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Amount:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-134, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Description:";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Enabled = false;
            this.txtCustomer.Location = new System.Drawing.Point(76, 28);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(181, 20);
            this.txtCustomer.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-134, -65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Customer:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(283, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 34;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.MouseEnter += new System.EventHandler(this.btn_MouseEnterStyle);
            this.btnSearch.MouseLeave += new System.EventHandler(this.btn_MouseLeaveStyle);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 61;
            this.label10.Text = "Product:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 126);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 60;
            this.label11.Text = "Description:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 59;
            this.label12.Text = "Customer:";
            // 
            // btnRemoveSelected
            // 
            this.btnRemoveSelected.Location = new System.Drawing.Point(10, 167);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new System.Drawing.Size(102, 23);
            this.btnRemoveSelected.TabIndex = 62;
            this.btnRemoveSelected.Text = "Remove Selected";
            this.btnRemoveSelected.UseVisualStyleBackColor = true;
            this.btnRemoveSelected.Click += new System.EventHandler(this.btnRemoveSelected_Click);
            this.btnRemoveSelected.MouseEnter += new System.EventHandler(this.btn_MouseEnterStyle);
            this.btnRemoveSelected.MouseLeave += new System.EventHandler(this.btn_MouseLeaveStyle);
            // 
            // txtProdSelecc
            // 
            this.txtProdSelecc.Location = new System.Drawing.Point(76, 81);
            this.txtProdSelecc.Name = "txtProdSelecc";
            this.txtProdSelecc.ReadOnly = true;
            this.txtProdSelecc.Size = new System.Drawing.Size(181, 20);
            this.txtProdSelecc.TabIndex = 63;
            this.txtProdSelecc.Text = "Click to select product...";
            this.txtProdSelecc.Click += new System.EventHandler(this.txtProdSelecc_Click);
            // 
            // NewInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(720, 555);
            this.ControlBox = false;
            this.Controls.Add(this.txtProdSelecc);
            this.Controls.Add(this.btnRemoveSelected);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.txtPriceProduct);
            this.Controls.Add(this.amountProducts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtTotalNeto);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimumSize = new System.Drawing.Size(728, 567);
            this.Name = "NewInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NewInvoice";
            ((System.ComponentModel.ISupportInitialize)(this.amountProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.TextBox txtPriceProduct;
        private System.Windows.Forms.NumericUpDown amountProducts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtTotalNeto;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.NumericUpDown amount;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Button btnRemoveSelected;
        private System.Windows.Forms.TextBox txtProdSelecc;
    }
}