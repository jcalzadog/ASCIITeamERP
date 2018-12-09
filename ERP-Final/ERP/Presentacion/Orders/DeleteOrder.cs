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

namespace ERP.Presentacion.Orders
{
    public partial class DeleteOrder : Form
    {
        bool acept;

        public bool Acept
        {
            get
            {
                return acept;
            }

            set
            {
                acept = value;
            }
        }

        public DeleteOrder()
        {
            InitializeComponent();
            acept = false;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            acept = true;
            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
