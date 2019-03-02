using ERP.Dominio.Gestores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio
{
    class Invoicees
    {
        public GestorInvoices gestor { get; set; }
        public Invoicees() {
            this.gestor = new GestorInvoices();
        }
    }
}
