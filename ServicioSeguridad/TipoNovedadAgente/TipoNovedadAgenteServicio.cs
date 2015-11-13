using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Servicio.RecursoHumano.TipoNovedadAgente.DTOs;

namespace Servicio.RecursoHumano.TipoNovedadAgente
{
    public class TipoNovedadAgenteServicio : ITipoNovedadAgenteServicio
    {
        public void Insertar(string abreviatura, string descripcion, bool esJornadaCompleta)
        {
            try
            {
                using (var _context = new ModeloBometricoContainer())
                {
                    var _nuevaNovedad = new TipoNovedad()
                    {
                        Abreviatura = abreviatura,
                        Descripcion = descripcion,
                        EsJornadaCompleta = esJornadaCompleta
                    };

                    _context.TipoNovedades.Add(_nuevaNovedad);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TipoNovedad ObtenerPorId(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoNovedadAgenteDTO> ObtenerTodo()
        {
            throw new NotImplementedException();
        }
    }
}
