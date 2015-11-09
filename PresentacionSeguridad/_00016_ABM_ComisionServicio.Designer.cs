namespace PresentacionRecursoHumano
{
    partial class _00016_ABM_ComisionServicio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_00016_ABM_ComisionServicio));
            this.dgvGrilla = new PresentacionBase.Clases.Control.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDNI = new System.Windows.Forms.Label();
            this.lblApyNom = new System.Windows.Forms.Label();
            this.lblLegajo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Menu = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chkJornadaCompleta = new System.Windows.Forms.CheckBox();
            this.dtpHoraFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.chkFechaHasta = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.Menu.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvGrilla.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGrilla.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dgvGrilla.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrilla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGrilla.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGrilla.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvGrilla.Location = new System.Drawing.Point(0, 232);
            this.dgvGrilla.MultiSelect = false;
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.RowHeadersVisible = false;
            this.dgvGrilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrilla.Size = new System.Drawing.Size(824, 260);
            this.dgvGrilla.TabIndex = 12;
            this.dgvGrilla.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrilla_RowEnter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDNI);
            this.groupBox1.Controls.Add(this.lblApyNom);
            this.groupBox1.Controls.Add(this.lblLegajo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(805, 46);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDNI.Location = new System.Drawing.Point(687, 13);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(110, 25);
            this.lblDNI.TabIndex = 14;
            this.lblDNI.Text = "35.000.000";
            // 
            // lblApyNom
            // 
            this.lblApyNom.AutoSize = true;
            this.lblApyNom.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApyNom.Location = new System.Drawing.Point(119, 13);
            this.lblApyNom.Name = "lblApyNom";
            this.lblApyNom.Size = new System.Drawing.Size(108, 25);
            this.lblApyNom.TabIndex = 13;
            this.lblApyNom.Text = "Pérez, Juan";
            // 
            // lblLegajo
            // 
            this.lblLegajo.AutoSize = true;
            this.lblLegajo.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLegajo.Location = new System.Drawing.Point(555, 13);
            this.lblLegajo.Name = "lblLegajo";
            this.lblLegajo.Size = new System.Drawing.Size(64, 25);
            this.lblLegajo.TabIndex = 12;
            this.lblLegajo.Text = "12345";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(654, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "DNI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Apellido y Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(507, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Legajo";
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Menu.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.btnSalir});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(824, 47);
            this.Menu.TabIndex = 23;
            this.Menu.Text = "toolStrip1";
            // 
            // btnGuardar
            // 
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(53, 44);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGuardar.ToolTipText = "Crear una nueva comisión de servicio";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(33, 44);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Location = new System.Drawing.Point(731, 119);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(84, 48);
            this.btnAgregar.TabIndex = 31;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(443, 119);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(282, 105);
            this.txtObservaciones.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 15);
            this.label6.TabIndex = 40;
            this.label6.Text = "Descripción";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(440, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 15);
            this.label8.TabIndex = 45;
            this.label8.Text = "Observaciones";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(12, 119);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(425, 23);
            this.txtDescripcion.TabIndex = 46;
            // 
            // btnEliminar
            // 
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Location = new System.Drawing.Point(731, 176);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(84, 48);
            this.btnEliminar.TabIndex = 42;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkJornadaCompleta);
            this.groupBox6.Controls.Add(this.dtpHoraFin);
            this.groupBox6.Controls.Add(this.dtpFechaHasta);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.dtpHoraInicio);
            this.groupBox6.Controls.Add(this.dtpFechaDesde);
            this.groupBox6.Controls.Add(this.chkFechaHasta);
            this.groupBox6.Location = new System.Drawing.Point(12, 148);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(425, 76);
            this.groupBox6.TabIndex = 48;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Duración";
            // 
            // chkJornadaCompleta
            // 
            this.chkJornadaCompleta.AutoSize = true;
            this.chkJornadaCompleta.Location = new System.Drawing.Point(300, 19);
            this.chkJornadaCompleta.Name = "chkJornadaCompleta";
            this.chkJornadaCompleta.Size = new System.Drawing.Size(122, 19);
            this.chkJornadaCompleta.TabIndex = 52;
            this.chkJornadaCompleta.Text = "Jornada Completa";
            this.chkJornadaCompleta.UseVisualStyleBackColor = true;
            // 
            // dtpHoraFin
            // 
            this.dtpHoraFin.CustomFormat = "HH:mm";
            this.dtpHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraFin.Location = new System.Drawing.Point(228, 44);
            this.dtpHoraFin.Name = "dtpHoraFin";
            this.dtpHoraFin.ShowUpDown = true;
            this.dtpHoraFin.Size = new System.Drawing.Size(60, 23);
            this.dtpHoraFin.TabIndex = 55;
            this.dtpHoraFin.ValueChanged += new System.EventHandler(this.dtpHoraFin_ValueChanged);
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Enabled = false;
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(69, 44);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(95, 23);
            this.dtpFechaHasta.TabIndex = 33;
            this.dtpFechaHasta.ValueChanged += new System.EventHandler(this.dtpFechaHasta_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(175, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 15);
            this.label11.TabIndex = 53;
            this.label11.Text = "Entrada";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 15);
            this.label10.TabIndex = 31;
            this.label10.Text = "Desde";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(184, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 15);
            this.label12.TabIndex = 54;
            this.label12.Text = "Salida";
            // 
            // dtpHoraInicio
            // 
            this.dtpHoraInicio.CustomFormat = "HH:mm";
            this.dtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraInicio.Location = new System.Drawing.Point(228, 17);
            this.dtpHoraInicio.Name = "dtpHoraInicio";
            this.dtpHoraInicio.ShowUpDown = true;
            this.dtpHoraInicio.Size = new System.Drawing.Size(60, 23);
            this.dtpHoraInicio.TabIndex = 52;
            this.dtpHoraInicio.ValueChanged += new System.EventHandler(this.dtpHoraInicio_ValueChanged);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(69, 17);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(95, 23);
            this.dtpFechaDesde.TabIndex = 30;
            this.dtpFechaDesde.ValueChanged += new System.EventHandler(this.dtpFechaDesde_ValueChanged);
            // 
            // chkFechaHasta
            // 
            this.chkFechaHasta.AutoSize = true;
            this.chkFechaHasta.Location = new System.Drawing.Point(10, 47);
            this.chkFechaHasta.Name = "chkFechaHasta";
            this.chkFechaHasta.Size = new System.Drawing.Size(56, 19);
            this.chkFechaHasta.TabIndex = 32;
            this.chkFechaHasta.Text = "Hasta";
            this.chkFechaHasta.UseVisualStyleBackColor = true;
            this.chkFechaHasta.CheckedChanged += new System.EventHandler(this.chkFechaHasta_CheckedChanged);
            // 
            // _00016_ABM_ComisionServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 492);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvGrilla);
            this.Name = "_00016_ABM_ComisionServicio";
            this.Text = "_00016_ABM_ComisionServicio";
            this.Load += new System.EventHandler(this._00016_ABM_ComisionServicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PresentacionBase.Clases.Control.DataGridView dgvGrilla;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Label lblApyNom;
        private System.Windows.Forms.Label lblLegajo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip Menu;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox chkJornadaCompleta;
        private System.Windows.Forms.DateTimePicker dtpHoraFin;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpHoraInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.CheckBox chkFechaHasta;
    }
}