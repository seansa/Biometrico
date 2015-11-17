using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using System.Reflection;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Servicio.Core.Reporte
{
    public class ReporteServicio : IReporteServicio
    {
        public Agente BuscarPorId(long id)
        {
            try
            {
                using (var _context = new ModeloBometricoContainer())
                {
                    return _context.Agentes.First(x => x.Id == id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ReporteDiarioDTO.ReporteDiarioDTO> FiltrarAgenteDTO(DateTime fechaBuscar)
        {
            try
            {
                using (var _context = new ModeloBometricoContainer())
                {
                    var listaDto = new List<ReporteDiarioDTO.ReporteDiarioDTO>();
                    foreach (var agente in _context.Agentes.ToList())
                    {
                        var lista = agente.Horarios.Where(w => w.FechaDesde.Date <= fechaBuscar && w.FechaHasta.Date >= fechaBuscar).OrderByDescending(o => o.FechaActualizacion).ToList();
                        var ultimoHorario = lista.FirstOrDefault();
                        if (ultimoHorario != null)
                        {
                            if (TomarValorPropiedad(fechaBuscar, ultimoHorario))
                            {
                                var novedad = obtenerNovedad(agente.Id, fechaBuscar);
                                var comision = obtenerComision(agente.Id, fechaBuscar);
                                var lactancia = obtenerLactancia(agente.Id, fechaBuscar);
                                var reloj = obtenerReloj(fechaBuscar);
                                var _reporteDTO = new ReporteDiarioDTO.ReporteDiarioDTO(agente.Id, fechaBuscar, ultimoHorario,novedad, comision,lactancia,reloj);
                                
                                listaDto.Add(_reporteDTO);
                            }
                        }
                    }
                    return listaDto;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private string nombreDia(DateTime fechaBuscar)
        {
            using (var _context = new ModeloBometricoContainer())
            {
                var _horario = new AccesoDatos.Horario();
                PropertyInfo dia = _horario.GetType().GetProperty("Lunes");

                return dia.Name;

            }
        }
        private string ConvertirDia(DateTime fechaBuscar)
        {
            var _listaConDias = new List<Horario>();
            var reg = new Regex("[^a-zA-Z0-9 ]");
            var normal = fechaBuscar.ToString("dddd").Normalize(NormalizationForm.FormD);
            var dia = reg.Replace(normal, "");
            dia = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dia);
            return dia;

        }
        private bool TomarValorPropiedad(DateTime fechaBuscar, Horario schedule)
        {
            var horario = schedule;

            if ((bool)schedule.GetType().GetProperty(ConvertirDia(fechaBuscar)).GetValue(horario, null))
            {
                return true;
            }
            return false;
        }
        public List<AccesoDatos.Acceso> obtenerAccesos(long agenteid, DateTime fechaBuscar)
        {
            try
            {
                using (var _context=new ModeloBometricoContainer())
                {
                    var acceso = _context.Accesos.Where(x => x.AgenteId == agenteid && x.FechaHora == fechaBuscar).ToList();
                    return acceso.ToList() ;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public TimeSpan? horaAcceso(TipoAcceso tipo, List<AccesoDatos.Acceso> lista)
        {
            var hora = (TimeSpan?)null;
            if (tipo==TipoAcceso.Entrada||tipo==TipoAcceso.EntradaParacial)
            {
                var AccesosOrdenados = lista.Where(x => x.TipoAcceso == tipo).OrderBy(x => x.Hora);
                var primerAcceso = AccesosOrdenados.FirstOrDefault();
                if (primerAcceso!=null)
                {
                    hora = (TimeSpan?)primerAcceso.Hora;
                }
            }
            if (tipo == TipoAcceso.Salida|| tipo==TipoAcceso.SalidaParcial)
            {
                var AccesosOrdenados = lista.Where(x => x.TipoAcceso == tipo).OrderByDescending(x => x.Hora);
                var ultimoAcceso = AccesosOrdenados.FirstOrDefault();
                if (ultimoAcceso != null)
                {
                    hora = (TimeSpan?)ultimoAcceso.Hora;
                }
            }
            return hora;
        }

        public int obtenerMinutosLlegadaTarde()
        {
            try
            {
                using (var _context=new ModeloBometricoContainer())
                {
                    var configuracionesOrdenadas = _context.Configuraciones.OrderByDescending(x => x.Id);
                    var configuracion = configuracionesOrdenadas.FirstOrDefault();
                    var _minutos = configuracion.MinutosToleranciaLlegadaTarde;
                    return _minutos;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int obtenerMinutosAusentes()
        {
            try
            {
                using (var _context = new ModeloBometricoContainer())
                {
                    var configuracionesOrdenadas = _context.Configuraciones.OrderByDescending(x => x.Id);
                    var configuracion = configuracionesOrdenadas.FirstOrDefault();
                    var _minutos = configuracion.MinutosToleranciaAusente;
                    return _minutos;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int obtenerMinutosLactancia()
        {

            try
            {
                using (var _context = new ModeloBometricoContainer())
                {
                    var configuracionesOrdenadas = _context.Configuraciones.OrderByDescending(x => x.Id);
                    var configuracion = configuracionesOrdenadas.FirstOrDefault();
                    var _minutos = configuracion.MinutosLactancia;
                    return _minutos;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Novedad obtenerNovedad(long id, DateTime fechaBuscar)
        {
            try
            {
                using (var _context = new ModeloBometricoContainer())
                {
                    var novedadesOrdenadas = _context.Novedades.Where(x => x.AgenteId == id&&x.FechaDesde<=fechaBuscar&&x.FechaHasta>=fechaBuscar).OrderByDescending(x => x.Id);
                    var novedad = novedadesOrdenadas.FirstOrDefault();
                    return novedad;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ComisionServicio obtenerComision(long id, DateTime fechaBuscar)
        {
            try
            {
                using (var _context = new ModeloBometricoContainer())
                {
                    var comisionOrdenada = _context.ComisionServicios.Where(w => w.AgenteId == id && w.FechaDesde <= fechaBuscar && w.FechaHasta >= fechaBuscar).OrderByDescending(x => x.Id);
                    var comision = comisionOrdenada.FirstOrDefault();
                    if (comision!=null)
                    {
                        return comision; 
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Lactancia obtenerLactancia(long id, DateTime fechaBuscar)
        {
            try
            {
                using (var _context=new ModeloBometricoContainer())
                {
                    var lactanciaOrdenada = _context.Lactancias.Where(x => x.AgenteId == id && x.FechaDesde <= fechaBuscar && x.FechaHasta >= fechaBuscar).OrderByDescending(x => x.FechaActualizacion);
                    var lactancia = lactanciaOrdenada.FirstOrDefault();
                    if (lactancia!=null)
                    {
                        return lactancia;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public RelojDefectuoso obtenerReloj(DateTime fechaBuscar)
        {
            try
            {
                using (var _context= new ModeloBometricoContainer())
                {
                    var reloj = _context.RelojDefectuosos.FirstOrDefault(x => x.Fecha == fechaBuscar);
                    return reloj;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }


}

