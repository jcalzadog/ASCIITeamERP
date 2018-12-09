using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.Dominio.Gestores;

namespace ERP.Presentacion.Orders
{
    public partial class SelectCustomer : Form
    {
        Customer cliente;
        string dni;
        TextBox txtNombre;
        public decimal id { get; set; }
        public SelectCustomer(TextBox txtNombre)
        {
            InitializeComponent();
            aparienciaBotones(btnCancel);
            cliente = new Customer();
            this.txtNombre = txtNombre;
            cargarTablaClientes("DELETED=0");
            
        }

        public void aparienciaBotones(Button btn)
        {
            btn.BackColor = Color.Black;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.Black;
            btn.FlatAppearance.BorderSize = 1;
        }

        private void cargarTablaClientes(String condicion)
        {
            dgvSelectCustomer.Columns.Clear();

            cliente.gestorCliente.leerClientes(condicion);


            DataTable tcustomers = cliente.gestorCliente.tabla;
            dgvSelectCustomer.Columns.Clear();

            dgvSelectCustomer.Columns.Add("DNI", "DNI");
            dgvSelectCustomer.Columns.Add("NAME", "NAME");
            dgvSelectCustomer.Columns.Add("SURNAME", "SURNAME");
            dgvSelectCustomer.Columns.Add("ADDRESS", "ADDRESS");
            //dgvSelectCustomer.Columns.Add("PHONE", "PHONE");
            //dgvSelectCustomer.Columns.Add("EMAIL", "EMAIL");
            //dgvSelectCustomer.Columns.Add("CITY", "CITY");

            foreach (DataRow row in tcustomers.Rows)
            {
                dgvSelectCustomer.Rows.Add(row["DNI"], row["NAME"], row["SURNAME"], row["ADDRESS"]);
            }
            //dgvUsers.ColumnHeadersVisible = false;
            dgvSelectCustomer.RowHeadersVisible = false;
            dgvSelectCustomer.AllowUserToAddRows = false;
            dgvSelectCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSelectCustomer.BackgroundColor = Color.Black;

            //No editable
            dgvSelectCustomer.ReadOnly = true;
            dgvSelectCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtSearchCustomer_KeyUp(object sender, KeyEventArgs e)
        {
            cargarTablaClientes("DELETED=0 AND ((UPPER(DNI) LIKE '%"+txtSearchCustomer.Text.ToUpper()+ "%') OR (UPPER(NAME) LIKE '%" + txtSearchCustomer.Text.ToUpper() + "%') OR (UPPER(SURNAME) LIKE '%" + txtSearchCustomer.Text.ToUpper() + "%'))");
        }

        private void dgvSelectCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dni =(string) dgvSelectCustomer.Rows[e.RowIndex].Cells[0].Value;
            id = (decimal) new ConnectOracle().DLookUp("IDCUSTOMER", "CUSTOMERS", "DNI='" + dni + "'");
            txtNombre.Text = (string)dgvSelectCustomer.Rows[e.RowIndex].Cells[1].Value;
            this.Dispose();
            
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
