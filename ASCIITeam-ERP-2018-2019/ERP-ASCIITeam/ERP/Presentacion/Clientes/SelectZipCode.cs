
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

namespace ERP.Presentacion.Clientes
{
    public partial class SelectZipCode : Form
    {

        private Customer customer;
        private String codCiudadFIlaSeleccionada { get; set; }
        public String codZipCodeFIlaSeleccionada { get; set; }

        public SelectZipCode()
        {
            customer = new Customer();
            InitializeComponent();
            cargarDatos();
        }

        private void cargarDatos()
        {
            cmbState.Enabled = false;
            cmbCities.Enabled = false;
            cmbZipCode.Enabled = false;
            customer.gestorCliente.refrescarRegions(cmbRegion);


            btnChooseCode.BackColor = Color.Black;
            btnChooseCode.ForeColor = Color.White;
            btnChooseCode.FlatStyle = FlatStyle.Flat;
            btnChooseCode.FlatAppearance.BorderColor = Color.Black;
            btnChooseCode.FlatAppearance.BorderSize = 1;

            btnClose.BackColor = Color.Black;
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderColor = Color.Black;
            btnClose.FlatAppearance.BorderSize = 1;

            btnChooseCode.Enabled = false;
            btnChooseCode.BackColor = Color.Transparent;
            btnChooseCode.ForeColor = Color.Black;
        }

        private void btnChooseCode_Click(object sender, EventArgs e)
        {
            this.codZipCodeFIlaSeleccionada = cmbZipCode.SelectedItem.ToString();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbState.SelectedItem.Equals("Nothing"))
            {
                cmbCities.Enabled = false;
            } else
            {
                customer.state = cmbState.SelectedItem.ToString();
                cmbCities.Enabled = true;
                customer.gestorCliente.refrescarCities(cmbCities, customer);
            }
        }

        /*public void cargarTablaCities()
        {
            dgvCities.Columns.Clear();

            DataTable tCities = customer.gestorCliente.tablaCities;
            dgvCities.Columns.Clear();

            dgvCities.Columns.Add("NAME", "CITY");

            foreach (DataRow row in tCities.Rows)
            {
                dgvCities.Rows.Add(row["NAME"]);
            }
            //dgvUsers.ColumnHeadersVisible = false;
            dgvCities.RowHeadersVisible = false;
            dgvCities.AllowUserToAddRows = false;
            dgvCities.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCities.BackgroundColor = Color.Black;

            ////Colores de Header (no va nose porque)
            //dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(114, 47, 55);
            //dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //No editable
            dgvCities.ReadOnly = true;
            dgvCities.Rows[dgvCities.Rows[0].Index].Selected = true;
            dgvCities.CurrentCell = dgvCities.Rows[dgvCities.Rows[0].Index].Cells[0];
            codCiudadFIlaSeleccionada = dgvCities.Rows[dgvCities.SelectedRows[0].Index].Cells[0].Value.ToString();
        }

        public void cargarTablaZipCodes()
        {
            dgvZipCode.Columns.Clear();

            DataTable tZipCode = customer.gestorCliente.tablaZipCode;
            dgvZipCode.Columns.Clear();

            dgvZipCode.Columns.Add("CODE", "ZIP-CODE");

            foreach (DataRow row in tZipCode.Rows)
            {
                dgvZipCode.Rows.Add(row["CODE"]);
            }
            //dgvUsers.ColumnHeadersVisible = false;
            dgvZipCode.RowHeadersVisible = false;
            dgvZipCode.AllowUserToAddRows = false;
            dgvZipCode.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvZipCode.BackgroundColor = Color.Black;

            ////Colores de Header (no va nose porque)
            //dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(114, 47, 55);
            //dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //No editable
            dgvZipCode.ReadOnly = true;
            //dgvZipCode.Rows[dgvCities.Rows[0].Index].Selected = true;
            //dgvZipCode.CurrentCell = dgvCities.Rows[dgvCities.Rows[0].Index].Cells[0];
            //codCiudadFIlaSeleccionada = dgvCities.Rows[dgvCities.SelectedRows[0].Index].Cells[1].Value.ToString();
            //codCiudadFIlaSeleccionada = dgvCities.Rows[dgvCities.SelectedRows[0].Index].Cells[0].Value.ToString();
            //codZipCodeFIlaSeleccionada = dgvZipCode.Rows[dgvZipCode.SelectedRows[0].Index].Cells[1].Value.ToString();
        }*/

        private void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(cmbState.SelectedItem != null)
            //{
                if (cmbRegion.SelectedItem.Equals("Nothing"))
                {
                    cmbState.Enabled = false;
                }
                else
                {
                    customer.region = cmbRegion.SelectedItem.ToString();
                    cmbState.Enabled = true;
                    customer.gestorCliente.refrescarState(cmbState, customer);//(cmbState, cmbRegion.SelectedItem.ToString());
                }
            //}

        }

        private void style_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Black;
            ((Button)sender).ForeColor = Color.White;
        }

        private void style_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Black;
            ((Button)sender).ForeColor = Color.White;
        }

        private void cmbCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCities.SelectedItem.Equals("Nothing"))
            {
                cmbZipCode.Enabled = false;
            }
            else
            {
                customer.city = cmbCities.SelectedItem.ToString();
                cmbZipCode.Enabled = true;
                customer.gestorCliente.refrescarZipCode(cmbZipCode, customer);//(cmbState, cmbRegion.SelectedItem.ToString());
            }
        }

        private void cmbZipCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbZipCode.SelectedItem.Equals("Nothing"))
            {
                btnChooseCode.Enabled = false;
                btnChooseCode.BackColor = Color.Transparent;
                btnChooseCode.ForeColor = Color.Black;
            }
            else
            {
                btnChooseCode.Enabled = true;
                btnChooseCode.BackColor = Color.Black;
                btnChooseCode.ForeColor = Color.White;
            }
        }
    }
}
