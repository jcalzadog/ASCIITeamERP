using System;
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

        public DataTable getOrderCart (decimal idOrder)
        {
            DataTable cart = new DataTable();
            DataSet data = new DataSet();
            data = conector.getData("SELECT P.NAME, O.AMOUNT, O.PRICESALE FROM ORDERSPRODUCTS O INNER JOIN PRODUCTS P ON O.REFPRODUCT=P.IDPRODUCT WHERE O.REFORDER='"+idOrder.ToString()+"'", "ORDERSPRODUCTS O INNER JOIN PRODUCTS P ON O.REFPRODUCT=P.IDPRODUCT");
            cart = data.Tables["ORDERSPRODUCTS O INNER JOIN PRODUCTS P ON O.REFPRODUCT=P.IDPRODUCT"];
            return cart;
        }

        public void eliminar (string idOrder)
        {
            conector.setData("UPDATE ORDERS SET DELETED=1 WHERE IDORDER='" + idOrder + "'");
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

            conector.setData("INSERT INTO ORDERS VALUES ('"+idOrder+"', '"+o.refCustomer+"', '"+o.refUser+ "', sysdate,'"+o.refPayMethod+"', '"+o.total+"', '"+(o.prepaid.ToString().Replace('.',','))+"', '0')");
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
            conector.setData("UPDATE PRODUCTS P SET P.STOCK = ( SELECT(P.STOCK - O.AMOUNT) FROM ORDERSPRODUCTS O WHERE P.IDPRODUCT = O.REFPRODUCT AND O.REFORDER = 9) WHERE P.IDPRODUCT IN (SELECT PR.IDPRODUCT FROM PRODUCTS PR INNER JOIN ORDERSPRODUCTS OS ON PR.IDPRODUCT = OS.REFPRODUCT WHERE OS.REFORDER =" + idOrder + ")");
            String query = "SELECT STOCK FROM PRODUCTS P INNER JOIN ORDERSPRODUCTS O ON P.IDPRODUCT= O.REFPRODUCT WHERE O.REFORDER=" + idOrder;
            DataSet data = conector.getData(query, "PRODUCTS P INNER JOIN ORDERSPRODUCTS O ON P.IDPRODUCT= O.REFPRODUCT");
            int[] arrayStocks= data.Tables[0].AsEnumerable().Select(r => r.Field<int>("STOCK")).ToArray();

            for(int i = 0; i < arrayStocks.Length; i++)
            {
                if (arrayStocks[i] < 0)
                {
                    posible = false;
                }
            }
            return posible;
        }

        public void sumarStock(decimal idOrder)
        {
            conector.setData("UPDATE PRODUCTS P SET P.STOCK = ( SELECT(P.STOCK + O.AMOUNT) FROM ORDERSPRODUCTS O WHERE P.IDPRODUCT = O.REFPRODUCT AND O.REFORDER = 9) WHERE P.IDPRODUCT IN (SELECT PR.IDPRODUCT FROM PRODUCTS PR INNER JOIN ORDERSPRODUCTS OS ON PR.IDPRODUCT = OS.REFPRODUCT WHERE OS.REFORDER =" + idOrder + ")");
        }

    }
}
