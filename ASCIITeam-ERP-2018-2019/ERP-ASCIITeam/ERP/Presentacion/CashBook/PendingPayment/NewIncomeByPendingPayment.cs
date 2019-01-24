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

namespace ERP.Presentacion.CashBook.PendingPayment
{
    public partial class NewIncomeByPendingPayment : Form
    {
        Income income;
        DateTime dateIncome;
        decimal user;
        string concept;
        decimal amount;
        Boolean hecho;

        public NewIncomeByPendingPayment(DateTime dateIncome,decimal user,string concept,decimal amount)
        {
            InitializeComponent();
            income = new Income();
            this.dateIncome = dateIncome;
            this.user = user;
            this.concept = concept;
            this.amount = amount;
            hecho = false;
            cmbSource.DataSource = income.gestorIncome.getSources();
            cmbType.DataSource = income.gestorIncome.getTypes();
        }

        public Boolean getHecho()
        {
            return this.hecho;
        }

        private void cmbSource_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblSource_Click(object sender, EventArgs e)
        {

        }

        private void lblType_Click(object sender, EventArgs e)
        {

        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {

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

            income.gestorIncome.newIncome(new Dominio.Income(0, this.dateIncome, this.user, cmbSource.SelectedIndex, cmbType.SelectedIndex, this.concept, amountFinal));
            
            this.hecho = true;
            this.Dispose();
        }


        private double Truncate(double value, int decimales)
        {
            double aux_value = Math.Pow(10, decimales);
            return (Math.Truncate(value * aux_value) / aux_value);
        }
    }
}
