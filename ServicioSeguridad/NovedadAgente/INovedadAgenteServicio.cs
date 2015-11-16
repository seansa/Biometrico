using Servicio.RecursoHumano.NovedadAgente.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.RecursoHumano.NovedadAgente
{
    public interface INovedadAgenteServicio
    {
        void Insertar(NovedadAgenteDTO novedadAgente);
        IEnumerable<NovedadAgenteDTO> ObtenerPorId(long agenteId);
    }
}
