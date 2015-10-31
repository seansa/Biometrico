using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.RecursoHumano.Lactancia.DTOs
{
    public class LactanciaDTO
    {
        public long Id { get; set; }
        public long AgenteId { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public DateTime FechaDesde { get; set; }
        public string FechaDesdeStr { get { return FechaDesde.ToShortDateString(); } }
        public DateTime FechaHasta { get; set; }
        public string FechaHastaStr { get { return FechaHasta.ToShortDateString(); } }
        public TimeSpan HoraInicio { get; set; }
        public string HoraInicioStr { get { return HoraInicio.Hours.ToString() + ":" + HoraInicio.Minutes.ToString(); } }
        public bool Lunes { get; set; }
        public string LunesStr { get { return Lunes ? "SI" : "NO"; } }
        public bool Martes { get; set; }
        public string MartesStr { get { return Martes ? "SI" : "NO"; } }
        public bool  Miercoles { get; set; }
        public string MiercolesStr { get { return Miercoles ? "SI" : "NO"; } }
        public bool Jueves { get; set; }
        public string JuevesStr { get { return Jueves ? "SI" : "NO"; } }
        public bool  Viernes { get; set; }
        public string ViernesStr { get { return Viernes ? "SI" : "NO"; } }
        public bool Sabado { get; set; }
        public string SabadoStr { get { return Sabado ? "SI" : "NO"; } }
        public bool Domingo { get; set; }
        public string DomingoStr { get { return Domingo ? "SI" : "NO"; } }
        

    }
}
