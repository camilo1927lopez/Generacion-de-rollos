namespace GeneradorArchivosRollos
{
    partial class FrmGenerarPapeleria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGenerarPapeleria));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnAñadir = new System.Windows.Forms.Button();
            this.dgvInfoIngresada = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.usrCantidad = new WinFormsControlLibrary.usrNumeric();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.usrNumeracionFinal = new WinFormsControlLibrary.usrNumeric();
            this.usrNumeracionInicial = new WinFormsControlLibrary.usrNumeric();
            this.usrNroCabida = new WinFormsControlLibrary.usrNumeric();
            this.usrNumRollo = new WinFormsControlLibrary.usrNumeric();
            this.label3 = new System.Windows.Forms.Label();
            this.tbOrdenProduccion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfoIngresada)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 33);
            this.label1.TabIndex = 6;
            this.label1.Text = "Generador Etiquetas Manuales";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnGenerar);
            this.groupBox1.Controls.Add(this.btnAñadir);
            this.groupBox1.Controls.Add(this.dgvInfoIngresada);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.usrCantidad);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.usrNumeracionFinal);
            this.groupBox1.Controls.Add(this.usrNumeracionInicial);
            this.groupBox1.Controls.Add(this.usrNroCabida);
            this.groupBox1.Controls.Add(this.usrNumRollo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbOrdenProduccion);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Candara", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 448);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información a generar:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(295, 413);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 15;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(187, 413);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 14;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnAñadir
            // 
            this.btnAñadir.Location = new System.Drawing.Point(242, 213);
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.Size = new System.Drawing.Size(75, 23);
            this.btnAñadir.TabIndex = 13;
            this.btnAñadir.Text = "Añadir";
            this.btnAñadir.UseVisualStyleBackColor = true;
            this.btnAñadir.Click += new System.EventHandler(this.btnAñadir_Click);
            // 
            // dgvInfoIngresada
            // 
            this.dgvInfoIngresada.AllowUserToAddRows = false;
            this.dgvInfoIngresada.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvInfoIngresada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfoIngresada.Location = new System.Drawing.Point(6, 249);
            this.dgvInfoIngresada.Name = "dgvInfoIngresada";
            this.dgvInfoIngresada.Size = new System.Drawing.Size(544, 152);
            this.dgvInfoIngresada.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(198, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 14);
            this.label7.TabIndex = 11;
            this.label7.Text = "Nro. Cabida:";
            // 
            // usrCantidad
            // 
            this.usrCantidad.DefaultValue = 0F;
            this.usrCantidad.Location = new System.Drawing.Point(278, 171);
            this.usrCantidad.Mascara = "";
            this.usrCantidad.Name = "usrCantidad";
            this.usrCantidad.PermiteDecimales = false;
            this.usrCantidad.Size = new System.Drawing.Size(117, 22);
            this.usrCantidad.TabIndex = 10;
            this.usrCantidad.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(212, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 14);
            this.label6.TabIndex = 9;
            this.label6.Text = "Cantidad:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(171, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "Numeración final:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(164, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "Numeración inicial:";
            // 
            // usrNumeracionFinal
            // 
            this.usrNumeracionFinal.DefaultValue = 0F;
            this.usrNumeracionFinal.Location = new System.Drawing.Point(278, 143);
            this.usrNumeracionFinal.Mascara = "";
            this.usrNumeracionFinal.Name = "usrNumeracionFinal";
            this.usrNumeracionFinal.PermiteDecimales = false;
            this.usrNumeracionFinal.Size = new System.Drawing.Size(117, 22);
            this.usrNumeracionFinal.TabIndex = 6;
            this.usrNumeracionFinal.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // usrNumeracionInicial
            // 
            this.usrNumeracionInicial.DefaultValue = 0F;
            this.usrNumeracionInicial.Location = new System.Drawing.Point(278, 115);
            this.usrNumeracionInicial.Mascara = "";
            this.usrNumeracionInicial.Name = "usrNumeracionInicial";
            this.usrNumeracionInicial.PermiteDecimales = false;
            this.usrNumeracionInicial.Size = new System.Drawing.Size(117, 22);
            this.usrNumeracionInicial.TabIndex = 5;
            this.usrNumeracionInicial.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // usrNroCabida
            // 
            this.usrNroCabida.DefaultValue = 0F;
            this.usrNroCabida.Location = new System.Drawing.Point(278, 87);
            this.usrNroCabida.Mascara = "";
            this.usrNroCabida.Name = "usrNroCabida";
            this.usrNroCabida.PermiteDecimales = false;
            this.usrNroCabida.Size = new System.Drawing.Size(117, 22);
            this.usrNroCabida.TabIndex = 4;
            this.usrNroCabida.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // usrNumRollo
            // 
            this.usrNumRollo.DefaultValue = 0F;
            this.usrNumRollo.Location = new System.Drawing.Point(278, 59);
            this.usrNumRollo.Mascara = "";
            this.usrNumRollo.Name = "usrNumRollo";
            this.usrNumRollo.PermiteDecimales = false;
            this.usrNumRollo.Size = new System.Drawing.Size(117, 22);
            this.usrNumRollo.TabIndex = 3;
            this.usrNumRollo.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Número del rollo:";
            // 
            // tbOrdenProduccion
            // 
            this.tbOrdenProduccion.Location = new System.Drawing.Point(278, 31);
            this.tbOrdenProduccion.Name = "tbOrdenProduccion";
            this.tbOrdenProduccion.Size = new System.Drawing.Size(117, 22);
            this.tbOrdenProduccion.TabIndex = 1;
            this.tbOrdenProduccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbOrdenProduccion_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Número orden de producción:";
            // 
            // FrmGenerarPapeleria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(580, 577);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmGenerarPapeleria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Generar Papelería";
            this.Load += new System.EventHandler(this.FrmGenerarPapeleria_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfoIngresada)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private WinFormsControlLibrary.usrNumeric usrNumRollo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbOrdenProduccion;
        private WinFormsControlLibrary.usrNumeric usrNumeracionFinal;
        private WinFormsControlLibrary.usrNumeric usrNumeracionInicial;
        private WinFormsControlLibrary.usrNumeric usrNroCabida;
        private System.Windows.Forms.Label label7;
        private WinFormsControlLibrary.usrNumeric usrCantidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvInfoIngresada;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnAñadir;
        private System.Windows.Forms.Button btnLimpiar;
    }
}