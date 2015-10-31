using Servicio.RecursoHumano.SubSector.DTOs;
using Servicio.Seguridad.Perfil.DTOs;
using System.Collections.Generic;

namespace Servicio.Seguridad.Usuario
{
    public static class Identidad
    {
        public static long? UsuarioId { get; set; }

        public static string NombreUsuario { get; set; }

        public static string ApyNomAgente { get; set; }

        public static List<PerfilDTO> Perfiles {get;set;}

        public static List<SubSectorDTO> SubSectores { get; set; }
    }
}
