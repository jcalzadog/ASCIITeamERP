using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Dominio.Gestores
{
    class GestorIncomes
    {
        public DataTable tIncomes { get; set; }
        ConnectOracle conector;

        public GestorIncomes()
        {
            this.tIncomes = new DataTable();
            this.conector = new ConnectOracle();
            readIncomes("", "", 0, null, null, -1, -1);
        }

        public string[] getSources()
        {
            Object numSources = conector.DLookUp("COUNT(ID)", "SOURCES_TARGETS", "ID < 1000");
            String query = "select description from SOURCES_TARGETS where id < "+ numSources;
            DataSet data = conector.getData(query, "SOURCES_TARGETS");
            return data.Tables[0].AsEnumerable().Select(r => r.Field<string>("description")).ToArray();
        }

        public string[] getTypes()
        {
            String query = "select description from TYPES_INCOME";
            DataSet data = conector.getData(query, "TYPES_INCOME");
            return data.Tables[0].AsEnumerable().Select(r => r.Field<string>("description")).ToArray();
        }


        public void readIncomes(string concept, string oper, decimal amount, string start, string end, decimal source, decimal type)
        {
            StringBuilder query = new StringBuilder("Select i.id, i.ie_date, u.name, s.description, t.description, i.description, i.amount from incomes_expenses i inner join users u " +
               "on i.refuser=u.iduser inner join sources_targets s on i.refst=s.id inner join types_income t on i.reftype=t.id where refaction='0'");
            if (!concept.ToString().Equals(""))
            {
                query.Append(" and upper(i.description) like '%" + concept.ToUpper() + "%'");
            }

            if (!oper.Equals(""))
            {
                query.Append(" and i.amount"+oper+"'" + amount+"'");
            }
            
            if (start != null)
            {
                query.Append(" and i.ie_date>='" + start.Substring(0,10) + "'");
            }
            if (end != null)
            {
                query.Append(" and i.ie_date<='" + end.Substring(0,10) + "'");
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
            DataSet data = conector.getData(query.ToString(), "incomes_expenses i inner join users u on i.refuser=u.iduser inner join sources_targets t on i.refst=t.id inner join types_income t on i.reftype=t.id");
            tIncomes = data.Tables[0];
            tIncomes.Columns[0].ColumnName = "ID";
            tIncomes.Columns[1].ColumnName = "DATE";
            tIncomes.Columns[2].ColumnName = "USER";
            tIncomes.Columns[3].ColumnName = "SOURCE";
            tIncomes.Columns[4].ColumnName = "TYPE";
            tIncomes.Columns[5].ColumnName = "DESCRIPTION";
            tIncomes.Columns[6].ColumnName = "AMOUNT";
        }

        public void newIncome (Income i)
        {
            decimal cantIncomes = (decimal)conector.DLookUp("COUNT(id)", "incomes_expenses", "");
            decimal idIncome;
            if (cantIncomes == 0)
            {
                idIncome = 1;

            }
            else
            {
                idIncome = (decimal)conector.DLookUp("MAX(id)", "incomes_expenses", "");
                idIncome++;
            }
            //MessageBox.Show(i.Amount.ToString());
            conector.setData("INSERT INTO incomes_expenses VALUES ('" + idIncome + "', '" + i.Income_date.ToString().Substring(0,10) 
                + "','"+i.RefUser+"','" + i.RefSt + "', '" + i.RefType + "', '"
                +i.Description.Replace('\'',' ').PadRight(60,' ').Substring(0,60).Trim()+"', '" 
                + i.Amount + "', '0','0')");
        }

        public decimal getTotal()
        {
            return (decimal)conector.DLookUp("NVL(SUM(AMOUNT),0)", "INCOMES_EXPENSES", "REFACTION='0'"); 
        }
        public decimal getTotalChecks()
        {
            decimal idType = (decimal)conector.DLookUp("id", "types_income", "description='Check'");
            return (decimal)conector.DLookUp("NVL(SUM(AMOUNT),0)", "INCOMES_EXPENSES", "REFACTION='0' and reftype='" + idType + "'");             
        }
        public decimal getTotalCash()
        {
            decimal idType = (decimal)conector.DLookUp("id", "types_income", "description='Cash'");
            return (decimal)conector.DLookUp("NVL(SUM(AMOUNT),0)", "INCOMES_EXPENSES", "REFACTION='0' and reftype='" + idType + "'"); 
        }
        public decimal getTotalReceipts()
        {
            decimal idType = (decimal)conector.DLookUp("id", "types_income", "description='Receipt'");
            return (decimal)conector.DLookUp("NVL(SUM(AMOUNT),0)", "INCOMES_EXPENSES", "REFACTION='0' and reftype='" + idType + "'");
        }

        public void deleteIncome (Decimal id, Decimal userID)
        {
            Decimal amount = (Decimal)conector.DLookUp("nvl(amount,0)", "incomes_expenses", "id='" + id + "'");
            bool isRevoked = (decimal)conector.DLookUp("nvl(revoked,0)", "incomes_expenses", "id='" + id + "'")!=0;

            string description = (string)conector.DLookUp("description", "incomes_expenses", "id='" + id + "'")+" -REVOKED";
            amount = -amount;
            Decimal source=(Decimal) conector.DLookUp("refst","incomes_expenses","id='"+id+"'");
            Decimal type = (Decimal)conector.DLookUp("reftype", "incomes_expenses", "id='" + id + "'");
            if (isRevoked || amount>0)
            {
                MessageBox.Show("Error! You cannot revoke the selected income, it's revoked yet!");
            }
            else
            {
                conector.setData("update incomes_expenses set revoked='1' where id='" + id + "'");
                newIncome(new Income(0, DateTime.Now, userID, source, type, description, amount));
            }
            
        }
    }
}
