using ERP.Dominio;
using ERP.Dominio.Gestores;
using ERP.Presentacion.SystemTab;
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
    //----------PARA VALIDATE DNI TODO JUNTO -->  
    //if(Cadena.Contains("'")){
    //    return false;
    //}
    //Regex.IsMatch(cadena, "^[0-9]{8}[A-Z]");

    public partial class FormPrincipal : Form
    {
        //private GestorUsuario gestorUser;
        //private GestorCliente gestorCliente;
        private User usuario;
        public static String nombreFilaSeleccionada;

        public FormPrincipal()
        {
            usuario = new User();
            //gestorUser = new GestorUsuario();
            //gestorCliente = new GestorCliente();

            InitializeComponent();

            tbcMenuPrincipal.Width = this.Width;
            tbcMenuPrincipal.Height = this.Height;
            tbcMenuPrincipal.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);

            cargarComponentes();
            cargarTablaUsuarios("DELETED=0");

            //gestorUser.cargarTablaUser(dgvUsers);
            //gestorCliente.cargarTablaCustomer(dgvCustomers);

            FormLogin login = new FormLogin(tbcMenuPrincipal);
            login.ShowDialog();

            /* activar o desactivar pestañas  ((Control)tabPage1).Enabled = true;    y  tbcMenuPrincipal.SelectedIndex = 1;*/

            // coger columnas o filas seleccionadas https://docs.microsoft.com/es-es/dotnet/framework/winforms/controls/selected-cells-rows-and-columns-datagridview
        }

        /**
         * Metodo para usar el "menu pestañas" . 
         */
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
                _textBrush = new SolidBrush(Color.FromArgb(114, 47, 55));
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

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    ((Control)tabPage1).Enabled = true;
        //    ((Control)tabPage3).Enabled = true;
        //    ((Control)tabPage4).Enabled = true;
        //    ((Control)tabPage5).Enabled = true;
        //    ((Control)tabPage6).Enabled = true;
        //    ((Control)tabPage7).Enabled = true;
        //    ((Control)tabPage8).Enabled = true;

        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    tbcMenuPrincipal.SelectTab(1);
        //    ((Control)tabPage1).Enabled = false;
        //    ((Control)tabPage3).Enabled = false;
        //    ((Control)tabPage4).Enabled = false;
        //    ((Control)tabPage5).Enabled = false;
        //    ((Control)tabPage6).Enabled = false;
        //    ((Control)tabPage7).Enabled = false;
        //    ((Control)tabPage8).Enabled = false;
        //}


        private void cargarTablaUsuarios(String condicion)
        {
            dgvUsers.Columns.Clear();

            User usuario = new User();
            usuario.gestorusuario.leerUsuarios(condicion);


            DataTable tusers = usuario.gestorusuario.tabla;
            dgvUsers.Columns.Clear();

            dgvUsers.Columns.Add("NAME", "NAME");
            dgvUsers.Columns.Add("ROLE", "ROLE");

            foreach (DataRow row in tusers.Rows)
            {
                dgvUsers.Rows.Add(row["NAME"], row["ROLE"]);
            }
            //dgvUsers.ColumnHeadersVisible = false;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.FromArgb(114, 47, 55);

            ////Colores de Header (no va nose porque)
            //dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(114, 47, 55);
            //dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //No editable
            dgvUsers.ReadOnly = true;

        }

        public void filtrarTablaUsuario(String name,bool check)
        {
            String condicion="";
            int añadida = 0;

            //if (check)
            //{
            //    condicion += " U.NAME like '%" + name + "%' AND U.DELETED=1";
            //} else
            //{
            //    condicion += " U.NAME like '%" + name + "%' AND U.DELETED=0";
            //}


            if (tbxSearchUser.Text != null && !tbxSearchUser.Text.Equals("Search a name..."))
            {
                condicion += " U.NAME like '%" + tbxSearchUser.Text + "%' AND U.DELETED=0";
                añadida = 1;
            }
            //if (check)
            //{
            //    if (añadida == 1)
            //    {
            //        condicion += " AND ";
            //    }
            //    condicion += "U.DELETED = 1";
            //    añadida = 1;
            //}
            //else //if (cbxUserDeleted.CheckState != CheckState.Checked)
            //{
            //    if (añadida == 1)
            //    {
            //        condicion += " AND ";
            //    }
            //    condicion += "U.DELETED = 0";
            //    añadida = 1;
            //}

            cargarTablaUsuarios(condicion);
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

            dgvCustomers.Width = this.Width - 150;
            dgvCustomers.Height = this.Height - 100;

            dgvCategorie.Width = this.Width - 150;
            dgvCategorie.Height = this.Height - 100;
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (!nombreFilaSeleccionada.Equals(""))
            {
                ConfirmarBorrarUsuario deletedUser = new ConfirmarBorrarUsuario(dgvUsers, nombreFilaSeleccionada);
                deletedUser.ShowDialog();
                cargarTablaUsuarios("");
            } else
            {
                MessageBox.Show("No se ha sellecionado ninguna fila.");
            }
            
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            NuevoUsuario newUser = new NuevoUsuario();
            newUser.ShowDialog();
            cargarTablaUsuarios("");

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
            EditarRol editRol = new EditarRol();
            editRol.ShowDialog();
        }


        /*public void cargarTablaCustomer()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();
            //SELECT U.NAME,R.NAME FROM USERS U INNER JOIN USERS_ROLES A ON U.IDUSER=A.IDUSER INNER JOIN ROLES R ON A.IDROLE=R.IDROLE;
            data = Search.getData("SELECT * FROM CUSTOMERS ORDER BY IDCUSTOMER", "CUSTOMERS");

            DataTable tCustomers = data.Tables["CUSTOMERS"];

            //dgvCustomers.DataSource = tcustomers;

            dgvCustomers.Columns.Add("IDCUSTOMER", "ID");
            dgvCustomers.Columns.Add("NAME", "NAME");
            dgvCustomers.Columns.Add("SURNAME", "SURNAME");
            dgvCustomers.Columns.Add("ADDRESS", "ADDRESS");
            dgvCustomers.Columns.Add("PHONE", "PHONE");
            dgvCustomers.Columns.Add("EMAIL", "EMAIL");
            dgvCustomers.Columns.Add("DELETED", "DELETED");
            dgvCustomers.Columns.Add("REFZIPCODESCITIES", "REFZIPCODESCITIES");

            foreach (DataRow row in tCustomers.Rows)
            {
                dgvCustomers.Rows.Add(row["IDCUSTOMER"], row["NAME"], row["SURNAME"], row["ADDRESS"], row["PHONE"], row["EMAIL"], row["DELETED"], row["REFZIPCODESCITIES"]);
            }
            //dgvUsers.ColumnHeadersVisible = false;
            dgvCustomers.RowHeadersVisible = false;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }*/

        public void cargarComponentes()
        {
            //General
            tbxSearchUser.ForeColor = Color.Gray;
            tbxSearchUser.Text = "Search a Name...";

            tbxSearchUser.ForeColor = Color.Gray;
            tbxSearchCustomer.Text = "Search a Name...";

            //Usuarios
            btnNewUser.BackColor = Color.FromArgb(114, 47, 55);
            btnNewUser.ForeColor = Color.White;
            btnNewUser.FlatStyle = FlatStyle.Flat;
            btnNewUser.FlatAppearance.BorderColor = Color.Black;
            btnNewUser.FlatAppearance.BorderSize = 1;

            btnEditUser.BackColor = Color.FromArgb(114, 47, 55);
            btnEditUser.ForeColor = Color.White;
            btnEditUser.FlatStyle = FlatStyle.Flat;
            btnEditUser.FlatAppearance.BorderColor = Color.Black;
            btnEditUser.FlatAppearance.BorderSize = 1;

            btnRoles.BackColor = Color.FromArgb(114, 47, 55);
            btnRoles.ForeColor = Color.White;
            btnRoles.FlatStyle = FlatStyle.Flat;
            btnRoles.FlatAppearance.BorderColor = Color.Black;
            btnRoles.FlatAppearance.BorderSize = 1;

            btnDeleteUser.BackColor = Color.FromArgb(114, 47, 55);
            btnDeleteUser.ForeColor = Color.White;
            btnDeleteUser.FlatStyle = FlatStyle.Flat;
            btnDeleteUser.FlatAppearance.BorderColor = Color.Black;
            btnDeleteUser.FlatAppearance.BorderSize = 1;

            btnLogs.BackColor = Color.FromArgb(114, 47, 55);
            btnLogs.ForeColor = Color.White;
            btnLogs.FlatStyle = FlatStyle.Flat;
            btnLogs.FlatAppearance.BorderColor = Color.Black;
            btnLogs.FlatAppearance.BorderSize = 1;

            //Productos
            //txtBuscarProd.Text = "Buscar";
            //txtBuscarProd.ForeColor = Color.Gray;

            //btnNewProd.FlatStyle = FlatStyle.Flat;
            //btnNewProd.FlatAppearance.BorderColor = Color.Black;
            //btnNewProd.FlatAppearance.BorderSize = 1;

            //btnEditProd.FlatStyle = FlatStyle.Flat;
            //btnEditProd.FlatAppearance.BorderColor = Color.Black;
            //btnEditProd.FlatAppearance.BorderSize = 1;

            //btnDeleteProd.FlatStyle = FlatStyle.Flat;
            //btnDeleteProd.FlatAppearance.BorderColor = Color.Black;
            //btnDeleteProd.FlatAppearance.BorderSize = 1;
            
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

            //System
            btnExit.BackColor = Color.FromArgb(114, 47, 55);
            btnExit.ForeColor = Color.White;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderColor = Color.Black;
            btnExit.FlatAppearance.BorderSize = 1;

            btnLogOut.BackColor = Color.FromArgb(114, 47, 55);
            btnLogOut.ForeColor = Color.White;
            btnLogOut.FlatStyle = FlatStyle.Flat;
            btnLogOut.FlatAppearance.BorderColor = Color.Black;
            btnLogOut.FlatAppearance.BorderSize = 1;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ConfirmarExit cExit = new ConfirmarExit();
            cExit.ShowDialog();
        }

        private void tbxSearchUser_Enter(object sender, EventArgs e)
        {
            if(tbxSearchUser.Text.Equals("Search a Name..."))
            {
                tbxSearchUser.Text = "";
                tbxSearchUser.ForeColor = Color.Black;
            }
        }

        private void tbxSearchUser_Leave(object sender, EventArgs e)
        {
            if (tbxSearchUser.Text.Equals(""))
            {
                tbxSearchUser.ForeColor = Color.Gray;
                tbxSearchUser.Text = "Search a Name...";
            }
        }

        private void btnNewUser_MouseEnter(object sender, EventArgs e)
        {
            btnNewUser.BackColor = Color.White;
            btnNewUser.ForeColor = Color.Black;
        }

        private void btnNewUser_MouseLeave(object sender, EventArgs e)
        {
            btnNewUser.BackColor = Color.FromArgb(114, 47, 55);
            btnNewUser.ForeColor = Color.White;
        }

        private void btnRoles_MouseEnter(object sender, EventArgs e)
        {
            btnRoles.BackColor = Color.White;
            btnRoles.ForeColor = Color.Black;
        }

        private void btnRoles_MouseLeave(object sender, EventArgs e)
        {
            btnRoles.BackColor = Color.FromArgb(114, 47, 55);
            btnRoles.ForeColor = Color.White;
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.White;
            btnExit.ForeColor = Color.Black;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.FromArgb(114, 47, 55);
            btnExit.ForeColor = Color.White;
        }

        private void btnDeleteUser_MouseEnter(object sender, EventArgs e)
        {
            btnDeleteUser.BackColor = Color.White;
            btnDeleteUser.ForeColor = Color.Black;
        }

        private void btnDeleteUser_MouseLeave(object sender, EventArgs e)
        {
            btnDeleteUser.BackColor = Color.FromArgb(114, 47, 55);
            btnDeleteUser.ForeColor = Color.White;
        }

        private void btnLogs_MouseEnter(object sender, EventArgs e)
        {
            btnLogs.BackColor = Color.White;
            btnLogs.ForeColor = Color.Black;
        }

        private void btnLogs_MouseLeave(object sender, EventArgs e)
        {
            btnLogs.BackColor = Color.FromArgb(114, 47, 55);
            btnLogs.ForeColor = Color.White;
        }

        private void tbcMenuPrincipal_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!e.TabPage.Enabled)
            {
                e.Cancel = true;
            }
        }

        private void btnLogOut_MouseEnter(object sender, EventArgs e)
        {
            btnLogOut.BackColor = Color.White;
            btnLogOut.ForeColor = Color.Black;
        }

        private void btnLogOut_MouseLeave(object sender, EventArgs e)
        {
            btnLogOut.BackColor = Color.FromArgb(114, 47, 55);
            btnLogOut.ForeColor = Color.White;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            ConfirmarLogOut confirmLogOut = new ConfirmarLogOut(tbcMenuPrincipal);
            confirmLogOut.ShowDialog();

        }

