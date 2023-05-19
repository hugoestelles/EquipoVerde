namespace NutriWise
{
    partial class ListaCompra
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
            this.lblListaCompra = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblListaCompra
            // 
            this.lblListaCompra.AutoSize = true;
            this.lblListaCompra.BackColor = System.Drawing.Color.Gold;
            this.lblListaCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaCompra.Location = new System.Drawing.Point(81, 94);
            this.lblListaCompra.Name = "lblListaCompra";
            this.lblListaCompra.Size = new System.Drawing.Size(188, 25);
            this.lblListaCompra.TabIndex = 0;
            this.lblListaCompra.Text = "Lista de la compra";
            // 
            // ListaCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.Controls.Add(this.lblListaCompra);
            this.Name = "ListaCompra";
            this.Size = new System.Drawing.Size(1001, 570);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblListaCompra;
    }
}
