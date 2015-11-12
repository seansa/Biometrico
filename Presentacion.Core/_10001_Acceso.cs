using AccesoDatos;
using Servicio.Core.Acces;
using Servicio.RecursoHumano.Agente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core
{
    public partial class _10001_Acceso : PresentacionBase.FormularioBase

    {

        private IAgenteServicio _agenteServicio;
        private IAccesoServicio _accesoServicio;
        private TipoAcceso _tipoAcceso;
        private long _agenteId;
        private Dictionary<TipoAcceso, string> _diccionario;
        public _10001_Acceso()
        {
            InitializeComponent();
            _agenteServicio = new AgenteServicio();
            _accesoServicio = new AccesoServicio();
            _tipoAcceso = new TipoAcceso();
            _diccionario = new Dictionary<TipoAcceso, string>();
            Inicializador.InicializadorAccesos.CargarAccesos(ref _diccionario);
            _agenteId = -1;
        }
        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);
            this.dgvAgentes.Columns["Legajo"].Visible = true;
            this.dgvAgentes.Columns["ApyNom"].Visible = true;
            this.dgvAgentes.Columns["DNI"].Visible = true;
            this.dgvAgentes.Columns["ApyNom"].HeaderText = "Apellido y Nombre";
        }
        private void Actualizar()
        {
            this.dgvAgentes.DataSource = _agenteServicio.ObtenerPorFiltro(string.Empty);
            FormatearGrilla(this.dgvAgentes);

            this.cmbTipoAcceso.DataSource = _diccionario.Values.ToList();
            
        }

        private void _10001_Acceso_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            _tipoAcceso = _diccionario.First(x => x.Value == this.cmbTipoAcceso.SelectedValue.ToString()).Key;
           
                _accesoServicio.Insertar(_agenteId, this.dtpHoraAcceso.Value, _tipoAcceso, "2");
            
        }

        private void dgvAgentes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvAgentes.RowCount>0)
            {
                _agenteId = Convert.ToInt64(this.dgvAgentes["Id", e.RowIndex].Value);
            }
            else
            {
                _agenteId = -1;
            }

        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            this.dtpHoraAcceso.Value = this.dtpFecha.Value.Date;
        }
    }
}
