using ERP.Dominio;
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

namespace ERP.Presentacion.CashBook.Incomes
{
    partial class DeleteIncome : Form
    {
        decimal id;
        GestorIncomes gestor;
        decimal user;
        public DeleteIncome(Income i, decimal id,decimal user)
        {
            InitializeComponent();
            cargarComponentes();
            this.id = id;
            this.gestor = i.gestorIncome;
            this.user = user;
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            gestor.deleteIncome(id,user);
            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAceptar_MouseEnter(object sender, EventArgs e)
        {
           btnAceptar.BackColor = Color.White;
           btnAceptar.ForeColor = Color.Black;
        }

        private void btnAceptar_MouseLeave(object sender, EventArgs e)
        {
            btnAceptar.BackColor = Color.Black;
            btnAceptar.ForeColor = Color.White;


        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.Black;
            btnCancelar.ForeColor = Color.White;

        }

        private void btnCancelar_MouseEnter(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.White;
            btnCancelar.ForeColor = Color.Black;
        }
        public void cargarComponentes()
        {
            //Exit
            btnAceptar.BackColor = Color.Black;
            btnAceptar.ForeColor = Color.White;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.FlatAppearance.BorderColor = Color.Black;
            btnAceptar.FlatAppearance.BorderSize = 1;

            btnCancelar.BackColor = Color.Black;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderColor = Color.Black;
            btnCancelar.FlatAppearance.BorderSize = 1;

        }
    }
}
