using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio
{
    class LinesInvoices
    {
        public int id;
        public string description;
        public int amount;
        public float price;
        public int refinvoice;
        public int deleted;
        public LinesInvoices(int id, string description, int amount, float price, int refinvoice) {
            this.id = id;
            this.description = description;
            this.amount = amount;
            this.price = price;
            this.refinvoice = refinvoice;
            this.deleted = 0;
        }
    }
}
