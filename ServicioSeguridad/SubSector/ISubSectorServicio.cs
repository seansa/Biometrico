using Servicio.RecursoHumano.SubSector.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.RecursoHumano.SubSector
{
    public interface ISubSectorServicio 
    {
        void Insertar(long sectorId, int codigo, string descripcion, string abreviatura);

        void Modificar(long id, long sectorId, int codigo, string descripcion, string abreviatura);

        void Eliminar(long id);

        AccesoDatos.SubSector ObtenerPorId(long id);

        IEnumerable<SubSectorDTO> ObtenerTodo();

        IEnumerable<SubSectorDTO> ObtenerTodo(long sectorId);

        IEnumerable<SubSectorDTO> ObtenerPorFiltro(string cadenaBuscar);

        IEnumerable<SubSectorDTO> ObtenerPorFiltro(long sectorId, string cadenaBuscar);

        bool VerificarSiExiste(long? id, long sectorId, int codigo, string descripcion, string abreviatura);

        int ObtenerSiguienteNroCodigo();
    }
}
