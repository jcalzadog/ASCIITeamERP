using ERP.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Presentacion.CashBook.Incomes
{
    public partial class NewIncome : Form
    {

        Income income = new Income();
        public NewIncome(object userID)
        {
            InitializeComponent();
            rellenarCombos();
        }

        private void rellenarCombos()
        {
            
            foreach (String source in income.gestorIncome.getSources()){
                cmbSource.Items.Add(source);
            }

            foreach (String type in income.gestorIncome.getTypes())
            {
                cmbType.Items.Add(type);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tbxAmount_TextChanged(object sender, EventArgs e)
        {
            tbxAmount.Text = tbxAmount.Text.Replace(".", ",");
            tbxAmount.Text = Regex.Replace(tbxAmount.Text,"\\d*\\,\\d*", "");
        }
    }
}
