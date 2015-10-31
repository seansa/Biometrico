using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.RecursoHumano.SubSector.DTOs
{
    public class SubSectorDTO
    {
        public long Id { get; set; }
        public long SectorId { get; set; }
        
        public int Codigo { get; set; }
        public string Abreviatura { get; set; }
        public string Descripcion { get; set; }
        public string Sector { get; set; }

        public int CantidadAgentes { get; set; }
    }
}
