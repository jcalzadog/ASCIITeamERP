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
    public partial class NuevoCliente : Form
    {
        private Customer customer;

        public NuevoCliente()
        {
            customer = new Customer();
            InitializeComponent();
            cargarComponentes();
        }

        private void cargarComponentes()
        {
            btnCancel.BackColor = Color.Black;
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = Color.Black;
            btnCancel.FlatAppearance.BorderSize = 1;

            btnClearAll.BackColor = Color.Black;
            btnClearAll.ForeColor = Color.White;
            btnClearAll.FlatStyle = FlatStyle.Flat;
            btnClearAll.FlatAppearance.BorderColor = Color.Black;
            btnClearAll.FlatAppearance.BorderSize = 1;

            btnSaveAnother.BackColor = Color.Black;
            btnSaveAnother.ForeColor = Color.White;
            btnSaveAnother.FlatStyle = FlatStyle.Flat;
            btnSaveAnother.FlatAppearance.BorderColor = Color.Black;
            btnSaveAnother.FlatAppearance.BorderSize = 1;

            btnSaveClose.BackColor = Color.Black;
            btnSaveClose.ForeColor = Color.White;
            btnSaveClose.FlatStyle = FlatStyle.Flat;
            btnSaveClose.FlatAppearance.BorderColor = Color.Black;
            btnSaveClose.FlatAppearance.BorderSize = 1;

            btnSelectZipCode.BackColor = Color.Black;
            btnSelectZipCode.ForeColor = Color.White;
            btnSelectZipCode.FlatStyle = FlatStyle.Flat;
            btnSelectZipCode.FlatAppearance.BorderColor = Color.Black;
            btnSelectZipCode.FlatAppearance.BorderSize = 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NuevoCliente_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSelectZipCode_Click(object sender, EventArgs e)
        {
            SelectZipCode zipCode = new SelectZipCode();
            zipCode.ShowDialog();
            tbxZipCode.Text = zipCode.codZipCodeFIlaSeleccionada;
            zipCode.Dispose();
        }

        private void btnSelectZipCode_MouseEnter(object sender, EventArgs e)
        {
            btnSelectZipCode.BackColor = Color.White;
            btnSelectZipCode.ForeColor = Color.Black;
        }

        private void btnSelectZipCode_MouseLeave(object sender, EventArgs e)
        {
            btnSelectZipCode.BackColor = Color.Black;
            btnSelectZipCode.ForeColor = Color.White;
        }

        private void btnClearAll_MouseEnter(object sender, EventArgs e)
        {
            btnClearAll.BackColor = Color.White;
            btnClearAll.ForeColor = Color.Black;
        }

        private void btnClearAll_MouseLeave(object sender, EventArgs e)
        {
            btnClearAll.BackColor = Color.Black;
            btnClearAll.ForeColor = Color.White;
        }

        private void btnSaveClose_MouseEnter(object sender, EventArgs e)
        {
            btnSaveClose.BackColor = Color.White;
            btnSaveClose.ForeColor = Color.Black;
        }

        private void btnSaveClose_MouseLeave(object sender, EventArgs e)
        {
            btnSaveClose.BackColor = Color.Black;
            btnSaveClose.ForeColor = Color.White;
        }

        private void btnSaveAnother_MouseEnter(object sender, EventArgs e)
        {
            btnSaveAnother.BackColor = Color.White;
            btnSaveAnother.ForeColor = Color.Black;
        }

        private void btnSaveAnother_MouseLeave(object sender, EventArgs e)
        {
            btnSaveAnother.BackColor = Color.Black;
            btnSaveAnother.ForeColor = Color.White;
        }

        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.White;
            btnCancel.ForeColor = Color.Black;
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.Black;
            btnCancel.ForeColor = Color.White;
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            tbxDNI.Text = "";
            tbxName.Text = "";
            tbxSurname.Text = "";
            tbxAddress.Text = "";
            tbxEmail.Text = "";
            tbxPhone.Text = "";
            tbxZipCode.Text = "";
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            //Boolean creado = usuario.gestorusuario.nuevoUsuario(tbxUsername.Text, tbxPassword.Text, cmbRoles.SelectedItem.ToString());
            Boolean creado = customer.gestorCliente.nuevoCliente(tbxDNI.Text, tbxName.Text, tbxSurname.Text, tbxAddress.Text, Int32.Parse(tbxPhone.Text), tbxEmail.Text, tbxZipCode.Text);
            if (creado)
            {
                this.Dispose();
            }
        }
    }
}
