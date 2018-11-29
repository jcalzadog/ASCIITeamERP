using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Presentacion.SystemTab
{
    public partial class ConfirmarLogOut : Form
    {
        private TabControl tbcMenuPrincipal;
        public ConfirmarLogOut(TabControl tbcMenuPrincipal)
        {
            InitializeComponent();
            this.tbcMenuPrincipal = tbcMenuPrincipal;
        }

        private void lblExit_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin(this.tbcMenuPrincipal);
            this.Dispose();
            this.tbcMenuPrincipal.Hide();
            login.ShowDialog();
            if (!login.IsDisposed)
            {
                this.tbcMenuPrincipal.Visible = true;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
