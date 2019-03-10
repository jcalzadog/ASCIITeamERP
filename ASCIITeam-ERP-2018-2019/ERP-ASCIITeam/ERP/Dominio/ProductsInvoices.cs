using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio
{
    class ProductsInvoices
    {
        
        int idproduct;
        int idinvoice;
        int amount;
        float price;

      
        public ProductsInvoices(int idproduct, int idinvoice, int amount, float price)
        {
           
            this.Idproduct = idproduct;
            this.Idinvoice = idinvoice;
            this.Amount = amount;
            this.Price = price;
        }
        public int Idproduct
        {
            get
            {
                return idproduct;
            }

            set
            {
                idproduct = value;
            }
        }

        public int Idinvoice
        {
            get
            {
                return idinvoice;
            }

            set
            {
                idinvoice = value;
            }
        }

        public int Amount
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

        public float Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

    }
}
