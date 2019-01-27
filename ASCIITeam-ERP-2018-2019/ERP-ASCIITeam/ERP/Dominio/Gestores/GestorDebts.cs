using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio.Gestores
{
    class GestorDebts
    {
        public DataTable tDebts { get; set; }
        ConnectOracle conector;

        public GestorDebts()
        {
            this.tDebts = new DataTable();
            this.conector = new ConnectOracle();
            readDebts("", "", 0, null, null);
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


        public void readDebts(string concept, string oper, double amount, string start, string end)
        {
            StringBuilder query = new StringBuilder("Select d.id, d.ddate, u.name, d.description, d.amount from DEBTS d inner join users u on d.refuser=u.iduser where PAID='0'");
            if (!concept.ToString().Equals(""))
            {
                query.Append(" and upper(d.description) like '%" + concept.ToUpper() + "%'");
            }

            if (!oper.Equals(""))
            {
                query.Append(" and d.amount" + oper + "'" + amount + "'");
            }

            if (start != null)
            {
                query.Append(" and d.ddate>='" + start.Substring(0, 10) + "'");
            }
            if (end != null)
            {
                query.Append(" and d.ddate<='" + end.Substring(0, 10) + "'");
            }
            query.Append(" order by id desc");
            //Debug.WriteLine("-------------------------------------------------"+query.ToString());
            DataSet data = conector.getData(query.ToString(), "DEBTS d inner join users u on p.refuser=u.iduser where PAID='0'");
            tDebts = data.Tables[0];
            tDebts.Columns[0].ColumnName = "ID";
            tDebts.Columns[1].ColumnName = "DATE";
            tDebts.Columns[2].ColumnName = "USER";
            tDebts.Columns[3].ColumnName = "DESCRIPTION";
            tDebts.Columns[4].ColumnName = "AMOUNT";
        }

        public void newDebt(Debts d) {
            
            decimal cantDebts = (decimal)conector.DLookUp("COUNT(id)", "DEBTS", "");
            decimal idDebts;
            if (cantDebts == 0)
            {
                idDebts = 1;

            }
            else
            {
                idDebts = (decimal)conector.DLookUp("MAX(id)", "DEBTS", "");
                idDebts++;
            }
            conector.setData("INSERT INTO DEBTS VALUES('" + idDebts+ "', '" + d.ddate.ToString().Substring(0, 10)
                + "','" + d.refUser + "', '"
                + d.description.Replace('\'', ' ').PadRight(60, ' ').Substring(0, 60).Trim() + "', '"
                + d.amount + "','0')");



        }

        public decimal getAmount(decimal id)
        {
            return Convert.ToDecimal(conector.DLookUp("AMOUNT", "DEBTS", "ID=" + id));
        }

        public DateTime getDate(decimal id)
        {
            return Convert.ToDateTime(conector.DLookUp("DDATE", "DEBTS", "ID=" + id));
        }

        public string getConcept(decimal id)
        {
            return Convert.ToString(conector.DLookUp("DESCRIPTION", "DEBTS", "ID=" + id));
        }

        public void updateDebtsTotal(Debts d)
        {
            conector.setData("UPDATE DEBTS SET AMOUNT=" + d.amount + ",PAID=1 WHERE ID=" + d.id);
        }

        public void updatePendingPaymentParcial(Debts d)
        {
            conector.setData("UPDATE DEBTS SET AMOUNT='" + d.amount + "' WHERE ID=" + d.id);
        }
    }
}
