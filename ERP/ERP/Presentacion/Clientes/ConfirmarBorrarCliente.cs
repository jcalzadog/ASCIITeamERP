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

namespace ERP.Presentacion.Clientes
{
    public partial class ConfirmarBorrarCliente : Form
    {
        private Customer cliente;
        private DataGridView dgvCustomers;
        private String dniFilaSeleccionada;
        public ConfirmarBorrarCliente(DataGridView dgvCustomers, String dniFilaSeleccionada)
        {
            cliente = new Customer();
            InitializeComponent();
            this.dgvCustomers = dgvCustomers;
            this.dniFilaSeleccionada = dniFilaSeleccionada;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //usuario.gestorusuario.eliminarUsuario(dgvUsers, this.nombreFilaSeleccionada);
            cliente.gestorCliente.eliminarCliente(dgvCustomers, dniFilaSeleccionada);
            this.Dispose();
        }
    }
}
