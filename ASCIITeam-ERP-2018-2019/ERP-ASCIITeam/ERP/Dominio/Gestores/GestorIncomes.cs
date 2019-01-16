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
            readIncomes("", "", 0, null, null, -1, -1);
        }


        public void readIncomes(String concept, String oper, Decimal amount, Object start, Object end, Decimal source, Decimal type)
        {
            StringBuilder query = new StringBuilder( "Select i.id, i.ie_date, u.name, s.description, t.description, i.description, i.amount from incomes_expenses i inner join users u "+
               "on i.refuser=u.iduser inner join sources_targets s on i.refst=s.id inner join types_income t on i.reftype=t.id where refaction='0'");
            if (!concept.ToString().Equals(""))
            {
                query.Append(" and upper(i.description) like %'"+concept.ToUpper()+"%'");
            }

            if (oper.Equals(">"))
            {
                query.Append(" and i.amount>'" + amount + "'");
            }
            if (oper.Equals("<"))
            {
                query.Append(" and i.amount<'" + amount + "'");
            }
            if (oper.Equals("="))
            {
                query.Append(" and i.amount='" + amount + "'");
            }
            if (start != null)
            {
                query.Append(" and i.ie_date>='" + (DateTime)start+"'");
            }
            if (end != null)
            {
                query.Append(" and i.ie_date<='" +(DateTime) end + "'");
            }
            if (source >= 0)
            {
                query.Append(" and i.refst='" + source + "'");
            }
            if (type >= 0)
            {
                query.Append(" and i.reftype='" + type + "'");
            }
            DataSet data = conector.getData(query.ToString(), "incomes_expenses i inner join users u on i.refuser=u.iduser inner join sources_targets t on i.refst=t.id inner join types_income t on i.reftype=t.id");
            tIncomes = data.Tables[0];
            tIncomes.Columns[0].ColumnName = "ID";
            tIncomes.Columns[1].ColumnName = "DATE";
            tIncomes.Columns[2].ColumnName = "USER";
            tIncomes.Columns[3].ColumnName = "TARGET";
            tIncomes.Columns[4].ColumnName = "TYPE";
            tIncomes.Columns[5].ColumnName = "DESCRIPTION";
            tIncomes.Columns[6].ColumnName = "AMOUNT";
        }
    }
}
