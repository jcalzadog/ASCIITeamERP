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
    public partial class ConfirmarBorrarRol : Form
    {

        private Role rol;
        private String nameRol;

        public ConfirmarBorrarRol(String nombreRol)
        {
            InitializeComponent();
            cargarComponentes();
            rol = new Role();
            rol.nameRol = nombreRol;
        }

        public void cargarComponentes()
        {
            //Exit
            btnConfirm.BackColor = Color.Black;
            btnConfirm.ForeColor = Color.White;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.FlatAppearance.BorderColor = Color.Black;
            btnConfirm.FlatAppearance.BorderSize = 1;

            btnCancel.BackColor = Color.Black;
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = Color.Black;
            btnCancel.FlatAppearance.BorderSize = 1;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void style_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Black;
            ((Button)sender).ForeColor = Color.White;
        }

        private void style_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Black;
            ((Button)sender).ForeColor = Color.White;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            bool borrado = rol.gestorRol.eliminarRole(rol);
            if (borrado)
            {
                ERP.Persistencia.Logs.write("Role " + rol.nameRol + " deleted");
                this.Dispose();
            }
        }
    }
}
