using ERP.Dominio;
using ERP.Presentacion.ErroresCambios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Presentacion.Plataformas
{
    public partial class AddPlataforma : Form
    {
        private Platforms plataforma;
        public AddPlataforma()
        {
            InitializeComponent();
            cargarDiseño();
            plataforma = new Platforms();
        }

        private void btnSaveAnother_Click(object sender, EventArgs e)
        {
            if (Dominio.Util.Validations.validatePlatforms(textBox1.Text))
            {
                plataforma.name = textBox1.Text;
                plataforma.gestorplataforma.insertPlataforma(plataforma);
                textBox1.Text = "";
                plataforma.gestorplataforma.readPlatforms();
                ERP.Persistencia.Logs.write("Platform " + textBox1.Text + " created");
            }
            else {
                VentanaPersonalizada vp = new VentanaPersonalizada("Has introducido caracteres invalidos");
                vp.ShowDialog();
            }
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Dominio.Util.Validations.validatePlatforms(textBox1.Text))
            {
                plataforma.name = textBox1.Text;
                plataforma.gestorplataforma.insertPlataforma(plataforma);
                plataforma.gestorplataforma.readPlatforms();
                ERP.Persistencia.Logs.write("Platform " + textBox1.Text + " created");
                this.Dispose();
            }
            else
            {
                VentanaPersonalizada vp = new VentanaPersonalizada("Has introducido caracteres invalidos");
                vp.ShowDialog();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void cargarDiseño()
        {
            btnSave.BackColor = Color.Black;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderColor = Color.Black;
            btnSave.FlatAppearance.BorderSize = 1;

            btnSaveAnother.BackColor = Color.Black;
            btnSaveAnother.ForeColor = Color.White;
            btnSaveAnother.FlatStyle = FlatStyle.Flat;
            btnSaveAnother.FlatAppearance.BorderColor = Color.Black;
            btnSaveAnother.FlatAppearance.BorderSize = 1;

            btnCancelar.BackColor = Color.Black;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderColor = Color.Black;
            btnCancelar.FlatAppearance.BorderSize = 1;
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

        private void btnSaveAnother_MouseLeave(object sender, EventArgs e)
        {
            btnSaveAnother.BackColor = Color.Black;
            btnSaveAnother.ForeColor = Color.White;
        }

        private void btnSaveAnother_MouseEnter(object sender, EventArgs e)
        {
            btnSaveAnother.BackColor = Color.White;
            btnSaveAnother.ForeColor = Color.Black;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.Black;
            btnSave.ForeColor = Color.White;
        }
    }
}
