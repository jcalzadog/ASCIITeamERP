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
            readPendingPayments("", "", 0, null, null, -1);
        }

        public decimal getAmount(decimal id)
        {
            return Convert.ToDecimal(conector.DLookUp("AMOUNT", "PPAYMENTS", "ID="+id));
        }

        public DateTime getDate(decimal id)
        {
            return Convert.ToDateTime(conector.DLookUp("PPDATE", "PPAYMENTS", "ID=" + id));
        }

        public string getConcept(decimal id)
        {
            return Convert.ToString(conector.DLookUp("DESCRIPTION", "PPAYMENTS", "ID=" + id));
        }

        public string[] getTypes()
        {
            String query = "select description from TYPES_PPAYMENT";
            DataSet data = conector.getData(query, "TYPES_PPAYMENT");
            return data.Tables[0].AsEnumerable().Select(r => r.Field<string>("description")).ToArray();
        }


        public void readPendingPayments(string concept, string oper, decimal amount, string start, string end, decimal type)
        {
            StringBuilder query = new StringBuilder("Select p.id, p.ppdate, u.name, t.description, p.description, p.amount from PPAYMENTS p inner join users u on p.refuser=u.iduser inner join TYPES_PPAYMENT t on p.reftype=t.id where PAID='0'");
            if (!concept.ToString().Equals(""))
            {
                query.Append(" and upper(p.description) like '%" + concept.ToUpper() + "%'");
            }

            if (!oper.Equals(""))
            {
                query.Append(" and p.amount" + oper + "'" + amount + "'");
            }

            if (start != null)
            {
                query.Append(" and p.ppdate>='" + start.Substring(0, 10) + "'");
            }
            if (end != null)
            {
                query.Append(" and p.ppdate<='" + end.Substring(0, 10) + "'");
            }
            if (type >= 0)
            {
                query.Append(" and p.reftype='" + type + "'");
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

        public void newPendingPayment(PendingPayments p)
        {
            decimal cantPPaym = (decimal)conector.DLookUp("COUNT(id)", "PPAYMENTS", "");
            decimal idPPaym;
            if (cantPPaym == 0)
            {
                idPPaym = 1;

            }
            else
            {
                idPPaym = (decimal)conector.DLookUp("MAX(id)", "PPAYMENTS", "");
                idPPaym++;
            }
            conector.setData("INSERT INTO PPAYMENTS VALUES ('" + idPPaym + "', '" + p.ppdate.ToString().Substring(0, 10)
                + "','" + p.refUser + "','"+ p.refType + "', '"
                + p.description.Replace('\'', ' ').PadRight(60, ' ').Substring(0, 60).Trim() + "', '"
                + p.amount + "','0')");
        }

        public void updatePendingPaymentParcial(PendingPayments p)
        {
            conector.setData("UPDATE PPAYMENTS SET AMOUNT='"+p.amount+"' WHERE ID="+p.id);
        }

        public void updatePendingPaymentTotal(PendingPayments p)
        {
            conector.setData("UPDATE PPAYMENTS SET AMOUNT=" + p.amount + ",PAID=1 WHERE ID=" + p.id);
        }
    }
}
