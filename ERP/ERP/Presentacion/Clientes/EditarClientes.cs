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
    public partial class EditarClientes : Form
    {

        public String dniFilaSeleccionadaClientes = "";
        public String nameFilaSellecionadaClientes = "";
        public String surnameFilaSeleccionadaClientes = "";
        public String addressFilaSellecionadaClientes = "";
        public String phoneFilaSeleccionadaClientes = "";
        public String emailFilaSellecionadaClientes = "";
        public String cityFilaSeleccionadaClientes = "";
        public EditarClientes(String dni,String name, String surname, String address, String phone, String email, String city)
        {
            InitializeComponent();
            dniFilaSeleccionadaClientes = dni;
            nameFilaSellecionadaClientes = name;
            surnameFilaSeleccionadaClientes = surname;
            addressFilaSellecionadaClientes = address;
            phoneFilaSeleccionadaClientes = phone;
            emailFilaSellecionadaClientes = email;
            cityFilaSeleccionadaClientes = city;

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

            btnConfirm.BackColor = Color.Black;
            btnConfirm.ForeColor = Color.White;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.FlatAppearance.BorderColor = Color.Black;
            btnConfirm.FlatAppearance.BorderSize = 1;

            btnSelectZipCode.BackColor = Color.Black;
            btnSelectZipCode.ForeColor = Color.White;
            btnSelectZipCode.FlatStyle = FlatStyle.Flat;
            btnSelectZipCode.FlatAppearance.BorderColor = Color.Black;
            btnSelectZipCode.FlatAppearance.BorderSize = 1;

            tbxDNI.Text = this.dniFilaSeleccionadaClientes;
            tbxName.Text = this.nameFilaSellecionadaClientes;
            tbxSurname.Text = this.surnameFilaSeleccionadaClientes;
            tbxAddress.Text = this.addressFilaSellecionadaClientes;
            tbxPhone.Text = this.phoneFilaSeleccionadaClientes;
            tbxEmail.Text = this.emailFilaSellecionadaClientes;
            tbxZipCode.Text = this.cityFilaSeleccionadaClientes;
        }

        private void EditarClientes_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {

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

        private void btnConfirm_MouseEnter(object sender, EventArgs e)
        {
            btnConfirm.BackColor = Color.White;
            btnConfirm.ForeColor = Color.Black;
        }

        private void btnConfirm_MouseLeave(object sender, EventArgs e)
        {
            btnConfirm.BackColor = Color.Black;
            btnConfirm.ForeColor = Color.White;
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
    }
}
