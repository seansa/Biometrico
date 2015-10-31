//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccesoDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Horario
    {
        public long Id { get; set; }
        public long AgenteId { get; set; }
        public Nullable<System.TimeSpan> HoraEntrada { get; set; }
        public Nullable<System.TimeSpan> HoraSalidaParcial { get; set; }
        public Nullable<System.TimeSpan> HoraEntradaParcial { get; set; }
        public  Nullable<System.TimeSpan> HoraSalida { get; set; }
        public bool Lunes { get; set; }
        public bool Martes { get; set; }
        public bool Miercoles { get; set; }
        public bool Jueves { get; set; }
        public bool Viernes { get; set; }
        public bool Sabado { get; set; }
        public bool Domingo { get; set; }
        public System.DateTime FechaActualizacion { get; set; }
        public System.DateTime FechaDesde { get; set; }
        public System.DateTime FechaHasta { get; set; }
    
        public virtual Agente Agente { get; set; }
    }
}
