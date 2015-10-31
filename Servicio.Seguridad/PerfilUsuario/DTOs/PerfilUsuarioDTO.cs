using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Seguridad.PerfilUsuario.DTOs
{
    public class PerfilUsuarioDTO
    {
        public bool Item { get; set; }
        public long UsuarioId { get; set; }
        public string Legajo { get; set; }        
        public string ApyNom { get; set; }
        public string Dni { get; set; }
        public string NombreUsuario { get; set; }
        public string EstaBloqueado { get; set; }
    }
}
