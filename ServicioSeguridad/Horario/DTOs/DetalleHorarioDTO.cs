using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.RecursoHumano.Horario.DTOs
{
    public class DetalleHorarioDTO
    {
        //public long IdAgente { get; set; }
        public long AgenteId { get; set; }
        public DateTime FechaDesde { get; set; }
        public string FechaDesdeStr { get { return FechaDesde.ToShortDateString(); ; } }
        public DateTime FechaHasta { get; set; }
        public string FechaHastaStr { get { return FechaHasta.ToShortDateString(); ; } }
        public TimeSpan? HoraEntrada { get; set; }
        public string HoraEntradaStr
        {
            get
            {
                    return HoraEntrada.HasValue?
                    HoraEntrada.Value.Hours.ToString("00") + ":" + HoraEntrada.Value.Minutes.ToString("00")
                    :"No Asignada";
            }
        }
        public TimeSpan? HoraSalidaParcial { get; set; }
        public string HoraSalidaParcialStr
        {
            get
            {
                    return HoraSalidaParcial.HasValue?
                    HoraSalidaParcial.Value.Hours.ToString("00") + ":" + HoraSalidaParcial.Value.Minutes.ToString("00")
                    : "No Asignada";
            }
        }
        public TimeSpan? HoraEntradaParcial { get; set; }
        public string HoraEntradaParcialStr
        {
            get
            {
                return HoraEntradaParcial.HasValue ?
                        HoraEntradaParcial.Value.Hours.ToString("00") + ":" + HoraEntradaParcial.Value.Minutes.ToString("00")
                        : "No Asignada";
            }
        }
        public TimeSpan? HoraSalida { get; set; }
        public string HoraSalidaStr
        {
            get
            {
                return HoraSalida.HasValue ?
                HoraSalida.Value.Hours.ToString("00") + ":" + HoraSalida.Value.Minutes.ToString("00")
                : "No Asignada";
            }
        }
        public bool Lunes { get; set; }
        public string LunesStr { get { return Lunes ? "SI" : "NO"; } }
        public bool Martes { get; set; }
        public string MartesStr { get { return Martes ? "SI" : "NO"; } }
        public bool Miercoles { get; set; }
        public string MiercolesStr { get { return Miercoles ? "SI" : "NO"; } }
        public bool Jueves { get; set; }
        public string JuevesStr { get { return Jueves ? "SI" : "NO"; } }
        public bool Viernes { get; set; }
        public string ViernesStr { get { return Viernes ? "SI" : "NO"; } }
        public bool Sabado { get; set; }
        public string SabadoStr { get { return Sabado ? "SI" : "NO"; } }
        public bool Domingo { get; set; }
        public string DomingoStr { get { return Domingo ? "SI" : "NO"; } }

    }
}
