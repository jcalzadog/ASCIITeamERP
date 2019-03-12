using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Presentacion.Invoices
{
    public partial class PrintInvoice : Form
    {
        private decimal idInvoice;
        public PrintInvoice(decimal idInvoice)
        {
            this.idInvoice = idInvoice;
            InitializeComponent();
            
        }

        private void PrintInvoice_Load(object sender, EventArgs e)
        {
            DataTable tProduct = contentProduct();
            DataTable tOrder = contentOrder();
            DataTable tInvoice = contentInvoice();
            DataTable tCustomer = customerData();

            CrystalReportInvoice miReporte = new CrystalReportInvoice();
            miReporte.Database.Tables["ContentProduct"].SetDataSource(tProduct);
            miReporte.Database.Tables["ContentOrder"].SetDataSource(tOrder);
            miReporte.Database.Tables["ContentInvoice"].SetDataSource(tInvoice);
            miReporte.Database.Tables["CustomerData"].SetDataSource(tCustomer);
            
            //miReporte.FileName = "C:\\Users\\Diego\\Desktop\\rptDetalleSalidas.rpt";

            crystalReportViewer1.ReportSource = miReporte;
        }

        private DataTable contentProduct()
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();
            DataTable tProducts = new DataTable();

            tProducts.Columns.Add("Cantidad", Type.GetType("System.String"));
            tProducts.Columns.Add("Descripcion", Type.GetType("System.String"));
            tProducts.Columns.Add("PrecioUni", Type.GetType("System.String"));
            tProducts.Columns.Add("Total", Type.GetType("System.String"));


            String queryContentProducts = "SELECT P.NAME DESCR,SUM(OP.AMOUNT) AMO,OP.PRICESALE PRIC, ROUND(SUM(OP.AMOUNT) * OP.PRICESALE, 2) TOTALPRIC " +
                                "FROM ORDERSPRODUCTS OP INNER JOIN PRODUCTS P ON OP.REFPRODUCT = P.IDPRODUCT " +
                            "INNER JOIN ORDERS_INVOICES OI ON OP.REFORDER = OI.IDORDER " +
                           "WHERE OI.IDINVOICE =" + this.idInvoice
                           + " GROUP BY P.NAME,OP.PRICESALE " +
                            "UNION " +
                           "SELECT LI.DESCRIPTION DESCR, LI.AMOUNT AMO, LI.PRICE PRIC, ROUND(LI.AMOUNT * LI.PRICE, 2) TOTALPRIC " +
                            "FROM LINES_INVOICE LI " +
                           "WHERE LI.REFINVOICE =" + this.idInvoice
                           + " UNION " +
                           "SELECT P.NAME DESCR, PI.AMOUNT AMO, PI.PRICESALE PRIC, ROUND(PI.AMOUNT * PI.PRICESALE, 2) TOTALPRIC " +
                            "FROM PRODUCTS_INVOICES PI INNER JOIN PRODUCTS P ON PI.IDPRODUCT = P.IDPRODUCT " +
                           "WHERE PI.IDINVOICE =" + this.idInvoice;

            data = search.getData(queryContentProducts, "table");
            DataTable tmp = data.Tables["table"];

            foreach (DataRow row in tmp.Rows)
            {
                tProducts.Rows.Add(new Object[] { row["AMO"], row["DESCR"], row["PRIC"], row["TOTALPRIC"] });
            }

            return tProducts;
        }

        private DataTable contentOrder()
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();
            DataTable tCustomers = new DataTable();

            tCustomers.Columns.Add("FormaPago", Type.GetType("System.String"));

            data = search.getData("SELECT P.PAYMENTMETHOD METH " +
                        "FROM PAYMENTMETHODS P INNER JOIN ORDERS O ON P.IDPAYMENTMETHOD = O.REFPAYMENTMETHOD " +
                            "INNER JOIN ORDERS_INVOICES OI ON O.IDORDER = OI.IDORDER " +
                        "WHERE OI.IDINVOICE =" + this.idInvoice,"table");
            DataTable tmp = data.Tables["table"];
            foreach (DataRow row in tmp.Rows)
            {
                tCustomers.Rows.Add(new Object[] { row["METH"] });
            }

            return tCustomers;
        }

        private DataTable contentInvoice()
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();
            DataTable tInvoice = new DataTable();

            tInvoice.Columns.Add("Id", Type.GetType("System.String"));
            tInvoice.Columns.Add("Fecha", Type.GetType("System.String"));
            tInvoice.Columns.Add("BaseImp", Type.GetType("System.String"));
            tInvoice.Columns.Add("Iva", Type.GetType("System.String"));
            tInvoice.Columns.Add("TotalFactura", Type.GetType("System.String"));

            data = search.getData("SELECT I.NUM_INVOICE NUMI, I.DATETIME DATETI, (I.AMOUNT-(I.AMOUNT*0.21)) BASEI, (I.AMOUNT*0.21) IVA, I.AMOUNT TOTALFAC FROM INVOICES I WHERE I.ID=" + this.idInvoice, "table");
            DataTable tmp = data.Tables["table"];

            foreach (DataRow row in tmp.Rows)
            {
                tInvoice.Rows.Add(new Object[] { row["NUMI"], row["DATETI"], row["BASEI"], row["IVA"], row["TOTALFAC"] });
            }

            return tInvoice;
        }

        private DataTable customerData()
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();
            DataTable tcustomers = new DataTable();

            tcustomers.Columns.Add("Dni", Type.GetType("System.String"));
            tcustomers.Columns.Add("Nombre", Type.GetType("System.String"));
            tcustomers.Columns.Add("Apellidos", Type.GetType("System.String"));
            tcustomers.Columns.Add("Poblacion", Type.GetType("System.String"));
            tcustomers.Columns.Add("Provincia", Type.GetType("System.String"));
            tcustomers.Columns.Add("CodPost", Type.GetType("System.String"));
            tcustomers.Columns.Add("Direc", Type.GetType("System.String"));
            tcustomers.Columns.Add("Telef", Type.GetType("System.String"));

            data = search.getData("SELECT C.DNI DNI, C.NAME NOMBRE, C.SURNAME APELLIDO, CIT.CITY POBLA, ST.STATE PROVI, ZC.ZIPCODE CODPOS, C.ADDRESS DIRECC, C.PHONE TELEF " +
                                    "FROM CUSTOMERS C INNER JOIN INVOICES I ON C.IDCUSTOMER = I.REFCUSTOMER " +
                                        "INNER JOIN ZIPCODESCITIES ZCC ON C.REFZIPCODESCITIES = ZCC.IDZIPCODESCITIES "+
                                        "INNER JOIN ZIPCODES ZC ON ZCC.REFZIPCODE = ZC.IDZIPCODE " +
                                        "INNER JOIN STATES ST ON ZCC.REFSTATE = ST.IDSTATE " +
                                        "INNER JOIN CITIES CIT ON ZCC.REFCITY = CIT.IDCITY " +
                                        "INNER JOIN REGIONS REG ON ST.REFREGION = REG.IDREGION " +
                                    "WHERE I.ID =" + this.idInvoice, "table");
            DataTable tmp = data.Tables["table"];

            foreach (DataRow row in tmp.Rows)
            {
                tcustomers.Rows.Add(new Object[] { row["DNI"], row["NOMBRE"], row["APELLIDO"], row["POBLA"],
                                row["PROVI"], row["CODPOS"], row["DIRECC"], row["TELEF"] });
            }


            return tcustomers;
        }

    }
}
