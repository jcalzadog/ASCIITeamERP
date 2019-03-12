using ERP.Dominio;
using ERP.Dominio.Gestores;
using ERP.Presentacion.ErroresCambios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ERP.Presentacion.Orders
{
    public partial class NewOrder : Form
    {
        decimal idCustomer;
        decimal userId;
        Order editingOrder;
        DateTime date;
        Order order;
        List<DetailOrder> details;

        internal Order Order
        {
            get
            {
                return order;
            }

            set
            {
                order = value;
            }
        }

        public NewOrder( Object userId)
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            aparienciaBotones(btnAddProduct);
            aparienciaBotones(btnCancel);
            aparienciaBotones(btnRemoveProduct);
            aparienciaBotones(btnSave);
            aparienciaBotones(btnSelectCustomer);
            this.userId = (decimal)userId;
            initPayMethods();
            date = DateTime.UtcNow.Date;
            lblDate.Text = date.ToString("dd/MM/yyyy");
            details = new List<DetailOrder>();
            editingOrder = null;
            order = new Order();
        }
        /// <summary>
        /// Constructor del formulario de pedido para el caso de estar editando en lugar de creando una nueva, deshabilita el boton de seleccionar cliente
        /// ademas en caso de luego guardar cambios verifica el estado de confirmacion y se lo quita
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="orderId"></param>
        public NewOrder(Object userId, Object orderId) : this (userId)
        {
            this.Text = "Edit order ID" + orderId;
            editingOrder = order.gestorOrder.getOrder(decimal.Parse((string) orderId));
            btnSelectCustomer.Enabled = false;
            foreach (DataRow row in order.gestorOrder.getOrderCart(decimal.Parse((string)orderId)).Rows)
            {
                dgvCart.Rows.Add(row[0], row[1], row[2], row[3]);
            }
            details = order.gestorOrder.getDetails(decimal.Parse((string)orderId));
            throw new Exception();
            //establecer total fecha prepagado, lista de objetos , metodo de pago
            lblTotal.Text = editingOrder.total.ToString();
            lblDate.Text = editingOrder.date.ToString("dd/MM/yyyy");
            cboPayMethods.SelectedIndex = Decimal.ToInt16(editingOrder.refPayMethod) - 1;
            txtNameCustomer.Text = "Customer with ID:" + editingOrder.refCustomer.ToString();
            txtPrepaid.Text = editingOrder.prepaid.ToString();
            idCustomer = editingOrder.refCustomer;
        }

        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            SelectCustomer selector = new SelectCustomer(txtNameCustomer);
            selector.ShowDialog();
            idCustomer = selector.id;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void initPayMethods()
        {
            decimal numberOfMethods =(decimal) new ConnectOracle().DLookUp("COUNT(*)", "PAYMENTMETHODS", "DELETED=0");
            for (int i = 0; i < numberOfMethods; i++)
            {
                cboPayMethods.Items.Add(new ConnectOracle().DLookUp("PAYMENTMETHOD", "PAYMENTMETHODS", "IDPAYMENTMETHOD='" + (i + 1) + "'"));
            }
            cboPayMethods.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (idCustomer==0)
            {
                MessageBox.Show("Customer can't be empty");
            } else if (details.Count == 0)
            {
                MessageBox.Show("The order list can't be empty");
            }
            else 
            {
                decimal id=0;
                if (editingOrder == null)
                {
                    order = new Dominio.Order(0, idCustomer, userId, DateTime.Now, cboPayMethods.SelectedIndex + 1, Convert.ToDecimal(lblTotal.Text), decimal.Parse(txtPrepaid.Text.Equals("") ? "0" : txtPrepaid.Text), 0);
                    //GestorOrder gestor = new GestorOrder();
                    id = order.gestorOrder.insertOrder(order);
                }
                else
                {
                    editingOrder.refPayMethod = cboPayMethods.SelectedIndex + 1;
                    editingOrder.total = Convert.ToDecimal(lblTotal.Text);
                    editingOrder.prepaid = Convert.ToDecimal(txtPrepaid.Text);
                    id = editingOrder.id;
                    order.gestorOrder.deleteDetails(id);
                    order.gestorOrder.updateOrder(editingOrder);
                    
                }
                
                foreach (DetailOrder d in details)
                {
                    order.gestorOrder.insertDetail(d, id);
                }
                VentanaPersonalizada vp = new VentanaPersonalizada("Order saved");
                
                ERP.Persistencia.Logs.write("Order " + id + " created");
                this.Dispose();
            }

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            SelectProduct selector = new SelectProduct();
            selector.ShowDialog();
            if (selector.Acepta)
            {
                details.Add(new DetailOrder(0, selector.IdProd, selector.Cantidad, selector.Price));
                object[] row = new object[4]; 
                row[0] = selector.NameProd;
                row[1] = selector.Cantidad;
                row[2] = selector.Price;
                row[3] = selector.Cantidad * selector.Price;
                dgvCart.Rows.Add(row);
                lblTotal.Text = (Convert.ToDecimal(lblTotal.Text) + (selector.Cantidad * selector.Price)).ToString();
            }
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count > 0)
            {
                
                lblTotal.Text = (Convert.ToDecimal(lblTotal.Text) - Convert.ToDecimal(dgvCart.SelectedRows[0].Cells[3].Value)).ToString();
                details.RemoveAt(dgvCart.SelectedRows[0].Index);
                dgvCart.Rows.Remove(dgvCart.SelectedRows[0]);
                    
                
            }
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Black;
            ((Button)sender).ForeColor = Color.White;
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.White;
            ((Button)sender).ForeColor = Color.Black;
        }

        public void aparienciaBotones(Button btn)
        {
            btn.BackColor = Color.Black;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.Black;
            btn.FlatAppearance.BorderSize = 1;
        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtPrepaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valido = false;
            if (Char.IsDigit(e.KeyChar))
            {
                valido = true;
            }
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                if (!txtPrepaid.Text.Contains(","))
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

        private void ckTotallyPaid_CheckedChanged(object sender, EventArgs e)
        {
            if (ckTotallyPaid.Checked)
            {
                txtPrepaid.Enabled = false;
                txtPrepaid.Text = lblTotal.Text;
            }
            else
            {
                txtPrepaid.Enabled = true;
                txtPrepaid.Text = "";
            }
        }

        private void txtPrepaid_KeyUp(object sender, KeyEventArgs e)
        {
            if (decimal.Parse(txtPrepaid.Text == "" ? "0" : txtPrepaid.Text) >decimal.Parse(lblTotal.Text==""? "0" : lblTotal.Text))
            {
                txtPrepaid.Text = "";
            }
        }

        private void cboPayMethods_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboPayMethods.Text.Equals("Cash on Delivery"))
            {
                txtPrepaid.Text = "";
                txtPrepaid.Enabled = false;
                ckTotallyPaid.Checked = false;
                ckTotallyPaid.Enabled = false;
            } else
            {

                txtPrepaid.Enabled = true;
                ckTotallyPaid.Checked = false;
                ckTotallyPaid.Enabled = true;
            }
        }
    }
}
