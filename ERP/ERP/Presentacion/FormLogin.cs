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

namespace ERP
{
    public partial class FormLogin : Form
    {
        ConnectOracle conector;
        GestorUsuario gestorU;
        TabControl tbMenuP;


        public FormLogin(TabControl tbcMenu)
        {
            gestorU = new GestorUsuario();
            this.tbMenuP = tbcMenu;

            InitializeComponent();
            cargarComponentes();
            conector = new ConnectOracle();
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
            Application.Exit();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            String user = tbxUser.Text;
            //String pass = Encryptor.MD5Hash(tbxContraseña.Text);
            String pass = tbxPassword.Text;
            String condicion = " NAME = '" + user + "' AND PASSWORD = '" + pass + "'";

            String passDB = Convert.ToString(conector.DLookUp("IDUSER", "USERS", condicion));

            if (!passDB.Equals("-1"))
            {
                //MessageBox.Show("Login Succesful");
                //this.Dispose();
                gestorU.comprobarPermisos(user, pass, this.tbMenuP);
                this.Hide();
            }
            else
            {
                MessageBox.Show("ERROR");
            }
            //----------------------------

            //    String user = tbxUser.Text;
            ////String pass = Encryptor.MD5Hash(tbxContraseña.Text);
            //String pass = tbxPassword.Text;
            //String condicion = " NAME = '" + user + "' AND PASSWORD = '" + pass + "'";

            ////String passDB = Convert.ToString(conector.DLookUp("IDUSER", "USERS", condicion));

            //    if (user.Equals("Diego"))
            //    {
            //        //MessageBox.Show("Login Succesful");
            //        //this.Dispose();
            //        this.Hide();
            //   }
            //    else
            //    {
            //        MessageBox.Show("ERROR");
            //    }
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void cargarComponentes()
        {
            //Login
            btnConfirm.BackColor = Color.FromArgb(114, 47, 55);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.FlatAppearance.BorderColor = Color.Black;
            btnConfirm.FlatAppearance.BorderSize = 1;

            btnCancel.BackColor = Color.FromArgb(114, 47, 55);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = Color.Black;
            btnCancel.FlatAppearance.BorderSize = 1;

        }

        private void btnConfirm_MouseEnter(object sender, EventArgs e)
        {
            btnConfirm.BackColor = Color.White;
            btnConfirm.ForeColor = Color.Black;
        }

        private void btnConfirm_MouseLeave(object sender, EventArgs e)
        {
            btnConfirm.BackColor = Color.FromArgb(114, 47, 55);
            btnConfirm.ForeColor = Color.White;
        }

        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.White;
            btnCancel.ForeColor = Color.Black;
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.FromArgb(114, 47, 55);
            btnCancel.ForeColor = Color.White;
        }
    }
}
