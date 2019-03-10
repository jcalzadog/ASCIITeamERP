using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio
{
    class LinesInvoices
    {

        private string description;
        private int amount;
        private float price;
        private int refinvoice;
        private int deleted;

      

        public LinesInvoices(string description, int amount, float price, int refinvoice, int deleted)
        {
            this.Description = description;
            this.Amount = amount;
            this.Price = price;
            this.Refinvoice = refinvoice;
            this.Deleted = deleted;
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

        public int Refinvoice
        {
            get
            {
                return refinvoice;
            }

            set
            {
                refinvoice = value;
            }
        }

        public int Deleted
        {
            get
            {
                return deleted;
            }

            set
            {
                deleted = value;
            }
        }
    }
}
