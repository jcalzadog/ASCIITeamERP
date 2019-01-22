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
       
        public DataTable tValidation { get; set; }
        public GestorValidation() {
            this.conector = new ConnectOracle();
            tValidation = new DataTable();
            readValidation();
        }

        public void readValidation() {
            
            DataSet data = conector.getData("SELECT v.id,v.validation_date, u.name, v.a_incash, v.a_receipt, v.a_check, v.total from validations v inner join users u on v.refuser=u.iduser order by id desc", "validations v inner join users u on v.refuser=u.iduser order by id desc");
            tValidation = data.Tables[0];
            tValidation.Columns[0].ColumnName = "ID";
            tValidation.Columns[1].ColumnName = "VALIDATION DATE";
            tValidation.Columns[2].ColumnName = "USER";
            tValidation.Columns[3].ColumnName = "IN CASH";
            tValidation.Columns[4].ColumnName = "RECEIPT";
            tValidation.Columns[5].ColumnName = "CHECK";
            tValidation.Columns[6].ColumnName = "TOTAL";
        }

        public void newValidation(Validation v)
        {
            decimal cantVali = (decimal)conector.DLookUp("COUNT(id)", "validations", "");
            decimal idV;
            if (cantVali == 0)
            {
                idV = 1;

            }
            else
            {
                idV = (decimal)conector.DLookUp("MAX(id)", "validations", "");
                idV++;
            }
            conector.setData("INSERT INTO validations VALUES ('" + idV + "', '" + v.validation_date.ToString().Substring(0, 10)
                + "','" + v.refUser + "','" + v.a_incash + "', '" + v.a_receipt + "', '"+ v.a_check + "', '" + v.total+ "')");
        }

    }
}
