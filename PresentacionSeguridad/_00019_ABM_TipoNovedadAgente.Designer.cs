namespace PresentacionRecursoHumano
{
    partial class _00019_ABM_TipoNovedadAgente
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtTipoNovedadAgente = new System.Windows.Forms.TextBox();
            this.txtAbreviaturaCodigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbJornadaCompleta = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMensaje)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tipo de Novedad";
            // 
            // txtTipoNovedadAgente
            // 
            this.txtTipoNovedadAgente.Location = new System.Drawing.Point(130, 123);
            this.txtTipoNovedadAgente.Name = "txtTipoNovedadAgente";
            this.txtTipoNovedadAgente.Size = new System.Drawing.Size(338, 23);
            this.txtTipoNovedadAgente.TabIndex = 4;
            // 
            // txtAbreviaturaCodigo
            // 
            this.txtAbreviaturaCodigo.Location = new System.Drawing.Point(130, 163);
            this.txtAbreviaturaCodigo.Name = "txtAbreviaturaCodigo";
            this.txtAbreviaturaCodigo.Size = new System.Drawing.Size(158, 23);
            this.txtAbreviaturaCodigo.TabIndex = 6;
            this.txtAbreviaturaCodigo.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Abreviatura/Codigo";
            // 
            // cbJornadaCompleta
            // 
            this.cbJornadaCompleta.AutoSize = true;
            this.cbJornadaCompleta.Location = new System.Drawing.Point(15, 202);
            this.cbJornadaCompleta.Name = "cbJornadaCompleta";
            this.cbJornadaCompleta.Size = new System.Drawing.Size(120, 19);
            this.cbJornadaCompleta.TabIndex = 7;
            this.cbJornadaCompleta.Text = "Jornada completa";
            this.cbJornadaCompleta.UseVisualStyleBackColor = true;
            // 
            // _00019_ABM_TipoNovedadAgente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 267);
            this.Controls.Add(this.cbJornadaCompleta);
            this.Controls.Add(this.txtAbreviaturaCodigo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTipoNovedadAgente);
            this.Controls.Add(this.label2);
            this.Name = "_00019_ABM_TipoNovedadAgente";
            this.Text = "_00019_ABM_TipoNovedadAgente";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtTipoNovedadAgente, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtAbreviaturaCodigo, 0);
            this.Controls.SetChildIndex(this.cbJornadaCompleta, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMensaje)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTipoNovedadAgente;
        private System.Windows.Forms.TextBox txtAbreviaturaCodigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbJornadaCompleta;
    }
}