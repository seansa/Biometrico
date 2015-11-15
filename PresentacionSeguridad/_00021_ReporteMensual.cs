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

        public _00021_ReporteMensual()
        {
            InitializeComponent();
            _agenteServicio = new AgenteServicio();
            _reporteServicio = new ReporteMensualServicio();
            _sectorServicio = new SectorServicio();
            _subsectorServicio = new SubSectorServicio();
            _listaAños = _reporteServicio.ListaAños();
            _listaMeses = _reporteServicio.ListaMeses();
        }

        public _00021_ReporteMensual(string titulo) : this()
        {
            Text = titulo;
        }

        public void FormatearGrillas(DataGridView dgvAgentes, DataGridView dgvReporte, DataGridView dgvDetalles)
        {
            base.FormatearGrilla(dgvAgentes);
            base.FormatearGrilla(dgvReporte);
            base.FormatearGrilla(dgvDetalles);

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

        private void Actualizar()
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

            FormatearGrillas(dgvAgentes, dgvReporte, dgvDetalles);
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

            Actualizar();
        }

        private void cmbArea_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Actualizar();
            
        }

        private void cmbDireccion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarComboBox(this.cmbArea, _subsectorServicio.ObtenerTodo(((SectorDTO)cmbDireccion.SelectedItem).Id), "Descripcion");
            Actualizar();
        }
    }
}
