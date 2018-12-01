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

            rol.gestorRol.cargarTablaPermisos(dgvPermissions, cmbRoles.SelectedItem.ToString());
        }

        private void dgvPermissions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAllow_Click(object sender, EventArgs e)
        {

        }

        private void btnDeny_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

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
        private void btnAllow_MouseEnter(object sender, EventArgs e)
        {
            btnAllow.BackColor = Color.White;
            btnAllow.ForeColor = Color.Black;
        }

        private void btnAllow_MouseLeave(object sender, EventArgs e)
        {
            btnAllow.BackColor = Color.Black;
            btnAllow.ForeColor = Color.White;
        }

        private void btnDeny_MouseEnter(object sender, EventArgs e)
        {
            btnDeny.BackColor = Color.White;
            btnDeny.ForeColor = Color.Black;
        }

        private void btnDeny_MouseLeave(object sender, EventArgs e)
        {
            btnDeny.BackColor = Color.Black;
            btnDeny.ForeColor = Color.White;
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
            btnClose.BackColor = Color.White;
            btnClose.ForeColor = Color.Black;
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.Black;
            btnClose.ForeColor = Color.White;
        }

        private void btnNewRole_MouseEnter(object sender, EventArgs e)
        {
            btnNewRole.BackColor = Color.White;
            btnNewRole.ForeColor = Color.Black;
        }

        private void btnNewRole_MouseLeave(object sender, EventArgs e)
        {
            btnNewRole.BackColor = Color.Black;
            btnNewRole.ForeColor = Color.White;
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dgvPermissions = new DataGridView();
            rol.gestorRol.refrescarTablaPermisos(dgvPermissions, cmbRoles.SelectedItem.ToString());
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
            rol.gestorRol.modificarRol(dgvPermissions, cmbRoles.SelectedItem.ToString());
        }

        private void btnDeleteRol_Click(object sender, EventArgs e)
        {
            String nameRol = cmbRoles.SelectedItem.ToString();
            ConfirmarBorrarRol confirmDeletedRole = new ConfirmarBorrarRol(nameRol);
            confirmDeletedRole.ShowDialog();
            rol.gestorRol.refrescarRoles(cmbRoles);
            cmbRoles.SelectedIndex = 0;
        }

        private void btnDeleteRol_MouseEnter(object sender, EventArgs e)
        { 
            btnDeleteRol.BackColor = Color.White;
            btnDeleteRol.ForeColor = Color.Black;
        }
        private void btnDeleteRol_MouseLeave(object sender, EventArgs e)
        {
            btnDeleteRol.BackColor = Color.Black;
            btnDeleteRol.ForeColor = Color.White;
        }
    }
}

