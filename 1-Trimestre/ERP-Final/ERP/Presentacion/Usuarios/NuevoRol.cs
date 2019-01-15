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

namespace ERP.Presentacion.Usuarios
{
    public partial class NuevoRol : Form
    {
        private Role rol;

        public NuevoRol()
        {
            rol = new Role();
            InitializeComponent();
            cargarComponentes();
            rol.nameRol = "";
            rol.gestorRol.cargarTablaPermisos(dgvPermissions,rol);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void cargarComponentes()
        {
            btnAllow.BackColor = Color.Black;
            btnAllow.ForeColor = Color.White;
            btnAllow.FlatStyle = FlatStyle.Flat;
            btnAllow.FlatAppearance.BorderColor = Color.Black;
            btnAllow.FlatAppearance.BorderSize = 1;

            btnDeny.BackColor = Color.Black;
            btnDeny.ForeColor = Color.White;
            btnDeny.FlatStyle = FlatStyle.Flat;
            btnDeny.FlatAppearance.BorderColor = Color.Black;
            btnDeny.FlatAppearance.BorderSize = 1;

            btnCancel.BackColor = Color.Black;
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = Color.Black;
            btnCancel.FlatAppearance.BorderSize = 1;

            btnSave.BackColor = Color.Black;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderColor = Color.Black;
            btnSave.FlatAppearance.BorderSize = 1;
        }


        private void btnAllow_MouseEnter(object sender, EventArgs e)
        {
            btnAllow.BackColor = Color.White;
            btnAllow.ForeColor = Color.Black;
        }

        private void btnAllow_MouseLeave(object sender, EventArgs e)
        {
            btnAllow.BackColor = Color.Black;
            btnAllow.ForeColor = Color.White;
        }

        private void btnDeny_MouseEnter(object sender, EventArgs e)
        {
            btnDeny.BackColor = Color.White;
            btnDeny.ForeColor = Color.Black;
        }

        private void btnDeny_MouseLeave(object sender, EventArgs e)
        {
            btnDeny.BackColor = Color.Black;
            btnDeny.ForeColor = Color.White;
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.White;
            btnSave.ForeColor = Color.Black;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.Black;
            btnSave.ForeColor = Color.White;
        }

        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.White;
            btnCancel.ForeColor = Color.Black;
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.Black;
            btnCancel.ForeColor = Color.White;
        }

        private void btnAllow_Click(object sender, EventArgs e)
        {
            int columnaCheck = 0;
            foreach (DataGridViewRow row in dgvPermissions.Rows)
            {
                dgvPermissions.Rows[columnaCheck].Cells[1].Value = true;
                columnaCheck++;
            }
        }

        private void btnDeny_Click(object sender, EventArgs e)
        {
            int columnaCheck = 0;
            foreach (DataGridViewRow row in dgvPermissions.Rows)
            {
                dgvPermissions.Rows[columnaCheck].Cells[1].Value = false;
                columnaCheck++;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Dominio.Util.Validations.validateUser(tbxNombreRol.Text))
            {

                rol.nameRol = tbxNombreRol.Text;
                Boolean creado = rol.gestorRol.nuevoRol(dgvPermissions, rol);
                if (creado)
                {
                    ERP.Persistencia.Logs.write("Role " + tbxNombreRol.Text + " created");
                    this.Dispose();
                }
            }
            else
            {
                VentanaPersonalizada vp = new VentanaPersonalizada("Has introducido caracteres invalidos en el Rol");
                vp.ShowDialog();
            }

        }
    }
}
