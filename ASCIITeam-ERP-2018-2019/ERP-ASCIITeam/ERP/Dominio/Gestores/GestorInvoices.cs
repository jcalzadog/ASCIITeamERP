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
            data = conector.getData("SELECT NAME FROM PRODUCTS ", "PRODUCTS");
            Decimal cuentaProductos = (Decimal)conector.DLookUp("COUNT(IDPRODUCT)", "PRODUCTS", "");
            c.Items.Add("Nothing");
            for (int i = 0; i < cuentaProductos; i++)
            {
                c.Items.Add(data.Tables[0].Rows[i][0].ToString());
            }
            c.SelectedIndex = 0;
           
        }
        public decimal productPrice(String product) {
            decimal precio = (decimal)conector.DLookUp("PRICE", "PRODUCTS", "UPPER(NAME)='"+product.ToUpper()+"'");
            return precio;
        }

        /// <summary>
        /// realiza las inserciones necesarias para generar una factura a partir de un pedido
        /// </summary>
        /// <param name="idOrder">pedido al que se le va a generar la factura</param>
        public decimal generateInvoice (decimal idOrder)
        {
            decimal numberInvoice = (decimal)conector.DLookUp("nvl(MAX(NUM_INVOICE)+1,TO_NUMBER(TO_CHAR(sysdate,'YYYY')||'0000')+1)", "invoices", "(NUM_INVOICE>TO_NUMBER(TO_CHAR(sysdate,'YYYY')||'0000') and NUM_INVOICE<TO_NUMBER(TO_CHAR(sysdate,'YYYY')+1||'0000'))");
            
            decimal idInvoice = (decimal)conector.DLookUp("nvl(MAX(ID)+1,1)", "invoices", "");
            decimal idCustomer = (decimal)conector.DLookUp("refcustomer", "orders", "idorder='" + idOrder + "'");
            decimal amount = (decimal)conector.DLookUp("total", "orders", "idorder='" + idOrder + "'");
            conector.setData("insert into invoices values ( '"+numberInvoice+"', sysdate, '"+idCustomer+"', '"+amount+"', 0, 0, '"+idInvoice+"')");
            decimal idOrderInvoice = (decimal)conector.DLookUp("nvl(max(idorderinv)+1,1)", "orders_invoices", "");
            conector.setData("insert into orders_invoices values ('"+idOrderInvoice+"', '"+idOrder+"', '"+idInvoice+"')");
            return numberInvoice;
        }

        /// <summary>
        /// realiza las inserciones necesarias para generar una factura a partir de una factua a mano
        /// </summary>
        /// <param name="idCustomer">cliente al que se le va a generar la factura</param>
        /// <param name="amount">cantidad total a la que asciende la factura CON IVA</param>
        /// <return>idInvoice generado, de cara a insertar sus respectivas lineas y productos de factura</return>
        public decimal generateInvoice(decimal idCustomer, decimal amount)
        {
            decimal numberInvoice = (decimal)conector.DLookUp("nvl(MAX(NUM_INVOICE)+1,TO_NUMBER(TO_CHAR(sysdate,'YYYY')||'0000')+1)", "invoices", "(NUM_INVOICE>TO_NUMBER(TO_CHAR(sysdate,'YYYY')||'0000') and NUM_INVOICE<TO_NUMBER(TO_CHAR(sysdate,'YYYY')+1||'0000'))");

            decimal idInvoice = (decimal)conector.DLookUp("nvl(MAX(ID)+1,1)", "invoices", "");
            
            
            conector.setData("insert into invoices values ( '" + numberInvoice + "', sysdate, '" + idCustomer + "', '" + amount + "', 0, 0, '" + idInvoice + "')");
            
            return idInvoice;
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
