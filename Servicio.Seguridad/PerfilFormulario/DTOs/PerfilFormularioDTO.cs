using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Seguridad.PerfilFormulario.DTOs
{
    public class PerfilFormularioDTO
    {
        public bool Item { get; set; }

        public long FormularioId { get; set; }

        public string Descripcion { get; set; }

        public string DescripcionCompleta { get; set; }
    }
}
