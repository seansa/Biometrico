using Servicio.RecursoHumano.AgenteSubSector.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.RecursoHumano.AgenteSubSector
{
    public interface IAgenteSubSectorServicio
    {
        void AsignarAgentes(List<long> AgentesIds, long subSectorId);
        void QuitarAgentes(List<long> AgentesIds, long subSectorId);

        IEnumerable<AgenteSubSectorDTO> ObtenerAgentesAsignados(long subSectorId, string cadenaBuscar);
        IEnumerable<AgenteSubSectorDTO> ObtenerAgentesNoAsignados(long subSectorId, string cadenaBuscar);


    }
}
