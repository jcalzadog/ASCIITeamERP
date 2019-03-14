using ERP.Dominio;
using ERP.Dominio.Gestores;
using ERP.Presentacion.ErroresCambios;
using ERP.Presentacion.Orders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ERP.Presentacion.Invoices

{
    public partial class NewInvoice : Form
    {
        Invoicees i;
        Customer c;
        int taxes = 21;
        List<Object> listaItems = new List<Object>();
        string editing_number = "";

        decimal idProdSelec=0;

        public NewInvoice()
        {   
            InitializeComponent();
            cargarComponentes();
            i = new Invoicees();
            c = new Customer();
            
            this.dataGridView1.Columns.Add("DESCRIPTION", "DESCRIPTION");
            this.dataGridView1.Columns.Add("AMOUNT", "AMOUNT");
            this.dataGridView1.Columns.Add("PRICE UD.", "PRICE UD.");
            this.dataGridView1.Columns.Add("TOTAL", "TOTAL");
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.txtTotalNeto.Text = "0";
            this.txtTotal.Text = "0";
            foreach (DataGridViewColumn column in this.dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //
        }

        public NewInvoice (string editing_number): this()
        {
            this.editing_number = editing_number;
            this.listaItems = i.gestor.getItems(Convert.ToDecimal(editing_number));
            this.txtTotal.Text = i.gestor.getTotalInvoice(Convert.ToDecimal(editing_number)).ToString();
            this.txtTotalNeto.Text = (Convert.ToDecimal(txtTotal.Text) * (decimal)0.79).ToString();
            this.txtCustomer.Text = i.gestor.getDNICustomer(editing_number);
            DataTable tabla = i.gestor.getTable(editing_number);
            foreach (DataRow r in tabla.Rows)
            {
                dataGridView1.Rows.Add(r[0], r[1], r[2], r[3], Convert.ToDecimal(r[2])*Convert.ToDecimal(r[3]));
            }

            
        }

        public void cargarComponentes()
        {
            aparienciaBotones(btnSearch);
            aparienciaBotones(btnAdd);
            aparienciaBotones(btnAddProduct);
            aparienciaBotones(btnRemoveSelected);
            aparienciaBotones(btnAccept);
            aparienciaBotones(btnCancel);
        }

        public void aparienciaBotones(Button btn)
        {
            btn.BackColor = Color.Black;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.Black;
            btn.FlatAppearance.BorderSize = 1;

        }

        private void btn_MouseEnterStyle(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.White;
            ((Button)sender).ForeColor = Color.Black;
        }

        private void btn_MouseLeaveStyle(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Black;
            ((Button)sender).ForeColor = Color.White;
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
                float xtotal = float.Parse(this.txtTotal.Text.ToString()) + total;
                this.txtTotal.Text = xtotal.ToString();

                this.txtTotalNeto.Text = calcularIVA().ToString();
                
                LinesInvoices li = new LinesInvoices(description,amount,price,0,0);
                listaItems.Add(li);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (this.txtProdSelecc.Text.ToString().Equals("Click to select product...") || this.txtPriceProduct.Text.Equals(""))
            {
                VentanaPersonalizada vp = new VentanaPersonalizada("You must fill al the fields");
                vp.ShowDialog();

            }
            else
            {
                float price = float.Parse(this.txtPriceProduct.Text.Replace(".", ",").Replace("'", "").Replace("-",""));
                price = (float)Math.Round(price, 2);
                int amount = int.Parse(this.amountProducts.Value.ToString());
                float total = price * amount;
                total = (float)Math.Round(total, 2);
                this.dataGridView1.Rows.Add(txtProdSelecc.Text, amount, price, total);
                float xtotal = float.Parse(this.txtTotal.Text.ToString()) + total;
                this.txtTotal.Text = xtotal.ToString();
                
                this.txtTotalNeto.Text = calcularIVA().ToString();

                ProductsInvoices pi = new ProductsInvoices(Convert.ToInt16(idProdSelec), 0, amount, price);
                listaItems.Add(pi);

                idProdSelec = 0;
                amountProducts.Value = 1;
                txtProdSelecc.Text = "Click to select product...";
                txtPriceProduct.Text = "";

            }
        }
        public float calcularIVA() {
            float xtotal = float.Parse(this.txtTotal.Text.ToString());
            float xtotalneto = xtotal - ((xtotal * taxes) / 100);
            this.txtTotalNeto.Text = xtotalneto.ToString();
            return xtotalneto;
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

        
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (this.txtCustomer.Text.Equals("") || dataGridView1.RowCount==0)
            {
                VentanaPersonalizada vp = new VentanaPersonalizada("You haven't selected any customer or the invoice is empty ");
                vp.ShowDialog();
            }
            else
            {
                int idcliente = Convert.ToInt32(i.gestor.getIdCliente(this.txtCustomer.Text.ToString()));
                float amount = float.Parse(this.txtTotal.Text.ToString());
                int idinvoice=0;
                if (!this.editing_number.Equals(""))
                {
                    i.gestor.deleteDetails(Convert.ToDecimal(editing_number));
                    idinvoice = Convert.ToInt16(i.gestor.getIdInvoice(Convert.ToDecimal(editing_number)));
                    i.gestor.editInvoice(editing_number, idcliente, amount);
                } else
                {
                    idinvoice = Convert.ToInt32(i.gestor.generateInvoice(idcliente, amount));
                }
                for (int j = 0; j < listaItems.Count; j++)
                {
                    if (listaItems.ElementAt(j).GetType() == typeof(ProductsInvoices))
                    {
                        ProductsInvoices aux = (ProductsInvoices)listaItems.ElementAt(j);
                        i.gestor.insertarProductInvoices(aux.Idproduct, idinvoice, aux.Amount, aux.Price);
                    } else if (listaItems.ElementAt(j).GetType()== typeof(DetailOrder))
                    {
                        //como es un detail order no tiene que insertarlo, ya se encuentra insertado previamente
                    }
                    else
                    {
                        LinesInvoices aux = (LinesInvoices)listaItems.ElementAt(j);
                        i.gestor.insertarLinesInvoices(aux.Description, idinvoice, aux.Amount, aux.Price);
                    }
                }
                
                this.Dispose();
            }
           
            
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
         
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (listaItems.ElementAt(dataGridView1.SelectedRows[0].Index).GetType() == typeof(DetailOrder))
                {
                    new VentanaPersonalizada("This item cannot be deleted because \nit comes from the order.").ShowDialog();
                }
                else
                {
                    this.txtTotal.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[3].Value)).ToString();
                    listaItems.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                    this.txtTotalNeto.Text = calcularIVA().ToString();

                }
            }
            
        }

        private void txtProdSelecc_Click(object sender, EventArgs e)
        {
            SelectProduct selector = new SelectProduct();
            selector.ShowDialog();
            if (selector.Acepta)
            {
                idProdSelec = selector.IdProd;
                amountProducts.Value = selector.Cantidad;
                txtProdSelecc.Text = selector.NameProd;
                txtPriceProduct.Text = selector.Price.ToString();
            } else
            {
                idProdSelec = 0;
                amountProducts.Value = 1;
                txtProdSelecc.Text = "Click to select product...";
                txtPriceProduct.Text ="";
            }
        }
    }
    
    
}
