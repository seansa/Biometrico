using Servicio.RecursoHumano.Agente.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.RecursoHumano.Agente
{
    public interface IAgenteServicio 
    {
        void Insertar(string legajo, string apellido, string nombre, string dni, string telefono, string celular, string mail, bool visualizar);

        void Modificar(long id, string legajo, string apellido, string nombre, string dni, string telefono, string celular, string mail, bool visualizar);

        void Eliminar(long id);

        AccesoDatos.Agente ObtenerPorId(long id);

        IEnumerable<AgenteDTO> ObtenerTodo();

        IEnumerable<AgenteDTO> ObtenerPorFiltro(string cadenaBuscar);
                
        bool VerificarSiExiste(long? id, string legajo);
    }
}
