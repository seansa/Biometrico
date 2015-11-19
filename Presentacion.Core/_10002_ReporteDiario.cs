using iTextSharp.text;
using iTextSharp.text.pdf;
using Servicio.Core.Reporte;
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
    public partial class _10002_ReporteDiario : Form
    {
        private IReporteServicio _reporteServicio;
        private List<Servicio.Core.Reporte.ReporteDiarioDTO.ReporteDiarioDTO> lista;
        public _10002_ReporteDiario()
        {
            InitializeComponent();
            _reporteServicio = new ReporteServicio();
            lista = new List<Servicio.Core.Reporte.ReporteDiarioDTO.ReporteDiarioDTO>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
             lista= _reporteServicio.FiltrarAgenteDTO(this.dateTimePicker1.Value.Date);
            this.dataGridView1.DataSource = lista;

            this.nudAusentes.Value = lista.Count(x => x.Ausente == "SI");
            this.nudPresentes.Value = Convert.ToDecimal(lista.Count(x => x.Ausente != "SI"));
            this.nudTarde.Value = Convert.ToDecimal(lista.Count(x => x.Tarde == "SI"));
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(Environment.CurrentDirectory + @"\reportediario.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.A4.Rotate());
            Document doc = new Document(rec);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            string HTML= "<table  width='100%' border='0'><tr align='center' color = '#424242'>" +
                "<td><h3>Presentes: "+this.nudPresentes.Value.ToString()+"</h3></td>" +
                "<td><h3>Ausentes: " + this.nudAusentes.Value.ToString() + "</h3></td>" +
                 "<td><h3>Tarde: " + this.nudTarde.Value.ToString() + "</h3></td>" +
                "</tr></table>";
            HTML += "<table  width='100%' border='1'><tr color = 'white' bgcolor='black'><td><h2><div align ='center'>REPORTE DIARIO DE AGENTES DEL "+this.dateTimePicker1.Value.ToShortDateString() +"</div></h2></td></tr>" +
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
            


            //HTML += header;
            //for (int i = 0; i < 300; i++)
            //{
            //    if (i == 18) HTML += header;
            //    if ((i - 18) % 20 == 0 && (i - 18) != 0) HTML += header;
            //    HTML += "   <td>" + i + "</td>" +
            //    "    <td>Jackson</td>" +
            //    "     <td>94</td>  " +
            //    "</tr>";

            //}

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
    }
}
