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
    public partial class NuevoCliente : Form
    {
        private Customer customer;

        public NuevoCliente()
        {
            customer = new Customer();
            InitializeComponent();
            cargarDatos();
        }

        private void cargarDatos()
        {
            cmbState.Enabled = false;
            customer.gestorCliente.refrescarRegions(cmbRegion);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NuevoCliente_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRegion.SelectedItem.Equals("Ninguno"))
            {
                cmbState.Enabled = false;
            } else
            {
                cmbState.Enabled = true;
                customer.gestorCliente.refrescarState(cmbState,cmbRegion.SelectedItem.ToString());
            }
            
        }
    }
}
