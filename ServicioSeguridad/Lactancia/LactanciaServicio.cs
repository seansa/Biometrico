using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Servicio.RecursoHumano.Lactancia.DTOs;

namespace Servicio.RecursoHumano.Lactancia
{
    public class LactanciaServicio : ILactanciaServicio
    {
        public void Eliminar(long id)
        {
            try
            {
                using (var _context = new ModeloBometricoContainer())
                {
                    var _lactancia = _context.Lactancias.Find(id);
                    if (_lactancia == null) throw new Exception("No se encontro una Lactancia");
                    _context.Lactancias.Remove(_lactancia);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Insertar(long agenteid, DateTime fechaDesde, DateTime fechaHasta, TimeSpan horaInicio, bool lunes, bool martes, bool miercoles, bool jueves, bool viernes, bool sabado, bool domingo)
        {
            try
            {
                using (var _context= new ModeloBometricoContainer())
                {
                    var _lactancia = new AccesoDatos.Lactancia()
                    {
                        AgenteId = agenteid,
                        FechaDesde = fechaDesde,
                        FechaHasta = fechaHasta,
                        FechaActualizacion = DateTime.Now,
                        HoraInicio=horaInicio,
                        Lunes=lunes,
                        Martes=martes,
                        Miercoles=miercoles,
                        Jueves=jueves,
                        Viernes=viernes,
                        Sabado=sabado,
                        Domingo=domingo,

                    };
                    _context.Lactancias.Add(_lactancia);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        public IEnumerable<LactanciaDTO> ObtenerPorFiltro(long agenteId)
        {
            try
            {
                using (var _context=new ModeloBometricoContainer())
                {
                    var _listaLactancias = _context.Lactancias.AsNoTracking().Where(x => x.AgenteId == agenteId).Select(x => new LactanciaDTO
                    {
                        Id = x.Id,
                        AgenteId = x.AgenteId,
                        FechaActualizacion = x.FechaActualizacion,
                        FechaDesde = x.FechaDesde,
                        FechaHasta = x.FechaHasta,
                        Lunes = x.Lunes,
                        Martes = x.Martes,
                        Miercoles=x.Miercoles,
                        Jueves=x.Jueves,
                        Viernes=x.Viernes,
                        Sabado=x.Sabado,
                        Domingo=x.Domingo,
                        HoraInicio=x.HoraInicio
                    }).ToList();
                    return _listaLactancias;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<LactanciaDTO> ObtenerPorFiltro(long agenteId, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                using (var _context = new ModeloBometricoContainer())
                {
                    var _listaLactancia = _context.Lactancias.AsNoTracking().Where(x => x.AgenteId == agenteId && ((x.FechaDesde <= fechaDesde) && (x.FechaHasta >= fechaDesde) || (x.FechaDesde <= fechaHasta) && (x.FechaHasta >= fechaHasta))).
                        Select(x => new LactanciaDTO
                        {
                            Id=x.Id,
                            AgenteId=x.AgenteId,
                            FechaHasta=x.FechaHasta,
                            FechaDesde=x.FechaDesde,
                            FechaActualizacion=x.FechaActualizacion,
                            HoraInicio=x.HoraInicio,
                            Lunes=x.Lunes,
                            Martes=x.Martes,
                            Miercoles=x.Miercoles,
                            Jueves=x.Jueves,
                            Viernes=x.Viernes,
                            Sabado=x.Sabado,
                            Domingo=x.Domingo
                        }).ToList();
                    return _listaLactancia;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public AccesoDatos.Lactancia ObtenerPorId(long id)
        {
            try
            {
                using (var _context= new ModeloBometricoContainer())
                {
                    var _lactancia = _context.Lactancias.Find(id);
                    if (_lactancia == null) throw new Exception("No se Encontro ninguna Lactancia");
                    return _lactancia;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<LactanciaDTO> ObtenerTodo()
        {
            try
            {
                using (var _context= new ModeloBometricoContainer())
                {
                    var _lista = _context.Lactancias.AsNoTracking().Select(x=>new LactanciaDTO
                    {
                        Id=x.Id,
                        AgenteId=x.AgenteId,
                        FechaDesde=x.FechaDesde,
                        FechaHasta=x.FechaHasta,
                        FechaActualizacion=x.FechaActualizacion,
                        HoraInicio=x.HoraInicio,
                        Lunes=x.Lunes,
                        Martes=x.Martes,
                        Miercoles=x.Miercoles,
                        Jueves=x.Jueves,
                        Viernes=x.Viernes,
                        Sabado=x.Sabado,
                        Domingo=x.Domingo
                    }).ToList();
                    return _lista;
                }                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
