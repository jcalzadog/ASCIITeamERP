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

namespace ERP.Presentacion.Usuarios
{
    public partial class NuevoUsuario : Form
    {

        GestorRol gestorR;

        public NuevoUsuario()
        {
            
            gestorR = new GestorRol();
            InitializeComponent();
            cargarComponentes();


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveAnother_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {

        }

        private void btnNewRole_Click(object sender, EventArgs e)
        {
            NuevoRol newRol = new NuevoRol();
            newRol.ShowDialog();
        }

        public void cargarComponentes()
        {
            btnNewRole.BackColor = Color.FromArgb(114, 47, 55);
            btnNewRole.ForeColor = Color.White;
            btnNewRole.FlatStyle = FlatStyle.Flat;
            btnNewRole.FlatAppearance.BorderColor = Color.Black;
            btnNewRole.FlatAppearance.BorderSize = 1;

            btnEditRole.BackColor = Color.FromArgb(114, 47, 55);
            btnEditRole.ForeColor = Color.White;
            btnEditRole.FlatStyle = FlatStyle.Flat;
            btnEditRole.FlatAppearance.BorderColor = Color.Black;
            btnEditRole.FlatAppearance.BorderSize = 1;

            btnSaveClose.BackColor = Color.FromArgb(114, 47, 55);
            btnSaveClose.ForeColor = Color.White;
            btnSaveClose.FlatStyle = FlatStyle.Flat;
            btnSaveClose.FlatAppearance.BorderColor = Color.Black;
            btnSaveClose.FlatAppearance.BorderSize = 1;

            btnSaveAnother.BackColor = Color.FromArgb(114, 47, 55);
            btnSaveAnother.ForeColor = Color.White;
            btnSaveAnother.FlatStyle = FlatStyle.Flat;
            btnSaveAnother.FlatAppearance.BorderColor = Color.Black;
            btnSaveAnother.FlatAppearance.BorderSize = 1;

            btnCancel.BackColor = Color.FromArgb(114, 47, 55);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = Color.Black;
            btnCancel.FlatAppearance.BorderSize = 1;

            gestorR.refrescarRoles(cmbRoles);
        }

        private void btnEditRole_Click(object sender, EventArgs e)
        {
            EditarRol editRol = new EditarRol();
            editRol.ShowDialog();
        }

        private void btnEditRole_MouseEnter(object sender, EventArgs e)
        {
            btnEditRole.BackColor = Color.White;
            btnEditRole.ForeColor = Color.Black;
        }

        private void btnEditRole_MouseLeave(object sender, EventArgs e)
        {
            btnEditRole.BackColor = Color.FromArgb(114, 47, 55);
            btnEditRole.ForeColor = Color.White;
        }

        private void btnNewRole_MouseEnter(object sender, EventArgs e)
        {
            btnNewRole.BackColor = Color.White;
            btnNewRole.ForeColor = Color.Black;
        }

        private void btnNewRole_MouseLeave(object sender, EventArgs e)
        {
            btnNewRole.BackColor = Color.FromArgb(114, 47, 55);
            btnNewRole.ForeColor = Color.White;
        }

        private void btnSaveAnother_MouseEnter(object sender, EventArgs e)
        {
            btnSaveAnother.BackColor = Color.White;
            btnSaveAnother.ForeColor = Color.Black;
        }

        private void btnSaveAnother_MouseLeave(object sender, EventArgs e)
        {
            btnSaveAnother.BackColor = Color.FromArgb(114, 47, 55);
            btnSaveAnother.ForeColor = Color.White;
        }

        private void btnSaveClose_MouseEnter(object sender, EventArgs e)
        {
            btnSaveClose.BackColor = Color.White;
            btnSaveClose.ForeColor = Color.Black;
        }

        private void btnSaveClose_MouseLeave(object sender, EventArgs e)
        {
            btnSaveClose.BackColor = Color.FromArgb(114, 47, 55);
            btnSaveClose.ForeColor = Color.White;
        }

        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.White;
            btnCancel.ForeColor = Color.Black;
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.FromArgb(114, 47, 55);
            btnCancel.ForeColor = Color.White;
        }
    }
}
