using Servicio.RecursoHumano.Agente;
using Servicio.RecursoHumano.Agente.DTOs;
using Servicio.RecursoHumano.Reportes;
using Servicio.RecursoHumano.Reportes.DTOs;
using Servicio.RecursoHumano.Sector;
using Servicio.RecursoHumano.Sector.DTOs;
using Servicio.RecursoHumano.SubSector;
using Servicio.RecursoHumano.SubSector.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace PresentacionRecursoHumano
{
    public partial class _00021_ReporteMensual : PresentacionBase.FormularioBase
    {
        private readonly IAgenteServicio _agenteServicio;
        private readonly ISectorServicio _sectorServicio;
        private readonly ISubSectorServicio _subsectorServicio;
        private IReporteMensualServicio _reporteServicio;
        private List<int> _listaAños;
        private List<string> _listaMeses;
        private IEnumerable<AgenteDTO> _listaAgentes;
        private AgenteDTO _agenteSeleccionado;
        private List<ReporteMensualDTO> _reporteAgenteSeleccionado;
        private int _filaAgente;

        public _00021_ReporteMensual()
        {
            InitializeComponent();
            _agenteServicio = new AgenteServicio();
            _sectorServicio = new SectorServicio();
            _subsectorServicio = new SubSectorServicio();
            _agenteSeleccionado = null;

            _filaAgente = -1;
        }

        public _00021_ReporteMensual(string titulo) : this()
        {
            Text = titulo;
        }

        public void FormatearGrillaAgentes(DataGridView dgvAgentes)
        {
            base.FormatearGrilla(dgvAgentes);

            this.dgvAgentes.Columns["Legajo"].Visible = true;
            this.dgvAgentes.Columns["Legajo"].HeaderText = "Legajo";
            this.dgvAgentes.Columns["Legajo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvAgentes.Columns["Legajo"].DisplayIndex = 1;

            this.dgvAgentes.Columns["ApyNom"].Visible = true;
            this.dgvAgentes.Columns["ApyNom"].HeaderText = "Apellido y Nombre";
            this.dgvAgentes.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvAgentes.Columns["ApyNom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvAgentes.Columns["ApyNom"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        public void FormatearGrillaReporte(DataGridView dgvReporte)
        {
            base.FormatearGrilla(dgvReporte);

            this.dgvReporte.Columns["Numero"].Visible = true;
            this.dgvReporte.Columns["Numero"].HeaderText = "Nº";
            this.dgvReporte.Columns["Numero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvReporte.Columns["Numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReporte.Columns["Numero"].DisplayIndex = 1;
                    
            this.dgvReporte.Columns["FechaStr"].Visible = true;
            this.dgvReporte.Columns["FechaStr"].HeaderText = "Fecha";
            this.dgvReporte.Columns["FechaStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvReporte.Columns["FechaStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReporte.Columns["FechaStr"].DisplayIndex = 2;

            this.dgvReporte.Columns["AusenteStr"].Visible = true;
            this.dgvReporte.Columns["AusenteStr"].HeaderText = "Ausente";
            this.dgvReporte.Columns["AusenteStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvReporte.Columns["AusenteStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReporte.Columns["AusenteStr"].DisplayIndex = 3;

            this.dgvReporte.Columns["HoraEntradaStr"].Visible = true;
            this.dgvReporte.Columns["HoraEntradaStr"].HeaderText = "Entrada";
            this.dgvReporte.Columns["HoraEntradaStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvReporte.Columns["HoraEntradaStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReporte.Columns["HoraEntradaStr"].DisplayIndex = 4;

            this.dgvReporte.Columns["MinutosTardeStr"].Visible = true;
            this.dgvReporte.Columns["MinutosTardeStr"].HeaderText = "Tardanza";
            this.dgvReporte.Columns["MinutosTardeStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvReporte.Columns["MinutosTardeStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReporte.Columns["MinutosTardeStr"].DisplayIndex = 5;

            this.dgvReporte.Columns["HoraSalidaParcialStr"].Visible = true;
            this.dgvReporte.Columns["HoraSalidaParcialStr"].HeaderText = "Salida Parcial";
            this.dgvReporte.Columns["HoraSalidaParcialStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvReporte.Columns["HoraSalidaParcialStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReporte.Columns["HoraSalidaParcialStr"].DisplayIndex = 6;

            this.dgvReporte.Columns["MinutosFaltantes"].Visible = true;
            this.dgvReporte.Columns["MinutosFaltantes"].HeaderText = "Faltante";
            this.dgvReporte.Columns["MinutosFaltantes"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvReporte.Columns["MinutosFaltantes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReporte.Columns["MinutosFaltantes"].DisplayIndex = 7;

            this.dgvReporte.Columns["HoraEntradaParcialStr"].Visible = true;
            this.dgvReporte.Columns["HoraEntradaParcialStr"].HeaderText = "Entrada Parcial";
            this.dgvReporte.Columns["HoraEntradaParcialStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvReporte.Columns["HoraEntradaParcialStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReporte.Columns["HoraEntradaParcialStr"].DisplayIndex = 8;

            this.dgvReporte.Columns["MinutosTardeExtensionStr"].Visible = true;
            this.dgvReporte.Columns["MinutosTardeExtensionStr"].HeaderText = "Tardanza";
            this.dgvReporte.Columns["MinutosTardeExtensionStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvReporte.Columns["MinutosTardeExtensionStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReporte.Columns["MinutosTardeExtensionStr"].DisplayIndex = 9;

            this.dgvReporte.Columns["HoraSalidaStr"].Visible = true;
            this.dgvReporte.Columns["HoraSalidaStr"].HeaderText = "Salida";
            this.dgvReporte.Columns["HoraSalidaStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvReporte.Columns["HoraSalidaStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReporte.Columns["HoraSalidaStr"].DisplayIndex = 10;

            this.dgvReporte.Columns["MinutosFaltantesExtension"].Visible = true;
            this.dgvReporte.Columns["MinutosFaltantesExtension"].HeaderText = "Faltante";
            this.dgvReporte.Columns["MinutosFaltantesExtension"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvReporte.Columns["MinutosFaltantesExtension"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReporte.Columns["MinutosFaltantesExtension"].DisplayIndex = 11;
        }

        private void ActualizarAgentes()
        {
            if (cmbArea.SelectedItem == null || cmbDireccion.SelectedItem == null) {
                _listaAgentes = new List<AgenteDTO>();
                dgvAgentes.DataSource = _listaAgentes;
                dgvReporte.DataSource = _reporteServicio.ObtenerPorId(_agenteSeleccionado.Id);
                CargarAutoComplete(true);
            }
            else
            {
                _listaAgentes = _agenteServicio.ObtenerPorFiltro(((SubSectorDTO)cmbArea.SelectedItem).Descripcion);
                dgvAgentes.DataSource = _listaAgentes;
                CargarAutoComplete();
            }

            FormatearGrillaAgentes(dgvAgentes);
        }

        private void ActualizarReporte()
        {
            if (_agenteSeleccionado == null || _filaAgente == -1)
            {
                lblApyNom.Text = String.Empty;
                lblLegajo.Text = String.Empty;
            }
            else
            {
                lblApyNom.Text = _agenteSeleccionado.ApyNom;
                lblLegajo.Text = _agenteSeleccionado.Legajo;
            }

            dgvReporte.DataSource = _reporteServicio.ObtenerPorId(_agenteSeleccionado.Id);
            FormatearGrillaReporte(dgvReporte);

            if (_reporteAgenteSeleccionado.Any())
            {
                if (_reporteAgenteSeleccionado.First().Novedades.Any())
                {
                    dgvNovedades.DataSource = _reporteAgenteSeleccionado.First().Novedades.ToList();
                }

                if (_reporteAgenteSeleccionado.First().Comisiones.Any())
                {
                    dgvComisiones.DataSource = _reporteAgenteSeleccionado.First().Comisiones.ToList();
                }

                if (_reporteAgenteSeleccionado.First().Lactancias.Any())
                {
                    dgvLactancias.DataSource = _reporteAgenteSeleccionado.First().Lactancias.ToList();
                }
            }
        }

        public void CargarComboBox(ComboBox cmb, object lista, string propiedadMostrar, string propiedadDevolver = "Id")
        {
            cmb.DataSource = lista;
            cmb.DisplayMember = propiedadMostrar;
            cmb.ValueMember = propiedadDevolver;
        }

        public void CargarAutoComplete(bool vacio = false)
        {
            List<string> datos = new List<string>();

            txtBuscar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();

            if (!vacio)
            {
                coleccion.AddRange(_listaAgentes.Select(agente => agente.ApyNom).ToArray());
                coleccion.AddRange(_listaAgentes.Select(agente => agente.Legajo).ToArray());
            }

            txtBuscar.AutoCompleteCustomSource = coleccion;
        }

        public AgenteDTO BuscarAgente(object busqueda, string criterio)
        {
            foreach (var agente in _listaAgentes)
            {
                if (agente.GetType().GetProperty(criterio).GetValue(agente, null).ToString() == busqueda.ToString()) return agente;
            }

            return null;
        }

        private DateTime MesReporte()
        {
            int day = 1;
            int month = DateTime.ParseExact((string)cmbMes.SelectedItem, "MMMM", new CultureInfo("es-Ar")).Month;
            int year = (int)cmbAño.SelectedItem;

            return new DateTime(year, month, day);
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                foreach (DataGridViewRow row in dgvAgentes.Rows)
                {
                    if ((row.Cells["ApyNom"].Value.ToString().ToLower() == txtBuscar.Text.ToLower()) || (row.Cells["Legajo"].Value.ToString().ToLower() == txtBuscar.Text.ToLower()))
                    {
                        dgvAgentes.CurrentCell = row.Cells["Legajo"];
                        txtBuscar.Clear();
                        dgvAgentes.Focus();
                    }
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _00021_ReporteMensual_Load(object sender, EventArgs e)
        {
            try
            {
                _listaAños = ReporteMensualServicio.ListaAños();
                _listaMeses = ReporteMensualServicio.ListaMeses();
            }
            catch
            {
                MessageBox.Show("No hay accesos en la base de datos");
                Close();
            }

            cmbAño.DataSource = _listaAños;
            cmbMes.DataSource = _listaMeses;

            try
            {
                CargarComboBox(this.cmbDireccion, _sectorServicio.ObtenerTodo(), "Descripcion");
                CargarComboBox(this.cmbArea, _subsectorServicio.ObtenerTodo(((SectorDTO)cmbDireccion.SelectedItem).Id), "Descripcion");
            }
            catch
            {
                MessageBox.Show("No hay sectores o subsectores en la base de datos");
                Close();
            }

            lblApyNom.Text = String.Empty;
            lblLegajo.Text = String.Empty;

            this.txtBuscar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

            try
            {
                _agenteSeleccionado = _agenteServicio.ObtenerTodo().First();
            }
            catch
            {
                MessageBox.Show("No hay agentes en la base de datos");
                Close();
            }

            ActualizarAgentes();
        }
   

        private void cmbArea_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ActualizarAgentes();
        }

        private void cmbDireccion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarComboBox(this.cmbArea, _subsectorServicio.ObtenerTodo(((SectorDTO)cmbDireccion.SelectedItem).Id), "Descripcion");
            ActualizarAgentes();
        }

        private void dgvAgentes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAgentes.RowCount > 0) {
                _filaAgente = e.RowIndex;
                _agenteSeleccionado = (AgenteDTO)dgvAgentes.Rows[_filaAgente].DataBoundItem;

                _reporteServicio = new ReporteMensualServicio(_agenteSeleccionado.Id, MesReporte());
                _reporteAgenteSeleccionado = _reporteServicio.ObtenerPorId(_agenteSeleccionado.Id);

                ActualizarReporte();
            }
            else
            {
                _filaAgente = -1;
                _agenteSeleccionado = null;
            }          
        }
    }
}
