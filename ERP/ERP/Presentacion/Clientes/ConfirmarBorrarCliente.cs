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
        public ConfirmarBorrarCliente()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //usuario.gestorusuario.eliminarUsuario(dgvUsers, this.nombreFilaSeleccionada);
            this.Dispose();
        }
    }
}
