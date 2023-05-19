namespace NutriWise
{
    partial class Dieta
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDieta = new System.Windows.Forms.DataGridView();
            this.desayuno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDieta)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(583, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "En volumen e intolerante a la lactosa";
            // 
            // dgvDieta
            // 
            this.dgvDieta.AllowUserToAddRows = false;
            this.dgvDieta.AllowUserToDeleteRows = false;
            this.dgvDieta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDieta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDieta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.desayuno,
            this.comida,
            this.cena});
            this.dgvDieta.Location = new System.Drawing.Point(81, 123);
            this.dgvDieta.Name = "dgvDieta";
            this.dgvDieta.ReadOnly = true;
            this.dgvDieta.Size = new System.Drawing.Size(576, 247);
            this.dgvDieta.TabIndex = 1;
            // 
            // desayuno
            // 
            this.desayuno.HeaderText = "Desayuno";
            this.desayuno.Name = "desayuno";
            this.desayuno.ReadOnly = true;
            // 
            // comida
            // 
            this.comida.HeaderText = "Comida";
            this.comida.Name = "comida";
            this.comida.ReadOnly = true;
            // 
            // cena
            // 
            this.cena.HeaderText = "Cena";
            this.cena.Name = "cena";
            this.cena.ReadOnly = true;
            // 
            // Dieta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.Controls.Add(this.dgvDieta);
            this.Controls.Add(this.label1);
            this.Name = "Dieta";
            this.Size = new System.Drawing.Size(751, 463);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDieta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDieta;
        private System.Windows.Forms.DataGridViewTextBoxColumn desayuno;
        private System.Windows.Forms.DataGridViewTextBoxColumn comida;
        private System.Windows.Forms.DataGridViewTextBoxColumn cena;
    }
}
