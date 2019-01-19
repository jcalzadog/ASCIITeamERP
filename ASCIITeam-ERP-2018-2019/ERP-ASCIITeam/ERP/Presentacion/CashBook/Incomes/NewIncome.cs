﻿using ERP.Dominio;
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
    public partial class NewIncome : Form
    {
        GestorIncomes gestor;
        Object usuarioLogeado;
        public NewIncome(Object usuarioLogeado)
        {
            InitializeComponent();
            this.usuarioLogeado = usuarioLogeado;
            dtpDate.MaxDate = DateTime.Today;
            dtpDate.Value = DateTime.Today;
            dtpDate.MinDate = DateTime.Today.AddDays(-7);
            gestor = new Income().gestorIncome;
            cmbSource.DataSource = gestor.getSources();
            cmbType.DataSource = gestor.getTypes();
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
            if (e.KeyChar == '.' || e.KeyChar==',')
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
            if (rtbConcept.Text=="" || tbxAmount.Text == "")
            {

            }
            else
            {
                gestor.newIncome(new Dominio.Income(0, dtpDate.Value, (decimal)this.usuarioLogeado, cmbSource.SelectedIndex, cmbType.SelectedIndex, rtbConcept.Text, decimal.Parse(tbxAmount.Text)));
                this.Dispose();
            }
            
        }
    }
}
