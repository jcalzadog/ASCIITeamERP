using ERP.Dominio;
using ERP.Dominio.Gestores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Presentacion.Orders
{
    public partial class SelectProduct : Form
    {
        bool acepta;
        int cantidad = 1;
        decimal idProd;
        decimal price;
        string nameProd;
        Producto producto;
        public SelectProduct()
        {
            InitializeComponent();
            aparienciaBotones(btnCancel);
            Acepta = false;
            producto = new Producto();
            cargarTablaProductos("");
        }

        public void aparienciaBotones(Button btn)
        {
            btn.BackColor = Color.Black;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.Black;
            btn.FlatAppearance.BorderSize = 1;
        }

        public bool Acepta
        {
            get
            {
                return acepta;
            }

            set
            {
                acepta = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
            }
        }

        public decimal IdProd
        {
            get
            {
                return idProd;
            }

            set
            {
                idProd = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public string NameProd
        {
            get
            {
                return nameProd;
            }

            set
            {
                nameProd = value;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IdProd =(decimal) dgvProducts.SelectedRows[0].Cells[0].Value;
            price = (decimal)dgvProducts.SelectedRows[0].Cells[5].Value;
            nameProd = (string)dgvProducts.SelectedRows[0].Cells[1].Value;
            Acepta = true;
            this.Dispose();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            cantidad = (int)numericUpDown1.Value;
            
        }


        private void cargarTablaProductos(String condicion)
        {
            dgvProducts.Columns.Clear();

            producto.gestorProducto.leerProductos(condicion);


            DataTable tproduct = producto.gestorProducto.tabla;
            dgvProducts.Columns.Clear();
            dgvProducts.Columns.Add("IDPRODUCT", "IDPRODUCT");
            dgvProducts.Columns.Add("NAME", "NAME");
            dgvProducts.Columns.Add("IDCATEGORY", "CATEGORY");
            dgvProducts.Columns.Add("IDPLATFORM", "PLATFORM");
            dgvProducts.Columns.Add("MINIMUMAGE", "PEGI");
            dgvProducts.Columns.Add("PRICE", "PRICE");

            foreach (DataRow row in tproduct.Rows)
            {
                dgvProducts.Rows.Add(row["IDPRODUCT"], row["NAME"], row["CATEGORY"], row["PLATFORM"], row["PEGI"], row["PRICE"]);
            }

            dgvProducts.RowHeadersVisible = false;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BackgroundColor = Color.Black;
            dgvProducts.AllowUserToResizeRows = false;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            dgvProducts.ReadOnly = true;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string condicion = " UPPER(PR.NAME) like '%" + textBox1.Text.ToUpper() + "%' AND PR.DELETED=0 ";
            cargarTablaProductos(condicion);
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
