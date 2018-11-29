using ERP.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Presentacion.Usuarios
{
    public partial class ConfirmarBorrarUsuario : Form
    {

        private User usuario;
        private DataGridView dgvUsers;
        private String nombreFilaSeleccionada;
        public ConfirmarBorrarUsuario(DataGridView dgvUsers, String nombreFilaSeleccionada)
        {
            usuario = new User();
            this.dgvUsers = dgvUsers;
            this.nombreFilaSeleccionada = nombreFilaSeleccionada;
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            usuario.gestorusuario.eliminarUsuario(dgvUsers, this.nombreFilaSeleccionada);
        }
    }
}
