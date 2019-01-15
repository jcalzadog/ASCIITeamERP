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
    class GestorCategorias
    {
        ConnectOracle conector;
        LinkedList<Object> listaCat;
        public DataTable tabla { get; set; }
        public GestorCategorias() {
            conector = new ConnectOracle();
            tabla = new DataTable();
            listaCat = new LinkedList<object>();
        }

        public bool categoriaEstaProducto(String name)
        {
            bool tiene = false;
            Decimal contar = (Decimal)conector.DLookUp("COUNT(IDPRODUCT)", "PRODUCTS P INNER JOIN CATEGORIES C ON P.IDCATEGORY=C.IDCATEGORY", "P.DELETED=0 AND C.NAME='" + name + "'");
            if (contar > 0)
            {
                tiene = true;
            }
            return tiene;
        }

        public Decimal contarCategorias()
        {
            Decimal cuentaCate = (Decimal)conector.DLookUp("COUNT(IDCATEGORY)", "CATEGORIES", "");

            return cuentaCate;
        }

        public void readCategorias() {
            DataSet data = new DataSet();
            // data = conector.getData("SELECT * FROM CATEGORIES WHERE DELETED = 0 ORDER BY IDCATEGORY", "CATEGORIES");
            data = conector.getData("SELECT C.NAME NAME, COUNT(CASE WHEN P.DELETED=0 THEN P.IDPRODUCT END) CUENTA FROM CATEGORIES C LEFT OUTER JOIN PRODUCTS P ON C.IDCATEGORY=P.IDCATEGORY WHERE C.DELETED = 0 GROUP BY C.NAME ORDER BY C.NAME", "CATEGORIES C LEFT OUTER JOIN PRODUCTS P ON C.IDCATEGORY=P.IDCATEGORY GROUP BY C.NAME ORDER BY C.NAME");
            tabla = data.Tables["CATEGORIES C LEFT OUTER JOIN PRODUCTS P ON C.IDCATEGORY=P.IDCATEGORY GROUP BY C.NAME ORDER BY C.NAME"];
        }

        public void insertCategorias(Categorias C) {
             Boolean creado = false;
            Decimal existe = (Decimal)conector.DLookUp("COUNT(IDCATEGORY)", "CATEGORIES", "NAME=UPPER('" + C.name + "') AND DELETED =0");

            if (existe == 0)
            {
                Decimal numCate = (Decimal)conector.DLookUp("COUNT(IDCATEGORY)", "CATEGORIES", "");
                Decimal idCategoria;
                if (numCate == 0)
                {
                    idCategoria = 0;

                }
                else
                {
                    idCategoria = (Decimal)conector.DLookUp("MAX(IDCATEGORY)", "CATEGORIES", "");
                }


                String sentencia1 = "INSERT INTO CATEGORIES VALUES(" + (idCategoria + 1) + ",UPPER('" + C.name + "'),0)";
                conector.setData(sentencia1);

                

                existe = (Decimal)conector.DLookUp("COUNT(IDCATEGORY)", "CATEGORIES", "NAME=UPPER('" + C.name + "') AND IDCATEGORY =" + (idCategoria + 1) );

                if (existe > 0)
                {
                    VentanaPersonalizada vp = new VentanaPersonalizada("Se ha añadido correctamente");
                    vp.ShowDialog();
                }
            }
            else
            {


                VentanaPersonalizada vp = new VentanaPersonalizada("Ya existe esa categoria");
                vp.ShowDialog();
            }
          

        }

        public void updateCategorias(Categorias C) {
            Decimal id = (Decimal)conector.DLookUp("IDCATEGORY", "CATEGORIES", "NAME=UPPER('" + FormPrincipal.nombreviejoCategoria + "')");
            Decimal existe = (Decimal)conector.DLookUp("COUNT(IDCATEGORY)", "CATEGORIES", "NAME=UPPER('" + C.name + "') AND DELETED = 0");
            if (existe == 0)
            {
               
               conector.setData("UPDATE CATEGORIES SET NAME=UPPER('" + C.name + "') WHERE IDCATEGORY=" + id);
                VentanaPersonalizada vp = new VentanaPersonalizada("Se ha actualizado correctamente");
                vp.ShowDialog();
            }
            else {
                VentanaPersonalizada vp = new VentanaPersonalizada("Ya existe esa categoria");
                vp.ShowDialog();
            }
            
        }
        public void deleteCategoria(Categorias C) {
            
             conector.setData("UPDATE CATEGORIES SET DELETED=1 WHERE NAME=UPPER('"+ C.name + "')");
        }
        public void refrescarCategorias(ComboBox cmbCategorias)
        {
            Decimal numCate = (Decimal)conector.DLookUp("MAX(IDCATEGORY)", "CATEGORIES", "");
            //int numRoles = int.Parse(numR);

            listaCat = new LinkedList<Object>();
            
            for (int i = 1; i <= numCate; i++)
            {
                listaCat.AddLast(conector.DLookUp("NAME", "CATEGORIES", " IDCATEGORY=" + i));
            }

            cmbCategorias.Items.Clear();
            int cont = 0;
            while (cont < listaCat.Count)
            {
                cmbCategorias.Items.Add(listaCat.ElementAt(cont));
                cont++;
            }
            cmbCategorias.SelectedIndex = 0;
        }



    }

}
