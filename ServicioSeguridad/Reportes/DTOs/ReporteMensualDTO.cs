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
        public String Mes { get; set; }

        public string FechaStr { get { return String.Format("{0:dd\\/MM\\/yy}", Fecha); } }

        public bool? Ausente { get; set; }
        public bool? AusentePorLlegarTarde { get; set; }
        public string AusenteStr { get { return Ausente == null? "" : (bool)Ausente ? "Sí" : "No"; } }

        public TimeSpan? HoraEntrada { get; set; }
        public TimeSpan? HoraEntradaParcial { get; set; }
        public TimeSpan? HoraSalida { get; set; }
        public TimeSpan? HoraSalidaParcial { get; set; }

        public string HoraEntradaStr { get { return HoraEntrada == null && Ausente == null ? "" : HoraEntrada == null ? "-" : String.Format("{0:hh\\:mm\\:ss}", HoraEntrada); } }
        public string HoraSalidaStr { get { return HoraSalida == null && Ausente == null ? "" : HoraSalida == null ? "-" : String.Format("{0:hh\\:mm\\:ss}", HoraSalida); } }
        public string HoraSalidaParcialStr { get { return HoraSalidaParcial == null && Ausente == null ? "" : HoraSalidaParcial == null ? "-" : String.Format("{0:hh\\:mm\\:ss}", HoraSalidaParcial); } }
        public string HoraEntradaParcialStr { get { return HoraSalida == null && Ausente == null ? "" : HoraSalida == null ? "-" : String.Format("{0:hh\\:mm\\:ss}", HoraEntradaParcial); } }

        public TimeSpan? MinutosTarde { get; set; }
        public TimeSpan? MinutosTardeExtension { get; set; }
        public TimeSpan? MinutosFaltantes { get; set; }
        public TimeSpan? MinutosFaltantesExtension { get; set; }

        public string MinutosTardeStr { get { return MinutosTarde == null && Ausente == null ? "" : (MinutosTarde == null || String.Format("{0:mm\\:ss}", MinutosTarde) == "00:00") ? "-" : String.Format("{0:mm\\:ss}", MinutosTarde); } }
        public string MinutosTardeExtensionStr { get { return MinutosTardeExtension == null && Ausente == null ? "" : (MinutosTardeExtension == null || String.Format("{0:mm\\:ss}", MinutosTardeExtension) == "00:00") ? "-" : String.Format("{0:mm\\:ss}", MinutosTardeExtension); } }
        public string MinutosFaltantesStr { get { return MinutosFaltantes == null && Ausente == null ? "" : (MinutosFaltantes == null || String.Format("{0:mm\\:ss}", MinutosFaltantes) == "00:00") ? "-" : String.Format("{0:mm\\:ss}", MinutosFaltantes); } }
        public string MinutosFaltantesExtensionStr { get { return MinutosFaltantesExtension == null && Ausente == null ? "" : (MinutosFaltantesExtension == null || String.Format("{0:mm\\:ss}", MinutosFaltantesExtension) == "00:00") ? "-" : String.Format("{0:mm\\:ss}", MinutosFaltantesExtension); } }
    }
}
