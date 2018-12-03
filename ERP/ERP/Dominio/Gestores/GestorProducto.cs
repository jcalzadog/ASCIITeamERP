using ERP.Presentacion.ErroresCambios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Dominio.Gestores
{
    class GestorProducto
    {
        public DataTable tabla { get; set; }
        ConnectOracle conector;

        public GestorProducto()
        {
            conector = new ConnectOracle();
            tabla = new DataTable();
        }

        public void leerProductos(String condicion)
        {
            DataSet data = new DataSet();

            if (condicion.Equals(""))
            {
                data = conector.getData("SELECT PR.NAME NAME,C.NAME CATEGORY,PL.NAME PLATFORM,PR.MINIMUMAGE PEGI,PR.PRICE PRICE FROM PRODUCTS PR INNER JOIN CATEGORIES C ON PR.IDCATEGORY = C.IDCATEGORY INNER JOIN PLATFORMS PL ON PR.IDPLATFORM = PL.IDPLATFORM", "PRODUCTS PR INNER JOIN CATEGORIES C ON PR.IDCATEGORY = C.IDCATEGORY INNER JOIN PLATFORMS PL ON PR.IDPLATFORM = PL.IDPLATFORM");
            }
            else
            {
                data = conector.getData("SELECT PR.NAME NAME,C.NAME CATEGORY,PL.NAME PLATFORM,PR.MINIMUMAGE PEGI,PR.PRICE PRICE FROM PRODUCTS PR INNER JOIN CATEGORIES C ON PR.IDCATEGORY = C.IDCATEGORY INNER JOIN PLATFORMS PL ON PR.IDPLATFORM = PL.IDPLATFORM WHERE " + condicion, "PRODUCTS PR INNER JOIN CATEGORIES C ON PR.IDCATEGORY = C.IDCATEGORY INNER JOIN PLATFORMS PL ON PR.IDPLATFORM = PL.IDPLATFORM");
            }
            tabla = data.Tables["PRODUCTS PR INNER JOIN CATEGORIES C ON PR.IDCATEGORY = C.IDCATEGORY INNER JOIN PLATFORMS PL ON PR.IDPLATFORM = PL.IDPLATFORM"];
        }
        
        public Boolean nuevoProducto(String name, String nomCat, String nomPlat,int pegi,int price)
        {
            Decimal idCat = (Decimal)conector.DLookUp("IDCATEGORY", "CATEGORIES", "NAME = '"+nomCat+"'");
            Decimal idPlat = (Decimal)conector.DLookUp("IDPLATFORM", "PLATFORMS", "NAME = '" + nomPlat + "'");
            Boolean creado = false;
            Decimal existe = (Decimal)conector.DLookUp("COUNT(IDPRODUCT)", "PRODUCTS", "NAME='" + name + "' AND IDCATEGORY = " + idCat + " AND IDPLATFORM = " + idPlat);

            if (existe == 0)
            {
                Decimal idProduct = (Decimal)conector.DLookUp("MAX(IDPRODUCT)", "PRODUCTS", "");
                

                String sentencia = "INSERT INTO PRODUCTS VALUES(" + (idProduct + 1) + ",'" + name + "',"+idCat+","+idPlat+","+pegi+","+price+","+0+")";
                conector.setData(sentencia);
                
                existe = (Decimal)conector.DLookUp("COUNT(IDPRODUCT)", "PRODUCTS", "NAME='" + name + "' AND IDCATEGORY = " + idCat + " AND IDPLATFORM = " + idPlat);

                if (existe > 0)
                {
                    MessageBox.Show("El usuario se ha añadido correctamente.");
                    creado = true;
                }
            }
            else
            {
                String mensaje = "El nombre de producto no es Valido.";
                VentanaPersonalizada cambio = new VentanaPersonalizada(mensaje);
                cambio.ShowDialog();
                //MessageBox.Show("El nombre de producto no es Valido.");
            }
            return creado;
        }

        public void modificarProducto(String name, String nomCat, String nomPlat, int pegi, int price, String nomCatVieja,String nomPlatVieja)
        {
            Decimal idProduct = (Decimal)conector.DLookUp("MAX(IDPRODUCT)", "PRODUCTS", "");
            Object idCat = conector.getData("SELECT IDCATEGORY FROM CATEGORIES WHERE NAME = "+nomCat,"CATEGORIES");
            Object idPlat = conector.getData("SELECT IDPLATFORM FROM PLATFORMS WHERE NAME = " + nomPlat, "PLATFORMS");
            Object idCatVieja = conector.getData("SELECT IDCATEGORY FROM CATEGORIES WHERE NAME = "+nomCatVieja,"CATEGORIES");
            Object idPlatVieja = conector.getData("SELECT IDPLATFORM FROM PLATFORMS WHERE NAME = " + nomPlatVieja, "PLATFORMS");
            

            String sentencia = "UPDATE PRODUCTS SET idcategory = "+idCat+", idplatform = "+idPlat+", minimumage = "+pegi+", price = "+price+" WHERE name = '"+name+"' and idcategory = "+idCatVieja+" and idplatform = "+idPlatVieja;
            conector.setData(sentencia);


            String mensaje = "The user has been modified correctly.";
            VentanaPersonalizada cambio = new VentanaPersonalizada(mensaje);
            //cambio.ShowDialog();
            //MessageBox.Show("El usuario se ha eliminado correctamente.");
        }


    }
}
