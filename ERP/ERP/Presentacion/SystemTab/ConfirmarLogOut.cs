using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Presentacion.SystemTab
{
    public partial class ConfirmarLogOut : Form
    {
        private TabControl tbcMenuPrincipal;
        public ConfirmarLogOut(TabControl tbcMenuPrincipal)
        {
            InitializeComponent();
            cargarComponentes();
            this.tbcMenuPrincipal = tbcMenuPrincipal;
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

        private void lblExit_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin(this.tbcMenuPrincipal);
            this.Dispose();
            this.tbcMenuPrincipal.Hide();
            login.ShowDialog();
            if (!login.IsDisposed)
            {
                this.tbcMenuPrincipal.Visible = true;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
