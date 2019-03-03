using ERP.Dominio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ERP.Presentacion.Products
{
    public partial class EditarProducto : Form
    {
        Producto producto;
        Categorias categoria;
        Platforms plataforma;

        public EditarProducto(String nombre,String catVieja, String platVieja,String pegi, String price, String stock)
        {
            producto = new Producto();
            plataforma = new Platforms();
            categoria = new Categorias();
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            cargarDatos(nombre,catVieja,platVieja,pegi,price,stock);
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
            product.stock = Int32.Parse(txtStock.Text);

            producto.gestorProducto.modificarProducto(product, FormPrincipal.catViejaFilaSellecionadaProducts, FormPrincipal.platViejaFilaSellecionadaProducts);//(txtName.Text, cmbCategory.SelectedItem.ToString(), cmbPlatform.SelectedItem.ToString(), Int32.Parse(txtPegi.Text), Int32.Parse(txtPrice.Text),FormPrincipal.catViejaFilaSellecionadaProducts,FormPrincipal.platViejaFilaSellecionadaProducts);
            ERP.Persistencia.Logs.write("Product " + txtName.Text + " updated");
            this.Dispose();
        }
        private void cargarDatos(String name,String catVieja,String platVieja,String pegi,String price, String stock)
        {
            txtName.Text = name;
            categoria.gestor.refrescarCategorias(cmbCategory);
            plataforma.gestorplataforma.refrescarPlatform(cmbPlatform);
            cmbCategory.SelectedItem = catVieja;
            cmbPlatform.SelectedItem = platVieja;
            txtPegi.Text = pegi;
            txtPrice.Text = price;
            txtStock.Text = stock;
            btnSave.BackColor = Color.Transparent;
            btnCancel.BackColor = Color.Transparent;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cargarBotones(bool pegi, bool price, bool stock)
        {
            if (pegi && price && stock)
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
            bool result3 = int.TryParse(txtStock.Text, out i);
            cargarBotones(result1, result2, result3);
        }

        private void txtPrice_KeyUp(object sender, KeyEventArgs e)
        {
            int i = 0;
            bool result1 = int.TryParse(txtPrice.Text, out i);
            bool result2 = int.TryParse(txtPegi.Text, out i);
            bool result3 = int.TryParse(txtStock.Text, out i);
            cargarBotones(result1, result2, result3);
        }

        private void txtStock_KeyUp(object sender, KeyEventArgs e)
        {
            int i = 0;
            bool result1 = int.TryParse(txtPrice.Text, out i);
            bool result2 = int.TryParse(txtPegi.Text, out i);
            bool result3 = int.TryParse(txtStock.Text, out i);
            cargarBotones(result1, result2,result3);
        }
    }
}
