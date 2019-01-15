using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Presentacion
{
    public partial class FormCargaInicial : Form
    {
        public FormCargaInicial()
        {
            InitializeComponent();
        }

        public void fn_progressBar()
        {
            progressBar1.Increment(5);
            if(progressBar1.Value == progressBar1.Maximum)
            {
                timerProgressBar.Stop();
                this.Hide();
            }
        }

        private void timerProgressBar_Tick(object sender, EventArgs e)
        {
            fn_progressBar();
        }
    }
}
