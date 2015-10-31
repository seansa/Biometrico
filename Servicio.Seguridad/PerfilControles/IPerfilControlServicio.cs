using Servicio.Seguridad.PerfilControles.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Seguridad.PerfilControles
{
    public interface IPerfilControlServicio
    {
        void AsignarControles(List<long> ControlIds, long perfilId);
        void QuitarControles(List<long> ControlIds, long perfilId);
        IEnumerable<PerfilControlDTO> ObtenerControlesAsignados(long perfilId, string cadenaBuscar);
        IEnumerable<PerfilControlDTO> ObtenerControlesNoAsignados(long perfilId, string cadenaBuscar);
    }
}
