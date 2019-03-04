using ERP.Dominio.Gestores;
using ERP.Presentacion.ErroresCambios;
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
        public Object cityFilaSeleccionadaClientes = "";

        private Customer c;

        public EditarClientes(String dni,String name, String surname, String address, String phone, String email, String city)
        {
            InitializeComponent();
            c = new Customer();
            dniFilaSeleccionadaClientes = dni;
            nameFilaSellecionadaClientes = name;
            surnameFilaSeleccionadaClientes = surname;
            addressFilaSellecionadaClientes = address;
            phoneFilaSeleccionadaClientes = phone;
            emailFilaSellecionadaClientes = email;



            cityFilaSeleccionadaClientes = c.gestorCliente.sacarZipCode(dniFilaSeleccionadaClientes);
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
            tbxZipCode.Text = this.cityFilaSeleccionadaClientes.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
                if (Dominio.Util.Validations.validateName(tbxName.Text))
                {
                    if (Dominio.Util.Validations.validateName(tbxSurname.Text))
                    {
                        if (Dominio.Util.Validations.validatePhoneorZipcode(tbxPhone.Text))
                        {
                            if (Dominio.Util.Validations.validateEmail(tbxEmail.Text))
                            {
                                if (Dominio.Util.Validations.validatePhoneorZipcode(tbxZipCode.Text))
                                {
                               
                                        int zip = Int32.Parse(tbxZipCode.Text);

                                        Customer clientemod = new Customer(0, this.tbxName.Text, this.tbxDNI.Text, this.tbxSurname.Text, this.tbxAddress.Text, Int32.Parse(this.tbxPhone.Text), this.tbxEmail.Text, c.deleted, zip);

                                        clientemod.gestorCliente.modificarCliente(clientemod, this.dniFilaSeleccionadaClientes);

                                        ERP.Persistencia.Logs.write("Customer " + tbxDNI.Text + " updated");
                                        this.Dispose();
                                }
                                else
                                {
                                    VentanaPersonalizada vp = new VentanaPersonalizada("Has introducido caracteres invalidos en el Phone");
                                    vp.ShowDialog();
                                }
                            }
                            else
                            {
                                VentanaPersonalizada vp = new VentanaPersonalizada("Has introducido caracteres invalidos en el Email");
                                vp.ShowDialog();
                            }
                        }
                        else
                        {
                            VentanaPersonalizada vp = new VentanaPersonalizada("Has introducido caracteres invalidos en el Phone");
                            vp.ShowDialog();
                        }
                    }
                    else
                    {
                        VentanaPersonalizada vp = new VentanaPersonalizada("Has introducido caracteres invalidos en el Surname");
                        vp.ShowDialog();
                    }
                }
                else
                {
                    VentanaPersonalizada vp = new VentanaPersonalizada("Has introducido caracteres invalidos en el Name");
                    vp.ShowDialog();
                }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
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
    }
}
