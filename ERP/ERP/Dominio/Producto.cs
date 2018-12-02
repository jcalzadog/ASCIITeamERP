using ERP.Dominio.Gestores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio
{
    class Producto
    {
        //Atributos
        private int idProduct { get; set; }
        private String name { get; set; }
        private int idCategory { get; set; }
        private int idPlatform { get; set; }
        private int miniNumage { get; set; }
        private float prize { get; set; }
        private int deleted { get; set; }
        public GestorProducto gestorProducto { get; set; }

        //Metodos
        public Producto()
        {
            gestorProducto = new GestorProducto();
        }

        public Producto(int idP, String nameP,int idCat, int idPlat,int pegiP,float prizeP, int deletedP)
        {
            idProduct = idP;
            name = nameP;
            idCategory = idCategory;
            idPlatform = idPlatform;
            miniNumage = pegiP;
            prize = prizeP;
            deleted = deletedP; ;
            
            gestorProducto = new GestorProducto();
        }
    }
}
