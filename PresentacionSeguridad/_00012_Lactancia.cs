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
        public _00012_Lactancia()
        {
            InitializeComponent();
            _lactanciaServicio = new LactanciaServicio();
           


        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);
            this.dgvLactancia.Columns["FechaDesdeStr"].Visible = false;
            this.dgvLactancia.Columns["FechaHastaStr"].Visible = false;
            this.dgvLactancia.Columns["HoraInicioStr"].Visible = false;
            this.dgvLactancia.Columns["LunesStr"].Visible = false;
            this.dgvLactancia.Columns["MartesStr"].Visible = false;
            this.dgvLactancia.Columns["MiercolesStr"].Visible = false;
            this.dgvLactancia.Columns["JuevesStr"].Visible = false;
            this.dgvLactancia.Columns["ViernesStr"].Visible = false;
            this.dgvLactancia.Columns["SabadoStr"].Visible = false;
            this.dgvLactancia.Columns["DomingoStr"].Visible = false;
            this.dgvLactancia.Columns["FechaActualizacionStr"].Visible = false;
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
            Actualizar();
        }

        private void Actualizar()
        {
            this.dgvLactancia.DataSource = _lactanciaServicio.ObtenerTodo();
            FormatearGrilla(this.dgvLactancia);
        }
    }
}
