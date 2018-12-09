using ERP.Dominio;
using ERP.Dominio.Gestores;
using ERP.Dominio.Util;
using ERP.Presentacion;
using ERP.Presentacion.ErroresCambios;
using ERP.Recursos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP
{
    public partial class FormLogin : Form
    {
        User usuario;
        public String nombreUsuario="";
        TabControl tbMenuP;


        public FormLogin(TabControl tbcMenu)
        {
            usuario = new User();
            this.nombreUsuario = usuario.name;
            this.tbMenuP = tbcMenu;

            InitializeComponent();
            cargarComponentes();

            FormCargaInicial cargaInicial = new FormCargaInicial();
            cargaInicial.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            usuario.name = tbxUser.Text;
            String pass = Encryptor.MD5Hash(tbxPassword.Text);
            //usuario.password = tbxPassword.Text;
            usuario.password = pass;

            String passDB = usuario.gestorusuario.loguearse(usuario);

            if (!passDB.Equals("-1"))
            {
                //MessageBox.Show("Login Succesful");
                //this.Dispose();
                usuario.gestorusuario.comprobarPermisos(usuario, this.tbMenuP);
                this.Hide();
                tbMenuP.SelectedIndex = 0;
                this.nombreUsuario = usuario.name;
            }
            else
            {
                VentanaPersonalizada vp = new VentanaPersonalizada("Error, user or password not valid");
                vp.ShowDialog();
            }
            //----------------------------

            //    String user = tbxUser.Text;
            ////String pass = Encryptor.MD5Hash(tbxContraseña.Text);
            //String pass = tbxPassword.Text;
            //String condicion = " NAME = '" + user + "' AND PASSWORD = '" + pass + "'";

            ////String passDB = Convert.ToString(conector.DLookUp("IDUSER", "USERS", condicion));

            //    if (user.Equals("Diego"))
            //    {
            //        //MessageBox.Show("Login Succesful");
            //        //this.Dispose();
            //        this.Hide();
            //   }
            //    else
            //    {
            //        MessageBox.Show("ERROR");
            //    }
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void cargarComponentes()
        {
            //Color rojo oscuso --> Color.FromArgb(114, 47, 55);

            //Login
            btnConfirm.BackColor = Color.Black;
            btnConfirm.ForeColor = Color.White;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.FlatAppearance.BorderColor = Color.Black;
            btnConfirm.FlatAppearance.BorderSize = 1;

            btnCancel.BackColor = Color.Black;
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = Color.Black;
            btnCancel.FlatAppearance.BorderSize = 1;

            this.cmbLanguage.SelectedIndex = 0;

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
        private void aplicarIdioma()
        {
            this.btnCancel.Text = StringResources.Cancel;
            this.btnConfirm.Text = StringResources.Confirm;
            this.lblUser.Text = StringResources.User;
            this.lblPassword.Text = StringResources.Password;
            this.lblLanguage.Text = StringResources.Languaje;

        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLanguage.SelectedIndex == 0)
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new
                CultureInfo("EN-US");
                aplicarIdioma();
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new
                CultureInfo("ES-ES");
                aplicarIdioma();
            }
        }
    }
}
