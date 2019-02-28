using ERP.Presentacion.ErroresCambios;
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

            listaPermits = new LinkedList<Object>();
            for (int i = 1; i <= numRoles; i++)
            {
                if (!conector.DLookUp("NAME", "ROLES", " IDROLE=" + i).ToString().Equals("-1"))
                {
                    listaPermits.AddLast(conector.DLookUp("NAME", "ROLES", " IDROLE=" + i));
                }
            }

            cmbRoles.Items.Clear();
            int cont = 0;
            while (cont < listaPermits.Count)
            {
                cmbRoles.Items.Add(listaPermits.ElementAt(cont));
                cont++;
            }
        }

        public void seleccionarRoles(ComboBox cmbRoles, String nameRol)//(ComboBox cmbRoles,String nameR)
        {
            //Object idUser = conector.DLookUp("IDUSER", "USERS", "NAME='"+nameUser+"'");
            //Object idRol = conector.DLookUp("R.IDROLE", "ROLES R INNER JOIN USERS_ROLES U ON R.IDROLE=U.IDROLE", "U.IDUSER=" + idUser);
            //int numRoles = int.Parse(numR);
            cmbRoles.SelectedItem = nameRol;
        }

        public void cargarTablaPermisos(DataGridView dgvPermissions, Role R)//(DataGridView dgvPermissions, String Role)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();
            //SELECT U.NAME,R.NAME FROM USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE;
            //data = Search.getData("SELECT * FROM PERMITS ORDER BY IDPERMIT", "PERMITS
            //data = Search.getData("SELECT U.NAME NAME,R.NAME ROLE FROM USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE", "USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE");
            data = Search.getData("SELECT NAME FROM PERMITS ORDER BY IDPERMIT", "PERMITS");

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
                if (!R.nameRol.Equals(""))
                {
                    tienePermiso = (Decimal)conector.DLookUp("COUNT(R.IDROLE)", "ROLES R INNER JOIN ROL_PERM A ON R.IDROLE=A.IDROLE INNER JOIN PERMITS P ON A.IDPERMIT=P.IDPERMIT", "P.IDPERMIT=" + (columnaCheck + 1) + " AND R.NAME='" + R.nameRol + "'");
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
            dgvPermissions.BackgroundColor = Color.Black;

            ////Colores de Header (no va nose porque)
            //dgvPermissions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(114, 47, 55);
            //dgvPermissions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //No editable
            dgvPermissions.Columns["NAME"].ReadOnly = true;
        }

        public void refrescarTablaPermisos(DataGridView dgvPermissions, Role R)//(DataGridView dgvPermissions,String Role)
        {
            int columnaCheck = 0;
            foreach (DataGridViewRow row in dgvPermissions.Rows)
            {
                //SI TIENE PERMISO SE PONE CHECKED
                //SELECT COUNT(R.IDROLE) FROM ROLES R INNER JOIN ROL_PERM A ON R.IDROLE=A.IDROLE INNER JOIN PERMITS P ON A.IDPERMIT=P.IDPERMIT WHERE P.IDPERMIT=1 AND R.NAME='ADMIN';
                Decimal tienePermiso = 0;
                if (!R.nameRol.Equals(""))
                {
                    tienePermiso = (Decimal)conector.DLookUp("COUNT(R.IDROLE)", "ROLES R INNER JOIN ROL_PERM A ON R.IDROLE=A.IDROLE INNER JOIN PERMITS P ON A.IDPERMIT=P.IDPERMIT", "P.IDPERMIT=" + (columnaCheck + 1) + " AND R.NAME='" + R.nameRol + "'");
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

        public bool comprobarRolUtilizado(String rol)
        {
            //Devuelve true si algun usuario usa el rol.
            bool eliminado = false;
            Decimal idRol = (Decimal)conector.DLookUp("IDROLE", "ROLES", "NAME='" + rol + "'");
            Decimal usersConRol = (Decimal)conector.DLookUp("COUNT(IDUSERROL)", "USERS_ROLES", "IDROLE=" + idRol);
            if (usersConRol > 0)
            {
                eliminado = true;
            }

            return eliminado;
        }

        public Boolean nuevoRol(DataGridView dgvPermissions, Role R)//(DataGridView dgvPermissions, String nombreRol)
        {
            Boolean creado = false;
            Decimal existe = (Decimal)conector.DLookUp("COUNT(IDROLE)", "ROLES", "NAME='"+R.nameRol.ToUpper()+"'");

            if (existe == 0)
            {
                Decimal idRol = (Decimal)conector.DLookUp("MAX(IDROLE)", "ROLES", "");
                Decimal idRol_Permits = (Decimal)conector.DLookUp("MAX(IDROLPERM)", "ROL_PERM", "");
                idRol_Permits += 1;
                idRol += 1;

                String sentencia1 = "INSERT INTO ROLES VALUES(" + (idRol) + ",'" + R.nameRol.ToUpper() + "')";
                conector.setData(sentencia1);

                int checkedPermit = 0;
                foreach (DataGridViewRow row in dgvPermissions.Rows)
                {
                    if (row.Cells[1].Value != null && (bool)row.Cells[1].Value)
                    {
                        String sentencia2 = "INSERT INTO ROL_PERM VALUES(" + (idRol_Permits + checkedPermit) + "," + (checkedPermit+1) + "," + (idRol) + ")";
                        conector.setData(sentencia2);
                    } else
                    {
                        //nada
                    }
                    checkedPermit++;
                }

                existe = (Decimal)conector.DLookUp("COUNT(IDROLE)", "ROLES", "IDROLE="+ (idRol) +" AND NAME ='" + R.nameRol.ToUpper()+"'");
                if(existe != 0)
                {
                    String mensaje = "The user has been successfully deleted.";
                    VentanaPersonalizada cambio = new VentanaPersonalizada(mensaje);
                    cambio.ShowDialog();
                    //MessageBox.Show("El Rol se ha añadido correctamente.");
                    creado = true;
                }
            } else
            {
                String mensaje = "The user has been successfully deleted.";
                VentanaPersonalizada cambio = new VentanaPersonalizada(mensaje);
                cambio.ShowDialog();
                MessageBox.Show("The Role already exists.");
            }


            return creado;
           
        }
        public void modificarRol(DataGridView dgvPermissions, Role R)//(DataGridView dgvPermissions, String nombreRol)
        {

            Decimal idRol = (Decimal)conector.DLookUp("IDROLE", "ROLES", "NAME='"+ R.nameRol+"'");
            Decimal idRol_Permits = (Decimal)conector.DLookUp("MAX(IDROLPERM)", "ROL_PERM", "");
            idRol_Permits += 1;

            int[] modelo = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            int checkedPermit = 0;
            foreach (DataGridViewRow row in dgvPermissions.Rows)
            {
                if (row.Cells[1].Value != null && (bool)row.Cells[1].Value)
                {
                    modelo[checkedPermit] = 1;
                }
                else
                {
                    //nada
                }
                checkedPermit++;
            }

            //Borro todo para meter las nuevas
            String sentencia1 = "DELETE FROM ROL_PERM WHERE IDROLE="+ idRol;
            conector.setData(sentencia1);

            checkedPermit = 0;
            for (int i = 0;i< modelo.Length; i++)
            {
                if (modelo[i] == 1)
                {
                    String sentencia2 = "INSERT INTO ROL_PERM VALUES(" + (idRol_Permits + checkedPermit) + "," + (checkedPermit + 1) + "," + (idRol) + ")";
                    conector.setData(sentencia2);
                }
                checkedPermit++;
            }

            Decimal existe = (Decimal)conector.DLookUp("COUNT(IDROLE)", "ROLES", "IDROLE=" + (idRol) + " AND NAME ='" + R.nameRol.ToUpper() + "'");
                if (existe != 0)
                {
                    MessageBox.Show("The Role has been modified correctly.");
                }
        }

        public bool eliminarRole(Role R)//(String nombreRole)
        {
            bool result = false;
            //String name = (String)dgvUsers.SelectedRows[selectedRowCount].DataBoundItem;


            //DELETE FROM USERS_ROLES WHERE IDUSERROL = (SELECT IDUSER FROM USERS WHERE NAME = 'aaa');
            //DELETE FROM USERS WHERE NAME = 'aaa'

            //String sentencia1 = "DELETE FROM USERS_ROLES WHERE IDUSERROL = (SELECT IDUSER FROM USERS WHERE NAME = '"+ name+"')";-----
            //conector.setData(sentencia1);-------

            String sentencia1 = "DELETE FROM ROL_PERM WHERE IDROLE = (SELECT IDROLE FROM ROLES WHERE NAME = '"+R.nameRol+"')";
            conector.setData(sentencia1);

            String sentencia2 = "DELETE FROM ROLES WHERE NAME = '" + R.nameRol + "'";
            conector.setData(sentencia2);


            String mensaje = "The role has been successfully deleted.";
            VentanaPersonalizada cambio = new VentanaPersonalizada(mensaje);
            cambio.ShowDialog();
            //MessageBox.Show("El usuario se ha eliminado correctamente.");
            Decimal existe = (Decimal)conector.DLookUp("COUNT(IDROLE)", "ROLES", "NAME='" + R.nameRol + "'");
            if (existe == 0)
            {
                result = true;
            }
            return result;
        }

    }
}
