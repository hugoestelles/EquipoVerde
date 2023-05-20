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
            this.btnMailDieta = new System.Windows.Forms.Button();
            this.dia = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dgvDieta.AllowUserToResizeColumns = false;
            this.dgvDieta.AllowUserToResizeRows = false;
            this.dgvDieta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDieta.BackgroundColor = System.Drawing.Color.Khaki;
            this.dgvDieta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDieta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dia,
            this.desayuno,
            this.comida,
            this.cena});
            this.dgvDieta.Location = new System.Drawing.Point(55, 89);
            this.dgvDieta.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDieta.Name = "dgvDieta";
            this.dgvDieta.ReadOnly = true;
            this.dgvDieta.RowHeadersWidth = 51;
            this.dgvDieta.RowTemplate.Height = 24;
            this.dgvDieta.Size = new System.Drawing.Size(592, 344);
            this.dgvDieta.TabIndex = 1;
            // 
            // btnMailDieta
            // 
            this.btnMailDieta.Location = new System.Drawing.Point(665, 221);
            this.btnMailDieta.Name = "btnMailDieta";
            this.btnMailDieta.Size = new System.Drawing.Size(69, 62);
            this.btnMailDieta.TabIndex = 2;
            this.btnMailDieta.Text = "button1";
            this.btnMailDieta.UseVisualStyleBackColor = true;
            // 
            // dia
            // 
            this.dia.FillWeight = 71.06599F;
            this.dia.HeaderText = "";
            this.dia.Name = "dia";
            this.dia.ReadOnly = true;
            // 
            // desayuno
            // 
            this.desayuno.FillWeight = 109.6447F;
            this.desayuno.HeaderText = "Desayuno";
            this.desayuno.Name = "desayuno";
            this.desayuno.ReadOnly = true;
            // 
            // comida
            // 
            this.comida.FillWeight = 109.6447F;
            this.comida.HeaderText = "Comida";
            this.comida.Name = "comida";
            this.comida.ReadOnly = true;
            // 
            // cena
            // 
            this.cena.FillWeight = 109.6447F;
            this.cena.HeaderText = "Cena";
            this.cena.Name = "cena";
            this.cena.ReadOnly = true;
            // 
            // Dieta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.Controls.Add(this.btnMailDieta);
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
        private System.Windows.Forms.Button btnMailDieta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dia;
        private System.Windows.Forms.DataGridViewTextBoxColumn desayuno;
        private System.Windows.Forms.DataGridViewTextBoxColumn comida;
        private System.Windows.Forms.DataGridViewTextBoxColumn cena;
    }
}
