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
        public DateTime FechaActualizacion { get; set; }
        public string FechaActualizacionStr { get { return FechaActualizacion.ToString(); } }
        public DateTime FechaDesde { get; set; }
        public string FechaDesdeStr { get { return FechaDesde.ToShortDateString(); } }
        public DateTime? FechaHasta { get; set; }
        public string FechaHastaStr { get { return ((DateTime)FechaHasta).ToShortDateString(); } }
        public TimeSpan HoraInicio { get; set; }
        public string HoraInicioStr { get { return HoraInicio.Hours.ToString() + ":" + HoraInicio.Minutes.ToString(); } }
        public string Observacion { get; set; }
    }
}
