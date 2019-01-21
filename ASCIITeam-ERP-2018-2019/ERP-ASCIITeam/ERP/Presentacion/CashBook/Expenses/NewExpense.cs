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
                
                gestor.newExpense(new Dominio.Expense(0, dtpDate.Value, (decimal)this.usuarioLogeado, cmbSource.SelectedIndex, cmbType.SelectedIndex, rtbConcept.Text, decimal.Parse(tbxAmount.Text)));

                this.Dispose();
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
    }
}
