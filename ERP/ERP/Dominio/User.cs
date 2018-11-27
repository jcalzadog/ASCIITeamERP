﻿using ERP.Dominio.Gestores;
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

        private int idUser { get; set; }
        private String name { get; set; }
        private String password { get; set; }
        private int deleted { get; set; }
        public GestorUsuario gestorusuario { get; set; }

        //Metodos
        public User(int Id,String nameU,String passwordU,int deletedU)
        {
            idUser = Id;
            name = nameU;
            password = passwordU;
            deleted = deletedU;
            gestorusuario = new GestorUsuario();
        }
    }
}
