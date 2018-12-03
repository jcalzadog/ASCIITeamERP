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
        public int idProduct { get; set; }
        public String name { get; set; }
        public int idCategory { get; set; }
        public int idPlatform { get; set; }
        public int miniNumage { get; set; }
        public float prize { get; set; }
        public int deleted { get; set; }
        public GestorProducto gestorProducto { get; set; }

        //Metodos
        public Producto()
        {
            gestorProducto = new GestorProducto();
        }

        public Producto(String nameP)
        {
            
            name = nameP;
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
