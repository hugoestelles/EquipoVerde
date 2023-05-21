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
            this.dia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desayuno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEnviar = new System.Windows.Forms.Button();
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
            this.dgvDieta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDieta.BackgroundColor = System.Drawing.Color.Khaki;
            this.dgvDieta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDieta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dia,
            this.desayuno,
            this.comida,
            this.cena});
            this.dgvDieta.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dgvDieta.Location = new System.Drawing.Point(20, 139);
            this.dgvDieta.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDieta.Name = "dgvDieta";
            this.dgvDieta.ReadOnly = true;
            this.dgvDieta.RowHeadersVisible = false;
            this.dgvDieta.RowHeadersWidth = 51;
            this.dgvDieta.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDieta.RowTemplate.Height = 24;
            this.dgvDieta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDieta.ShowEditingIcon = false;
            this.dgvDieta.Size = new System.Drawing.Size(700, 163);
            this.dgvDieta.TabIndex = 1;
            // 
            // dia
            // 
            this.dia.FillWeight = 71.06599F;
            this.dia.HeaderText = "";
            this.dia.Name = "dia";
            this.dia.ReadOnly = true;
            this.dia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // desayuno
            // 
            this.desayuno.FillWeight = 109.6447F;
            this.desayuno.HeaderText = "Desayuno";
            this.desayuno.Name = "desayuno";
            this.desayuno.ReadOnly = true;
            this.desayuno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // comida
            // 
            this.comida.FillWeight = 109.6447F;
            this.comida.HeaderText = "Comida";
            this.comida.Name = "comida";
            this.comida.ReadOnly = true;
            this.comida.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cena
            // 
            this.cena.FillWeight = 109.6447F;
            this.cena.HeaderText = "Cena";
            this.cena.Name = "cena";
            this.cena.ReadOnly = true;
            this.cena.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.Gold;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.btnEnviar.Image = global::NutriWise.Properties.Resources.enviarCorreo;
            this.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviar.Location = new System.Drawing.Point(295, 384);
            this.btnEnviar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(136, 40);
            this.btnEnviar.TabIndex = 21;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // Dieta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.Controls.Add(this.btnEnviar);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dia;
        private System.Windows.Forms.DataGridViewTextBoxColumn desayuno;
        private System.Windows.Forms.DataGridViewTextBoxColumn comida;
        private System.Windows.Forms.DataGridViewTextBoxColumn cena;
        private System.Windows.Forms.Button btnEnviar;
    }
}
