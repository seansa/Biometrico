using Servicio.Core.Acceso.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.Acceso
{
   public interface IAccesoServicio
    {
        void Insertar(long idAgente, DateTime fechaHora, int reloj, string tipoAcceso);
        IEnumerable<AccesoDTO> ObtenerTodo();
        IEnumerable<AccesoDTO> ObtenerPorAgente(long idAgente);

        IEnumerable<AccesoDTO> ObtenerPorFecha(DateTime dia);
        IEnumerable<AccesoDTO> ObtenerEntreFechas(DateTime fecha1, DateTime fecha2);
        IEnumerable<AccesoDTO> ObtenerAusentes();
        
    }
}
