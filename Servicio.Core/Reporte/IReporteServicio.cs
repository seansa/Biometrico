using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.Reporte
{
    public interface IReporteServicio
    {
        Agente BuscarPorId(long id);
        List<ReporteDiarioDTO.ReporteDiarioDTO> FiltrarAgenteDTO(DateTime fechaBuscar);
        List<AccesoDatos.Acceso> obtenerAccesos(long agenteid, DateTime fechaBuscar);
        TimeSpan? horaAcceso(TipoAcceso tipo, List<AccesoDatos.Acceso> lista);
        int obtenerMinutosLlegadaTarde();
        int obtenerMinutosAusentes();
        int obtenerMinutosLactancia();
        TipoNovedad obtenerTipo(long id);
        bool IsDateInRange(DateTime fecha, DateTime fechaDesde, DateTime? fechaHasta);
        bool IsTimeInRange(TimeSpan hora, TimeSpan horaDesde, TimeSpan horaHasta);
    }
}
