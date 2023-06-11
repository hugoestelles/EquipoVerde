namespace NutriWise
{
    partial class Ayuda
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
            this.lblAyuda = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pctAyuda = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctAyuda)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAyuda
            // 
            this.lblAyuda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(219)))), ((int)(((byte)(63)))));
            this.lblAyuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAyuda.Location = new System.Drawing.Point(177, 37);
            this.lblAyuda.Name = "lblAyuda";
            this.lblAyuda.Size = new System.Drawing.Size(660, 306);
            this.lblAyuda.TabIndex = 2;
            this.lblAyuda.Text = "Si tiene algún problema contacte \r\ncon el siguiente correo:\r\nnutriwiseinformacion" +
    "@gmail.com\r\n\r\nO llame al número:\r\n696942069";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NutriWise.Properties.Resources.RectangleAyuda1;
            this.pictureBox1.Location = new System.Drawing.Point(97, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(829, 362);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pctAyuda
            // 
            this.pctAyuda.Image = global::NutriWise.Properties.Resources.Atención_al_cliente;
            this.pctAyuda.Location = new System.Drawing.Point(408, 390);
            this.pctAyuda.Name = "pctAyuda";
            this.pctAyuda.Size = new System.Drawing.Size(172, 180);
            this.pctAyuda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctAyuda.TabIndex = 0;
            this.pctAyuda.TabStop = false;
            // 
            // Ayuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.Controls.Add(this.lblAyuda);
            this.Controls.Add(this.pctAyuda);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Ayuda";
            this.Size = new System.Drawing.Size(1001, 570);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctAyuda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctAyuda;
        private System.Windows.Forms.Label lblAyuda;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
