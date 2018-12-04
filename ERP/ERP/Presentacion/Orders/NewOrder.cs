using System;
using System.Windows.Forms;

namespace ERP.Presentacion.Orders
{
    public partial class NewOrder : Form
    {
        decimal idCustomer;
        decimal userId;
        public NewOrder( decimal userId)
        {
            InitializeComponent();
            this.userId = userId;
            initPayMethods();
        }

        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            SelectCustomer selector = new SelectCustomer(txtNameCustomer);
            selector.ShowDialog();
            idCustomer = selector.id;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void initPayMethods()
        {
            decimal numberOfMethods =(decimal) new ConnectOracle().DLookUp("COUNT(*)", "PAYMENTMETHODS", "DELETED=0");
            for (int i = 0; i < numberOfMethods; i++)
            {
                cboPayMethods.Items.Add(new ConnectOracle().DLookUp("PAYMENTMETHOD", "PAYMENTMETHODS", "IDPAYMENTMETHOD='" + (i + 1) + "'"));
            }
            cboPayMethods.SelectedIndex = 0;
        }
    }
}
