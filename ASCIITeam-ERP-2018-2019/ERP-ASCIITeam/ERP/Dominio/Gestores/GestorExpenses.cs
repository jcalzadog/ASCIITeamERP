﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Dominio.Gestores
{
    class GestorExpenses
    {
        public DataTable tExpenses { get; set; }
        ConnectOracle conector;
        public GestorExpenses()
            {
            this.tExpenses = new DataTable();
            this.conector = new ConnectOracle();
            readExpenses("", "", 0, null, null, -1, -1);
    }
        public void readExpenses(String concept, String oper, Decimal amount, Object start, Object end, Decimal source, Decimal type)
        {
            StringBuilder query = new StringBuilder("Select i.id, i.ie_date, u.name, s.description, t.description, i.description, i.amount from incomes_expenses i inner join users u " +
               "on i.refuser=u.iduser inner join sources_targets s on i.refst=s.id inner join types_income t on i.reftype=t.id where refaction='1'");
            if (!concept.ToString().Equals(""))
            {
                query.Append(" and upper(i.description) like %'" + concept.ToUpper() + "%'");
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
                query.Append(" and i.ie_date>='" + (DateTime)start + "'");
            }
            if (end != null)
            {
                query.Append(" and i.ie_date<='" + (DateTime)end + "'");
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
            tExpenses = data.Tables[0];
            tExpenses.Columns[0].ColumnName = "ID";
            tExpenses.Columns[1].ColumnName = "DATE";
            tExpenses.Columns[2].ColumnName = "USER";
            tExpenses.Columns[3].ColumnName = "TARGET";
            tExpenses.Columns[4].ColumnName = "TYPE";
            tExpenses.Columns[5].ColumnName = "DESCRIPTION";
            tExpenses.Columns[6].ColumnName = "AMOUNT";
        }

        public void refrescarTargets(ComboBox cmbTargets)
        {
            Decimal numTargets = (Decimal)conector.DLookUp("COUNT(ID)", "SOURCES_TARGETS", "ID >= 1000");
            //int numRoles = int.Parse(numR);

            LinkedList<Object> listaTarget = new LinkedList<Object>();
            
            for (int i = 1000; i < (1000+numTargets); i++)
            {
                listaTarget.AddLast(conector.DLookUp("DESCRIPTION", "SOURCES_TARGETS", " ID=" + i));
            }

            cmbTargets.Items.Clear();
            cmbTargets.Items.Add("-TARGETS-");
            for (int i = 0; i < listaTarget.Count; i++)
            {
                cmbTargets.Items.Add(listaTarget.ElementAt(i));
            }
                
            
            cmbTargets.SelectedIndex = 0;
        }

        public void refrescarTypes(ComboBox cmbTypes)
        {
            Decimal numTypes = (Decimal)conector.DLookUp("COUNT(ID)", "TYPES_PPAYMENT", "");
            //int numRoles = int.Parse(numR);

            LinkedList<Object> listaTypes = new LinkedList<Object>();

            for (int i = 0; i < numTypes; i++)
            {
                listaTypes.AddLast(conector.DLookUp("DESCRIPTION", "TYPES_PPAYMENT", " ID=" + i));
            }

            cmbTypes.Items.Clear();
            cmbTypes.Items.Add("-TYPES-");
            for (int i = 0; i < listaTypes.Count; i++)
            {
                cmbTypes.Items.Add(listaTypes.ElementAt(i));
            }


            cmbTypes.SelectedIndex = 0;
        }


        public decimal getTotal()
        {
            return (decimal)conector.DLookUp("NVL(SUM(AMOUNT),0)", "INCOMES_EXPENSES", "REFACTION='1'"); 
        }
        public decimal getTotalChecks()
        {
            decimal idType = (decimal)conector.DLookUp("id", "types_income", "description='Check'");
            return (decimal)conector.DLookUp("NVL(SUM(AMOUNT),0)", "INCOMES_EXPENSES", "REFACTION='1' and reftype='" + idType + "'");
            
            
        }
        public decimal getTotalCash()
        {
            decimal idType = (decimal)conector.DLookUp("id", "types_income", "description='Cash'");
            return (decimal)conector.DLookUp("NVL(SUM(AMOUNT),0)", "INCOMES_EXPENSES", "REFACTION='1' and reftype='" + idType + "'");

        }
        public decimal getTotalReceipts()
        {
            decimal idType = (decimal)conector.DLookUp("id", "types_income", "description='Receipt'");
            return (decimal)conector.DLookUp("NVL(SUM(AMOUNT),0)", "INCOMES_EXPENSES", "REFACTION='1' and reftype='" + idType + "'");
        }
    }
}
