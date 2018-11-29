﻿using System;
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
        ConnectOracle conector;

        public GestorUsuario()
        {
            conector = new ConnectOracle();
        }

        public void cargarTablaUser(DataGridView dgvUsers)
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

        public void comprobarPermisos(String name,String password,TabControl tbcMenuPrincipal)
        {
            //SELECT R.NAME ROLE FROM USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE WHERE U.NAME='root' AND U.PASSWORD='admin1234';
            Object rol = conector.DLookUp("R.NAME", "USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE", "U.NAME='" + name + "' AND U.PASSWORD='" + password + "'");
            String role = Convert.ToString(rol);
            Decimal numPermisos = (Decimal)conector.DLookUp("COUNT(IDPERMIT)", "PERMITS", "");

            //taboage de 1 a 6
            Decimal tienePermiso = 0;
            for (int i = 0;i< numPermisos; i++)
            {
                //si existe el id role con nombre de ese usuario con el permiso, le permite usarlo.
                //problema en el rol
                tienePermiso = (Decimal)conector.DLookUp("COUNT(R.IDROLE)", "ROLES R INNER JOIN ROL_PERM A ON R.IDROLE=A.IDROLE INNER JOIN PERMITS P ON A.IDPERMIT=P.IDPERMIT", "P.IDPERMIT=" + (i + 1) + " AND R.NAME='" + role + "'");
                if (tienePermiso == 0)
                {
                    TabPage tp = tbcMenuPrincipal.TabPages[i + 1];
                    ((Control)tp).Enabled = false;
                } else
                {
                    TabPage tp = tbcMenuPrincipal.TabPages[i + 1];
                    ((Control)tp).Enabled = true;
                }
            }



            //Decimal tienePermiso = 0;
            //if (!Role.Equals(""))
            //{
            //    tienePermiso = (Decimal)conexion.DLookUp("COUNT(R.IDROLE)", "ROLES R INNER JOIN ROL_PERM A ON R.IDROLE=A.IDROLE INNER JOIN PERMITS P ON A.IDPERMIT=P.IDPERMIT", "P.IDPERMIT=" + (columnaCheck + 1) + " AND R.NAME='" + Role + "'");
            //}
        }
    }
}
