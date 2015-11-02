using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Servicio.RecursoHumano.Lactancia.DTOs;
using System.Globalization;

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

        public bool VerificarAlgunDiaCargado(bool[] arrayDias)
        {
            try
            {
                for (int i = 0; i < arrayDias.Length; i++)
                {
                    if (arrayDias[i])
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool VerificarNoEsteRepetidoMemoria(List<LactanciaDTO> lista, DateTime fechaDesde, DateTime fechaHasta, bool[] arrayDias)
        {
            try
            {
                foreach (var lact in lista)
                {
                    if (IsDateInRange(fechaDesde,lact.FechaDesde,lact.FechaHasta)
                        ||IsDateInRange(fechaHasta,lact.FechaDesde,lact.FechaHasta)
                        ||IsDateInRange(lact.FechaDesde,fechaDesde,fechaHasta))
                    {
                        var _arrayDias =new bool[7];
                        _arrayDias[0] = lact.Lunes;
                        _arrayDias[1]= lact.Martes;
                        _arrayDias[2] = lact.Miercoles;
                        _arrayDias[3] = lact.Jueves;
                        _arrayDias[4] = lact.Viernes;
                        _arrayDias[5] = lact.Sabado;
                        _arrayDias[6] = lact.Domingo;
                        for (int i = 0; i < _arrayDias.Length; i++)
                        {
                            if (_arrayDias[i]&&arrayDias[i])
                            {
                                return false;
                            }
                        }
                    } 
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool IsDateInRange(DateTime fecha, DateTime fechaDesde, DateTime fechaHasta)
        {
            if (DateTime.Compare(fecha.Date,fechaDesde.Date)>=0 && DateTime.Compare(fecha.Date,fechaHasta.Date)<=0)
            {
                return true;   
            }
            return false;
        }
        

        public string ComprobarDiaExisteEnRango(DateTime inicio, DateTime fin, int dia)
        {
            DateTime diaAux = inicio;
            do
            {
                if ((int)diaAux.DayOfWeek == dia)
                {
                    return diaAux.ToString("dddd", new CultureInfo("es-Es"));
                }
                
                    diaAux = diaAux.AddDays(1);
                
            } while (diaAux.Date <= fin.Date);
            return "No";
        }
    }

}
