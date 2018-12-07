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
    public partial class EditarProducto : Form
    {
        Producto producto;
        Categorias categoria;
        Platforms plataforma;

        public EditarProducto(String nombre,String catVieja, String platVieja,String pegi, String price)
        {
            producto = new Producto();
            plataforma = new Platforms();
            categoria = new Categorias();
            InitializeComponent();
            cargarDatos(nombre,catVieja,platVieja,pegi,price);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Producto product = new Producto();
            product.name = txtName.Text;
            product.nomCategory = cmbCategory.SelectedItem.ToString();
            product.nomPlatform = cmbPlatform.SelectedItem.ToString();
            product.miniNumage = Int32.Parse(txtPegi.Text);
            product.prize = Int32.Parse(txtPrice.Text);

            producto.gestorProducto.modificarProducto(product, FormPrincipal.catViejaFilaSellecionadaProducts, FormPrincipal.platViejaFilaSellecionadaProducts);//(txtName.Text, cmbCategory.SelectedItem.ToString(), cmbPlatform.SelectedItem.ToString(), Int32.Parse(txtPegi.Text), Int32.Parse(txtPrice.Text),FormPrincipal.catViejaFilaSellecionadaProducts,FormPrincipal.platViejaFilaSellecionadaProducts);
            this.Dispose();
        }
        private void cargarDatos(String name,String catVieja,String platVieja,String pegi,String price)
        {
            txtName.Text = name;
            categoria.gestor.refrescarCategorias(cmbCategory);
            plataforma.gestorplataforma.refrescarPlatform(cmbPlatform);
            cmbCategory.SelectedItem = catVieja;
            cmbPlatform.SelectedItem = platVieja;
            txtPegi.Text = pegi;
            txtPrice.Text = price;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
