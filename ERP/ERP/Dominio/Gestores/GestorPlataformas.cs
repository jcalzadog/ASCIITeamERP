using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio.Gestores
{
    class GestorPlataformas
        
    {
        ConnectOracle conector;
        public DataTable tabla { get; set; }
        public GestorPlataformas() {
            tabla = new DataTable();
            conector = new ConnectOracle();
        }
        public void readPlatforms()
        {
            DataSet data = new DataSet();
            data = conector.getData("SELECT L.NAME NAME, COUNT(P.IDPRODUCT) CUENTA FROM PLATFORMS L LEFT OUTER JOIN PRODUCTS P ON L.IDPLATFORM=P.IDPLATFORM WHERE L.DELETED=0 GROUP BY L.NAME",
                "PLATFORMS L LEFT OUTER JOIN PRODUCTS P ON L.IDPLATFORM=P.IDPLATFORM WHERE L.DELETED=0 GROUP BY L.NAME");
            tabla = data.Tables["PLATFORMS L LEFT OUTER JOIN PRODUCTS P ON L.IDPLATFORM=P.IDPLATFORM WHERE L.DELETED=0 GROUP BY L.NAME"];
        }
    }
}
