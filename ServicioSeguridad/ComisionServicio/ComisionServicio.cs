using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using System.Globalization;
using System.Transactions;
using Servicio.RecursoHumano.ComisionServicio;
using Servicio.RecursoHumano.ComisionServicio.DTOs;
using System.ComponentModel;

namespace Servicio.RecursoHumano.ComisionServicio
{
    public class ComisionServicio : IComisionServicio
    {
        public void Eliminar(long id)
        {
            try
            {
                using (var _context = new ModeloBometricoContainer())
                {
                    var _ComisionServicio = _context.ComisionServicios.Find(id);
                    if (_ComisionServicio == null) throw new Exception("No se encontró ninguna comisión de servicio");
                    _context.ComisionServicios.Remove(_ComisionServicio);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Insertar(List<ComisionServicioDTO> lista)
        {
            using (var tran = new TransactionScope())
            {

                try
                {
                    foreach (var x in lista)
                    {

                        using (var _context = new ModeloBometricoContainer())
                        {
                            var _ComisionServicio = new AccesoDatos.ComisionServicio()
                            {
                                Id = x.Id,
                                AgenteId = x.AgenteId,
                                FechaDesde = x.FechaDesde,
                                FechaHasta = x.FechaHasta ?? null,
                                HoraDesde = x.HoraInicio,
                                HoraHasta = x.HoraFin,
                                Descripcion = x.Descripcion,
                                EsJornadaCompleta = x.JornadaCompleta,
                                Observacion = x.Observaciones
                            };
                            _context.ComisionServicios.Add(_ComisionServicio);
                            _context.SaveChanges();
                        } 
                    }

                    tran.Complete();
                }
                catch (Exception)
                {
                    throw;
                } 
            }
        }


        public IEnumerable<ComisionServicioDTO> ObtenerPorFiltro(long agenteId)
        {
            try
            {
                using (var _context=new ModeloBometricoContainer())
                {
                    var _listaComisionServicio = _context.ComisionServicios.AsNoTracking().Where(x => x.AgenteId == agenteId).Select(x => new ComisionServicioDTO
                    {
                        Id = x.Id,
                        AgenteId = x.AgenteId,
                        FechaDesde = x.FechaDesde,
                        FechaHasta = x.FechaHasta,
                        HoraFin = x.HoraHasta,
                        HoraInicio = x.HoraDesde,
                        Descripcion = x.Descripcion,
                        JornadaCompleta = x.EsJornadaCompleta,
                        Observaciones = x.Observacion
                    }).ToList();

                    return _listaComisionServicio;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ComisionServicioDTO> ObtenerPorFiltro(long agenteId, DateTime fechaDesde, DateTime? fechaHasta)
        {
            try
            {
                using (var _context = new ModeloBometricoContainer())
                {
                    var _listaComisionServicio = _context.ComisionServicios.AsNoTracking().Where(x => x.AgenteId == agenteId && ((x.FechaDesde <= fechaDesde) && (x.FechaHasta >= fechaDesde) || (x.FechaDesde <= fechaHasta) && (x.FechaHasta >= fechaHasta))).
                        Select(x => new ComisionServicioDTO
                        {
                            Id = x.Id,
                            AgenteId = x.AgenteId,
                            FechaDesde = x.FechaDesde,
                            FechaHasta = x.FechaHasta,
                            HoraFin = x.HoraHasta,
                            HoraInicio = x.HoraDesde,
                            Descripcion = x.Descripcion,
                            JornadaCompleta = x.EsJornadaCompleta,
                            Observaciones = x.Observacion
                        }).ToList();
                    return _listaComisionServicio;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AccesoDatos.ComisionServicio ObtenerPorId(long id)
        {
            try
            {
                using (var _context= new ModeloBometricoContainer())
                {
                    var _ComisionServicio = _context.ComisionServicios.Find(id);
                    if (_ComisionServicio == null) throw new Exception("No se encontró ninguna comisión de servicio");
                    return _ComisionServicio;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<ComisionServicioDTO> ObtenerTodo()
        {
            try
            {
                using (var _context= new ModeloBometricoContainer())
                {
                    var _lista = _context.ComisionServicios.AsNoTracking().Select(x=>new ComisionServicioDTO
                    {
                        Id = x.Id,
                        AgenteId = x.AgenteId,
                        FechaDesde = x.FechaDesde,
                        FechaHasta = x.FechaHasta,
                        HoraFin = x.HoraHasta,
                        HoraInicio = x.HoraDesde,
                        Descripcion = x.Descripcion,
                        JornadaCompleta = x.EsJornadaCompleta,
                        Observaciones = x.Observacion
                    }).ToList();
                    return _lista;
                }                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool VerificarNoEsteRepetidoMemoria(List<ComisionServicioDTO> lista, DateTime fechaDesde, DateTime? fechaHasta, bool jornadaCompleta, TimeSpan horaInicio, TimeSpan horaFin)
        {
            try
            {
                foreach (var comision in lista)
                {
                    if (IsDateInRange(fechaDesde, comision.FechaDesde, comision.FechaHasta)
                        ||IsDateInRange((DateTime)fechaHasta, comision.FechaDesde, comision.FechaHasta)
                        ||IsDateInRange(comision.FechaDesde,fechaDesde,fechaHasta))
                    {
                        if (jornadaCompleta) return false;
                        else if (lista.Any(e =>
                           (horaInicio < e.HoraInicio && horaInicio < e.HoraFin && horaFin > e.HoraInicio && horaFin < e.HoraFin) ||
                           (horaInicio == e.HoraInicio && horaInicio < e.HoraFin && horaFin > e.HoraInicio && horaFin < e.HoraFin) ||
                           (horaInicio < e.HoraInicio && horaInicio < e.HoraFin && horaFin > e.HoraInicio && horaFin == e.HoraFin) ||
                           (horaInicio > e.HoraInicio && horaInicio < e.HoraFin && horaFin > e.HoraInicio && horaFin > e.HoraFin) ||
                           (horaInicio == e.HoraInicio && horaInicio < e.HoraFin && horaFin > e.HoraInicio && horaFin == e.HoraFin) ||
                           (horaInicio > e.HoraInicio && horaInicio < e.HoraFin && horaFin > e.HoraInicio && horaFin < e.HoraFin) ||
                           (horaInicio < e.HoraInicio && horaInicio < e.HoraFin && horaFin > e.HoraInicio && horaFin > e.HoraFin) ||
                           (horaInicio == e.HoraInicio && horaInicio < e.HoraFin && horaFin > e.HoraInicio && horaFin > e.HoraFin) ||
                           (horaInicio > e.HoraInicio && horaInicio < e.HoraFin && horaFin > e.HoraInicio && horaFin == e.HoraFin))) return false;
                        else return true;
                    } 
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool IsDateInRange(DateTime fecha, DateTime fechaDesde, DateTime? fechaHasta)
        {
            if (DateTime.Compare(fecha.Date,fechaDesde.Date)>=0 && DateTime.Compare(fecha.Date,((DateTime)fechaHasta).Date) <= 0)
            {
                return true;   
            }
            return false;
        }
       
    }

}
