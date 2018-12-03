using ERP.Dominio;
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

namespace ERP.Presentacion.Products
{
    public partial class AñadirProducto : Form
    {

        Producto producto;
        Categorias categoria;
        Platform plataforma;
        public AñadirProducto()
        {
            producto = new Producto();
            plataforma = new Platform();
            categoria = new Categorias();
            InitializeComponent();
            cargarDatos();
            

        }

        private void btnSaveAnhother_Click(object sender, EventArgs e)
        {
            Boolean creado = producto.gestorProducto.nuevoProducto(txtName.Text,cmbCategory.SelectedItem.ToString(), cmbPlatform.SelectedItem.ToString(),Int32.Parse(txtPegi.Text),Int32.Parse(txtPrice.Text));
            if (creado)
            {
                txtName.Text = "";
                cmbCategory.SelectedIndex = 0;
                cmbPlatform.SelectedIndex = 0;
                txtPegi.Text = "";
                txtPrice.Text = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Boolean creado = producto.gestorProducto.nuevoProducto(txtName.Text, cmbCategory.SelectedItem.ToString(), cmbPlatform.SelectedItem.ToString(), Int32.Parse(txtPegi.Text), Int32.Parse(txtPrice.Text));
            if (creado)
            {
                this.Dispose();
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cargarDatos()
        {
            categoria.gestor.refrescarCategorias(cmbCategory);
            plataforma.gestor.refrescarPlatform(cmbPlatform);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
