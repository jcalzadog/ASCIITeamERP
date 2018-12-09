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
            aparienciaBotones(btnClose);
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            dgvDetails.DataSource = new GestorOrder().getOrderCart(Convert.ToDecimal(id));
            DateTime d = (DateTime)new ConnectOracle().DLookUp("DATETIME", "ORDERS", "IDORDER='" + id + "'");
            lblDate.Text = d.ToString("dd/MM/yyyy");
            decimal t = (decimal)new ConnectOracle().DLookUp("TOTAL", "ORDERS", "IDORDER='" + id + "'");
            lblTotal.Text = t.ToString();
            dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void aparienciaBotones(Button btn)
        {
            btn.BackColor = Color.Black;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.Black;
            btn.FlatAppearance.BorderSize = 1;
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Black;
            ((Button)sender).ForeColor = Color.White;
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.White;
            ((Button)sender).ForeColor = Color.Black;
        }
    }
}
