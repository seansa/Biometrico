using Servicio.RecursoHumano.Reportes.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.RecursoHumano.Reportes
{
    public interface IReporteMensualServicio
    {
        List<ReporteMensualDTO> ObtenerPorId(long agenteId);
    }
}
