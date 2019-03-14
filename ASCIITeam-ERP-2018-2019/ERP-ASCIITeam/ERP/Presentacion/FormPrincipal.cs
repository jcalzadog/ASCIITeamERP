using ERP.Dominio;
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
using ERP.Presentacion.Orders;
using ERP.Presentacion.CashBook.Incomes;
using ERP.Dominio.Gestores;
using ERP.Presentacion.CashBook.Expenses;
using ERP.Presentacion.CashBook.Validations;
using ERP.Presentacion.CashBook.PendingPayment;
using ERP.Presentacion.CashBook.DDebts;
using ERP.Presentacion.Invoices;
using System.Diagnostics;

namespace ERP
{
    public partial class FormPrincipal : Form
    {
        public static String nombreUsuarioLogueado { get; set; }
        public Object idUsuarioLogueado;

        private User usuario;
        private Customer cliente;
        private Categorias categoria;
        private Producto producto;
        private Platforms plataforma;
        private Order orders;
        private Income incomes;
        private Expense expense;
        private PendingPayments pendingPayments;
        private Debts debts;
        private Invoicees invoice;

        public static String nombreFilaSeleccionadaUsers = "";
        public static String rolFilaSellecionadaUsers = "";

        public static int eliminadoOrders = 0;

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
        public static String stockFilaSeleccionadaProducts = "";

        public static String nombreviejoCategoria = "";
        public static String nombreviejoPlataformas = "";

        public FormPrincipal()
        {
            usuario = new User();
            cliente = new Customer();
            producto = new Producto();
            plataforma = new Platforms();
            orders = new Order();
            incomes = new Income();
            expense = new Expense();
            pendingPayments = new PendingPayments();
            debts = new Debts();
            invoice = new Invoicees();

            InitializeComponent();

            tbcMenuPrincipal.Width = this.Width;
            tbcMenuPrincipal.Height = this.Height;
            tbcMenuPrincipal.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);
            
            cargarComponentes();

            //Cargar Tablas
            cargarTablaUsuarios("DELETED=0");
            cargarTablaProductos(" PR.DELETED=0");
            cargarTablaClientes("C.DELETED=0");
            cargarCategorias();
            cargarPlataformas();
            cargarTablaOrders("");
            cargarIncomes();
            cargarExpenses();
            cargarPendingPayments();
            cargarDebts();
            cargarInvoices();
            FormLogin login = new FormLogin(tbcMenuPrincipal);
            login.ShowDialog();
            nombreUsuarioLogueado = login.nombreUsuario;

            this.idUsuarioLogueado = usuario.gestorusuario.extraerIdUserLogueado(nombreUsuarioLogueado);
            ERP.Persistencia.Logs.idUser = this.idUsuarioLogueado;

            /* activar o desactivar pestañas  ((Control)tabPage1).Enabled = true;    y  tbcMenuPrincipal.SelectedIndex = 1;*/
            // coger columnas o filas seleccionadas https://docs.microsoft.com/es-es/dotnet/framework/winforms/controls/selected-cells-rows-and-columns-datagridview
            //Por si errores al Cargar Tablas
            controlErroresUsuarios();
            controlErroresProduct();
            controlErroresPlataformas();
            controlErroresCategorias();
            controlErroresClientes();

            
        }

        public void cargarInvoices()
        {
            dgvInvoices.Columns.Clear();
            invoice.gestor.loadTable();

            dgvInvoices.Columns.Add("NUM_INVOICE", "NUM_INVOICE");
            dgvInvoices.Columns.Add("DATETIME", "DATETIME");
            dgvInvoices.Columns.Add("CUSTOMER", "CUSTOMER");
            dgvInvoices.Columns.Add("NET", "NET");
            dgvInvoices.Columns.Add("TOTAL", "TOTAL");

            DataTable tInvoices = invoice.gestor.tabla;
            int i = 0;
            foreach (DataRow row in tInvoices.Rows)
            {
                dgvInvoices.Rows.Add(row["NUM_INVOICE"], row["DATETIME"], row["CUSTOMER"], row["NET"], row["TOTAL"]);

                string numfact = Convert.ToString(dgvInvoices.Rows[i].Cells[0].Value);

                if (invoice.gestor.isPosted(numfact))
                {
                    dgvInvoices.Rows[i].Cells[0].Style.BackColor = Color.Green;
                    dgvInvoices.Rows[i].Cells[0].Style.SelectionBackColor = Color.Transparent;
                }
                i++;

            }
            dgvInvoices.RowHeadersVisible = false;
            dgvInvoices.AllowUserToAddRows = false;
            dgvInvoices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInvoices.BackgroundColor = Color.Black;
            dgvInvoices.Sort(dgvInvoices.Columns[0], ListSortDirection.Descending);
            dgvInvoices.ClearSelection();
        }

        public void cargarIncomes()
        {
            dgvIncomes.DataSource = incomes.gestorIncome.tIncomes;
            dgvIncomes.RowHeadersVisible = false;
            dgvIncomes.AllowUserToAddRows = false;
            dgvIncomes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIncomes.BackgroundColor = Color.Black;
            dgvIncomes.Columns[0].Visible = false;
        }

        public void cargarPendingPayments()
        {
            dgvPendingPayment.DataSource = pendingPayments.gestorPendingPayments.tPPayments;
            dgvPendingPayment.RowHeadersVisible = false;
            dgvPendingPayment.AllowUserToAddRows = false;
            dgvPendingPayment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPendingPayment.BackgroundColor = Color.Black;
            dgvPendingPayment.Columns[0].Visible = false;
        }


        public void cargarDebts()
        {
            dgvDebts.DataSource = debts.gestorDebts.tDebts;
            dgvDebts.RowHeadersVisible = false;
            dgvDebts.AllowUserToAddRows = false;
            dgvDebts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDebts.BackgroundColor = Color.Black;
            dgvDebts.Columns[0].Visible = false;
        }

