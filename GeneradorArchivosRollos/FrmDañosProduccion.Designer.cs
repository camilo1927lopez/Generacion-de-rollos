namespace GeneradorArchivosRollos
{
    partial class FrmDañosProduccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDañosProduccion));
            this.FinalizarOrden = new System.Windows.Forms.Button();
            this.cbxOrden = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.GenerarInforme = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FinalizarOrden
            // 
            this.FinalizarOrden.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinalizarOrden.Location = new System.Drawing.Point(294, 69);
            this.FinalizarOrden.Name = "FinalizarOrden";
            this.FinalizarOrden.Size = new System.Drawing.Size(142, 32);
            this.FinalizarOrden.TabIndex = 25;
            this.FinalizarOrden.Text = "Finalizar Orden";
            this.FinalizarOrden.UseVisualStyleBackColor = true;
            this.FinalizarOrden.Click += new System.EventHandler(this.FinalizarOrden_Click);
            // 
            // cbxOrden
            // 
            this.cbxOrden.FormattingEnabled = true;
            this.cbxOrden.Location = new System.Drawing.Point(168, 21);
            this.cbxOrden.Name = "cbxOrden";
            this.cbxOrden.Size = new System.Drawing.Size(292, 21);
            this.cbxOrden.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Número Orden Producción:";
            // 
            // GenerarInforme
            // 
            this.GenerarInforme.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerarInforme.Location = new System.Drawing.Point(46, 69);
            this.GenerarInforme.Name = "GenerarInforme";
            this.GenerarInforme.Size = new System.Drawing.Size(142, 32);
            this.GenerarInforme.TabIndex = 29;
            this.GenerarInforme.Text = "Generar informe";
            this.GenerarInforme.UseVisualStyleBackColor = true;
            this.GenerarInforme.Click += new System.EventHandler(this.GenerarInforme_Click);
            // 
            // FrmDañosProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 130);
            this.Controls.Add(this.GenerarInforme);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxOrden);
            this.Controls.Add(this.FinalizarOrden);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDañosProduccion";
            this.Text = "Generación daños por produccion";
            this.Load += new System.EventHandler(this.FrmDañosProduccion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FinalizarOrden;
        private System.Windows.Forms.ComboBox cbxOrden;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button GenerarInforme;
    }
}