namespace PresentacionRecursoHumano
{
    partial class _00013_Novedades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_00013_Novedades));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Menu = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.dgvGrilla = new PresentacionBase.Clases.Control.DataGridView();
            this.cmbDireccion = new System.Windows.Forms.ComboBox();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.grbAfectados = new System.Windows.Forms.GroupBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.grbDuración = new System.Windows.Forms.GroupBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.chkTodoElDia = new System.Windows.Forms.CheckBox();
            this.dtpHoraHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.grbAfectados.SuspendLayout();
            this.grbDuración.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.btnSalir});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(802, 38);
            this.Menu.TabIndex = 0;
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
            // 
            // btnSalir
            // 
            this.btnSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(33, 35);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.AllowUserToAddRows = false;
            this.dgvGrilla.AllowUserToDeleteRows = false;
            this.dgvGrilla.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
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
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGrilla.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGrilla.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvGrilla.Location = new System.Drawing.Point(0, 143);
            this.dgvGrilla.MultiSelect = false;
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.ReadOnly = true;
            this.dgvGrilla.RowHeadersVisible = false;
            this.dgvGrilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrilla.Size = new System.Drawing.Size(802, 322);
            this.dgvGrilla.TabIndex = 1;
            // 
            // cmbDireccion
            // 
            this.cmbDireccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbDireccion.FormattingEnabled = true;
            this.cmbDireccion.Location = new System.Drawing.Point(70, 22);
            this.cmbDireccion.Name = "cmbDireccion";
            this.cmbDireccion.Size = new System.Drawing.Size(367, 23);
            this.cmbDireccion.TabIndex = 3;
            // 
            // cmbArea
            // 
            this.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(70, 53);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(367, 23);
            this.cmbArea.TabIndex = 4;
            // 
            // grbAfectados
            // 
            this.grbAfectados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.grbAfectados.Controls.Add(this.lblArea);
            this.grbAfectados.Controls.Add(this.lblDireccion);
            this.grbAfectados.Controls.Add(this.cmbDireccion);
            this.grbAfectados.Controls.Add(this.cmbArea);
            this.grbAfectados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbAfectados.Location = new System.Drawing.Point(14, 47);
            this.grbAfectados.Name = "grbAfectados";
            this.grbAfectados.Size = new System.Drawing.Size(447, 90);
            this.grbAfectados.TabIndex = 5;
            this.grbAfectados.TabStop = false;
            this.grbAfectados.Text = "Afectados";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblArea.Location = new System.Drawing.Point(33, 58);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(31, 15);
            this.lblArea.TabIndex = 6;
            this.lblArea.Text = "Área";
            this.lblArea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDireccion.Location = new System.Drawing.Point(7, 27);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(57, 15);
            this.lblDireccion.TabIndex = 5;
            this.lblDireccion.Text = "Dirección";
            this.lblDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grbDuración
            // 
            this.grbDuración.Controls.Add(this.btnAgregar);
            this.grbDuración.Controls.Add(this.chkTodoElDia);
            this.grbDuración.Controls.Add(this.dtpHoraHasta);
            this.grbDuración.Controls.Add(this.dtpHoraDesde);
            this.grbDuración.Controls.Add(this.dtpFecha);
            this.grbDuración.Controls.Add(this.label3);
            this.grbDuración.Controls.Add(this.label1);
            this.grbDuración.Controls.Add(this.label2);
            this.grbDuración.Location = new System.Drawing.Point(467, 47);
            this.grbDuración.Name = "grbDuración";
            this.grbDuración.Size = new System.Drawing.Size(327, 90);
            this.grbDuración.TabIndex = 7;
            this.grbDuración.TabStop = false;
            this.grbDuración.Text = "Duración";
            // 
            // btnAgregar
            // 
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Location = new System.Drawing.Point(230, 50);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(84, 26);
            this.btnAgregar.TabIndex = 12;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // chkTodoElDia
            // 
            this.chkTodoElDia.AutoSize = true;
            this.chkTodoElDia.Location = new System.Drawing.Point(230, 24);
            this.chkTodoElDia.Name = "chkTodoElDia";
            this.chkTodoElDia.Size = new System.Drawing.Size(84, 19);
            this.chkTodoElDia.TabIndex = 11;
            this.chkTodoElDia.Text = "Todo el día";
            this.chkTodoElDia.UseVisualStyleBackColor = true;
            // 
            // dtpHoraHasta
            // 
            this.dtpHoraHasta.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtpHoraHasta.CustomFormat = "HH:mm";
            this.dtpHoraHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraHasta.Location = new System.Drawing.Point(162, 53);
            this.dtpHoraHasta.Name = "dtpHoraHasta";
            this.dtpHoraHasta.ShowUpDown = true;
            this.dtpHoraHasta.Size = new System.Drawing.Size(52, 23);
            this.dtpHoraHasta.TabIndex = 10;
            // 
            // dtpHoraDesde
            // 
            this.dtpHoraDesde.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtpHoraDesde.CustomFormat = "HH:mm";
            this.dtpHoraDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraDesde.Location = new System.Drawing.Point(52, 53);
            this.dtpHoraDesde.Name = "dtpHoraDesde";
            this.dtpHoraDesde.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpHoraDesde.ShowUpDown = true;
            this.dtpHoraDesde.Size = new System.Drawing.Size(52, 23);
            this.dtpHoraDesde.TabIndex = 9;
            // 
            // dtpFecha
            // 
            this.dtpFecha.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(52, 22);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(162, 23);
            this.dtpFecha.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(119, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Hasta";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Fecha";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(7, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Desde";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _00013_Novedades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 465);
            this.Controls.Add(this.grbDuración);
            this.Controls.Add(this.grbAfectados);
            this.Controls.Add(this.dgvGrilla);
            this.Controls.Add(this.Menu);
            this.MinimumSize = new System.Drawing.Size(818, 504);
            this.Name = "_00013_Novedades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.grbAfectados.ResumeLayout(false);
            this.grbAfectados.PerformLayout();
            this.grbDuración.ResumeLayout(false);
            this.grbDuración.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Menu;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private PresentacionBase.Clases.Control.DataGridView dgvGrilla;
        private System.Windows.Forms.ComboBox cmbDireccion;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.GroupBox grbAfectados;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.GroupBox grbDuración;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DateTimePicker dtpHoraDesde;
        private System.Windows.Forms.DateTimePicker dtpHoraHasta;
        private System.Windows.Forms.CheckBox chkTodoElDia;
        private System.Windows.Forms.Button btnAgregar;
    }
}