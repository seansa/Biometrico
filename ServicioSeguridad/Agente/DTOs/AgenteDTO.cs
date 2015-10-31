using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.RecursoHumano.Agente.DTOs
{
    public class AgenteDTO
    {
        public long Id { get; set; }

        private string _legajo;
        public string Legajo
        {
            get { return _legajo.PadLeft(12, '0'); }
            set { _legajo = value; }
        }

        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public string ApyNom
        {
            get
            {
                return string.Format("{0} {1}", Apellido, Nombre);
            }
        }

        public string DNI { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public string Mail { get; set; }

        public string Visualizar { get; set; }
    }
}
