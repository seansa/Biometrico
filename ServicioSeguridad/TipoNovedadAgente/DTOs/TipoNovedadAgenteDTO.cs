using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.RecursoHumano.TipoNovedadAgente.DTOs
{
    public class TipoNovedadAgente
    {
        public long Id { get; set; }
        public string Abreviatura { get; set; }
        public string Descripcion { get; set; }
        public bool EsJornadaCompleta { get; set; }
    }
}
