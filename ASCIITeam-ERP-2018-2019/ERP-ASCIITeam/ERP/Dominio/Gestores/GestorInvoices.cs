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

        public decimal generateInvoice(decimal idCustomer, float amount)
        {
            decimal numberInvoice = (decimal)conector.DLookUp("nvl(MAX(NUM_INVOICE)+1,TO_NUMBER(TO_CHAR(sysdate,'YYYY')||'0000')+1)", "invoices", "(NUM_INVOICE>TO_NUMBER(TO_CHAR(sysdate,'YYYY')||'0000') and NUM_INVOICE<TO_NUMBER(TO_CHAR(sysdate,'YYYY')+1||'0000'))");

            decimal idInvoice = (decimal)conector.DLookUp("nvl(MAX(ID)+1,1)", "invoices", "");
            
            
            conector.setData("insert into invoices values ( '" + numberInvoice + "', sysdate, '" + idCustomer + "', '" + amount + "', 0, 0, '" + idInvoice + "')");
            
            return idInvoice;
        }

        public void insertarProductInvoices(int idproduct,int idinvoice,int amount,float price) {
            decimal idProductInvoice = (decimal)conector.DLookUp("nvl(MAX(IDPROINV)+1,1)", "products_invoices", "");
            conector.setData("INSERT INTO PRODUCTS_INVOICES VALUES('" + idProductInvoice + "','" + idproduct + "','" + idinvoice + "','" + amount + "','" + price + "')");
        }

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

        public bool isPosted (string num_invoice)
        {
            decimal posted = Convert.ToDecimal(conector.DLookUp("POSTED", "INVOICES", "NUM_INVOICE='" + num_invoice + "'"));

            return posted == 1;
        }

        public void post (string num_invoice)
        {
            conector.setData("update invoices set posted=1 where num_invoice=" + num_invoice);
        }

        public void delete (string num_invoice)
        {
            conector.setData("update invoices set deleted=1 where num_invoice=" + num_invoice);
        }

    }
}
