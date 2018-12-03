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
        public DataTable tabla { get; set; }
        public GestorCategorias() {
            conector = new ConnectOracle(); 
            tabla = new DataTable();
        }

        public void readCategorias() {
            DataSet data = new DataSet();
            // data = conector.getData("SELECT * FROM CATEGORIES WHERE DELETED = 0 ORDER BY IDCATEGORY", "CATEGORIES");
            data = conector.getData("SELECT C.NAME NAME, COUNT(P.IDPRODUCT) CUENTA FROM CATEGORIES C LEFT OUTER JOIN PRODUCTS P ON C.IDCATEGORY=P.IDCATEGORY WHERE C.DELETED = 0 GROUP BY C.NAME", "CATEGORIES C LEFT OUTER JOIN PRODUCTS P ON C.IDCATEGORY=P.IDCATEGORY GROUP BY C.NAME");
            tabla = data.Tables["CATEGORIES C LEFT OUTER JOIN PRODUCTS P ON C.IDCATEGORY=P.IDCATEGORY GROUP BY C.NAME"];
        }

        public void insertCategorias(String name) {
             Boolean creado = false;
            Decimal existe = (Decimal)conector.DLookUp("COUNT(IDCATEGORY)", "CATEGORIES", "NAME='" + name + "' AND DELETED =0");

            if (existe == 0)
            {
                Decimal idCategoria = (Decimal)conector.DLookUp("MAX(IDCATEGORY)", "CATEGORIES", "");
               
               

                String sentencia1 = "INSERT INTO CATEGORIES VALUES(" + (idCategoria + 1) + ",'" + name + "',0)";
                conector.setData(sentencia1);

                

                existe = (Decimal)conector.DLookUp("COUNT(IDCATEGORY)", "CATEGORIES", "NAME='" + name + "' AND IDCATEGORY =" + (idCategoria + 1) );

                if (existe > 0)
                {
                    MessageBox.Show("La categoria se ha añadido correctamente.");
                    creado = true;
                }
            }
            else
            {
               
               
                MessageBox.Show("Esa categoria ya existe");
            }
          

        }

        public void updateCategorias(String name) {
            Decimal id = (Decimal)conector.DLookUp("IDCATEGORY", "CATEGORIES", "NAME='" + FormPrincipal.nombreviejo + "'");
            Decimal existe = (Decimal)conector.DLookUp("COUNT(IDCATEGORY)", "CATEGORIES", "NAME='" + name + "' AND DELETED = 0");
            if (existe == 0)
            {
               
               conector.setData("UPDATE CATEGORIES SET NAME=UPPER('" + name + "') WHERE IDCATEGORY=" + id);
            }
            else {
                MessageBox.Show("Esa categoria ya existe");
            }
            
        }
        public void deleteCategoria(String name) {
            
             conector.setData("UPDATE CATEGORIES SET DELETED=1 WHERE NAME=UPPER('"+name+"')");
        }
     


        }

}
