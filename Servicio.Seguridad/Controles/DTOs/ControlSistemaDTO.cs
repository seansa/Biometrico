using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Seguridad.Controles.DTOs
{
    public class ControlSistemaDTO
    {
        public bool Item { get; set; }

        public long? Id { get; set; }

        public string Descripcion { get; set; }

        public string Formulario { get; set; }

        public string EstaEnBase { get; set; }
    }
}
