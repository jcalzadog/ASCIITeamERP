using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Presentacion.ErroresCambios
{
    public partial class VentanaPersonalizada : Form
    {
        public VentanaPersonalizada(String mensaje)
        {
            InitializeComponent();
            cargarComponentes();

            lblMensaje.Text = mensaje;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void cargarComponentes()
        {
            btnClose.BackColor = Color.Black;
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderColor = Color.Black;
            btnClose.FlatAppearance.BorderSize = 1;
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.White;
            btnClose.ForeColor = Color.Black;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.Black;
            btnClose.ForeColor = Color.White;
        }
    }
}
