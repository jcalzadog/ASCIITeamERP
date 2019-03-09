using ERP.Dominio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ERP.Presentacion.Invoices
{
    public partial class ConfirmarBorrarInvoice : Form
    {

        private Invoicees invoice;
        private String numInvoiceFilaSeleccionada;

        public ConfirmarBorrarInvoice(String numInvoiceFilaSeleccionada)
        {
            this.numInvoiceFilaSeleccionada = numInvoiceFilaSeleccionada;
            InitializeComponent();
            cargarComponentes();
            invoice = new Invoicees();
        }


        public void cargarComponentes()
        {
            //Exit
            btnConfirmar.BackColor = Color.Black;
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.FlatAppearance.BorderColor = Color.Black;
            btnConfirmar.FlatAppearance.BorderSize = 1;

            btnCancelar.BackColor = Color.Black;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderColor = Color.Black;
            btnCancelar.FlatAppearance.BorderSize = 1;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            
            invoice.gestor.delete(numInvoiceFilaSeleccionada);
            MessageBox.Show("No llego aqui");
            ERP.Persistencia.Logs.write("Invoice " + numInvoiceFilaSeleccionada + " deleted");
            this.Dispose();
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
    }
}
