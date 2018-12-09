using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio.Gestores
{
    class Customer
    {
        public int idCustomer { get; set; }
        public String dni { get; set; }
        public String name { get; set; }
        public String surname { get; set; }
        public String address { get; set; }
        public int phone { get; set; }
        public String email { get; set; }
        public int deleted { get; set; }
        public int refzipcodescities { get; set; }
        public String region { get; set; }
        public String state { get; set; }
        public String city { get; set; }

        public GestorCliente gestorCliente { get; set; }

        public Customer()
        {
            gestorCliente = new GestorCliente();
        }

        public Customer(int idC, String nameC, String dni,String surnameC, String addressC, int phoneC, String emailC, int deletedC, int refzipcodescitiesC)
        {
            idCustomer = idC;
            this.dni = dni;
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
