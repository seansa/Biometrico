using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.RecursoHumano.RelojDefectuoso.DTOs
{
    public class RelojDefectuosoDTO
    {
        public long IdAgente { get; set; }
        public long IdHorario { get; set; }
        public string Nombre { get; set; }
        public bool RelojDefectuosoEntrada { get; set; }
        public bool RelojDefectuosoSalidaParcial { get; set; }
        public bool RelojDefectuosoEntradaParcial { get; set; }
        public bool RelojDefectuosoSalida { get; set; }
        public bool JornadaCompleta { get; set; }
    }
}
