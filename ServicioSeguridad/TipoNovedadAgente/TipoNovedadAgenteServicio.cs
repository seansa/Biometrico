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

        public IList<TipoNovedadAgenteDTO> ObtenerPorFiltro(string abreviatura, string descripcion)
        {
            try
            {
                using (var _context = new ModeloBometricoContainer())
                {
                    var _novedades = _context.TipoNovedades
                        .AsNoTracking()
                        .Where(x => x.Abreviatura.Contains(abreviatura)
                        || x.Descripcion.Contains(descripcion))
                        .Select(x => new TipoNovedadAgenteDTO
                        {
                            Id = x.Id,
                            Abreviatura = x.Abreviatura,
                            Descripcion = x.Descripcion,
                            EsJornadaCompleta = x.EsJornadaCompleta
                        })
                        .ToList();

                    return _novedades;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TipoNovedad ObtenerPorId(long id)
        {
            try
            {
                using (var _context = new ModeloBometricoContainer())
                {
                    var _tipo = _context.TipoNovedades.Find(id);

                    if (_tipo == null) throw new Exception("No se encontro el tipo de novedad");

                    return _tipo;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<TipoNovedadAgenteDTO> ObtenerTodo()
        {
            try
            {
                using (var _context = new ModeloBometricoContainer())
                {
                    var _tipoNovedad = _context.TipoNovedades
                        .AsNoTracking()
                        .Select(x => new TipoNovedadAgenteDTO
                        {
                            Id = x.Id,
                            Abreviatura = x.Abreviatura,
                            Descripcion = x.Descripcion,
                            EsJornadaCompleta = x.EsJornadaCompleta
                        })
                        .ToList();

                    return _tipoNovedad;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
