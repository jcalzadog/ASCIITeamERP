using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Presentacion.Usuarios
{
    public partial class NuevoUsuario : Form
    {
        ConnectOracle conector;
        public NuevoUsuario()
        {
            conector = new ConnectOracle();
            InitializeComponent();
            cargarComponentes();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveAnother_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {

        }

        private void btnNewRole_Click(object sender, EventArgs e)
        {
            NuevoRol newRol = new NuevoRol();
            newRol.ShowDialog();
        }

        public void cargarComponentes()
        {
            btnNewRole.FlatStyle = FlatStyle.Flat;
            btnNewRole.FlatAppearance.BorderColor = Color.Black;
            btnNewRole.FlatAppearance.BorderSize = 1;

            btnEditRole.FlatStyle = FlatStyle.Flat;
            btnEditRole.FlatAppearance.BorderColor = Color.Black;
            btnEditRole.FlatAppearance.BorderSize = 1;

            btnSaveClose.FlatStyle = FlatStyle.Flat;
            btnSaveClose.FlatAppearance.BorderColor = Color.Black;
            btnSaveClose.FlatAppearance.BorderSize = 1;

            btnSaveAnother.FlatStyle = FlatStyle.Flat;
            btnSaveAnother.FlatAppearance.BorderColor = Color.Black;
            btnSaveAnother.FlatAppearance.BorderSize = 1;

            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderColor = Color.Black;
            btnSave.FlatAppearance.BorderSize = 1;

            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = Color.Black;
            btnCancel.FlatAppearance.BorderSize = 1;

            LinkedList<Object> listaPermits = new LinkedList<Object>();
            listaPermits.AddFirst(conector.DLookUp("NAME", "PERMITS", "IDPERMIT=1"));
            listaPermits.AddLast(conector.DLookUp("NAME", "PERMITS", " IDPERMIT=2"));
            listaPermits.AddLast(conector.DLookUp("NAME", "PERMITS", " IDPERMIT=3"));
            listaPermits.AddLast(conector.DLookUp("NAME", "PERMITS", " IDPERMIT=4"));
            listaPermits.AddLast(conector.DLookUp("NAME", "PERMITS", " IDPERMIT=5"));
            listaPermits.AddLast(conector.DLookUp("NAME", "PERMITS", " IDPERMIT=6"));

            cmbRoles.Items.Clear();
            int cont = 0;
            while(cont< listaPermits.Count)
            {
                cmbRoles.Items.Add(listaPermits.ElementAt(cont));
                cont++;
            }
            
        }

        private void btnEditRole_Click(object sender, EventArgs e)
        {
            EditarRol editRol = new EditarRol();
            editRol.ShowDialog();
        }
    }
}
