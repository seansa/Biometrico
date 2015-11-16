using Servicio.RecursoHumano.Agente.DTOs;
using Servicio.RecursoHumano.Horario.DTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicio.RecursoHumano.Reportes.DTOs
{
    public class ReporteMensualDTO
    {
        public int Numero { get; set; }
        public AgenteDTO Agente { get; set; }

        public bool TieneAccesos
        {
            get
            {
                return Accesos.Count() > 0 ? true : false; 
            }
        }
        public bool TieneNovedades {
            get {
                return Novedades.Count() > 0 ? true : false;
            }
        }
        public bool TieneComisiones
        {
            get
            {
                return Comisiones.Count() > 0 ? true : false;
            }
        }
        public bool TieneLactancias
        {
            get
            {
                return Lactancias.Count() > 0 ? true : false;
            }
        }
        public int CantidadNovedades
        {
            get
            {
                return TieneNovedades ? Novedades.Count() : 0;
            }
        }
        public int CantidadComisiones
        {
            get
            {
                return TieneComisiones ? Comisiones.Count() : 0;
            }
        }
        public int CantidadLactancias
        {
            get
            {
                return TieneLactancias ? Lactancias.Count() : 0;
            }
        }

        public List<HorarioDTO> Horarios { get; set; }
        public List<Core.Acceso.DTOs.AccesoDTO> Accesos { get; private set; }
        public List<NovedadAgente.DTOs.NovedadAgenteDTO> Novedades { get; set; }
        public List<ComisionServicio.DTOs.ComisionServicioDTO> Comisiones { get; set; }
        public List<Lactancia.DTOs.LactanciaDTO> Lactancias { get; set; }

        public DateTime Fecha { get; set; }
        public string Mes { get { return Fecha.Month.ToString("MMMM", new CultureInfo("es-AR")); } }
        public string Año { get { return Fecha.Year.ToString(); } }


        public string FechaShortStr {
            get
            {
                return Fecha.Date.ToShortDateString();
            }
        }

        public bool Ausente { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraEntradaParcial { get; set; }
        public DateTime HoraSalida { get; set; }
        public DateTime HoraSalidaParcial { get; set; }
        public TimeSpan MinutosTarde { get; set; }
        public TimeSpan MinutosFaltantes { get; set; }
        public TimeSpan MinutosTardeExtension { get; set; }
        public TimeSpan MinutosFaltantesExtension { get; set; }
    }
}
