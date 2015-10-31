using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Seguridad.PerfilControles.DTOs
{
    public class PerfilControlDTO
    {
        public bool Item { get; set; }
        public long ControlId { get; set; }
        public string Descripcion { get; set; }
        public string Formulario { get; set; }
    }
}
