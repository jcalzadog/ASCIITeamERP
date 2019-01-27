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

namespace ERP.Presentacion.CashBook.PendingPayment
{
    public partial class CollectPendingPayment : Form
    {
        PendingPayments pendingPayment;
        decimal idPpay;
        Object idUsuarioLogueado;

        public CollectPendingPayment(decimal idPpayment,Object idUsuarioLogueado)
        {
            InitializeComponent();
            aparienciaBotones(btnCancel);
            aparienciaBotones(btnSave);
            pendingPayment = new PendingPayments();
            this.idPpay = idPpayment;
            this.idUsuarioLogueado = idUsuarioLogueado;
            cargarInicio();
        }

        public void cargarInicio()
        {
            tbxTotal.Text = Convert.ToString(pendingPayment.gestorPendingPayments.getAmount(this.idPpay));
            tbxNewPp.Text = tbxTotal.Text;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CollectPendingPayment_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

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
                tbxNewPp.Text = "0";
            } else
            {
                tbxAmount.Enabled = true;
                tbxAmount.Text = "";
                tbxNewPp.Text = tbxTotal.Text;
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
                tbxNewPp.Text = tbxTotal.Text;
            } else 
            {
                Boolean valido = true;
                for (int i = 0; i < tbxAmount.Text.Length; i++)
                {
                    if (Char.IsLetter(tbxAmount.Text.ElementAt(i)))
                    {
                        valido = false;
                    }
                }
                if (valido)
                {
                    decimal parcial = Convert.ToDecimal(tbxAmount.Text);
                    if (parcial < 0)
                    {
                        tbxAmount.Text = "";
                    } else {
                        if (parcial < total)
                        {
                            tbxNewPp.Text = Convert.ToString((total - parcial));
                        }
                        else
                        {
                            tbxAmount.Text = tbxTotal.Text;
                            tbxNewPp.Text = "0";
                        }
                    }
                    
                }else
                {
                    tbxAmount.Text = "";
                }
            }
            
        }

        private double Truncate(double value, int decimales)
        {
            double aux_value = Math.Pow(10, decimales);
            return (Math.Truncate(value * aux_value) / aux_value);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxAmount.Text == "")
            {
                VentanaPersonalizada vp = new VentanaPersonalizada("Amount Not Valid.");
                vp.ShowDialog();
            } else
            {
                decimal amount = Convert.ToDecimal(tbxAmount.Text);
                if(amount == 0)
                {
                    VentanaPersonalizada vp = new VentanaPersonalizada("Amount Not Valid.");
                    vp.ShowDialog();
                } else
                {
                    if(tbxNewPp.Text == "0")
                    {
                        //Total
                        DateTime ppDate = pendingPayment.gestorPendingPayments.getDate(this.idPpay);
                        string ppConcept = pendingPayment.gestorPendingPayments.getConcept(this.idPpay);

                        NewIncomeByPendingPayment newIncomePP = new NewIncomeByPendingPayment(ppDate, (decimal)this.idUsuarioLogueado, ppConcept, amount);
                        newIncomePP.ShowDialog();

                        if (newIncomePP.getHecho() == true)
                        {
                            pendingPayment.id = this.idPpay;

                            pendingPayment.amount = Convert.ToDecimal(tbxNewPp.Text);
                            pendingPayment.gestorPendingPayments.updatePendingPaymentTotal(pendingPayment);
                            this.Dispose();
                        }
                    } else
                    {
                        //Parcial
                        DateTime ppDate = pendingPayment.gestorPendingPayments.getDate(this.idPpay);
                        string ppConcept = pendingPayment.gestorPendingPayments.getConcept(this.idPpay);

                        NewIncomeByPendingPayment newIncomePP = new NewIncomeByPendingPayment(ppDate,(decimal)this.idUsuarioLogueado,ppConcept,amount);
                        newIncomePP.ShowDialog();
     
                        if (newIncomePP.getHecho() == true)
                        {
                            pendingPayment.id = this.idPpay;
                            double newPp = Truncate(Convert.ToDouble(this.tbxNewPp.Text), 2);
                            string pPF = Convert.ToString(newPp);

                            pendingPayment.amount = Convert.ToDecimal(pPF);
                            pendingPayment.gestorPendingPayments.updatePendingPaymentParcial(pendingPayment);
                            this.Dispose();
                        }
                           
                        
                    }
                }
            }
        }
    }
}
