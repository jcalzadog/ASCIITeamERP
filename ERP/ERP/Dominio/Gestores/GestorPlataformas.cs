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
    class GestorPlataformas
        
    {
        ConnectOracle conector;
        public DataTable tabla { get; set; }
        LinkedList<Object> listaPlat;
        public GestorPlataformas() {
            tabla = new DataTable();
            conector = new ConnectOracle();
            listaPlat = new LinkedList<object>();
        }
        public void readPlatforms()
        {
            DataSet data = new DataSet();
            data = conector.getData("SELECT L.NAME NAME, COUNT(P.IDPRODUCT) CUENTA FROM PLATFORMS L LEFT OUTER JOIN PRODUCTS P ON L.IDPLATFORM=P.IDPLATFORM WHERE L.DELETED=0 GROUP BY L.NAME",
                "PLATFORMS L LEFT OUTER JOIN PRODUCTS P ON L.IDPLATFORM=P.IDPLATFORM WHERE L.DELETED=0 GROUP BY L.NAME");
            tabla = data.Tables["PLATFORMS L LEFT OUTER JOIN PRODUCTS P ON L.IDPLATFORM=P.IDPLATFORM WHERE L.DELETED=0 GROUP BY L.NAME"];
        }
        public void insertPlataforma(Platforms P)
        {
            Boolean creado = false;
            Decimal existe = (Decimal)conector.DLookUp("COUNT(IDPLATFORM)", "PLATFORMS", "NAME=UPPER('" + P.name + "') AND DELETED =0");

            if (existe == 0)
            {
                Decimal idCategoria = (Decimal)conector.DLookUp("MAX(IDPLATFORM)", "PLATFORMS", "");



                String sentencia1 = "INSERT INTO PLATFORMS VALUES(" + (idCategoria + 1) + ",UPPER('" + P.name + "'),0)";
                conector.setData(sentencia1);



                existe = (Decimal)conector.DLookUp("COUNT(IDPLATFORM)", "PLATFORMS", "NAME=UPPER('" + P.name + "') AND IDPLATFORM =" + (idCategoria + 1));

                if (existe > 0)
                {
                    VentanaPersonalizada vp = new VentanaPersonalizada("Se ha añadido correctamente");
                    vp.ShowDialog();
                }
            }
            else
            {


                VentanaPersonalizada vp = new VentanaPersonalizada("Ya existe esa plataforma");
                vp.ShowDialog();
            }


        }

        public void updatePlataforma(Platforms P)
        {
            Object id = conector.DLookUp("IDPLATFORM", "PLATFORMS", "NAME=UPPER('" + FormPrincipal.nombreviejoPlataformas + "')");
            Decimal existe = (Decimal)conector.DLookUp("COUNT(IDPLATFORM)", "PLATFORMS", "NAME=UPPER('" + P.name + "') AND DELETED = 0");
            if (existe == 0)
            {

                conector.setData("UPDATE PLATFORMS SET NAME=UPPER('" + P.name + "') WHERE IDPLATFORM=" + id);
                VentanaPersonalizada vp = new VentanaPersonalizada("Se ha actualizado correctamente");
                vp.ShowDialog();
            }
            else
            {
                VentanaPersonalizada vp = new VentanaPersonalizada("Ya existe esa plataforma");
                vp.ShowDialog();
            }

        }
        public void deletePlataforma(Platforms P)
        {

            conector.setData("UPDATE PLATFORMS SET DELETED=1 WHERE NAME=UPPER('" + P.name + "')");

        }

        public void refrescarPlatform(ComboBox cmbPlatform)
        {
            Decimal numPlat = (Decimal)conector.DLookUp("MAX(IDPLATFORM)", "PLATFORMS", "");
            //int numRoles = int.Parse(numR);

            listaPlat = new LinkedList<Object>();
            for (int i = 1; i <= numPlat; i++)
            {
                listaPlat.AddLast(conector.DLookUp("NAME", "PLATFORMS", " IDPLATFORM=" + i));
            }

            cmbPlatform.Items.Clear();
            int cont = 0;
            while (cont < listaPlat.Count)
            {
                cmbPlatform.Items.Add(listaPlat.ElementAt(cont));
                cont++;
            }
            cmbPlatform.SelectedIndex = 0;
        }
    }
}
