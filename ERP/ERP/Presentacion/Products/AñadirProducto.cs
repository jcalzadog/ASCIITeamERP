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
        Platforms plataforma;
        public AñadirProducto()
        {
            producto = new Producto();
            plataforma = new Platforms();
            categoria = new Categorias();
            InitializeComponent();
            cargarDatos();
            aparienciaBotones(btnSave);
            aparienciaBotones(btnSaveAnother);
            aparienciaBotones(btnCancel);




        }

        private void btnSaveAnhother_Click(object sender, EventArgs e)
        {
            Producto product = new Producto();
            product.name = txtName.Text;
            product.nomCategory = cmbCategory.SelectedItem.ToString();
            product.nomPlatform = cmbPlatform.SelectedItem.ToString();
            product.miniNumage = Int32.Parse(txtPegi.Text);
            product.prize = Int32.Parse(txtPrice.Text);
            Boolean creado = producto.gestorProducto.nuevoProducto(product);//(txtName.Text,cmbCategory.SelectedItem.ToString(), cmbPlatform.SelectedItem.ToString(),Int32.Parse(txtPegi.Text),Int32.Parse(txtPrice.Text));
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
            Producto product = new Producto();
            product.name = txtName.Text;
            product.nomCategory = cmbCategory.SelectedItem.ToString();
            product.nomPlatform = cmbPlatform.SelectedItem.ToString();
            product.miniNumage = Int32.Parse(txtPegi.Text);
            product.prize = Int32.Parse(txtPrice.Text);
            Boolean creado = producto.gestorProducto.nuevoProducto(product);//(txtName.Text, cmbCategory.SelectedItem.ToString(), cmbPlatform.SelectedItem.ToString(), Int32.Parse(txtPegi.Text), Int32.Parse(txtPrice.Text));
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
            plataforma.gestorplataforma.refrescarPlatform(cmbPlatform);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void aparienciaBotones(Button btn)
        {
            btn.BackColor = Color.Black;
            btn.ForeColor = Color.White;
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

    }
}
