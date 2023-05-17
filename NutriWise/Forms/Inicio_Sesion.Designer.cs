namespace NutriWise
{
    partial class Inicio_Sesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio_Sesion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pctContraseña = new System.Windows.Forms.PictureBox();
            this.lblCrear = new System.Windows.Forms.Label();
            this.lblNoCuenta = new System.Windows.Forms.Label();
            this.btnInicio = new System.Windows.Forms.Button();
            this.lblOlvidado = new System.Windows.Forms.Label();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblCredenciales = new System.Windows.Forms.Label();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.lblInicio = new System.Windows.Forms.Label();
            this.pctCerrar = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctContraseña)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Ivory;
            this.panel1.Controls.Add(this.pctContraseña);
            this.panel1.Controls.Add(this.lblCrear);
            this.panel1.Controls.Add(this.lblNoCuenta);
            this.panel1.Controls.Add(this.btnInicio);
            this.panel1.Controls.Add(this.lblOlvidado);
            this.panel1.Controls.Add(this.txtContraseña);
            this.panel1.Controls.Add(this.lblContraseña);
            this.panel1.Controls.Add(this.txtMail);
            this.panel1.Controls.Add(this.lblMail);
            this.panel1.Controls.Add(this.lblCredenciales);
            this.panel1.Controls.Add(this.lblBienvenido);
            this.panel1.Controls.Add(this.lblInicio);
            this.panel1.Location = new System.Drawing.Point(373, 41);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(518, 570);
            this.panel1.TabIndex = 2;
            // 
            // pctContraseña
            // 
            this.pctContraseña.Image = global::NutriWise.Properties.Resources.ojo;
            this.pctContraseña.Location = new System.Drawing.Point(452, 336);
            this.pctContraseña.Name = "pctContraseña";
            this.pctContraseña.Size = new System.Drawing.Size(43, 41);
            this.pctContraseña.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctContraseña.TabIndex = 14;
            this.pctContraseña.TabStop = false;
            this.pctContraseña.Click += new System.EventHandler(this.pctContraseña_Click);
            // 
            // lblCrear
            // 
            this.lblCrear.AutoSize = true;
            this.lblCrear.BackColor = System.Drawing.Color.Ivory;
            this.lblCrear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrear.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblCrear.Location = new System.Drawing.Point(402, 542);
            this.lblCrear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCrear.Name = "lblCrear";
            this.lblCrear.Size = new System.Drawing.Size(93, 18);
            this.lblCrear.TabIndex = 13;
            this.lblCrear.Text = "Crear cuenta";
            this.lblCrear.Click += new System.EventHandler(this.lblCrear_Click);
            // 
            // lblNoCuenta
            // 
            this.lblNoCuenta.AutoSize = true;
            this.lblNoCuenta.BackColor = System.Drawing.Color.Ivory;
            this.lblNoCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoCuenta.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblNoCuenta.Location = new System.Drawing.Point(32, 542);
            this.lblNoCuenta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNoCuenta.Name = "lblNoCuenta";
            this.lblNoCuenta.Size = new System.Drawing.Size(135, 18);
            this.lblNoCuenta.TabIndex = 12;
            this.lblNoCuenta.Text = "¿No tienes cuenta?";
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.Goldenrod;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnInicio.Location = new System.Drawing.Point(39, 450);
            this.btnInicio.Margin = new System.Windows.Forms.Padding(4);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(435, 58);
            this.btnInicio.TabIndex = 11;
            this.btnInicio.Text = "Iniciar Sesion";
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Sesion_Click);
            // 
            // lblOlvidado
            // 
            this.lblOlvidado.AutoSize = true;
            this.lblOlvidado.BackColor = System.Drawing.Color.Ivory;
            this.lblOlvidado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOlvidado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOlvidado.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblOlvidado.Location = new System.Drawing.Point(273, 385);
            this.lblOlvidado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOlvidado.Name = "lblOlvidado";
            this.lblOlvidado.Size = new System.Drawing.Size(184, 18);
            this.lblOlvidado.TabIndex = 10;
            this.lblOlvidado.Text = "He olvidado mi contraseña";
            this.lblOlvidado.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtContraseña
            // 
            this.txtContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtContraseña.Location = new System.Drawing.Point(38, 336);
            this.txtContraseña.Margin = new System.Windows.Forms.Padding(8);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '♥';
            this.txtContraseña.Size = new System.Drawing.Size(403, 41);
            this.txtContraseña.TabIndex = 9;
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContraseña.Location = new System.Drawing.Point(32, 289);
            this.lblContraseña.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(114, 25);
            this.lblContraseña.TabIndex = 8;
            this.lblContraseña.Text = "Contraseña";
            // 
            // txtMail
            // 
            this.txtMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMail.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtMail.Location = new System.Drawing.Point(36, 208);
            this.txtMail.Margin = new System.Windows.Forms.Padding(8);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(436, 41);
            this.txtMail.TabIndex = 7;
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMail.Location = new System.Drawing.Point(32, 160);
            this.lblMail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(60, 25);
            this.lblMail.TabIndex = 6;
            this.lblMail.Text = "Email";
            // 
            // lblCredenciales
            // 
            this.lblCredenciales.AutoSize = true;
            this.lblCredenciales.BackColor = System.Drawing.Color.Ivory;
            this.lblCredenciales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredenciales.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCredenciales.Location = new System.Drawing.Point(32, 98);
            this.lblCredenciales.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCredenciales.Name = "lblCredenciales";
            this.lblCredenciales.Size = new System.Drawing.Size(253, 18);
            this.lblCredenciales.TabIndex = 5;
            this.lblCredenciales.Text = "Porfavor introduzca sus credenciales";
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.BackColor = System.Drawing.Color.Ivory;
            this.lblBienvenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenido.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblBienvenido.Location = new System.Drawing.Point(32, 81);
            this.lblBienvenido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(80, 18);
            this.lblBienvenido.TabIndex = 4;
            this.lblBienvenido.Text = "Bienvenido";
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Font = new System.Drawing.Font("Mongolian Baiti", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInicio.Location = new System.Drawing.Point(28, 36);
            this.lblInicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(297, 46);
            this.lblInicio.TabIndex = 0;
            this.lblInicio.Text = "Inicio de sesión";
            // 
            // pctCerrar
            // 
            this.pctCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctCerrar.Image = global::NutriWise.Properties.Resources.X;
            this.pctCerrar.Location = new System.Drawing.Point(1178, 9);
            this.pctCerrar.Margin = new System.Windows.Forms.Padding(0);
            this.pctCerrar.Name = "pctCerrar";
            this.pctCerrar.Size = new System.Drawing.Size(71, 71);
            this.pctCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctCerrar.TabIndex = 44;
            this.pctCerrar.TabStop = false;
            this.pctCerrar.Click += new System.EventHandler(this.pctCerrar_Click);
            // 
            // Inicio_Sesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(1258, 657);
            this.Controls.Add(this.pctCerrar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Inicio_Sesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio Sesion";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctContraseña)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctCerrar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label lblOlvidado;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblCredenciales;
        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Label lblCrear;
        private System.Windows.Forms.Label lblNoCuenta;
        private System.Windows.Forms.PictureBox pctContraseña;
        private System.Windows.Forms.PictureBox pctCerrar;
    }
}