namespace PresentacionRecursoHumano
{
    partial class _00004_ABM_SubSector
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
            this.lbl1 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.nudCodigo = new System.Windows.Forms.NumericUpDown();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSector = new System.Windows.Forms.ComboBox();
            this.btnNuevoSector = new System.Windows.Forms.Button();
            this.txtAbreviatura = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMensaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCodigo)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(475, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "*";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(212, 151);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(15, 20);
            this.lbl1.TabIndex = 13;
            this.lbl1.Text = "*";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(105, 178);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(364, 23);
            this.txtDescripcion.TabIndex = 10;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            this.txtDescripcion.Validating += new System.ComponentModel.CancelEventHandler(this.nudCodigo_Validating);
            // 
            // nudCodigo
            // 
            this.nudCodigo.Location = new System.Drawing.Point(105, 148);
            this.nudCodigo.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudCodigo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCodigo.Name = "nudCodigo";
            this.nudCodigo.Size = new System.Drawing.Size(101, 23);
            this.nudCodigo.TabIndex = 9;
            this.nudCodigo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCodigo.Validating += new System.ComponentModel.CancelEventHandler(this.nudCodigo_Validating);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(22, 181);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(69, 15);
            this.lblDescripcion.TabIndex = 12;
            this.lblDescripcion.Text = "Descripción";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(49, 150);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(46, 15);
            this.lblCodigo.TabIndex = 11;
            this.lblCodigo.Text = "Código";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Sector";
            // 
            // cmbSector
            // 
            this.cmbSector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSector.FormattingEnabled = true;
            this.cmbSector.Location = new System.Drawing.Point(105, 117);
            this.cmbSector.Name = "cmbSector";
            this.cmbSector.Size = new System.Drawing.Size(321, 23);
            this.cmbSector.TabIndex = 16;
            // 
            // btnNuevoSector
            // 
            this.btnNuevoSector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoSector.Location = new System.Drawing.Point(434, 114);
            this.btnNuevoSector.Name = "btnNuevoSector";
            this.btnNuevoSector.Size = new System.Drawing.Size(36, 28);
            this.btnNuevoSector.TabIndex = 17;
            this.btnNuevoSector.Text = "...";
            this.btnNuevoSector.UseVisualStyleBackColor = true;
            this.btnNuevoSector.Click += new System.EventHandler(this.btnNuevoSector_Click);
            // 
            // txtAbreviatura
            // 
            this.txtAbreviatura.Location = new System.Drawing.Point(105, 208);
            this.txtAbreviatura.Name = "txtAbreviatura";
            this.txtAbreviatura.Size = new System.Drawing.Size(364, 23);
            this.txtAbreviatura.TabIndex = 18;
            this.txtAbreviatura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAbreviatura_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "Abreviatura";
            // 
            // _00004_ABM_SubSector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 267);
            this.Controls.Add(this.txtAbreviatura);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnNuevoSector);
            this.Controls.Add(this.cmbSector);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.nudCodigo);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblCodigo);
            this.MaximumSize = new System.Drawing.Size(534, 306);
            this.Name = "_00004_ABM_SubSector";
            this.Controls.SetChildIndex(this.lblCodigo, 0);
            this.Controls.SetChildIndex(this.lblDescripcion, 0);
            this.Controls.SetChildIndex(this.nudCodigo, 0);
            this.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.Controls.SetChildIndex(this.lbl1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cmbSector, 0);
            this.Controls.SetChildIndex(this.btnNuevoSector, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtAbreviatura, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMensaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCodigo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.NumericUpDown nudCodigo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSector;
        private System.Windows.Forms.Button btnNuevoSector;
        private System.Windows.Forms.TextBox txtAbreviatura;
        private System.Windows.Forms.Label label5;
    }
}