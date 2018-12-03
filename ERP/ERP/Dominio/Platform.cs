using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio
{
    class Platform
    {
        public Gestores.GestorPlatforms gestor;

        public Platform() 
        {
            this.gestor = new Gestores.GestorPlatforms();
        }
    }
}
