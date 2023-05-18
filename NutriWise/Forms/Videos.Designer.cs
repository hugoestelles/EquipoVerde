
namespace NutriWise.Forms
{
    partial class Videos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pctComidaLactosa = new System.Windows.Forms.PictureBox();
            this.pctComidaVegana = new System.Windows.Forms.PictureBox();
            this.pctComidaSaludable = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctComidaLactosa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctComidaVegana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctComidaSaludable)).BeginInit();
            this.SuspendLayout();
            // 
            // pctComidaLactosa
            // 
            this.pctComidaLactosa.Image = global::NutriWise.Properties.Resources.ComidaSinLactosa;
            this.pctComidaLactosa.Location = new System.Drawing.Point(79, 375);
            this.pctComidaLactosa.Name = "pctComidaLactosa";
            this.pctComidaLactosa.Size = new System.Drawing.Size(878, 192);
            this.pctComidaLactosa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctComidaLactosa.TabIndex = 2;
            this.pctComidaLactosa.TabStop = false;
            // 
            // pctComidaVegana
            // 
            this.pctComidaVegana.Image = global::NutriWise.Properties.Resources.ComidaVegana;
            this.pctComidaVegana.Location = new System.Drawing.Point(79, 184);
            this.pctComidaVegana.Name = "pctComidaVegana";
            this.pctComidaVegana.Size = new System.Drawing.Size(878, 192);
            this.pctComidaVegana.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctComidaVegana.TabIndex = 1;
            this.pctComidaVegana.TabStop = false;
            // 
            // pctComidaSaludable
            // 
            this.pctComidaSaludable.Image = global::NutriWise.Properties.Resources.ComidaSaludable;
            this.pctComidaSaludable.Location = new System.Drawing.Point(79, 0);
            this.pctComidaSaludable.Name = "pctComidaSaludable";
            this.pctComidaSaludable.Size = new System.Drawing.Size(878, 192);
            this.pctComidaSaludable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctComidaSaludable.TabIndex = 0;
            this.pctComidaSaludable.TabStop = false;
            // 
            // Videos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.Controls.Add(this.pctComidaLactosa);
            this.Controls.Add(this.pctComidaVegana);
            this.Controls.Add(this.pctComidaSaludable);
            this.Name = "Videos";
            this.Size = new System.Drawing.Size(1001, 570);
            ((System.ComponentModel.ISupportInitialize)(this.pctComidaLactosa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctComidaVegana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctComidaSaludable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctComidaSaludable;
        private System.Windows.Forms.PictureBox pctComidaVegana;
        private System.Windows.Forms.PictureBox pctComidaLactosa;
    }
}