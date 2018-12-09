using ERP.Dominio;
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
    public partial class EditarUsuario : Form
    {
        private Role rol;
        private Role Totalrol;
        private User user;
        private bool cambiarPass=false;
        private String nombreRol;
        public EditarUsuario(String nameU,String nameR)
        {
            Totalrol = new Role();
            

            InitializeComponent();
            Totalrol.gestorRol.refrescarRoles(cmbRoles);
            Totalrol.gestorRol.seleccionarRoles(cmbRoles,"ADMIN");

            nombreRol = nameR;
            tbxUsername.Text = nameU;
            

            rol = new Role(cmbRoles.SelectedItem.ToString());
            cargarComponentes();
            rol.gestorRol.seleccionarRoles(cmbRoles, nameR);
            user = new User(tbxUsername.Text, tbxPassword.Text, rol, 0);

            panel1.BringToFront();
        }

        public void cargarComponentes()
        {

            btnEditRole.BackColor = Color.Black;
            btnEditRole.ForeColor = Color.White;
            btnEditRole.FlatStyle = FlatStyle.Flat;
            btnEditRole.FlatAppearance.BorderColor = Color.Black;
            btnEditRole.FlatAppearance.BorderSize = 1;

            btnSave.BackColor = Color.Black;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderColor = Color.Black;
            btnSave.FlatAppearance.BorderSize = 1;

            btnCancel.BackColor = Color.Black;
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = Color.Black;
            btnCancel.FlatAppearance.BorderSize = 1;

            rol.gestorRol.refrescarRoles(cmbRoles);
            cmbRoles.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void tbxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEditRole_MouseEnter(object sender, EventArgs e)
        {
            btnEditRole.BackColor = Color.White;
            btnEditRole.ForeColor = Color.Black;
        }

        private void btnEditRole_MouseLeave(object sender, EventArgs e)
        {
            btnEditRole.BackColor = Color.Black;
            btnEditRole.ForeColor = Color.White;
        }
        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.White;
            btnSave.ForeColor = Color.Black;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.Black;
            btnSave.ForeColor = Color.White;
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

        private void lblPassword_MouseEnter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxEditPass.CheckState == CheckState.Checked)
            {
                panel1.Hide();
                cambiarPass = true;
            } else
            {
                panel1.Show();
                cambiarPass = false;
            }
        }

        private void btnEditRole_Click(object sender, EventArgs e)
        {
            EditarRol editRol = new EditarRol();
            editRol.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(cambiarPass == true)
            {
                if (Dominio.Util.Validations.validateUser(tbxPassword.Text))
                {
                    user.password = tbxPassword.Text;
                    user.gestorusuario.modificarUsuario(user);
                    ERP.Persistencia.Logs.write("User " + tbxUsername.Text + " updated");
                    this.Dispose();
                }
                else
                {
                    VentanaPersonalizada vp = new VentanaPersonalizada("Has introducido caracteres invalidos en la password");
                    vp.ShowDialog();
                }
                
            }
            else
            {
                rol = new Role(cmbRoles.SelectedItem.ToString());
                user = new User(tbxUsername.Text, "", rol, 0);
                user.gestorusuario.modificarUsuario(user);
                this.Dispose();
            }
        }
    }
}
