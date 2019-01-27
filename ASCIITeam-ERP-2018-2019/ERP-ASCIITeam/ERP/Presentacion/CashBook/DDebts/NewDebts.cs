using ERP.Dominio;
using ERP.Presentacion.ErroresCambios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Presentacion.CashBook.DDebts
{
    public partial class NewDebts : Form
    {
        Debts d = new Debts();
        Object usuarioLogueado;
        public NewDebts(Object usuario)
        {
            InitializeComponent();
            this.usuarioLogueado = usuario;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtConcept.Text == "" || txtAmount.Text == "")
            {

            }
            else
            {
                Boolean valido = true;
                for (int i = 0; i < txtAmount.Text.Length; i++)
                {
                    if (Char.IsLetter(txtAmount.Text.ElementAt(i)))
                    {
                        valido = false;
                    }
                }
                if (valido)
                {
                    if (decimal.Parse(txtAmount.Text) < 0)
                    {
                        VentanaPersonalizada vp = new VentanaPersonalizada("The amount is negative.");
                        vp.ShowDialog();
                    }
                    else
                    {
                        
                        decimal cant = decimal.Parse(txtAmount.Text.Replace(".", ",").Replace("'", ""));
                        //redondeamos
                        cant = Math.Round(cant, 2);
                        d.gestorDebts.newDebt(new Debts( 0, DateTime.Today, (decimal)this.usuarioLogueado, txtConcept.Text,cant, 0));
                        this.Dispose();
                    }
                }
                else
                {
                    VentanaPersonalizada vp = new VentanaPersonalizada("The amount is not valid.");
                    vp.ShowDialog();
                }
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valido = false;
            if (Char.IsDigit(e.KeyChar))
            {
                valido = true;
            }
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                if (!txtAmount.Text.Contains(","))
                {
                    e.KeyChar = ',';
                    valido = true;
                }

            }
            if (Char.IsControl(e.KeyChar))
            {
                valido = true;
            }
            e.Handled = !valido;
        }
    }
}
