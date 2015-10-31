using Servicio.Seguridad.Perfil.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Seguridad.Perfil
{
    public interface IServicioPerfil
    {
        void Eliminar(AccesoDatos.Perfil entidadEliminar);
        void Eliminar(long id);
        void Insertar(AccesoDatos.Perfil entidadNueva);
        void Modificar(AccesoDatos.Perfil entidadModificar);
        IEnumerable<PerfilDTO> ObtenerPorFiltro(string cadenaBuscar);
        AccesoDatos.Perfil ObtenerPorId(long id);
        IEnumerable<PerfilDTO> ObtenerTodo();
        bool VerificarSiExiste(long? id, string descripcion);
    }
}
