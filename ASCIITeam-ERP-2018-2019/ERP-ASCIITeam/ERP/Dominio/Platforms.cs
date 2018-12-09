using ERP.Dominio.Gestores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio
{
    class Platforms
    {
        public String name;
        public GestorPlataformas gestorplataforma;

        public Platforms() {
            gestorplataforma = new GestorPlataformas();
            
        }
        public Platforms(String name) {
            this.name = name;
            gestorplataforma = new GestorPlataformas();
        }
    }
}
