using Servicio.Seguridad.Controles.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Seguridad.Controles
{
    public interface IControlSistemaServicio
    {
        void Insertar(List<ControlSistemaDTO> listaControles);

        void Eliminar(List<long> controlIds);

        IEnumerable<ControlSistemaDTO> ObtenerPorFiltro(List<Assembly> listaAssemblys, string cadenaBuscar);
    }
}
