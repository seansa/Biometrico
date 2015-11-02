using Servicio.RecursoHumano.Agente;
using Servicio.RecursoHumano.Lactancia;
using Servicio.RecursoHumano.Lactancia.DTOs;
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
    public partial class _00014_ABM_Lactancia : PresentacionBase.FormularioBase
    {
        public long AgenteId { get; set; }
        private IAgenteServicio _agenteServicio;
        private ILactanciaServicio _lactanciaServicio;
        private List<LactanciaDTO> _listaLactancia;
        private LactanciaDTO _lactanciaSeleccionada;
        public _00014_ABM_Lactancia()
        {
            InitializeComponent();
            _agenteServicio = new AgenteServicio();
            _lactanciaServicio = new LactanciaServicio();
            _listaLactancia = new List<LactanciaDTO>();
            _lactanciaSeleccionada = new LactanciaDTO();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _00014_ABM_Lactancia_Load(object sender, EventArgs e)
        {
            var _agente = _agenteServicio.ObtenerPorId(AgenteId);
            this.txtApyNom.Text = _agente.Apellido + ", " + _agente.Nombre;
            this.txtLegajo.Text = _agente.Legajo;
            this.txtDni.Text = _agente.DNI;

        }
        private void Actualizar()
        {
            this.dgvLactancia.DataSource = _listaLactancia.ToList();
            FormatearGrilla(this.dgvLactancia);
        }
        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);
            this.dgvLactancia.Columns["FechaDesdeStr"].Visible = true;
            this.dgvLactancia.Columns["FechaHastaStr"].Visible = true;
            this.dgvLactancia.Columns["HoraInicioStr"].Visible = true;
            this.dgvLactancia.Columns["LunesStr"].Visible = true;
            this.dgvLactancia.Columns["MartesStr"].Visible = true;
            this.dgvLactancia.Columns["MiercolesStr"].Visible = true;
            this.dgvLactancia.Columns["JuevesStr"].Visible = true;
            this.dgvLactancia.Columns["ViernesStr"].Visible = true;
            this.dgvLactancia.Columns["SabadoStr"].Visible = true;
            this.dgvLactancia.Columns["DomingoStr"].Visible = true;
            this.dgvLactancia.Columns["FechaActualizacionStr"].Visible = true;
            this.dgvLactancia.Columns["FechaDesdeStr"].HeaderText = "Fecha Desde";
            this.dgvLactancia.Columns["FechaHastaStr"].HeaderText = "Fecha Hasta";
            this.dgvLactancia.Columns["HoraInicioStr"].HeaderText = "Hora Inicio";
            this.dgvLactancia.Columns["LunesStr"].HeaderText = "Lunes";
            this.dgvLactancia.Columns["MartesStr"].HeaderText = "Martes";
            this.dgvLactancia.Columns["MiercolesStr"].HeaderText = "Miercoles";
            this.dgvLactancia.Columns["JuevesStr"].HeaderText = "Jueves";
            this.dgvLactancia.Columns["ViernesStr"].HeaderText = "Viernes";
            this.dgvLactancia.Columns["SabadoStr"].HeaderText = "Sabado";
            this.dgvLactancia.Columns["DomingoStr"].HeaderText = "Domingo";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var _nuevaLactancia = new LactanciaDTO()
            {
                AgenteId = AgenteId,
                FechaDesde = this.dtpFechaDesde.Value,
                FechaHasta = this.dtpFechaHasta.Value,
                HoraInicio = this.dtpHoraInicio.Value.TimeOfDay,
                Lunes=this.chkLunes.Checked,
                Martes=this.chkMartes.Checked,
                Miercoles=this.chkMiercoles.Checked,
                Jueves=this.chkJueves.Checked,
                Viernes=this.chkViernes.Checked,
                Sabado=this.chkSabado.Checked,
                Domingo=this.chkDomingo.Checked
            };
            _listaLactancia.Add(_nuevaLactancia);
            LimpiarControles(this.pnlDias);
            LimpiarControles(this.pnlFechas);
            Actualizar();
        }
        public override void LimpiarControles(object obj)
        {
            base.LimpiarControles(obj);
        }

        private void btnMarcarSemana_Click(object sender, EventArgs e)
        {
            this.chkLunes.Checked = true;
            this.chkMartes.Checked = true;
            this.chkMiercoles.Checked = true;
            this.chkJueves.Checked = true;
            this.chkViernes.Checked = true;
            
        }

        private void btnDesmarcar_Click(object sender, EventArgs e)
        {
            this.chkLunes.Checked = false;
            this.chkMartes.Checked = false;
            this.chkMiercoles.Checked = false;
            this.chkJueves.Checked = false;
            this.chkViernes.Checked = false;
            this.chkSabado.Checked = false;
            this.chkDomingo.Checked = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            _listaLactancia.RemoveAt(this.dgvLactancia.CurrentRow.Index);
            Actualizar();
        }

        private void dgvLactancia_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

                //{
        //    if (this.dgvLactancia.RowCount>0)
        //    {
        //        _lactanciaSeleccionada = (LactanciaDTO)this.dgvLactancia.Rows.[e.RowIndex].
        //    }
        //    else
        //    {
        //        _lactanciaSeleccionada =(LactanciaDTO)null;
        //    }
        }
    }
}
