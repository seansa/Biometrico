﻿using Servicio.Core.Reporte;
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

            this.nudAusentes.Value = lista.Count(x => x.Ausente == "SI");
            this.nudPresentes.Value = Convert.ToDecimal(lista.Count(x => x.Ausente != "SI"));
            this.nudTarde.Value = Convert.ToDecimal(lista.Count(x => x.Tarde == "SI"));
        }
    }
}
