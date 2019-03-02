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

namespace ERP.Presentacion.Categories
{
    public partial class DeleteCategorie : Form
    {
        public String namedelete { get; set; }
        private Categorias categoria { get; set; }
        public DeleteCategorie()
        {
            InitializeComponent();
            cargarComponentes();
            categoria = new Categorias();
            categoria.name = this.namedelete;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            categoria.name = this.namedelete;
            categoria.gestor.deleteCategoria(categoria);
            ERP.Persistencia.Logs.write("Categorie " + categoria.name + " deleted");
            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
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

        public void cargarComponentes()
        {
            //Exit
            btnAceptar.BackColor = Color.Black;
            btnAceptar.ForeColor = Color.White;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.FlatAppearance.BorderColor = Color.Black;
            btnAceptar.FlatAppearance.BorderSize = 1;

            btnCancelar.BackColor = Color.Black;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderColor = Color.Black;
            btnCancelar.FlatAppearance.BorderSize = 1;

        }
    }
}
