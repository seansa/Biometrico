using Servicio.RecursoHumano.Agente;
using Servicio.RecursoHumano.Lactancia;
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
    public partial class _00012_Lactancia : PresentacionBase.FormularioBase
    {
        private ILactanciaServicio _lactanciaServicio;
        private IAgenteServicio _agenteServicio;
        public long AgenteId { get; set; }
        public _00012_Lactancia()
        {
            InitializeComponent();
            _lactanciaServicio = new LactanciaServicio();
            _agenteServicio = new AgenteServicio();


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

        private void _00012_Lactancia_Load(object sender, EventArgs e)
        {

          
                var _agente = _agenteServicio.ObtenerPorId(AgenteId);
                this.txtApyNom.Text = _agente.Apellido + ", " + _agente.Nombre;
                this.txtDni.Text = _agente.DNI;
                this.txtLegajo.Text = _agente.Legajo; 
            
            Actualizar();
        }

        private void Actualizar()
        {
            this.dgvLactancia.DataSource = _lactanciaServicio.ObtenerPorFiltro(AgenteId);
            FormatearGrilla(this.dgvLactancia);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var _formulario = new _00014_ABM_Lactancia();
            _formulario.AgenteId = AgenteId;
            _formulario.ShowDialog();
            Actualizar();
       }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
