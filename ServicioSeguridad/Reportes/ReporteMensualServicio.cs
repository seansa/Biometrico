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
        private List<AccesoDTO> _listaAccesos;
        private List<ComisionServicioDTO> _listaComisiones;
        private List<NovedadAgenteDTO> _listaNovedades;
        private List<AccesoDTO> _listaAccesosDía;
        private List<LactanciaDTO> _listaLactancias;

        private DateTime _fecha;
        private string _dia;
        DetalleHorarioDTO _horarioDia;
        private int _minutosToleranciaLlegadaTarde;
        private int _minutosToleranciaAusente;

        private static List<Tuple<string, int>> _listaMesesYAños = ListaMesesYAños();


        public ReporteMensualServicio(long AgenteId, DateTime fecha)
        {
            _agenteId = AgenteId;
            _fecha = fecha;

            _agenteServicio = new AgenteServicio();
            _accesoServicio = new AccesoServicio();
            _horarioServicio = new HorarioServicio();
            _comisionServicio = new ComisionServicio.ComisionServicio();
            _novedadesServicio = new NovedadAgenteServicio();
            _lactanciaServicio = new LactanciaServicio();

            _listaHorarios = _horarioServicio.ObtenerHorariosPorId(_agenteId).ToList();
            _listaAccesos = _accesoServicio.ObtenerPorId(_agenteId).ToList();
            _listaComisiones = _comisionServicio.ObtenerPorFiltro(_agenteId).ToList();
            _listaNovedades = _novedadesServicio.ObtenerPorId(_agenteId).ToList();
            _listaLactancias = _lactanciaServicio.ObtenerPorFiltro(_agenteId).ToList();
            _listaAccesosDía = _listaAccesos.Where(acceso => acceso.FechaHora.Date == _fecha.Date).Select(acceso => acceso).ToList();

            _dia = new CultureInfo("es-Ar").TextInfo.ToTitleCase(_fecha.Date.ToString("dddd", new CultureInfo("es-Ar")));
            _horarioDia = _listaHorarios.Where(horario => (bool)horario.GetType().GetProperty(_dia).GetValue(horario, null) == true).Select(horario => horario).SingleOrDefault();
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

        public IEnumerable<ReporteMensualDTO> ObtenerPorId(long agenteId)
        {
            using (var _context = new ModeloBometricoContainer())
            {
                if (_horarioDia != null)
                {
                    var reporte = new ReporteMensualDTO();

                    reporte.AgenteId = _agenteId;
                    reporte.Accesos = _listaAccesosDía;
                    reporte.Numero = Generador().Single();
                    reporte.Ausente = Ausente(_fecha, _horarioDia);
                    reporte.Comision = _listaComisiones.Where(comision => comision.FechaDesde.Date < _fecha && (comision.FechaHasta == null || ((DateTime)comision.FechaHasta).Date > _fecha)).SingleOrDefault();
                    reporte.Lactancia = _listaLactancias.Where(lactancia => lactancia.FechaDesde.Date < _fecha && (lactancia.FechaHasta == null || ((DateTime)lactancia.FechaHasta).Date > _fecha)).SingleOrDefault();
                    reporte.Novedad = reporte.Novedad = _listaNovedades.Where(novedad => novedad.FechaDesde.Date < _fecha && (novedad.FechaHasta == null || ((DateTime)novedad.FechaHasta).Date > _fecha)).SingleOrDefault();
                    reporte.Fecha = _fecha;
                    reporte.HoraEntrada = _listaAccesosDía.Where(acceso => acceso.TipoAcceso == "Entrada").SingleOrDefault().FechaHora;
                    reporte.HoraEntradaParcial = _listaAccesosDía.Where(acceso => acceso.TipoAcceso == "Entrada Parcial").SingleOrDefault().FechaHora;
                    reporte.HoraSalida = _listaAccesosDía.Where(acceso => acceso.TipoAcceso == "Salida").SingleOrDefault().FechaHora;
                    reporte.HoraSalidaParcial = _listaAccesosDía.Where(acceso => acceso.TipoAcceso == "Salida Parcial").SingleOrDefault().FechaHora;
                    reporte.MinutosTarde = Tardanza(_listaAccesosDía, _horarioDia);
                    reporte.MinutosTardeExtension = TardanzaExtension(_listaAccesosDía, _horarioDia);
                    reporte.MinutosFaltantes = null;
                    reporte.MinutosFaltantesExtension = null;

                    yield return reporte;
                }
            }
        }

        public IEnumerable<int> Generador()
        {
            for (var i = 1; ; ++i)
            {
                yield return i;
            }
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

        private bool Ausente(DateTime fecha, DetalleHorarioDTO horarioDia)
        {
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
