using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.RecursoHumano.ComisionServicio.DTOs
{
    public class ComisionServicioDTO
    {
        public long Id { get; set; }
        public long AgenteId { get; set; }
        public DateTime FechaDesde { get; set; }
        public string FechaDesdeStr { get { return FechaDesde.ToShortDateString(); } }
        public DateTime? FechaHasta { get; set; }
        public string FechaHastaStr { get { return ((DateTime?)FechaHasta) == null ? "-" : ((DateTime)FechaHasta).ToShortDateString(); } }
        public TimeSpan? HoraInicio { get; set; }
        public string HoraInicioStr { get { return HoraInicio == null ? "-" : String.Format("{0:hh\\:mm}", HoraInicio); } }
        public TimeSpan? HoraFin { get; set; }
        public string HoraFinStr { get { return HoraFin == null ? "-" : String.Format("{0:hh\\:mm}", HoraFin); } }
        public bool JornadaCompleta { get; set; }
        public string JornadaCompletaStr { get { return JornadaCompleta ? "Sí" : "No"; } }
        public string Observaciones { get; set; }
        public string Descripcion { get; set; }
    }
}
