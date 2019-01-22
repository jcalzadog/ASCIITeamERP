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

namespace ERP.Presentacion.CashBook.Validations
{
    public partial class ValidateHistory : Form
    {
        private Validation validation;
        private Object usuarioLogeado;
        private Decimal a_incash;
        private Decimal a_receipt;
        private Decimal a_check;
        private Decimal total;
        public ValidateHistory(Object usuarioLogeado,Decimal a_incash, Decimal a_receipt, Decimal a_check, Decimal total)
        {
            InitializeComponent();
            cargarComponentes();

            validation = new Validation();
            this.usuarioLogeado = usuarioLogeado;
            this.a_incash = a_incash;
            this.a_receipt = a_receipt;
            this.a_check = a_check;
            this.total = total;

            cargarTablaValidation();
        }

        private void cargarComponentes()
        {
            btnClose.BackColor = Color.Black;
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderColor = Color.Black;
            btnClose.FlatAppearance.BorderSize = 1;

            btnValidation.BackColor = Color.Black;
            btnValidation.ForeColor = Color.White;
            btnValidation.FlatStyle = FlatStyle.Flat;
            btnValidation.FlatAppearance.BorderColor = Color.Black;
            btnValidation.FlatAppearance.BorderSize = 1;
        }

        public void cargarTablaValidation()
        {
            validation.gestorValidation.readValidation();
            dgvValidate.DataSource = validation.gestorValidation.tValidation;
            dgvValidate.RowHeadersVisible = false;
            dgvValidate.AllowUserToAddRows = false;
            dgvValidate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvValidate.BackgroundColor = Color.Black;
            dgvValidate.Columns[0].Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            validation.gestorValidation.newValidation(new Dominio.Validation(0, DateTime.Today, (decimal)this.usuarioLogeado, this.a_incash, this.a_receipt, this.a_check, this.total));
            cargarTablaValidation();
        }

        private void btnValidation_MouseEnter(object sender, EventArgs e)
        {
            btnValidation.BackColor = Color.White;
            btnValidation.ForeColor = Color.Black;
        }

        private void btnValidation_MouseLeave(object sender, EventArgs e)
        {
            btnValidation.BackColor = Color.Black;
            btnValidation.ForeColor = Color.White;
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.White;
            btnClose.ForeColor = Color.Black;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.Black;
            btnClose.ForeColor = Color.White;
        }
    }
}
