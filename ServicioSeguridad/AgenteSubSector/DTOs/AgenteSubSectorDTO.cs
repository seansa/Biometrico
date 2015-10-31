using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.RecursoHumano.AgenteSubSector.DTOs
{
    public class AgenteSubSectorDTO
    {
        public bool Item { get; set; }

        public long AgenteId { get; set; }
        public string Legajo { get; set; }
        public string ApyNom { get; set; }
        public string Dni { get; set; }
    }
}
