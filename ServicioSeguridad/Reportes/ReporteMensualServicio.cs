using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using Servicio.RecursoHumano.Horario.DTOs;
using Servicio.Core.Acceso.DTOs;
using Servicio.RecursoHumano.ComisionServicio.DTOs;
using Servicio.RecursoHumano.NovedadAgente.DTOs;
using Servicio.Core.Acces;
using Servicio.RecursoHumano.Horario;
using Servicio.RecursoHumano.ComisionServicio;
using Servicio.RecursoHumano.NovedadAgente;
using Servicio.RecursoHumano.Reportes.DTOs;
using Servicio.RecursoHumano.Configuracion;
using Servicio.RecursoHumano.Agente;
using Servicio.RecursoHumano.Lactancia;
using Servicio.RecursoHumano.Lactancia.DTOs;

namespace Servicio.RecursoHumano.Reportes
{
    public class ReporteMensualServicio : IReporteMensualServicio
    {
        private readonly long _agenteId;
        private readonly IAgenteServicio _agenteServicio;
        private readonly IAccesoServicio _accesoServicio;
        private readonly IHorarioServicio _horarioServicio;
        private readonly IComisionServicio _comisionServicio;
        private readonly INovedadAgenteServicio _novedadesServicio;
        private readonly ILactanciaServicio _lactanciaServicio;
        
        private List<DetalleHorarioDTO> _listaHorarios;
        private List<AccesoDTO> _listaAccesosDelMes;
        private List<ComisionServicioDTO> _listaComisiones;
        private List<NovedadAgenteDTO> _listaNovedades;
        private List<LactanciaDTO> _listaLactancias;
        private List<DateTime> _listaDiasDelMes;

        private DateTime _fecha;
        private string _dia;
        private DetalleHorarioDTO _horarioDia;
        private int _minutosToleranciaLlegadaTarde;
        private int _minutosToleranciaAusente;
        private int _diasMes;

        private static List<Tuple<string, int>> _listaMesesYAños = ListaMesesYAños();


        public ReporteMensualServicio(long AgenteId, DateTime fecha)
        {
            _agenteId = AgenteId;
            _fecha = fecha;
            _diasMes = DateTime.DaysInMonth(_fecha.Year, _fecha.Month);

            _agenteServicio = new AgenteServicio();
            _accesoServicio = new AccesoServicio();
            _horarioServicio = new HorarioServicio();
            _comisionServicio = new ComisionServicio.ComisionServicio();
            _novedadesServicio = new NovedadAgenteServicio();
            _lactanciaServicio = new LactanciaServicio();

            _listaHorarios = _horarioServicio.ObtenerHorariosPorId(_agenteId).ToList();
            _listaAccesosDelMes = _accesoServicio.ObtenerPorId(_agenteId).Where(acceso => acceso.FechaHora.Month == _fecha.Month).ToList();
            _listaComisiones = _comisionServicio.ObtenerPorFiltro(_agenteId).ToList();
            _listaNovedades = _novedadesServicio.ObtenerPorId(_agenteId).ToList();
            _listaLactancias = _lactanciaServicio.ObtenerPorFiltro(_agenteId).ToList();
            _listaDiasDelMes = DiasDelMesConHorarios();            

            _minutosToleranciaAusente = ConfiguracionServicio.MinutosToleranciaAusente ?? 15;
            _minutosToleranciaLlegadaTarde = ConfiguracionServicio.MinutosToleranciaLlegadaTarde ?? 10;

        }

        #region Statics

