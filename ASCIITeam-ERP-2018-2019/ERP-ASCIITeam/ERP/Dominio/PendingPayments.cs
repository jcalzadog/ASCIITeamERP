using ERP.Dominio.Gestores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio
{
    class PendingPayments
    {
        public Decimal id { get; set; }
        public DateTime ppdate { get; set; }
        public Decimal refUser { get; set; }
        public Decimal refType { get; set; }
        public String description { get; set; }
        public Decimal amount { get; set; }
        public Decimal paid { get; set; }
        public GestorPendingPayments gestorPendingPayments { get; set; }

        public PendingPayments()
        {
            this.gestorPendingPayments = new GestorPendingPayments();
        }

        public PendingPayments(decimal id, DateTime date, decimal refUser, decimal refType, string description, decimal amount, decimal paid)
        {
            this.id = id;
            this.ppdate = date;
            this.refUser = refUser;
            this.refType = refType;
            this.description = description;
            this.amount = amount;
            this.paid = paid;
            this.gestorPendingPayments = new GestorPendingPayments();
        }
    }
}
