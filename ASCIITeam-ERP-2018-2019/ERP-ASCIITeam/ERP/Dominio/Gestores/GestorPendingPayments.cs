using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio.Gestores
{
    class GestorPendingPayments
    {

        public DataTable tPPayments { get; set; }
        ConnectOracle conector;

        public GestorPendingPayments()
        {
            this.tPPayments = new DataTable();
            this.conector = new ConnectOracle();
            readPendingPayments("", "", 0, null, null, -1, -1);
        }

        //public string[] getSources()
        //{
        //    Object numSources = conector.DLookUp("COUNT(ID)", "SOURCES_TARGETS", "ID < 1000");
        //    String query = "select description from SOURCES_TARGETS where id < " + numSources;
        //    DataSet data = conector.getData(query, "SOURCES_TARGETS");
        //    return data.Tables[0].AsEnumerable().Select(r => r.Field<string>("description")).ToArray();
        //}

        //public string[] getTypes()
        //{
        //    String query = "select description from TYPES_INCOME";
        //    DataSet data = conector.getData(query, "TYPES_INCOME");
        //    return data.Tables[0].AsEnumerable().Select(r => r.Field<string>("description")).ToArray();
        //}


        public void readPendingPayments(string concept, string oper, decimal amount, string start, string end, decimal source, decimal type)
        {
            StringBuilder query = new StringBuilder("Select p.id, p.ppdate, u.name, t.description, p.description, p.amount from PPAYMENTS p inner join users u on p.refuser=u.iduser inner join TYPES_PPAYMENT t on p.reftype=t.id where PAID='0'");
            if (!concept.ToString().Equals(""))
            {
                query.Append(" and upper(i.description) like '%" + concept.ToUpper() + "%'");
            }

            if (!oper.Equals(""))
            {
                query.Append(" and i.amount" + oper + "'" + amount + "'");
            }

            if (start != null)
            {
                query.Append(" and i.ie_date>='" + start.Substring(0, 10) + "'");
            }
            if (end != null)
            {
                query.Append(" and i.ie_date<='" + end.Substring(0, 10) + "'");
            }
            if (source >= 0)
            {
                query.Append(" and i.refst='" + source + "'");
            }
            if (type >= 0)
            {
                query.Append(" and i.reftype='" + type + "'");
            }
            query.Append(" order by id desc");
            //Debug.WriteLine("-------------------------------------------------"+query.ToString());
            DataSet data = conector.getData(query.ToString(), "PPAYMENTS p inner join users u on p.refuser=u.iduser inner join TYPES_PPAYMENT t on p.reftype=t.id");
            tPPayments = data.Tables[0];
            tPPayments.Columns[0].ColumnName = "ID";
            tPPayments.Columns[1].ColumnName = "DATE";
            tPPayments.Columns[2].ColumnName = "USER";
            tPPayments.Columns[3].ColumnName = "TYPE";
            tPPayments.Columns[4].ColumnName = "DESCRIPTION";
            tPPayments.Columns[5].ColumnName = "AMOUNT";
        }
    }
}
