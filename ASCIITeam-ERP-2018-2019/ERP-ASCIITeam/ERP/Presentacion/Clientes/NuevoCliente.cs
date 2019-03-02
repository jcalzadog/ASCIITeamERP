using ERP.Dominio;
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSelectZipCode_Click(object sender, EventArgs e)
        {
            SelectZipCode zipCode = new SelectZipCode();
            zipCode.ShowDialog();
            tbxZipCode.Text = zipCode.codZipCodeFIlaSeleccionada;
            zipCode.Dispose();
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
            if (Dominio.Util.Validations.validateDNI(tbxDNI.Text) && !customer.gestorCliente.validarDNIrepetidoNuevoUser(tbxDNI.Text))
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
                                        customer.dni = tbxDNI.Text;
                                        customer.name = tbxName.Text;
                                        customer.surname = tbxSurname.Text;
                                        customer.address = tbxAddress.Text;
                                        customer.phone = Int32.Parse(tbxPhone.Text);
                                        customer.email = tbxEmail.Text;
                                        customer.refzipcodescities = Int32.Parse(tbxZipCode.Text);

                                        Boolean creado = customer.gestorCliente.nuevoCliente(customer);
                                        if (creado)
                                        {
                                            ERP.Persistencia.Logs.write("Customer " + tbxDNI.Text + " created");
                                            this.Dispose();
                                        }
                                }
                                else
                                {
                                    VentanaPersonalizada vp = new VentanaPersonalizada("Has introducido caracteres invalidos en el ZipCode");
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
            else
            {
                VentanaPersonalizada vp = new VentanaPersonalizada("Has introducido caracteres invalidos en el DNI");
                vp.ShowDialog();
            }
        }

        private void btnSaveAnother_Click(object sender, EventArgs e)
        {
            if (Dominio.Util.Validations.validateDNI(tbxDNI.Text) && !customer.gestorCliente.validarDNIrepetidoNuevoUser(tbxDNI.Text))
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
                       

                                        customer.dni = tbxDNI.Text;
                                        customer.name = tbxName.Text;
                                        customer.surname = tbxSurname.Text;
                                        customer.address = tbxAddress.Text;
                                        customer.phone = Int32.Parse(tbxPhone.Text);
                                        customer.email = tbxEmail.Text;
                                        customer.refzipcodescities = Int32.Parse(tbxZipCode.Text);
                                        Boolean creado = customer.gestorCliente.nuevoCliente(customer);//(tbxDNI.Text, tbxName.Text, tbxSurname.Text, tbxAddress.Text, Int32.Parse(tbxPhone.Text), tbxEmail.Text, tbxZipCode.Text);
                                    if (creado)
                                    {
                                        ERP.Persistencia.Logs.write("Customer " + tbxDNI.Text + " created");
                                        tbxDNI.Text = "";
                                        tbxName.Text = "";
                                        tbxSurname.Text = "";
                                        tbxAddress.Text = "";
                                        tbxEmail.Text = "";
                                        tbxPhone.Text = "";
                                        tbxZipCode.Text = "";
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
            else
            {
                VentanaPersonalizada vp = new VentanaPersonalizada("Has introducido caracteres invalidos en el DNI");
                vp.ShowDialog();
            }
        }
    }
}
