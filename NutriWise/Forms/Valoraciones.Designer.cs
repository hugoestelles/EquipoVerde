namespace NutriWise
{
    partial class Valoraciones
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
            this.lblAgradecimiento = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.lblAnonimo = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAgradecimiento
            // 
            this.lblAgradecimiento.AutoSize = true;
            this.lblAgradecimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.lblAgradecimiento.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAgradecimiento.Location = new System.Drawing.Point(296, 64);
            this.lblAgradecimiento.Name = "lblAgradecimiento";
            this.lblAgradecimiento.Size = new System.Drawing.Size(387, 31);
            this.lblAgradecimiento.TabIndex = 2;
            this.lblAgradecimiento.Text = "Agradecemos tus opiniones ♥\r\n";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.textBox1.Location = new System.Drawing.Point(143, 110);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(677, 241);
            this.textBox1.TabIndex = 8;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.Gold;
            this.btnEnviar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.btnEnviar.Location = new System.Drawing.Point(413, 459);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(155, 51);
            this.btnEnviar.TabIndex = 9;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = false;
            // 
            // lblAnonimo
            // 
            this.lblAnonimo.AutoSize = true;
            this.lblAnonimo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblAnonimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnonimo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAnonimo.Location = new System.Drawing.Point(350, 354);
            this.lblAnonimo.Name = "lblAnonimo";
            this.lblAnonimo.Size = new System.Drawing.Size(260, 25);
            this.lblAnonimo.TabIndex = 10;
            this.lblAnonimo.Text = "Las opiniones son anonimas";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.numericUpDown1.Location = new System.Drawing.Point(205, 405);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(66, 30);
            this.numericUpDown1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(192, 377);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "estrellas";
            // 
            // Valoraciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.lblAnonimo);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblAgradecimiento);
            this.Name = "Valoraciones";
            this.Size = new System.Drawing.Size(1001, 570);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblAgradecimiento;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label lblAnonimo;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
    }
}
