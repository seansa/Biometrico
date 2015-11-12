using Servicio.RecursoHumano.Horario.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.RecursoHumano.Horario
{
    public interface IHorarioServicio
    {
        void AsignarHorarios(List<DetalleHorarioDTO> listahorarios, long agenteid);
        IEnumerable<DetalleHorarioDTO> AgregarDetalleHorario( List<DetalleHorarioDTO> listahorarios, long id, DateTime fechadesde, DateTime fechahasta, TimeSpan? horaentrada, TimeSpan? horasalidaparcial, TimeSpan? horaentradaparcial, TimeSpan? horasalida,bool lunes, bool martes, bool miercoles, bool jueves, bool viernes, bool sabado, bool domingo);
        IEnumerable<DetalleHorarioDTO> ObtenerHorariosPorId(long id);
        bool VerificarExiste(List<DetalleHorarioDTO> lista, DateTime fechadesde, DateTime fechahasta, TimeSpan? horaentrada, TimeSpan? horasalidaparcial, TimeSpan? horaentradaparcial, TimeSpan? horasalida, bool[] listaDias);
        string VerificarDiasDelRango(DateTime inicio, DateTime fin, int dias);
    }
}
