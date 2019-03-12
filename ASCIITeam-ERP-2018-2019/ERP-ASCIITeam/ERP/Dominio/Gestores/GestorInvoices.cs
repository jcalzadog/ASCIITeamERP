using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Dominio.Gestores
{
    class GestorInvoices
    {

        public DataTable tabla { get; set; }
        ConnectOracle conector;

        public GestorInvoices()
        {
            conector = new ConnectOracle();
            tabla = new DataTable();
        }

        public void comboProducts(ComboBox c)
        {
            DataSet data = new DataSet();
            data = conector.getData("SELECT NAME,IDPRODUCT FROM PRODUCTS ", "PRODUCTS");
            //Decimal cuentaProductos = (Decimal)conector.DLookUp("COUNT(IDPRODUCT)", "PRODUCTS", "");
            
            //for (int i = 0; i < cuentaProductos; i++)
            //{
            //   // c.Items.Add(data.Tables[0].Rows[i][0].ToString());
               
            //}
            
            c.DisplayMember ="NAME";
            c.ValueMember = "IDPRODUCT";
            c.DataSource = data.Tables[0];
            c.SelectedIndex = 0;
           
        }
        public decimal productPrice(decimal id)
        {
            decimal precio = (decimal)conector.DLookUp("PRICE", "PRODUCTS","IDPRODUCT="+id);
            return precio;
        }
        public string getProductName(decimal id) {
            string name = conector.DLookUp("NAME", "PRODUCTS", "IDPRODUCT=" + id).ToString();
            return name;
        }

        public decimal getIdCliente(String dni) {
            decimal id =(decimal) conector.DLookUp("IDCUSTOMER", "CUSTOMERS", "DNI='" + dni + "'");
            return id;
        }

        /// <summary>
        /// realiza las inserciones necesarias para generar una factura a partir de un pedido
        /// </summary>
        /// <param name="idOrder">pedido al que se le va a generar la factura</param>
        public decimal generateInvoice(decimal idOrder)
        {
            decimal numberInvoice = (decimal)conector.DLookUp("nvl(MAX(NUM_INVOICE)+1,TO_NUMBER(TO_CHAR(sysdate,'YYYY')||'0000')+1)", "invoices", "(NUM_INVOICE>TO_NUMBER(TO_CHAR(sysdate,'YYYY')||'0000') and NUM_INVOICE<TO_NUMBER(TO_CHAR(sysdate,'YYYY')+1||'0000'))");

            decimal idInvoice = (decimal)conector.DLookUp("nvl(MAX(ID)+1,1)", "invoices", "");
            decimal idCustomer = (decimal)conector.DLookUp("refcustomer", "orders", "idorder='" + idOrder + "'");
            decimal amount = (decimal)conector.DLookUp("total", "orders", "idorder='" + idOrder + "'");
            conector.setData("insert into invoices values ( '" + numberInvoice + "', sysdate, '" + idCustomer + "', '" + amount + "', 0, 0, '" + idInvoice + "')");
            decimal idOrderInvoice = (decimal)conector.DLookUp("nvl(max(idorderinv)+1,1)", "orders_invoices", "");
            conector.setData("insert into orders_invoices values ('" + idOrderInvoice + "', '" + idOrder + "', '" + idInvoice + "')");
            return numberInvoice;
        }
        /// <summary>
        /// Metodo para cuando vas a reinsertar los datos de una factura que has editado, elimina sus lineas antiguas (las escritas a mano, las de pedido NUNCA)
        /// 
        /// </summary>
        /// <param name="num_invoice"></param>
        public void deleteDetails (decimal num_invoice)
        {
            conector.setData("delete from lines_invoice where refinvoice=" + getIdInvoice(num_invoice));
            conector.setData("delete from products_invoices where idinvoice=" + getIdInvoice(num_invoice));
        }
        /// <summary>
        /// Devuelve los item de una factura para proceder con la modificacion
        /// </summary>
        /// <param name="num_invoice"></param>
        /// <returns></returns>
        public List<Object> getItems (decimal num_invoice)
        {
            decimal idInvoice = getIdInvoice(num_invoice);
            List<Object> items = new List<object>();
            decimal idAsociedOrder =Convert.ToDecimal( conector.DLookUp("nvl(idorder,0)", "orders_invoices", "idinvoice=" + idInvoice));
            if (idAsociedOrder > 0)
            {
                List<DetailOrder> orderItems = new GestorOrder().getDetails(idAsociedOrder);
                foreach (DetailOrder d in orderItems){
                    items.Add(d);
                }
            }

            

            decimal products = Convert.ToDecimal(conector.DLookUp("count(idproinv)", "products_invoices", "idinvoice=" + idInvoice));
            if (products > 0)
            {
                DataSet lines_invoice = conector.getData("select idproduct, amount, pricesale from products_invoices where idinvoice=" + idInvoice, "lineas");
                foreach (DataRow r in lines_invoice.Tables["lineas"].Rows)
                {
                    items.Add(new ProductsInvoices(Convert.ToInt16(r["idproduct"]), Convert.ToInt16(idInvoice), Convert.ToInt16(r["amount"]),(float)Convert.ToDecimal(r["pricesale"])));
                }
            }

            decimal lines = Convert.ToDecimal(conector.DLookUp("count(id)", "lines_invoice", "refinvoice=" + idInvoice));
            if (lines > 0)
            {
                DataSet lines_invoice = conector.getData("select description, amount, price from lines_invoice where refinvoice=" + idInvoice, "lineas");
                foreach (DataRow r in lines_invoice.Tables["lineas"].Rows)
                {
                    items.Add(new LinesInvoices((string)r["description"], Convert.ToInt16(r["amount"]), (float)Convert.ToDouble(r["price"]), Convert.ToInt16(idInvoice), 0));
                }
            }

            return items;
        }


        /// <summary>
        /// Inserta una factura manualmente en facturas, a partir del cliente que la origina y la cantidad total de factura, devuelve el numero que se ha creado
        /// </summary>
        /// <param name="idCustomer"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public decimal generateInvoice(decimal idCustomer, float amount)
        {
            decimal numberInvoice = (decimal)conector.DLookUp("nvl(MAX(NUM_INVOICE)+1,TO_NUMBER(TO_CHAR(sysdate,'YYYY')||'0000')+1)", "invoices", "(NUM_INVOICE>TO_NUMBER(TO_CHAR(sysdate,'YYYY')||'0000') and NUM_INVOICE<TO_NUMBER(TO_CHAR(sysdate,'YYYY')+1||'0000'))");

            decimal idInvoice = (decimal)conector.DLookUp("nvl(MAX(ID)+1,1)", "invoices", "");
            
            
            conector.setData("insert into invoices values ( '" + numberInvoice + "', sysdate, '" + idCustomer + "', '" + amount + "', 0, 0, '" + idInvoice + "')");
            
            return idInvoice;
        }
        /// <summary>
        /// inserta un producto que se ha añadido a una factura
        /// </summary>
        /// <param name="idproduct"></param>
        /// <param name="idinvoice"></param>
        /// <param name="amount"></param>
        /// <param name="price"></param>
        public void insertarProductInvoices(int idproduct,int idinvoice,int amount,float price) {
            decimal idProductInvoice = (decimal)conector.DLookUp("nvl(MAX(IDPROINV)+1,1)", "products_invoices", "");
            conector.setData("INSERT INTO PRODUCTS_INVOICES VALUES('" + idProductInvoice + "','" + idproduct + "','" + idinvoice + "','" + amount + "','" + price + "')");
        }
        /// <summary>
        /// inserta una linea de una factura (de las que van puestas a mano)
        /// </summary>
        /// <param name="description"></param>
        /// <param name="idinvoice"></param>
        /// <param name="amount"></param>
        /// <param name="price"></param>
        public void insertarLinesInvoices(string description, int idinvoice, int amount, float price)
        {
            decimal idLineInvoice = (decimal)conector.DLookUp("nvl(MAX(ID)+1,1)", "lines_invoice", "");
            conector.setData("INSERT INTO LINES_INVOICE VALUES('" + idLineInvoice+ "','" +description + "','" + amount + "','" + price + "','" + idinvoice +"','0')");
        }

        /// <summary>
        /// carga en tabla las facturas
        /// </summary>
        ///
        public void loadTable()
        {
            DataSet data = new DataSet();
            data = conector.getData("SELECT I.NUM_INVOICE NUM_INVOICE, I.DATETIME DATETIME, C.SURNAME CUSTOMER, (I.AMOUNT*'0,79') NET, I.AMOUNT TOTAL FROM INVOICES I INNER JOIN CUSTOMERS C ON I.REFCUSTOMER=C.IDCUSTOMER WHERE i.DELETED=0", "INVOICES I INNER JOIN CUSTOMERS C ON I.REFCUSTOMER=C.IDCUSTOMER");
            tabla = data.Tables[0];

        }
        /// <summary>
        /// Comprueba si esta contabilizada
        /// </summary>
        /// <param name="num_invoice"></param>
        /// <returns></returns>
        public bool isPosted (string num_invoice)
        {
            decimal posted = Convert.ToDecimal(conector.DLookUp("POSTED", "INVOICES", "NUM_INVOICE='" + num_invoice + "'"));

            return posted == 1;
        }

        /// <summary>
        /// Marca como contabilizada la factura
        /// </summary>
        /// <param name="num_invoice"></param>
        public void post (string num_invoice)
        {
            conector.setData("update invoices set posted=1 where num_invoice=" + num_invoice);
        }
        /// <summary>
        /// Marca como eliminada la factura
        /// </summary>
        /// <param name="num_invoice"></param>
        public void delete (string num_invoice)
        {
            conector.setData("update invoices set deleted=1 where num_invoice=" + num_invoice);
        }
        /// <summary>
        /// Obtiene el id de invoice para poder referenciarla en otras tablas a partir de su numero
        /// </summary>
        /// <param name="num_invoice"></param>
        /// <returns></returns>
        public decimal getIdInvoice(decimal num_invoice)
        {
            return Convert.ToDecimal(conector.DLookUp("ID", "INVOICES", "NUM_INVOICE='" + num_invoice + "'"));
        }

        public decimal getTotalInvoice (decimal num_invoice)
        {
            return Convert.ToDecimal(conector.DLookUp("amount", "invoices", "num_invoice=" + num_invoice));
        }
        /// <summary>
        /// obtiene el dni del cliente al que se le esta facturando
        /// </summary>
        /// <param name="num_invoice"></param>
        /// <returns></returns>
        public string getDNICustomer (string num_invoice)
        {
            return (string)conector.DLookUp("dni", "customers", "idcustomer=(select refcustomer from invoices where num_invoice='" + num_invoice + "')");
        }


        public DataTable getTable (string editing_number)
        {
            decimal idInvoice = getIdInvoice(Convert.ToDecimal(editing_number));
            String queryContentProducts = "SELECT P.NAME DESCR,SUM(OP.AMOUNT) AMO, OP.PRICESALE PRIC, ROUND(SUM(OP.AMOUNT) * OP.PRICESALE, 2) TOTALPRIC " +
                                "FROM ORDERSPRODUCTS OP INNER JOIN PRODUCTS P ON OP.REFPRODUCT = P.IDPRODUCT " +
                            "INNER JOIN ORDERS_INVOICES OI ON OP.REFORDER = OI.IDORDER " +
                           "WHERE OI.IDINVOICE =" + idInvoice
                           + " GROUP BY P.NAME,OP.PRICESALE " +
                            "UNION " +
                           "SELECT LI.DESCRIPTION DESCR, LI.AMOUNT AMO, LI.PRICE PRIC, ROUND(LI.AMOUNT * LI.PRICE, 2) TOTALPRIC " +
                            "FROM LINES_INVOICE LI " +
                           "WHERE LI.REFINVOICE =" + idInvoice + ""
                           + " UNION " +
                           "SELECT P.NAME DESCR, PI.AMOUNT AMO, PI.PRICESALE PRIC, ROUND(PI.AMOUNT * PI.PRICESALE, 2) TOTALPRIC " +
                            "FROM PRODUCTS_INVOICES PI INNER JOIN PRODUCTS P ON PI.IDPRODUCT = P.IDPRODUCT " +
                           "WHERE PI.IDINVOICE =" + idInvoice + "";

            DataSet data = conector.getData(queryContentProducts, "table");
            DataTable tmp = data.Tables["table"];
            return tmp;
        }// i.gestor.editInvoice(editing_number, idcliente, amount);

        public void editInvoice (string editing_number, int idcliente, float amount)
        {
            conector.setData("update invoices set refcustomer=" + idcliente + ", amount='" + amount.ToString().Replace('.', ',') + "' where num_invoice=" + editing_number);
        }
    }

   
}
