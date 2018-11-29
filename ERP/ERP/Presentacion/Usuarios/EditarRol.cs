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
        ConnectOracle conector;
        private GestorRol gestorR;

        public EditarRol()
        {
            gestorR = new GestorRol();
            conector = new ConnectOracle();
            InitializeComponent();
            cargarComponentes();

            gestorR.cargarTablaPermisos(dgvPermissions, cmbRoles.SelectedItem.ToString());
        }

        private void dgvPermissions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblRole_Click(object sender, EventArgs e)
        {

        }

        private void lblPermissions_Click(object sender, EventArgs e)
        {

        }

        private void EditarRol_Load(object sender, EventArgs e)
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
        }

        public void cargarTablaPermisos()
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
        }

        public void cargarComponentes()
        {

            btnAllow.BackColor = Color.FromArgb(114, 47, 55);
            btnAllow.ForeColor = Color.White;
            btnAllow.FlatStyle = FlatStyle.Flat;
            btnAllow.FlatAppearance.BorderColor = Color.Black;
            btnAllow.FlatAppearance.BorderSize = 1;

            btnNewRole.BackColor = Color.FromArgb(114, 47, 55);
            btnNewRole.ForeColor = Color.White;
            btnNewRole.FlatStyle = FlatStyle.Flat;
            btnNewRole.FlatAppearance.BorderColor = Color.Black;
            btnNewRole.FlatAppearance.BorderSize = 1;

            btnDeny.BackColor = Color.FromArgb(114, 47, 55);
            btnDeny.ForeColor = Color.White;
            btnDeny.FlatStyle = FlatStyle.Flat;
            btnDeny.FlatAppearance.BorderColor = Color.Black;
            btnDeny.FlatAppearance.BorderSize = 1;

            btnCancel.BackColor = Color.FromArgb(114, 47, 55);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = Color.Black;
            btnCancel.FlatAppearance.BorderSize = 1;

            btnSave.BackColor = Color.FromArgb(114, 47, 55);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderColor = Color.Black;
            btnSave.FlatAppearance.BorderSize = 1;

            gestorR.refrescarRoles(cmbRoles);
            cmbRoles.SelectedIndex = 0;
        }
        private void btnAllow_MouseEnter(object sender, EventArgs e)
        {
            btnAllow.BackColor = Color.White;
            btnAllow.ForeColor = Color.Black;
        }

        private void btnAllow_MouseLeave(object sender, EventArgs e)
        {
            btnAllow.BackColor = Color.FromArgb(114, 47, 55);
            btnAllow.ForeColor = Color.White;
        }

        private void btnDeny_MouseEnter(object sender, EventArgs e)
        {
            btnDeny.BackColor = Color.White;
            btnDeny.ForeColor = Color.Black;
        }

        private void btnDeny_MouseLeave(object sender, EventArgs e)
        {
            btnDeny.BackColor = Color.FromArgb(114, 47, 55);
            btnDeny.ForeColor = Color.White;
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.White;
            btnSave.ForeColor = Color.Black;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.FromArgb(114, 47, 55);
            btnSave.ForeColor = Color.White;
        }

        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.White;
            btnCancel.ForeColor = Color.Black;
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.FromArgb(114, 47, 55);
            btnCancel.ForeColor = Color.White;
        }

        private void btnNewRole_MouseEnter(object sender, EventArgs e)
        {
            btnNewRole.BackColor = Color.White;
            btnNewRole.ForeColor = Color.Black;
        }

        private void btnNewRole_MouseLeave(object sender, EventArgs e)
        {
            btnNewRole.BackColor = Color.FromArgb(114, 47, 55);
            btnNewRole.ForeColor = Color.White;
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            //gestorR.cargarTablaPermisos(dgvPermissions, cmbRoles.SelectedItem.ToString());
        }
    }
}
