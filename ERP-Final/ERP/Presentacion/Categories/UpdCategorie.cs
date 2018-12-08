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
    public partial class UpdCategorie : Form
    {
        Categorias categoria;
     
        public UpdCategorie()
        {
            InitializeComponent();
            categoria = new Categorias();
            cargarComponentes();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Dominio.Util.Validations.validateCategorie(textBox1.Text))
            {
                categoria.name = textBox1.Text;
                categoria.gestor.updateCategorias(categoria);
                this.Dispose();
            }
            else {
                VentanaPersonalizada vp = new VentanaPersonalizada("Has introducido caracteres no validos");
                vp.ShowDialog();
            }
            
            categoria.gestor.readCategorias();
        }
    

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnUpdate_MouseEnter(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.White;
            btnUpdate.ForeColor = Color.Black;
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

        private void btnUpdate_MouseLeave(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.Black;
            btnUpdate.ForeColor = Color.White;
        }
        public void cargarComponentes()
        {
            //Exit
           btnUpdate.BackColor = Color.Black;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.FlatAppearance.BorderColor = Color.Black;
            btnUpdate.FlatAppearance.BorderSize = 1;

            btnCancel.BackColor = Color.Black;
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = Color.Black;
            btnCancel.FlatAppearance.BorderSize = 1;

        }
    }
}
