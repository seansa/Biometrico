using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.RecursoHumano.Configuracion
{
    public interface IConfiguracionServicio
    {
        void GuardarConfiguracion(TimeSpan entrada, TimeSpan salida, int lactancia, int minutostarde, int minutosausente);
        bool HayRegistros();
        AccesoDatos.Configuracion ObtenerUltimaConfiguracion();
    }
}
