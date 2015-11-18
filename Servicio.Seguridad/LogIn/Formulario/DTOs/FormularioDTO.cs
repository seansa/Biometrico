using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Seguridad.Formulario.DTOs
{
    public class FormularioDTO
    {
        public bool Item { get; set; }

        public long? Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionCompleta { get; set; }
        public string EstaEnBase { get; set; }
    }
}
