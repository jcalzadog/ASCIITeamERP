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

namespace ERP.Presentacion.Plataformas
{
    public partial class UpdatePlataforma : Form
    {
        private Platforms plataforma;

        public UpdatePlataforma()
        {
            InitializeComponent();
            cargarDiseño();
            plataforma = new Platforms();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Dominio.Util.Validations.validatePlatforms(txtUpdate.Text)) {

            plataforma.name = txtUpdate.Text;
            plataforma.gestorplataforma.updatePlataforma(plataforma);
            this.Dispose();
            plataforma.gestorplataforma.readPlatforms();
            }
            else
            {
                VentanaPersonalizada vp = new VentanaPersonalizada("Has introducido caracteres invalidos");
                vp.ShowDialog();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void cargarDiseño()
        {
            btnUpdate.BackColor = Color.Black;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.FlatAppearance.BorderColor = Color.Black;
            btnUpdate.FlatAppearance.BorderSize = 1;

            btnCancelar.BackColor = Color.Black;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderColor = Color.Black;
            btnCancelar.FlatAppearance.BorderSize = 1;
        }

        private void btnUpdate_MouseEnter(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.White;
            btnUpdate.ForeColor = Color.Black;
        }

        private void btnUpdate_MouseLeave(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.Black;
            btnUpdate.ForeColor = Color.White;
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

        private void UpdatePlataforma_Load(object sender, EventArgs e)
        {

        }
    }
}
