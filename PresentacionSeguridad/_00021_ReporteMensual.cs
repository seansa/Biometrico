using Servicio.RecursoHumano.Agente;
using Servicio.RecursoHumano.Agente.DTOs;
using Servicio.RecursoHumano.Reportes;
using Servicio.RecursoHumano.Sector;
using Servicio.RecursoHumano.Sector.DTOs;
using Servicio.RecursoHumano.SubSector;
using Servicio.RecursoHumano.SubSector.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PresentacionRecursoHumano
{
    public partial class _00021_ReporteMensual : PresentacionBase.FormularioBase
    {
        private readonly IAgenteServicio _agenteServicio;
        private readonly IReporteMensualServicio _reporteServicio;
        private readonly ISectorServicio _sectorServicio;
        private readonly ISubSectorServicio _subsectorServicio;
        private List<int> _listaAños;
        private List<string> _listaMeses;
        private IEnumerable<AgenteDTO> _listaAgentes;
        private AgenteDTO _agenteSeleccionado;
        private int _filaAgente;

        public _00021_ReporteMensual()
        {
            InitializeComponent();
            _agenteServicio = new AgenteServicio();
            _reporteServicio = new ReporteMensualServicio();
            _sectorServicio = new SectorServicio();
            _subsectorServicio = new SubSectorServicio();
            _listaAños = _reporteServicio.ListaAños();
            _listaMeses = _reporteServicio.ListaMeses();
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
            base.FormatearGrilla(dgvAgentes);

            this.dgvReporte.Columns["Numero"].Visible = true;
            this.dgvReporte.Columns["Numero"].HeaderText = "Nº";
            this.dgvReporte.Columns["Numero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvReporte.Columns["Numero"].DisplayIndex = 1;
                    
            this.dgvReporte.Columns["FechaShortStr"].Visible = true;
            this.dgvReporte.Columns["FechaShortStr"].HeaderText = "Fecha";
            this.dgvReporte.Columns["FechaShortStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvReporte.Columns["FechaShortStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvReporte.Columns["Ausente"].Visible = true;
            this.dgvReporte.Columns["Ausente"].HeaderText = "Ausente";
            this.dgvReporte.Columns["Ausente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvReporte.Columns["Ausente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvReporte.Columns["HoraEntrada"].Visible = true;
            this.dgvReporte.Columns["HoraEntrada"].HeaderText = "Entrada";
            this.dgvReporte.Columns["HoraEntrada"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvReporte.Columns["HoraEntrada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvReporte.Columns["HoraSalidaParcial"].Visible = true;
            this.dgvReporte.Columns["HoraSalidaParcial"].HeaderText = "Salida Pcial";
            this.dgvReporte.Columns["HoraSalidaParcial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvReporte.Columns["HoraSalidaParcial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvReporte.Columns["MinutosTarde"].Visible = true;
            this.dgvReporte.Columns["MinutosTarde"].HeaderText = "Tarde";
            this.dgvReporte.Columns["MinutosTarde"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvReporte.Columns["MinutosTarde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvReporte.Columns["MinutosFaltantes"].Visible = true;
            this.dgvReporte.Columns["MinutosFaltantes"].HeaderText = "Falta";
            this.dgvReporte.Columns["MinutosFaltantes"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvReporte.Columns["MinutosFaltantes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvReporte.Columns["HoraEntradaParcial"].Visible = true;
            this.dgvReporte.Columns["HoraEntradaParcial"].HeaderText = "Entrada Pcial";
            this.dgvReporte.Columns["HoraEntradaParcial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvReporte.Columns["HoraEntradaParcial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvReporte.Columns["HoraSalida"].Visible = true;
            this.dgvReporte.Columns["HoraSalida"].HeaderText = "Salida";
            this.dgvReporte.Columns["HoraSalida"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvReporte.Columns["HoraSalida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvReporte.Columns["MinutosTardeExtension"].Visible = true;
            this.dgvReporte.Columns["MinutosTardeExtension"].HeaderText = "Tarde";
            this.dgvReporte.Columns["MinutosTardeExtension"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvReporte.Columns["MinutosTardeExtension"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvReporte.Columns["MinutosFaltantesExtension"].Visible = true;
            this.dgvReporte.Columns["MinutosFaltantesExtension"].HeaderText = "Falta";
            this.dgvReporte.Columns["MinutosFaltantesExtension"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvReporte.Columns["MinutosFaltantesExtension"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void ActualizarAgentes()
        {
            if (cmbArea.SelectedItem == null || cmbDireccion.SelectedItem == null) {
                _listaAgentes = new List<AgenteDTO>();
                dgvAgentes.DataSource = _listaAgentes;
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

            FormatearGrillaAgentes(dgvAgentes);
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
            cmbAño.DataSource = _listaAños;
            cmbMes.DataSource = _listaMeses;

            CargarComboBox(this.cmbDireccion, _sectorServicio.ObtenerTodo(), "Descripcion");
            CargarComboBox(this.cmbArea, _subsectorServicio.ObtenerTodo(((SectorDTO)cmbDireccion.SelectedItem).Id), "Descripcion");

            this.txtBuscar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

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
