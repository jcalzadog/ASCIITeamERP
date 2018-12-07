using System.Data;

namespace ERP.Dominio.Gestores
{
    class GestorOrder
    {
        public DataTable tOrders { get; set; }

        public GestorOrder()
        {
            tOrders = new DataTable();
        }

        public void leerOrders(string condicion)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT O.IDORDER ID, C.SURNAME SURNAME, U.NAME USERNAME, "+
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

        public void eliminar (string idOrder)
        {
            new ConnectOracle().setData("UPDATE ORDERS SET DELETED=1 WHERE IDORDER='" + idOrder + "'");
        }

    }
}
