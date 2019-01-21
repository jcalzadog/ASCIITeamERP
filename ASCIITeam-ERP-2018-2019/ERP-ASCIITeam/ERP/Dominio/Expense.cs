using ERP.Dominio.Gestores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio
{
    public class Expense
    {
        Decimal id;
        DateTime expense_date;
        Decimal refUser;
        Decimal refSt;
        Decimal refType;
        String description;
        Decimal amount;
        public GestorExpenses gestorExpense { get; set; }
        public Expense() {
            gestorExpense = new GestorExpenses();
        }
        public Expense(decimal id, DateTime expense_date, decimal refUser, decimal refSt, decimal refType, string description, decimal amount)
        {
            this.Id = id;
            this.Expense_Date = expense_date;
            this.RefUser = refUser;
            this.RefSt = refSt;
            this.RefType = refType;
            this.Description = description;
            this.Amount = amount;
            this.gestorExpense = new GestorExpenses();
        }
        public decimal Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public DateTime Expense_Date
        {
            get
            {
                return expense_date;
            }

            set
            {
                expense_date = value;
            }
        }

        public decimal RefUser
        {
            get
            {
                return refUser;
            }

            set
            {
                refUser = value;
            }
        }

        public decimal RefSt
        {
            get
            {
                return refSt;
            }

            set
            {
                refSt = value;
            }
        }

        public decimal RefType
        {
            get
            {
                return refType;
            }

            set
            {
                refType = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public decimal Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

    
    }
}
