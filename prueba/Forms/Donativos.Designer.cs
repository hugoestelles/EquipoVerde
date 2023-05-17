namespace NutriWise
{
    partial class Donativos
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
            this.lblDonacion = new System.Windows.Forms.Label();
            this.lblCredenciales = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnDonacion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDonacion
            // 
            this.lblDonacion.AutoSize = true;
            this.lblDonacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonacion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDonacion.Location = new System.Drawing.Point(370, 27);
            this.lblDonacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDonacion.Name = "lblDonacion";
            this.lblDonacion.Size = new System.Drawing.Size(205, 51);
            this.lblDonacion.TabIndex = 3;
            this.lblDonacion.Text = "Donación";
            // 
            // lblCredenciales
            // 
            this.lblCredenciales.AutoSize = true;
            this.lblCredenciales.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredenciales.ForeColor = System.Drawing.Color.Gold;
            this.lblCredenciales.Location = new System.Drawing.Point(272, 92);
            this.lblCredenciales.Name = "lblCredenciales";
            this.lblCredenciales.Size = new System.Drawing.Size(406, 29);
            this.lblCredenciales.TabIndex = 4;
            this.lblCredenciales.Text = "Porfavor introduzca sus credenciales";
            
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.txtNombre.Location = new System.Drawing.Point(489, 208);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(207, 37);
            this.txtNombre.TabIndex = 5;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNombre.Location = new System.Drawing.Point(297, 208);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(110, 31);
            this.lblNombre.TabIndex = 9;
            this.lblNombre.Text = "Nombre";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCantidad.Location = new System.Drawing.Point(297, 317);
            this.lblCantidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(123, 31);
            this.lblCantidad.TabIndex = 10;
            this.lblCantidad.Text = "Cantidad";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.nudCantidad.Location = new System.Drawing.Point(489, 311);
            this.nudCantidad.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(207, 37);
            this.nudCantidad.TabIndex = 11;
            // 
            // btnDonacion
            // 
            this.btnDonacion.BackColor = System.Drawing.Color.Gold;
            this.btnDonacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDonacion.FlatAppearance.BorderSize = 0;
            this.btnDonacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDonacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDonacion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDonacion.Location = new System.Drawing.Point(379, 419);
            this.btnDonacion.Name = "btnDonacion";
            this.btnDonacion.Size = new System.Drawing.Size(224, 61);
            this.btnDonacion.TabIndex = 12;
            this.btnDonacion.Text = "Donar";
            this.btnDonacion.UseVisualStyleBackColor = false;
            // 
            // Donativos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.Controls.Add(this.btnDonacion);
            this.Controls.Add(this.nudCantidad);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblCredenciales);
            this.Controls.Add(this.lblDonacion);
            this.Name = "Donativos";
            this.Size = new System.Drawing.Size(1001, 570);
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDonacion;
        private System.Windows.Forms.Label lblCredenciales;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Button btnDonacion;
    }
}
