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

        public void leerOrders()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT O.IDORDER ID, C.SURNAME SURNAME, U.NAME USERNAME, "+
                "M.PAYMENTMETHOD PAYMETHOD, O.DATETIME DAT,O.TOTAL TOTAL, O.PREPAID PREPAID "+
                "FROM ORDERS O INNER JOIN CUSTOMERS C ON O.REFCUSTOMER=C.IDCUSTOMER "+
                "INNER JOIN USERS U ON O.REFUSER=U.IDUSER INNER JOIN PAYMENTMETHODS M "+
                "ON O.REFPAYMENTMETHOD=M.IDPAYMENTMETHOD", "ORDERS O INNER JOIN CUSTOMERS C ON O.REFCUSTOMER = C.IDCUSTOMER "+
                "INNER JOIN USERS U ON O.REFUSER=U.IDUSER INNER JOIN PAYMENTMETHODS M " +
                "ON O.REFPAYMENTMETHOD=M.IDPAYMENTMETHOD");

            tOrders = data.Tables["ORDERS O INNER JOIN CUSTOMERS C ON O.REFCUSTOMER = C.IDCUSTOMER " +
                "INNER JOIN USERS U ON O.REFUSER=U.IDUSER INNER JOIN PAYMENTMETHODS M " +
                "ON O.REFPAYMENTMETHOD=M.IDPAYMENTMETHOD"];
        }

        public void filter(string filter)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("Select O.IDORDER, C.NAME AS CLIENTNAME, U.NAME AS USERNAME, O.DATETIME, P.PAYMENTMETHOD AS PAYMENTMETHOD, O.TOTAL, O.PREPAID FROM E_ORDERS O, E_CUSTOMERS C, E_USERS U, E_PAYMENTMETHODS P WHERE P.IDPAYMENTMETHOD=O.REFPAYMENTMETHOD AND  U.IDUSER=O.REFUSER  AND C.IDCUSTOMER=O.REFCUSTOMER AND  ( UPPER(c.name) LIKE UPPER ('%" + filter + "%') OR  UPPER(U.NAME) LIKE UPPER ('%" + filter + "%') OR O.DATETIME LIKE '%" + filter + "%' OR UPPER(P.PAYMENTMETHOD) LIKE UPPER ('%" + filter + "%') OR O.TOTAL LIKE '%" + filter + "%' OR O.PREPAID LIKE '%" + filter + "%') and o.deleted=0", "ORDERS");

            tOrders = data.Tables["ORDERS"];
        }

    }
}
