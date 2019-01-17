using ERP.Dominio.Gestores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio
{
    class Income
    {
        Decimal id;
        DateTime income_date;
        Decimal refUser;
        Decimal refSt;
        Decimal refType;
        String description;
        Decimal amount;
        public GestorIncomes gestorIncome { get; set; }

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

        public DateTime Income_date
        {
            get
            {
                return income_date;
            }

            set
            {
                income_date = value;
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

        public Income()
        {
            this.gestorIncome = new GestorIncomes();
        }

        public Income(decimal id, DateTime income_date, decimal refUser, decimal refSt, decimal refType, string description, decimal amount)
        {
            this.Id = id;
            this.Income_date = income_date;
            this.RefUser = refUser;
            this.RefSt = refSt;
            this.RefType = refType;
            this.Description = description;
            this.Amount = amount;
            this.gestorIncome = new GestorIncomes();
        }
    }
}
