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

            //CrystalReport1 miReporte = new CrystalReport1();
            //miReporte.Database.Tables["Customers"].SetDataSource(tcustomers);


            //crystalReportViewer1.ReportSource = miReporte;
        }
    }
}
