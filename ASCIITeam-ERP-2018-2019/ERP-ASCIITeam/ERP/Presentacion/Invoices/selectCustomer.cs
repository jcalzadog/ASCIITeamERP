﻿using ERP.Dominio.Gestores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Presentacion.Invoices
{
    public partial class selectCustomer : Form
    {
        Customer c = new Customer();
        public string customername;
        public selectCustomer()
        {
            InitializeComponent();
            dgvClientes.Columns.Add("DNI", "DNI");
            dgvClientes.Columns.Add("NAME", "NAME");
            dgvClientes.Columns.Add("SURNAME", "SURNAME");
            dgvClientes.Columns.Add("ADDRESS", "ADDRESS");
            dgvClientes.Columns.Add("PHONE", "PHONE");
            dgvClientes.Columns.Add("EMAIL", "EMAIL");
            dgvClientes.Columns.Add("CITY", "CITY");
            this.dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.BackgroundColor = Color.Black;
            dgvClientes.ReadOnly = true;                               
            cargarClientes();
        
        }
        public void cargarClientes() {
            //dgvClientes.Columns.Clear();
            c.gestorCliente.leerClientes("DELETED=0");
            DataTable tcustomers = c.gestorCliente.tabla;                
            foreach (DataRow row in tcustomers.Rows)
            {
                dgvClientes.Rows.Add(row["DNI"], row["NAME"], row["SURNAME"], row["ADDRESS"], row["PHONE"], row["EMAIL"], row["CITY"]);
            }
         
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        { 
          this.customername = dgvClientes.Rows[dgvClientes.CurrentRow.Index].Cells[0].Value.ToString();
           this.Dispose();
        }

 
        private void filtrarTablaClientes(String name)
        {
            String condicion = "";
            condicion += " (UPPER(C.NAME) like '%" + name.ToUpper() + "%' OR UPPER(C.SURNAME) like '%" + name.ToUpper() +"%' OR C.DNI like '%" + name + "%') AND C.DELETED=0";

            dgvClientes.Columns.Clear();
            c.gestorCliente.leerClientes(condicion);


            DataTable tcustomers = c.gestorCliente.tabla;
            dgvClientes.Columns.Clear();

            dgvClientes.Columns.Add("DNI", "DNI");
            dgvClientes.Columns.Add("NAME", "NAME");
            dgvClientes.Columns.Add("SURNAME", "SURNAME");
            dgvClientes.Columns.Add("ADDRESS", "ADDRESS");
            dgvClientes.Columns.Add("PHONE", "PHONE");
            dgvClientes.Columns.Add("EMAIL", "EMAIL");
            dgvClientes.Columns.Add("CITY", "CITY");

            foreach (DataRow row in tcustomers.Rows)
            {
                dgvClientes.Rows.Add(row["DNI"], row["NAME"], row["SURNAME"], row["ADDRESS"], row["PHONE"], row["EMAIL"], row["CITY"]);
            }
       

        }
        private void txtFilter_KeyUp(object sender, KeyEventArgs e)
        {
            filtrarTablaClientes(this.txtFilter.Text);
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valido = false;
      
            if (Char.IsLetterOrDigit(e.KeyChar)) {
                valido = true;
            }
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
             
                    valido = false;
                

            }
            if (Char.IsControl(e.KeyChar))
            {
                valido = true;
            }
            e.Handled = !valido;
        }
    }
}
