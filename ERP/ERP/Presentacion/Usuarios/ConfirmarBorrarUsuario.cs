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
            
            this.dgvUsers = dgvUsers;
            this.nombreFilaSeleccionada = nombreFilaSeleccionada;
            InitializeComponent();
            cargarComponentes();
            usuario = new User(nombreFilaSeleccionada);
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
            usuario.gestorusuario.eliminarUsuario(dgvUsers, usuario);
            this.Dispose();
        }

        private void btnCancelar_MouseEnter(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.White;
            btnCancelar.ForeColor = Color.Black;
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.Black;
            btnCancelar.ForeColor = Color.White;
        }

        private void btnConfirmar_MouseEnter(object sender, EventArgs e)
        {
            btnConfirmar.BackColor = Color.White;
            btnConfirmar.ForeColor = Color.Black;
        }

        private void btnConfirmar_MouseLeave(object sender, EventArgs e)
        {
            btnConfirmar.BackColor = Color.Black;
            btnConfirmar.ForeColor = Color.White;
        }
    }
}
