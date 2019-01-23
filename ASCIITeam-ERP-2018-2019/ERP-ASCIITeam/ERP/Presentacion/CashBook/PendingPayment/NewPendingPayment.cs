using ERP.Dominio;
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

namespace ERP.Presentacion.CashBook.PendingPayment
{
    public partial class NewPendingPayment : Form
    {

        PendingPayments pendingPayment;
        Object usuarioLogeado;

        public NewPendingPayment(Object usuarioLogeado)
        {
            InitializeComponent();
            pendingPayment = new PendingPayments();

            cargarComponentes();
            this.usuarioLogeado = usuarioLogeado;
        }

        public void cargarComponentes()
        {
            cmbType.DataSource = pendingPayment.gestorPendingPayments.getTypes();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rtbConcept.Text == "" || tbxAmount.Text == "")
            {

            }
            else
            {
                if (decimal.Parse(tbxAmount.Text) < 0)
                {
                    VentanaPersonalizada vp = new VentanaPersonalizada("The amount is negative.");
                    vp.ShowDialog();
                }
                else
                {
                    pendingPayment.gestorPendingPayments.newPendingPayment(new Dominio.PendingPayments(0, DateTime.Today, (decimal)this.usuarioLogeado, cmbType.SelectedIndex, rtbConcept.Text, decimal.Parse(tbxAmount.Text),0));
                    this.Dispose();
                }
            }
        }

        private void tbxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valido = false;
            if (Char.IsDigit(e.KeyChar))
            {
                valido = true;
            }
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                if (!tbxAmount.Text.Contains(","))
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
    }
}
