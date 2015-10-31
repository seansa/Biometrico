using Servicio.RecursoHumano.Sector;
using System.Linq;
using System.Windows.Forms;

namespace PresentacionRecursoHumano
{
    public partial class _00001_Sectores : PresentacionBase.FormularioConsulta
    {
        private readonly ISectorServicio _sectorServicio;

        public _00001_Sectores()
            :base("Consulta de Sectores", "Lista de Sectores",new _00002_ABM_Sector())
        {
            InitializeComponent();

            _sectorServicio = new SectorServicio();
            this.btnImprimir.Visible = false;
            this.WindowState = FormWindowState.Maximized;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        public override void Actualizar(string cadenaBuscar)
        {
            var resultado = _sectorServicio.ObtenerPorFiltro(cadenaBuscar);
            this.dgvGrilla.DataSource = resultado.ToList();

            FormatearGrilla(this.dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Codigo"].Visible = true;
            dgv.Columns["Codigo"].Width = 100;
            dgv.Columns["Codigo"].HeaderText = "Código";
            dgv.Columns["Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Codigo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].HeaderText = "Descripción";
            dgv.Columns["Descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["CantidadSubGrupos"].Visible = true;
            dgv.Columns["CantidadSubGrupos"].Width = 150;
            dgv.Columns["CantidadSubGrupos"].HeaderText = "Sub-Sectores";
            dgv.Columns["CantidadSubGrupos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["CantidadSubGrupos"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }    
}
