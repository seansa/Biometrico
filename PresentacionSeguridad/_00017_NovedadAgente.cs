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
using AccesoDatos;

namespace PresentacionRecursoHumano
{
    public partial class _00017_NovedadAgente : PresentacionBase.FormularioBase
    {
        private readonly IAgenteServicio _agenteServicio;
        TipoNovedadAgenteServicio _tipoNovedadAgente;
        NovedadAgenteServicio _novedadAgente;
        List<NovedadAgenteDTO> listaNovedades;

        private long current_id;
        private long _tipoNovedadId;
        

        public _00017_NovedadAgente()
        {
            InitializeComponent();
            _agenteServicio = new AgenteServicio();
            _tipoNovedadAgente = new TipoNovedadAgenteServicio();
            _novedadAgente = new NovedadAgenteServicio();
            listaNovedades = new List<NovedadAgenteDTO>();
                        
            PoblarGrilla();
            FormatearGrilla(this.dgvNovedadAgente);
            PoblarComboBox(this.cmbTipoNovedadAgente, _tipoNovedadAgente.ObtenerTodo(), "Descripcion");

            this.btnGrabar.Image = Imagenes.BotonEjecutar;
            this.btnLimpiar.Image = Imagenes.BotonLimpiar;
            this.btnTipoNovedad.Image = Imagenes.BotonModificar;
            this.btnSalir.Image = Imagenes.BotonSalir;
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
            _formulario.TipoOperacion = TipoOperacion.Insertar;
            _formulario.ShowDialog();
            PoblarComboBox(this.cmbTipoNovedadAgente, _tipoNovedadAgente.ObtenerTodo(), "Descripcion");
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
            var _tipoNovedad = _tipoNovedadAgente.ObtenerPorId(_tipoNovedadId);

            if (cmbTipoNovedadAgente.Items.Count > 0)
            {
                if (HorasValidas(_tipoNovedad))
                {
                   
                        if (_novedadAgente.VerificarRangodeFechas(listaNovedades, this.dtpFechaDesde.Value.Date, this.dtpFechaHasta.Value.Date))
                         {

                            var _nuevaNovedad = new NovedadAgenteDTO();
                            _nuevaNovedad.AngenteId = current_id;
                            _nuevaNovedad.Observacion = this.txtObservacion.Text;
                            _nuevaNovedad.TipoNovedadId = _tipoNovedadId;
                            _nuevaNovedad.FechaDesde = this.dtpFechaDesde.Value.Date;
                            _nuevaNovedad.FechaHasta = this.dtpFechaHasta.Value.Date;
                            _nuevaNovedad.HoraDesde = (_tipoNovedad.EsJornadaCompleta) ? (TimeSpan?)null : dtpHoraDesde.Value.TimeOfDay;
                            _nuevaNovedad.HoraHasta = (_tipoNovedad.EsJornadaCompleta) ? (TimeSpan?)null : dtpHoraHasta.Value.TimeOfDay;
                            _novedadAgente.Insertar(_nuevaNovedad);
                            LimpiarControles(this);
                            listaNovedades.Add(_nuevaNovedad);
                        MessageBox.Show("La Novedad del Agente ha sido guardada con éxito");
                        
                    }
                    else
                    {
                        Mensaje.Mostrar("El agente ya tiene una Novedad en ese rango de fechas",TipoMensaje.Aviso);
                    }
                }
                else
                {
                    Mensaje.Mostrar("Hora Entrada no puede ser mayor que Hora Salida", TipoMensaje.Aviso);
                }
            }
            else
            {
                Mensaje.Mostrar("Debe seleccionar un Tipo de novedad", TipoMensaje.Aviso);
            }
        }

        private bool HorasValidas(TipoNovedad _tipoNovedad)
        {
            if (_tipoNovedad.EsJornadaCompleta)
            {
                return true;
            }
            else
            {
                return (dtpHoraDesde.Value > dtpHoraHasta.Value) ? false : true;
            }
        }

        private void cmbTipoNovedadAgente_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbTipoNovedadAgente.SelectedIndex >= 0)
            {
                _tipoNovedadId = (long)cmbTipoNovedadAgente.SelectedValue;
                var _tipoNovedad = _tipoNovedadAgente.ObtenerPorId(_tipoNovedadId);

                this.dtpHoraDesde.Enabled = _tipoNovedad.EsJornadaCompleta ? false : true;
                this.dtpHoraHasta.Enabled = _tipoNovedad.EsJornadaCompleta ? false : true;
            }
           
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);
        }

        private void _00017_NovedadAgente_Load(object sender, EventArgs e)
        {
            listaNovedades = _novedadAgente.ObtenerPorId(current_id).ToList();
        }
    }
}
