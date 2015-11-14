using Servicio.RecursoHumano.RelojDefectuoso;
using Servicio.RecursoHumano.RelojDefectuoso.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionRecursoHumano
{
    public partial class _00013_Novedades : PresentacionBase.FormularioBase
    {
        RelojDefectuosoServicio _relojDefectuoso;
        public _00013_Novedades() : base()
        {
            InitializeComponent();
            _relojDefectuoso = new RelojDefectuosoServicio();
        }

        public _00013_Novedades(string titulo) : this()
        {
            this.Text = titulo;
        }

        private void chkJornadaCompleta_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkJornadaCompleta.Checked) DeshabilitarControles(false);
            else DeshabilitarControles(true);
        }
        private void DeshabilitarControles(bool estado)
        {
            this.dtpHoraDesde.Enabled = estado;
            this.dtpHoraHasta.Enabled = estado;
        }

        private void _00013_Novedades_Load(object sender, EventArgs e)
        {
            DeshabilitarControles(true);
            this.dgvGrilla.DataSource = new List<RelojDefectuosoDTO>();
            FormatearGrilla(this.dgvGrilla);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DeshabilitarControles(false);
            
            var resultado = _relojDefectuoso.ObtenerListadodeRelojDefectuoso(this.dtpFecha.Value.Date, this.chkJornadaCompleta.Checked, dtpHoraDesde.Value.TimeOfDay, dtpHoraHasta.Value.TimeOfDay);
            this.dgvGrilla.DataSource = resultado.ToList();
            FormatearGrilla(this.dgvGrilla);
            DeshabilitarControles(true);
            chkJornadaCompleta.Checked = false;
        }
        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);
            this.dgvGrilla.Columns["Legajo"].Visible = true;
            this.dgvGrilla.Columns["Legajo"].Width = 150;
            this.dgvGrilla.Columns["ApyNom"].Visible = true;
            this.dgvGrilla.Columns["ApyNom"].Width = 150;
            this.dgvGrilla.Columns["RelojDefectuosoEntrada"].Width = 150;
            this.dgvGrilla.Columns["RelojDefectuosoEntrada"].HeaderText = "Reloj Entrada";
            this.dgvGrilla.Columns["RelojDefectuosoEntrada"].Visible = true;
            this.dgvGrilla.Columns["RelojDefectuosoSalidaParcial"].Width = 150;
            this.dgvGrilla.Columns["RelojDefectuosoSalidaParcial"].Visible = true;
            this.dgvGrilla.Columns["RelojDefectuosoSalidaParcial"].HeaderText = "Reloj Salida Parcial";
            this.dgvGrilla.Columns["RelojDefectuosoEntradaParcial"].Width = 150;
            this.dgvGrilla.Columns["RelojDefectuosoEntradaParcial"].Visible = true;
            this.dgvGrilla.Columns["RelojDefectuosoEntradaParcial"].HeaderText = "Reloj Entrada Parcial";
            this.dgvGrilla.Columns["RelojDefectuosoSalida"].Width = 150;
            this.dgvGrilla.Columns["RelojDefectuosoSalida"].Visible = true;
            this.dgvGrilla.Columns["RelojDefectuosoSalida"].HeaderText = "Reloj Salida";
            this.dgvGrilla.Columns["JornadaCompleta"].Width = 150;
            this.dgvGrilla.Columns["JornadaCompleta"].Visible = true;
            this.dgvGrilla.Columns["JornadaCompleta"].HeaderText = "Jornada Completa";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _relojDefectuoso.GuardarRelojDefectuoso(this.dtpFecha.Value.Date, this.dtpHoraDesde.Value.TimeOfDay, this.dtpHoraHasta.Value.TimeOfDay, this.chkJornadaCompleta.Checked);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
