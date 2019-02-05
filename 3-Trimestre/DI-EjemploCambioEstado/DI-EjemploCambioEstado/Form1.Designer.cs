namespace DI_EjemploCambioEstado
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.CampoA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CampoB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CampoA,
            this.Estado1,
            this.Estado2,
            this.CampoB});
            this.dgv1.Location = new System.Drawing.Point(12, 84);
            this.dgv1.Name = "dgv1";
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(555, 242);
            this.dgv1.TabIndex = 0;
            this.dgv1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellClick);
            // 
            // CampoA
            // 
            this.CampoA.HeaderText = "CampoA";
            this.CampoA.Name = "CampoA";
            // 
            // Estado1
            // 
            this.Estado1.HeaderText = "Estado1";
            this.Estado1.Name = "Estado1";
            // 
            // Estado2
            // 
            this.Estado2.HeaderText = "Estado2";
            this.Estado2.Name = "Estado2";
            // 
            // CampoB
            // 
            this.CampoB.HeaderText = "CampoB";
            this.CampoB.Name = "CampoB";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(579, 338);
            this.Controls.Add(this.dgv1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.cl);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CampoA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CampoB;
    }
}

