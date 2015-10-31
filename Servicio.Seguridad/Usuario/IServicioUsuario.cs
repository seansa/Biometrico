using Servicio.Seguridad.Usuario.DTOs;
using System.Collections.Generic;

namespace Servicio.Seguridad.Usuario
{
    public interface IServicioUsuario
    {
        IEnumerable<UsuarioDTO> ObtenerPorFiltro(string cadenaBuscar);

        bool CrearUsuarios(List<UsuarioDTO> listaAgentes);

        void BloquearUsuario(List<UsuarioDTO> listaUsuarios);

        void ResetearPassword(List<UsuarioDTO> listaUsuarios);

        AccesoDatos.Usuario ObtenerPorNombre(string nombreUsuario);

        void CambiarPassword(long usuarioId, string passwordNuevo);
    }
}
