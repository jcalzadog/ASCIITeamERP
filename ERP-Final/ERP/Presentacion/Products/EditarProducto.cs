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
            aparienciaBotones(btnSave);
            aparienciaBotones(btnCancel);
            

        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Black;
            ((Button)sender).ForeColor = Color.White;
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.White;
            ((Button)sender).ForeColor = Color.Black;
        }

        public void aparienciaBotones(Button btn)
        {
            btn.BackColor = Color.Black;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.Black;
            btn.FlatAppearance.BorderSize = 1;
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
            btnSave.BackColor = Color.Transparent;
            btnCancel.BackColor = Color.Transparent;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cargarBotones(bool pegi, bool price)
        {
            if (pegi && price)
            {
                btnSave.Enabled = true;
                btnSave.BackColor = Color.Black;
                btnSave.ForeColor = Color.White;
                
            }
            else
            {
                btnSave.Enabled = false;
                btnSave.BackColor = Color.Transparent;
                btnSave.ForeColor = Color.Black;
                
            }
        }

        private void txtPegi_KeyUp(object sender, KeyEventArgs e)
        {
            int i = 0;
            bool result1 = int.TryParse(txtPrice.Text, out i);
            bool result2 = int.TryParse(txtPegi.Text, out i);
            cargarBotones(result1, result2);
        }

        private void txtPrice_KeyUp(object sender, KeyEventArgs e)
        {
            int i = 0;
            bool result1 = int.TryParse(txtPrice.Text, out i);
            bool result2 = int.TryParse(txtPegi.Text, out i);
            cargarBotones(result1, result2);
        }
    }
}
