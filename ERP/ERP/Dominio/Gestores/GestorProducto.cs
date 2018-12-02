﻿using ERP.Presentacion.ErroresCambios;
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
        
        public Boolean nuevoProducto(String name, int idCat, int idPlat,int pegi,int price)
        {
            Boolean creado = false;
            Decimal existe = (Decimal)conector.DLookUp("COUNT(IDPRODUCT)", "PRODUCTS", "NAME='" + name + "' AND IDCATEGORY = " + idCat + " AND IDPLATFORM = " + idPlat);

            if (existe == 0)
            {
                Decimal idProduct = (Decimal)conector.DLookUp("MAX(IDPRODUCT)", "PRODUCTS", "");
                Decimal idPlatfrom = (Decimal)conector.DLookUp("MAX(IDPLATFORM)", "PLATFORMS", "");
                Decimal idCategory = (Decimal)conector.DLookUp("IDCATEGORY", "CATEGORIES", "");

                String sentencia = "INSERT INTO PRODUCTS VALUES(" + (idProduct + 1) + ",'" + name + "',"+idCat+","+idPlat+","+pegi+","+price+")";
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
    }
}
