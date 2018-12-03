using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Dominio.Gestores
{
    class GestorPlatform
    {
        ConnectOracle conector;
        LinkedList<Object> listaPlat;
        public GestorPlatform()
        {
            conector = new ConnectOracle();
            listaPlat = new LinkedList<object>();
        }

        public void refrescarPlatform(ComboBox cmbPlatform)
        {
            Decimal numPlat = (Decimal)conector.DLookUp("MAX(IDPLATFORM)", "PLATFORMS", "");
            //int numRoles = int.Parse(numR);

            listaPlat = new LinkedList<Object>();
            for (int i = 1; i <= numPlat; i++)
            {
                listaPlat.AddLast(conector.DLookUp("NAME", "PLATFORMS", " IDPLATFORM=" + i));
            }

            cmbPlatform.Items.Clear();
            int cont = 0;
            while (cont < listaPlat.Count)
            {
                cmbPlatform.Items.Add(listaPlat.ElementAt(cont));
                cont++;
            }
            cmbPlatform.SelectedIndex = 0;
        }
    }
}
