using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio.Gestores
{
    class Customer
    {
        private int idCustomer { get; set; }
        private String name { get; set; }
        private String surname { get; set; }
        private String address { get; set; }
        private int phone { get; set; }
        private String email { get; set; }
        private int deleted { get; set; }
        private int refzipcodescities { get; set; }

        public GestorCliente gestorCliente { get; set; }

        public Customer()
        {
            gestorCliente = new GestorCliente();
        }

        public Customer(int idC, String nameC, String surnameC, String addressC, int phoneC, String emailC, int deletedC, int refzipcodescitiesC)
        {
            idCustomer = idC;
            name = nameC;
            surname = surnameC;
            address = addressC;
            phone = phoneC;
            email = emailC;
            deleted = deletedC;
            refzipcodescities = refzipcodescitiesC;

            gestorCliente = new GestorCliente();
        }



    }
}
