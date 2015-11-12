namespace PresentacionRecursoHumano
{
    partial class _00011_ABM_Horario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_00011_ABM_Horario));
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.btnSemana = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.txtApyNom = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.chkSabado = new System.Windows.Forms.CheckBox();
            this.pnlDias = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.chkDomingo = new System.Windows.Forms.CheckBox();
            this.chkViernes = new System.Windows.Forms.CheckBox();
            this.chkJueves = new System.Windows.Forms.CheckBox();
            this.chkMiercoles = new System.Windows.Forms.CheckBox();
            this.chkMartes = new System.Windows.Forms.CheckBox();
            this.chkLunes = new System.Windows.Forms.CheckBox();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvgrilla = new PresentacionBase.Clases.Control.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.chkFechaHasta = new System.Windows.Forms.CheckBox();
            this.dtpHoraEntrada = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraEntradaParcial = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraSalidaParcial = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraSalida = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.chkHorariosParciales = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSemana.SuspendLayout();
            this.pnlDias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvgrilla)).BeginInit();
            this.btnSalir.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Enabled = false;
            this.dtpFechaHasta.Location = new System.Drawing.Point(497, 3);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(240, 23);
            this.dtpFechaHasta.TabIndex = 18;
            this.dtpFechaHasta.Visible = false;
            this.dtpFechaHasta.ValueChanged += new System.EventHandler(this.dtpFechaHasta_ValueChanged);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Location = new System.Drawing.Point(92, 3);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(233, 23);
            this.dtpFechaDesde.TabIndex = 17;
            this.dtpFechaDesde.ValueChanged += new System.EventHandler(this.dtpFechaDesde_ValueChanged);
            // 
            // btnSemana
            // 
            this.btnSemana.Controls.Add(this.label3);
            this.btnSemana.Controls.Add(this.label2);
            this.btnSemana.Controls.Add(this.label1);
            this.btnSemana.Controls.Add(this.txtLegajo);
            this.btnSemana.Controls.Add(this.txtApyNom);
            this.btnSemana.Controls.Add(this.txtDni);
            this.btnSemana.Enabled = false;
            this.btnSemana.Location = new System.Drawing.Point(10, 59);
            this.btnSemana.Name = "btnSemana";
            this.btnSemana.Size = new System.Drawing.Size(745, 100);
            this.btnSemana.TabIndex = 16;
            this.btnSemana.TabStop = false;
            this.btnSemana.Text = "Datos del Agente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(518, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "DNI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Apellido y Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Legajo";
            // 
            // txtLegajo
            // 
            this.txtLegajo.Location = new System.Drawing.Point(121, 22);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(237, 23);
            this.txtLegajo.TabIndex = 6;
            // 
            // txtApyNom
            // 
            this.txtApyNom.Location = new System.Drawing.Point(121, 62);
            this.txtApyNom.Name = "txtApyNom";
            this.txtApyNom.Size = new System.Drawing.Size(615, 23);
            this.txtApyNom.TabIndex = 7;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(555, 22);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(181, 23);
            this.txtDni.TabIndex = 8;
            // 
            // chkSabado
            // 
            this.chkSabado.AutoSize = true;
            this.chkSabado.Location = new System.Drawing.Point(415, 12);
            this.chkSabado.Name = "chkSabado";
            this.chkSabado.Size = new System.Drawing.Size(65, 19);
            this.chkSabado.TabIndex = 5;
            this.chkSabado.Text = "Sábado";
            this.chkSabado.UseVisualStyleBackColor = true;
            // 
            // pnlDias
            // 
            this.pnlDias.Controls.Add(this.button1);
            this.pnlDias.Controls.Add(this.chkDomingo);
            this.pnlDias.Controls.Add(this.chkSabado);
            this.pnlDias.Controls.Add(this.chkViernes);
            this.pnlDias.Controls.Add(this.chkJueves);
            this.pnlDias.Controls.Add(this.chkMiercoles);
            this.pnlDias.Controls.Add(this.chkMartes);
            this.pnlDias.Controls.Add(this.chkLunes);
            this.pnlDias.Location = new System.Drawing.Point(10, 293);
            this.pnlDias.Name = "pnlDias";
            this.pnlDias.Size = new System.Drawing.Size(745, 42);
            this.pnlDias.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(582, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 33);
            this.button1.TabIndex = 7;
            this.button1.Text = "Marcar Semana";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // chkDomingo
            // 
            this.chkDomingo.AutoSize = true;
            this.chkDomingo.Location = new System.Drawing.Point(496, 12);
            this.chkDomingo.Name = "chkDomingo";
            this.chkDomingo.Size = new System.Drawing.Size(76, 19);
            this.chkDomingo.TabIndex = 6;
            this.chkDomingo.Text = "Domingo";
            this.chkDomingo.UseVisualStyleBackColor = true;
            // 
            // chkViernes
            // 
            this.chkViernes.AutoSize = true;
            this.chkViernes.Location = new System.Drawing.Point(337, 12);
            this.chkViernes.Name = "chkViernes";
            this.chkViernes.Size = new System.Drawing.Size(64, 19);
            this.chkViernes.TabIndex = 4;
            this.chkViernes.Text = "Viernes";
            this.chkViernes.UseVisualStyleBackColor = true;
            // 
            // chkJueves
            // 
            this.chkJueves.AutoSize = true;
            this.chkJueves.Location = new System.Drawing.Point(260, 12);
            this.chkJueves.Name = "chkJueves";
            this.chkJueves.Size = new System.Drawing.Size(60, 19);
            this.chkJueves.TabIndex = 3;
            this.chkJueves.Text = "Jueves";
            this.chkJueves.UseVisualStyleBackColor = true;
            // 
            // chkMiercoles
            // 
            this.chkMiercoles.AutoSize = true;
            this.chkMiercoles.Location = new System.Drawing.Point(170, 12);
            this.chkMiercoles.Name = "chkMiercoles";
            this.chkMiercoles.Size = new System.Drawing.Size(77, 19);
            this.chkMiercoles.TabIndex = 2;
            this.chkMiercoles.Text = "Miércoles";
            this.chkMiercoles.UseVisualStyleBackColor = true;
            // 
            // chkMartes
            // 
            this.chkMartes.AutoSize = true;
            this.chkMartes.Location = new System.Drawing.Point(96, 12);
            this.chkMartes.Name = "chkMartes";
            this.chkMartes.Size = new System.Drawing.Size(62, 19);
            this.chkMartes.TabIndex = 1;
            this.chkMartes.Text = "Martes";
            this.chkMartes.UseVisualStyleBackColor = true;
            // 
            // chkLunes
            // 
            this.chkLunes.AutoSize = true;
            this.chkLunes.Location = new System.Drawing.Point(16, 12);
            this.chkLunes.Name = "chkLunes";
            this.chkLunes.Size = new System.Drawing.Size(57, 19);
            this.chkLunes.TabIndex = 0;
            this.chkLunes.Text = "Lunes";
            this.chkLunes.UseVisualStyleBackColor = true;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(689, 422);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(68, 85);
            this.btnQuitar.TabIndex = 15;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(688, 342);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(68, 74);
            this.btnAgregar.TabIndex = 14;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvgrilla
            // 
            this.dgvgrilla.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            this.dgvgrilla.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvgrilla.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dgvgrilla.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvgrilla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvgrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvgrilla.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvgrilla.GridColor = System.Drawing.Color.White;
            this.dgvgrilla.Location = new System.Drawing.Point(10, 342);
            this.dgvgrilla.MultiSelect = false;
            this.dgvgrilla.Name = "dgvgrilla";
            this.dgvgrilla.RowHeadersVisible = false;
            this.dgvgrilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvgrilla.Size = new System.Drawing.Size(672, 166);
            this.dgvgrilla.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Fecha Inicial";
            // 
            // chkFechaHasta
            // 
            this.chkFechaHasta.AutoSize = true;
            this.chkFechaHasta.Location = new System.Drawing.Point(385, 7);
            this.chkFechaHasta.Name = "chkFechaHasta";
            this.chkFechaHasta.Size = new System.Drawing.Size(85, 19);
            this.chkFechaHasta.TabIndex = 22;
            this.chkFechaHasta.Text = "Fecha Final";
            this.chkFechaHasta.UseVisualStyleBackColor = true;
            this.chkFechaHasta.CheckedChanged += new System.EventHandler(this.chkFechaHasta_CheckedChanged);
            // 
            // dtpHoraEntrada
            // 
            this.dtpHoraEntrada.CustomFormat = "";
            this.dtpHoraEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraEntrada.Location = new System.Drawing.Point(96, 46);
            this.dtpHoraEntrada.Name = "dtpHoraEntrada";
            this.dtpHoraEntrada.ShowUpDown = true;
            this.dtpHoraEntrada.Size = new System.Drawing.Size(130, 23);
            this.dtpHoraEntrada.TabIndex = 23;
            this.dtpHoraEntrada.ValueChanged += new System.EventHandler(this.dpHorarioEntrada_ValueChanged);
            // 
            // dtpHoraEntradaParcial
            // 
            this.dtpHoraEntradaParcial.Enabled = false;
            this.dtpHoraEntradaParcial.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraEntradaParcial.Location = new System.Drawing.Point(587, 92);
            this.dtpHoraEntradaParcial.Name = "dtpHoraEntradaParcial";
            this.dtpHoraEntradaParcial.ShowUpDown = true;
            this.dtpHoraEntradaParcial.Size = new System.Drawing.Size(150, 23);
            this.dtpHoraEntradaParcial.TabIndex = 24;
            this.dtpHoraEntradaParcial.ValueChanged += new System.EventHandler(this.dtpHoraEntradaParcial_ValueChanged);
            // 
            // dtpHoraSalidaParcial
            // 
            this.dtpHoraSalidaParcial.Enabled = false;
            this.dtpHoraSalidaParcial.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraSalidaParcial.Location = new System.Drawing.Point(590, 61);
            this.dtpHoraSalidaParcial.MinDate = new System.DateTime(2015, 10, 31, 0, 0, 0, 0);
            this.dtpHoraSalidaParcial.Name = "dtpHoraSalidaParcial";
            this.dtpHoraSalidaParcial.ShowUpDown = true;
            this.dtpHoraSalidaParcial.Size = new System.Drawing.Size(150, 23);
            this.dtpHoraSalidaParcial.TabIndex = 25;
            this.dtpHoraSalidaParcial.ValueChanged += new System.EventHandler(this.dtpHoraSalidaParcial_ValueChanged);
            // 
            // dtpHoraSalida
            // 
            this.dtpHoraSalida.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraSalida.Location = new System.Drawing.Point(96, 88);
            this.dtpHoraSalida.Name = "dtpHoraSalida";
            this.dtpHoraSalida.ShowUpDown = true;
            this.dtpHoraSalida.Size = new System.Drawing.Size(130, 23);
            this.dtpHoraSalida.TabIndex = 26;
            this.dtpHoraSalida.ValueChanged += new System.EventHandler(this.dtpHoraSalida_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 15);
            this.label5.TabIndex = 27;
            this.label5.Text = "Hora Entrada";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // chkHorariosParciales
            // 
            this.chkHorariosParciales.AutoSize = true;
            this.chkHorariosParciales.Location = new System.Drawing.Point(430, 33);
            this.chkHorariosParciales.Name = "chkHorariosParciales";
            this.chkHorariosParciales.Size = new System.Drawing.Size(120, 19);
            this.chkHorariosParciales.TabIndex = 31;
            this.chkHorariosParciales.Text = "Horarios Parciales";
            this.chkHorariosParciales.UseVisualStyleBackColor = true;
            this.chkHorariosParciales.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 27;
            this.label6.Text = "Hora Salida";
            this.label6.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSalir.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.btnSalir.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.toolStripButton2});
            this.btnSalir.Location = new System.Drawing.Point(0, 0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(765, 47);
            this.btnSalir.TabIndex = 34;
            this.btnSalir.Text = "toolStrip1";
            // 
            // btnGuardar
            // 
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(53, 44);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGuardar.ToolTipText = "Nuevo";
            this.btnGuardar.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.ForeColor = System.Drawing.Color.White;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(33, 44);
            this.toolStripButton2.Text = "Salir";
            this.toolStripButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.dtpFechaDesde);
            this.panel2.Controls.Add(this.dtpFechaHasta);
            this.panel2.Controls.Add(this.chkHorariosParciales);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dtpHoraEntradaParcial);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.chkFechaHasta);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.dtpHoraEntrada);
            this.panel2.Controls.Add(this.dtpHoraSalida);
            this.panel2.Controls.Add(this.dtpHoraSalidaParcial);
            this.panel2.Location = new System.Drawing.Point(10, 164);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(745, 122);
            this.panel2.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(460, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 15);
            this.label8.TabIndex = 34;
            this.label8.Text = "Hora Salida Parcial";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(450, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 15);
            this.label7.TabIndex = 33;
            this.label7.Text = "Hora Entrada Parcial";
            // 
            // _00011_ABM_Horario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 522);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnSemana);
            this.Controls.Add(this.pnlDias);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvgrilla);
            this.Name = "_00011_ABM_Horario";
            this.Text = "_00011_ABM_Horario";
            this.Load += new System.EventHandler(this._00011_ABM_Horario_Load);
            this.btnSemana.ResumeLayout(false);
            this.btnSemana.PerformLayout();
            this.pnlDias.ResumeLayout(false);
            this.pnlDias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvgrilla)).EndInit();
            this.btnSalir.ResumeLayout(false);
            this.btnSalir.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.GroupBox btnSemana;
        private System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.TextBox txtApyNom;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.CheckBox chkSabado;
        private System.Windows.Forms.Panel pnlDias;
        private System.Windows.Forms.CheckBox chkDomingo;
        private System.Windows.Forms.CheckBox chkViernes;
        private System.Windows.Forms.CheckBox chkJueves;
        private System.Windows.Forms.CheckBox chkMiercoles;
        private System.Windows.Forms.CheckBox chkMartes;
        private System.Windows.Forms.CheckBox chkLunes;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpHoraEntrada;
        private System.Windows.Forms.DateTimePicker dtpHoraEntradaParcial;
        private System.Windows.Forms.DateTimePicker dtpHoraSalidaParcial;
        private System.Windows.Forms.DateTimePicker dtpHoraSalida;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkHorariosParciales;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStrip btnSalir;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private PresentacionBase.Clases.Control.DataGridView dgvgrilla;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}