using ERP.Dominio.Gestores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Presentacion.Orders
{
    public partial class ViewOrder : Form
    {
        public ViewOrder(string id)
        {
            InitializeComponent();
            dgvDetails.DataSource = new GestorOrder().getOrderCart(Convert.ToDecimal(id));
            DateTime d = (DateTime)new ConnectOracle().DLookUp("DATETIME", "ORDERS", "IDORDER='" + id + "'");
            lblDate.Text = d.ToString("dd/MM/yyyy");
            decimal t = (decimal)new ConnectOracle().DLookUp("TOTAL", "ORDERS", "IDORDER='" + id + "'");
            lblTotal.Text = t.ToString();
            dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
