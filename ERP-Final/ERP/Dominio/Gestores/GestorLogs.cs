using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Dominio.Gestores
{
    class GestorLogs
    {
        public DataTable tabla { get; set; }

        ConnectOracle conector;

        public GestorLogs()
        {
            conector = new ConnectOracle();
            tabla = new DataTable();
        }


        public void cargarTablaLogs(DataGridView dgvLogs,String condicion)
        {
            dgvLogs.Columns.Clear();

            DataSet data = new DataSet();

            if (condicion.Equals(""))
            {
                data = conector.getData("SELECT L.FECHACAMBIO DAT,U.NAME NAM,L.DESCRIPCION DES FROM LOGS L INNER JOIN USERS U ON L.IDUSER = U.IDUSER", "LOGS L INNER JOIN USERS U ON L.IDUSER=U.USERS");
            } else
            {
                data = conector.getData("SELECT L.FECHACAMBIO DAT,U.NAME NAM,L.DESCRIPCION DES FROM LOGS L INNER JOIN USERS U ON L.IDUSER = U.IDUSER WHERE "+condicion, "LOGS L INNER JOIN USERS U ON L.IDUSER=U.USERS");
            }

            DataTable tLogs = data.Tables["LOGS L INNER JOIN USERS U ON L.IDUSER=U.USERS"];

            //dgvCustomers.DataSource = tcustomers;

            dgvLogs.Columns.Add("DAT", "DATE");
            dgvLogs.Columns.Add("NAM", "USER");
            dgvLogs.Columns.Add("DES", "DESCRIPTION");

            foreach (DataRow row in tLogs.Rows)
            {
                dgvLogs.Rows.Add(row["DAT"], row["NAM"], row["DES"]);
            }
            //dgvUsers.ColumnHeadersVisible = false;
            dgvLogs.RowHeadersVisible = false;
            dgvLogs.AllowUserToAddRows = false;
            dgvLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLogs.BackgroundColor = Color.Black;

            ////Colores de Header (no va nose porque)
            //dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(114, 47, 55);
            //dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //No editable
            dgvLogs.ReadOnly = true;
        }
    }
}
