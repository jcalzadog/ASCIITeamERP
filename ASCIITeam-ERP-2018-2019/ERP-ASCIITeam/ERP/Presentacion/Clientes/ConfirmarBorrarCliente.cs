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

namespace ERP.Presentacion.Clientes
{
    public partial class ConfirmarBorrarCliente : Form
    {
        private Customer cliente;
        private DataGridView dgvCustomers;
        private String dniFilaSeleccionada;
        public ConfirmarBorrarCliente(DataGridView dgvCustomers, String dniFilaSeleccionada)
        {
            cliente = new Customer();
            InitializeComponent();
            cargaInicio();
            this.dgvCustomers = dgvCustomers;
            this.dniFilaSeleccionada = dniFilaSeleccionada;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //usuario.gestorusuario.eliminarUsuario(dgvUsers, this.nombreFilaSeleccionada);
            cliente.dni = dniFilaSeleccionada;
            cliente.gestorCliente.eliminarCliente(dgvCustomers, cliente);
            ERP.Persistencia.Logs.write("Customer " + cliente.name + " deleted");
            this.Dispose();
        }
        
        private void cargaInicio()
        {
            btnCancelar.BackColor = Color.Black;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderColor = Color.Black;
            btnCancelar.FlatAppearance.BorderSize = 1;

            btnConfirmar.BackColor = Color.Black;
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.FlatAppearance.BorderColor = Color.Black;
            btnConfirmar.FlatAppearance.BorderSize = 1;
        }

        private void style_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Black;
            ((Button)sender).ForeColor = Color.White;
        }

        private void style_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Black;
            ((Button)sender).ForeColor = Color.White;
        }
    }
 }

