using ERP.Presentacion.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using ERP.Presentacion.Categorias;

namespace ERP
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            tbcMenuPrincipal.Width = this.Width;
            tbcMenuPrincipal.Height = this.Height;
            tbcMenuPrincipal.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);
            cargarComponentes();
            cargarTablaUser();

            FormLogin login = new FormLogin();
            login.ShowDialog();

            /* activar o desactivar pestañas  ((Control)tabPage1).Enabled = true;    y  tbcMenuPrincipal.SelectTab(1);*/
        }

        private void tabControl1_DrawItem(Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tbcMenuPrincipal.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tbcMenuPrincipal.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Black);
                // g.FillRectangle(Brushes.Red, e.Bounds);
                g.FillRectangle(Brushes.SteelBlue, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Arial", 10.0f, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((Control)tabPage1).Enabled = true;
            ((Control)tabPage3).Enabled = true;
            ((Control)tabPage4).Enabled = true;
            ((Control)tabPage5).Enabled = true;
            ((Control)tabPage6).Enabled = true;
            ((Control)tabPage7).Enabled = true;
            ((Control)tabPage8).Enabled = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbcMenuPrincipal.SelectTab(1);
            ((Control)tabPage1).Enabled = false;
            ((Control)tabPage3).Enabled = false;
            ((Control)tabPage4).Enabled = false;
            ((Control)tabPage5).Enabled = false;
            ((Control)tabPage6).Enabled = false;
            ((Control)tabPage7).Enabled = false;
            ((Control)tabPage8).Enabled = false;
        }

  

        private void FormPrincipal_SizeChanged(object sender, EventArgs e)
        {
            tbcMenuPrincipal.Width = this.Width;
            tbcMenuPrincipal.Height = this.Height;
        }

        private void tabPage2_Resize(object sender, EventArgs e)
        {
            
            dgvUsers.Width = this.Width-150;
            dgvUsers.Height = this.Height-100;

        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {

        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            NuevoUsuario newUser = new NuevoUsuario();
            newUser.ShowDialog();
        }

        private void btnNewCategorie_Click(object sender, EventArgs e)
        {
            //AddCategorie ncategorie = new AddCategorie();
            //ncategorie.ShowDialog();

        }

        private void btnUpdateCategorie_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteCategorie_Click(object sender, EventArgs e)
        {

        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            NuevoRol newRol = new NuevoRol();
            newRol.ShowDialog();
        }

        public void cargarTablaUser()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();
            //SELECT U.NAME,R.NAME FROM USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE;
            data = Search.getData("SELECT * FROM USERS ORDER BY IDUSER", "USERS");

            DataTable tusers = data.Tables["USERS"];

            //dgvCustomers.DataSource = tcustomers;

            dgvUsers.Columns.Add("IDUSER", "ID");
            dgvUsers.Columns.Add("NAME", "NAME");
            dgvUsers.Columns.Add("PASSWORD", "PASSWORD");
            dgvUsers.Columns.Add("DELETED", "DELETED");

            foreach (DataRow row in tusers.Rows)
            {
                dgvUsers.Rows.Add(row["IDUSER"], row["NAME"], row["PASSWORD"], row["DELETED"]);
            }
            //dgvUsers.ColumnHeadersVisible = false;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void cargarComponentes()
        {
            //Usuarios
            btnNewUser.FlatStyle = FlatStyle.Flat;
            btnNewUser.FlatAppearance.BorderColor = Color.Black;
            btnNewUser.FlatAppearance.BorderSize = 1;

            btnRoles.FlatStyle = FlatStyle.Flat;
            btnRoles.FlatAppearance.BorderColor = Color.Black;
            btnRoles.FlatAppearance.BorderSize = 1;

            btnDeleteUser.FlatStyle = FlatStyle.Flat;
            btnDeleteUser.FlatAppearance.BorderColor = Color.Black;
            btnDeleteUser.FlatAppearance.BorderSize = 1;

            btnLogs.FlatStyle = FlatStyle.Flat;
            btnLogs.FlatAppearance.BorderColor = Color.Black;
            btnLogs.FlatAppearance.BorderSize = 1;

            //Categorias
            btnNewCategorie.FlatStyle = FlatStyle.Flat;
            btnNewCategorie.FlatAppearance.BorderColor = Color.Black;
            btnNewCategorie.FlatAppearance.BorderSize = 1;

            btnUpdateCategorie.FlatStyle = FlatStyle.Flat;
            btnUpdateCategorie.FlatAppearance.BorderColor = Color.Black;
            btnUpdateCategorie.FlatAppearance.BorderSize = 1;

            btnDeleteCategorie.FlatStyle = FlatStyle.Flat;
            btnDeleteCategorie.FlatAppearance.BorderColor = Color.Black;
            btnDeleteCategorie.FlatAppearance.BorderSize = 1;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
