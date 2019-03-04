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


        /// <summary>
        /// realiza las inserciones necesarias para generar una factura a partir de un pedido
        /// </summary>
        /// <param name="idOrder">pedido al que se le va a generar la factura</param>
        public decimal generateInvoice (decimal idOrder)
        {
            decimal numberInvoice = (decimal)conector.DLookUp("nvl(MAX(NUM_INVOICE)+1,TO_NUMBER(TO_CHAR(sysdate,'YYYY')||'0000')+1)", "invoices", "(NUM_INVOICE>TO_NUMBER(TO_CHAR(sysdate,'YYYY')||'0000') and NUM_INVOICE<TO_NUMBER(TO_CHAR(sysdate,'YYYY')+1||'0000'))");
            
            decimal idInvoice = (decimal)conector.DLookUp("nvl(MAX(ID)+1,1)", "invoices", "");
            decimal idCustomer = (decimal)conector.DLookUp("refcustomer", "orders", "where idorder='" + idOrder + "'");
            decimal amount = (decimal)conector.DLookUp("total", "orders", "where idorder='" + idOrder + "'");
            conector.setData("insert into invoices values ( '"+numberInvoice+"', sysdate, '"+idCustomer+"', '"+amount+"', 0, 0, '"+idInvoice+"'");
            return numberInvoice;
        }



    }
}
