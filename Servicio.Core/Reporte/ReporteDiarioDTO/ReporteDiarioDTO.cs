using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace Servicio.Core.Reporte.ReporteDiarioDTO
{
    public class ReporteDiarioDTO
    {
        private long AgenteId { get; set; }
        public string Legajo { get { return _agente.Legajo; } }
        public string Apellido { get { return _agente.Apellido; } }
        public string Nombre { get { return _agente.Nombre; } }

        private DateTime FechaReporte { get; set; }
        public int NumeroDia { get { return FechaReporte.Day; } }
        public string NombreDia { get { return FechaReporte.ToString("dddd", new CultureInfo("es-Es")); } }
        public string NombreMes { get { return CultureInfo.InstalledUICulture.DateTimeFormat.GetMonthName(FechaReporte.Month); } }
        public string Anio { get { return FechaReporte.Year.ToString(); } }
        private TimeSpan? HoraEntrada
        {
            get
            {
                return _reporteServicio.horaAcceso(TipoAcceso.Entrada, _accesos);
            }

        }
        public string HoraEntradaStr { get { return HoraEntrada != null ? HoraEntrada.ToString() : "No Registrado"; } }
        private TimeSpan? HoraSalidaParcial
        {
            get
            {
                return _reporteServicio.horaAcceso(TipoAcceso.SalidaParcial, _accesos);
            }

        }
        public string HoraSalidaParcialStr
        {
            get
            {
                return HoraSalidaParcial != null ? HoraSalidaParcial.ToString() : "No Registrado";
            }
        }
        private TimeSpan? HoraEntradaParcial
        {
            get
            {
                return _reporteServicio.horaAcceso(TipoAcceso.EntradaParacial, _accesos);
            }

        }
        public string HoraEntradaParcialStr
        {
            get
            {
                return HoraEntradaParcial != null ? HoraEntradaParcial.ToString() : "No Registrado";
            }
        }
        private TimeSpan? HoraSalida
        {
            get
            {
                return _reporteServicio.horaAcceso(TipoAcceso.Salida, _accesos);
            }

        }
        public string HoraSalidaStr
        {
            get
            {
                return HoraSalida != null ? HoraSalida.ToString() : "No Registrado";
            }
        }
        private double MinutosTarde
        {
            get
            {
                double valor = -1;
                if (HoraEntrada != null)
                {
                    if (_novedad != null)
                    {
                        if (!_tipoNovedad.EsJornadaCompleta)
                        {

                            if (_lactancia==null)
                            {
                                if (_novedad.HoraHasta <= HoraEntrada && _novedad.HoraDesde <= _horario.HoraEntrada)
                                {
                                    var minutosAdicionales = _novedad.HoraHasta - _novedad.HoraDesde;
                                    var horarioEntrada = _horario.HoraEntrada.Value.Add((TimeSpan)minutosAdicionales);
                                    return HoraEntrada.Value.TotalMinutes - horarioEntrada.TotalMinutes;
                                } 
                            }
                            else
                            {
                                if (_lactancia.HoraInicio)
                                {
                                    var minutosLact = new TimeSpan(0, _minutosLactancia, 0);
                                    var minutosAdicionales = _novedad.HoraHasta - _novedad.HoraDesde;
                                    var horarioEntrada = _horario.HoraEntrada.Value.Add((TimeSpan)minutosAdicionales);
                                    horarioEntrada = horarioEntrada.Add(minutosLact);
                                    return HoraEntrada.Value.TotalMinutes - horarioEntrada.TotalMinutes; 
                                }
                            }
                        }
                    }
                    if (_comision!=null && _novedad==null)
                    {
                        if (_lactancia==null)
                        {
                            if (_comision.HoraHasta <= HoraEntrada && _comision.HoraDesde <= _horario.HoraEntrada)
                            {
                                var minutosAdicionales = _comision.HoraHasta - _comision.HoraDesde;
                                var horarioEntrada = _horario.HoraEntrada.Value.Add((TimeSpan)minutosAdicionales);
                                return HoraEntrada.Value.TotalMinutes - horarioEntrada.TotalMinutes;
                            } 
                        }
                        else
                        {
                            if (_lactancia.HoraInicio)
                            {
                                var minutosLact = new TimeSpan(0, _minutosLactancia, 0);
                                var minutosAdicionales = _comision.HoraHasta - _comision.HoraDesde;
                                var horarioEntrada = _horario.HoraEntrada.Value.Add((TimeSpan)minutosAdicionales);
                                horarioEntrada = horarioEntrada.Add(minutosLact);
                                return HoraEntrada.Value.TotalMinutes - horarioEntrada.TotalMinutes;
                            }

                        }
                    }
                    if (_lactancia!=null )
                    {
                        if (_lactancia.HoraInicio)
                        {
                            var minutosLact = new TimeSpan(0, _minutosLactancia, 0);
                            var horarioEntrada = _horario.HoraEntrada.Value.Add(minutosLact);
                            return HoraEntrada.Value.TotalMinutes - horarioEntrada.TotalMinutes;
                        }
                    }
                    
                    valor = HoraEntrada.Value.TotalMinutes - _horario.HoraEntrada.Value.TotalMinutes;
                }
                
                return valor;
            }
        }
        public string MinutsTardeStr
        {
            get
            {
                if (MinutosTarde == -1 && HoraEntrada == null)
                {
                    return "No Ingreso";
                }
                if (MinutosTarde == -1 && HoraEntrada != null)
                {
                    return "llegaTemprano";
                }
                else
                {
                    return MinutosTarde.ToString();
                }
            }
        }
        private double MinutosFaltantes
        {
            get
            {
                double valor = -1;
                if (HoraEntrada != null&&HoraSalida!=null)
                {
                    var valor1 = HoraSalida.Value.TotalMinutes - _horario.HoraSalida.Value.TotalMinutes;
                    var valor2 = MinutosTarde;
                    valor = valor2 - valor1;
                }
                return valor;
            }
           
        }
        public string MinutosFaltantesSTR { get { return MinutosFaltantes >= 0 ? MinutosFaltantes.ToString() : "NO"; } }
        public string Nov
        {
            get
            {
                return _novedad != null ? "SI" : "NO";
            }
        }
        public string Comision
        {
            get
            {
                return _comision != null ? "SI" : "NO";
            }
        }
        public string Lact
        {
            get
            {
                return _lactancia != null ? "SI" : "NO";
            }
        }
        public string Reloj
        {
            get
            {
                return _reloj != null ? "SI" : "NO";
            }
        }
        public string Ausente
        {
            get
            {
                if (HoraEntrada == null)
                {
                    if (_novedad != null)
                    {

                        if (_tipoNovedad.EsJornadaCompleta)
                        {
                            return "NO";
                        }
                        else if (_reporteServicio.IsTimeInRange((TimeSpan)_horario.HoraEntrada, (TimeSpan)_novedad.HoraDesde,(TimeSpan)_novedad.HoraHasta)
                            || _reporteServicio.IsTimeInRange((TimeSpan)_horario.HoraSalida, (TimeSpan)_novedad.HoraDesde, (TimeSpan)_novedad.HoraHasta))
                        {
                            return "NO";
                        }
                        else
                        {
                            return "SI";
                        }
                    }
                    else if (_comision != null && _novedad== null)
                    {
                        if (_comision.EsJornadaCompleta)
                        {

                            return "NO"; 
                        }
                        else if ((_comision.HoraDesde<=_horario.HoraEntrada&&_comision.HoraHasta>=_horario.HoraEntrada)
                            || (_comision.HoraDesde<=_horario.HoraSalida&&_comision.HoraHasta>=_horario.HoraSalida))
                        {
                            return "NO";
                        }
                        else
                        {
                            return "SI";
                        }
                    }
                    else if (_reloj != null && _reloj.JornadaCompleta == true)
                    {
                        return "NO";
                    }
                    else
                    {
                        return "SI";
                    }
                }
                else
                {
                    if (_novedad!=null)
                    {
                        if (!_tipoNovedad.EsJornadaCompleta)
                        {
                            
                            if (_novedad.HoraHasta<=HoraEntrada&&_novedad.HoraDesde<=_horario.HoraEntrada)
                            {
                                var minutosAdicionales = _novedad.HoraHasta - _novedad.HoraDesde;
                                var horarioEntrada = _horario.HoraEntrada.Value.Add((TimeSpan)minutosAdicionales);
                                return (HoraEntrada.Value.TotalMinutes - horarioEntrada.TotalMinutes) >= (double)_toleraciaAusente ? "SI" : "NO";
                            }
                        }
                    }
                    if (_comision!=null &&_novedad==null)
                    {

                    }
                    if (_lactancia != null)
                    {
                        if (_lactancia.HoraInicio)
                        {
                            var minutos = new TimeSpan(0, _minutosLactancia, 0);
                            var horaEntrada = _horario.HoraEntrada.Value.Add(minutos);
                            return (HoraEntrada.Value.Minutes - horaEntrada.Minutes) > _toleraciaAusente ? "SI" : "NO";

                        }
                        else
                        {
                            return MinutosTarde > _toleraciaAusente ? "SI" : "NO";

                        }
                    }
                    else
                    {
                        var retornar=MinutosTarde>_toleraciaAusente ? "SI" : "NO";
                        return retornar;

                    }
                }

            }
        }

        public string Tarde
        {
            get
            {
                if (HoraEntrada == null)
                {

                    if (_novedad != null && _tipoNovedad.EsJornadaCompleta)
                    {
                        return "NO";
                    }
                    else if (_comision != null)
                    {
                        if (_comision.EsJornadaCompleta)
                        {

                            return "NO";
                        }
                        else if ((_comision.HoraDesde <= _horario.HoraEntrada && _comision.HoraHasta >= _horario.HoraEntrada)
                            || (_comision.HoraDesde <= _horario.HoraSalida && _comision.HoraHasta >= _horario.HoraSalida))
                        {
                            return "NO";
                        }
                        else
                        {
                            return "SI";
                        }
                    }
                    else if (_reloj != null && (_reloj.JornadaCompleta == true || (_reloj.HoraDesde <= _horario.HoraEntrada && _reloj.HoraHasta >= _horario.HoraSalida)))
                    {
                        return "NO";
                    }
                    else
                    {
                        return "NO";
                    }
                }
                else
                {
                    if (Ausente!="SI")
                    {
                        if (_lactancia != null)
                        {
                            if (_lactancia.HoraInicio)
                            {
                                var minutos = new TimeSpan(0,_minutosLactancia, 0);
                                var horaEntrada = _horario.HoraEntrada.Value.Add(minutos);
                                return (HoraEntrada.Value.Minutes - horaEntrada.Minutes) > _toleraciaLlegadaTarde ? "SI" : "NO";
                            }
                            else
                            {
                                return MinutosTarde > _toleraciaLlegadaTarde ? "SI" : "NO";
                            }

                        }

                        else
                        {
                            return MinutosTarde > _toleraciaLlegadaTarde ? "SI" : "NO";
                        } 
                    }
                    else
                    {
                        return "NO";
                    }


                }
            }
        }
           
        
    
        public string JornadaIncompleta
        {
            get
            {
                if (MinutosFaltantes > 0)
                {
                    return "SI";
                }
                else
                {
                    return "NO";
                }
            }
        }
        public string EstaOK
        {
            get
            {
                if (Ausente=="SI"||Tarde=="SI"||JornadaIncompleta=="SI")
                {
                    return "NO";
                }
                else
                {
                    return "OK";
                }
            }
        }
        private IReporteServicio _reporteServicio;
        private Agente _agente;
        private Horario _horario;
        private Novedad _novedad;
        private ComisionServicio _comision;
        private Lactancia _lactancia;
        private RelojDefectuoso _reloj;
        private TipoNovedad _tipoNovedad;
        private List<AccesoDatos.Acceso> _accesos;
        private int _toleraciaLlegadaTarde;
        private int _toleraciaAusente;
        private int _minutosLactancia;
        

        public ReporteDiarioDTO(long agenteId
            , DateTime fechaBuscar
            , Horario horario
            ,Novedad novedad
            , ComisionServicio comision
            , Lactancia lactancia
            ,RelojDefectuoso reloj)
        {

            AgenteId = agenteId;
            FechaReporte = fechaBuscar;
            _reporteServicio = new ReporteServicio();
            _agente = _reporteServicio.BuscarPorId(AgenteId);
            _horario = horario;
            _accesos = _reporteServicio.obtenerAccesos(AgenteId, fechaBuscar);
            _toleraciaLlegadaTarde = _reporteServicio.obtenerMinutosLlegadaTarde();
            _toleraciaAusente = _reporteServicio.obtenerMinutosAusentes();
            _minutosLactancia = _reporteServicio.obtenerMinutosLactancia();
            _lactancia = lactancia;
            _novedad = novedad;
            _comision = comision;
            _reloj = reloj;
            if (_novedad!=null)
            {
                _tipoNovedad = _reporteServicio.obtenerTipo(_novedad.Id);
            }
        }

        
        
    }
}
