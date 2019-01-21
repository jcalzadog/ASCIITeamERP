using ERP.Dominio.Gestores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio
{
    class Validation
    {
        public Decimal id;
        public DateTime validation_date;
        public Decimal refUser;
        public Decimal a_incash;
        public Decimal a_receipt;
        public Decimal a_check;
        public Decimal total;
        public GestorValidation gestorValidation { get; set; }

        public Validation()
        {
            this.gestorValidation = new GestorValidation();
        }

        public Validation(decimal id, DateTime validation_date, Decimal refUser, Decimal a_incash, Decimal a_receipt, Decimal a_check, Decimal total)
        {
            this.id = id;
            this.validation_date = validation_date;
            this.refUser = refUser;
            this.a_incash = a_incash;
            this.a_receipt = a_receipt;
            this.a_check = a_check;
            this.total = total;
            this.gestorValidation = new GestorValidation();
        }
    }
}
