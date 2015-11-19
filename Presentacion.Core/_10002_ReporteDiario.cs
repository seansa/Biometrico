using iTextSharp.text;
using iTextSharp.text.pdf;
using Servicio.Core.Reporte;
using Servicio.Core.Reporte.ReporteDiarioDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

            lista = _reporteServicio.FiltrarAgenteDTO(this.dateTimePicker1.Value.Date);

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

        private void btnReporte_Click(object sender, EventArgs e)
        {
            VisualizarReporte();
        }
        private void VisualizarReporte()
        {
            FileStream fs = new FileStream(Environment.CurrentDirectory + @"\reportediario.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.A4.Rotate());
            Document doc = new Document(rec);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            string HTML = "<table  width='100%' border='0'><tr align='center' color = '#424242'>" +
                "<td><h3>Presentes: " + this.nudPresentes.Value.ToString() + "</h3></td>" +
                "<td><h3>Ausentes: " + this.nudAusentes.Value.ToString() + "</h3></td>" +
                 "<td><h3>Tarde: " + this.nudTarde.Value.ToString() + "</h3></td>" +
                "</tr></table>";
            HTML += "<table  width='100%' border='1'><tr color = 'white' bgcolor='black'><td><h2><div align ='center'>REPORTE DIARIO DE AGENTES DEL " + this.dateTimePicker1.Value.ToShortDateString() + "</div></h2></td></tr>" +
                "</table><table width='100%' border='1' color='black'>";
            string header = " <tr align = 'center' color ='white' bgcolor ='#424242'> <td >Legajo</td>" +
               "    <td>Apellido</td>" +
              "     <td>Nombre</td>  " +
              "     <td>Tardanza</td>  " +
              "     <td>J.Incomp.</td>  " +
              "     <td>Ausente</td>  " +
              "     <td>Lactancia</td>  " +
              "     <td>Comision</td>  " +
              "     <td>Novedad</td>  " +
              "     <td>Reloj</td>  " +
              "     <td>OK</td>  " +

               "</tr>";
            HTML += header;
            foreach (var linea in lista)
            {
                HTML += " <tr align = 'center' ><td>" + linea.Legajo + "</td>" +
                "    <td>" + linea.Apellido + "</td>" +
                "    <td>" + linea.Nombre + "</td>" +
                "     <td>" + linea.Tarde + " </td>  " +
                "     <td>" + linea.JornadaIncompleta + " </td>  " +
                "     <td>" + linea.Ausente + " </td>  " +
                "     <td>" + linea.Lact + " </td>  " +
                "     <td>" + linea.Comision + " </td>  " +
                "     <td>" + linea.Nov + " </td>  " +
                "     <td>" + linea.Reloj + " </td>  " +
                "     <td>" + linea.EstaOK + " </td>  " +

                "</tr>";
            }


            HTML += "</table>";



            var htmlWorker = new iTextSharp.text.html.simpleparser.HTMLWorker(doc);
            doc.Open();
            htmlWorker.Parse(new StringReader(HTML));
            doc.Close();

            // ejecutar archivo pdf
            System.Diagnostics.Process proceso = new System.Diagnostics.Process();
            proceso.StartInfo.FileName = "reportediario.pdf";
            proceso.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
            proceso.Start();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.ColumnIndex == this.dataGridView1.Columns["Comision"].Index) && (string)e.Value != null)
            {
                if ((string)e.Value == "SI")
                {

                    ReporteDiarioDTO reporte = new ReporteDiarioDTO();
                    reporte = (ReporteDiarioDTO)this.dataGridView1.Rows[e.RowIndex].DataBoundItem;

                    DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.ToolTipText = reporte._comision.Descripcion+"\n"+reporte._comision.Observacion;
                }
                if ((e.ColumnIndex == this.dataGridView1.Columns["Nov"].Index) && (string)e.Value != null)
                {
                    if ((string)e.Value == "SI")
                    {

                        ReporteDiarioDTO reporte = new ReporteDiarioDTO();
                        reporte = (ReporteDiarioDTO)this.dataGridView1.Rows[e.RowIndex].DataBoundItem;

                        DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        cell.ToolTipText = reporte._novedad.Observacion;
                    }
                }
                if ((e.ColumnIndex == this.dataGridView1.Columns["Lact"].Index) && (string)e.Value != null)
                {
                    if ((string)e.Value == "SI")
                    {

                        ReporteDiarioDTO reporte = new ReporteDiarioDTO();
                        reporte = (ReporteDiarioDTO)this.dataGridView1.Rows[e.RowIndex].DataBoundItem;

                        DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                        cell.ToolTipText = reporte._lactancia.HoraInicio ? "Lactancia al comienzo de la jornada" : "Lactancia al final de la jornada";
                    }

                }
            }
        }
    }

}
