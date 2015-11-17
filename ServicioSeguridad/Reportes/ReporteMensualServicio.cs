﻿using AccesoDatos;
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

            _dia = new CultureInfo("es-Ar").TextInfo.ToTitleCase(_fecha.Date.ToString("dddd", new CultureInfo("es-Ar")));
            _horarioDia = _listaHorarios.Where(horario => (bool)horario.GetType().GetProperty(_dia).GetValue(horario, null) == true).SingleOrDefault();
            //_minutosToleranciaAusente = ConfiguracionServicio.MinutosToleranciaAusente;
            //_minutosToleranciaLlegadaTarde = ConfiguracionServicio.MinutosToleranciaLlegadaTarde;


            ////// Config (falta formulario)
            _minutosToleranciaAusente = 15;
            _minutosToleranciaLlegadaTarde = 10;

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

            if (_horarioDia != null)
            {
                var enumerador = Generador().GetEnumerator();
                var _finMes = new DateTime(_fecha.Year, _fecha.Month, _diasMes);
                enumerador.MoveNext();

                foreach (var dia in _listaDiasDelMes)
                {
                    var reporte = new ReporteMensualDTO();
                    var listaAccesosDelDia = ListaAccesosDelDia(dia);

                    reporte.AgenteId = _agenteId;
                    reporte.Numero = enumerador.Current;
                    reporte.Ausente = Ausente(dia, _horarioDia, listaAccesosDelDia);

                    // Listas para las grillas de abajo

                    reporte.Comisiones = _listaComisiones.Where(comision => comision.FechaDesde.Date <= _fecha.Date && (comision.FechaHasta == null || ((DateTime)comision.FechaHasta).Date >= _finMes.Date)).Select(comision => comision).ToList();
                    reporte.Lactancias = _listaLactancias.Where(lactancia => lactancia.FechaDesde.Date <= _fecha.Date && (lactancia.FechaHasta == null || ((DateTime)lactancia.FechaHasta).Date >= _finMes.Date)).Select(lactancia => lactancia).ToList();
                    reporte.Novedades = _listaNovedades.Where(novedad => novedad.FechaDesde.Date <= _fecha.Date && (novedad.FechaHasta == null || ((DateTime)novedad.FechaHasta).Date > _finMes.Date)).Select(novedad => novedad).ToList();

                    reporte.Fecha = dia;

                    // Horas de los accesos

                    reporte.HoraEntrada = listaAccesosDelDia.Where(acceso => acceso.TipoAcceso == "Entrada").Any() ? listaAccesosDelDia.Where(acceso => acceso.TipoAcceso == "Entrada").Single().FechaHora : (DateTime?)null;
                    reporte.HoraEntradaParcial = listaAccesosDelDia.Where(acceso => acceso.TipoAcceso == "Entrada Parcial").Any() ? listaAccesosDelDia.Where(acceso => acceso.TipoAcceso == "Entrada Parcial").Single().FechaHora : (DateTime?)null;
                    reporte.HoraSalida = listaAccesosDelDia.Where(acceso => acceso.TipoAcceso == "Salida").Any() ? listaAccesosDelDia.Where(acceso => acceso.TipoAcceso == "Salida").Single().FechaHora : (DateTime?)null;
                    reporte.HoraSalidaParcial = listaAccesosDelDia.Where(acceso => acceso.TipoAcceso == "Salida Parcial").Any() ? listaAccesosDelDia.Where(acceso => acceso.TipoAcceso == "Salida Parcial").Single().FechaHora : (DateTime?)null;

                    // Minutos tarde y minutos faltantes

                    reporte.MinutosTarde = Tardanza(listaAccesosDelDia, _horarioDia);
                    reporte.MinutosTardeExtension = TardanzaExtension(listaAccesosDelDia, _horarioDia);
                    reporte.MinutosFaltantes = null;
                    reporte.MinutosFaltantesExtension = null;

                    enumerador.MoveNext();

                    lista.Add(reporte);
                }
            }

            return lista;
        }

        public List<DateTime> DiasDelMesConHorarios()
        {
            var lista = new List<DateTime>();

            for (var i = 1; i <= _diasMes; i++)
            {                
                var diaActual = new DateTime(_fecha.Year, _fecha.Month, i);

                if(diaActual <= DateTime.Now)
                {
                    if (_listaHorarios.Where(horario => (horario.FechaDesde.Date < diaActual.Date) && (horario.FechaHasta == null || horario.FechaHasta.Date > diaActual.Date)).Any())
                    {
                        lista.Add(diaActual);
                    }
                }
            }

            return lista;
        }

        public IEnumerable<int> Generador()
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
                if (item.FechaHora.Day == fecha.Day - 1) {
                    lista.Add(item);
                }
            }

            return lista;
        }

        private TimeSpan? Tardanza(List<AccesoDTO> accesosDia, DetalleHorarioDTO horarioDia)
        {
            TimeSpan? _horaEntradaAcceso = accesosDia.Where(acceso => acceso.TipoAcceso.Equals("Entrada")).Any() ? accesosDia.Where(acceso => acceso.TipoAcceso.Equals("Entrada")).Single().FechaHora.TimeOfDay : (TimeSpan?)null;
            TimeSpan? _horaEntradaHorario = horarioDia.HoraEntrada ?? null;

            if (_horaEntradaAcceso == null) return null;

            if (_horaEntradaAcceso <= ((TimeSpan)_horaEntradaHorario).Add(TimeSpan.FromMinutes(_minutosToleranciaAusente)))
            {
                if (_horaEntradaAcceso > _horaEntradaHorario) return ((TimeSpan)_horaEntradaAcceso).Subtract((TimeSpan)_horaEntradaHorario);
                else return TimeSpan.Zero;
            }
            else return null;
        }

        private TimeSpan? TardanzaExtension(List<AccesoDTO> accesosDia, DetalleHorarioDTO horarioDia)
        {
            TimeSpan? _horaEntradaExtensionAcceso = accesosDia.Where(acceso => acceso.TipoAcceso.Equals("Entrada Parcial")).Any() ? accesosDia.Where(acceso => acceso.TipoAcceso.Equals("Entrada Parcial")).Single().FechaHora.TimeOfDay : (TimeSpan?)null;
            TimeSpan? _horaEntradaParcialHorario = horarioDia.HoraEntradaParcial ?? null;

            if (_horaEntradaExtensionAcceso == null) return null;

            if (_horaEntradaExtensionAcceso <= ((TimeSpan)_horaEntradaParcialHorario).Add(TimeSpan.FromMinutes(_minutosToleranciaAusente)))
            {
                if (_horaEntradaExtensionAcceso > _horaEntradaParcialHorario) return ((TimeSpan)_horaEntradaExtensionAcceso).Subtract((TimeSpan)_horaEntradaParcialHorario);
                else return TimeSpan.Zero;
            }
            else return null;
        }

        private bool Ausente(DateTime fecha, DetalleHorarioDTO horarioDia, List<AccesoDTO> _listaAccesosDía)
        {
            int _numeroEntradasDia = _listaAccesosDía.Where(acceso => acceso.TipoAcceso.Contains("Entrada")).Select(acceso => acceso).Count();

            bool _hayNovedadHoraEntrada;
            bool _hayNovedadHoraEntradaParcial;
            bool _hayComisionServicioHoraEntrada;
            bool _hayComisionServicioHoraEntradaParcial;

            var listaComisonesServicioDelDia = _listaComisiones.Where(comision => comision.FechaDesde.Date <= fecha.Date && ((DateTime)comision.FechaHasta).Date >= fecha.Date).Select(comision => comision).ToList();

            _hayNovedadHoraEntrada = _listaNovedades.Count() > 0 ? (_listaNovedades.Where(novedad => (novedad.HoraDesde <= horarioDia.HoraEntrada) && ((novedad.HoraHasta == null) || (novedad.HoraHasta >= horarioDia.HoraEntrada))).Select(novedad => novedad).Count() > 0 ? true : false) : false;
            _hayComisionServicioHoraEntrada = listaComisonesServicioDelDia.Count() > 0 ? (listaComisonesServicioDelDia.Where(comision => (comision.HoraInicio <= horarioDia.HoraEntrada) && (comision.HoraFin >= horarioDia.HoraEntrada)).Select(comision => comision).Count() > 0 ? true : false) : false;

            if (horarioDia.HoraEntradaParcial.Equals(null)) // Si el horario no incluye entrada parcial
            {
                if (_hayNovedadHoraEntrada || _hayComisionServicioHoraEntrada) // Primer check (novedades y comision de servicio)
                {
                    return false;
                }
                else if (_listaAccesosDía.Count() > 0 && _numeroEntradasDia == 1) // Segundo check (horarios y accesos)
                {
                    if (Tardanza(_listaAccesosDía, horarioDia) != null) // Tercer check (tardanza)
                    {
                        return false;
                    }
                    return true;
                }
                return true;
            }
            else // Si el horario sí incluye entrada parcial
            {
                _hayNovedadHoraEntradaParcial = _listaNovedades.Count() > 0 ? (_listaNovedades.Where(novedad => (novedad.HoraDesde <= horarioDia.HoraEntradaParcial) && ((novedad.HoraHasta == null) || (novedad.HoraHasta >= horarioDia.HoraEntradaParcial))).Select(novedad => novedad).Count() > 0 ? true : false) : false;
                _hayComisionServicioHoraEntradaParcial = listaComisonesServicioDelDia.Count() > 0 ? (listaComisonesServicioDelDia.Where(comision => (comision.HoraInicio <= horarioDia.HoraEntradaParcial) && (comision.HoraFin >= horarioDia.HoraEntradaParcial)).Select(comision => comision).Count() > 0 ? true : false) : false;

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
                    return true;
                }
                return true;
            }            
        }
    }
}
