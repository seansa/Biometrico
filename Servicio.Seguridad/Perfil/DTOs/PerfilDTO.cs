using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Seguridad.Perfil.DTOs
{
    public class PerfilDTO
    {
        public long Id { get; set; }

        public string Descripcion { get; set; }

        public int CantidadUsuarios { get; set; }
    }
}
