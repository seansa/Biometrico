using AccesoDatos;
using Servicio.RecursoHumano.TipoNovedadAgente.DTOs;
using System;
using System.Collections.Generic;

namespace Servicio.RecursoHumano.TipoNovedadAgente
{
    public interface ITipoNovedadAgenteServicio
    {
        void Insertar(string abreviatura, string descripcion, bool esJornadaCompleta);
        IEnumerable<TipoNovedadAgenteDTO> ObtenerTodo();
        TipoNovedad ObtenerPorId(long id);
    }
}
