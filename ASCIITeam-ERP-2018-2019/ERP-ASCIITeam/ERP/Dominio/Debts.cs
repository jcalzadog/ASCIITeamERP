using ERP.Dominio.Gestores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio
{
    class Debts
    {
        public Decimal id { get; set; }
        public DateTime ddate { get; set; }
        public Decimal refUser { get; set; }
        public String description { get; set; }
        public Decimal amount { get; set; }
        public Decimal paid { get; set; }
        public GestorDebts gestorDebts { get; set; }

        public Debts()
        {
            this.gestorDebts = new GestorDebts();
        }

        public Debts(decimal id, DateTime date, decimal refUser, string description, decimal amount, decimal paid)
        {
            this.id = id;
            this.ddate = date;
            this.refUser = refUser;
            this.description = description;
            this.amount = amount;
            this.paid = paid;
            this.gestorDebts = new GestorDebts();
        }
    }
}
