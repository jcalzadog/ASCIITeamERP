using ERP.Presentacion.ErroresCambios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Dominio.Gestores
{
    class GestorCliente
    {
        public DataTable tabla { get; set; }
        public DataTable tablaCities { get; set; }
        public DataTable tablaZipCode { get; set; }
        ConnectOracle conector;
        LinkedList<Object> listaRegiones;
        LinkedList<Object> listaStates;
        LinkedList<Object> listaCities;
        LinkedList<Object> listaZipCode;

        public GestorCliente()
        {
            conector = new ConnectOracle();
            tabla = new DataTable();
            tablaCities = new DataTable();
            tablaZipCode = new DataTable();
            listaRegiones = new LinkedList<Object>();
            listaStates = new LinkedList<Object>();
            listaCities = new LinkedList<Object>();
            listaZipCode = new LinkedList<Object>();
        }

        public Object sacarZipCode(String dni)
        {
            //SELECT Z.ZIPCODE FROM ZIPCODES Z INNER JOIN ZIPCODESCITIES T ON Z.IDZIPCODE=T.REFZIPCODE INNER JOIN CITIES C ON T.REFCITY=C.IDCITY WHERE C.CITY ='';
            //SELECT REFZIPCODECITIES FROM CUSTOMERS WHERE DNI=
            object zipC = conector.DLookUp("REFZIPCODESCITIES ", "CUSTOMERS", " DNI='" + dni + "'");
            return zipC;
        }

        public void leerClientes(String condicion)
        {
            //SELECT C.DNI,C.NAME,C.SURNAME,C.ADDRESS,C.PHONE,C.EMAIL,R.REGION,T.CITY FROM CUSTOMERS C INNER JOIN ZIPCODESCITIES Z ON C.REFZIPCODESCITIES=Z.IDZIPCODESCITIES INNER JOIN REGIONS R ON Z.REFSTATE=R.IDREGION INNER JOIN CITIES T ON Z.REFCITY=T.IDCITY
            DataSet data = new DataSet();

            if (condicion.Equals(""))
            {
                data = conector.getData("SELECT C.DNI,C.NAME,C.SURNAME,C.ADDRESS,C.PHONE,C.EMAIL, T.CITY FROM CUSTOMERS C INNER JOIN ZIPCODESCITIES Z ON C.REFZIPCODESCITIES=Z.IDZIPCODESCITIES INNER JOIN CITIES T ON Z.REFCITY=T.IDCITY", "CUSTOMERS C INNER JOIN ZIPCODESCITIES Z ON C.REFZIPCODESCITIES=Z.IDZIPCODESCITIES INNER JOIN CITIES T ON Z.REFCITY=T.IDCITY");
            }
            else
            {
                data = conector.getData("SELECT C.DNI,C.NAME,C.SURNAME,C.ADDRESS,C.PHONE,C.EMAIL, T.CITY FROM CUSTOMERS C INNER JOIN ZIPCODESCITIES Z ON C.REFZIPCODESCITIES=Z.IDZIPCODESCITIES INNER JOIN CITIES T ON Z.REFCITY=T.IDCITY WHERE " + condicion, "CUSTOMERS C INNER JOIN ZIPCODESCITIES Z ON C.REFZIPCODESCITIES=Z.IDZIPCODESCITIES INNER JOIN CITIES T ON Z.REFCITY=T.IDCITY");
            }
            tabla = data.Tables["CUSTOMERS C INNER JOIN ZIPCODESCITIES Z ON C.REFZIPCODESCITIES=Z.IDZIPCODESCITIES INNER JOIN CITIES T ON Z.REFCITY=T.IDCITY"];
        }

        public void refrescarRegions(ComboBox cmbRegions)
        {
            Decimal numRegions = (Decimal)conector.DLookUp("MAX(IDREGION)", "REGIONS", "");
            //int numRoles = int.Parse(numR);

            for (int i = 1; i <= numRegions; i++)
            {
                listaRegiones.AddLast(conector.DLookUp("REGION", "REGIONS", " IDREGION=" + i));
            }

            cmbRegions.Items.Clear();
            int cont = 0;
            cmbRegions.Items.Add("Ninguno");
            while (cont < listaRegiones.Count)
            {
                cmbRegions.Items.Add(listaRegiones.ElementAt(cont));
                cont++;
            }
            cmbRegions.SelectedIndex = 0;
        }

        public void refrescarState(ComboBox cmbState,Customer C)
        {
            listaStates = new LinkedList<Object>();
            Decimal numState = (Decimal)conector.DLookUp("MAX(IDSTATE)", "STATES S INNER JOIN REGIONS R ON S.REFREGION=R.IDREGION", "R.REGION='" + C.region + "'");
            //int numRoles = int.Parse(numR);
            LinkedList<Object> listaI = new LinkedList<Object>();

            for (int i = 1; i <= numState; i++)
            {
                listaI.AddLast(conector.DLookUp("STATE", "STATES S INNER JOIN REGIONS R ON S.REFREGION=R.IDREGION", "R.REGION='" + C.region + "' AND IDSTATE=" + i));
            }


            for (int i = 1; i < numState; i++)
            {

                if (!listaI.ElementAt(i).ToString().Equals("-1"))
                {
                    listaStates.AddLast(listaI.ElementAt(i));
                }

            }

            cmbState.Items.Clear();
            int cont = 0;
            cmbState.Items.Add("Ninguno");
            while (cont < listaStates.Count)
            {
                cmbState.Items.Add(listaStates.ElementAt(cont));
                cont++;
            }
            //cmbState.SelectedIndex = 0;
        }

        public void refrescarCities(ComboBox cmbCities, Customer C)
        {
            //listaCities = new LinkedList<Object>();
            //Decimal numCities = (Decimal)conector.DLookUp("COUNT(C.IDCITY)", "CITIES C INNER JOIN ZIPCODESCITIES Z ON C.IDCITY=Z.REFCITY INNER JOIN STATES S ON Z.REFSTATE=S.IDSTATE", "S.STATE='" + nameState + "'");

            ////int numRoles = int.Parse(numR);
            //LinkedList<Object> listaI = new LinkedList<Object>();

            //for (int i = 1; i <= numCities; i++)
            //{
            //    listaI.AddLast(conector.DLookUp("C.CITY","CITIES C INNER JOIN ZIPCODESCITIES Z ON C.IDCITY = Z.REFCITY INNER JOIN STATES S ON Z.REFSTATE = S.IDSTATE", "S.STATE = '" + nameState + "' AND C.IDCITY=" + i));
            //}
            //listaI = conector.DLookUp("C.CITY", "CITIES C INNER JOIN ZIPCODESCITIES Z ON C.IDCITY = Z.REFCITY INNER JOIN STATES S ON Z.REFSTATE = S.IDSTATE", "S.STATE = '" + nameState + "'"));

            //for (int i = 1; i < numCities; i++)
            //{

            //    if (!listaI.ElementAt(i).ToString().Equals("-1"))
            //    {
            //        listaCities.AddLast(listaI.ElementAt(i));
            //    }

            //}

            //cmbCities.Items.Clear();
            //int cont = 0;
            //cmbCities.Items.Add("Ninguno");
            //while (cont < listaStates.Count)
            //{
            //    cmbCities.Items.Add(listaCities.ElementAt(cont));
            //    cont++;
            //}
            //cmbCities.SelectedIndex = 0;

            DataSet data = new DataSet();
            data = conector.getData("SELECT DISTINCT C.CITY NAME FROM CITIES C INNER JOIN ZIPCODESCITIES Z ON C.IDCITY = Z.REFCITY INNER JOIN STATES S ON Z.REFSTATE = S.IDSTATE WHERE S.STATE = '" + C.state + "'", "CITIES C INNER JOIN ZIPCODESCITIES Z ON C.IDCITY = Z.REFCITY INNER JOIN STATES S ON Z.REFSTATE = S.IDSTATE");
            tablaCities = data.Tables["CITIES C INNER JOIN ZIPCODESCITIES Z ON C.IDCITY = Z.REFCITY INNER JOIN STATES S ON Z.REFSTATE = S.IDSTATE"];
        }
    

        public void refrescarZipCode(Customer C)
        {
            DataSet data = new DataSet();
            data = conector.getData("SELECT Z.ZIPCODE CODE FROM ZIPCODES Z INNER JOIN ZIPCODESCITIES H ON Z.IDZIPCODE = H.REFZIPCODE INNER JOIN CITIES C ON H.REFCITY= C.IDCITY WHERE C.CITY = '" + C.city + "'", "FROM ZIPCODES Z INNER JOIN ZIPCODESCITIES H ON Z.IDZIPCODE = H.REFZIPCODE INNER JOIN CITIES C ON H.REFCITY= C.IDCITY");
            tablaZipCode = data.Tables["FROM ZIPCODES Z INNER JOIN ZIPCODESCITIES H ON Z.IDZIPCODE = H.REFZIPCODE INNER JOIN CITIES C ON H.REFCITY= C.IDCITY"];
        }

        public Boolean nuevoCliente(Customer C)//(String DNI,String name,String surname,String address,int phone,String email,String zipCode)
        {
            Boolean creado = false;
            Decimal existe = (Decimal)conector.DLookUp("COUNT(DNI)", "CUSTOMERS", "DNI='" + C.dni + "'");

            if (existe == 0 && validarDNI(C))
            {
                Decimal idCustomer = (Decimal)conector.DLookUp("MAX(IDCUSTOMER)", "CUSTOMERS", "");

                String sentencia1 = "INSERT INTO CUSTOMERS VALUES("+ (idCustomer+1)+",'" + C.dni + "','" + C.name + "','" + C.surname + "','"+C.address+"',"+C.phone+",'"+C.email+"',"+C.refzipcodescities+",0)";
                conector.setData(sentencia1);

                existe = (Decimal)conector.DLookUp("COUNT(IDCUSTOMER)", "CUSTOMERS", "DNI='" + C.dni + "'");

                if (existe > 0)
                {
                    String mensaje = "The customer has been added correctly.";
                    VentanaPersonalizada cambio = new VentanaPersonalizada(mensaje);
                    cambio.ShowDialog();
                    //MessageBox.Show("El usuario se ha añadido correctamente.");
                    creado = true;
                }
            }
            else
            {
                String mensaje = "DNI is not valid.";
                VentanaPersonalizada cambio = new VentanaPersonalizada(mensaje);
                cambio.ShowDialog();
                //MessageBox.Show("El nombre de usuario no es Valido.");
            }
            return creado;
        }

        public void modificarCliente(Customer C, String dniViejo)
        {
            Decimal idClient = (Decimal)conector.DLookUp("IDPRODUCT", "CUSTOMERS", "DNI='" + dniViejo + "'");


            //String sentencia = "UPDATE CUSTOMERS SET idcategory = " + idCat + ", idplatform = " + idPlat + ", minimumage = " + P.miniNumage + ", price = " + P.prize + " WHERE name = '" + P.name + "' and idcategory = " + idCatVieja + " and idplatform = " + idPlatVieja;
            //conector.setData(sentencia);


            String mensaje = "The customer has been modified correctly.";
            VentanaPersonalizada cambio = new VentanaPersonalizada(mensaje);
            //cambio.ShowDialog();
            //MessageBox.Show("El usuario se ha eliminado correctamente.");

        }

        public Boolean validarDNI(Customer C)
        {

            if (C.dni.Contains("'"))
            {
                return false;
            }
            return Regex.IsMatch(C.dni, "^[0-9]{8}[A-Z]");
        }

        public void eliminarCliente(DataGridView dgvUsersaa, Customer C)
        {
            //String name = (String)dgvUsers.SelectedRows[selectedRowCount].DataBoundItem;


            String dni = C.dni;

            //DELETE FROM USERS_ROLES WHERE IDUSERROL = (SELECT IDUSER FROM USERS WHERE NAME = 'aaa');
            //DELETE FROM USERS WHERE NAME = 'aaa'

            //String sentencia1 = "DELETE FROM USERS_ROLES WHERE IDUSERROL = (SELECT IDUSER FROM USERS WHERE NAME = '"+ name+"')";-----
            //conector.setData(sentencia1);-------

            String sentencia1 = "UPDATE CUSTOMERS SET DELETED = 1 WHERE DNI = '" + dni + "'";
            conector.setData(sentencia1);

            String mensaje = "The customer has been successfully deleted.";
            VentanaPersonalizada cambio = new VentanaPersonalizada(mensaje);
            cambio.ShowDialog();
            //MessageBox.Show("El cliente se ha eliminado correctamente.");
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
