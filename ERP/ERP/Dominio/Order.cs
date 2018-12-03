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
        public int refCustomer { get; set; }
        public int refUser { get; set; }
        public DateTime date { get; set; }
        public int refPayMethod { get; set; }
        public float total { get; set; }
        public int prepaid { get; set; }
        public int deleted { get; set; }
        public Order(int iD, int refCustomer, int refUser, DateTime datet, int refPaymentMethod, float total, int prepaid, int deleted)
        {
            id = iD;
            this.refCustomer = refCustomer;
            this.refUser = refUser;
            date = datet;
            refPayMethod = refPaymentMethod;
            this.total = total;
            this.prepaid = prepaid;
            this.deleted = deleted;
        }

        
    }
}
