using Servicio.RecursoHumano.SubSector;
using System.Linq;
using System.Windows.Forms;

namespace PresentacionRecursoHumano
{
    public partial class _00003_SubSectores : PresentacionBase.FormularioConsulta
    {
        private readonly ISubSectorServicio _subSectorServicio;

        public _00003_SubSectores()
            :base("Consulta de Sub-Sectores", "Lista de Sub-Sectores",new _00004_ABM_SubSector())
        {
            InitializeComponent();

            _subSectorServicio = new SubSectorServicio();
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
            var resultado = _subSectorServicio.ObtenerPorFiltro(cadenaBuscar);
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

            dgv.Columns["Abreviatura"].Visible = true;
            dgv.Columns["Abreviatura"].Width = 70;
            dgv.Columns["Abreviatura"].HeaderText = "Abreviatura";
            dgv.Columns["Abreviatura"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Abreviatura"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].HeaderText = "Descripción";
            dgv.Columns["Descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["Sector"].Visible = true;
            dgv.Columns["Sector"].Width = 200;
            dgv.Columns["Sector"].HeaderText = "Sector";
            dgv.Columns["Sector"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns["Sector"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["CantidadAgentes"].Visible = true;
            dgv.Columns["CantidadAgentes"].Width = 80;
            dgv.Columns["CantidadAgentes"].HeaderText = "Agentes";
            dgv.Columns["CantidadAgentes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["CantidadAgentes"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
