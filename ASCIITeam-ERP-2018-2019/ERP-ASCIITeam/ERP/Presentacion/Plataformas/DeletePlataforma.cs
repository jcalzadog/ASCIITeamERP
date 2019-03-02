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

namespace ERP.Presentacion.Plataformas
{
    public partial class DeletePlataforma : Form
    {
        public String nameDelete;
        private Platforms plataforma;
        public DeletePlataforma()
        {
            InitializeComponent();
            cargarComponentes();
            plataforma = new Platforms();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            plataforma.name = this.nameDelete;
            plataforma.gestorplataforma.deletePlataforma(plataforma);
            ERP.Persistencia.Logs.write("Platform " + plataforma.name + " deleted");
            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void cargarComponentes()
        {
            //Exit
            btnConfirm.BackColor = Color.Black;
            btnConfirm.ForeColor = Color.White;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.FlatAppearance.BorderColor = Color.Black;
            btnConfirm.FlatAppearance.BorderSize = 1;

            btnCancelar.BackColor = Color.Black;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderColor = Color.Black;
            btnCancelar.FlatAppearance.BorderSize = 1;

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
    }
}
