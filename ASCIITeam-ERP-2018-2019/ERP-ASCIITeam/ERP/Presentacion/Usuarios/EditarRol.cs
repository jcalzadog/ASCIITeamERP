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
    public partial class EditarRol : Form
    {
        private Role rol;

        public EditarRol()
        {
            rol = new Role();
            InitializeComponent();
            cargarComponentes();

            rol.nameRol = cmbRoles.SelectedItem.ToString();
            rol.gestorRol.cargarTablaPermisos(dgvPermissions, rol);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnNewRole_Click(object sender, EventArgs e)
        {
            NuevoRol newRol = new NuevoRol();
            newRol.ShowDialog();
            rol.gestorRol.refrescarRoles(cmbRoles);
            cmbRoles.SelectedIndex = 0;
        }

        /*public void cargarTablaPermisos()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();
            //SELECT U.NAME,R.NAME FROM USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE;
            //data = Search.getData("SELECT * FROM PERMITS ORDER BY IDPERMIT", "PERMITS
            //data = Search.getData("SELECT U.NAME NAME,R.NAME ROLE FROM USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE", "USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE");
            data = Search.getData("SELECT NAME FROM PERMITS", "PERMITS");

            //USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE
            DataTable tPerm = data.Tables["PERMITS"];
            DataGridViewCheckBoxColumn dgvColumnCheck = new DataGridViewCheckBoxColumn();

            //dgvCustomers.DataSource = tcustomers;

            dgvPermissions.Columns.Add("NAME", "NAME");
            dgvPermissions.Columns.Add(dgvColumnCheck);  // ---- PARA CHECBOX https://social.msdn.microsoft.com/Forums/es-ES/5e1770fc-10b3-4400-b895-a20192e28c34/como-agregar-un-checkbox-en-un-datagridview-en-vbnet?forum=vbes

            foreach (DataRow row in tPerm.Rows)
            {
                dgvPermissions.Rows.Add(row["NAME"]);
            }
            //dgvUsers.ColumnHeadersVisible = false;
            dgvPermissions.RowHeadersVisible = false;

            dgvPermissions.AllowUserToAddRows = false;
            dgvPermissions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPermissions.BackgroundColor = Color.FromArgb(114, 47, 55);

            ////Colores de Header (no va nose porque)
            //dgvPermissions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(114, 47, 55);
            //dgvPermissions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //No editable
            dgvPermissions.ReadOnly = true;
        }*/

        public void cargarComponentes()
        {

            btnAllow.BackColor = Color.Black;
            btnAllow.ForeColor = Color.White;
            btnAllow.FlatStyle = FlatStyle.Flat;
            btnAllow.FlatAppearance.BorderColor = Color.Black;
            btnAllow.FlatAppearance.BorderSize = 1;

            btnNewRole.BackColor = Color.Black;
            btnNewRole.ForeColor = Color.White;
            btnNewRole.FlatStyle = FlatStyle.Flat;
            btnNewRole.FlatAppearance.BorderColor = Color.Black;
            btnNewRole.FlatAppearance.BorderSize = 1;

            btnDeny.BackColor = Color.Black;
            btnDeny.ForeColor = Color.White;
            btnDeny.FlatStyle = FlatStyle.Flat;
            btnDeny.FlatAppearance.BorderColor = Color.Black;
            btnDeny.FlatAppearance.BorderSize = 1;

            btnClose.BackColor = Color.Black;
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderColor = Color.Black;
            btnClose.FlatAppearance.BorderSize = 1;

            btnSave.BackColor = Color.Black;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderColor = Color.Black;
            btnSave.FlatAppearance.BorderSize = 1;

            btnDeleteRol.BackColor = Color.Black;
            btnDeleteRol.ForeColor = Color.White;
            btnDeleteRol.FlatStyle = FlatStyle.Flat;
            btnDeleteRol.FlatAppearance.BorderColor = Color.Black;
            btnDeleteRol.FlatAppearance.BorderSize = 1;

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

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dgvPermissions = new DataGridView();
            rol.nameRol = cmbRoles.SelectedItem.ToString();
            rol.gestorRol.refrescarTablaPermisos(dgvPermissions, rol);
        }

        private void btnAllow_Click_1(object sender, EventArgs e)
        {
            int columnaCheck = 0;
            foreach (DataGridViewRow row in dgvPermissions.Rows)
            {
                dgvPermissions.Rows[columnaCheck].Cells[1].Value = true;
                columnaCheck++;
            }
        }

        private void btnDeny_Click_1(object sender, EventArgs e)
        {
            int columnaCheck = 0;
            foreach (DataGridViewRow row in dgvPermissions.Rows)
            {
                dgvPermissions.Rows[columnaCheck].Cells[1].Value = false;
                columnaCheck++;
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            rol.nameRol = cmbRoles.SelectedItem.ToString();
            rol.gestorRol.modificarRol(dgvPermissions, rol);
            ERP.Persistencia.Logs.write("Role " + cmbRoles.SelectedItem.ToString() + " updated");
        }

        private void btnDeleteRol_Click(object sender, EventArgs e)
        {
            String nameRol = cmbRoles.SelectedItem.ToString();
            bool existeUserConRol = rol.gestorRol.comprobarRolUtilizado(nameRol);
            if (existeUserConRol)
            {
                String mensaje = "The role has been used with a User.";
                VentanaPersonalizada aviso = new VentanaPersonalizada(mensaje);
                aviso.ShowDialog();
            } else
            {
                ConfirmarBorrarRol confirmDeletedRole = new ConfirmarBorrarRol(nameRol);
                confirmDeletedRole.ShowDialog();
                rol.gestorRol.refrescarRoles(cmbRoles);
                cmbRoles.SelectedIndex = 0;
            }
            
        }

    }
}

