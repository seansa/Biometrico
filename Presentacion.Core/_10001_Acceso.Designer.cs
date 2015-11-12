namespace Presentacion.Core
{
    partial class _10001_Acceso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_10001_Acceso));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnEntrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.dtpHoraAcceso = new System.Windows.Forms.DateTimePicker();
            this.dgvAgentes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cmbTipoAcceso = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgentes)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEntrar,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(342, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnEntrar
            // 
            this.btnEntrar.ForeColor = System.Drawing.Color.White;
            this.btnEntrar.Image = ((System.Drawing.Image)(resources.GetObject("btnEntrar.Image")));
            this.btnEntrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(53, 35);
            this.btnEntrar.Text = "Ingresar";
            this.btnEntrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.ForeColor = System.Drawing.Color.White;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(33, 35);
            this.toolStripButton2.Text = "Salir";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // dtpHoraAcceso
            // 
            this.dtpHoraAcceso.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraAcceso.Location = new System.Drawing.Point(101, 66);
            this.dtpHoraAcceso.Name = "dtpHoraAcceso";
            this.dtpHoraAcceso.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpHoraAcceso.ShowUpDown = true;
            this.dtpHoraAcceso.Size = new System.Drawing.Size(102, 23);
            this.dtpHoraAcceso.TabIndex = 1;
            // 
            // dgvAgentes
            // 
            this.dgvAgentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAgentes.Location = new System.Drawing.Point(0, 95);
            this.dgvAgentes.Name = "dgvAgentes";
            this.dgvAgentes.Size = new System.Drawing.Size(504, 197);
            this.dgvAgentes.TabIndex = 2;
            this.dgvAgentes.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAgentes_RowEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hora de Acceso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(12, 66);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpFecha.Size = new System.Drawing.Size(83, 23);
            this.dtpFecha.TabIndex = 4;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // cmbTipoAcceso
            // 
            this.cmbTipoAcceso.FormattingEnabled = true;
            this.cmbTipoAcceso.Location = new System.Drawing.Point(209, 66);
            this.cmbTipoAcceso.Name = "cmbTipoAcceso";
            this.cmbTipoAcceso.Size = new System.Drawing.Size(121, 23);
            this.cmbTipoAcceso.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(206, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tipo de Acceso";
            // 
            // _10001_Acceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 295);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTipoAcceso);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAgentes);
            this.Controls.Add(this.dtpHoraAcceso);
            this.Controls.Add(this.toolStrip1);
            this.Name = "_10001_Acceso";
            this.Text = "_10001_Acceso";
            this.Load += new System.EventHandler(this._10001_Acceso_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgentes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnEntrar;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.DateTimePicker dtpHoraAcceso;
        private System.Windows.Forms.DataGridView dgvAgentes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cmbTipoAcceso;
        private System.Windows.Forms.Label label3;
    }
}