        private static DateTime FechaPrimerAcceso()
        {
            try
            {
                using (var _context = new ModeloBometricoContainer())
                {
                    var _primerAcceso = _context.Accesos.First();
                    if (_primerAcceso == null) throw new Exception("No hay accesos");
                    return _primerAcceso.FechaHora;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static List<Tuple<string, int>> ListaMesesYAños()
        {
            DateTime fechaInicio = FechaPrimerAcceso();
            DateTime fechaFin = DateTime.Today;
            DateTime iterador;
            DateTime limite;
            List<Tuple<string, int>> lista = new List<Tuple<string, int>>();
            var dateTimeFormat = new CultureInfo("es-Ar").DateTimeFormat;

            if (fechaInicio.Date == fechaFin.Date)
            {
                lista.Add(Tuple.Create(dateTimeFormat.GetMonthName(fechaInicio.Month), fechaInicio.Year));
                return lista;
            }
            else
            {
                iterador = new DateTime(fechaInicio.Year, fechaInicio.Month, 1);
                limite = fechaFin;

                while (iterador <= limite)
                {
                    lista.Add(Tuple.Create(dateTimeFormat.GetMonthName(iterador.Month), iterador.Year));
                    iterador = iterador.AddMonths(1);
                }

                return lista;
            }  
        }

        public static List<string> ListaMeses()
        {
            var lista = new List<string>();

            foreach (var tupla in _listaMesesYAños)
            {
                lista.Add(tupla.Item1);
            }

            return lista;
        }

        public static List<int> ListaAños()
        {
            var lista = new List<int>();

            foreach (var tupla in _listaMesesYAños)
            {
                lista.Add(tupla.Item2);
            }

            return lista;
        }

        #endregion

        public List<ReporteMensualDTO> ObtenerPorId(long agenteId)
        {
            var lista = new List<ReporteMensualDTO>();

            var enumerador = Generador().GetEnumerator();
            enumerador.MoveNext();

            foreach (var dia in _listaDiasDelMes)
            {
                _horarioDia = HorarioDelDia(dia);


                if (_horarioDia != null)
                {
                    var _finMes = new DateTime(_fecha.Year, _fecha.Month, _diasMes);
                    var reporte = new ReporteMensualDTO();
                    var listaAccesosDelDia = ListaAccesosDelDia(dia);
                    bool porLlegarTarde;

                    reporte.AgenteId = _agenteId;
                    reporte.Numero = enumerador.Current;
                    reporte.Ausente = Ausente(dia, _horarioDia, listaAccesosDelDia);
                    

                    // Listas para las grillas de abajo

                    reporte.Comisiones = ComisionesEnElMes(dia);
                    reporte.Lactancias = LactanciasEnElMes(dia);
                    reporte.Novedades = NovedadesEnElMes(dia);

                    reporte.Fecha = dia;

                    // Horas de los accesos

                    reporte.HoraEntrada = listaAccesosDelDia.Where(acceso => acceso.TipoAcceso == "Entrada").Any() ? listaAccesosDelDia.Where(acceso => acceso.TipoAcceso == "Entrada").Last().Hora : (TimeSpan?)null;
                    reporte.HoraEntradaParcial = _horarioDia.HoraEntradaParcial == null ? null : listaAccesosDelDia.Where(acceso => acceso.TipoAcceso == "EntradaParacial").Any() ? listaAccesosDelDia.Where(acceso => acceso.TipoAcceso == "EntradaParacial").Last().Hora : (TimeSpan?)null;
                    reporte.HoraSalida = listaAccesosDelDia.Where(acceso => acceso.TipoAcceso == "Salida").Any() ? listaAccesosDelDia.Where(acceso => acceso.TipoAcceso == "Salida").Last().Hora : (TimeSpan?)null;
                    reporte.HoraSalidaParcial = _horarioDia.HoraSalidaParcial == null ? null : listaAccesosDelDia.Where(acceso => acceso.TipoAcceso == "SalidaParcial").Any() ? listaAccesosDelDia.Where(acceso => acceso.TipoAcceso == "SalidaParcial").Last().Hora : (TimeSpan?)null;

                    // Minutos tarde y minutos faltantes

                    reporte.MinutosTarde = Tardanza(listaAccesosDelDia, _horarioDia);
                    reporte.MinutosTardeExtension = _horarioDia.HoraEntradaParcial == null ? null : TardanzaExtension(listaAccesosDelDia, _horarioDia);
                    reporte.MinutosFaltantes = (reporte.HoraSalidaParcial != null && reporte.HoraEntrada != null) ? Diff((TimeSpan)reporte.HoraSalidaParcial, (TimeSpan)reporte.HoraEntrada) : (TimeSpan?)null;
                    reporte.MinutosFaltantesExtension = _horarioDia.HoraEntradaParcial == null ? ((reporte.HoraSalida != null && reporte.HoraEntrada != null) ? Diff(Diff((TimeSpan)reporte.HoraSalida, (TimeSpan)reporte.HoraEntrada), Diff((TimeSpan)_horarioDia.HoraSalida, (TimeSpan)_horarioDia.HoraEntrada)) : (TimeSpan?)null) : ((reporte.HoraSalida != null && reporte.HoraEntradaParcial != null) ? Diff(Diff((TimeSpan)reporte.HoraSalida, (TimeSpan)reporte.HoraEntradaParcial), Diff((TimeSpan)_horarioDia.HoraSalida, (TimeSpan)_horarioDia.HoraEntradaParcial)) : (TimeSpan?)null);

                    reporte.AusentePorLlegarTarde = ((TimeSpan?)reporte.MinutosTarde == null ? false : ((TimeSpan)reporte.MinutosTarde).TotalMinutes > _minutosToleranciaAusente);

                    enumerador.MoveNext();

                    lista.Add(reporte);
                }
            }

            return lista;
        }

        private TimeSpan Diff(TimeSpan mayor, TimeSpan menor)
        {
            return new TimeSpan(mayor.Ticks - menor.Ticks);
        }

        private List<ComisionServicioDTO> ComisionesEnElMes(DateTime currentDia)
        {
            var lista = new List<ComisionServicioDTO>();

            foreach (var comision in _listaComisiones)
            {
                if ((comision.FechaDesde.Date.CompareTo(currentDia.Date) <= 0) && (comision.FechaHasta == null || ((DateTime)comision.FechaHasta).Date.CompareTo(currentDia.Date) >= 0))
                {
                    lista.Add(comision);
                }
            }

            return lista;
        }

        private List<NovedadAgenteDTO> NovedadesEnElMes(DateTime currentDia)
        {
            var lista = new List<NovedadAgenteDTO>();

            foreach (var novedad in _listaNovedades)
            {
                if ((novedad.FechaDesde.Date.CompareTo(currentDia.Date) <= 0) && (novedad.FechaHasta == null || ((DateTime)novedad.FechaHasta).Date.CompareTo(currentDia.Date) >= 0))
                {
                    lista.Add(novedad);
                }
            }

            return lista;
        }

        private List<LactanciaDTO> LactanciasEnElMes(DateTime currentDia)
        {
            var lista = new List<LactanciaDTO>();

            foreach (var lactancia in _listaLactancias)
            {
                if ((lactancia.FechaDesde.Date.CompareTo(currentDia.Date) <= 0) && (lactancia.FechaHasta == null || ((DateTime)lactancia.FechaHasta).Date.CompareTo(currentDia.Date) >= 0))
                {
                    lista.Add(lactancia);
                }
            }

            return lista;
        }

        private List<DateTime> DiasDelMesConHorarios()
        {
            var lista = new List<DateTime>();

            for (var i = 1; i <= _diasMes; i++)
            {                
                var diaActual = new DateTime(_fecha.Year, _fecha.Month, i);

                if(diaActual <= DateTime.Now)
                {
                    if (_listaHorarios.Where(horario => (horario.FechaDesde.Date.CompareTo(diaActual.Date) <= 0) && (horario.FechaHasta == null || horario.FechaHasta.Date.CompareTo(diaActual.Date) >= 0)).Any())
                    {
                        lista.Add(diaActual);
                    }
                }
            }

            return lista;
        }

        private DetalleHorarioDTO HorarioDelDia(DateTime dia)
        {
            var cultura = new CultureInfo("es-AR");
            var diaStr = cultura.DateTimeFormat.GetDayName(dia.DayOfWeek) == "miércoles" ? "miercoles" : cultura.DateTimeFormat.GetDayName(dia.DayOfWeek) == "sábado" ? "sabado" : cultura.DateTimeFormat.GetDayName(dia.DayOfWeek);
            var diaCased = cultura.TextInfo.ToTitleCase(diaStr);

            foreach (var horario in _listaHorarios)
            {
                var valor = horario.GetType().GetProperty(diaCased).GetValue(horario, null);

                if((bool)valor)
                {
                    return horario;
                }
            }

            return null;
        }

        private IEnumerable<int> Generador()
        {
            for (var i = 1; i <= 31 ; i++)
            {
                yield return i;
            }
        }

        private List<AccesoDTO> ListaAccesosDelDia(DateTime fecha)
        {
            var lista = new List<AccesoDTO>();

            foreach (var item in _listaAccesosDelMes)
            {
                if (item.FechaHora.Date.Day == fecha.Date.Day) {
                    lista.Add(item);
                }
            }

            return lista;
        }


        private TimeSpan? Tardanza(List<AccesoDTO> accesosDia, DetalleHorarioDTO horarioDia)
        {
            TimeSpan? _horaEntradaAcceso = accesosDia.Where(acceso => acceso.TipoAcceso.Equals("Entrada")).Any() ? accesosDia.Where(acceso => acceso.TipoAcceso.Equals("Entrada")).Last().Hora : (TimeSpan?)null;
            TimeSpan? _horaEntradaHorario = horarioDia.HoraEntrada ?? null;

            if (_horaEntradaAcceso == null) return null;

            if (_horaEntradaAcceso > ((TimeSpan)_horaEntradaHorario).Add(TimeSpan.FromMinutes(_minutosToleranciaAusente)))
            {
                if (_horaEntradaAcceso > _horaEntradaHorario) return ((TimeSpan)_horaEntradaAcceso).Subtract((TimeSpan)_horaEntradaHorario);
                else return TimeSpan.Zero;
            }
            else return null;
        }

        private TimeSpan? TardanzaExtension(List<AccesoDTO> accesosDia, DetalleHorarioDTO horarioDia)
        {
            TimeSpan? _horaEntradaExtensionAcceso = accesosDia.Where(acceso => acceso.TipoAcceso.Equals("EntradaParacial")).Any() ? accesosDia.Where(acceso => acceso.TipoAcceso.Equals("EntradaParacial")).Last().Hora : (TimeSpan?)null;
            TimeSpan? _horaEntradaParcialHorario = horarioDia.HoraEntradaParcial ?? null;

            if (_horaEntradaExtensionAcceso == null) return null;

            if (_horaEntradaExtensionAcceso > ((TimeSpan)_horaEntradaParcialHorario).Add(TimeSpan.FromMinutes(_minutosToleranciaAusente)))
            {
                if (_horaEntradaExtensionAcceso > _horaEntradaParcialHorario) return ((TimeSpan)_horaEntradaExtensionAcceso).Subtract((TimeSpan)_horaEntradaParcialHorario);
                else return TimeSpan.Zero;
            }
            else return null;
        }

        private bool Ausente(DateTime fecha, DetalleHorarioDTO horarioDia, List<AccesoDTO> _listaAccesosDía)
        {
            int _numeroEntradasDia = _listaAccesosDía.Where(acceso => acceso.TipoAcceso.ToString().Contains("Entrada")).Count();

            bool _hayNovedadHoraEntrada;
            bool _hayNovedadHoraEntradaParcial;
            bool _hayComisionServicioHoraEntrada;
            bool _hayComisionServicioHoraEntradaParcial;

            var listaComisonesServicioDelDia = ComisionesEnElMes(fecha);
            var listaNovedadesDelDia = NovedadesEnElMes(fecha);

            _hayNovedadHoraEntrada = listaNovedadesDelDia.Any() ? (listaNovedadesDelDia.Where(novedad => ((novedad.HoraDesde <= horarioDia.HoraEntrada) && (novedad.HoraHasta >= horarioDia.HoraEntrada))).Any() ? true : false) : false;
            _hayComisionServicioHoraEntrada = listaComisonesServicioDelDia.Any() ? (listaComisonesServicioDelDia.Where(comision => (((comision.HoraInicio <= horarioDia.HoraEntrada) && (comision.HoraFin >= horarioDia.HoraEntrada)) || comision.JornadaCompleta)).Any() ? true : false) : false;

            if (horarioDia.HoraEntradaParcial == null) // Si el horario no incluye entrada parcial
            {
                if (_hayNovedadHoraEntrada || _hayComisionServicioHoraEntrada) // Primer check (novedades y comision de servicio)
                {
                    return false;
                }
                else if (_listaAccesosDía.Any() || _numeroEntradasDia == 1) // Segundo check (horarios y accesos)
                {
                    if (Tardanza(_listaAccesosDía, horarioDia) != null) // Tercer check (tardanza)
                    {
                        return true;
                    }
                    return false;
                }
                return true;
            }
            else // Si el horario sí incluye entrada parcial
            {
                _hayNovedadHoraEntradaParcial = listaNovedadesDelDia.Any() ? (listaNovedadesDelDia.Where(novedad => (((TimeSpan)novedad.HoraDesde).CompareTo(horarioDia.HoraEntradaParcial) <= 0) && ((novedad.HoraHasta == null) || (((TimeSpan)novedad.HoraHasta).CompareTo(horarioDia.HoraEntradaParcial) >= 0))).Any() ? true : false) : false;
                _hayComisionServicioHoraEntradaParcial = listaComisonesServicioDelDia.Any() ? (listaComisonesServicioDelDia.Where(comision => (((comision.HoraInicio <= horarioDia.HoraEntradaParcial) && (comision.HoraFin >= horarioDia.HoraEntradaParcial)) || comision.JornadaCompleta)).Any() ? true : false) : false;

                if (_hayNovedadHoraEntrada || _hayComisionServicioHoraEntrada) // Primer check (novedades y comision de servicio)
                {
                    return false;
                }
                else if (_listaAccesosDía.Count() > 0 && (_hayNovedadHoraEntradaParcial || _hayComisionServicioHoraEntradaParcial)) return false; // Segundo check (novedades y comisión de servicio por la tarde)
                else if (_listaAccesosDía.Count() > 0 && _numeroEntradasDia == 2) // Tercer check (horarios y accesos)
                {
                    if (Tardanza(_listaAccesosDía, horarioDia) != null && TardanzaExtension(_listaAccesosDía, horarioDia) != null) // Cuarto check (tardanza)
                    {
                        return false;
                    }
                    return false;
                }
                return true;
            }            
        }
    }
}
