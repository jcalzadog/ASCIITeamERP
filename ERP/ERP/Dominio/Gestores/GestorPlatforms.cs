using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Dominio.Gestores
{
    class GestorPlatforms
    {
        ConnectOracle conector;
        public DataTable tabla { get; set; }
        public GestorPlatforms()
        {
            conector = new ConnectOracle();
            tabla = new DataTable();
        }

        public void readPlatforms()
        {
            DataSet data = new DataSet();
            data = conector.getData("SELECT L.NAME NAME, COUNT(P.IDPRODUCT) CUENTA FROM PLATFORMS L LEFT OUTER JOIN PRODUCTS P ON L.IDPLATFORM=P.IDPLATFORM WHERE L.DELETED=0 GROUP BY L.NAME",
                "PLATFORMS L LEFT OUTER JOIN PRODUCTS P ON L.IDPLATFORM=P.IDPLATFORM WHERE L.DELETED=0 GROUP BY L.NAME");
            tabla = data.Tables["PLATFORMS L LEFT OUTER JOIN PRODUCTS P ON L.IDPLATFORM=P.IDPLATFORM WHERE L.DELETED=0 GROUP BY L.NAME"];
        }

        public void insertPlatform(String name)
        {
            bool created = false;
            Decimal platformExists = (Decimal)conector.DLookUp("COUNT(IDPLATFORM)", "PLATFORMS", "NAME='" + name + "' AND DELETED =0");

            if (platformExists == 0)
            {

                Decimal idPlatform = (Decimal)conector.DLookUp("MAX(IDPLATFORM)", "PLATFORMS", "");



                String sentencia1 = "INSERT INTO PLATFORMS VALUES(" + (idPlatform + 1) + ",'" + name + "',0)";
                conector.setData(sentencia1);



                platformExists = (Decimal)conector.DLookUp("COUNT(idplatform)", "platforms", "NAME='" + name + "' AND idplatform =" + (idPlatform + 1));

                if (platformExists > 0)
                {
                    MessageBox.Show("La plataforma se ha añadido correctamente.");
                    created = true;
                }
            }
            else
            {


                MessageBox.Show("Esa plataforma ya existe");
            }


        }

        public void updatePlatform(String name)
        {
            Decimal id = (Decimal)conector.DLookUp("IDPLATFORM", "PLATFORMS", "NAME='" + FormPrincipal.nombreviejo + "'"); 
            Decimal exists = (Decimal)conector.DLookUp("COUNT(IDPLATFORM)", "PLATFORMS", "NAME='" + name + "' AND DELETED = 0");
            if (exists == 0)
            {

                conector.setData("UPDATE platforms SET NAME=UPPER('" + name + "') WHERE IDPLATFORM=" + id);
            }
            else
            {
                MessageBox.Show("Can't add the platform because it already exists");
            }

        }
        public void deletePlatform(String name)
        {

            conector.setData("UPDATE PLATFORMS SET DELETED=1 WHERE NAME=UPPER('" + name + "')");
        }



    }
}

