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

namespace ERP.Presentacion.Categories
{
    public partial class AddCategoria : Form
    {
        Categorias categoria;
        public AddCategoria()
        {
            InitializeComponent();
            categoria = new Categorias();
            cargarDiseño();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Dominio.Util.Validations.validatePlatforms(textBox1.Text))
            {
                categoria.name = textBox1.Text;
                categoria.gestor.insertCategorias(categoria);
                categoria.gestor.readCategorias();
                ERP.Persistencia.Logs.write("Categorie " + textBox1.Text + " created");
                this.Dispose();
            }
            else {
                VentanaPersonalizada vp = new VentanaPersonalizada("Has introducido caracteres invalidos");
                vp.ShowDialog();
            }
            
            
        }


        //btnSaveAndAnother
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Dominio.Util.Validations.validateCategorie(textBox1.Text))
            {
                categoria.name = textBox1.Text;
                categoria.gestor.insertCategorias(categoria);
                textBox1.Text = "";
                categoria.gestor.readCategorias();
                ERP.Persistencia.Logs.write("Categorie " + textBox1.Text + " created");
            }
            else
            {
                VentanaPersonalizada vp = new VentanaPersonalizada("Has introducido caracteres invalidos");
                vp.ShowDialog();
            }


        }

        public void cargarDiseño() {
            btnAceptar.BackColor = Color.Black;
            btnAceptar.ForeColor = Color.White;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.FlatAppearance.BorderColor = Color.Black;
            btnAceptar.FlatAppearance.BorderSize = 1;

            btnSave.BackColor = Color.Black;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderColor = Color.Black;
            btnSave.FlatAppearance.BorderSize = 1;

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
