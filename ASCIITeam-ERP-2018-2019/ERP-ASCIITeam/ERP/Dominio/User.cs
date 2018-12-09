using ERP.Dominio.Gestores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio
{
    class User
    {
        //Atributos

        public int idUser { get; set; }
        public String name { get; set; }
        public String password { get; set; }
        public int deleted { get; set; }
        public Role rol { get; set; }
        public GestorUsuario gestorusuario { get; set; }

        //Metodos
        public User()
        {
            this.rol = new Role();
            gestorusuario = new GestorUsuario();
        }

        public User(String nameU)
        {
            this.rol = new Role();
            name = nameU;
            gestorusuario = new GestorUsuario();
        }
        public User(String nameU, String passwordU, Role rol, int deletedU)
        {
            name = nameU;
            password = passwordU;
            deleted = deletedU;
            this.rol = rol;
            gestorusuario = new GestorUsuario();
        }

        public User(int Id,String nameU,String passwordU,Role rol,int deletedU)
        {
            idUser = Id;
            name = nameU;
            password = passwordU;
            deleted = deletedU;
            this.rol = rol;
            gestorusuario = new GestorUsuario();
        }
    }
}
