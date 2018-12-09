using ERP.Dominio.Gestores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio
{
    class Role
    {
        public int idRol { get; set; }
        public String nameRol { get; set; }
        public LinkedList<Object> listaPermits { get; set; }

        public GestorRol gestorRol { get; set; }

        public Role()
        {
            this.gestorRol = new GestorRol();
        }

        public Role(String nameRol)
        {
            this.nameRol = nameRol;
            this.gestorRol = new GestorRol();
        }
        public Role(int idRol, String nameRol, LinkedList<Object> listaPermits)
        {
            this.idRol = idRol;
            this.nameRol = nameRol;
            this.listaPermits = listaPermits;
            this.gestorRol = new GestorRol();
        }
    }
}
