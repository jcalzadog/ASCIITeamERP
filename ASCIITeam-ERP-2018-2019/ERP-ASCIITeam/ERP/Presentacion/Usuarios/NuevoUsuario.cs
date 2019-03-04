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

namespace ERP.Presentacion.Usuarios
{
    public partial class NuevoUsuario : Form
    {

        Role rol;
        User usuario;
        public NuevoUsuario()
        {

            rol = new Role();
            usuario = new User();

            InitializeComponent();
            cargarComponentes();


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSaveAnother_Click(object sender, EventArgs e)
        {
            Role rol = new Role(cmbRoles.SelectedItem.ToString());
            if (Dominio.Util.Validations.validateUser(tbxUsername.Text))
            {
                if (Dominio.Util.Validations.validateUser(tbxPassword.Text))
                {

                    User user = new User(tbxUsername.Text, tbxPassword.Text, rol, 0);
                    Boolean creado = user.gestorusuario.nuevoUsuario(user);
                    if (creado)
                    {
                        ERP.Persistencia.Logs.write("User " + tbxUsername.Text + " created");
                        tbxUsername.Text = "";
                        tbxPassword.Text = "";
                        cmbRoles.SelectedIndex = 0;
                    }
                }
                else
                {
                    VentanaPersonalizada vp = new VentanaPersonalizada("Has introducido caracteres invalidos en la password");
                    vp.ShowDialog();
                }
            }
            else
            {
                VentanaPersonalizada vp = new VentanaPersonalizada("Has introducido caracteres invalidos en el user");
                vp.ShowDialog();
            }
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            Role rol = new Role(cmbRoles.SelectedItem.ToString());
            if (Dominio.Util.Validations.validateUser(tbxUsername.Text))
            {
                if (Dominio.Util.Validations.validateUser(tbxPassword.Text))
                {

                    User user = new User(tbxUsername.Text, tbxPassword.Text, rol, 0);
                    Boolean creado = user.gestorusuario.nuevoUsuario(user);
                    if (creado)
                    {
                        ERP.Persistencia.Logs.write("User " + tbxUsername.Text + " created");
                        this.Dispose();
                    }
                }
                else
                {
                    VentanaPersonalizada vp = new VentanaPersonalizada("Has introducido caracteres invalidos en la password");
                    vp.ShowDialog();
                }
            }
            else
            {
                VentanaPersonalizada vp = new VentanaPersonalizada("Has introducido caracteres invalidos en el user");
                vp.ShowDialog();
            }

            
        }

        private void btnNewRole_Click(object sender, EventArgs e)
        {
            NuevoRol newRol = new NuevoRol();
            newRol.ShowDialog();
        }

        public void cargarComponentes()
        {

            btnEditRole.BackColor = Color.Black;
            btnEditRole.ForeColor = Color.White;
            btnEditRole.FlatStyle = FlatStyle.Flat;
            btnEditRole.FlatAppearance.BorderColor = Color.Black;
            btnEditRole.FlatAppearance.BorderSize = 1;

            btnSaveClose.BackColor = Color.Black;
            btnSaveClose.ForeColor = Color.White;
            btnSaveClose.FlatStyle = FlatStyle.Flat;
            btnSaveClose.FlatAppearance.BorderColor = Color.Black;
            btnSaveClose.FlatAppearance.BorderSize = 1;

            btnSaveAnother.BackColor = Color.Black;
            btnSaveAnother.ForeColor = Color.White;
            btnSaveAnother.FlatStyle = FlatStyle.Flat;
            btnSaveAnother.FlatAppearance.BorderColor = Color.Black;
            btnSaveAnother.FlatAppearance.BorderSize = 1;

            btnCancel.BackColor = Color.Black;
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = Color.Black;
            btnCancel.FlatAppearance.BorderSize = 1;

            rol.gestorRol.refrescarRoles(cmbRoles);
            cmbRoles.SelectedIndex = 0;
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

        private void btnEditRole_Click(object sender, EventArgs e)
        {
            EditarRol editRol = new EditarRol();
            editRol.ShowDialog();
        }
    }
}
