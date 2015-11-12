using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.RecursoHumano.NovedadAgente.DTOs
{
    public class NovedadAgenteDTO
    {
        public long Id { get; set; }
        public long AngenteId { get; set; }
        public long TipoNovedadId { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public TimeSpan HoraDesde { get; set; }
        public TimeSpan HoraHasta { get; set; }
        public string Observacion { get; set; }
    }
}
