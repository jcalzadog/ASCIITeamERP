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
    public partial class PayDebts : Form
    {
        Debts pDebt;
        decimal idpDebt;
        Object idUsuarioLogueado;

        public PayDebts(decimal idpDebt, Object idUsuarioLogueado)
        {
            InitializeComponent();
            pDebt = new Debts();
            this.idpDebt = idpDebt;
            this.idUsuarioLogueado = idUsuarioLogueado;
            aparienciaBotones(btnSave);
            aparienciaBotones(btnCancel);
            cargarInicio();
        }

        public void cargarInicio()
        {
            tbxTotal.Text = Convert.ToString(pDebt.gestorDebts.getAmount(this.idpDebt));
            txtNewDebt.Text = tbxTotal.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void chbCollectTotal_CheckedChanged(object sender, EventArgs e)
        {
            if (chbCollectTotal.CheckState == CheckState.Checked)
            {
                tbxAmount.Text = tbxTotal.Text;
                tbxAmount.Enabled = false;
                txtNewDebt.Text = "0";
            }
            else
            {
                tbxAmount.Enabled = true;
                tbxAmount.Text = "";
                txtNewDebt.Text = tbxTotal.Text;
            }
        }

        private void tbxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valido = false;
            if (Char.IsDigit(e.KeyChar))
            {
                valido = true;
            }
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                if (!tbxAmount.Text.Contains(","))
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

        private void tbxAmount_KeyUp(object sender, KeyEventArgs e)
        {
            decimal total = Convert.ToDecimal(tbxTotal.Text);
            if (tbxAmount.Text == "")
            {
                txtNewDebt.Text = tbxTotal.Text;
            }
            else
            {
                Boolean valido = true;
                Boolean coma = false;
                for (int i = 0; i < tbxAmount.Text.Length; i++)
                {
                    if (Char.IsLetter(tbxAmount.Text.ElementAt(i)))
                    {
                        valido = false;
                    }
                    if (!(Char.IsDigit(tbxAmount.Text.ElementAt(i))))
                    {
                        valido = false;
                    }
                    if ((tbxAmount.Text.ElementAt(i).Equals(',') || tbxAmount.Text.ElementAt(i).Equals('.')) && tbxAmount.Text.Length > 1)
                    {
                        valido = true;
                        if (!coma)
                        {
                            coma = true;
                        }
                        else
                        {
                            tbxAmount.Text = tbxAmount.Text.Substring(0, tbxAmount.Text.Length - 1);
                            tbxAmount.SelectionStart = tbxAmount.Text.Length;
                        }
                    }
                    if (valido)
                    {
                        decimal parcial = Convert.ToDecimal(tbxAmount.Text);
                        if (parcial < 0)
                        {
                            tbxAmount.Text = "";
                        }
                        else
                        {
                            if (parcial < total)
                            {
                                txtNewDebt.Text = Convert.ToString((total - parcial));
                            }
                            else
                            {
                                tbxAmount.Text = tbxTotal.Text;
                                txtNewDebt.Text = "0";
                            }
                        }

                    }
                    else
                    {
                        tbxAmount.Text = "";
                    }
                }
            }
        }

        private double Truncate(double value, int decimales)
        {
            double aux_value = Math.Pow(10, decimales);
            return (Math.Truncate(value * aux_value) / aux_value);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Boolean valido = true;
         
           
            if (tbxAmount.Text == "")
            {
                VentanaPersonalizada vp = new VentanaPersonalizada("Amount Not Valid.");
                valido = false;
                vp.ShowDialog();
            }
           
             if (valido)
            {
                
               for (int i = 0; i < tbxAmount.Text.Length; i++)
                {
                    if (Char.IsLetter(tbxAmount.Text.ElementAt(i)))
                    {
                       valido = false;
                   }
                }
            }

            if (valido)
            {
                decimal amount = Convert.ToDecimal(tbxAmount.Text);
                if (amount == 0)
                {
                    VentanaPersonalizada vp = new VentanaPersonalizada("Amount Not Valid.");
                    vp.ShowDialog();
                }
                else
                {
                    if (txtNewDebt.Text == "0")
                    {
                        //Total
                        DateTime dDate = pDebt.gestorDebts.getDate(this.idpDebt);
                        string dConcept = pDebt.gestorDebts.getConcept(this.idpDebt);

                        NewExpenseByDebt newExpenseD = new NewExpenseByDebt(dDate, (decimal)this.idUsuarioLogueado, dConcept, amount);
                        newExpenseD.ShowDialog();

                        if (newExpenseD.getHecho() == true)
                        {
                            pDebt.id = this.idpDebt;

                            pDebt.amount = Convert.ToDecimal(txtNewDebt.Text);
                            pDebt.gestorDebts.updateDebtsTotal(pDebt);
                            this.Dispose();
                        }
                    }
                    else
                    {
                        //Parcial
                        DateTime dDate = pDebt.gestorDebts.getDate(this.idpDebt);
                        string dConcept = pDebt.gestorDebts.getConcept(this.idpDebt);

                        NewExpenseByDebt newExpenseD = new NewExpenseByDebt(dDate, (decimal)this.idUsuarioLogueado, dConcept, amount);
                        newExpenseD.ShowDialog();

                        if (newExpenseD.getHecho() == true)
                        {
                            pDebt.id = this.idpDebt;
                            double newD = Truncate(Convert.ToDouble(this.txtNewDebt.Text), 2);
                            string dF = Convert.ToString(newD);

                            pDebt.amount = Convert.ToDecimal(dF);
                            pDebt.gestorDebts.updatePendingPaymentParcial(pDebt);
                            this.Dispose();
                        }


                    }
                }
            }
            
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
