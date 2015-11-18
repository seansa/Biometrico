namespace Presentacion.Core
{
    partial class _10002_ReporteDiario
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.nudAusentes = new System.Windows.Forms.NumericUpDown();
            this.nudPresentes = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudTarde = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAusentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPresentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTarde)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 66);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1074, 424);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(206, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(188, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(479, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ausentes";
            // 
            // nudAusentes
            // 
            this.nudAusentes.Location = new System.Drawing.Point(536, 14);
            this.nudAusentes.Name = "nudAusentes";
            this.nudAusentes.Size = new System.Drawing.Size(58, 20);
            this.nudAusentes.TabIndex = 4;
            // 
            // nudPresentes
            // 
            this.nudPresentes.Location = new System.Drawing.Point(660, 12);
            this.nudPresentes.Name = "nudPresentes";
            this.nudPresentes.Size = new System.Drawing.Size(58, 20);
            this.nudPresentes.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(600, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Presentes";
            // 
            // nudTarde
            // 
            this.nudTarde.Location = new System.Drawing.Point(765, 12);
            this.nudTarde.Name = "nudTarde";
            this.nudTarde.Size = new System.Drawing.Size(58, 20);
            this.nudTarde.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(724, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tarde";
            // 
            // _10002_ReporteDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 490);
            this.Controls.Add(this.nudTarde);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudPresentes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudAusentes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "_10002_ReporteDiario";
            this.Text = "_10002_ReporteDiario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAusentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPresentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTarde)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudAusentes;
        private System.Windows.Forms.NumericUpDown nudPresentes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudTarde;
        private System.Windows.Forms.Label label3;
    }
}