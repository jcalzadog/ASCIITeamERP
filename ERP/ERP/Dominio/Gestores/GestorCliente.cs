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
    class GestorCliente
    {
        public DataTable tabla { get; set; }
        ConnectOracle conector;

        public GestorCliente()
        {
            conector = new ConnectOracle();
            tabla = new DataTable();
        }

        public void leerClientes(String condicion)
        {
            //SELECT C.DNI,C.NAME,C.SURNAME,C.ADDRESS,C.PHONE,C.EMAIL,R.REGION,T.CITY FROM CUSTOMERS C INNER JOIN ZIPCODESCITIES Z ON C.REFZIPCODESCITIES=Z.IDZIPCODESCITIES INNER JOIN REGIONS R ON Z.REFSTATE=R.IDREGION INNER JOIN CITIES T ON Z.REFCITY=T.IDCITY
            DataSet data = new DataSet();

            if (condicion.Equals(""))
            {
                data = conector.getData("SELECT C.DNI,C.NAME,C.SURNAME,C.ADDRESS,C.PHONE,C.EMAIL,R.REGION,T.CITY FROM CUSTOMERS C INNER JOIN ZIPCODESCITIES Z ON C.REFZIPCODESCITIES=Z.IDZIPCODESCITIES INNER JOIN REGIONS R ON Z.REFSTATE=R.IDREGION INNER JOIN CITIES T ON Z.REFCITY=T.IDCITY", "CUSTOMERS C INNER JOIN ZIPCODESCITIES Z ON C.REFZIPCODESCITIES=Z.IDZIPCODESCITIES INNER JOIN REGIONS R ON Z.REFSTATE=R.IDREGION INNER JOIN CITIES T ON Z.REFCITY=T.IDCITY");
            }
            else
            {
                data = conector.getData("SELECT C.DNI,C.NAME,C.SURNAME,C.ADDRESS,C.PHONE,C.EMAIL,R.REGION,T.CITY FROM CUSTOMERS C INNER JOIN ZIPCODESCITIES Z ON C.REFZIPCODESCITIES=Z.IDZIPCODESCITIES INNER JOIN REGIONS R ON Z.REFSTATE=R.IDREGION INNER JOIN CITIES T ON Z.REFCITY=T.IDCITY WHERE " + condicion, "CUSTOMERS C INNER JOIN ZIPCODESCITIES Z ON C.REFZIPCODESCITIES=Z.IDZIPCODESCITIES INNER JOIN REGIONS R ON Z.REFSTATE=R.IDREGION INNER JOIN CITIES T ON Z.REFCITY=T.IDCITY");
            }
            tabla = data.Tables["CUSTOMERS C INNER JOIN ZIPCODESCITIES Z ON C.REFZIPCODESCITIES=Z.IDZIPCODESCITIES INNER JOIN REGIONS R ON Z.REFSTATE=R.IDREGION INNER JOIN CITIES T ON Z.REFCITY=T.IDCITY"];
        }

        public void eliminarCliente(DataGridView dgvUsersaa, String dniFilaSeleccionada)
        {
            //String name = (String)dgvUsers.SelectedRows[selectedRowCount].DataBoundItem;


            String dni = dniFilaSeleccionada;

            //DELETE FROM USERS_ROLES WHERE IDUSERROL = (SELECT IDUSER FROM USERS WHERE NAME = 'aaa');
            //DELETE FROM USERS WHERE NAME = 'aaa'

            //String sentencia1 = "DELETE FROM USERS_ROLES WHERE IDUSERROL = (SELECT IDUSER FROM USERS WHERE NAME = '"+ name+"')";-----
            //conector.setData(sentencia1);-------

            String sentencia1 = "UPDATE CUSTOMERS SET DELETED = 1 WHERE DNI = '" + dni + "'";
            conector.setData(sentencia1);

            MessageBox.Show("El cliente se ha eliminado correctamente.");
        }

        public void cargarTablaCustomer(DataGridView dgvCustomers)
        {
            //PARA COLORES
            //'Color para el fondo de la celda 
            //Me.DataGridView1.Rows(0).Cells(0).Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF000F")

            //'Color para el texto de la celda 
            //Me.DataGridView1.Rows(0).Cells(0).Style.ForeColor = System.Drawing.ColorTranslator.FromHtml("#006")


            DataSet data = new DataSet();

            //SELECT U.NAME,R.NAME FROM USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE;
            data = conector.getData("SELECT * FROM CUSTOMERS ORDER BY IDCUSTOMER", "CUSTOMERS");

            DataTable tCustomers = data.Tables["CUSTOMERS"];

            //dgvCustomers.DataSource = tcustomers;

            dgvCustomers.Columns.Add("IDCUSTOMER", "ID");
            dgvCustomers.Columns.Add("NAME", "NAME");
            dgvCustomers.Columns.Add("SURNAME", "SURNAME");
            dgvCustomers.Columns.Add("ADDRESS", "ADDRESS");
            dgvCustomers.Columns.Add("PHONE", "PHONE");
            dgvCustomers.Columns.Add("EMAIL", "EMAIL");
            dgvCustomers.Columns.Add("DELETED", "DELETED");
            dgvCustomers.Columns.Add("REFZIPCODESCITIES", "REFZIPCODESCITIES");

            foreach (DataRow row in tCustomers.Rows)
            {
                dgvCustomers.Rows.Add(row["IDCUSTOMER"], row["NAME"], row["SURNAME"], row["ADDRESS"], row["PHONE"], row["EMAIL"], row["DELETED"], row["REFZIPCODESCITIES"]);
            }
            //dgvUsers.ColumnHeadersVisible = false;
            dgvCustomers.RowHeadersVisible = false;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.BackgroundColor = Color.FromArgb(114, 47, 55);

            ////Colores de Header (no va nose porque)
            //dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(114, 47, 55);
            //dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //No editable
            dgvCustomers.ReadOnly = true;
        }
    }
}
