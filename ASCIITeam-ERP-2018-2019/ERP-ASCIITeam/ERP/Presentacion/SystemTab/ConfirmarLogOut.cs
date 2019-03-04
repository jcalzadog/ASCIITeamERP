using ERP.Dominio;
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
        String[] paginas = {"Start","Users","Customers","Orders","Products","Categories","Platforms","CashBook","Invoices","System"};
        private TabControl tbcMenuPrincipal;
        public ConfirmarLogOut(TabControl tbcMenuPrincipal)
        {
            InitializeComponent();
            cargarComponentes();
            this.tbcMenuPrincipal = tbcMenuPrincipal;
        }

        public void cargarComponentes()
        {
            //Exit
            btnConfirmar.BackColor = Color.Black;
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.FlatAppearance.BorderColor = Color.Black;
            btnConfirmar.FlatAppearance.BorderSize = 1;

            btnCancelar.BackColor = Color.Black;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderColor = Color.Black;
            btnCancelar.FlatAppearance.BorderSize = 1;

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            
            for(int i = 0; i < 10;i++)
            {
                TabPage tp = tbcMenuPrincipal.TabPages[i];
                tp.Text = paginas[i];
            }
            
            FormLogin login = new FormLogin(this.tbcMenuPrincipal);
            this.Dispose();
            this.tbcMenuPrincipal.Hide();
            login.ShowDialog();
            if (!login.IsDisposed)
            {
                User usuario = new User();
                ERP.FormPrincipal.nombreUsuarioLogueado = login.nombreUsuario;
                ERP.Persistencia.Logs.idUser = usuario.gestorusuario.extraerIdUserLogueado(login.nombreUsuario);
                this.tbcMenuPrincipal.Visible = true;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void style_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Black;
            ((Button)sender).ForeColor = Color.White;
        }

        private void style_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Black;
            ((Button)sender).ForeColor = Color.White;
        }

    }
}
