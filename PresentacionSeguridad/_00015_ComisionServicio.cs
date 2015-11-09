using Servicio.RecursoHumano.Agente;
using Servicio.RecursoHumano.ComisionServicio;
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
    public partial class _00015_ComisionServicio : PresentacionBase.FormularioBase
    {
        private IComisionServicio _comisionServicio;
        private IAgenteServicio _agenteServicio;
        public long AgenteId { get; set; }

        public _00015_ComisionServicio()
        {
            InitializeComponent();
        }
        public _00015_ComisionServicio(string titulo) : this()
        {
            this.Text = titulo;
            _comisionServicio = new ComisionServicio();
            _agenteServicio = new AgenteServicio();
        }


        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgvGrilla);

            this.dgvGrilla.Columns["Descripcion"].Visible = true;
            this.dgvGrilla.Columns["Descripcion"].HeaderText = "Descripción";
            this.dgvGrilla.Columns["Descripcion"].Width = 111;
            this.dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvGrilla.Columns["Descripcion"].DisplayIndex = 1;

            this.dgvGrilla.Columns["FechaDesdeStr"].Visible = true;
            this.dgvGrilla.Columns["FechaDesdeStr"].HeaderText = "Desde";
            this.dgvGrilla.Columns["FechaDesdeStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvGrilla.Columns["FechaDesdeStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvGrilla.Columns["FechaHastaStr"].Visible = true;
            this.dgvGrilla.Columns["FechaHastaStr"].HeaderText = "Hasta";
            this.dgvGrilla.Columns["FechaHastaStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvGrilla.Columns["FechaHastaStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvGrilla.Columns["HoraInicioStr"].Visible = true;
            this.dgvGrilla.Columns["HoraInicioStr"].HeaderText = "Entrada";
            this.dgvGrilla.Columns["HoraInicioStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvGrilla.Columns["HoraInicioStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvGrilla.Columns["HoraFinStr"].Visible = true;
            this.dgvGrilla.Columns["HoraFinStr"].HeaderText = "Salida";
            this.dgvGrilla.Columns["HoraFinStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvGrilla.Columns["HoraFinStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvGrilla.Columns["JornadaCompletaStr"].Visible = true;
            this.dgvGrilla.Columns["JornadaCompletaStr"].HeaderText = "Jornada Completa";
            this.dgvGrilla.Columns["JornadaCompletaStr"].Width = 111;
            this.dgvGrilla.Columns["JornadaCompletaStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvGrilla.Columns["Observaciones"].Visible = true;
            this.dgvGrilla.Columns["Observaciones"].HeaderText = "Observaciones";
            this.dgvGrilla.Columns["Observaciones"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvGrilla.Columns["Observaciones"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNuevaComsion_Click(object sender, EventArgs e)
        {
            var formABM = new _00016_ABM_ComisionServicio("Modificar Comisiones de Servicio");
            formABM.AgenteId = AgenteId;
            formABM.ShowDialog();
            Actualizar();
        }

        private void _00015_ComisionServicio_Load(object sender, EventArgs e)
        {
            var _agente = _agenteServicio.ObtenerPorId(AgenteId);
            this.lblApyNom.Text = _agente.Apellido + ", " + _agente.Nombre;
            this.lblDNI.Text = string.Format("{0:##0,000,000}", Int32.Parse(_agente.DNI));
            this.lblLegajo.Text = string.Format("{0:###,000}", Int32.Parse(_agente.Legajo));

            Actualizar();
        }

        private void Actualizar()
        {
            this.dgvGrilla.DataSource = _comisionServicio.ObtenerPorFiltro(AgenteId);
            FormatearGrilla(this.dgvGrilla);
        }
    }
}
