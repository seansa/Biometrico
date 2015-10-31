using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Seguridad.Usuario.DTOs
{
    public class UsuarioDTO
    {
        public long? Id { get; set; }
        public long AgenteId { get; set; }

        public bool Item { get; set; }

        private string _legajo;
        public string Legajo
        {
            get { return _legajo.PadLeft(12, '0'); }
            set { _legajo = value; }
        }

        public string Apellido { get; set; }
        public string Nombre { get; set; }

        public string ApyNom { get { return string.Format("{0} {1}", Apellido, Nombre); }  }

        public string Usuario { get; set; }

        public bool EstaBloqueado { get; set; }

        public string EstaBloqueadoStr
        {
            get { return EstaBloqueado ? "SI" : "NO"; }
        }
    }
}