//<<<<<<< HEAD
        private void tbxSearchCustomer_Enter(object sender, EventArgs e)
        {
            if (tbxSearchCustomer.Text.Equals("Search a Name..."))
            {
                tbxSearchCustomer.Text = "";
                tbxSearchCustomer.ForeColor = Color.Black;
            }
        }

        private void tbxSearchCustomer_Leave(object sender, EventArgs e)
        {
            if (tbxSearchCustomer.Text.Equals(""))
            {
                tbxSearchCustomer.ForeColor = Color.Gray;
                tbxSearchCustomer.Text = "Search a Name...";
            }
        }
//=======
        private void txtBuscarProd_TextChanged(object sender, EventArgs e)
        {

//>>>>>>> a3a8c49b150b7208ae5c3ba9ebe7b0b90e5daec2
        }

        private void tbxSearchUser_KeyUp(object sender, KeyEventArgs e)
        {
            filtroTotal();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nombreFilaSeleccionada = dgvUsers.Rows[e.RowIndex].Cells[0].Value.ToString(); //No secontrola System.ArgumentOutOfRangeException'
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            filtroTotal();
            //String condicion = "";
            //if (cbxUserDeleted.CheckState == CheckState.Checked)
            //{
            //    condicion += "U.DELETED = 1";

            //}
            //else if (cbxUserDeleted.CheckState != CheckState.Checked)
            //{
            //    condicion += "U.DELETED = 0";
            //}
            //cargarTablaUsuarios(condicion);

        }
        public void filtroTotal()
        {
            filtrarTablaUsuario(tbxSearchUser.Text.Equals("Search a name...") ? "" : tbxSearchUser.Text, cbxUserDeleted.Checked);
        }

        private void btnEditUser_MouseEnter(object sender, EventArgs e)
        {
            btnEditUser.BackColor = Color.White;
            btnEditUser.ForeColor = Color.Black;
        }

        private void btnEditUser_MouseLeave(object sender, EventArgs e)
        {
            btnEditUser.BackColor = Color.FromArgb(114, 47, 55);
            btnEditUser.ForeColor = Color.White;
        }
    }
}
