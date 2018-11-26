using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            String user = tbxUser.Text;
            //String pass = Encryptor.MD5Hash(tbxContraseña.Text);
            String pass = tbxPassword.Text;
            String condicion = " USUARIO = '" + user + "' AND CONTRASENA = '" + pass + "'";

            //String passDB = Convert.ToString(conector.DLookUp("ID", "USUARIOS", condicion));

            if (!passDB.Equals("-1"))
            {
                MessageBox.Show("Login Succesful");
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }
    }
}
