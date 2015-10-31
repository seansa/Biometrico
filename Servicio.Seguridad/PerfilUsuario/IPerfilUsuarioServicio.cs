using Servicio.Seguridad.PerfilUsuario.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Seguridad.PerfilUsuario
{
    public interface IPerfilUsuarioServicio
    {
        void AsignarUsuarios(List<long> usuarioIds, long perfilId);
        void QuitarUsuarios(List<long> usuarioIds, long perfilId);
        IEnumerable<PerfilUsuarioDTO> ObtenerUsuariosAsignados(long perfilId, string cadenaBuscar);
        IEnumerable<PerfilUsuarioDTO> ObtenerUsuariosNoAsignados(long perfilId, string cadenaBuscar);
    }
}
