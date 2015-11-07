using Servicio.RecursoHumano.ComisionServicio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.RecursoHumano.ComisionServicio
{
    public interface IComisionServicio
    {

        void Insertar(List<ComisionServicioDTO> lista);
        void Eliminar(long id);
        IEnumerable<ComisionServicioDTO> ObtenerTodo();
        AccesoDatos.ComisionServicio ObtenerPorId(long id);
        IEnumerable<ComisionServicioDTO> ObtenerPorFiltro(long agenteId);
        IEnumerable<ComisionServicioDTO> ObtenerPorFiltro(long agenteId, DateTime fechaDesde, DateTime? fechaHasta);
        bool VerificarNoEsteRepetidoMemoria(List<ComisionServicioDTO> lista, DateTime fechaDesde, DateTime? fechaHasta);
    }
}
