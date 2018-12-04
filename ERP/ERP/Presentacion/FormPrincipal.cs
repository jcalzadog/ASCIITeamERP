using ERP.Dominio;
using ERP.Dominio.Gestores;
using ERP.Presentacion.Clientes;
using ERP.Presentacion.Categories;
using ERP.Presentacion.ErroresCambios;
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
using ERP.Presentacion.Products;
using ERP.Presentacion.Plataformas;

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
        private String nombreUsuarioLogueado;
        private Decimal idUsuarioLogueado;

        private User usuario;
        private Customer cliente;
        private Producto producto;
        private Platforms plataforma;
        private GestorOrder orders;
        public static String nombreFilaSeleccionadaUsers="";
        public static String rolFilaSellecionadaUsers="";

        public static String dniFilaSeleccionadaClientes = "";
        public static String nameFilaSellecionadaClientes = "";
        public static String surnameFilaSeleccionadaClientes = "";
        public static String addressFilaSellecionadaClientes = "";
        public static String phoneFilaSeleccionadaClientes = "";
        public static String emailFilaSellecionadaClientes = "";
        public static String cityFilaSeleccionadaClientes = "";


        public static String nombreFilaSeleccionadaProducts = "";
        public static String catViejaFilaSellecionadaProducts = "";
        public static String platViejaFilaSellecionadaProducts = "";
        public static String pegiFilaSellecionadaProducts = "";
        public static String priceFilaSellecionadaProducts = "";




        private Categorias categoria;
        public static String nombreviejo;
        public static String nombreviejopf;
        public FormPrincipal()
        {
            usuario = new User();
            cliente = new Customer();
            producto = new Producto();
            plataforma = new Platforms();
            orders = new GestorOrder();
            InitializeComponent();

            tbcMenuPrincipal.Width = this.Width;
            tbcMenuPrincipal.Height = this.Height;
            tbcMenuPrincipal.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);
            cargarCategorias();
            cargarComponentes();
            cargarTablaUsuarios("DELETED=0");
            cargarTablaProductos("PR.DELETED=0");
            cargarTablaClientes("C.DELETED=0");
            cargarPlataformas();
            cargarTablaOrders();
            FormLogin login = new FormLogin(tbcMenuPrincipal);
            login.ShowDialog();
            this.nombreUsuarioLogueado = login.nombreUsuario;
            this.idUsuarioLogueado = usuario.gestorusuario.extraerIdUserLogueado(nombreUsuarioLogueado);
            /* activar o desactivar pestañas  ((Control)tabPage1).Enabled = true;    y  tbcMenuPrincipal.SelectedIndex = 1;*/

            // coger columnas o filas seleccionadas https://docs.microsoft.com/es-es/dotnet/framework/winforms/controls/selected-cells-rows-and-columns-datagridview


            controlErroresUsuarios();
            controlErroresProduct();
        }



        public void cargarCategorias() {
            dgvCategorie.Columns.Clear();
            categoria = new Categorias();
            categoria.gestor.readCategorias();
            DataTable tcategorias = categoria.gestor.tabla;

            dgvCategorie.Columns.Clear();

            dgvCategorie.Columns.Add("NAME", "NAME");
            dgvCategorie.Columns.Add("CUENTA", "NUMBER OF PRODUCTS");


            foreach (DataRow row in tcategorias.Rows)
            {
                dgvCategorie.Rows.Add(row["NAME"],row["CUENTA"]);
            }


            dgvCategorie.RowHeadersVisible = false;
            dgvCategorie.AllowUserToAddRows = false;
            dgvCategorie.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategorie.BackgroundColor = Color.Black;

        }
        public void cargarPlataformas()
        {
            dgvPlatforms.Columns.Clear();
            
            plataforma.gestorplataforma.readPlatforms();
            DataTable tPlatformas = plataforma.gestorplataforma.tabla;

            dgvPlatforms.Columns.Clear();

            dgvPlatforms.Columns.Add("NAME", "NAME");
            dgvPlatforms.Columns.Add("CUENTA", "NUMBER OF PRODUCTS");


            foreach (DataRow row in tPlatformas.Rows)
            {
                dgvPlatforms.Rows.Add(row["NAME"], row["CUENTA"]);
            }


            dgvPlatforms.RowHeadersVisible = false;
            dgvPlatforms.AllowUserToAddRows = false;
            dgvPlatforms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPlatforms.BackgroundColor = Color.Black;

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
                _textBrush = new SolidBrush(Color.Black);
                // g.FillRectangle(Brushes.Red, e.Bounds);
                g.FillRectangle(Brushes.DarkOrange, e.Bounds);
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
            dgvUsers.BackgroundColor = Color.Black;

            ////Colores de Header (no va nose porque)
            //dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(114, 47, 55);
            //dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //No editable
            dgvUsers.ReadOnly = true;
            //dgvUsers.Rows[dgvUsers.Rows[0].Index].Selected = true;
            //dgvUsers.CurrentCell = dgvUsers.Rows[dgvUsers.Rows[0].Index].Cells[0];

        }

        private void cargarTablaProductos(String condicion)
        {
            dgvProducts.Columns.Clear();

            producto.gestorProducto.leerProductos(condicion);


            DataTable tproduct = producto.gestorProducto.tabla;
            dgvProducts.Columns.Clear();

            dgvProducts.Columns.Add("NAME", "NAME");
            dgvProducts.Columns.Add("IDCATEGORY", "CATEGORY");
            dgvProducts.Columns.Add("IDPLATFORM", "PLATFORM");
            dgvProducts.Columns.Add("MINIMUMAGE", "PEGI");
            dgvProducts.Columns.Add("PRICE", "PRICE");

            foreach (DataRow row in tproduct.Rows)
            {
                dgvProducts.Rows.Add(row["NAME"], row["CATEGORY"], row["PLATFORM"], row["PEGI"], row["PRICE"]);
            }

            dgvProducts.RowHeadersVisible = false;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BackgroundColor = Color.Black;

            dgvProducts.ReadOnly = true;

        }

        private void cargarTablaOrders()
        {
            dgvOrders.Columns.Clear();

            orders.leerOrders();


            DataTable tOrders = orders.tOrders;

            dgvOrders.Columns.Add("ID", "ID");
            dgvOrders.Columns.Add("SURNAME", "SURNAME");
            dgvOrders.Columns.Add("USERNAME", "USERNAME");
            dgvOrders.Columns.Add("PAYMETHOD", "PAYMETHOD");
            dgvOrders.Columns.Add("DAT", "DAT");
            dgvOrders.Columns.Add("TOTAL", "TOTAL");
            dgvOrders.Columns.Add("PREPAID", "PREPAID");

            foreach (DataRow row in tOrders.Rows)
            {
                dgvOrders.Rows.Add(row["ID"], row["SURNAME"], row["USERNAME"], row["PAYMETHOD"], row["DAT"], row["TOTAL"], row["PREPAID"]);
            }

            dgvOrders.RowHeadersVisible = false;
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.BackgroundColor = Color.Black;

            dgvOrders.ReadOnly = true;

        }

        private void cargarTablaClientes(String condicion)
        {
            dgvCustomers.Columns.Clear();

            cliente.gestorCliente.leerClientes(condicion);


            DataTable tcustomers = cliente.gestorCliente.tabla;
            dgvCustomers.Columns.Clear();

            dgvCustomers.Columns.Add("DNI", "DNI");
            dgvCustomers.Columns.Add("NAME", "NAME");
            dgvCustomers.Columns.Add("SURNAME", "SURNAME");
            dgvCustomers.Columns.Add("ADDRESS", "ADDRESS");
            dgvCustomers.Columns.Add("PHONE", "PHONE");
            dgvCustomers.Columns.Add("EMAIL", "EMAIL");
            dgvCustomers.Columns.Add("CITY", "CITY");

            foreach (DataRow row in tcustomers.Rows)
            {
                dgvCustomers.Rows.Add(row["DNI"], row["NAME"], row["SURNAME"], row["ADDRESS"], row["PHONE"], row["EMAIL"], row["CITY"]);
            }
            //dgvUsers.ColumnHeadersVisible = false;
            dgvCustomers.RowHeadersVisible = false;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.BackgroundColor = Color.Black;

            ////Colores de Header (no va nose porque)
            //dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(114, 47, 55);
            //dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //No editable
            dgvCustomers.ReadOnly = true;
            //dgvUsers.Rows[dgvUsers.Rows[0].Index].Selected = true;
            //dgvUsers.CurrentCell = dgvUsers.Rows[dgvUsers.Rows[0].Index].Cells[0];

        }

        private void controlErroresUsuarios()
        {
            /*Hay un problema y es que cuando se inicia la tabla sale selecionada ya una fila y si no selecionas otra
             * y le das a alguna funcion, al no funcionar elevento que salta cuando pulsas una fila da error porque
             * estas dos variables estan vacias. Para ello le asigno en este metodo desde el principio el contenido de la
             * fila seleccionada por defecto.*/

            if (nombreFilaSeleccionadaUsers.Equals(""))
            {
                dgvUsers.Rows[dgvUsers.Rows[0].Index].Selected = true;
                dgvUsers.CurrentCell = dgvUsers.Rows[dgvUsers.Rows[0].Index].Cells[0];
                nombreFilaSeleccionadaUsers = dgvUsers.Rows[dgvUsers.SelectedRows[0].Index].Cells[0].Value.ToString();
                rolFilaSellecionadaUsers = dgvUsers.Rows[dgvUsers.SelectedRows[0].Index].Cells[1].Value.ToString();
            }
        }

        private void controlErroresProduct()
        {
            /*Hay un problema y es que cuando se inicia la tabla sale selecionada ya una fila y si no selecionas otra
             * y le das a alguna funcion, al no funcionar elevento que salta cuando pulsas una fila da error porque
             * estas dos variables estan vacias. Para ello le asigno en este metodo desde el principio el contenido de la
             * fila seleccionada por defecto.*/

            if (nombreFilaSeleccionadaUsers.Equals(""))
            {
                dgvProducts.Rows[dgvProducts.Rows[0].Index].Selected = true;
                dgvProducts.CurrentCell = dgvProducts.Rows[dgvProducts.Rows[0].Index].Cells[0];
                nombreFilaSeleccionadaUsers = dgvProducts.Rows[dgvProducts.SelectedRows[0].Index].Cells[0].Value.ToString();
                rolFilaSellecionadaUsers = dgvProducts.Rows[dgvProducts.SelectedRows[0].Index].Cells[1].Value.ToString();
            }
        }

        public void filtrarTablaUsuario(String name,bool check)
        {
            String condicion="";

            if (check)
            {
                condicion += " U.NAME like '%" + name + "%' AND U.DELETED=1";
            }
            else
            {
                condicion += " U.NAME like '%" + name + "%' AND U.DELETED=0";
            }


            //if (tbxSearchUser.Text != null && !tbxSearchUser.Text.Equals("Search a name..."))
            //{
            //    condicion += " U.NAME like '%" + tbxSearchUser.Text + "%' AND U.DELETED=0";
            //    añadida = 1;
            //}
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

        public void filtrarTablaProductos(String name, bool check)
        {
            String condicion = "";

            if (check)
            {
                condicion += " PR.NAME like '%" + name + "%' AND PR.DELETED=1";
            }
            else
            {
                condicion += " PR.NAME like '%" + name + "%' AND PR.DELETED=0";
            }

            cargarTablaProductos(condicion);
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

            dgvOrders.Width = this.Width - 150;
            dgvOrders.Height = this.Height - 100;

            dgvPlatforms.Width = this.Width - 150;
            dgvPlatforms.Height = this.Height - 100;

            //Diseño
            //panel1.Width = tbcMenuPrincipal.Width;
            //panel1.Location = new Point(0, tbcMenuPrincipal.Location.Y+780);

            panel3.Width = tbcMenuPrincipal.Width;
            panel3.Location = new Point(0, tbcMenuPrincipal.Location.Y + 780);

            //panel4.Width = tbcMenuPrincipal.Width;
            //panel4.Location = new Point(0, tbcMenuPrincipal.Location.Y + 780);

            panel2.Width = tbcMenuPrincipal.Width;
            panel2.Height = tbcMenuPrincipal.Height;

        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (!nombreFilaSeleccionadaUsers.Equals(""))
            {
                ConfirmarBorrarUsuario deletedUser = new ConfirmarBorrarUsuario(dgvUsers, nombreFilaSeleccionadaUsers);
                deletedUser.ShowDialog();
                filtroTotalUsuarios();
            } else
            {
                String mensaje = "No se ha selecionado ninguna fila.";
                VentanaPersonalizada cambio = new VentanaPersonalizada(mensaje);
                cambio.ShowDialog();
                //MessageBox.Show("No se ha sellecionado ninguna fila.");
            }

        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            NuevoUsuario newUser = new NuevoUsuario();
            newUser.ShowDialog();
            filtroTotalUsuarios();//Usa cargar tabla usuarios para actualizar tabla

        }

        private void btnNewCategorie_Click(object sender, EventArgs e)
        {
            AddCategoria ncategorie = new AddCategoria();
            ncategorie.ShowDialog();
            cargarCategorias();

        }

        private void btnUpdateCategorie_Click(object sender, EventArgs e)
        {

            UpdCategorie ucategorie = new UpdCategorie();
            String name = dgvCategorie.Rows[dgvCategorie.CurrentRow.Index].Cells[0].Value.ToString();
            ucategorie.textBox1.Text = name;
            nombreviejo = name;
            ucategorie.ShowDialog();

            cargarCategorias();
        }

        private void btnDeleteCategorie_Click(object sender, EventArgs e)
        {
            DeleteCategorie dc = new DeleteCategorie();
            dc.namedelete = dgvCategorie.Rows[dgvCategorie.CurrentRow.Index].Cells[0].Value.ToString();

            dc.ShowDialog();


            cargarCategorias();
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

            tbxSearchCustomer.ForeColor = Color.Gray;
            tbxSearchCustomer.Text = "Search a Name...";

            txtSearchProd.ForeColor = Color.Gray;
            txtSearchProd.Text = "Search a Name...";

            //Usuarios
            btnNewUser.BackColor = Color.Black;
            btnNewUser.ForeColor = Color.White;
            btnNewUser.FlatStyle = FlatStyle.Flat;
            btnNewUser.FlatAppearance.BorderColor = Color.Black;
            btnNewUser.FlatAppearance.BorderSize = 1;

            btnEditUser.BackColor = Color.Black;
            btnEditUser.ForeColor = Color.White;
            btnEditUser.FlatStyle = FlatStyle.Flat;
            btnEditUser.FlatAppearance.BorderColor = Color.Black;
            btnEditUser.FlatAppearance.BorderSize = 1;

            btnRoles.BackColor = Color.Black;
            btnRoles.ForeColor = Color.White;
            btnRoles.FlatStyle = FlatStyle.Flat;
            btnRoles.FlatAppearance.BorderColor = Color.Black;
            btnRoles.FlatAppearance.BorderSize = 1;

            btnDeleteUser.BackColor = Color.Black;
            btnDeleteUser.ForeColor = Color.White;
            btnDeleteUser.FlatStyle = FlatStyle.Flat;
            btnDeleteUser.FlatAppearance.BorderColor = Color.Black;
            btnDeleteUser.FlatAppearance.BorderSize = 1;

            btnLogs.BackColor = Color.Black;
            btnLogs.ForeColor = Color.White;
            btnLogs.FlatStyle = FlatStyle.Flat;
            btnLogs.FlatAppearance.BorderColor = Color.Black;
            btnLogs.FlatAppearance.BorderSize = 1;

            //Clientes
            btnNewCustomer.BackColor = Color.Black;
            btnNewCustomer.ForeColor = Color.White;
            btnNewCustomer.FlatStyle = FlatStyle.Flat;
            btnNewCustomer.FlatAppearance.BorderColor = Color.Black;
            btnNewCustomer.FlatAppearance.BorderSize = 1;

            btnEditCustomer.BackColor = Color.Black;
            btnEditCustomer.ForeColor = Color.White;
            btnEditCustomer.FlatStyle = FlatStyle.Flat;
            btnEditCustomer.FlatAppearance.BorderColor = Color.Black;
            btnEditCustomer.FlatAppearance.BorderSize = 1;

            btnDeleteCustomer.BackColor = Color.Black;
            btnDeleteCustomer.ForeColor = Color.White;
            btnDeleteCustomer.FlatStyle = FlatStyle.Flat;
            btnDeleteCustomer.FlatAppearance.BorderColor = Color.Black;
            btnDeleteCustomer.FlatAppearance.BorderSize = 1;

            //Orders
            aparienciaBotones(btnNewOrder);
            aparienciaBotones(btnEditOrder);
            aparienciaBotones(btnViewDetails);
            aparienciaBotones(btnPrintOrder);
            aparienciaBotones(btnDeleteOrder);


            //Productos
            btnNewProd.BackColor = Color.Black;
            btnNewProd.ForeColor = Color.White;
            btnNewProd.FlatStyle = FlatStyle.Flat;
            btnNewProd.FlatAppearance.BorderColor = Color.Black;
            btnNewProd.FlatAppearance.BorderSize = 1;

            btnUpdateProd.BackColor = Color.Black;
            btnUpdateProd.ForeColor = Color.White;
            btnUpdateProd.FlatStyle = FlatStyle.Flat;
            btnUpdateProd.FlatAppearance.BorderColor = Color.Black;
            btnUpdateProd.FlatAppearance.BorderSize = 1;

            btnDeleteProd.BackColor = Color.Black;
            btnDeleteProd.ForeColor = Color.White;
            btnDeleteProd.FlatStyle = FlatStyle.Flat;
            btnDeleteProd.FlatAppearance.BorderColor = Color.Black;
            btnDeleteProd.FlatAppearance.BorderSize = 1;

            categoria.gestor.refrescarCategorias(cmbFilCategory);
            plataforma.gestorplataforma.refrescarPlatform(cmbFilPlatform);

            //Platforms
            aparienciaBotones(btnUpdatePlatform);
            aparienciaBotones(btnDeletePlatform);
            aparienciaBotones(btnNewPlatform);
            


            //Categorias

            btnNewCategorie.BackColor = Color.Black;
            btnNewCategorie.ForeColor = Color.White;
            btnNewCategorie.FlatStyle = FlatStyle.Flat;
            btnNewCategorie.FlatAppearance.BorderColor = Color.Black;
            btnNewCategorie.FlatAppearance.BorderSize = 1;

            btnUpdateCategorie.BackColor = Color.Black;
            btnUpdateCategorie.ForeColor = Color.White;
            btnUpdateCategorie.FlatStyle = FlatStyle.Flat;
            btnUpdateCategorie.FlatAppearance.BorderColor = Color.Black;
            btnUpdateCategorie.FlatAppearance.BorderSize = 1;


            btnDeleteCategorie.BackColor = Color.Black;
            btnDeleteCategorie.ForeColor = Color.White;
            btnDeleteCategorie.FlatStyle = FlatStyle.Flat;
            btnDeleteCategorie.FlatAppearance.BorderColor = Color.Black;
            btnDeleteCategorie.FlatAppearance.BorderSize = 1;

            //System
            btnExit.BackColor = Color.Black;
            btnExit.ForeColor = Color.White;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderColor = Color.Black;
            btnExit.FlatAppearance.BorderSize = 1;

            btnLogOut.BackColor = Color.Black;
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

        }

        private void tbxSearchUser_Leave(object sender, EventArgs e)
        {

        }

        private void btnNewUser_MouseEnter(object sender, EventArgs e)
        {
            btnNewUser.BackColor = Color.White;
            btnNewUser.ForeColor = Color.Black;
        }

        private void btnNewUser_MouseLeave(object sender, EventArgs e)
        {
            btnNewUser.BackColor = Color.Black;
            btnNewUser.ForeColor = Color.White;
        }

        private void btnRoles_MouseEnter(object sender, EventArgs e)
        {
            btnRoles.BackColor = Color.White;
            btnRoles.ForeColor = Color.Black;
        }

        private void btnRoles_MouseLeave(object sender, EventArgs e)
        {
            btnRoles.BackColor = Color.Black;
            btnRoles.ForeColor = Color.White;
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.White;
            btnExit.ForeColor = Color.Black;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.Black;
            btnExit.ForeColor = Color.White;
        }

        private void btnDeleteUser_MouseEnter(object sender, EventArgs e)
        {
            btnDeleteUser.BackColor = Color.White;
            btnDeleteUser.ForeColor = Color.Black;
        }

        private void btnDeleteUser_MouseLeave(object sender, EventArgs e)
        {
            btnDeleteUser.BackColor = Color.Black;
            btnDeleteUser.ForeColor = Color.White;
        }

        private void btnLogs_MouseEnter(object sender, EventArgs e)
        {
            btnLogs.BackColor = Color.White;
            btnLogs.ForeColor = Color.Black;
        }

        private void btnLogs_MouseLeave(object sender, EventArgs e)
        {
            btnLogs.BackColor = Color.Black;
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
            btnLogOut.BackColor = Color.Black;
            btnLogOut.ForeColor = Color.White;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            ConfirmarLogOut confirmLogOut = new ConfirmarLogOut(tbcMenuPrincipal);
            confirmLogOut.ShowDialog();

        }


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

        private void tbxSearchUser_KeyUp(object sender, KeyEventArgs e)
        {
            filtroTotalUsuarios();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
            {
                return;
            }
            if (dgvUsers.Rows.Count > 0 && dgvUsers.Rows[e.RowIndex].Cells[e.ColumnIndex] != null)
            {
                if (!String.IsNullOrEmpty(dgvUsers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                {
                    // do sonmthind
                    nombreFilaSeleccionadaUsers = dgvUsers.Rows[e.RowIndex].Cells[0].Value.ToString();
                    rolFilaSellecionadaUsers = dgvUsers.Rows[e.RowIndex].Cells[1].Value.ToString();
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (cbxUserDeleted.CheckState == CheckState.Checked)
            {
                btnDeleteUser.Enabled = false;


            } else
            {
                btnDeleteUser.Enabled = true;
            }
            filtroTotalUsuarios();
            //String condicion = "";

            //else if (cbxUserDeleted.CheckState != CheckState.Checked)
            //{
            //    condicion += "U.DELETED = 0";
            //}
            //cargarTablaUsuarios(condicion);

        }
        public void filtroTotalUsuarios()
        {
            bool deleted = false;
            if(cbxUserDeleted.CheckState == CheckState.Checked)
            {
                deleted = true;
            }
            filtrarTablaUsuario(tbxSearchUser.Text.Equals("Search a Name...") ? "" : tbxSearchUser.Text, deleted);
            //(tbxSearchUser.Text.Equals("Search a Name...") ? "" : tbxSearchUser.Text, deleted, combox.SelectedItem.Equals("Ninguno") ? "" :combox.SelectedItem.toString , );
        }

        public void filtroTotalProd()
        {
            bool deleted = false;
            if (ckbDeleted.CheckState == CheckState.Checked)
            {
                deleted = true;
            }
            filtrarTablaProductos(txtSearchProd.Text.Equals("Search a Name...") ? "" : txtSearchProd.Text, deleted);
        }

        private void btnEditUser_MouseEnter(object sender, EventArgs e)
        {
            btnEditUser.BackColor = Color.White;
            btnEditUser.ForeColor = Color.Black;
        }

        private void btnEditUser_MouseLeave(object sender, EventArgs e)
        {
            btnEditUser.BackColor = Color.Black;
            btnEditUser.ForeColor = Color.White;
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (!rolFilaSellecionadaUsers.Equals(""))
            {
                EditarUsuario editUser = new EditarUsuario(nombreFilaSeleccionadaUsers, rolFilaSellecionadaUsers);
                editUser.ShowDialog();
                filtroTotalUsuarios();//Usa cargar tabla usuariospara actualizar tabla
            }
            else
            {
                String mensaje = "No se ha selecionado ninguna fila.";
                VentanaPersonalizada cambio = new VentanaPersonalizada(mensaje);
                cambio.ShowDialog();
                //MessageBox.Show("No se ha sellecionado ninguna fila.");
            }
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {

        }

        private void btnNewProd_Click(object sender, EventArgs e)
        {
            AñadirProducto addProduct = new AñadirProducto();
            addProduct.ShowDialog();
            filtroTotalProd();//Usa cargar tabla usuarios para actualizar tabla
        }

        private void cmbFilCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDeleteProd_Click(object sender, EventArgs e)
        {
            if (!nombreFilaSeleccionadaProducts.Equals(""))
            {
                ConfirmarBorrarProducto deletedProduct = new ConfirmarBorrarProducto(dgvProducts, nombreFilaSeleccionadaProducts);
                deletedProduct.ShowDialog();
                filtroTotalProd();
            }
            else
            {
                String mensaje = "No se ha selecionado ninguna fila.";
                VentanaPersonalizada cambio = new VentanaPersonalizada(mensaje);
                cambio.ShowDialog();
            }
        }

        private void btnUpdateProd_Click(object sender, EventArgs e)
        {
            EditarProducto updateProduct = new EditarProducto(nombreFilaSeleccionadaProducts, catViejaFilaSellecionadaProducts, platViejaFilaSellecionadaProducts, pegiFilaSellecionadaProducts, priceFilaSellecionadaProducts);
            updateProduct.ShowDialog();
            filtroTotalProd();
    }

        private void cmbFilPlatform_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage5_Resize(object sender, EventArgs e)
        {
            dgvProducts.Width = this.Width - 150;
            dgvProducts.Height = this.Height - 100;
        }



        private void btn_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Black;
            ((Button)sender).ForeColor = Color.White;
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.White;
            ((Button)sender).ForeColor = Color.Black;
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Equals("Search a Name..."))
            {
                ((TextBox)sender).Text = "";
                ((TextBox)sender).ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Trim().Equals(""))
            {
                ((TextBox)sender).ForeColor = Color.Gray;
                ((TextBox)sender).Text = "Search a Name...";
            }
        }

        private void btnNewCustomer_MouseEnter(object sender, EventArgs e)
        {
            btnNewCustomer.BackColor = Color.White;
            btnNewCustomer.ForeColor = Color.Black;
        }

        private void btnNewCustomer_MouseLeave(object sender, EventArgs e)
        {
            btnNewCustomer.BackColor = Color.Black;
            btnNewCustomer.ForeColor = Color.White;
        }

        private void btnEditCustomer_MouseEnter(object sender, EventArgs e)
        {
            btnEditCustomer.BackColor = Color.White;
            btnEditCustomer.ForeColor = Color.Black;
        }

        private void btnEditCustomer_MouseLeave(object sender, EventArgs e)
        {
            btnEditCustomer.BackColor = Color.Black;
            btnEditCustomer.ForeColor = Color.White;
        }

        private void btnDeleteCustomer_MouseEnter(object sender, EventArgs e)
        {
            btnDeleteCustomer.BackColor = Color.White;
            btnDeleteCustomer.ForeColor = Color.Black;
        }

        private void btnDeleteCustomer_MouseLeave(object sender, EventArgs e)
        {
            btnDeleteCustomer.BackColor = Color.Black;
            btnDeleteCustomer.ForeColor = Color.White;
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            NuevoCliente newCustomer = new NuevoCliente();
            newCustomer.ShowDialog();
            filtroTotalClientes();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (dgvProducts.Rows.Count > 0 && dgvProducts.Rows[e.RowIndex].Cells[e.ColumnIndex] != null)
            {
                if (!String.IsNullOrEmpty(dgvProducts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                {
                    // do sonmthind
                    nombreFilaSeleccionadaProducts = dgvProducts.Rows[e.RowIndex].Cells[0].Value.ToString();
                    catViejaFilaSellecionadaProducts = dgvProducts.Rows[e.RowIndex].Cells[1].Value.ToString();
                    platViejaFilaSellecionadaProducts = dgvProducts.Rows[e.RowIndex].Cells[2].Value.ToString();
                    pegiFilaSellecionadaProducts = dgvProducts.Rows[e.RowIndex].Cells[3].Value.ToString();
                    priceFilaSellecionadaProducts = dgvProducts.Rows[e.RowIndex].Cells[4].Value.ToString();
                }
            }

        }
        private void cbxDeleted_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxUserDeleted.CheckState == CheckState.Checked)
            {
                btnDeleteUser.Enabled = false;


            }
            else
            {
                btnDeleteUser.Enabled = true;
            }
            filtroTotalClientes();
        }

        public void filtroTotalClientes()
        {
            bool deleted = false;
            if (cbxCustomerDeleted.CheckState == CheckState.Checked)
            {
                deleted = true;
            }
            filtrarTablaCliente(tbxSearchCustomer.Text.Equals("Search a Name...") ? "" : tbxSearchCustomer.Text, deleted);
        }

        public void filtrarTablaCliente(String name, bool check)
        {
            String condicion = "";

            if (check)
            {
                condicion += " C.NAME like '%" + name + "%' AND C.DELETED=1";
            }
            else
            {
                condicion += " C.NAME like '%" + name + "%' AND C.DELETED=0";
            }

            cargarTablaClientes(condicion);
        }

        private void tbxSearchCustomer_KeyUp(object sender, KeyEventArgs e)
        {
            filtroTotalClientes();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchProd_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void ckbDeleted_CheckedChanged(object sender, EventArgs e)
        {

            if (ckbDeleted.CheckState == CheckState.Checked)
            {
                btnDeleteProd.Enabled = false;
                btnDeleteProd.BackColor = Color.DarkOrange;


            }
            else
            {
                btnDeleteProd.Enabled = true;
                btnDeleteProd.BackColor = Color.Black;
            }
            filtroTotalProd();

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (!dniFilaSeleccionadaClientes.Equals(""))
            {
                ConfirmarBorrarCliente deleteCustomer = new ConfirmarBorrarCliente(dgvCustomers,dniFilaSeleccionadaClientes);
                deleteCustomer.ShowDialog();
                filtroTotalClientes();
            }
            else
            {
                String mensaje = "No se ha selecionado ninguna fila.";
                VentanaPersonalizada cambio = new VentanaPersonalizada(mensaje);
                cambio.ShowDialog();
                //MessageBox.Show("No se ha sellecionado ninguna fila.");
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (dgvCustomers.Rows.Count > 0 && dgvCustomers.Rows[e.RowIndex].Cells[e.ColumnIndex] != null)
            {
                if (!String.IsNullOrEmpty(dgvCustomers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                {
                    // do sonmthind
                    dniFilaSeleccionadaClientes = dgvCustomers.Rows[e.RowIndex].Cells[0].Value.ToString();
                    nameFilaSellecionadaClientes = dgvCustomers.Rows[e.RowIndex].Cells[1].Value.ToString();
                    surnameFilaSeleccionadaClientes = dgvCustomers.Rows[e.RowIndex].Cells[2].Value.ToString();
                    addressFilaSellecionadaClientes = dgvCustomers.Rows[e.RowIndex].Cells[3].Value.ToString();
                    phoneFilaSeleccionadaClientes = dgvCustomers.Rows[e.RowIndex].Cells[4].Value.ToString();
                    emailFilaSellecionadaClientes = dgvCustomers.Rows[e.RowIndex].Cells[5].Value.ToString();
                    cityFilaSeleccionadaClientes = dgvCustomers.Rows[e.RowIndex].Cells[6].Value.ToString();
                }
            }
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if (!rolFilaSellecionadaUsers.Equals(""))
            {
                EditarUsuario editUser = new EditarUsuario(nombreFilaSeleccionadaUsers, rolFilaSellecionadaUsers);
                editUser.ShowDialog();
                filtroTotalUsuarios();//Usa cargar tabla usuariospara actualizar tabla
            }
            else
            {
                String mensaje = "No se ha selecionado ninguna fila.";
                VentanaPersonalizada cambio = new VentanaPersonalizada(mensaje);
                cambio.ShowDialog();
                //MessageBox.Show("No se ha sellecionado ninguna fila.");
            }
        }

        public void aparienciaBotones(Button btn)
        {
            btn.BackColor = Color.Black;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.Black;
            btn.FlatAppearance.BorderSize = 1;
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdatePlatform_Click(object sender, EventArgs e)
        {
            UpdatePlataforma up = new UpdatePlataforma();
            String name = dgvPlatforms.Rows[dgvPlatforms.CurrentRow.Index].Cells[0].Value.ToString();
            up.txtUpdate.Text = name;
            nombreviejopf = name;
            up.ShowDialog();

            cargarPlataformas();
        }

        private void btnNewPlatform_Click(object sender, EventArgs e)
        {
            AddPlataforma ap = new AddPlataforma();
            ap.ShowDialog();
            cargarPlataformas();
        }

        private void btnDeletePlatform_Click(object sender, EventArgs e)
        {
            DeletePlataforma dp = new DeletePlataforma();
            dp.nameDelete = dgvCategorie.Rows[dgvCategorie.CurrentRow.Index].Cells[0].Value.ToString();
            dp.ShowDialog();
            cargarPlataformas();
        }

        private void txtSearchProd_KeyUp(object sender, KeyEventArgs e)
        {
            filtroTotalProd();
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            // ventana new order
        }
    }
}
