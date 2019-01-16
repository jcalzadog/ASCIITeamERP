using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio.Gestores
{
    class GestorIncomes
    {
        public DataTable tIncomes { get; set; }
        ConnectOracle conector;

        public GestorIncomes()
        {
            this.tIncomes =new DataTable();
            this.conector = new ConnectOracle();
        }


        public void readIncomes(String concept, String oper, Decimal amount, DateTime start, DateTime end, Decimal source, Decimal type)
        {
            StringBuilder query = new StringBuilder( "i.Select id, i.ie_date, u.name, s.description, i.amount where refaction=0");
            if (!concept.ToString().Equals(""))
            {
                query.Append("and ");
            }
        }
    }
}
