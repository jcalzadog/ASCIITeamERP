using ERP.Dominio;
using ERP.Dominio.Gestores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Presentacion.Invoices

{
    public partial class NewInvoice : Form
    {
        Invoicees i;
        Customer c;
        public NewInvoice()
        {   
            InitializeComponent();
            i = new Invoicees();
            c = new Customer();
            i.gestor.comboProducts(this.cmbProducts);
            
            this.dataGridView1.Columns.Add("DESCRIPTION", "DESCRIPTION");
            this.dataGridView1.Columns.Add("AMOUNT", "AMOUNT");
            this.dataGridView1.Columns.Add("PRICE UD.", "PRICE UD.");
            this.dataGridView1.Columns.Add("TOTAL", "TOTAL");
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.txtTotalNeto.Text = "0";
            this.txtTotal.Text = "0";
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            float price = float.Parse(this.txtPrice.Text.Replace(".", ",").Replace("'", ""));
            price = (float)Math.Round(price, 2);
            int amount = int.Parse(this.amount.Value.ToString());
            string description = this.txtDescription.Text;
            float total = price * amount;
            total = (float)Math.Round(total, 2);
            this.dataGridView1.Rows.Add(description, amount, price, total);
            float xneto = float.Parse(this.txtTotalNeto.Text.ToString()) + total;
            this.txtTotalNeto.Text = xneto.ToString();
            float xtotal = xneto + ((xneto * 21) / 100);
            this.txtTotal.Text = xtotal.ToString();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            float price = float.Parse(this.txtPriceProduct.Text.Replace(".", ",").Replace("'", ""));
            price = (float)Math.Round(price, 2);
            int amount = int.Parse(this.amountProducts.Value.ToString());
            string product = this.cmbProducts.SelectedItem.ToString() ;
            float total = price * amount;
            total = (float)Math.Round(total, 2);
            this.dataGridView1.Rows.Add(product, amount, price, total);
            float xneto = float.Parse(this.txtTotalNeto.Text.ToString()) + total;
            this.txtTotalNeto.Text = xneto.ToString();
            float xtotal = xneto + ((xneto * 21) / 100);
            this.txtTotal.Text = xtotal.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            selectCustomer sc = new selectCustomer();

            sc.ShowDialog();
            this.txtCustomer.Text = sc.customername;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
