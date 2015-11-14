using PresentacionBase;
using Servicio.RecursoHumano.Agente;
using Servicio.RecursoHumano.Agente.DTOs;
using Servicio.RecursoHumano.NovedadAgente;
using Servicio.RecursoHumano.NovedadAgente.DTOs;
using Servicio.RecursoHumano.TipoNovedadAgente;
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
    public partial class _00017_NovedadAgente : PresentacionBase.FormularioBase
    {
        private readonly IAgenteServicio _agenteServicio;
        TipoNovedadAgenteServicio _tipoNovedadAgente;
        NovedadAgenteServicio _novedadAgente;

        private long current_id;
        private long _tipoNovedadId;
        bool bandera;

        public _00017_NovedadAgente()
        {
            InitializeComponent();
            _agenteServicio = new AgenteServicio();
            _tipoNovedadAgente = new TipoNovedadAgenteServicio();
            _novedadAgente = new NovedadAgenteServicio();

            bandera = false;
            PoblarGrilla();
            FormatearGrilla(this.dgvNovedadAgente);
            PoblarComboBox(this.cmbTipoNovedadAgente, _tipoNovedadAgente.ObtenerTodo(), "Descripcion");

            this.btnGrabar.Image = PresentacionBase.Imagenes.BotonEjecutar;
            this.btnLimpiar.Image = PresentacionBase.Imagenes.BotonLimpiar;
            this.btnTipoNovedad.Image = PresentacionBase.Imagenes.BotonModificar;
            this.btnSalir.Image = PresentacionBase.Imagenes.BotonSalir;
        }


        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Legajo"].Visible = true;
            dgv.Columns["Legajo"].HeaderText = "Legajo";
            dgv.Columns["Legajo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Legajo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["ApyNom"].Visible = true;
            dgv.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["ApyNom"].HeaderText = "Apellido y Nombre";
            dgv.Columns["ApyNom"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns["ApyNom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["DNI"].Visible = true;
            dgv.Columns["DNI"].HeaderText = "Nro Documento";
            dgv.Columns["DNI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns["DNI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        public void PoblarGrilla()
        {
            var resultado = _agenteServicio.ObtenerTodo();
            this.dgvNovedadAgente.DataSource = resultado.ToList();
        }

        private void btnTipoNovedad_Click(object sender, EventArgs e)
        {
            var _formulario = new _00018_ABM_TipoNovedadAgente();
            _formulario.TipoOperacion = PresentacionBase.TipoOperacion.Insertar;
            _formulario.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvNovedadAgente_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvNovedadAgente.RowCount > 0)
            {
                current_id = (long)this.dgvNovedadAgente["Id", e.RowIndex].Value;
                var agente = _agenteServicio.ObtenerPorId(current_id);
                this.txtApyNom.Text = agente.Apellido + " " + agente.Nombre;
                this.txtLegajo.Text = agente.Legajo;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (cmbTipoNovedadAgente.Items.Count > 0)
            {
                var _tipoNovedad = _tipoNovedadAgente.ObtenerPorId(_tipoNovedadId);
                var _nuevaNovedad = new NovedadAgenteDTO();
                _nuevaNovedad.AngenteId = current_id;
                _nuevaNovedad.Observacion = this.txtObservacion.Text;
                _nuevaNovedad.TipoNovedadId = _tipoNovedadId;
                _nuevaNovedad.FechaDesde = this.dtpFechaDesde.Value;
                _nuevaNovedad.FechaHasta = this.dtpFechaHasta.Value;
                _nuevaNovedad.HoraDesde = (_tipoNovedad.EsJornadaCompleta) ? dtpHoraDesde.Value.TimeOfDay : (TimeSpan?)null;
                _nuevaNovedad.HoraHasta = (_tipoNovedad.EsJornadaCompleta) ? dtpHoraHasta.Value.TimeOfDay : (TimeSpan?)null;
                _novedadAgente.Insertar(_nuevaNovedad);
            }
            else
            {
                PresentacionBase.Mensaje.Mostrar("Debe seleccionar un Tipo de novedad", PresentacionBase.TipoMensaje.Aviso);
            }
        }

        private void cmbTipoNovedadAgente_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cmbTipoNovedadAgente.SelectedIndex >= 0 && bandera == true)
            {
                _tipoNovedadId = (long)cmbTipoNovedadAgente.SelectedValue;
                var _tipoNovedad = _tipoNovedadAgente.ObtenerPorId(_tipoNovedadId);

                this.dtpHoraDesde.Enabled = _tipoNovedad.EsJornadaCompleta ? true : false;
                this.dtpHoraHasta.Enabled = _tipoNovedad.EsJornadaCompleta ? true : false;
            }
            else
            {
                bandera = true;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);
        }
    }
}
