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
    public partial class AddCategoria : Form
    {
        Categorias categoria;
        public AddCategoria()
        {
            InitializeComponent();
            categoria = new Categorias();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            categoria.gestor.insertCategorias(textBox1.Text);
            categoria.gestor.readCategorias();
            this.Dispose();
        }


        //btnSaveAndAnother
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            categoria.gestor.insertCategorias(textBox1.Text);
            textBox1.Text = "";
            categoria.gestor.readCategorias();

        }

        public void cargarDiseño() {
            btnCancelar.BackColor = Color.FromArgb(114, 47, 55);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderColor = Color.Black;
            btnCancelar.FlatAppearance.BorderSize = 1;

            btnSave.BackColor = Color.FromArgb(114, 47, 55);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderColor = Color.Black;
            btnSave.FlatAppearance.BorderSize = 1;

            btnAceptar.BackColor = Color.FromArgb(114, 47, 55);
            btnAceptar.ForeColor = Color.White;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.FlatAppearance.BorderColor = Color.Black;
            btnAceptar.FlatAppearance.BorderSize = 1;
        }
    }
}
