using Servicio.Seguridad.PerfilFormulario.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Seguridad.PerfilFormulario
{
    public interface IPerfilFormularioServicio
    {
        void AsignarFormularios(List<long> formularioIds, long perfilId);
        void QuitarFormularios(List<long> formularioIds, long perfilId);
        IEnumerable<PerfilFormularioDTO> ObtenerFormulariosAsignados(long perfilId, string cadenaBuscar);
        IEnumerable<PerfilFormularioDTO> ObtenerFormulariosNoAsignados(long perfilId, string cadenaBuscar);
    }
}
