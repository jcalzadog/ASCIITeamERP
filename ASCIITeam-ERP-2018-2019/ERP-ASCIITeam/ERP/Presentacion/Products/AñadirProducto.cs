using ERP.Dominio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ERP.Presentacion.Products
{
    public partial class AñadirProducto : Form
    {

        Producto producto;
        Categorias categoria;
        Platforms plataforma;
        public AñadirProducto(DataGridView cat, DataGridView plat)
        {
            producto = new Producto();
            plataforma = new Platforms();
            categoria = new Categorias();
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            cargarDatos();
            aparienciaBotones(btnSave);
            aparienciaBotones(btnSaveAnother);
            btnCancel.BackColor = Color.Black;
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = Color.Black;
            btnCancel.FlatAppearance.BorderSize = 1;




        }

        private void btnSaveAnhother_Click(object sender, EventArgs e)
        {
            Producto product = new Producto();
            product.name = txtName.Text;
            product.nomCategory = cmbCategory.SelectedItem.ToString();
            product.nomPlatform = cmbPlatform.SelectedItem.ToString();
            product.miniNumage = Int32.Parse(txtPegi.Text);
            product.prize = Int32.Parse(txtPrice.Text);
            product.stock = Int32.Parse(txtStock.Text);
            Boolean creado = producto.gestorProducto.nuevoProducto(product);//(txtName.Text,cmbCategory.SelectedItem.ToString(), cmbPlatform.SelectedItem.ToString(),Int32.Parse(txtPegi.Text),Int32.Parse(txtPrice.Text));
            if (creado)
            {
                ERP.Persistencia.Logs.write("Product " + txtName.Text + " created");
                txtName.Text = "";
                cmbCategory.SelectedIndex = 0;
                cmbPlatform.SelectedIndex = 0;
                txtPegi.Text = "";
                txtPrice.Text = "";
                txtStock.Text = "";
            }
            
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
            Boolean creado = producto.gestorProducto.nuevoProducto(product);//(txtName.Text, cmbCategory.SelectedItem.ToString(), cmbPlatform.SelectedItem.ToString(), Int32.Parse(txtPegi.Text), Int32.Parse(txtPrice.Text));
            if (creado)
            {
                ERP.Persistencia.Logs.write("Product " + txtName.Text + " created");
                this.Dispose();
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cargarDatos()
        {
            categoria.gestor.refrescarCategorias(cmbCategory);
            plataforma.gestorplataforma.refrescarPlatform(cmbPlatform);
            btnSaveAnother.Enabled = false;
            btnSave.Enabled = false;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void aparienciaBotones(Button btn)
        {
            btn.BackColor = Color.Transparent;
            btn.ForeColor = Color.Black;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.Black;
            btn.FlatAppearance.BorderSize = 1;
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

        private void txtPegi_KeyUp(object sender, KeyEventArgs e)
        {
            int i = 0;
            bool result1 = int.TryParse(txtPrice.Text, out i);
            bool result2 = int.TryParse(txtPegi.Text, out i);
            bool result3 = int.TryParse(txtStock.Text, out i);
            cargarBotones(result1, result2,result3);
        }

        private void txtPrice_KeyUp(object sender, KeyEventArgs e)
        {
            int i = 0;
            bool result1 = int.TryParse(txtPrice.Text, out i);
            bool result2 = int.TryParse(txtPegi.Text, out i);
            bool result3 = int.TryParse(txtStock.Text, out i);
            cargarBotones(result1, result2, result3);
        }

        private void cargarBotones(bool pegi,bool price,bool stock)
        {
            if(pegi && price && stock)
            {
                btnSave.Enabled = true;
                btnSaveAnother.Enabled = true;

                btnSave.BackColor = Color.Black;
                btnSave.ForeColor = Color.White;

                btnSaveAnother.BackColor = Color.Black;
                btnSaveAnother.ForeColor = Color.White;
            }
            else
            {
                btnSave.Enabled = false;
                btnSaveAnother.Enabled = false;

                btnSave.BackColor = Color.Transparent;
                btnSave.ForeColor = Color.Black;

                btnSaveAnother.BackColor = Color.Transparent;
                btnSaveAnother.ForeColor = Color.Black;
            }
        }

        private void txtStock_KeyUp(object sender, KeyEventArgs e)
        {
            int i = 0;
            bool result1 = int.TryParse(txtPrice.Text, out i);
            bool result2 = int.TryParse(txtPegi.Text, out i);
            bool result3 = int.TryParse(txtStock.Text, out i);
            cargarBotones(result1, result2, result3);
        }
    }
}
