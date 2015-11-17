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

        public List<NovedadAgente.DTOs.NovedadAgenteDTO> Novedades { get; set; }
        public List<ComisionServicio.DTOs.ComisionServicioDTO> Comisiones { get; set; }
        public List<Lactancia.DTOs.LactanciaDTO> Lactancias { get; set; }

        public DateTime Fecha { get; set; }

        public string FechaStr { get { return String.Format("{0:dd\\/MM\\/yy}", Fecha); } }

        public bool Ausente { get; set; }
        public string AusenteStr { get { return Ausente ? "Sí" : "No"; } }

        public DateTime? HoraEntrada { get; set; }
        public DateTime? HoraEntradaParcial { get; set; }
        public DateTime? HoraSalida { get; set; }
        public DateTime? HoraSalidaParcial { get; set; }

        public string HoraEntradaStr { get { return HoraEntrada == null ? "-" : String.Format("{0:hh\\:mm\\:ss}", HoraEntrada); } }
        public string HoraSalidaStr { get { return HoraSalida == null ? "-" : String.Format("{0:hh\\:mm\\:ss}", HoraSalida); } }
        public string HoraSalidaParcialStr { get { return HoraSalidaParcial == null ? "-" : String.Format("{0:hh\\:mm\\:ss}", HoraSalidaParcial); } }
        public string HoraEntradaParcialStr { get { return HoraEntradaParcial == null ? "-" : String.Format("{0:hh\\:mm\\:ss}", HoraEntradaParcial); } }

        public TimeSpan? MinutosTarde { get; set; }
        public TimeSpan? MinutosTardeExtension { get; set; }
        public TimeSpan? MinutosFaltantes { get; set; }
        public TimeSpan? MinutosFaltantesExtension { get; set; }

        public string MinutosTardeStr { get { return (MinutosTarde == null || ((TimeSpan)MinutosTarde).Ticks <= 0) ? "-" : String.Format("{0:mm\\:ss}", MinutosTarde); } }
        public string MinutosTardeExtensionStr { get { return (MinutosTardeExtension == null || ((TimeSpan)MinutosTardeExtension).Ticks <= 0) ? "-" : String.Format("{0:mm\\:ss}", MinutosTardeExtension); } }
        public string MinutosFaltantesStr { get { return (MinutosFaltantes == null || ((TimeSpan)MinutosFaltantes).Ticks <= 0) ? "-" : String.Format("{0:mm\\:ss}", MinutosFaltantes); } }
        public string MinutosFaltantesExtensionStr { get { return (MinutosFaltantesExtension == null || ((TimeSpan)MinutosFaltantesExtension).Ticks <= 0) ? "-" : String.Format("{0:mm\\:ss}", MinutosFaltantesExtension); } }
    }
}
