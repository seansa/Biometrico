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
        private int _diasDelMes;

        public ReporteMensualServicio(long AgenteId, DateTime fecha)
        {
            _agenteId = AgenteId;
            _fecha = fecha;
            _diasDelMes = DateTime.DaysInMonth(_fecha.Year, _fecha.Month);

            _agenteServicio = new AgenteServicio();
            _accesoServicio = new AccesoServicio();
            _horarioServicio = new HorarioServicio();
            _comisionServicio = new ComisionServicio.ComisionServicio();
            _novedadesServicio = new NovedadAgenteServicio();
            _lactanciaServicio = new LactanciaServicio();

            _listaHorarios = _horarioServicio.ObtenerHorariosPorId(_agenteId).AsParallel().ToList();
            _listaAccesosDelMes = _accesoServicio.ObtenerPorId(_agenteId).Where(acceso => acceso.FechaHora.Month == _fecha.Month).AsParallel().ToList();
            _listaComisiones = _comisionServicio.ObtenerPorFiltro(_agenteId).AsParallel().ToList();
            _listaNovedades = _novedadesServicio.ObtenerPorId(_agenteId).AsParallel().ToList();
            _listaLactancias = _lactanciaServicio.ObtenerPorFiltro(_agenteId).AsParallel().ToList();           

            _minutosToleranciaAusente = ConfiguracionServicio.MinutosToleranciaAusente ?? 15;
            _minutosToleranciaLlegadaTarde = ConfiguracionServicio.MinutosToleranciaLlegadaTarde ?? 10;
        }

        #region Statics

        public static List<string> ListaMeses()
        {
            var lista = new List<string>();
            var cultura = new CultureInfo("es-Ar");

            for (int i = 1; i <= 12; i++)
            {
                lista.Add(cultura.TextInfo.ToTitleCase(cultura.DateTimeFormat.GetMonthName(i).ToString()));
            }

            return lista;
        }

        public static List<int> ListaAños()
        {
            int añoActual = DateTime.Now.Year;
            return Enumerable.Range(añoActual - 10, añoActual - (añoActual - 10) + 1).OrderByDescending(año => año).AsParallel().ToList();
        }

        #endregion

        public List<ReporteMensualDTO> ObtenerPorId(long agenteId, int año, int mes)
        {
            var lista = new List<ReporteMensualDTO>();

            for (int i = 1; i <= _diasDelMes; i++)
            {
                var dia = new DateTime(año, mes, i);
                _horarioDia = HorarioDelDia(dia);
                var _finMes = new DateTime(_fecha.Year, _fecha.Month, _diasDelMes);
                var reporte = new ReporteMensualDTO();
                bool? porLlegarTarde = null;
                var listaAccesosDelDia = ListaAccesosDelDia(dia);
                _diasDelMes = DateTime.DaysInMonth(dia.Year, dia.Month);

                if (_horarioDia != null)
                {
                    reporte.AgenteId = _agenteId;
                    reporte.Numero = i;

                    // Listas para las grillas de abajo

                    reporte.Comisiones = ComisionesEnElMes(dia) ?? new List<ComisionServicioDTO>();
                    reporte.Lactancias = LactanciasEnElMes(dia) ?? new List<LactanciaDTO>();
                    reporte.Novedades = NovedadesEnElMes(dia) ?? new List<NovedadAgenteDTO>();

                    reporte.Fecha = dia;
                    reporte.Dia = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dia.ToString("dddd", new CultureInfo("es-Ar")));

                    // Horas de los accesos

                    reporte.HoraEntrada = listaAccesosDelDia == null ? null : listaAccesosDelDia.Where(acceso => acceso.TipoAcceso == "Entrada").Any() ? listaAccesosDelDia.Where(acceso => acceso.TipoAcceso == "Entrada").Last().Hora : (TimeSpan?)null;
                    reporte.HoraEntradaParcial = listaAccesosDelDia == null ? null : _horarioDia.HoraEntradaParcial == null ? null : listaAccesosDelDia.Where(acceso => acceso.TipoAcceso == "EntradaParacial").Any() ? listaAccesosDelDia.Where(acceso => acceso.TipoAcceso == "EntradaParacial").Last().Hora : (TimeSpan?)null;
                    reporte.HoraSalida = listaAccesosDelDia == null ? null : listaAccesosDelDia.Where(acceso => acceso.TipoAcceso == "Salida").Any() ? listaAccesosDelDia.Where(acceso => acceso.TipoAcceso == "Salida").Last().Hora : (TimeSpan?)null;
                    reporte.HoraSalidaParcial = listaAccesosDelDia == null ? null : _horarioDia.HoraSalidaParcial == null ? null : listaAccesosDelDia.Where(acceso => acceso.TipoAcceso == "SalidaParcial").Any() ? listaAccesosDelDia.Where(acceso => acceso.TipoAcceso == "SalidaParcial").Last().Hora : (TimeSpan?)null;

                    // Minutos tarde y minutos faltantes

                    reporte.MinutosTarde = listaAccesosDelDia == null ? null : Tardanza(listaAccesosDelDia, _horarioDia);
                    reporte.MinutosTardeExtension = listaAccesosDelDia == null ? null : _horarioDia.HoraEntradaParcial == null ? null : TardanzaExtension(listaAccesosDelDia, _horarioDia);
                    reporte.MinutosFaltantes = listaAccesosDelDia == null ? null : (reporte.HoraSalidaParcial != null && reporte.HoraEntrada != null) ? Diff((TimeSpan)reporte.HoraSalidaParcial, (TimeSpan)reporte.HoraEntrada) : (TimeSpan?)null;
                    reporte.MinutosFaltantesExtension = listaAccesosDelDia == null ? null : _horarioDia.HoraEntradaParcial == null ? ((reporte.HoraSalida != null && reporte.HoraEntrada != null) ? Diff(Diff((TimeSpan)reporte.HoraSalida, (TimeSpan)reporte.HoraEntrada), Diff((TimeSpan)_horarioDia.HoraSalida, (TimeSpan)_horarioDia.HoraEntrada)) : (TimeSpan?)null) : ((reporte.HoraSalida != null && reporte.HoraEntradaParcial != null) ? Diff(Diff((TimeSpan)reporte.HoraSalida, (TimeSpan)reporte.HoraEntradaParcial), Diff((TimeSpan)_horarioDia.HoraSalida, (TimeSpan)_horarioDia.HoraEntradaParcial)) : (TimeSpan?)null);

                    reporte.Ausente = listaAccesosDelDia == null ? (bool?)null : Ausente(dia, _horarioDia, listaAccesosDelDia, out porLlegarTarde) || ((reporte.MinutosTarde != null) && ((TimeSpan)reporte.MinutosTarde).TotalMinutes > _minutosToleranciaAusente ? true : false);
                    reporte.AusentePorLlegarTarde = listaAccesosDelDia == null ? (bool?)null : porLlegarTarde;
                }
                else
                {
                    reporte.AgenteId = _agenteId;
                    reporte.Numero = i;
                    reporte.Ausente = null;

                    // Listas para las grillas de abajo

                    reporte.Comisiones = ComisionesEnElMes(dia) ?? new List<ComisionServicioDTO>();
                    reporte.Lactancias = LactanciasEnElMes(dia) ?? new List<LactanciaDTO>();
                    reporte.Novedades = NovedadesEnElMes(dia) ?? new List<NovedadAgenteDTO>();

                    reporte.Fecha = dia;
                    reporte.Dia = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dia.ToString("dddd", new CultureInfo("es-Ar")));

                    // Horas de los accesos

                    reporte.HoraEntrada = null;
                    reporte.HoraEntradaParcial = null;
                    reporte.HoraSalida = null;
                    reporte.HoraSalidaParcial = null;

                    // Minutos tarde y minutos faltantes

                    reporte.MinutosTarde = null;
                    reporte.MinutosTardeExtension = null;
                    reporte.MinutosFaltantes = null;
                    reporte.MinutosFaltantesExtension = null;

                    reporte.AusentePorLlegarTarde = null;
                }

                lista.Add(reporte);
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
                if ((lactancia.FechaDesde.Month.CompareTo(currentDia.Month) <= 0) && (lactancia.FechaHasta == null || ((DateTime)lactancia.FechaHasta).Month.CompareTo(currentDia.Month) >= 0))
                {
                    lista.Add(lactancia);
                }
            }

            return lista;
        }

        private int DiasDelMes(int año, int mes)
        {
            return DateTime.DaysInMonth(año, mes);
        }

        private DetalleHorarioDTO HorarioDelDia(DateTime dia)
        {
            var cultura = new CultureInfo("es-AR");
            var diaStr = cultura.DateTimeFormat.GetDayName(dia.DayOfWeek) == "miércoles" ? "miercoles" : cultura.DateTimeFormat.GetDayName(dia.DayOfWeek) == "sábado" ? "sabado" : cultura.DateTimeFormat.GetDayName(dia.DayOfWeek);
            var diaCased = cultura.TextInfo.ToTitleCase(diaStr);

            foreach (var horario in _listaHorarios)
            {
                var valor = horario.GetType().GetProperty(diaCased).GetValue(horario, null);

                if((bool)valor && horario.FechaDesde.Date <= dia.Date && horario.FechaHasta.Date >= dia.Date)
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
            TimeSpan _horaEntradaHorario = (TimeSpan)horarioDia.HoraEntrada;

            if (_horaEntradaAcceso != null && ((TimeSpan)_horaEntradaAcceso).TotalMinutes > _horaEntradaHorario.TotalMinutes)
            {
                return Diff(_horaEntradaHorario, (TimeSpan)_horaEntradaAcceso);
            }
            else return null;
        }

        private TimeSpan? TardanzaExtension(List<AccesoDTO> accesosDia, DetalleHorarioDTO horarioDia)
        {
            TimeSpan? _horaEntradaParcialAcceso = accesosDia.Where(acceso => acceso.TipoAcceso.Equals("EntradaParacial")).Any() ? accesosDia.Where(acceso => acceso.TipoAcceso.Equals("EntradaParacial")).Last().Hora : (TimeSpan?)null;
            TimeSpan _horaEntradaParcialHorario = (TimeSpan)horarioDia.HoraEntradaParcial;

            if (_horaEntradaParcialAcceso > _horaEntradaParcialHorario && _horaEntradaParcialAcceso != null)
            {
                return Diff(_horaEntradaParcialHorario, (TimeSpan)_horaEntradaParcialAcceso);
            }
            else return null;
        }

        private bool TardanzaSuperaLimite(TimeSpan? tardanza, int limite)
        {
            if (tardanza != null && (((TimeSpan)tardanza).TotalMinutes > limite || ((TimeSpan)tardanza).TotalMinutes  + limite < 0)) return true;
            return false;
        }

        private bool Ausente(DateTime fecha, DetalleHorarioDTO horarioDia, List<AccesoDTO> _listaAccesosDía, out bool? porLlegarTarde)
        {
            bool _hayNovedadHoraEntrada;
            bool _hayComisionServicioHoraEntrada;

            var listaComisonesServicioDelDia = ComisionesEnElMes(fecha).Where(comision => (comision.FechaDesde <= fecha) && (comision.FechaHasta >= fecha)).AsParallel().ToList();
            var listaNovedadesDelDia = NovedadesEnElMes(fecha).Where(novedad => (novedad.FechaDesde <= fecha) && (novedad.FechaHasta >= fecha)).AsParallel().ToList(); ;
            porLlegarTarde = false;

            _hayNovedadHoraEntrada = listaNovedadesDelDia.Any() ? (listaNovedadesDelDia.Where(novedad => ((novedad.HoraDesde <= horarioDia.HoraEntrada) && (novedad.HoraHasta >= horarioDia.HoraEntrada))).Any() ? true : false) : false;
            _hayComisionServicioHoraEntrada = listaComisonesServicioDelDia.Any() ? (listaComisonesServicioDelDia.Where(comision => (((comision.HoraInicio <= horarioDia.HoraEntrada) && (comision.HoraFin >= horarioDia.HoraEntrada)) || comision.JornadaCompleta)).Any() ? true : false) : false;

            if (_hayNovedadHoraEntrada || _hayComisionServicioHoraEntrada) // Primer check (novedades y comision de servicio)
            {
                return false;
            }
            else if (_listaAccesosDía.Any()) // Segundo check (horarios y accesos)
            {
                if (TardanzaSuperaLimite(Tardanza(_listaAccesosDía, horarioDia), _minutosToleranciaAusente)) // Tercer check (tardanza)
                {
                    porLlegarTarde = true;
                    return true;
                }
                return false;
            }
            else if (fecha.Date <= DateTime.Now.Date) return true;
            return false;
        }
    }
}
