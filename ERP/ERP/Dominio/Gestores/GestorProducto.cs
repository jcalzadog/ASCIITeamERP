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

        public Boolean nuevoProducto(Producto P)//(String name, String nomCat, String nomPlat, int pegi, int price)
        {
            Decimal idCat = (Decimal)conector.DLookUp("IDCATEGORY", "CATEGORIES", "NAME = '" + P.nomCategory + "'");
            Decimal idPlat = (Decimal)conector.DLookUp("IDPLATFORM", "PLATFORMS", "NAME = '" + P.nomPlatform + "'");
            Boolean creado = false;
            Decimal existe = (Decimal)conector.DLookUp("COUNT(IDPRODUCT)", "PRODUCTS", "NAME='" + P.name + "' AND IDCATEGORY = " + idCat + " AND IDPLATFORM = " + idPlat);

            if (existe == 0)
            {
                Decimal idProduct = (Decimal)conector.DLookUp("MAX(IDPRODUCT)", "PRODUCTS", "");


                String sentencia = "INSERT INTO PRODUCTS VALUES(" + (idProduct + 1) + ",'" + P.name + "'," + idCat + "," + idPlat + "," + P.miniNumage + "," + P.prize + "," + 0 + ")";
                conector.setData(sentencia);

                existe = (Decimal)conector.DLookUp("COUNT(IDPRODUCT)", "PRODUCTS", "NAME='" + P.name + "' AND IDCATEGORY = " + idCat + " AND IDPLATFORM = " + idPlat);

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

        public void modificarProducto(Producto P,String nomCatVieja, String nomPlatVieja)//(String name, String nomCat, String nomPlat, int pegi, int price, String nomCatVieja, String nomPlatVieja)
        {
            Decimal idProduct = (Decimal)conector.DLookUp("MAX(IDPRODUCT)", "PRODUCTS", "");
            Decimal idCat = (Decimal)conector.DLookUp("IDCATEGORY", "CATEGORIES", "NAME = '" + P.nomCategory + "'");
            Decimal idPlat = (Decimal)conector.DLookUp("IDPLATFORM", "PLATFORMS", "NAME = '" + P.nomPlatform + "'");
            Decimal idCatVieja = (Decimal)conector.DLookUp("IDCATEGORY", "CATEGORIES", "NAME = '" + nomCatVieja + "'");
            Decimal idPlatVieja = (Decimal)conector.DLookUp("IDPLATFORM", "PLATFORMS", "NAME = '" + nomPlatVieja + "'");


            String sentencia = "UPDATE PRODUCTS SET idcategory = " + idCat + ", idplatform = " + idPlat + ", minimumage = " + P.miniNumage + ", price = " + P.prize + " WHERE name = '" + P.name + "' and idcategory = " + idCatVieja + " and idplatform = " + idPlatVieja;
            conector.setData(sentencia);


            String mensaje = "The user has been modified correctly.";
            VentanaPersonalizada cambio = new VentanaPersonalizada(mensaje);
            //cambio.ShowDialog();
            //MessageBox.Show("El usuario se ha eliminado correctamente.");
        }

        public void eliminarProducto(DataGridView dgvProduct, Producto P)
        {
            
            String name = P.name;

        String sentencia = "UPDATE PRODUCTS SET DELETED = 1 WHERE NAME = '" + P.name + "'";
        conector.setData(sentencia);

            String mensaje = "The product has been successfully deleted.";
        VentanaPersonalizada cambio = new VentanaPersonalizada(mensaje);
        cambio.ShowDialog();
        }

        public Decimal obtenerCmb(String select,String tabla,String cmb)
        {
            Decimal id = (Decimal)conector.DLookUp(select,tabla, "NAME='" + cmb + "'");
            return id;
        }
    }
        
}
