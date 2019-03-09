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
        private int numInvoice;
        private DateTime date;
        private int refcustomer;
        private int amount;
        private int deleted;
        private int posted;
        private int id;


        public Invoicees() {
            this.gestor = new GestorInvoices();
        }

        public Invoicees(int numInvoice, DateTime date, int refcustomer, int amount, int deleted, int posted, int id)
        {
            this.NumInvoice = numInvoice;
            this.Date = date;
            this.Refcustomer = refcustomer;
            this.Amount = amount;
            this.Deleted = deleted;
            this.Posted = posted;
            this.Id = id;
        }
        public int NumInvoice
        {
            get
            {
                return numInvoice;
            }

            set
            {
                numInvoice = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public int Refcustomer
        {
            get
            {
                return refcustomer;
            }

            set
            {
                refcustomer = value;
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

        public int Posted
        {
            get
            {
                return posted;
            }

            set
            {
                posted = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
    }
}
