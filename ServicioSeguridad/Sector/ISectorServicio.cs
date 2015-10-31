using Servicio.RecursoHumano.Sector.DTOs;
using System.Collections.Generic;

namespace Servicio.RecursoHumano.Sector
{
    public interface ISectorServicio 
    {
        void Insertar(int codigo, string descripcion);

        void Modificar(long id, int codigo, string descripcion);

        void Eliminar(long id);

        AccesoDatos.Sector ObtenerPorId(long id);

        IEnumerable<SectorDTO> ObtenerTodo();

        IEnumerable<SectorDTO> ObtenerPorFiltro(string cadenaBuscar);

        bool VerificarSiExiste(long? id, int codigo, string descripcion);

        int ObtenerSiguienteNroCodigo();
    }
}
