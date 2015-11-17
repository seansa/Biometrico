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
        private int MinutosTarde
        {
            get
            {
                var valor = -1;
                if (HoraEntrada != null)
                {
                    valor = Convert.ToInt32(HoraEntrada.Value.TotalMinutes - _horario.HoraEntrada.Value.TotalMinutes);
                }
                return valor;
            }
            set
            {

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
        private int MinutosFaltantes
        {
            get
            {
                var valor = -1;
                if (HoraSalida != null)
                {
                    var valor1 = Convert.ToInt32(HoraSalida.Value.Minutes - _horario.HoraSalida.Value.Minutes);
                    var valor2 = Convert.ToInt32(HoraEntrada.Value.Minutes - _horario.HoraEntrada.Value.Minutes);
                    valor = valor2 - valor1;
                }
                return valor;
            }
            set
            {

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
        public string Tarde
        {
            get
            {
                if (HoraEntrada == null)
                {

                    if (_novedad != null && _novedad.TipoNovedad.EsJornadaCompleta)
                    {
                        return "NO";
                    }
                    else if (_comision != null && _comision.EsJornadaCompleta)
                    {
                        return "NO";
                    }
                    else if (_reloj != null && (_reloj.JornadaCompleta == true || (_reloj.HoraDesde <= _horario.HoraEntrada && _reloj.HoraHasta >= _horario.HoraSalida)))
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
                    if (_lactancia != null)
                    {
                        if (_lactancia.HoraInicio)
                        {
                            var minutos = new TimeSpan(0, _reporteServicio.obtenerMinutosLactancia(), 0);
                            var horaEntrada = _horario.HoraEntrada.Value.Add(minutos);
                            return (HoraEntrada.Value.Minutes - horaEntrada.Minutes) > _reporteServicio.obtenerMinutosLlegadaTarde() ? "SI" : "NO";
                        }
                        else
                        {
                            return (HoraEntrada.Value.Minutes - _horario.HoraEntrada.Value.Minutes) > _reporteServicio.obtenerMinutosLlegadaTarde() ? "SI" : "NO";
                        }

                    }

                    else
                    {
                        return (HoraEntrada.Value.Minutes - _horario.HoraEntrada.Value.Minutes) > _reporteServicio.obtenerMinutosLlegadaTarde() ? "SI" : "NO";
                    }


                }
            }
        }
            public string Ausente
        {
            get
            {
                if (HoraEntrada == null)
                {
                    if (_novedad != null && _novedad.TipoNovedad.EsJornadaCompleta)
                    {
                        return "NO";
                    }
                    else if (_comision != null && _comision.EsJornadaCompleta)
                    {
                        return "NO";
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
                    if (_lactancia != null)
                    {
                        if (_lactancia.HoraInicio)
                        {
                            var minutos = new TimeSpan(0, _reporteServicio.obtenerMinutosLactancia(), 0);
                            var horaEntrada = _horario.HoraEntrada.Value.Add(minutos);
                            return (HoraEntrada.Value.Minutes - horaEntrada.Minutes) > _reporteServicio.obtenerMinutosAusentes() ? "SI" : "NO";

                        }
                        else
                        {
                            return (HoraEntrada.Value.Minutes - _horario.HoraEntrada.Value.Minutes) > _reporteServicio.obtenerMinutosAusentes() ? "SI" : "NO";

                        }
                    }
                    else
                    {
                        return (HoraEntrada.Value.Minutes - _horario.HoraEntrada.Value.Minutes) > _reporteServicio.obtenerMinutosAusentes() ? "SI" : "NO";

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
        private List<AccesoDatos.Acceso> _accesos;
        private int _toleraciaLlegadaTarde;
        private int _toleraciaAusente;
        private int _minutosLactancia;
        public ReporteDiarioDTO(long agenteId, DateTime fechaBuscar, Horario horario,Novedad novedad, ComisionServicio comision, Lactancia lactancia,RelojDefectuoso reloj)
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
        }
        
    }
}
