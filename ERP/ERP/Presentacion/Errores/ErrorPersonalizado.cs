using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Presentacion.Errores
{
    public partial class ErrorPersonalizado : Form
    {
        public ErrorPersonalizado(String mensaje)
        {
            InitializeComponent();
            cargarComponentes();
            lblMensaje.Text = mensaje;
        }

        public void cargarComponentes()
        {
            btnClose.BackColor = Color.FromArgb(114, 47, 55);
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
            btnClose.BackColor = Color.FromArgb(114, 47, 55);
            btnClose.ForeColor = Color.White;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
