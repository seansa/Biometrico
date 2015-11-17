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
        public long AgenteId { get; set; }

        public bool TieneAccesos
        {
            get
            {
                return Accesos.Count() > 0 ? true : false; 
            }
        }
        public bool TieneNovedades {
            get {
                return Novedad != null ? true : false;
            }
        }
        public bool TieneComisiones
        {
            get
            {
                return Comision != null ? true : false;
            }
        }
        public bool TieneLactancias
        {
            get
            {
                return Lactancia != null ? true : false;
            }
        }

        //public List<HorarioDTO> Horarios { get; set; }
        public List<Core.Acceso.DTOs.AccesoDTO> Accesos { get; set; }  // Accesos de un día (1 fila) --> de 'Fecha'
        public NovedadAgente.DTOs.NovedadAgenteDTO Novedad { get; set; }
        public ComisionServicio.DTOs.ComisionServicioDTO Comision { get; set; }
        public Lactancia.DTOs.LactanciaDTO Lactancia { get; set; }

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
        public string AusenteStr { get { return Ausente ? "Sí" : "No"; } }

        public DateTime? HoraEntrada { get; set; }
        public DateTime? HoraEntradaParcial { get; set; }
        public DateTime? HoraSalida { get; set; }
        public DateTime? HoraSalidaParcial { get; set; }

        public string HoraEntradaStr { get { return String.Format("{0:hh\\:mm\\:ss}", HoraEntrada); } }
        public string HoraSalidaStr { get { return String.Format("{0:hh\\:mm\\:ss}", HoraSalida); } }
        public string HoraSalidaParcialStr { get { return String.Format("{0:hh\\:mm\\:ss}", HoraSalidaParcial); } }
        public string HoraEntradaParcialStr { get { return String.Format("{0:hh\\:mm\\:ss}", HoraEntradaParcial); } }

        public TimeSpan? MinutosTarde { get; set; }
        public TimeSpan? MinutosFaltantes { get; set; }
        public TimeSpan? MinutosTardeExtension { get; set; }
        public TimeSpan? MinutosFaltantesExtension { get; set; }
    }
}
