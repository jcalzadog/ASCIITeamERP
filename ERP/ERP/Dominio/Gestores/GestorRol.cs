using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Dominio.Gestores
{
    class GestorRol
    {
        ConnectOracle conector;
        LinkedList<Object> listaPermits;

        public GestorRol()
        {
            conector = new ConnectOracle();
            listaPermits = new LinkedList<Object>();
        }

        public void refrescarRoles(ComboBox cmbRoles)
        {
            Decimal numRoles = (Decimal)conector.DLookUp("MAX(IDROLE)", "ROLES", "");
            //int numRoles = int.Parse(numR);

            for(int i = 1; i <= numRoles; i++)
            {
                listaPermits.AddLast(conector.DLookUp("NAME", "ROLES", " IDROLE="+i));
            }

            cmbRoles.Items.Clear();
            int cont = 0;
            while (cont < listaPermits.Count)
            {
                cmbRoles.Items.Add(listaPermits.ElementAt(cont));
                cont++;
            }
        }

        public void cargarTablaPermisos(DataGridView dgvPermissions, String Role)
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

            int columnaCheck = 0;
            foreach (DataRow row in tPerm.Rows)
            {
                dgvPermissions.Rows.Add(row["NAME"]);

                //SI TIENE PERMISO SE PONE CHECKED
                //SELECT COUNT(R.IDROLE) FROM ROLES R INNER JOIN ROL_PERM A ON R.IDROLE=A.IDROLE INNER JOIN PERMITS P ON A.IDPERMIT=P.IDPERMIT WHERE P.IDPERMIT=1 AND R.NAME='ADMIN';
                Decimal tienePermiso=0;
                if (!Role.Equals(""))
                {
                    tienePermiso = (Decimal)conector.DLookUp("COUNT(R.IDROLE)", "ROLES R INNER JOIN ROL_PERM A ON R.IDROLE=A.IDROLE INNER JOIN PERMITS P ON A.IDPERMIT=P.IDPERMIT", "P.IDPERMIT=" + (columnaCheck + 1) + " AND R.NAME='" + Role + "'");
                }
                
                if(tienePermiso == 1)
                {
                    //Pone checked
                    dgvPermissions.Rows[columnaCheck].Cells[1].Value = true;
                }
                
                columnaCheck++;
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
            dgvPermissions.Columns["NAME"].ReadOnly = true;
        }

        public void refrescarTablaPermisos(DataGridView dgvPermissions,String Role)
        {
            int columnaCheck = 0;
            foreach (DataGridViewRow row in dgvPermissions.Rows)
            {
                //SI TIENE PERMISO SE PONE CHECKED
                //SELECT COUNT(R.IDROLE) FROM ROLES R INNER JOIN ROL_PERM A ON R.IDROLE=A.IDROLE INNER JOIN PERMITS P ON A.IDPERMIT=P.IDPERMIT WHERE P.IDPERMIT=1 AND R.NAME='ADMIN';
                Decimal tienePermiso = 0;
                if (!Role.Equals(""))
                {
                    tienePermiso = (Decimal)conector.DLookUp("COUNT(R.IDROLE)", "ROLES R INNER JOIN ROL_PERM A ON R.IDROLE=A.IDROLE INNER JOIN PERMITS P ON A.IDPERMIT=P.IDPERMIT", "P.IDPERMIT=" + (columnaCheck + 1) + " AND R.NAME='" + Role + "'");
                }

                if (tienePermiso == 1)
                {
                    //Pone checked
                    dgvPermissions.Rows[columnaCheck].Cells[1].Value = true;
                } else
                {
                    dgvPermissions.Rows[columnaCheck].Cells[1].Value = false;
                }

                columnaCheck++;
            }
        }
    }
}