        public void cargarCategorias()
        {
            dgvCategorie.Columns.Clear();
            categoria = new Categorias();
            categoria.gestor.readCategorias();
            DataTable tcategorias = categoria.gestor.tabla;

            dgvCategorie.Columns.Clear();

            dgvCategorie.Columns.Add("NAME", "NAME");
            dgvCategorie.Columns.Add("CUENTA", "NUMBER OF PRODUCTS");


            foreach (DataRow row in tcategorias.Rows)
            {
                dgvCategorie.Rows.Add(row["NAME"], row["CUENTA"]);
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
            dgvProducts.Columns.Add("STOCK", "STOCK");

            foreach (DataRow row in tproduct.Rows)
            {
                dgvProducts.Rows.Add(row["NAME"], row["CATEGORY"], row["PLATFORM"], row["PEGI"], row["PRICE"], row["STOCK"]);
            }
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BackgroundColor = Color.Black;
            dgvProducts.ReadOnly = true;
        }

        private void cargarTablaOrders(string condicion)
        {
            dgvOrders.Columns.Clear();

            orders.gestorOrder.leerOrders(condicion,eliminadoOrders);

            DataTable tOrders = orders.gestorOrder.tOrders;

            dgvOrders.Columns.Add("DAT", "DAT");
            dgvOrders.Columns.Add("PREPAID", "PREPAID");
            dgvOrders.Columns.Add("REST", "REST");
            dgvOrders.Columns.Add("TOTAL", "TOTAL");
            dgvOrders.Columns.Add("", "CONFIRMED");
            dgvOrders.Columns.Add("", "LABELED");
            dgvOrders.Columns.Add("", "SENT");
            dgvOrders.Columns.Add("", "INVOICED");
            dgvOrders.Columns.Add("SURNAME", "SURNAME");
            dgvOrders.Columns.Add("PAYMETHOD", "PAYMETHOD");
            dgvOrders.Columns.Add("ID", "ID");

            int i = 0;
            foreach (DataRow row in tOrders.Rows)
            {
                dgvOrders.Rows.Add(row["DAT"], row["PREPAID"], row["REST"], row["TOTAL"],row,row, row, row
                    , row["SURNAME"], row["PAYMETHOD"], row["ID"]);

                dgvOrders.Rows[i].Cells[4].Value = "";
                dgvOrders.Rows[i].Cells[4].Style.BackColor = Color.Red;

                dgvOrders.Rows[i].Cells[5].Value = "";
                dgvOrders.Rows[i].Cells[5].Style.BackColor = Color.Red;

                dgvOrders.Rows[i].Cells[6].Value = "";
                dgvOrders.Rows[i].Cells[6].Style.BackColor = Color.Red;

                dgvOrders.Rows[i].Cells[7].Value = "";
                dgvOrders.Rows[i].Cells[7].Style.BackColor = Color.Red;

                //decimal statusRow = orders.gestorOrder.getstatus(Convert.ToDecimal(dgvOrders.Rows[i].Cells[10].Value));
                decimal statusRow = orders.gestorOrder.getstatus(Convert.ToDecimal(Convert.ToString(row["ID"])));
                switch (Convert.ToInt32(statusRow))
                {
                    case 1:
                        dgvOrders.Rows[i].Cells[4].Style.BackColor = Color.Green;
                        break;
                    case 2:
                        dgvOrders.Rows[i].Cells[4].Style.BackColor = Color.Green;
                        dgvOrders.Rows[i].Cells[5].Style.BackColor = Color.Green;
                        break;
                    case 3:
                        dgvOrders.Rows[i].Cells[4].Style.BackColor = Color.Green;
                        dgvOrders.Rows[i].Cells[5].Style.BackColor = Color.Green;
                        dgvOrders.Rows[i].Cells[6].Style.BackColor = Color.Green;
                        break;
                    case 4:
                        dgvOrders.Rows[i].Cells[4].Style.BackColor = Color.Green;
                        dgvOrders.Rows[i].Cells[5].Style.BackColor = Color.Green;
                        dgvOrders.Rows[i].Cells[6].Style.BackColor = Color.Green;
                        dgvOrders.Rows[i].Cells[7].Style.BackColor = Color.Green;
                        break;
                }
                i++;
            }

            dgvOrders.Columns[4].DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dgvOrders.Columns[5].DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dgvOrders.Columns[6].DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dgvOrders.Columns[7].DefaultCellStyle.SelectionBackColor = Color.Transparent;

            dgvOrders.RowHeadersVisible = false;
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.BackgroundColor = Color.Black;
            dgvOrders.ReadOnly = true;
            dgvOrders.Sort(dgvOrders.Columns[10],ListSortDirection.Descending);
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
            dgvCustomers.RowHeadersVisible = false;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.BackgroundColor = Color.Black;
            dgvCustomers.ReadOnly = true;
        }

        private void controlErroresUsuarios()
        {
            /*Hay un problema y es que cuando se inicia la tabla sale selecionada ya una fila y si no selecionas otra
             * y le das a alguna funcion, al no funcionar elevento que salta cuando pulsas una fila da error porque
             * estas dos variables estan vacias. Para ello le asigno en este metodo desde el principio el contenido de la
             * fila seleccionada por defecto.*/

            if (nombreFilaSeleccionadaUsers.Equals(""))
            {
                if (usuario.gestorusuario.contarUsuarios() > 0)
                {
                    dgvUsers.Rows[dgvUsers.Rows[0].Index].Selected = true;
                    dgvUsers.CurrentCell = dgvUsers.Rows[dgvUsers.Rows[0].Index].Cells[0];

                    nombreFilaSeleccionadaUsers = dgvUsers.Rows[dgvUsers.SelectedRows[0].Index].Cells[0].Value.ToString();
                    rolFilaSellecionadaUsers = dgvUsers.Rows[dgvUsers.SelectedRows[0].Index].Cells[1].Value.ToString();
                }
            }
        }

        private void controlErroresProduct()
        {
            /*Hay un problema y es que cuando se inicia la tabla sale selecionada ya una fila y si no selecionas otra
             * y le das a alguna funcion, al no funcionar elevento que salta cuando pulsas una fila da error porque
             * estas dos variables estan vacias. Para ello le asigno en este metodo desde el principio el contenido de la
             * fila seleccionada por defecto.*/

            if (nombreFilaSeleccionadaProducts.Equals(""))
            {
                if (producto.gestorProducto.contarProductos() > 0)
                {
                    dgvProducts.Rows[dgvProducts.Rows[0].Index].Selected = true;
                    dgvProducts.CurrentCell = dgvProducts.Rows[dgvProducts.Rows[0].Index].Cells[0];
                    nombreFilaSeleccionadaProducts = dgvProducts.Rows[dgvProducts.SelectedRows[0].Index].Cells[0].Value.ToString();
                    catViejaFilaSellecionadaProducts = dgvProducts.Rows[dgvProducts.SelectedRows[0].Index].Cells[1].Value.ToString();
                    platViejaFilaSellecionadaProducts = dgvProducts.Rows[dgvProducts.SelectedRows[0].Index].Cells[2].Value.ToString();
                    pegiFilaSellecionadaProducts = dgvProducts.Rows[dgvProducts.SelectedRows[0].Index].Cells[3].Value.ToString();
                    priceFilaSellecionadaProducts = dgvProducts.Rows[dgvProducts.SelectedRows[0].Index].Cells[4].Value.ToString();
                    stockFilaSeleccionadaProducts = dgvProducts.Rows[dgvProducts.SelectedRows[0].Index].Cells[5].Value.ToString();
                }
            }
        }

        private void controlErroresPlataformas()
        {
            /*Hay un problema y es que cuando se inicia la tabla sale selecionada ya una fila y si no selecionas otra
             * y le das a alguna funcion, al no funcionar elevento que salta cuando pulsas una fila da error porque
             * estas dos variables estan vacias. Para ello le asigno en este metodo desde el principio el contenido de la
             * fila seleccionada por defecto.*/

            if (nombreviejoPlataformas.Equals(""))
            {
                if (plataforma.gestorplataforma.contarPlataformas() > 0)
                {
                    dgvPlatforms.Rows[dgvPlatforms.Rows[0].Index].Selected = true;
                    dgvPlatforms.CurrentCell = dgvPlatforms.Rows[dgvPlatforms.Rows[0].Index].Cells[0];
                    nombreviejoPlataformas = dgvPlatforms.Rows[dgvPlatforms.SelectedRows[0].Index].Cells[0].Value.ToString();
                }
            }
        }

        private void controlErroresCategorias()
        {
            /*Hay un problema y es que cuando se inicia la tabla sale selecionada ya una fila y si no selecionas otra
             * y le das a alguna funcion, al no funcionar elevento que salta cuando pulsas una fila da error porque
             * estas dos variables estan vacias. Para ello le asigno en este metodo desde el principio el contenido de la
             * fila seleccionada por defecto.*/

            if (nombreviejoCategoria.Equals(""))
            {
                if (categoria.gestor.contarCategorias() > 0)
                {
                    dgvCategorie.Rows[dgvCategorie.Rows[0].Index].Selected = true;
                    dgvCategorie.CurrentCell = dgvCategorie.Rows[dgvCategorie.Rows[0].Index].Cells[0];
                    nombreviejoCategoria = dgvCategorie.Rows[dgvCategorie.SelectedRows[0].Index].Cells[0].Value.ToString();
                }
            }
        }

        private void controlErroresClientes()
        {
            /*Hay un problema y es que cuando se inicia la tabla sale selecionada ya una fila y si no selecionas otra
             * y le das a alguna funcion, al no funcionar elevento que salta cuando pulsas una fila da error porque
             * estas dos variables estan vacias. Para ello le asigno en este metodo desde el principio el contenido de la
             * fila seleccionada por defecto.*/

            if (dniFilaSeleccionadaClientes.Equals(""))
            {
                if (cliente.gestorCliente.contarClientes() > 0)
                {
                    dgvCustomers.Rows[dgvCustomers.Rows[0].Index].Selected = true;
                    dgvCustomers.CurrentCell = dgvCustomers.Rows[dgvCustomers.Rows[0].Index].Cells[0];

                    dniFilaSeleccionadaClientes = dgvCustomers.Rows[dgvCustomers.SelectedRows[0].Index].Cells[0].Value.ToString();
                    nameFilaSellecionadaClientes = dgvCustomers.Rows[dgvCustomers.SelectedRows[0].Index].Cells[1].Value.ToString();
                    surnameFilaSeleccionadaClientes = dgvCustomers.Rows[dgvCustomers.SelectedRows[0].Index].Cells[2].Value.ToString();
                    addressFilaSellecionadaClientes = dgvCustomers.Rows[dgvCustomers.SelectedRows[0].Index].Cells[3].Value.ToString();
                    phoneFilaSeleccionadaClientes = dgvCustomers.Rows[dgvCustomers.SelectedRows[0].Index].Cells[4].Value.ToString();
                    emailFilaSellecionadaClientes = dgvCustomers.Rows[dgvCustomers.SelectedRows[0].Index].Cells[5].Value.ToString();
                    cityFilaSeleccionadaClientes = dgvCustomers.Rows[dgvCustomers.SelectedRows[0].Index].Cells[6].Value.ToString();
                }
            }
        }

        public void filtrarTablaUsuario(String name, bool check)
        {
            String condicion = "";

            if (check)
            {
                condicion += " U.NAME like '%" + name + "%' AND U.DELETED=1";
            }
            else
            {
                condicion += " U.NAME like '%" + name + "%' AND U.DELETED=0";
            }

            cargarTablaUsuarios(condicion);
        }

        public void filtrarTablaProductos(String name, bool check)
        {
            String condicion = "";

            if (check)
            {
                condicion += " PR.NAME like '%" + name + "%' AND PR.DELETED=1 ";//OR C.NAME LIKE '%" + name+ "%'OR PL.NAME LIKE '%" + name + "%'";
            }
            else
            {
                condicion += " PR.NAME like '%" + name + "%' AND PR.DELETED=0 ";// OR C.NAME LIKE '%" + name + "%' OR PL.NAME LIKE '%" + name + "%'";
            }

            cargarTablaProductos(condicion);
        }

        private void FormPrincipal_SizeChanged(object sender, EventArgs e)
        {

            tbcMenuPrincipal.Width = this.Width;
            tbcMenuPrincipal.Height = this.Height;

            tbcInterCashBook.Width = tbcMenuPrincipal.Width;
            tbcInterCashBook.Height = tbcMenuPrincipal.Height - 250;

            dgvIncomes.Width = tbcInterCashBook.Width - 130;
            dgvIncomes.Height = tbcInterCashBook.Height - 80;

            dgvExpenses.Width = tbcInterCashBook.Width - 130;
            dgvExpenses.Height = tbcInterCashBook.Height - 80;

            dgvPendingPayment.Width = tbcInterCashBook.Width - 130;
            dgvPendingPayment.Height = tbcInterCashBook.Height - 80;

            dgvDebts.Width = tbcInterCashBook.Width - 130;
            dgvDebts.Height = tbcInterCashBook.Height - 80;


            //Cashbook
            int pantallaX = this.Location.X;
            int pantallaY = this.Location.Y;

            //lblInCash.Location = new Point(130, 653);
            //tbxInCash.Location = new Point(200, 650);
            //lbleuro1.Location = new Point(330, 653);
            lblInCash.Location = new Point(pantallaX + 180, pantallaY + 563);
            tbxInCash.Location = new Point(pantallaX + 240, pantallaY + 560);
            lbleuro1.Location = new Point(pantallaX + 370, pantallaY + 563);

            //lblChecks.Location = new Point(130, 703);
            //tbxChecks.Location = new Point(200, 700);
            //lbleuro2.Location = new Point(330, 703);
            lblChecks.Location = new Point(pantallaX + 180, pantallaY + 613);
            tbxChecks.Location = new Point(pantallaX + 240, pantallaY + 610);
            lbleuro2.Location = new Point(pantallaX + 370, pantallaY + 613);

            //lblReceipts.Location = new Point(130, 753);
            //tbxReceipts.Location = new Point(200, 750);
            //lbleuro3.Location = new Point(330, 753);
            lblReceipts.Location = new Point(pantallaX + 180, pantallaY + 663);
            tbxReceipts.Location = new Point(pantallaX + 240, pantallaY + 660);
            lbleuro3.Location = new Point(pantallaX + 370, pantallaY + 663);

            //lblTotal.Location = new Point(390, 753);
            //tbxTotal.Location = new Point(450, 750);
            //lbleuro4.Location = new Point(590, 753);
            lblTotal.Location = new Point(pantallaX + 400, pantallaY + 663);
            tbxTotal.Location = new Point(pantallaX + 460, pantallaY + 660);
            lbleuro4.Location = new Point(pantallaX + 600, pantallaY + 663);

            btnValidateHistory.Location = new Point(pantallaX + 800, pantallaY + 600);
        }

        private void tabPage2_Resize(object sender, EventArgs e)
        {

            dgvUsers.Width = this.Width - 150;
            dgvUsers.Height = this.Height - 100;

            dgvCustomers.Width = this.Width - 150;
            dgvCustomers.Height = this.Height - 100;

            dgvCategorie.Width = this.Width - 150;
            dgvCategorie.Height = this.Height - 100;

            dgvOrders.Width = this.Width - 150;
            dgvOrders.Height = this.Height - 100;

            dgvPlatforms.Width = this.Width - 150;
            dgvPlatforms.Height = this.Height - 100;

            dgvInvoices.Width = this.Width - 150;
            dgvInvoices.Height = this.Height - 100;

            panel2.Width = tbcMenuPrincipal.Width;
            panel2.Height = tbcMenuPrincipal.Height;

        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (!nombreFilaSeleccionadaUsers.Equals(""))
            {
                if (nombreFilaSeleccionadaUsers.Equals(nombreUsuarioLogueado))
                {
                    String mensaje = "Estas logueado con este user.";
                    VentanaPersonalizada cambio = new VentanaPersonalizada(mensaje);
                    cambio.ShowDialog();
                }
                else
                {
                    ConfirmarBorrarUsuario deletedUser = new ConfirmarBorrarUsuario(dgvUsers, nombreFilaSeleccionadaUsers);
                    deletedUser.ShowDialog();
                    filtroTotalUsuarios();
                }
            }
            else
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
            nombreviejoCategoria = name;
            ucategorie.ShowDialog();

            cargarCategorias();
        }

        private void btnDeleteCategorie_Click(object sender, EventArgs e)
        {
            if (!categoria.gestor.categoriaEstaProducto(dgvCategorie.Rows[dgvCategorie.CurrentRow.Index].Cells[0].Value.ToString()))
            {
                DeleteCategorie dc = new DeleteCategorie();
                dc.namedelete = dgvCategorie.Rows[dgvCategorie.CurrentRow.Index].Cells[0].Value.ToString();
                dc.ShowDialog();
                cargarCategorias();
            }
            else
            {
                String mensaje = "Any product have this Categorie";
                VentanaPersonalizada vp = new VentanaPersonalizada(mensaje);
                vp.ShowDialog();
            }
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            EditarRol editRol = new EditarRol();
            editRol.ShowDialog();
        }

        public void cargarComponentes()
        {

            //General
            tbxSearchUser.ForeColor = Color.Gray;
            tbxSearchUser.Text = "Search a Name...";

            tbxSearchCustomer.ForeColor = Color.Gray;
            tbxSearchCustomer.Text = "Search a Name...";

            txtSearchProd.ForeColor = Color.Gray;
            txtSearchProd.Text = "Search a Name...";

            txtSearchOrder.ForeColor = Color.Gray;
            txtSearchOrder.Text = "Search...";
            //Usuarios
            aparienciaBotones(btnNewUser);
            aparienciaBotones(btnEditUser);
            aparienciaBotones(btnRoles);
            aparienciaBotones(btnDeleteUser);
            aparienciaBotones(btnLogs);

            //Clientes
            aparienciaBotones(btnNewCustomer);
            aparienciaBotones(btnEditCustomer);
            aparienciaBotones(btnDeleteCustomer);

            //Orders
            aparienciaBotones(btnNewOrder);
            aparienciaBotones(btnViewDetails);
            aparienciaBotones(btnEditOrder);
            aparienciaBotones(btnDeleteOrder);
            aparienciaBotones(btnResOrders);
            btnResOrders.Enabled = false;
            btnResOrders.BackColor = Color.DarkOrange;

            //Productos
            aparienciaBotones(btnNewProd);
            aparienciaBotones(btnUpdateProd);
            aparienciaBotones(btnDeleteProd);

            //Platforms
            aparienciaBotones(btnUpdatePlatform);
            aparienciaBotones(btnDeletePlatform);
            aparienciaBotones(btnNewPlatform);

            //Categorias
            aparienciaBotones(btnNewCategorie);
            aparienciaBotones(btnUpdateCategorie);
            aparienciaBotones(btnDeleteCategorie);

            //System
            aparienciaBotones(btnExit);
            aparienciaBotones(btnLogOut);

            //Incomes (Filtros y Botones)
            dtpRangoInicialI.Value = new DateTime(1970, 1, 1);
            dtpRangoFinalI.Value = DateTime.Now;

            tbxFilterConceptI.ForeColor = Color.Gray;
            tbxFilterConceptI.Text = "Concept...";

            tbxFilterAmountI.ForeColor = Color.Gray;
            tbxFilterAmountI.Text = "Amount...";

            cmbFilterAmountSimbolI.Items.Add("");
            cmbFilterAmountSimbolI.Items.Add("<");
            cmbFilterAmountSimbolI.Items.Add(">");
            cmbFilterAmountSimbolI.Items.Add("=");
            cmbFilterAmountSimbolI.SelectedItem = 0;

            string[] sourceIncomes = incomes.gestorIncome.getSources();
            cmbFilterSource.Items.Clear();
            cmbFilterSource.Items.Add("-SOURCES-");
            for (int i = 0; i < sourceIncomes.Length; i++)
            {
                cmbFilterSource.Items.Add(sourceIncomes[i]);
            }
            cmbFilterSource.SelectedItem = "-SOURCES-";

            string[] typesIncomes = incomes.gestorIncome.getTypes();
            cmbFilterTypeI.Items.Clear();
            cmbFilterTypeI.Items.Add("-TYPES-");
            for (int i = 0; i < typesIncomes.Length; i++)
            {
                cmbFilterTypeI.Items.Add(typesIncomes[i]);
            }
            cmbFilterTypeI.SelectedItem = "-TYPES-";

            aparienciaBotones(btnNewIncome);
            aparienciaBotones(btnRevokeIncome);
            aparienciaBotones(btnClearDatesI);
            aparienciaBotones(btnValidateHistory);

            //Expenses(Filtros y botones)
            string[] targetsExpenses = expense.gestorExpense.refrescarTargets();
            cmbFilterTarget.Items.Clear();
            cmbFilterTarget.Items.Add("-TARGETS-");
            for (int i = 0; i < targetsExpenses.Length; i++)
            {
                cmbFilterTarget.Items.Add(targetsExpenses[i]);
            }
            cmbFilterTarget.SelectedItem = "-TARGETS-";

            string[] tiposExpenses = expense.gestorExpense.refrescarTypes();
            cmbFilterTypeE.Items.Clear();
            cmbFilterTypeE.Items.Add("-TYPES-");
            for (int i = 0; i < tiposExpenses.Length; i++)
            {
                cmbFilterTypeE.Items.Add(tiposExpenses[i]);
            }
            cmbFilterTypeE.SelectedItem = "-TYPES-";

            //expense.gestorExpense.refrescarTargets(cmbFilterTarget);
            //expense.gestorExpense.refrescarTypes(cmbFilterTypeE);
            cmbFilterAmountSimbolE.SelectedIndex=0;

            aparienciaBotones(btnNewExpense);
            aparienciaBotones(btnRevokeExpense);
            aparienciaBotones(btnCleanDatesE);
            tbxFilterConceptE.ForeColor = Color.Gray;
            tbxFilterConceptE.Text = "Concept...";
            tbxFilterAmountE.ForeColor = Color.Gray;
            tbxFilterAmountE.Text = "Amount...";
            dtpRangoInicialE.Value = new DateTime(1970, 1, 1);
            dtpRangoFinalE.Value = DateTime.Now;

            //Pending Payment(Filtros y botones)
            dtpStartFilterP.Value = new DateTime(1970, 1, 1);
            dtpEndFilterP.Value = DateTime.Now;

            tbxFilterConceptP.ForeColor = Color.Gray;
            tbxFilterConceptP.Text = "Concept...";

            tbxFilterAmountP.ForeColor = Color.Gray;
            tbxFilterAmountP.Text = "Amount...";

            cmbFilterAmountSimbolP.Items.Add("");
            cmbFilterAmountSimbolP.Items.Add("<");
            cmbFilterAmountSimbolP.Items.Add(">");
            cmbFilterAmountSimbolP.Items.Add("=");
            cmbFilterAmountSimbolP.SelectedItem = 0;

            string[] typesPPayment = pendingPayments.gestorPendingPayments.getTypes();
            cmbFilterTypeP.Items.Clear();
            cmbFilterTypeP.Items.Add("-TYPES-");
            for (int i = 0; i < typesPPayment.Length; i++)
            {
                cmbFilterTypeP.Items.Add(typesPPayment[i]);
            }
            cmbFilterTypeP.SelectedItem = "-TYPES-";

            aparienciaBotones(btnCleanDatesP);
            aparienciaBotones(btnNewPpayment);
            aparienciaBotones(btnCollect);

            //Debts (Filtros y botones)
            dtpStartDateD.Value = new DateTime(1970, 1, 1);
            dtpEndDateD.Value = DateTime.Now;

            tbxConceptD.ForeColor = Color.Gray;
            tbxConceptD.Text = "Concept...";

            tbxAmountD.ForeColor = Color.Gray;
            tbxAmountD.Text = "Amount...";

            cmbAmountSimbolD.Items.Add("");
            cmbAmountSimbolD.Items.Add("<");
            cmbAmountSimbolD.Items.Add(">");
            cmbAmountSimbolD.Items.Add("=");
            cmbAmountSimbolD.SelectedItem = 0;

            aparienciaBotones(btnCleanDatesD);
            aparienciaBotones(btnNewDebt);
            aparienciaBotones(btnPay);

            //Invoices
            aparienciaBotones(btnNewInvoice);
            aparienciaBotones(btnUpdateInvoice);
            aparienciaBotones(btnDeleteInvoice);
            aparienciaBotones(btnPrintInvoice);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ConfirmarExit cExit = new ConfirmarExit();
            cExit.ShowDialog();
        }

        private void tbcMenuPrincipal_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!e.TabPage.Enabled)
            {
                e.Cancel = true;
            }
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
                btnDeleteUser.BackColor = Color.Transparent;
                btnDeleteUser.ForeColor = Color.Black;
            }
            else
            {
                btnDeleteUser.Enabled = true;
                btnDeleteUser.BackColor = Color.Black;
                btnDeleteUser.ForeColor = Color.White;
            }
            filtroTotalUsuarios();
        }
        public void filtroTotalUsuarios()
        {
            bool deleted = false;
            if (cbxUserDeleted.CheckState == CheckState.Checked)
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
            Logs logs = new Logs();
            logs.ShowDialog();
        }

        private void btnNewProd_Click(object sender, EventArgs e)
        {
            AñadirProducto addProduct = new AñadirProducto(dgvCategorie, dgvPlatforms);
            addProduct.ShowDialog();
            filtroTotalProd();//Usa cargar tabla usuarios para actualizar tabla
            cargarCategorias();
            cargarPlataformas();
        }

        private void cmbFilCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtroTotalProd();
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
            EditarProducto updateProduct = new EditarProducto(nombreFilaSeleccionadaProducts, catViejaFilaSellecionadaProducts, platViejaFilaSellecionadaProducts, pegiFilaSellecionadaProducts, priceFilaSellecionadaProducts, stockFilaSeleccionadaProducts);
            updateProduct.ShowDialog();
            filtroTotalProd();
        }

        private void cmbFilPlatform_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtroTotalProd();
        }

        private void tabPage5_Resize(object sender, EventArgs e)
        {
            dgvProducts.Width = this.Width - 150;
            dgvProducts.Height = this.Height - 100;
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

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            NuevoCliente newCustomer = new NuevoCliente();
            newCustomer.ShowDialog();
            filtroTotalClientes();
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
                    stockFilaSeleccionadaProducts = dgvProducts.Rows[e.RowIndex].Cells[5].Value.ToString();
                }
            }

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

        public void filtroTotalIncomes()
        {
            string fechaInicial = dtpRangoInicialI.Value.ToString();
            string fechaFinal = dtpRangoFinalI.Value.ToString();
            Decimal sourceNumber = cmbFilterSource.SelectedIndex - 1;
            Decimal typeNumber = cmbFilterTypeI.SelectedIndex - 1;
            string operador = Convert.ToString(cmbFilterAmountSimbolI.SelectedItem);
            filtrarTablaIncomes(tbxFilterConceptI.Text.Equals("Concept...") ? "" : tbxFilterConceptI.Text, operador, (tbxFilterAmountI.Text.Equals("Amount...") || tbxFilterAmountI.Text.Equals("")) ? Convert.ToDecimal(0) : Convert.ToDecimal(Convert.ToDecimal(tbxFilterAmountI.Text)), fechaInicial, fechaFinal, sourceNumber, typeNumber);
            cargarTotales();

        }

        public void filtrarTablaIncomes(string concept, string oper, decimal amount, string start, string end, decimal source, decimal type)
        {

            incomes.gestorIncome.readIncomes(concept, oper, amount, start, end, source, type);
            dgvIncomes.DataSource = incomes.gestorIncome.tIncomes;
        }

        public void filtrarTablaExpense(string concept, string oper, decimal amount,String start, String end, decimal source, decimal type)
        {

            expense.gestorExpense.readExpenses(concept, oper, amount, start, end, source, type);
            dgvExpenses.DataSource = expense.gestorExpense.tExpenses;  
        }

        public void filtroTotapPPayment()
        {
            string fechaInicial = dtpStartFilterP.Value.ToString();
            string fechaFinal = dtpEndFilterP.Value.ToString();
            Decimal typeNumber = cmbFilterTypeP.SelectedIndex - 1;
            string operador = Convert.ToString(cmbFilterAmountSimbolP.SelectedItem);
            filtrarTablaPPayment(tbxFilterConceptP.Text.Equals("Concept...") ? "" : tbxFilterConceptP.Text, operador, (tbxFilterAmountP.Text.Equals("Amount...") || tbxFilterAmountP.Text.Equals("")) ? Convert.ToDecimal(0) : Convert.ToDecimal(tbxFilterAmountP.Text), fechaInicial, fechaFinal, typeNumber);
            cargarTotales();

        }

        public void filtrarTablaPPayment(string concept, string oper, decimal amount, string start, string end, decimal type)
        {

            pendingPayments.gestorPendingPayments.readPendingPayments(concept, oper, amount, start, end, type);
            dgvPendingPayment.DataSource = pendingPayments.gestorPendingPayments.tPPayments;
        }

        public void filtroTotalDebts()
        {
            string fechaInicial = dtpStartDateD.Value.ToString();
            string fechaFinal = dtpEndDateD.Value.ToString();
            string operador = Convert.ToString(cmbAmountSimbolD.SelectedItem);
            filtrarTablaDebts(tbxConceptD.Text.Equals("Concept...") ? "" : tbxConceptD.Text, operador, (tbxAmountD.Text.Equals("Amount...") || tbxAmountD.Text.Equals("")) ? Convert.ToDouble(0) : Convert.ToDouble(tbxAmountD.Text), fechaInicial, fechaFinal);
            cargarTotales();

        }

        public void filtrarTablaDebts(string concept, string oper, double amount, string start, string end)
        {
            debts.gestorDebts.readDebts(concept, oper, amount, start, end);
            dgvDebts.DataSource = debts.gestorDebts.tDebts;
        }

        private void tbxSearchCustomer_KeyUp(object sender, KeyEventArgs e)
        {
            filtroTotalClientes();
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

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (!dniFilaSeleccionadaClientes.Equals(""))
            {
                if (!cliente.gestorCliente.clienteTienePedidos(dniFilaSeleccionadaClientes))
                {
                    ConfirmarBorrarCliente deleteCustomer = new ConfirmarBorrarCliente(dgvCustomers, dniFilaSeleccionadaClientes);
                    deleteCustomer.ShowDialog();
                    filtroTotalClientes();
                }
                else
                {
                    String mensaje = "The customer have Orders.";
                    VentanaPersonalizada vp = new VentanaPersonalizada(mensaje);
                    vp.ShowDialog();
                }
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
            if (!nameFilaSellecionadaClientes.Equals(""))
            {
                EditarClientes editCli = new EditarClientes(dniFilaSeleccionadaClientes, nameFilaSellecionadaClientes, surnameFilaSeleccionadaClientes, addressFilaSellecionadaClientes, phoneFilaSeleccionadaClientes, emailFilaSellecionadaClientes, cityFilaSeleccionadaClientes);
                editCli.ShowDialog();
                filtroTotalClientes();
            }
            else
            {
                String mensaje = "No se ha selecionado ninguna fila.";
                VentanaPersonalizada cambio = new VentanaPersonalizada(mensaje);
                cambio.ShowDialog();
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

        private void btnUpdatePlatform_Click(object sender, EventArgs e)
        {
            UpdatePlataforma up = new UpdatePlataforma();
            String name = dgvPlatforms.Rows[dgvPlatforms.CurrentRow.Index].Cells[0].Value.ToString();
            up.txtUpdate.Text = name;
            nombreviejoPlataformas = name;
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
            if (!plataforma.gestorplataforma.plataformaEstaProducto(dgvPlatforms.Rows[dgvPlatforms.CurrentRow.Index].Cells[0].Value.ToString()))
            {
                DeletePlataforma dp = new DeletePlataforma();
                dp.nameDelete = dgvPlatforms.Rows[dgvPlatforms.CurrentRow.Index].Cells[0].Value.ToString();
                dp.ShowDialog();
                cargarPlataformas();
            }
            else
            {
                String mensaje = "Any product have this Platform";
                VentanaPersonalizada vp = new VentanaPersonalizada(mensaje);
                vp.ShowDialog();
            }
        }

        private void txtSearchProd_KeyUp(object sender, KeyEventArgs e)
        {
            filtroTotalProd();
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            Presentacion.Orders.NewOrder dialogNewOrder = new Presentacion.Orders.NewOrder(idUsuarioLogueado);
            dialogNewOrder.ShowDialog();
            txtSearchOrder.Text = "";
            cargarTablaOrders("");
        }

        private void dgvPlatforms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (dgvPlatforms.Rows.Count > 0 && dgvPlatforms.Rows[e.RowIndex].Cells[e.ColumnIndex] != null)
            {
                if (!String.IsNullOrEmpty(dgvPlatforms.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                {
                    // do sonmthind
                    nombreviejoPlataformas = dgvPlatforms.Rows[dgvPlatforms.CurrentRow.Index].Cells[0].Value.ToString();
                }
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 1)
            {
                ViewOrder viewer = new ViewOrder(dgvOrders.SelectedRows[0].Cells[10].Value.ToString());
                viewer.ShowDialog();
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (filaOrders >= 0)
            {

                string id = ((decimal)dgvOrders.Rows[filaOrders].Cells[10].Value).ToString();
                DeleteInvoice dlg = new DeleteInvoice();
                dlg.ShowDialog();
                if (dlg.Acept)
                {
                    orders.gestorOrder.eliminar(id);
                    MessageBox.Show("Deleted successfully");
                    cargarTablaOrders("");
                    ERP.Persistencia.Logs.write("Order " + id + " deleted");
                }

            }
            else
            {
                MessageBox.Show("You haven't choose a order, or it can't be deleted");
            }

        }

        private void tbcMenuPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvOrders.ClearSelection(); cargarInvoices();
            dgvInvoices.ClearSelection();
            
        }

        private void cbxCustomerDeleted_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxCustomerDeleted.CheckState == CheckState.Checked)
            {
                btnDeleteCustomer.Enabled = false;
                btnDeleteCustomer.BackColor = Color.Transparent;
                btnDeleteCustomer.ForeColor = Color.Black;
            }
            else
            {
                btnDeleteCustomer.Enabled = true;
                btnDeleteCustomer.BackColor = Color.Black;
                btnDeleteCustomer.ForeColor = Color.White;
            }
            filtroTotalClientes();
        }

        private void txtSearchOrder_KeyUp(object sender, KeyEventArgs e)
        {
            cargarTablaOrders(txtSearchOrder.Text.ToUpper().Replace("'", ""));
            dgvOrders.ClearSelection();
        }
        int filaOrders = -1;
        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            filaOrders = e.RowIndex;
        }

        private void txtSearchOrder_Enter(object sender, EventArgs e)
        {
            if (txtSearchOrder.Text.Equals("Search..."))
            {
                txtSearchOrder.Text = "";
                txtSearchOrder.ForeColor = Color.Black;
            }
        }

        private void txtSearchOrder_Leave(object sender, EventArgs e)
        {
            if (txtSearchOrder.Text.Equals(""))
            {
                txtSearchOrder.ForeColor = Color.Gray;
                txtSearchOrder.Text = "Search...";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewExpense expensev = new NewExpense(idUsuarioLogueado);
            expensev.ShowDialog();
           
            filtroTotalExpense();
           
        }
        public void filtroTotalExpense()
        {
            string fechaInicial = dtpRangoInicialE.Value.ToString();
            string fechaFinal = dtpRangoFinalE.Value.ToString();
            Decimal targetNumber = cmbFilterTarget.SelectedIndex - 1;
            Decimal typeNumber = cmbFilterTypeE.SelectedIndex - 1;
            string operador = Convert.ToString(cmbFilterAmountSimbolE.SelectedItem);
            filtrarTablaExpense(tbxFilterConceptE.Text.Equals("Concept...") ? "" : tbxFilterConceptE.Text, operador, (tbxFilterAmountE.Text.Equals("Amount...") || tbxFilterAmountE.Text.Equals("")) ? Convert.ToDecimal(0) : Convert.ToDecimal(Convert.ToDecimal(tbxFilterAmountE.Text)), fechaInicial, fechaFinal, targetNumber, typeNumber);
            cargarTotales();

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dgvExpenses.SelectedRows.Count == 0)
            {
                VentanaPersonalizada vp = new VentanaPersonalizada("Any Row Selected");
                vp.ShowDialog();
            }
            else
            {
                decimal idSelecc = (decimal)dgvExpenses.SelectedRows[0].Cells[0].Value;
                if (idSelecc > 0)
                {
                    new RevokeExpense(expense, idSelecc, (Decimal)idUsuarioLogueado).ShowDialog();
                }
                filtroTotalExpense();
            }
        }

        private void filtrarElementosExpense(object sender, EventArgs e)
        {
            filtroTotalExpense();
        }

        private void btnNewIncome_Click(object sender, EventArgs e)
        {
            NewIncome newIncome = new NewIncome(idUsuarioLogueado);
            newIncome.ShowDialog();
            filtroTotalIncomes();
        }

        private void dgvExpenses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtpRangoInicialI.Value = new DateTime(1970, 1, 1);
            dtpRangoFinalI.Value = DateTime.Now;
        }

        private void tbxFilterConceptI_Enter(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Equals("Concept..."))
            {
                ((TextBox)sender).Text = "";
                ((TextBox)sender).ForeColor = Color.Black;
            }
        }
        public void cargarExpenses()
        {
            dgvExpenses.DataSource = expense.gestorExpense.tExpenses;
            dgvExpenses.RowHeadersVisible = false;
            dgvExpenses.AllowUserToAddRows = false;
            dgvExpenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExpenses.BackgroundColor = Color.Black;
            dgvExpenses.Columns[0].Visible = false;

        }

        private void tbxFilterConceptI_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Trim().Equals(""))
            {
                ((TextBox)sender).ForeColor = Color.Gray;
                ((TextBox)sender).Text = "Concept...";
            }
        }

        private void tbxFilterAmountI_Enter(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Equals("Amount..."))
            {
                ((TextBox)sender).Text = "";
                ((TextBox)sender).ForeColor = Color.Black;
            }
        }

        private void tbxFilterAmountI_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Trim().Equals(""))
            {
                ((TextBox)sender).ForeColor = Color.Gray;
                ((TextBox)sender).Text = "Amount...";
            }
        }

        private void filtrarElementosIncomes(object sender, EventArgs e)
        {
            filtroTotalIncomes();
        }

        private void tbxFilterAmountI_KeyUp(object sender, KeyEventArgs e)
        {
            Boolean valido = true;
            Boolean coma = false;
            for (int i = 0; i < tbxFilterAmountI.Text.Length; i++)
            {
                if (Char.IsLetter(tbxFilterAmountI.Text.ElementAt(i)))
                {
                    valido = false;
                }
                if (!(Char.IsDigit(tbxFilterAmountI.Text.ElementAt(i))))
                {
                    valido = false;
                }
                if ((tbxFilterAmountI.Text.ElementAt(i).Equals(',') || tbxFilterAmountI.Text.ElementAt(i).Equals('.')) && tbxFilterAmountI.Text.Length > 1)
                {
                    valido = true;
                    if (!coma)
                    {
                        coma = true;
                    }
                    else
                    {
                        tbxFilterAmountI.Text = tbxFilterAmountI.Text.Substring(0, tbxFilterAmountI.Text.Length - 1);
                        tbxFilterAmountI.SelectionStart = tbxFilterAmountI.Text.Length;
                    }

                }
            }
            if (valido)
            {
                filtroTotalIncomes();
            } else
            {
                tbxFilterAmountI.Text = "0";
                filtroTotalIncomes();
            }
                
        }

        private void cargarTotales()
        {
            tbxChecks.Text = (incomes.gestorIncome.getTotalChecks() - expense.gestorExpense.getTotalChecks()).ToString();
            tbxInCash.Text = (incomes.gestorIncome.getTotalCash() - expense.gestorExpense.getTotalCash()).ToString();
            tbxReceipts.Text = (incomes.gestorIncome.getTotalReceipts() - expense.gestorExpense.getTotalReceipts()).ToString();
            tbxTotal.Text = (incomes.gestorIncome.getTotal() - expense.gestorExpense.getTotal()).ToString();
        }

        private void btnRevokeIncome_Click(object sender, EventArgs e)
        {
            if(dgvIncomes.SelectedRows.Count == 0)
            {
                VentanaPersonalizada vp = new VentanaPersonalizada("Any Row Selected");
                vp.ShowDialog();
            } else
            {
                decimal idSelecc = (decimal)dgvIncomes.SelectedRows[0].Cells[0].Value;
                if (idSelecc > 0)
                {
                    new DeleteIncome(incomes, idSelecc, (Decimal)idUsuarioLogueado).ShowDialog();
                }
                filtroTotalIncomes();
            }
            
        }

        private void tbxFilterConceptI_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = e.KeyChar=='\'';
        }

        private void tbxFilterAmountI_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valido = false;
            if (Char.IsDigit(e.KeyChar))
            {
                valido = true;
            }
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                if (!tbxFilterAmountI.Text.Contains(","))
                {
                    e.KeyChar = ',';
                    valido = true;
                }

            }
            if (Char.IsControl(e.KeyChar))
            {
                valido = true;
            }
            e.Handled = !valido;
        }

        private void btnClearDates_Click(object sender, EventArgs e)
        {
            dtpRangoInicialI.Value = new DateTime(1970, 01, 01);
            dtpRangoFinalI.Value = DateTime.Today;
        }

        private void btnValidateHistory_Click(object sender, EventArgs e)
        {
            ValidateHistory validateH = new ValidateHistory((Decimal)idUsuarioLogueado, Convert.ToDecimal(tbxInCash.Text), Convert.ToDecimal(tbxReceipts.Text), Convert.ToDecimal(tbxChecks.Text), Convert.ToDecimal(tbxTotal.Text));
            validateH.ShowDialog();
        }

        private void tbxFilterConceptE_KeyUp(object sender, KeyEventArgs e)
        {
            filtroTotalExpense();
        }

        private void tbxFilterAmountE_KeyUp(object sender, KeyEventArgs e)
        {
            Boolean valido = true;
            Boolean coma = false;
            for (int i = 0; i < tbxFilterAmountE.Text.Length; i++)
            {
                if (Char.IsLetter(tbxFilterAmountE.Text.ElementAt(i)))
                {
                    valido = false;
                }
                if (!(Char.IsDigit(tbxFilterAmountE.Text.ElementAt(i))))
                {
                    valido = false;
                }
                if ((tbxFilterAmountE.Text.ElementAt(i).Equals(',') || tbxFilterAmountE.Text.ElementAt(i).Equals('.')) && tbxFilterAmountE.Text.Length > 1)
                {
                    valido = true;
                    if (!coma)
                    {
                        coma = true;
                    }
                    else
                    {
                        tbxFilterAmountE.Text = tbxFilterAmountE.Text.Substring(0, tbxFilterAmountE.Text.Length - 1);
                        tbxFilterAmountE.SelectionStart = tbxFilterAmountE.Text.Length;
                    }

                }
            }
            if (valido)
            {
                filtroTotalExpense();
            }
            else
            {
                tbxFilterAmountE.Text = "0";
                filtroTotalExpense();
            }
        }

        private void tbxFilterConceptE_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == '\'';
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NewDebts debts = new NewDebts(idUsuarioLogueado);
            debts.ShowDialog();
            filtroTotalDebts();
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            filtroTotalDebts();
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            filtroTotalDebts();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            filtroTotalDebts();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dtpStartDateD.Value = new DateTime(1970, 01, 01);
            dtpEndDateD.Value = DateTime.Today;
        }

        private void btnCleanDatesE_Click(object sender, EventArgs e)
        {
            dtpRangoInicialE.Value = new DateTime(1970, 01, 01);
            dtpRangoFinalE.Value = DateTime.Today;
        }

        private void tbxFilterAmountE_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valido = false;
            if (Char.IsDigit(e.KeyChar))
            {
                valido = true;
            }
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                if (!tbxFilterAmountI.Text.Contains(","))
                {
                    e.KeyChar = ',';
                    valido = true;
                }

            }
            if (Char.IsControl(e.KeyChar))
            {
                valido = true;
            }
            e.Handled = !valido;
        }

        private void btnCleanDatesP_Click(object sender, EventArgs e)
        {
            dtpStartFilterP.Value = new DateTime(1970, 01, 01);
            dtpEndFilterP.Value = DateTime.Today;
        }

        private void tbxFilterConceptP_Enter(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Equals("Concept..."))
            {
                ((TextBox)sender).Text = "";
                ((TextBox)sender).ForeColor = Color.Black;
            }
        }

        private void tbxFilterConceptP_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Trim().Equals(""))
            {
                ((TextBox)sender).ForeColor = Color.Gray;
                ((TextBox)sender).Text = "Concept...";
            }
        }

        private void tbxFilterConceptP_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == '\'';
        }

        private void tbxFilterAmountP_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valido = false;
            if (Char.IsDigit(e.KeyChar))
            {
                valido = true;
            }
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                if (!tbxFilterAmountI.Text.Contains(","))
                {
                    e.KeyChar = ',';
                    valido = true;
                }

            }
            if (Char.IsControl(e.KeyChar))
            {
                valido = true;
            }
            e.Handled = !valido;
        }

        private void tbxFilterAmountP_Enter(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Equals("Amount..."))
            {
                ((TextBox)sender).Text = "";
                ((TextBox)sender).ForeColor = Color.Black;
            }
        }

        private void tbxFilterAmountP_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Trim().Equals(""))
            {
                ((TextBox)sender).ForeColor = Color.Gray;
                ((TextBox)sender).Text = "Amount...";
            }
        }

        private void tbxFilterAmountP_KeyUp(object sender, KeyEventArgs e)
        {
            Boolean valido = true;
            Boolean coma = false;
            for (int i = 0; i < tbxFilterAmountP.Text.Length; i++)
            {
                if (Char.IsLetter(tbxFilterAmountP.Text.ElementAt(i)))
                {
                    valido = false;
                }
                if (!(Char.IsDigit(tbxFilterAmountP.Text.ElementAt(i))))
                {
                    valido = false;
                }
                if ((tbxFilterAmountP.Text.ElementAt(i).Equals(',') || tbxFilterAmountP.Text.ElementAt(i).Equals('.')) && tbxFilterAmountP.Text.Length > 1)
                {
                    valido = true;
                    if (!coma)
                    {
                        coma = true;
                    }
                    else
                    {
                        tbxFilterAmountP.Text = tbxFilterAmountP.Text.Substring(0, tbxFilterAmountP.Text.Length - 1);
                        tbxFilterAmountP.SelectionStart = tbxFilterAmountP.Text.Length;
                    }

                }
            }
            if (valido)
            {
                filtroTotapPPayment();
            }
            else
            {
                tbxFilterAmountP.Text = "";
                filtroTotapPPayment();
            }
        }

        private void filtrarElementosPPayment(object sender, EventArgs e)
        {
            filtroTotapPPayment();
        }

        private void btnNewPpayment_Click(object sender, EventArgs e)
        {
            NewPendingPayment newPPayment = new NewPendingPayment(idUsuarioLogueado);
            newPPayment.ShowDialog();
            filtroTotapPPayment();
        }

        private void btnCollect_Click(object sender, EventArgs e)
        {
            if (dgvPendingPayment.SelectedRows.Count == 0)
            {
                VentanaPersonalizada vp = new VentanaPersonalizada("Any Row Selected");
                vp.ShowDialog();
            }
            else
            {
                decimal idSelecc = (decimal)dgvPendingPayment.SelectedRows[0].Cells[0].Value;
                if (idSelecc > 0)
                {
                    CollectPendingPayment collectPPayment = new CollectPendingPayment(idSelecc, idUsuarioLogueado);
                    collectPPayment.ShowDialog();
                }
                filtroTotapPPayment();
                filtroTotalIncomes();
            }
        }

        private void tbxConceptD_Enter(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Equals("Concept..."))
            {
                ((TextBox)sender).Text = "";
                ((TextBox)sender).ForeColor = Color.Black;
            }
        }

        private void tbxConceptD_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Trim().Equals(""))
            {
                ((TextBox)sender).ForeColor = Color.Gray;
                ((TextBox)sender).Text = "Concept...";
            }
        }

        private void tbxAmountD_Enter(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Equals("Amount..."))
            {
                ((TextBox)sender).Text = "";
                ((TextBox)sender).ForeColor = Color.Black;
            }
        }

        private void tbxAmountD_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Trim().Equals(""))
            {
                ((TextBox)sender).ForeColor = Color.Gray;
                ((TextBox)sender).Text = "Amount...";
            }
        }

        private void tbxConceptD_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == '\'';
        }

        private void tbxAmountD_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valido = false;
            
            if (Char.IsDigit(e.KeyChar))
            {
                valido = true;
            }
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                if (!tbxFilterAmountI.Text.Contains(","))
                {
                    e.KeyChar = ',';
                    valido = true;
                    
                }

            }
            if (Char.IsControl(e.KeyChar))
            {
                valido = true;
            }
            e.Handled = !valido;
        }

        private void tbxAmountD_KeyUp(object sender, KeyEventArgs e)
        {
            Boolean valido = true;
            Boolean coma = false;
            for (int i = 0; i < tbxAmountD.Text.Length; i++)
            {
                if (Char.IsLetter(tbxAmountD.Text.ElementAt(i)))
                {
                    valido = false;
                }
                if (!(Char.IsDigit(tbxAmountD.Text.ElementAt(i))))
                {
                    valido = false;
                }
                if ((tbxAmountD.Text.ElementAt(i).Equals(',') || tbxAmountD.Text.ElementAt(i).Equals('.')) && tbxAmountD.Text.Length > 1)
                {
                    valido = true;
                    if (!coma)
                    {                   
                        coma = true;
                    }else
                    {                       
                        tbxAmountD.Text = tbxAmountD.Text.Substring(0, tbxAmountD.Text.Length - 1);
                        tbxAmountD.SelectionStart = tbxAmountD.Text.Length;
                    }
                    
                }
                //if ((tbxAmountD.Text.ElementAt(i).Equals(',') || tbxAmountD.Text.ElementAt(i).Equals('.')) && coma && tbxAmountD.Text.Length > 1)
                //{
                //    valido = true;
                //    coma = true;
                //    tbxAmountD.Text = tbxAmountD.Text.Substring(0, tbxAmountD.Text.Length - 1);
                //}
            }
            if (valido)
            {
                filtroTotalDebts();
            }
            else
            {
                tbxAmountD.Text = "";
                filtroTotalDebts();
            }
        }

        private void tbxConceptD_KeyUp(object sender, KeyEventArgs e)
        {
            filtroTotalDebts();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (dgvDebts.SelectedRows.Count == 0)
            {
                VentanaPersonalizada vp = new VentanaPersonalizada("Any Row Selected");
                vp.ShowDialog();
            }
            else
            {
                decimal idSelecc = (decimal)dgvDebts.SelectedRows[0].Cells[0].Value;
                if (idSelecc > 0)
                {
                    PayDebts pDebt = new PayDebts(idSelecc, idUsuarioLogueado);
                    pDebt.ShowDialog();
                }
                filtroTotalDebts();
                filtroTotalExpense();
            }
        }

        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                bool NoBorrado = orders.gestorOrder.comprobarPedidoEliminado(Convert.ToDecimal(Convert.ToString(dgvOrders.Rows[e.RowIndex].Cells[10].Value)));
                if (NoBorrado)
                {
                    int[] permisos = new int[4];
                    usuario.idUser = Convert.ToInt32(idUsuarioLogueado);
                    permisos = usuario.gestorusuario.comprobarPermisosOrders(usuario, permisos);

                    decimal statusRow = statusRow = orders.gestorOrder.getstatus(Convert.ToDecimal(Convert.ToString(dgvOrders.Rows[e.RowIndex].Cells[10].Value)));


                    switch (e.ColumnIndex)
                    {
                        case 4:
                            if (permisos[0] == 1) //Controlo que usuario tenga permisos para Confirmar
                            {
                                if (statusRow == 0)
                                {


                                    if (Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells[2].Value) == 0) //Caja porque total del pedido pagado
                                    {

                                        incomes.gestorIncome.newIncome(new Dominio.Income(0, DateTime.Today, (decimal)idUsuarioLogueado, 0, 0, "Nº Order" + dgvOrders.Rows[e.RowIndex].Cells[10].Value, Convert.ToDecimal(dgvOrders.Rows[e.RowIndex].Cells[3].Value)));

                                        //Cambiar status y color
                                        orders.gestorOrder.putstatus(Convert.ToDecimal(dgvOrders.Rows[e.RowIndex].Cells[10].Value), 1);
                                        dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                                        dgv.ClearSelection();

                                        //Recargo incomes
                                        incomes.gestorIncome.readIncomes("", "", 0, null, null, -1, -1);
                                        dgvIncomes.DataSource = incomes.gestorIncome.tIncomes;


                                    }
                                    else if (Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells[1].Value) == 0 && !(dgvOrders.Rows[e.RowIndex].Cells[9].Value.Equals("Cash on Delivery"))) //Nada pagado y NO es contrarrembolso
                                    {
                                        //pendingPayments.gestorPendingPayments.newPendingPayment(new Dominio.PendingPayments(0, DateTime.Today, (decimal)idUsuarioLogueado, 1, "Nº Order" + dgvOrders.Rows[e.RowIndex].Cells[10].Value, Convert.ToDecimal(dgvOrders.Rows[e.RowIndex].Cells[3].Value), 0));

                                        ////Cambiar status y color
                                        //orders.gestorOrder.putstatus(Convert.ToDecimal(dgvOrders.Rows[e.RowIndex].Cells[10].Value), 1);
                                        //dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                                        //dgv.ClearSelection();

                                        ////Recargo Pendiente de Pago.
                                        //pendingPayments.gestorPendingPayments.readPendingPayments("", "", 0, null, null, -1);
                                        //dgvPendingPayment.DataSource = pendingPayments.gestorPendingPayments.tPPayments;
                                        VentanaPersonalizada vp = new VentanaPersonalizada("Cant do the action.");
                                        vp.ShowDialog();
                                    }
                                    else if (Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells[1].Value) == 0 && (dgvOrders.Rows[e.RowIndex].Cells[9].Value.Equals("Cash on Delivery"))) //Nada pagado y SI es contrarrembolso
                                    {
                                        pendingPayments.gestorPendingPayments.newPendingPayment(new Dominio.PendingPayments(0, DateTime.Today, (decimal)idUsuarioLogueado, 0, "Nº Order" + dgvOrders.Rows[e.RowIndex].Cells[10].Value, Convert.ToDecimal(dgvOrders.Rows[e.RowIndex].Cells[3].Value), 0));

                                        //Cambiar status y color
                                        orders.gestorOrder.putstatus(Convert.ToDecimal(dgvOrders.Rows[e.RowIndex].Cells[10].Value), 1);
                                        dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                                        dgv.ClearSelection();

                                        //Recargo Pendiente de Pago.
                                        pendingPayments.gestorPendingPayments.readPendingPayments("", "", 0, null, null, -1);
                                        dgvPendingPayment.DataSource = pendingPayments.gestorPendingPayments.tPPayments;
                                    }
                                    else if (Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells[1].Value) != 0 && Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells[2].Value) != 0) //Pagado Parcialmente
                                    {
                                        incomes.gestorIncome.newIncome(new Dominio.Income(0, DateTime.Today, (decimal)idUsuarioLogueado, 0, 0, "Nº Order" + dgvOrders.Rows[e.RowIndex].Cells[10].Value, Convert.ToDecimal(dgvOrders.Rows[e.RowIndex].Cells[1].Value)));

                                        //Recargo incomes
                                        incomes.gestorIncome.readIncomes("", "", 0, null, null, -1, -1);
                                        dgvIncomes.DataSource = incomes.gestorIncome.tIncomes;

                                        if (dgvOrders.Rows[e.RowIndex].Cells[9].Value.Equals("Cash on Delivery"))
                                        {
                                            pendingPayments.gestorPendingPayments.newPendingPayment(new Dominio.PendingPayments(0, DateTime.Today, (decimal)idUsuarioLogueado, 0, "Nº Order" + dgvOrders.Rows[e.RowIndex].Cells[10].Value, Convert.ToDecimal(dgvOrders.Rows[e.RowIndex].Cells[2].Value), 0));
                                        }
                                        else
                                        {
                                            pendingPayments.gestorPendingPayments.newPendingPayment(new Dominio.PendingPayments(0, DateTime.Today, (decimal)idUsuarioLogueado, 1, "Nº Order" + dgvOrders.Rows[e.RowIndex].Cells[10].Value, Convert.ToDecimal(dgvOrders.Rows[e.RowIndex].Cells[2].Value), 0));
                                        }

                                        //Recargo Pendiente de Pago.
                                        pendingPayments.gestorPendingPayments.readPendingPayments("", "", 0, null, null, -1);
                                        dgvPendingPayment.DataSource = pendingPayments.gestorPendingPayments.tPPayments;

                                        //Cambiar status y color
                                        orders.gestorOrder.putstatus(Convert.ToDecimal(dgvOrders.Rows[e.RowIndex].Cells[10].Value), 1);
                                        dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                                        dgv.ClearSelection();

                                    }
                                    else
                                    {
                                        VentanaPersonalizada vp = new VentanaPersonalizada("Cant do this action.");
                                        vp.ShowDialog();
                                    }

                                }// else if (statusRow == 1)  --> ESTO ES QUE TENGA QUE ANULARLO EL OFICINISTA
                                 //{
                                 //    orders.gestorOrder.putstatus(Convert.ToDecimal(dgvOrders.Rows[e.RowIndex].Cells[10].Value), 0);

                                //    dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                                //    dgv.ClearSelection();
                                //} 
                                else if (statusRow > 1)
                                {
                                    VentanaPersonalizada vp = new VentanaPersonalizada("Cant desconfirm the product.");
                                    vp.ShowDialog();
                                }
                                else
                                {
                                    VentanaPersonalizada vp = new VentanaPersonalizada("Cant do this action.");
                                    vp.ShowDialog();
                                }
                            }
                            else
                            {
                                VentanaPersonalizada vp = new VentanaPersonalizada("You no have permissions to this action.");
                                vp.ShowDialog();
                            }

                            break;
                        case 5:
                            if (permisos[1] == 1) //Controlo que usuario tenga permisos para Etiquetar
                            {
                                if (statusRow == 1)
                                {
                                    //Cambiar status y color
                                    orders.gestorOrder.putstatus(Convert.ToDecimal(dgvOrders.Rows[e.RowIndex].Cells[10].Value), 2);
                                    dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                                    dgv.ClearSelection();

                                }
                                else if (statusRow == 2)
                                {
                                    //Cambiar status y color
                                    orders.gestorOrder.putstatus(Convert.ToDecimal(dgvOrders.Rows[e.RowIndex].Cells[10].Value), 1);
                                    dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                                    dgv.ClearSelection();
                                }
                                else if (statusRow > 2)
                                {
                                    VentanaPersonalizada vp = new VentanaPersonalizada("Cant Label the product.");
                                    vp.ShowDialog();
                                }
                                else
                                {
                                    VentanaPersonalizada vp = new VentanaPersonalizada("Cant do this action.");
                                    vp.ShowDialog();
                                }
                            }
                            else
                            {
                                VentanaPersonalizada vp = new VentanaPersonalizada("You no have permissions to this action.");
                                vp.ShowDialog();
                            }

                            break;
                        case 6:
                            if (permisos[2] == 1) //Controlo que usuario tenga permisos para Enviar
                            {
                                if (statusRow == 2)
                                {

                                    //SENTENCIA ACTUALIZAR --> UPDATE PRODUCTS P SET P.STOCK=(
                                    //SELECT(P.STOCK - O.AMOUNT)
                                    //FROM ORDERSPRODUCTS O
                                    //WHERE P.IDPRODUCT = O.REFPRODUCT AND O.REFORDER = 9);

                                    bool posible = orders.gestorOrder.restarStock(Convert.ToDecimal(dgvOrders.Rows[e.RowIndex].Cells[10].Value));

                                    if (posible)
                                    {
                                        //Cambiar status y color
                                        orders.gestorOrder.putstatus(Convert.ToDecimal(dgvOrders.Rows[e.RowIndex].Cells[10].Value), 3);
                                        dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                                        dgv.ClearSelection();

                                        //Recargo Tabla Productos
                                        cargarTablaProductos(" PR.DELETED=0");
                                    }
                                    else
                                    {
                                        VentanaPersonalizada vp = new VentanaPersonalizada("Cant do this action. There are not enough Stocks.");
                                        vp.ShowDialog();
                                    }


                                }
                                else if (statusRow == 3)
                                {

                                    orders.gestorOrder.sumarStock(Convert.ToDecimal(dgvOrders.Rows[e.RowIndex].Cells[10].Value));

                                    //Cambiar status y color
                                    orders.gestorOrder.putstatus(Convert.ToDecimal(dgvOrders.Rows[e.RowIndex].Cells[10].Value), 2);
                                    dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                                    dgv.ClearSelection();
                                }
                                else if (statusRow > 3)
                                {
                                    VentanaPersonalizada vp = new VentanaPersonalizada("Cant Sent the product.");
                                    vp.ShowDialog();
                                }
                                else
                                {
                                    VentanaPersonalizada vp = new VentanaPersonalizada("Cant do this action.");
                                    vp.ShowDialog();
                                }
                            }
                            else
                            {
                                VentanaPersonalizada vp = new VentanaPersonalizada("You no have permissions to this action.");
                                vp.ShowDialog();
                            }

                            break;
                        case 7:
                            if (permisos[3] == 1) //Controlo que usuario tenga permisos para Facturar
                            {

                                if (statusRow == 3)
                                {
                                    //Pongo Estado y Cambio color
                                    orders.gestorOrder.putstatus(Convert.ToDecimal(dgvOrders.Rows[e.RowIndex].Cells[10].Value), 4);
                                    dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                                    dgv.ClearSelection();

                                    //Se ha facturado
                                    decimal numgenerado=invoice.gestor.generateInvoice(Convert.ToDecimal(dgvOrders.Rows[e.RowIndex].Cells[10].Value));
                                    PrintInvoice informe = new PrintInvoice(invoice.gestor.getIdInvoice(numgenerado));
                                    informe.Show();
                                }
                                else if (statusRow == 4)
                                {
                                    //Una vez pedido es facturado, no se puede desfacturar.
                                    VentanaPersonalizada vp = new VentanaPersonalizada("The order has been invoiced, \n you can not perform the action.");
                                    vp.ShowDialog();
                                }
                                else
                                {
                                    VentanaPersonalizada vp = new VentanaPersonalizada("Cant do this action.");
                                    vp.ShowDialog();
                                }
                            }
                            else
                            {
                                VentanaPersonalizada vp = new VentanaPersonalizada("You no have permissions to this action.");
                                vp.ShowDialog();
                            }



                            break;
                    }
                }
            } else
            {
                VentanaPersonalizada vp = new VentanaPersonalizada("Cant do this action.");
                vp.ShowDialog();
            }
            
        }

        private void btnEditOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 1)
            {
                decimal status = orders.gestorOrder.getstatus(Convert.ToDecimal(dgvOrders.SelectedRows[0].Cells[10].Value));
                if (status > 0)
                {
                    VentanaPersonalizada vp = new VentanaPersonalizada("Cant do this action.");
                    vp.ShowDialog();
                } else
                {
                    Presentacion.Orders.NewOrder dialogNewOrder = new Presentacion.Orders.NewOrder(idUsuarioLogueado, dgvOrders.SelectedRows[0].Cells[10].Value.ToString());
                    dialogNewOrder.ShowDialog();
                    txtSearchOrder.Text = "";
                    cargarTablaOrders("");
                }

            }
            
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (ckbDeletedOrder.CheckState == CheckState.Checked)
            {
                eliminadoOrders = 1;
                btnDeleteOrder.Enabled = false;
                btnDeleteOrder.BackColor = Color.DarkOrange;

                btnResOrders.Enabled = true;
                btnResOrders.BackColor = Color.Black;
            }
            else
            {
                eliminadoOrders = 0;
                btnDeleteOrder.Enabled = true;
                btnDeleteOrder.BackColor = Color.Black;

                btnResOrders.Enabled = false;
                btnResOrders.BackColor = Color.DarkOrange;

            }

            //Filtrar tabla Order
            cargarTablaOrders("");
            dgvOrders.ClearSelection();
                
        }

        private void btnResOrders_Click(object sender, EventArgs e)
        {
            if (filaOrders >= 0)
            {
                try
                {
                    string id = ((decimal)dgvOrders.Rows[filaOrders].Cells[10].Value).ToString();
                    RestoreOrder dlg = new RestoreOrder();
                    dlg.ShowDialog();
                    if (dlg.Acept)
                    {
                        orders.gestorOrder.restaurar(id);
                        MessageBox.Show("Restored successfully");
                        cargarTablaOrders("");
                        ERP.Persistencia.Logs.write("Order " + id + " restored");
                    }
                }catch(ArgumentOutOfRangeException) {
                    MessageBox.Show("You haven't choose an order, or it can't be restored");
                }

            }
            else
            {
                MessageBox.Show("You haven't choose an order, or it can't be restored");
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            NewInvoice ni = new NewInvoice();
            ni.ShowDialog();
            cargarInvoices();
        }

        private void btn_MouseEnterStyle(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.White;
            ((Button)sender).ForeColor = Color.Black;
        }

        private void btn_MouseLeaveStyle(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Black;
            ((Button)sender).ForeColor = Color.White;
        }


        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {

            decimal idInvoice = invoice.gestor.getIdInvoice(Convert.ToDecimal(dgvInvoices.SelectedRows[0].Cells[0].Value));
            PrintInvoice invoicePrinted = new PrintInvoice(idInvoice);
            invoicePrinted.Show();
        }

            //SELECT PARA LA FACTURA USANDO UNION
/*            SELECT P.NAME DESCR, SUM(OP.AMOUNT)AMO, OP.PRICESALE PRIC
    FROM ORDERSPRODUCTS OP INNER JOIN PRODUCTS P ON OP.REFPRODUCT = P.IDPRODUCT
        INNER JOIN ORDERS_INVOICES OI ON OP.REFORDER = OI.IDORDER
    WHERE OI.IDINVOICE = 3
    GROUP BY P.NAME, OP.PRICESALE
UNION
SELECT LI.DESCRIPTION DESCR, LI.AMOUNT AMO, LI.PRICE PRIC
    FROM LINES_INVOICE LI
    WHERE LI.REFINVOICE = 3
UNION
SELECT P.NAME DESCR, PI.AMOUNT AMO, PI.PRICESALE PRIC
    FROM PRODUCTS_INVOICES PI INNER JOIN PRODUCTS P ON PI.IDPRODUCT = P.IDPRODUCT
    WHERE PI.IDINVOICE = 3;*/

        private void dgvInvoices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex>=0)
            {
                if (dgvInvoices.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Green)
                {
                    new VentanaPersonalizada("Can't un-post this invoice, \nplease post it now.").Show();
                } else if (txtPassAccounting.Text == "accounting")
                {
                    invoice.gestor.post(dgvInvoices.Rows[e.RowIndex].Cells[0].Value.ToString());
                    cargarInvoices();
                }
                else
                {
                    new VentanaPersonalizada("The ACCOUNTING password is incorrect!.").Show();
                }
                txtPassAccounting.Text = "";
            }

        }

        private void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            if (dgvInvoices.SelectedRows.Count == 1)
            {
                if (dgvInvoices.SelectedRows[0].Cells[0].Style.BackColor == Color.Green)
                {
                    new VentanaPersonalizada("You cannot delete a posted invoice.").ShowDialog();
                } else
                {
                    DeleteInvoice dlg = new DeleteInvoice();
                    dlg.ShowDialog();
                    if (dlg.Acept)
                    invoice.gestor.delete(dgvInvoices.SelectedRows[0].Cells[0].Value.ToString());
                }
            } else
            {
                new VentanaPersonalizada("Select an invoice first.").ShowDialog();
            }
            cargarInvoices();
        }

        private void btnUpdateInvoice_Click(object sender, EventArgs e)
        {
            if (dgvInvoices.SelectedRows.Count == 1)
            {
                if (dgvInvoices.SelectedRows[0].Cells[0].Style.BackColor == Color.Green)
                {
                    new VentanaPersonalizada("You cannot modify a posted invoice.").ShowDialog();
                }
                else
                {
                    new NewInvoice(dgvInvoices.SelectedRows[0].Cells[0].Value.ToString()).ShowDialog();

                }
            }
            else
            {
                new VentanaPersonalizada("Select an invoice first.").ShowDialog();
            }
            cargarInvoices();
        }



        private DataGridView recargarOrdersConHilo()
        {
            //dgvOr.Columns.Clear();
            DataGridView dgvOr = new DataGridView();

            orders.gestorOrder.leerOrders("", eliminadoOrders);

            DataTable tOrders = orders.gestorOrder.tOrders;

            dgvOr.Columns.Add("DAT", "DAT");
            dgvOr.Columns.Add("PREPAID", "PREPAID");
            dgvOr.Columns.Add("REST", "REST");
            dgvOr.Columns.Add("TOTAL", "TOTAL");
            dgvOr.Columns.Add("", "CONFIRMED");
            dgvOr.Columns.Add("", "LABELED");
            dgvOr.Columns.Add("", "SENT");
            dgvOr.Columns.Add("", "INVOICED");
            dgvOr.Columns.Add("SURNAME", "SURNAME");
            dgvOr.Columns.Add("PAYMETHOD", "PAYMETHOD");
            dgvOr.Columns.Add("ID", "ID");

            int i = 0;
            foreach (DataRow row in tOrders.Rows)
            {
                dgvOr.Rows.Add(row["DAT"], row["PREPAID"], row["REST"], row["TOTAL"], row, row, row, row
                    , row["SURNAME"], row["PAYMETHOD"], row["ID"]);

                dgvOr.Rows[i].Cells[4].Value = "";
                dgvOr.Rows[i].Cells[4].Style.BackColor = Color.Red;

                dgvOr.Rows[i].Cells[5].Value = "";
                dgvOr.Rows[i].Cells[5].Style.BackColor = Color.Red;

                dgvOr.Rows[i].Cells[6].Value = "";
                dgvOr.Rows[i].Cells[6].Style.BackColor = Color.Red;

                dgvOr.Rows[i].Cells[7].Value = "";
                dgvOr.Rows[i].Cells[7].Style.BackColor = Color.Red;

                //decimal statusRow = orders.gestorOrder.getstatus(Convert.ToDecimal(dgvOrders.Rows[i].Cells[10].Value));
                decimal statusRow = orders.gestorOrder.getstatus(Convert.ToDecimal(Convert.ToString(row["ID"])));
                switch (Convert.ToInt32(statusRow))
                {
                    case 1:
                        dgvOr.Rows[i].Cells[4].Style.BackColor = Color.Green;
                        break;
                    case 2:
                        dgvOr.Rows[i].Cells[4].Style.BackColor = Color.Green;
                        dgvOr.Rows[i].Cells[5].Style.BackColor = Color.Green;
                        break;
                    case 3:
                        dgvOr.Rows[i].Cells[4].Style.BackColor = Color.Green;
                        dgvOr.Rows[i].Cells[5].Style.BackColor = Color.Green;
                        dgvOr.Rows[i].Cells[6].Style.BackColor = Color.Green;
                        break;
                    case 4:
                        dgvOr.Rows[i].Cells[4].Style.BackColor = Color.Green;
                        dgvOr.Rows[i].Cells[5].Style.BackColor = Color.Green;
                        dgvOr.Rows[i].Cells[6].Style.BackColor = Color.Green;
                        dgvOr.Rows[i].Cells[7].Style.BackColor = Color.Green;
                        break;
                }
                i++;
            }

            dgvOr.Columns[4].DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dgvOr.Columns[5].DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dgvOr.Columns[6].DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dgvOr.Columns[7].DefaultCellStyle.SelectionBackColor = Color.Transparent;

            //dgvOr.Sort(dgvOrders.Columns[10],ListSortDirection.Descending);
            return dgvOr;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                int fila = dgvOrders.SelectedRows[0].Index;
                Debug.Print("num fila vieja: " + fila);
                int cantidad = dgvOrders.Rows.Count;
                cargarTablaOrders(txtSearchOrder.Text.Equals("Search...") ? "" : txtSearchOrder.Text);
                int cantidadNueva = dgvOrders.Rows.Count;
                if (cantidad > cantidadNueva)
                {
                    fila = fila + cantidad - cantidadNueva;
                }
                else if (cantidad < cantidadNueva)
                {
                    fila = fila + cantidadNueva - cantidad;
                }
                dgvOrders.ClearSelection();
                Debug.Print("num fila nueva: " + fila);
                dgvOrders.Rows[fila].Selected = true;
            } else
            {
                cargarTablaOrders(txtSearchOrder.Text.Equals("Search...") ? "" : txtSearchOrder.Text);
                dgvOrders.ClearSelection();
            }
         
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {


            timer1 = new Timer();
            timer1.Interval = 1000; //se establecen 5 seg
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }
    }
}