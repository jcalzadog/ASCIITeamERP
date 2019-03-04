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
        public String nomCategory { get; set; }
        public String nomPlatform { get; set; }
        public int miniNumage { get; set; }
        public float prize { get; set; }
        public int deleted { get; set; }
        public int stock { get; set; }
        public GestorProducto gestorProducto { get; set; }

        //Metodos
        public Producto()
        {
            gestorProducto = new GestorProducto();
        }

        public Producto(String nameP)
        {
            
            this.name = nameP;
            gestorProducto = new GestorProducto();
        }

        public Producto(int idP, String nameP,String nomCat, String nomPlat,int pegiP,float prizeP, int deletedP, int stock)
        {
            this.idProduct = idP;
            this.name = nameP;
            this.nomCategory = nomCat;
            this.nomPlatform = nomPlat;
            this.miniNumage = pegiP;
            this.prize = prizeP;
            this.deleted = deletedP;
            this.stock = stock;
            
            gestorProducto = new GestorProducto();
        }
    }
}
