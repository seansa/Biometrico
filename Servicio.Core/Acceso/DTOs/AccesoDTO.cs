using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.Acceso.DTOs
{
    public class AccesoDTO
    {

        public long Id { get; set; }

        public long AgenteId { get; set; }
        public DateTime FechaHora { get; set; }
        public string TipoAcceso { get; set; }
        public string Fecha { get { return FechaHora.ToShortDateString(); } }
        public TimeSpan? Hora { get; set; }
        public string NumeroReloj { get; set; }

    }
}