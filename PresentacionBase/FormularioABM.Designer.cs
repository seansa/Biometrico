namespace PresentacionBase
{
    partial class FormularioABM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioABM));
            this.Menu = new System.Windows.Forms.ToolStrip();
            this.btnEjecutar = new System.Windows.Forms.ToolStripButton();
            this.btnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProviderMensaje = new System.Windows.Forms.ErrorProvider(this.components);
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMensaje)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Menu.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEjecutar,
            this.btnLimpiar,
            this.btnSalir});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(518, 52);
            this.Menu.TabIndex = 1;
            this.Menu.Text = "toolStrip1";
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEjecutar.Image = ((System.Drawing.Image)(resources.GetObject("btnEjecutar.Image")));
            this.btnEjecutar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(53, 49);
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(51, 49);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(34, 49);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(351, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Datos Obligatorios [*]";
            // 
            // errorProviderMensaje
            // 
            this.errorProviderMensaje.ContainerControl = this;
            // 
            // FormularioABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 267);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Menu);
            this.MinimumSize = new System.Drawing.Size(534, 306);
            this.Name = "FormularioABM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormularioABM_FormClosing);
            this.Load += new System.EventHandler(this.FormularioABM_Load);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMensaje)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip Menu;
        public System.Windows.Forms.ToolStripButton btnEjecutar;
        public System.Windows.Forms.ToolStripButton btnLimpiar;
        public System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ErrorProvider errorProviderMensaje;
    }
}