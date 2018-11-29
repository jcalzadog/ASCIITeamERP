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
        private int idRol { get; set; }
        private String nameRol { get; set; }
        private LinkedList<Object> listaPermits { get; set; }

        private GestorRol gestorRol;

        public Role(int idRol, String nameRol, LinkedList<Object> listaPermits)
        {
            this.idRol = idRol;
            this.nameRol = nameRol;
            this.listaPermits = listaPermits;
            this.gestorRol = new GestorRol();
        }
    }
}
