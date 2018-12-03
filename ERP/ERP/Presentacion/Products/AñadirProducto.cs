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

namespace ERP.Presentacion.Products
{
    public partial class AñadirProducto : Form
    {

        Producto producto;
        public AñadirProducto()
        {
            InitializeComponent();
        }

        private void btnSaveAnhother_Click(object sender, EventArgs e)
        {
            Boolean creado = producto.gestorProducto.nuevoProducto(txtName.Text,cmbCategory.SelectedItem.ToString(), cmbPlatform.SelectedItem.ToString(),Convert.ToInt32(txtPegi.Text), Convert.ToInt32(txtPrice.Text));
            if (creado)
            {
                txtName.Text = "";
                cmbCategory.SelectedIndex = 0;
                cmbPlatform.SelectedIndex = 0;
                txtPegi.Text = "";
                txtPrice.Text = "";
            }
        }
    }
}
