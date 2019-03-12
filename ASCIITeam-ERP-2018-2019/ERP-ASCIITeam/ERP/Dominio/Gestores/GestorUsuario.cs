using ERP.Dominio.Util;
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
    class GestorUsuario
    {
        public DataTable tabla { get; set; }
        ConnectOracle conector;

        public GestorUsuario()
        {
            conector = new ConnectOracle();
            tabla = new DataTable();
        }

        public Decimal contarUsuarios()
        {
            Decimal cuentaUsuarios = (Decimal)conector.DLookUp("COUNT(IDUSER)", "USERS", "");

            return cuentaUsuarios;
        }

        public void leerUsuarios(String condicion)
        {
            DataSet data = new DataSet();

            if (condicion.Equals(""))
            {
                data = conector.getData("SELECT U.NAME NAME,R.NAME ROLE FROM USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE", "USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE");
            }
            else
            {
                data = conector.getData("SELECT U.NAME NAME,R.NAME ROLE FROM USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE WHERE " + condicion, "USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE");
            }
            tabla = data.Tables["USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE"];
        }

        /*public void cargarTablaUser(DataGridView dgvUsers)
        {
            //PARA COLORES
            //'Color para el fondo de la celda 
            //Me.DataGridView1.Rows(0).Cells(0).Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF000F")

            //'Color para el texto de la celda 
            //Me.DataGridView1.Rows(0).Cells(0).Style.ForeColor = System.Drawing.ColorTranslator.FromHtml("#006")


            DataSet data = new DataSet();
  
            //SELECT U.NAME,R.NAME FROM USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE;
            data = conector.getData("SELECT U.NAME NAME,R.NAME ROLE FROM USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE", "USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE");

            DataTable tusers = data.Tables["USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE"];

            //dgvCustomers.DataSource = tcustomers;

            dgvUsers.Columns.Add("NAME", "NAME");
            dgvUsers.Columns.Add("ROLE", "ROLE");

            foreach (DataRow row in tusers.Rows)
            {
                dgvUsers.Rows.Add(row["NAME"], row["ROLE"]);
            }
            //dgvUsers.ColumnHeadersVisible = false;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.FromArgb(114, 47, 55);

            ////Colores de Header (no va nose porque)
            //dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(114, 47, 55);
            //dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //No editable
            dgvUsers.ReadOnly = true;
        }

        public void refrescarTablaUser(DataGridView dgvUsers)
        {
            dgvUsers.Columns.Remove("NAME");
            dgvUsers.Columns.Remove("ROLE");

            DataSet data = new DataSet();

            //SELECT U.NAME,R.NAME FROM USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE;
            data = conector.getData("SELECT U.NAME NAME,R.NAME ROLE FROM USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE", "USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE");

            DataTable tusers = data.Tables["USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE"];

            //dgvCustomers.DataSource = tcustomers;

            dgvUsers.Columns.Add("NAME", "NAME");
            dgvUsers.Columns.Add("ROLE", "ROLE");

            foreach (DataRow row in tusers.Rows)
            {
                dgvUsers.Rows.Add(row["NAME"], row["ROLE"]);
            }
            //dgvUsers.ColumnHeadersVisible = false;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.FromArgb(114, 47, 55);

            ////Colores de Header (no va nose porque)
            //dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(114, 47, 55);
            //dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //No editable
            dgvUsers.ReadOnly = true;
        }*/

        public void comprobarPermisos(User U, TabControl tbcMenuPrincipal)//(String name,String password,TabControl tbcMenuPrincipal)
        {
            //SELECT R.NAME ROLE FROM USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE WHERE U.NAME='root' AND U.PASSWORD='admin1234';
            //   Object rol = conector.DLookUp("R.IDROLE", "USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE", "U.NAME='root' AND U.PASSWORD='admin1234'");
            //------------devuelve -1 en vez del id. EHCHO TODO EN UNO ABAJO EN VEZ DE POR PARTES.

            //MessageBox.Show(rol.ToString());

            Decimal numPermisos = (Decimal)conector.DLookUp("COUNT(IDPERMIT)", "PERMITS", " NAME LIKE '%MANAGEMENT%'");

            //taboage de 1 a 8
            Decimal tienePermiso = 0;
            for (int i = 0; i < numPermisos; i++)
            {
                //si existe el id role con nombre de ese usuario con el permiso, le permite usarlo.
                //problema en el rol DE ARRIBA ASIQUE TODO EN 1.
                //tienePermiso = (Decimal)conector.DLookUp("COUNT(R.IDROLE)", "ROLES R INNER JOIN ROL_PERM A ON R.IDROLE=A.IDROLE INNER JOIN PERMITS P ON A.IDPERMIT=P.IDPERMIT", "P.IDPERMIT=" + (i + 1) + " AND R.IDROLE=" + rol);
                tienePermiso = (Decimal)conector.DLookUp("COUNT(R.IDROLE)", "USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE INNER JOIN ROL_PERM A ON R.IDROLE=A.IDROLE INNER JOIN PERMITS P ON A.IDPERMIT=P.IDPERMIT", "P.IDPERMIT=" + (i + 1) + " AND U.NAME = '" + U.name + "' AND U.PASSWORD = '" + U.password + "'");
                if (tienePermiso == 0)
                {
                    TabPage tp = tbcMenuPrincipal.TabPages[i + 1];
                    ((Control)tp).Text = "";
                    ((Control)tp).Enabled = false;

                }
                else
                {
                    TabPage tp = tbcMenuPrincipal.TabPages[i + 1];
                    ((Control)tp).Enabled = true;
                }
            }
        }

        public int[] comprobarPermisosOrders(User U, int[] permisos)
        {

            Decimal numPermisosTotales = (Decimal)conector.DLookUp("COUNT(IDPERMIT)", "PERMITS", "");
            Decimal numPermisos = (Decimal)conector.DLookUp("COUNT(IDPERMIT)", "PERMITS", " NAME LIKE '%MANAGEMENT%'");

           // MessageBox.Show(Convert.ToString(U.idUser));
            Decimal tienePermiso = 0;
            int j = 0;
            for (int i = Convert.ToInt32(numPermisos); i < numPermisosTotales; i++)
            {
                
                tienePermiso = (Decimal)conector.DLookUp("COUNT(R.IDROLE)", "USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE INNER JOIN ROL_PERM A ON R.IDROLE=A.IDROLE INNER JOIN PERMITS P ON A.IDPERMIT=P.IDPERMIT", "P.IDPERMIT=" + (i + 1) + " AND U.IDUSER = '" + U.idUser + "'");
                if (tienePermiso == 0)
                {
                    permisos[j] = 0;

                }
                else
                {
                    permisos[j] = 1;
                }
                j++;
            }
            return permisos;
        }

        public String loguearse(User U)//(String user,String pass)
        {
            String condicion = " DELETED = 0 AND NAME = '" + U.name + "' AND PASSWORD = '" + U.password + "'";

            Decimal existe = (Decimal)conector.DLookUp("COUNT(IDUSER)", "USERS", "DELETED = 0 AND NAME = '" + U.name + "' AND PASSWORD = '" + U.password + "'");
            String passDB = "";
            if (existe == 0)
            {
                passDB = "-1";
            } else
            {
                passDB = Convert.ToString(conector.DLookUp("IDUSER", "USERS", condicion));
            }

            return passDB;
        }

        public Object extraerIdUserLogueado(String nameUser)
        {
            return conector.DLookUp("IDUSER", "USERS", "NAME='" + nameUser + "'");
        }

        public Boolean nuevoUsuario(User U)//(String name,String pass,String rol)
        {
            Boolean creado = false;
            Decimal existe = (Decimal)conector.DLookUp("COUNT(IDUSER)", "USERS", "NAME='"+U.name+"'");

            if (existe == 0)
            {
                Decimal numUser = (Decimal)conector.DLookUp("COUNT(IDUSER)", "USERS", "");
                Decimal idUser;
                if (numUser == 0)
                {
                    idUser = 1;

                }
                else
                {
                    idUser = (Decimal)conector.DLookUp("MAX(IDUSER)", "USERS", "");
                }

                Decimal numidUser_Roles = (Decimal)conector.DLookUp("COUNT(IDUSERROL)", "USERS_ROLES", "");
                Decimal idUser_Roles;
                if (numidUser_Roles == 0)
                {
                    idUser_Roles = 1;

                }
                else
                {
                    idUser_Roles = (Decimal)conector.DLookUp("MAX(IDUSERROL)", "USERS_ROLES", "");
                }

                Decimal numidRoles = (Decimal)conector.DLookUp("COUNT(IDROLE)", "ROLES", "");
                Decimal idRoles;
                if (numidRoles == 0)
                {
                    idRoles = 1;

                }
                else
                {
                    idRoles = (Decimal)conector.DLookUp("IDROLE", "ROLES", "NAME='" + U.rol.nameRol + "'");
                }

                String pass = Encryptor.MD5Hash(U.password);

                String sentencia1 = "INSERT INTO USERS VALUES(" + (idUser + 1) + ",'" + U.name + "','" + pass + "',0)";
                conector.setData(sentencia1);

                String sentencia2 = "INSERT INTO USERS_ROLES VALUES(" + (idUser_Roles + 1) + "," + (idUser + 1) + "," + idRoles + ")";
                conector.setData(sentencia2);

                existe = (Decimal)conector.DLookUp("COUNT(IDUSER)", "USERS", "NAME='" + U.name + "' AND IDUSER =" + (idUser + 1) + " AND PASSWORD ='" + pass + "'");

                if (existe > 0)
                {
                    String mensaje = "The user has been added correctly.";
                    VentanaPersonalizada cambio = new VentanaPersonalizada(mensaje);
                    cambio.ShowDialog();
                    //MessageBox.Show("El usuario se ha añadido correctamente.");
                    creado = true;
                }
            } else
            {
                String mensaje = "Username is not valid.";
                VentanaPersonalizada cambio = new VentanaPersonalizada(mensaje);
                cambio.ShowDialog();
                //MessageBox.Show("El nombre de usuario no es Valido.");
            }
            return creado;
        }

        public void modificarUsuario(User U)//(String nombreUser,String pass,String role)
        {
            //String name = (String)dgvUsers.SelectedRows[selectedRowCount].DataBoundItem;

            //DELETE FROM USERS_ROLES WHERE IDUSERROL = (SELECT IDUSER FROM USERS WHERE NAME = 'aaa');
            //DELETE FROM USERS WHERE NAME = 'aaa'

            //String sentencia1 = "DELETE FROM USERS_ROLES WHERE IDUSERROL = (SELECT IDUSER FROM USERS WHERE NAME = '"+ name+"')";-----
            //conector.setData(sentencia1);-------

            Object idUser = conector.DLookUp("IDUSER", "USERS", "NAME='" + U.name + "'");
            Object idRol = conector.DLookUp("IDROLE", "ROLES", "NAME='"+U.rol.nameRol+"'");

            if (U.password.Equals(""))
            {
                String sentencia2 = "UPDATE USERS_ROLES SET IDROLE =" + idRol + " WHERE IDUSER = " + idUser;
                conector.setData(sentencia2);
            } else
            {
                String pass = Encryptor.MD5Hash(U.password);
                String sentencia1 = "UPDATE USERS SET PASSWORD ='"+ pass + "' WHERE NAME = '" + U.name + "'";
                conector.setData(sentencia1);

                String sentencia2 = "UPDATE USERS_ROLES SET IDROLE =" + idRol + " WHERE IDUSER = " + idUser;
                conector.setData(sentencia2);
            }

            String mensaje = "The user has been modified correctly.";
            VentanaPersonalizada cambio = new VentanaPersonalizada(mensaje);
            cambio.ShowDialog();
            //MessageBox.Show("El usuario se ha eliminado correctamente.");
        }

        public void eliminarUsuario(DataGridView dgvUsersaa, User U)//(DataGridView dgvUsersaa, String nombreFilaSeleccionada)
        {
            //String name = (String)dgvUsers.SelectedRows[selectedRowCount].DataBoundItem;


            String name = U.name;

            //DELETE FROM USERS_ROLES WHERE IDUSERROL = (SELECT IDUSER FROM USERS WHERE NAME = 'aaa');
            //DELETE FROM USERS WHERE NAME = 'aaa'

            //String sentencia1 = "DELETE FROM USERS_ROLES WHERE IDUSERROL = (SELECT IDUSER FROM USERS WHERE NAME = '"+ name+"')";-----
            //conector.setData(sentencia1);-------

            String sentencia2 = "UPDATE USERS SET DELETED = 1 WHERE NAME = '" + name + "'";
            conector.setData(sentencia2);

            String mensaje = "The user has been successfully deleted.";
            VentanaPersonalizada cambio = new VentanaPersonalizada(mensaje);
            cambio.ShowDialog();
            //MessageBox.Show("El usuario se ha eliminado correctamente.");
        }
    }
}
