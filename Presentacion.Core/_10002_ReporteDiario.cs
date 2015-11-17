using Servicio.Core.Reporte;
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
    public partial class _10002_ReporteDiario : Form
    {
        private IReporteServicio _reporteServicio;
        public _10002_ReporteDiario()
        {
            InitializeComponent();
            _reporteServicio = new ReporteServicio();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var contadorAusentes = 0;
            var contadorPresentes = 0;
            var contadorTarde = 0;
            var lista= _reporteServicio.FiltrarAgenteDTO(this.dateTimePicker1.Value.Date);
            this.dataGridView1.DataSource = lista;
            foreach (var agente in lista)
            {
                if (agente.Ausente=="SI")
                {
                    contadorAusentes++;
                }
                if (agente.Ausente=="NO")
                {
                    contadorPresentes++;
                }
                if (agente.Tarde=="SI")
                {
                    contadorTarde++;
                }
            }
            this.nudAusentes.Value = Convert.ToDecimal(contadorAusentes);
            this.nudPresentes.Value = Convert.ToDecimal(contadorPresentes);
            this.nudTarde.Value = Convert.ToDecimal(contadorTarde);
        }
    }
}
