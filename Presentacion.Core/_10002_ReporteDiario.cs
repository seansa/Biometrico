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
    public partial class _10002_ReporteDiario : PresentacionBase.FormularioBase
    {
        private IReporteServicio _reporteServicio;
        private List<Servicio.Core.Reporte.ReporteDiarioDTO.ReporteDiarioDTO> lista;
        public _10002_ReporteDiario()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            _reporteServicio = new ReporteServicio();
            lista = new List<Servicio.Core.Reporte.ReporteDiarioDTO.ReporteDiarioDTO>();
            this.dataGridView1.DataSource = lista;
            FormatearGrilla(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
             lista= _reporteServicio.FiltrarAgenteDTO(this.dateTimePicker1.Value.Date);
            
            this.dataGridView1.DataSource = lista;

            this.nudAusentes.Value = lista.Count(x => x.Ausente == "SI");
            this.nudPresentes.Value = Convert.ToDecimal(lista.Count(x => x.Ausente != "SI"));
            this.nudTarde.Value = Convert.ToDecimal(lista.Count(x => x.Tarde == "SI"));
        }
        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);
            this.dataGridView1.Columns["Legajo"].Visible = true;
            this.dataGridView1.Columns["Apellido"].Visible = true;
            this.dataGridView1.Columns["Nombre"].Visible = true;
            this.dataGridView1.Columns["NumeroDia"].Visible = true;
            this.dataGridView1.Columns["NombreDia"].Visible = true;
            this.dataGridView1.Columns["NombreMes"].Visible = true;
            this.dataGridView1.Columns["Anio"].Visible = true;
            this.dataGridView1.Columns["HoraEntradaStr"].Visible = true;
            this.dataGridView1.Columns["HoraSalidaParcialStr"].Visible = true;
            this.dataGridView1.Columns["HoraEntradaParcialStr"].Visible = true;
            this.dataGridView1.Columns["HoraSalidaStr"].Visible = true;
            this.dataGridView1.Columns["MinutsTardeStr"].Visible = true;
            this.dataGridView1.Columns["MinutosFaltantesSTR"].Visible = true;
            this.dataGridView1.Columns["Nov"].Visible = true;
            this.dataGridView1.Columns["Comision"].Visible = true;
            this.dataGridView1.Columns["Lact"].Visible = true;
            this.dataGridView1.Columns["Reloj"].Visible = true;
            this.dataGridView1.Columns["Ausente"].Visible = true;
            this.dataGridView1.Columns["Tarde"].Visible = true;
            this.dataGridView1.Columns["JornadaIncompleta"].Visible = true;
            this.dataGridView1.Columns["EstaOK"].Visible = true;

            this.dataGridView1.Columns["Agente"].HeaderText = "Agente";
            this.dataGridView1.Columns["NumeroDia"].HeaderText = "N°";
            this.dataGridView1.Columns["NombreDia"].HeaderText = "Día";
            this.dataGridView1.Columns["NombreMes"].HeaderText = "Mes";
            this.dataGridView1.Columns["Anio"].HeaderText = "Año";
            this.dataGridView1.Columns["HoraEntradaStr"].HeaderText = "Entrada";
            this.dataGridView1.Columns["HoraSalidaParcialStr"].HeaderText = "Salida P.";
            this.dataGridView1.Columns["HoraEntradaParcialStr"].HeaderText = "Entrada P.";
            this.dataGridView1.Columns["HoraSalidaStr"].HeaderText = "Salida";
            this.dataGridView1.Columns["MinutsTardeStr"].HeaderText = "Min. Tar.";
            this.dataGridView1.Columns["MinutosFaltantesSTR"].HeaderText = "Min. Falt";
            this.dataGridView1.Columns["Nov"].HeaderText = "Nov.";
            this.dataGridView1.Columns["Comision"].HeaderText = "Com.";
            this.dataGridView1.Columns["Lact"].HeaderText = "Lact.";
            this.dataGridView1.Columns["Reloj"].HeaderText = "R. Def.";
            this.dataGridView1.Columns["Ausente"].HeaderText = "Aus.";
            this.dataGridView1.Columns["Tarde"].HeaderText = "Tar.";
            this.dataGridView1.Columns["JornadaIncompleta"].HeaderText = "Incom.";
            this.dataGridView1.Columns["EstaOK"].HeaderText = "OK";



        }
    }
}
