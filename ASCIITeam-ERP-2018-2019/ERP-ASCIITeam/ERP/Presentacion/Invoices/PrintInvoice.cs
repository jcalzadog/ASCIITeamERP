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
        public PrintInvoice()
        {
            InitializeComponent();
        }

        private void PrintInvoice_Load(object sender, EventArgs e)
        {
            //DataSet data = new DataSet();
            //ConnectOracle search = new ConnectOracle();
            //DataTable tcustomers = new DataTable();

            //tcustomers.Columns.Add("Name", Type.GetType("System.String"));
            //tcustomers.Columns.Add("Surname", Type.GetType("System.String"));

            //data = search.getData("select * from clientes", "customers");
            //DataTable tmp = data.Tables["customers"];

            //foreach (DataRow row in tmp.Rows)
            //{
            //    tcustomers.Rows.Add(new Object[] { row["nombre"], row["apellido1"] });
            //}

            ///*tcustomers.Rows.Add(new Object[] { "Luis", "Ayuga" });
            //tcustomers.Rows.Add(new Object[] { "Pedro", "Juarez" });*/

            //CrystalReportInvoice miReporte = new CrystalReportInvoice();
            //miReporte.Database.Tables["Customers"].SetDataSource(tcustomers);


            //crystalReportViewer1.ReportSource = miReporte;


            //DataTable tinvo = llenaInvo();
            //DataTable tcus = llenaCusto();
            //DataTable tpro = llenaPro();
            //DataTable to = llenaOrd();

            //Crys miReporte = new Crys();
            //miReporte.Database.Tables["invo"].SetDataSource(tinvo);
            //miReporte.Database.Tables["custo"].SetDataSource(tcus);
            //miReporte.Database.Tables["produ"].SetDataSource(tpro);
            //miReporte.Database.Tables["order"].SetDataSource(to);


            //crystalReportViewer1.ReportSource = miReporte;
        }

        //private DataTable llenaOrd()
        //{
        //    DataSet data = new DataSet();
        //    ConnectOracle search = new ConnectOracle();
        //    DataTable tcustomers = new DataTable();

        //    tcustomers.Columns.Add("FormaPago", Type.GetType("System.String"));


        //    //data = search.getData("select * from invoices where idinvoice = " + "20190001", "cus");
        //    //DataTable tmp = data.Tables["cus"];

        //    //foreach (DataRow row in tmp.Rows)
        //    //{
        //    //tcustomers.Rows.Add(new Object[] { row["idinvoice"], row["date_invoice"], row["net_amount"], row["amount"] });
        //    //}
        //    String tipo = search.getData("select PAYMENTMETHOD from PAYMENTMETHODS where IDPAYMENTMETHOD = " + refTipo);
        //    tcustomers.Rows.Add(new Object[] { tipo });

        //    return tcustomers;
        //}
    }
}
