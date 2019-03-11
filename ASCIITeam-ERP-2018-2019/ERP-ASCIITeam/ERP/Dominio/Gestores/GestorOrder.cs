using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace ERP.Dominio.Gestores
{
    class GestorOrder
    {
        public DataTable tOrders { get; set; }
        ConnectOracle conector;
        public GestorOrder()
        {
            tOrders = new DataTable();
            conector = new ConnectOracle();
        }
        /// <summary>
        /// Devuelve la cuantia total de un pedido
        /// </summary>
        /// <param name="idOrder"> id del pedido</param>
        /// <returns></returns>
        public decimal getTotalOder (decimal idOrder)
        {
            return (decimal)conector.DLookUp("total", "orders", "idorder=" + idOrder);
        }

        public void leerOrders(string condicion)
        {
            DataSet data = new DataSet();

            data = conector.getData("SELECT O.IDORDER ID, C.SURNAME SURNAME, U.NAME USERNAME, "+
                "M.PAYMENTMETHOD PAYMETHOD, O.DATETIME DAT,O.TOTAL TOTAL,(O.TOTAL-O.PREPAID) REST,O.PREPAID PREPAID "+
                "FROM ORDERS O INNER JOIN CUSTOMERS C ON O.REFCUSTOMER=C.IDCUSTOMER "+
                "INNER JOIN USERS U ON O.REFUSER=U.IDUSER INNER JOIN PAYMENTMETHODS M "+
                "ON O.REFPAYMENTMETHOD=M.IDPAYMENTMETHOD where ( UPPER(c.name) LIKE UPPER ('%" + condicion + "%') OR UPPER(c.surname) LIKE UPPER ('%" + condicion + "%') OR  UPPER(U.NAME) LIKE UPPER ('%" + condicion + "%') OR O.DATETIME LIKE '%" + condicion + "%' OR UPPER(M.PAYMENTMETHOD) LIKE UPPER ('%" + condicion + "%') OR O.TOTAL LIKE '%" + condicion + "%' OR O.PREPAID LIKE '%" + condicion + "%') and o.deleted=0", "ORDERS O INNER JOIN CUSTOMERS C ON O.REFCUSTOMER = C.IDCUSTOMER "+
                "INNER JOIN USERS U ON O.REFUSER=U.IDUSER INNER JOIN PAYMENTMETHODS M " +
                "ON O.REFPAYMENTMETHOD=M.IDPAYMENTMETHOD ORDER BY O.DATETIME");

            tOrders = data.Tables["ORDERS O INNER JOIN CUSTOMERS C ON O.REFCUSTOMER = C.IDCUSTOMER " +
                "INNER JOIN USERS U ON O.REFUSER=U.IDUSER INNER JOIN PAYMENTMETHODS M " +
                "ON O.REFPAYMENTMETHOD=M.IDPAYMENTMETHOD ORDER BY O.DATETIME"];
        }

        public void leerOrders(string condicion,int eliminado)
        {
            DataSet data = new DataSet();

            data = conector.getData("SELECT O.IDORDER ID, C.SURNAME SURNAME, U.NAME USERNAME, " +
                "M.PAYMENTMETHOD PAYMETHOD, O.DATETIME DAT,O.TOTAL TOTAL,(O.TOTAL-O.PREPAID) REST,O.PREPAID PREPAID " +
                "FROM ORDERS O INNER JOIN CUSTOMERS C ON O.REFCUSTOMER=C.IDCUSTOMER " +
                "INNER JOIN USERS U ON O.REFUSER=U.IDUSER INNER JOIN PAYMENTMETHODS M " +
                "ON O.REFPAYMENTMETHOD=M.IDPAYMENTMETHOD where ( UPPER(c.name) LIKE UPPER ('%" + condicion + "%') OR UPPER(c.surname) LIKE UPPER ('%" + condicion + "%') OR  UPPER(U.NAME) LIKE UPPER ('%" + condicion + "%') OR O.DATETIME LIKE '%" + condicion + "%' OR UPPER(M.PAYMENTMETHOD) LIKE UPPER ('%" + condicion + "%') OR O.TOTAL LIKE '%" + condicion + "%' OR O.PREPAID LIKE '%" + condicion + "%') and o.deleted="+eliminado+"", "ORDERS O INNER JOIN CUSTOMERS C ON O.REFCUSTOMER = C.IDCUSTOMER " +
                "INNER JOIN USERS U ON O.REFUSER=U.IDUSER INNER JOIN PAYMENTMETHODS M " +
                "ON O.REFPAYMENTMETHOD=M.IDPAYMENTMETHOD ORDER BY O.DATETIME");

            tOrders = data.Tables["ORDERS O INNER JOIN CUSTOMERS C ON O.REFCUSTOMER = C.IDCUSTOMER " +
                "INNER JOIN USERS U ON O.REFUSER=U.IDUSER INNER JOIN PAYMENTMETHODS M " +
                "ON O.REFPAYMENTMETHOD=M.IDPAYMENTMETHOD ORDER BY O.DATETIME"];
        }

        public DataTable getOrderCart (decimal idOrder)
        {
            DataTable cart = new DataTable();
            DataSet data = new DataSet();
            data = conector.getData("SELECT P.NAME, O.AMOUNT, O.PRICESALE, O.AMOUNT*O.PRICESALE TOTAL FROM ORDERSPRODUCTS O INNER JOIN PRODUCTS P ON O.REFPRODUCT=P.IDPRODUCT WHERE O.REFORDER='"+idOrder.ToString()+"'", "ORDERSPRODUCTS O INNER JOIN PRODUCTS P ON O.REFPRODUCT=P.IDPRODUCT");
            cart = data.Tables["ORDERSPRODUCTS O INNER JOIN PRODUCTS P ON O.REFPRODUCT=P.IDPRODUCT"];
            return cart;
        }

        public Order getOrder (decimal idOrder)
        {
            DataSet temp = conector.getData("select * from orders where idorder=" + idOrder, "orders");
            Order order = null;
            //System.Windows.Forms.MessageBox.Show(temp.Tables[0].Rows[0][0]+" "+temp.Tables[0].Rows[0][1].ToString() + " " +temp.Tables[0].Rows[0][2] + " " +temp.Tables[0].Rows[0][3] + " " + temp.Tables[0].Rows[0][4] + " " + temp.Tables[0].Rows[0][5] + " " + temp.Tables[0].Rows[0][6] + " " +temp.Tables[0].Rows[0][7]);
            int id = Decimal.ToInt32((decimal)temp.Tables[0].Rows[0][0]);
            decimal refCustomer = (decimal)temp.Tables[0].Rows[0][1];
            decimal refUser= (decimal)temp.Tables[0].Rows[0][2];
            DateTime date= (DateTime)temp.Tables[0].Rows[0][3];
            decimal refPayMethod= (decimal)temp.Tables[0].Rows[0][4];
            decimal total= (decimal)temp.Tables[0].Rows[0][5];
            decimal prepaid = (decimal)temp.Tables[0].Rows[0][6];
            int deleted= Decimal.ToInt16((decimal)temp.Tables[0].Rows[0][7]);
            order = new Dominio.Order(id, refCustomer,refUser,date,Decimal.ToInt16(refPayMethod),total,prepaid,deleted);
            return order;
        }
        /// <summary>
        /// Se actualiza el order cuyo id se corresponda con el del objeto (no muta la fecha de creacion, ni el cliente ni el usuario que la creo)
        /// o dicho de otra forma modifica el metodo de pago, total (si se han añadido productos) y prepagado
        /// para añadir las lineas de pedido e incluir las antiguas sin que se dupliquen se acompaña el metodo delete details que borra todos los detalles
        /// para insertar los antiguos y los nuevos a la vez (es la forma en la que se ha implementado el editor)
        /// </summary>
        /// <param name="modified"></param>
        public void updateOrder(Order modified)
        {
            conector.setData("update orders set refpaymentmethod='" + modified.refPayMethod + "', total='" + modified.total + "' , prepaid='" + modified.prepaid + "' where idorder='" + modified.id + "'");
        }
        
        public List<DetailOrder> getDetails (decimal idOrder)
        {
            List<DetailOrder> details = new List<DetailOrder>();
            DataSet datos = conector.getData("select * from ordersproducts where reforder=" + idOrder, "ordersproducts");
            foreach (DataRow row in datos.Tables[0].Rows)
            {
                details.Add(new DetailOrder((decimal)row[1], (decimal)row[2], (decimal)row[3], (decimal)row[4]));
            }
            return details;
        }
        /// <summary>
        /// Metodo a ejecutar antes de actualizar un order desde el dialogo new order ya que sobreescribe
        /// </summary>
        /// <param name="idOrder"></param>
        public void deleteDetails(decimal idOrder)
        {
            conector.setData("delete from ordersproducts where reforder=" + idOrder);
        }

        public void eliminar (string idOrder)
        {
            conector.setData("UPDATE ORDERS SET DELETED=1 WHERE IDORDER='" + idOrder + "'");
        }

        public void restaurar(string idOrder)
        {
            conector.setData("UPDATE ORDERS SET DELETED=0 WHERE IDORDER='" + idOrder + "'");
        }

        public decimal insertOrder (Order o)
        {
            decimal numPedidos = (decimal)conector.DLookUp("COUNT(IDORDER)", "ORDERS", "");
            decimal idOrder;
            if (numPedidos == 0)
            {
                idOrder = 1;

            } else
            {
                idOrder = (decimal)conector.DLookUp("MAX(IDORDER)", "ORDERS", "");
                idOrder++;
            }

            decimal numStatus = (decimal)conector.DLookUp("COUNT(ID)", "ORDERS_STATUS", "");
            decimal idStatus;
            if (numStatus == 0)
            {
                idStatus = 1;

            }
            else
            {
                idStatus = (decimal)conector.DLookUp("MAX(ID)", "ORDERS_STATUS", "");
                idStatus++;
            }

            conector.setData("INSERT INTO ORDERS VALUES ('"+idOrder+"', '"+o.refCustomer+"', '"+o.refUser+ "', sysdate,'"+o.refPayMethod+"', '"+o.total+"', '"+(o.prepaid.ToString().Replace('.',','))+"', '0')");//añadido para el control de estados 
            conector.setData("INSERT INTO ORDERS_STATUS VALUES ('" + idStatus + "', '" + idOrder + "', '0')");
            // se podria usar la fecha del objeto pero suponemos que en la insercion es la fecha del pedido por el momento, en futuras versiones quizas permita cambiar fecha
            return idOrder;
        }

        public void insertDetail (DetailOrder d, decimal idOrder)
        {

            decimal numDetail = (decimal)conector.DLookUp("COUNT(IDORDERPRODUCT)", "ORDERSPRODUCTS", "");
            decimal idDetail;
            if (numDetail == 0)
            {
                idDetail = 1;

            }
            else
            {
                idDetail = (decimal)conector.DLookUp("MAX(IDORDERPRODUCT)", "ORDERSPRODUCTS", "");
                idDetail++;
            }
            conector.setData("INSERT INTO ORDERSPRODUCTS VALUES ('" + idDetail + "', '" +idOrder + "', '" + d.RefProduct + "', '"+d.Amount + "', '" + d.Pricesale + "')");
        }

        public decimal getstatus(decimal idOrder)
        {
            decimal status = Convert.ToDecimal(conector.DLookUp("STATUS", "ORDERS_STATUS", "REFORDER='" + idOrder + "'"));
            return status;
        }

        public void putstatus(decimal idOrder, decimal status)
        {
            conector.setData("UPDATE ORDERS_STATUS SET STATUS="+status+ " WHERE REFORDER=" + idOrder);
        }

        public bool restarStock(decimal idOrder)
        {
            bool posible = true;
            //conector.setData("UPDATE PRODUCTS P SET P.STOCK=(SELECT(P.STOCK - O.AMOUNT) FROM ORDERSPRODUCTS O WHERE P.IDPRODUCT = O.REFPRODUCT AND O.REFORDER=" + idOrder + ")");
            conector.setData("UPDATE PRODUCTS P SET P.STOCK = ( SELECT(P.STOCK - SUM(O.AMOUNT)) FROM ORDERSPRODUCTS O WHERE P.IDPRODUCT = O.REFPRODUCT AND O.REFORDER ='" + idOrder + "') WHERE P.IDPRODUCT IN (SELECT PR.IDPRODUCT FROM PRODUCTS PR INNER JOIN ORDERSPRODUCTS OS ON PR.IDPRODUCT = OS.REFPRODUCT WHERE OS.REFORDER =" + idOrder + ")");
            String query = "SELECT STOCK FROM PRODUCTS P INNER JOIN ORDERSPRODUCTS O ON P.IDPRODUCT= O.REFPRODUCT WHERE O.REFORDER=" + idOrder;
            DataSet data = conector.getData(query, "PRODUCTS P INNER JOIN ORDERSPRODUCTS O ON P.IDPRODUCT= O.REFPRODUCT");
            int[] arrayStocks= data.Tables[0].AsEnumerable().Select(r => r.Field<int>("STOCK")).ToArray();

            for(int i = 0; i < arrayStocks.Length; i++)
            {
                if (arrayStocks[i] < 0)
                {
                    sumarStock(idOrder);
                    posible = false;
                }
            }
            return posible;
        }

        public void sumarStock(decimal idOrder)
        {
            conector.setData("UPDATE PRODUCTS P SET P.STOCK = ( SELECT(P.STOCK + SUM(O.AMOUNT)) FROM ORDERSPRODUCTS O WHERE P.IDPRODUCT = O.REFPRODUCT AND O.REFORDER ='" + idOrder + "') WHERE P.IDPRODUCT IN (SELECT PR.IDPRODUCT FROM PRODUCTS PR INNER JOIN ORDERSPRODUCTS OS ON PR.IDPRODUCT = OS.REFPRODUCT WHERE OS.REFORDER =" + idOrder + ")");
        }

        public bool comprobarPedidoEliminado(decimal idOrder)
        {
            decimal pedido = Convert.ToDecimal(conector.DLookUp("COUNT(IDORDER)", "ORDERS", "IDORDER='" + idOrder + "' AND DELETED=0"));
            if (pedido > 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public Decimal contarOrders()
        {
            Decimal cuentaOrders = (Decimal)conector.DLookUp("COUNT(IDORDER)", "ORDERS", "");

            return cuentaOrders;
        }

    }
}
