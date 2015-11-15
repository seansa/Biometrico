using Servicio.RecursoHumano.Agente;
using Servicio.RecursoHumano.Reportes;
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
    public partial class _00021_ReporteMensual : PresentacionBase.FormularioBase
    {
        private readonly IAgenteServicio _agenteServicio;
        private readonly IReporteMensualServicio _reporteServicio;
        private List<int> _listaAños;

        public _00021_ReporteMensual()
        {
            InitializeComponent();
            _agenteServicio = new AgenteServicio();
            _reporteServicio = new ReporteMensualServicio();
            _listaAños = _reporteServicio.ListaAños();
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
            this.dgvAgentes.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvAgentes.Columns["ApyNom"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvReporte.Columns["Legajo"].Visible = true;
            this.dgvReporte.Columns["Legajo"].HeaderText = "Legajo";
            this.dgvReporte.Columns["Legajo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvReporte.Columns["Legajo"].DisplayIndex = 1;
                   
            this.dgvReporte.Columns["ApyNom"].Visible = true;
            this.dgvReporte.Columns["ApyNom"].HeaderText = "Apellido y Nombre";
            this.dgvReporte.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvReporte.Columns["ApyNom"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void Actualizar()
        {
            this.dgvAgentes.DataSource = _agenteServicio.ObtenerTodo();
            //FormatearGrilla(this.dgvGrilla);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _00021_ReporteMensual_Load(object sender, EventArgs e)
        {
            cmbAño.DataSource = _listaAños;
            cmbMes.DataSource = _reporteServicio.ListaMeses();
        }
    }
}
