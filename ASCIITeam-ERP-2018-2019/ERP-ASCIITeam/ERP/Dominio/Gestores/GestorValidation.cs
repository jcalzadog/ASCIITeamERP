using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio.Gestores
{
    class GestorValidation
    {
        ConnectOracle conector;
       
        public DataTable tabla { get; set; }
        public GestorValidation() {
            this.conector = new ConnectOracle();
            tabla = new DataTable();
        }

        public void cargarValidation() {
            
            DataSet data = conector.getData("SELECT v.id,v.validation_date, u.user,  from validations v inner join users u on v.refuser=u.iduser ", "");
            tabla = data.Tables[0];
            tabla.Columns[0].ColumnName = "ID";
            tabla.Columns[1].ColumnName = "VALIDATION DATE";
            tabla.Columns[2].ColumnName = "USER";
            tabla.Columns[3].ColumnName = "IN CASH";
            tabla.Columns[4].ColumnName = "RECEIPT";
            tabla.Columns[5].ColumnName = "CHECK";
            tabla.Columns[6].ColumnName = "TOTAL";
        }


    }
}
