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

namespace Servicio.RecursoHumano.Reportes
{
    public class ReporteMensualServicio : IReporteMensualServicio
    {
        private readonly long _agenteId;
        private readonly IAccesoServicio _accesoServicio;
        private readonly IHorarioServicio _horarioServicio;
        private readonly IComisionServicio _comisionServicio;
        private readonly INovedadAgenteServicio _novedadesServicio;
        
        private List<DetalleHorarioDTO> _listaHorarios;
        private List<AccesoDTO> _listaAccesos;
        private List<ComisionServicioDTO> _listaComisiones;
        private List<NovedadAgenteDTO> _listaNovedades;

        private int _minutosToleranciaLlegadaTarde;
        private int _minutosToleranciaAusente;

        private static List<Tuple<string, int>> _listaMesesYAños = ListaMesesYAños();


        public ReporteMensualServicio(long AgenteId)
        {
            _agenteId = AgenteId;
            
            _accesoServicio = new AccesoServicio();
            _horarioServicio = new HorarioServicio();
            _comisionServicio = new ComisionServicio.ComisionServicio();
            _novedadesServicio = new NovedadAgenteServicio();

            _listaHorarios = _horarioServicio.ObtenerHorariosPorId(_agenteId).ToList();
            _listaAccesos = _accesoServicio.ObtenerPorId(_agenteId).ToList();
            _listaComisiones = _comisionServicio.ObtenerPorFiltro(_agenteId).ToList();
            _listaNovedades = _novedadesServicio.ObtenerPorId(_agenteId).ToList();
        }

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

        private TimeSpan? Tardanza(List<AccesoDTO> accesosDia, DetalleHorarioDTO horarioDia)
        {
            TimeSpan _horaEntradaAcceso = accesosDia.Where(acceso => acceso.TipoAcceso.Equals("Entrada")).Single().FechaHora.TimeOfDay;
            TimeSpan _horaEntradaHorario = (TimeSpan)horarioDia.HoraEntrada;

            if (_horaEntradaAcceso <= _horaEntradaHorario.Add(TimeSpan.FromMinutes(_minutosToleranciaAusente)))
            {
                if (_horaEntradaAcceso > _horaEntradaHorario) return _horaEntradaAcceso.Subtract(_horaEntradaHorario);
                else return TimeSpan.Zero;
            }
            else return null;
        }

        private TimeSpan? TardanzaExtension(List<AccesoDTO> accesosDia, DetalleHorarioDTO horarioDia)
        {
            TimeSpan _horaEntradaExtensionAcceso = accesosDia.Where(acceso => acceso.TipoAcceso.Equals("Entrada Parcial")).Single().FechaHora.TimeOfDay;
            TimeSpan _horaEntradaParcialHorario = (TimeSpan)horarioDia.HoraEntradaParcial;

            if (_horaEntradaExtensionAcceso <= _horaEntradaParcialHorario.Add(TimeSpan.FromMinutes(_minutosToleranciaAusente)))
            {
                if (_horaEntradaExtensionAcceso > _horaEntradaParcialHorario) return _horaEntradaExtensionAcceso.Subtract(_horaEntradaParcialHorario);
                else return TimeSpan.Zero;
            }
            else return null;
        }

        private bool DiaConHorario(DateTime fecha)
        {
            string _dia = fecha.Date.ToString("dddd", new CultureInfo("es-Ar"));
            DetalleHorarioDTO _horarioDia = _listaHorarios.Where(horario => _dia == (string)horario.GetType().GetProperty(_dia).GetValue(horario, null)).Select(horario => horario).SingleOrDefault();

            if (_horarioDia != null) return true;
            else return false;
        }

        private bool Ausente(DateTime fecha, DetalleHorarioDTO horarioDia)
        {
            string _dia = fecha.Date.ToString("dddd", new CultureInfo("es-Ar"));

            List<AccesoDTO> _listaAccesosDía = _listaAccesos.Where(acceso => acceso.FechaHora.Date == fecha.Date).Select(acceso => acceso).ToList();

            int _numeroEntradasDia = _listaAccesosDía.Where(acceso => acceso.TipoAcceso.Contains("Entrada")).Select(acceso => acceso).Count();

            bool _hayNovedadHoraEntrada;
            bool _hayNovedadHoraEntradaParcial;
            bool _hayComisionServicioHoraEntrada;
            bool _hayComisionServicioHoraEntradaParcial;

            _hayNovedadHoraEntrada = _listaNovedades.Count() > 0 ? (_listaNovedades.Where(novedad => (novedad.HoraDesde < horarioDia.HoraEntrada) && ((novedad.HoraHasta == null) || (novedad.HoraHasta > horarioDia.HoraEntrada))).Select(novedad => novedad).Count() > 0 ? true : false) : false;
            _hayComisionServicioHoraEntrada = _listaComisiones.Count() > 0 ? (_listaComisiones.Where(comision => (comision.HoraInicio < horarioDia.HoraEntrada) && (comision.HoraFin > horarioDia.HoraEntrada)).Select(comision => comision).Count() > 0 ? true : false) : false;

            if (horarioDia.HoraEntradaParcial == null) // Si el horario no incluye entrada parcial
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
                _hayNovedadHoraEntradaParcial = _listaNovedades.Count() > 0 ? (_listaNovedades.Where(novedad => (novedad.HoraDesde < horarioDia.HoraEntradaParcial) && ((novedad.HoraHasta == null) || (novedad.HoraHasta > horarioDia.HoraEntradaParcial))).Select(novedad => novedad).Count() > 0 ? true : false) : false;
                _hayComisionServicioHoraEntradaParcial = _listaComisiones.Count() > 0 ? (_listaComisiones.Where(comision => (comision.HoraInicio < horarioDia.HoraEntradaParcial) && (comision.HoraFin > horarioDia.HoraEntradaParcial)).Select(comision => comision).Count() > 0 ? true : false) : false;

                if (_hayNovedadHoraEntrada || _hayNovedadHoraEntradaParcial || _hayComisionServicioHoraEntrada || _hayComisionServicioHoraEntradaParcial) // Primer check (novedades y comision de servicio)
                {
                    return false;
                }
                else if (_listaAccesosDía.Count() > 0 && _numeroEntradasDia == 2) // Segundo check (horarios y accesos)
                {
                    if (Tardanza(_listaAccesosDía, horarioDia) != null && TardanzaExtension(_listaAccesosDía, horarioDia) != null) // Tercer check (tardanza)
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
