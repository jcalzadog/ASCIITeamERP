using System;
using System.Data;
using System.Diagnostics;

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
                "M.PAYMENTMETHOD PAYMETHOD, O.DATETIME DAT,O.TOTAL TOTAL, O.PREPAID PREPAID "+
                "FROM ORDERS O INNER JOIN CUSTOMERS C ON O.REFCUSTOMER=C.IDCUSTOMER "+
                "INNER JOIN USERS U ON O.REFUSER=U.IDUSER INNER JOIN PAYMENTMETHODS M "+
                "ON O.REFPAYMENTMETHOD=M.IDPAYMENTMETHOD where ( UPPER(c.name) LIKE UPPER ('%" + condicion + "%') OR UPPER(c.surname) LIKE UPPER ('%" + condicion + "%') OR  UPPER(U.NAME) LIKE UPPER ('%" + condicion + "%') OR O.DATETIME LIKE '%" + condicion + "%' OR UPPER(M.PAYMENTMETHOD) LIKE UPPER ('%" + condicion + "%') OR O.TOTAL LIKE '%" + condicion + "%' OR O.PREPAID LIKE '%" + condicion + "%') and o.deleted=0", "ORDERS O INNER JOIN CUSTOMERS C ON O.REFCUSTOMER = C.IDCUSTOMER "+
                "INNER JOIN USERS U ON O.REFUSER=U.IDUSER INNER JOIN PAYMENTMETHODS M " +
                "ON O.REFPAYMENTMETHOD=M.IDPAYMENTMETHOD");

            tOrders = data.Tables["ORDERS O INNER JOIN CUSTOMERS C ON O.REFCUSTOMER = C.IDCUSTOMER " +
                "INNER JOIN USERS U ON O.REFUSER=U.IDUSER INNER JOIN PAYMENTMETHODS M " +
                "ON O.REFPAYMENTMETHOD=M.IDPAYMENTMETHOD"];
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
            conector.setData("INSERT INTO ORDERS VALUES ('"+idOrder+"', '"+o.refCustomer+"', '"+o.refUser+ "', sysdate,'"+o.refPayMethod+"', '"+o.total+"', '"+o.prepaid+"', '0')");
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

    }
}
