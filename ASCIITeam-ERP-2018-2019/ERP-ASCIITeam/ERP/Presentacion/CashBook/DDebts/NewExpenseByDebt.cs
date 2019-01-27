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

namespace ERP.Presentacion.CashBook.DDebts
{
    public partial class NewExpenseByDebt : Form
    {

        Expense expense;
        DateTime dateExpense;
        decimal user;
        string concept;
        decimal amount;
        Boolean hecho;

        public NewExpenseByDebt(DateTime dateExpense, decimal user, string concept, decimal amount)
        {
            InitializeComponent();
            aparienciaBotones(btnSave);
            aparienciaBotones(btnCancel);
            expense = new Expense();
            this.dateExpense = dateExpense;
            this.user = user;
            this.concept = concept;
            this.amount = amount;
            hecho = false;
            cmbSource.DataSource = expense.gestorExpense.getSources();
            cmbType.DataSource = expense.gestorExpense.getTypes();
        }

        public Boolean getHecho()
        {
            return this.hecho;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            double amountTwoDeci = Truncate(Convert.ToDouble(this.amount), 2);
            string amountS = Convert.ToString(amountTwoDeci);
            decimal amountFinal = Convert.ToDecimal(amountS);

            expense.gestorExpense.newExpense(new Expense(0, this.dateExpense, this.user, cmbSource.SelectedIndex, cmbType.SelectedIndex, this.concept, amountFinal));

            this.hecho = true;
            this.Dispose();
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
    }
}
