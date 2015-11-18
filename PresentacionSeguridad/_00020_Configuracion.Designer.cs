namespace PresentacionRecursoHumano
{
    partial class _00020_Configuracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_00020_Configuracion));
            this.nudMinutosAusente = new System.Windows.Forms.NumericUpDown();
            this.nudMinutosTarde = new System.Windows.Forms.NumericUpDown();
            this.nudMinutosLactancia = new System.Windows.Forms.NumericUpDown();
            this.dtpSalidaPorDefecto = new System.Windows.Forms.DateTimePicker();
            this.dtpEntradaPorDefecto = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Menu = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutosAusente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutosTarde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutosLactancia)).BeginInit();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // nudMinutosAusente
            // 
            this.nudMinutosAusente.Location = new System.Drawing.Point(232, 277);
            this.nudMinutosAusente.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudMinutosAusente.Name = "nudMinutosAusente";
            this.nudMinutosAusente.Size = new System.Drawing.Size(100, 23);
            this.nudMinutosAusente.TabIndex = 31;
            // 
            // nudMinutosTarde
            // 
            this.nudMinutosTarde.Location = new System.Drawing.Point(232, 248);
            this.nudMinutosTarde.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudMinutosTarde.Name = "nudMinutosTarde";
            this.nudMinutosTarde.Size = new System.Drawing.Size(100, 23);
            this.nudMinutosTarde.TabIndex = 30;
            // 
            // nudMinutosLactancia
            // 
            this.nudMinutosLactancia.Location = new System.Drawing.Point(232, 157);
            this.nudMinutosLactancia.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudMinutosLactancia.Name = "nudMinutosLactancia";
            this.nudMinutosLactancia.Size = new System.Drawing.Size(100, 23);
            this.nudMinutosLactancia.TabIndex = 29;
            // 
            // dtpSalidaPorDefecto
            // 
            this.dtpSalidaPorDefecto.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpSalidaPorDefecto.Location = new System.Drawing.Point(232, 117);
            this.dtpSalidaPorDefecto.Name = "dtpSalidaPorDefecto";
            this.dtpSalidaPorDefecto.ShowUpDown = true;
            this.dtpSalidaPorDefecto.Size = new System.Drawing.Size(100, 23);
            this.dtpSalidaPorDefecto.TabIndex = 28;
            // 
            // dtpEntradaPorDefecto
            // 
            this.dtpEntradaPorDefecto.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEntradaPorDefecto.Location = new System.Drawing.Point(232, 81);
            this.dtpEntradaPorDefecto.Name = "dtpEntradaPorDefecto";
            this.dtpEntradaPorDefecto.ShowUpDown = true;
            this.dtpEntradaPorDefecto.Size = new System.Drawing.Size(100, 23);
            this.dtpEntradaPorDefecto.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(134, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 15);
            this.label6.TabIndex = 26;
            this.label6.Text = "Minutos de Tolerancia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 25;
            this.label4.Text = "Ausente";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 15);
            this.label5.TabIndex = 24;
            this.label5.Text = "Llegada Tarde";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 15);
            this.label3.TabIndex = 23;
            this.label3.Text = "Minutos Lactancia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Hora de Salida Por Defecto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 15);
            this.label1.TabIndex = 21;
            this.label1.Text = "Hora de Entrada Por Defecto";
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.btnSalir});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(407, 38);
            this.Menu.TabIndex = 32;
            this.Menu.Text = "toolStrip1";
            // 
            // btnGuardar
            // 
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(53, 35);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(33, 35);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // _00020_Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 351);
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.nudMinutosAusente);
            this.Controls.Add(this.nudMinutosTarde);
            this.Controls.Add(this.nudMinutosLactancia);
            this.Controls.Add(this.dtpSalidaPorDefecto);
            this.Controls.Add(this.dtpEntradaPorDefecto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "_00020_Configuracion";
            this.Text = "CONFIGURACION";
            this.Load += new System.EventHandler(this._00020_Configuracion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutosAusente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutosTarde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutosLactancia)).EndInit();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudMinutosAusente;
        private System.Windows.Forms.NumericUpDown nudMinutosTarde;
        private System.Windows.Forms.NumericUpDown nudMinutosLactancia;
        private System.Windows.Forms.DateTimePicker dtpSalidaPorDefecto;
        private System.Windows.Forms.DateTimePicker dtpEntradaPorDefecto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip Menu;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnSalir;
    }
}