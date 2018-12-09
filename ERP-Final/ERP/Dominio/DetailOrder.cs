using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio
{
    class DetailOrder
    {

        decimal refOrder;
        decimal refProduct;
        decimal amount;
        decimal pricesale;

        public DetailOrder(decimal refOrder, decimal refProduct, decimal amount, decimal pricesale)
        {
            this.refOrder = refOrder;
            this.refProduct = refProduct;
            this.amount = amount;
            this.pricesale = pricesale;
        }

        public decimal RefOrder
        {
            get
            {
                return refOrder;
            }

            set
            {
                refOrder = value;
            }
        }

        public decimal RefProduct
        {
            get
            {
                return refProduct;
            }

            set
            {
                refProduct = value;
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

        public decimal Pricesale
        {
            get
            {
                return pricesale;
            }

            set
            {
                pricesale = value;
            }
        }


    }
}
