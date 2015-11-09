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
        public _10001_Acceso()
        {
            InitializeComponent();
            _agenteServicio = new AgenteServicio();
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
        }

        private void _10001_Acceso_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

    }
}
