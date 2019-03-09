using ERP.Dominio;
using ERP.Dominio.Gestores;
using ERP.Presentacion.ErroresCambios;
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
        int taxes = 21;
        List<Producto> listaProducts = new List<Producto>();
        List<LinesInvoices> listaProducts = new List<LinesInvoices>();
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
            if (this.txtDescription.Text.Equals("") || this.txtPrice.Text.Equals(""))
            {
                VentanaPersonalizada vp = new VentanaPersonalizada("You must fill al the fields");
                vp.ShowDialog();
            }
            else
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
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (this.cmbProducts.Text.ToString().Equals("Nothing") || this.txtPriceProduct.Text.Equals(""))
            {
                VentanaPersonalizada vp = new VentanaPersonalizada("You must fill al the fields");
                vp.ShowDialog();

            }
            else
            {
                float price = float.Parse(this.txtPriceProduct.Text.Replace(".", ",").Replace("'", ""));
                price = (float)Math.Round(price, 2);
                int amount = int.Parse(this.amountProducts.Value.ToString());
                string product = this.cmbProducts.SelectedItem.ToString();
                float total = price * amount;
                total = (float)Math.Round(total, 2);
                this.dataGridView1.Rows.Add(product, amount, price, total);
                float xneto = float.Parse(this.txtTotalNeto.Text.ToString()) + total;
                this.txtTotalNeto.Text = xneto.ToString();
                float xtotal = xneto + ((xneto * taxes) / 100);
                this.txtTotal.Text = xtotal.ToString();
            }
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

        private void txtPriceProduct_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPriceProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valido = false;
            if (Char.IsDigit(e.KeyChar))
            {
                valido = true;
            }
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                if (!txtPriceProduct.Text.Contains(","))
                {
                    e.KeyChar = ',';
                    valido = true;
                }

            }
            if (Char.IsControl(e.KeyChar))
            {
                valido = true;
            }
            e.Handled = !valido;
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valido = false;
            if (Char.IsDigit(e.KeyChar))
            {
                valido = true;
            }
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                if (!txtPrice.Text.Contains(","))
                {
                    e.KeyChar = ',';
                    valido = true;
                }

            }
            if (Char.IsControl(e.KeyChar))
            {
                valido = true;
            }
            e.Handled = !valido;
        }

        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbProducts.Text.ToString().Equals("Nothing"))
            {
                this.txtPriceProduct.Text = "";
            }
            else {
                decimal precio = i.gestor.productPrice(this.cmbProducts.Text.ToString());
                this.txtPriceProduct.Text = precio.ToString();
            }
        }
    }
    
    
}
