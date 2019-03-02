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



    }
}
