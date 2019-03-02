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

namespace ERP.Presentacion.Usuarios
{
    public partial class Logs : Form
    {
        public Logs()
        {
            InitializeComponent();
            cargarInicio();
        }

        private void cargarInicio()
        {
            tbxUserName.ForeColor = Color.Gray;
            tbxUserName.Text = "Search a Username...";

            btnClose.BackColor = Color.Black;
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderColor = Color.Black;
            btnClose.FlatAppearance.BorderSize = 1;

            GestorLogs gestorL = new GestorLogs();
            gestorL.cargarTablaLogs(dgvLogs,"");
        }

        public void filtroTotal()
        {
            filtrarTablaLogs(tbxUserName.Text.Equals("Search a Username...") ? "" : tbxUserName.Text);
            //(tbxSearchUser.Text.Equals("Search a Name...") ? "" : tbxSearchUser.Text, deleted, combox.SelectedItem.Equals("Ninguno") ? "" :combox.SelectedItem.toString , );
        }

        public void filtrarTablaLogs(String name)
        {
            String condicion = "";
            condicion += " U.NAME like '%" + name + "%'";

            GestorLogs gestorL = new GestorLogs();
            gestorL.cargarTablaLogs(dgvLogs,condicion);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tbxUserName_Enter(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Equals("Search a Username..."))
            {
                ((TextBox)sender).Text = "";
                ((TextBox)sender).ForeColor = Color.Black;
            }
        }

        private void tbxUserName_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Trim().Equals(""))
            {
                ((TextBox)sender).ForeColor = Color.Gray;
                ((TextBox)sender).Text = "Search a Username...";
            }
        }

        private void tbxUserName_KeyUp(object sender, KeyEventArgs e)
        {
            filtroTotal();
        }
    }
}
