namespace GeneradorArchivosRollos
{
    partial class FrmPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.usrCantRollosXAnchoPapel = new WinFormsControlLibrary.usrNumeric();
            this.usrCabVertical = new WinFormsControlLibrary.usrNumeric();
            this.chkInvertido = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAnuladoAdicionalXLinea = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.usrCantAnuladosFinal = new WinFormsControlLibrary.usrNumeric();
            this.usrCantAnuladosInicio = new WinFormsControlLibrary.usrNumeric();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.chkLlevaAnuladosFinal = new System.Windows.Forms.CheckBox();
            this.chkLlevaAnuladosInicio = new System.Windows.Forms.CheckBox();
            this.usrSeleccionarArchivo1 = new WinFormsControlLibrary.usrSeleccionarArchivo();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.usrCantAnuladosIntermedio = new WinFormsControlLibrary.usrNumeric();
            this.chkLlevaAnuladosIntermedios = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbOrdenProduccion = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.generarPapeleriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auditoriaDeDañosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auditoriaDeDañosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.generaciónDañosPorProducciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Delimitador = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.FinalesxRollo = new WinFormsControlLibrary.usrNumeric();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FinalesxRollo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.usrCantRollosXAnchoPapel);
            this.groupBox1.Controls.Add(this.usrCabVertical);
            this.groupBox1.Controls.Add(this.chkInvertido);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Candara", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 166);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 247);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurar Cubo";
            // 
            // usrCantRollosXAnchoPapel
            // 
            this.usrCantRollosXAnchoPapel.DefaultValue = 0F;
            this.usrCantRollosXAnchoPapel.Location = new System.Drawing.Point(183, 65);
            this.usrCantRollosXAnchoPapel.Mascara = "";
            this.usrCantRollosXAnchoPapel.Name = "usrCantRollosXAnchoPapel";
            this.usrCantRollosXAnchoPapel.PermiteDecimales = false;
            this.usrCantRollosXAnchoPapel.Size = new System.Drawing.Size(50, 20);
            this.usrCantRollosXAnchoPapel.TabIndex = 14;
            this.usrCantRollosXAnchoPapel.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // usrCabVertical
            // 
            this.usrCabVertical.DefaultValue = 0F;
            this.usrCabVertical.Location = new System.Drawing.Point(183, 37);
            this.usrCabVertical.Mascara = "#,##0";
            this.usrCabVertical.Name = "usrCabVertical";
            this.usrCabVertical.PermiteDecimales = false;
            this.usrCabVertical.Size = new System.Drawing.Size(50, 20);
            this.usrCabVertical.TabIndex = 13;
            this.usrCabVertical.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // chkInvertido
            // 
            this.chkInvertido.AutoSize = true;
            this.chkInvertido.Checked = true;
            this.chkInvertido.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInvertido.Location = new System.Drawing.Point(79, 139);
            this.chkInvertido.Name = "chkInvertido";
            this.chkInvertido.Size = new System.Drawing.Size(115, 18);
            this.chkInvertido.TabIndex = 10;
            this.chkInvertido.Text = "Archivo Invertido";
            this.chkInvertido.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "Cant. Rollos X Ancho Papel:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cabida vertical total:";
            // 
            // tbAnuladoAdicionalXLinea
            // 
            this.tbAnuladoAdicionalXLinea.Location = new System.Drawing.Point(18, 212);
            this.tbAnuladoAdicionalXLinea.Name = "tbAnuladoAdicionalXLinea";
            this.tbAnuladoAdicionalXLinea.Size = new System.Drawing.Size(236, 22);
            this.tbAnuladoAdicionalXLinea.TabIndex = 4;
            this.tbAnuladoAdicionalXLinea.Text = "ANULADO";
            this.tbAnuladoAdicionalXLinea.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAnuladoAdicionalXLinea_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(15, 196);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(239, 14);
            this.label17.TabIndex = 9;
            this.label17.Text = "Anulado adicional por cada línea del archivo:";
            // 
            // usrCantAnuladosFinal
            // 
            this.usrCantAnuladosFinal.DefaultValue = 0F;
            this.usrCantAnuladosFinal.Location = new System.Drawing.Point(147, 98);
            this.usrCantAnuladosFinal.Mascara = "";
            this.usrCantAnuladosFinal.Name = "usrCantAnuladosFinal";
            this.usrCantAnuladosFinal.PermiteDecimales = false;
            this.usrCantAnuladosFinal.Size = new System.Drawing.Size(39, 20);
            this.usrCantAnuladosFinal.TabIndex = 7;
            this.usrCantAnuladosFinal.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // usrCantAnuladosInicio
            // 
            this.usrCantAnuladosInicio.DefaultValue = 0F;
            this.usrCantAnuladosInicio.Location = new System.Drawing.Point(147, 39);
            this.usrCantAnuladosInicio.Mascara = "";
            this.usrCantAnuladosInicio.Name = "usrCantAnuladosInicio";
            this.usrCantAnuladosInicio.PermiteDecimales = false;
            this.usrCantAnuladosInicio.Size = new System.Drawing.Size(39, 20);
            this.usrCantAnuladosInicio.TabIndex = 6;
            this.usrCantAnuladosInicio.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(36, 101);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(107, 14);
            this.label16.TabIndex = 4;
            this.label16.Text = "Cantidad anulados:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(36, 44);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 14);
            this.label15.TabIndex = 3;
            this.label15.Text = "Cantidad anulados:";
            // 
            // chkLlevaAnuladosFinal
            // 
            this.chkLlevaAnuladosFinal.AutoSize = true;
            this.chkLlevaAnuladosFinal.Checked = true;
            this.chkLlevaAnuladosFinal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLlevaAnuladosFinal.Location = new System.Drawing.Point(18, 74);
            this.chkLlevaAnuladosFinal.Name = "chkLlevaAnuladosFinal";
            this.chkLlevaAnuladosFinal.Size = new System.Drawing.Size(141, 18);
            this.chkLlevaAnuladosFinal.TabIndex = 1;
            this.chkLlevaAnuladosFinal.Text = "Lleva anulados al final";
            this.chkLlevaAnuladosFinal.UseVisualStyleBackColor = true;
            // 
            // chkLlevaAnuladosInicio
            // 
            this.chkLlevaAnuladosInicio.AutoSize = true;
            this.chkLlevaAnuladosInicio.Checked = true;
            this.chkLlevaAnuladosInicio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLlevaAnuladosInicio.Location = new System.Drawing.Point(18, 21);
            this.chkLlevaAnuladosInicio.Name = "chkLlevaAnuladosInicio";
            this.chkLlevaAnuladosInicio.Size = new System.Drawing.Size(146, 18);
            this.chkLlevaAnuladosInicio.TabIndex = 0;
            this.chkLlevaAnuladosInicio.Text = "Lleva anulados al inicio";
            this.chkLlevaAnuladosInicio.UseVisualStyleBackColor = true;
            // 
            // usrSeleccionarArchivo1
            // 
            this.usrSeleccionarArchivo1.ArchivoSeleccionado = "";
            this.usrSeleccionarArchivo1.ColorBoton = System.Drawing.SystemColors.ActiveCaption;
            this.usrSeleccionarArchivo1.ColorTextoBoton = System.Drawing.Color.Black;
            this.usrSeleccionarArchivo1.FiltroExtensionPermitida = "archivos de texto|*.txt";
            this.usrSeleccionarArchivo1.Font = new System.Drawing.Font("Candara", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usrSeleccionarArchivo1.IsEnabled = true;
            this.usrSeleccionarArchivo1.Location = new System.Drawing.Point(76, 542);
            this.usrSeleccionarArchivo1.Name = "usrSeleccionarArchivo1";
            this.usrSeleccionarArchivo1.Size = new System.Drawing.Size(424, 34);
            this.usrSeleccionarArchivo1.TabIndex = 0;
            this.usrSeleccionarArchivo1.Titulo = "Cargar Archivo:";
            this.usrSeleccionarArchivo1.Load += new System.EventHandler(this.usrSeleccionarArchivo1_Load);
            // 
            // btnProcesar
            // 
            this.btnProcesar.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcesar.Location = new System.Drawing.Point(238, 594);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(93, 32);
            this.btnProcesar.TabIndex = 1;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.usrCantAnuladosIntermedio);
            this.groupBox3.Controls.Add(this.chkLlevaAnuladosIntermedios);
            this.groupBox3.Controls.Add(this.tbAnuladoAdicionalXLinea);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.usrCantAnuladosFinal);
            this.groupBox3.Controls.Add(this.usrCantAnuladosInicio);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.chkLlevaAnuladosFinal);
            this.groupBox3.Controls.Add(this.chkLlevaAnuladosInicio);
            this.groupBox3.Font = new System.Drawing.Font("Candara", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(297, 166);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(270, 247);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Anulados";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 14);
            this.label6.TabIndex = 12;
            this.label6.Text = "Cantidad anulados:";
            // 
            // usrCantAnuladosIntermedio
            // 
            this.usrCantAnuladosIntermedio.DefaultValue = 0F;
            this.usrCantAnuladosIntermedio.Location = new System.Drawing.Point(147, 158);
            this.usrCantAnuladosIntermedio.Mascara = "";
            this.usrCantAnuladosIntermedio.Name = "usrCantAnuladosIntermedio";
            this.usrCantAnuladosIntermedio.PermiteDecimales = false;
            this.usrCantAnuladosIntermedio.Size = new System.Drawing.Size(39, 20);
            this.usrCantAnuladosIntermedio.TabIndex = 11;
            this.usrCantAnuladosIntermedio.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // chkLlevaAnuladosIntermedios
            // 
            this.chkLlevaAnuladosIntermedios.AutoSize = true;
            this.chkLlevaAnuladosIntermedios.Checked = true;
            this.chkLlevaAnuladosIntermedios.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLlevaAnuladosIntermedios.Location = new System.Drawing.Point(18, 133);
            this.chkLlevaAnuladosIntermedios.Name = "chkLlevaAnuladosIntermedios";
            this.chkLlevaAnuladosIntermedios.Size = new System.Drawing.Size(165, 18);
            this.chkLlevaAnuladosIntermedios.TabIndex = 10;
            this.chkLlevaAnuladosIntermedios.Text = "Lleva anulados entre rollos";
            this.chkLlevaAnuladosIntermedios.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(23, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(321, 33);
            this.label2.TabIndex = 5;
            this.label2.Text = "Generador Archivos Rollos";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Candara", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(29, 89);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(42, 13);
            this.lblVersion.TabIndex = 6;
            this.lblVersion.Text = "Versión";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 441);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Número Orden de producción:";
            // 
            // tbOrdenProduccion
            // 
            this.tbOrdenProduccion.Location = new System.Drawing.Point(274, 438);
            this.tbOrdenProduccion.Name = "tbOrdenProduccion";
            this.tbOrdenProduccion.Size = new System.Drawing.Size(176, 20);
            this.tbOrdenProduccion.TabIndex = 8;
            this.tbOrdenProduccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbOrdenProduccion_KeyPress);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generarPapeleriaToolStripMenuItem,
            this.auditoriaDeDañosToolStripMenuItem,
            this.auditoriaDeDañosToolStripMenuItem1,
            this.generaciónDañosPorProducciónToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(580, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // generarPapeleriaToolStripMenuItem
            // 
            this.generarPapeleriaToolStripMenuItem.Name = "generarPapeleriaToolStripMenuItem";
            this.generarPapeleriaToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.generarPapeleriaToolStripMenuItem.Text = "Generar Papelería";
            this.generarPapeleriaToolStripMenuItem.Click += new System.EventHandler(this.generarPapeleriaToolStripMenuItem_Click);
            // 
            // auditoriaDeDañosToolStripMenuItem
            // 
            this.auditoriaDeDañosToolStripMenuItem.Name = "auditoriaDeDañosToolStripMenuItem";
            this.auditoriaDeDañosToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // auditoriaDeDañosToolStripMenuItem1
            // 
            this.auditoriaDeDañosToolStripMenuItem1.Name = "auditoriaDeDañosToolStripMenuItem1";
            this.auditoriaDeDañosToolStripMenuItem1.Size = new System.Drawing.Size(119, 20);
            this.auditoriaDeDañosToolStripMenuItem1.Text = "Auditoria de daños";
            this.auditoriaDeDañosToolStripMenuItem1.Click += new System.EventHandler(this.auditoriaDeDañosToolStripMenuItem1_Click);
            // 
            // generaciónDañosPorProducciónToolStripMenuItem
            // 
            this.generaciónDañosPorProducciónToolStripMenuItem.Name = "generaciónDañosPorProducciónToolStripMenuItem";
            this.generaciónDañosPorProducciónToolStripMenuItem.Size = new System.Drawing.Size(199, 20);
            this.generaciónDañosPorProducciónToolStripMenuItem.Text = "Generación daños por producción";
            this.generaciónDañosPorProducciónToolStripMenuItem.Click += new System.EventHandler(this.generaciónDañosPorProducciónToolStripMenuItem_Click);
            // 
            // Delimitador
            // 
            this.Delimitador.Location = new System.Drawing.Point(274, 485);
            this.Delimitador.Name = "Delimitador";
            this.Delimitador.Size = new System.Drawing.Size(176, 20);
            this.Delimitador.TabIndex = 10;
            this.Delimitador.Text = ",";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(206, 488);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Delimitador:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(391, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(177, 86);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // FinalesxRollo
            // 
            this.FinalesxRollo.DefaultValue = 0F;
            this.FinalesxRollo.Location = new System.Drawing.Point(183, 100);
            this.FinalesxRollo.Mascara = "";
            this.FinalesxRollo.Name = "FinalesxRollo";
            this.FinalesxRollo.PermiteDecimales = false;
            this.FinalesxRollo.Size = new System.Drawing.Size(50, 22);
            this.FinalesxRollo.TabIndex = 16;
            this.FinalesxRollo.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 14);
            this.label7.TabIndex = 15;
            this.label7.Text = "Cant Adhesivos Finales x Rollo:";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(580, 638);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Delimitador);
            this.Controls.Add(this.tbOrdenProduccion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.usrSeleccionarArchivo1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generador de archivos impresión para Rollos";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkInvertido;
        private System.Windows.Forms.CheckBox chkLlevaAnuladosFinal;
        private System.Windows.Forms.CheckBox chkLlevaAnuladosInicio;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private WinFormsControlLibrary.usrNumeric usrCabVertical;
        private WinFormsControlLibrary.usrNumeric usrCantRollosXAnchoPapel;
        private WinFormsControlLibrary.usrNumeric usrCantAnuladosFinal;
        private WinFormsControlLibrary.usrNumeric usrCantAnuladosInicio;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbAnuladoAdicionalXLinea;
        private WinFormsControlLibrary.usrSeleccionarArchivo usrSeleccionarArchivo1;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbOrdenProduccion;
        private System.Windows.Forms.Label label6;
        private WinFormsControlLibrary.usrNumeric usrCantAnuladosIntermedio;
        private System.Windows.Forms.CheckBox chkLlevaAnuladosIntermedios;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem generarPapeleriaToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox Delimitador;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem auditoriaDeDañosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem auditoriaDeDañosToolStripMenuItem1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem generaciónDañosPorProducciónToolStripMenuItem;
        private WinFormsControlLibrary.usrNumeric FinalesxRollo;
        private System.Windows.Forms.Label label7;
    }
}

