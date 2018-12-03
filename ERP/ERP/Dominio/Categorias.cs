using ERP.Dominio.Gestores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio
{
    class Categorias
    {
        public String name { get; set; }

        public GestorCategorias gestor;

        public Categorias() {
            gestor = new GestorCategorias();
        }
    }
}
