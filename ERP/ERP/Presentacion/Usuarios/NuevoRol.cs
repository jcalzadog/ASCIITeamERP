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
    public partial class NuevoRol : Form
    {
        public NuevoRol()
        {
            InitializeComponent();
            cargarComponentes();
            cargarTablaPermisos();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void cargarComponentes()
        {
            btnAllow.FlatStyle = FlatStyle.Flat;
            btnAllow.FlatAppearance.BorderColor = Color.Black;
            btnAllow.FlatAppearance.BorderSize = 1;

            btnDeny.FlatStyle = FlatStyle.Flat;
            btnDeny.FlatAppearance.BorderColor = Color.Black;
            btnDeny.FlatAppearance.BorderSize = 1;

            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = Color.Black;
            btnCancel.FlatAppearance.BorderSize = 1;

            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderColor = Color.Black;
            btnSave.FlatAppearance.BorderSize = 1;
        }

        public void cargarTablaPermisos()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();
            //SELECT U.NAME,R.NAME FROM USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE;
            data = Search.getData("SELECT * FROM PERMITS ORDER BY IDPERMIT", "PERMITS");

            DataTable tPerm = data.Tables["PERMITS"];

            //dgvCustomers.DataSource = tcustomers;

            dgvPermissions.Columns.Add("IDPERMIT", "ID");
            dgvPermissions.Columns.Add("NAME", "NAME");


            foreach (DataRow row in tPerm.Rows)
            {
                dgvPermissions.Rows.Add(row["IDPERMIT"], row["NAME"]);
            }
            //dgvUsers.ColumnHeadersVisible = false;
            dgvPermissions.RowHeadersVisible = false;
            dgvPermissions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
