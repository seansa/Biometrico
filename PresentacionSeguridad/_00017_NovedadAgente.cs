using Servicio.RecursoHumano.Agente;
using Servicio.RecursoHumano.Agente.DTOs;
using Servicio.RecursoHumano.TipoNovedadAgente;
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
    public partial class _00017_NovedadAgente : PresentacionBase.FormularioBase
    {
        private readonly IAgenteServicio _agenteServicio;
        TipoNovedadAgenteServicio _tipoNovedadAgente;

        public _00017_NovedadAgente()
        {
            _agenteServicio = new AgenteServicio();
            InitializeComponent();
            _tipoNovedadAgente = new TipoNovedadAgenteServicio();
            PoblarGrilla();
            FormatearGrilla(this.dgvNovedadAgente);
            PoblarComboBox(this.cmbTipoNovedadAgente, _tipoNovedadAgente.ObtenerTodo(), "Descripcion");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }
        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Legajo"].Visible = true;
            dgv.Columns["Legajo"].HeaderText = "Legajo";
            dgv.Columns["Legajo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Legajo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["ApyNom"].Visible = true;
            dgv.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["ApyNom"].HeaderText = "Apellido y Nombre";
            dgv.Columns["ApyNom"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns["ApyNom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["DNI"].Visible = true;
            dgv.Columns["DNI"].HeaderText = "Nro Documento";
            dgv.Columns["DNI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns["DNI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        public void PoblarGrilla()
        {
            var resultado = _agenteServicio.ObtenerTodo();
            this.dgvNovedadAgente.DataSource = resultado.ToList();
        }

        private void btnTipoNovedad_Click(object sender, EventArgs e)
        {
            var _formulario = new _00019_ABM_TipoNovedadAgente();
            _formulario.TipoOperacion = PresentacionBase.TipoOperacion.Insertar;
            _formulario.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvNovedadAgente_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvNovedadAgente.RowCount > 0)
            {
                var _id = (long)this.dgvNovedadAgente["Id",e.RowIndex].Value;
                var agente = _agenteServicio.ObtenerPorId(_id);
                this.txtApyNom.Text = agente.Apellido + " " + agente.Nombre;
                this.txtLegajo.Text = agente.Legajo;
            }
        }
    }
}
