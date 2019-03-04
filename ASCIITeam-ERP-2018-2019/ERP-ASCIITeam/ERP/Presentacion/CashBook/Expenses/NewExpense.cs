using ERP.Dominio;
using ERP.Dominio.Gestores;
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

namespace ERP.Presentacion.CashBook.Expenses
{
    public partial class NewExpense : Form
    {
        GestorExpenses gestor;
        Income incomeComprobante;
        Object usuarioLogeado;
        public NewExpense(Object usuarioLogeado)
        {
            InitializeComponent();
            cargarComponentes();

            this.usuarioLogeado = usuarioLogeado;
            dtpDate.MaxDate = DateTime.Today;
            dtpDate.Value = DateTime.Today;
            dtpDate.MinDate = DateTime.Today.AddDays(-7);
            gestor = new Expense().gestorExpense;
            incomeComprobante = new Income();
            cmbSource.DataSource = gestor.getSources();
            cmbType.DataSource = gestor.getTypes();
        }

        private void cargarComponentes()
        {
            btnSave.BackColor = Color.Black;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderColor = Color.Black;
            btnSave.FlatAppearance.BorderSize = 1;

            btnCancel.BackColor = Color.Black;
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = Color.Black;
            btnCancel.FlatAppearance.BorderSize = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

        private void btnSave_Click(object sender, EventArgs e)
        {


            if (rtbConcept.Text == "" || tbxAmount.Text == "")
            {
                VentanaPersonalizada vp = new VentanaPersonalizada("Debes introducir datos en todos los campos");
                vp.ShowDialog();
            }
            else
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
                    if (decimal.Parse(tbxAmount.Text) < 0)
                {
                    VentanaPersonalizada vp = new VentanaPersonalizada("The amount is negative.");
                    vp.ShowDialog();
                }
                else
                {
                        Boolean esPosible = true;
                        if (cmbType.SelectedIndex == 0)
                        {
                            decimal totalCash = (incomeComprobante.gestorIncome.getTotalCash() - gestor.getTotalCash());
                            decimal resultado = totalCash - decimal.Parse(tbxAmount.Text);
                            if (resultado < 0)
                            {
                                esPosible = false;
                            }
                        }
                        if (cmbType.SelectedIndex == 1)
                        {
                            decimal totalCheck = (incomeComprobante.gestorIncome.getTotalChecks() - gestor.getTotalChecks());
                            decimal resultado = totalCheck - decimal.Parse(tbxAmount.Text);
                            if (resultado < 0)
                            {
                                esPosible = false;
                            }
                        }
                        if (cmbType.SelectedIndex == 2)
                        {
                            decimal totalReceipt = (incomeComprobante.gestorIncome.getTotalReceipts() - gestor.getTotalReceipts());
                            decimal resultado = totalReceipt - decimal.Parse(tbxAmount.Text);
                            if (resultado < 0)
                            {
                                esPosible = false;
                            }
                        }

                        if (esPosible)
                        {
                            gestor.newExpense(new Dominio.Expense(0, dtpDate.Value, (decimal)this.usuarioLogeado, cmbSource.SelectedIndex, cmbType.SelectedIndex, rtbConcept.Text, decimal.Parse(tbxAmount.Text)));
                            this.Dispose();
                        }
                        else
                        {
                            VentanaPersonalizada vp = new VentanaPersonalizada("There is no income for the action.");
                            vp.ShowDialog();
                        }
                    }
                }
                else
                {
                    VentanaPersonalizada vp = new VentanaPersonalizada("The amount is not valid.");
                    vp.ShowDialog();
                }
               
            }

        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.White;
            btnSave.ForeColor = Color.Black;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.Black;
            btnSave.ForeColor = Color.White;
        }

        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.White;
            btnCancel.ForeColor = Color.Black;
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.Black;
            btnCancel.ForeColor = Color.White;
        }

        private void NewExpense_Load(object sender, EventArgs e)
        {

        }

        private void tbxAmount_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void tbxAmount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
