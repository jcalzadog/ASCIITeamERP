using ERP.Dominio.Gestores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio
{
    class Order
    {

        public int id { get; set; }
        public decimal refCustomer { get; set; }
        public decimal refUser { get; set; }
        public DateTime date { get; set; }
        public decimal refPayMethod { get; set; }
        public decimal total { get; set; }
        public decimal prepaid { get; set; }
        public int deleted { get; set; }
        public GestorOrder gestorOrder { get; set; }


        public Order()
        {
            this.gestorOrder = new GestorOrder();
        }

        public Order(int iD, decimal refCustomer, decimal refUser, DateTime datet, int refPaymentMethod, decimal total, decimal prepaid, int deleted)
        {
            this.id = iD;
            this.refCustomer = refCustomer;
            this.refUser = refUser;
            this.date = datet;
            this.refPayMethod = refPaymentMethod;
            this.total = total;
            this.prepaid = prepaid;
            this.deleted = deleted;
            this.gestorOrder = new GestorOrder();
        }

        
    }
}
