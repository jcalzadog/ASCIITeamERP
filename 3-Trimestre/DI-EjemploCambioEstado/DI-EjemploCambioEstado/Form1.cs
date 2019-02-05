using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DI_EjemploCambioEstado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Cargo el dgv
            dgv1.RowHeadersVisible = false;
            dgv1.AllowUserToAddRows = false;
            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv1.BackgroundColor = Color.Black;
            //dgv1.Columns[0].Visible = false;

            dgv1.Rows.Add();
            dgv1.Rows.Add();
            cargarInicio();

        }

        private void cargarInicio()
        {
            dgv1.Rows[0].Cells[1].Style.BackColor = Color.Red;
            dgv1.Rows[0].Cells[2].Style.BackColor = Color.Red;
            dgv1.Rows[1].Cells[1].Style.BackColor = Color.Red;
            dgv1.Rows[1].Cells[2].Style.BackColor = Color.Red;
            //dgv1.Columns[1].Selected = false;
            dgv1.Columns[1].DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dgv1.Columns[2].DefaultCellStyle.SelectionBackColor = Color.Transparent;

        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
           
            if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Red)
            {
                dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                dgv.ClearSelection();
            } else if(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Green)
            {
                dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                dgv.ClearSelection();
            }
            
        }

        private void cl(object sender, EventArgs e)
        {
            //dgv1.Rows[0].Selected = true;
            dgv1.ClearSelection();
        }
    }
}
