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
    
    public partial class Novedad
    {
        public long Id { get; set; }
        public long AgenteId { get; set; }
        public long TipoNovedadId { get; set; }
        public System.DateTime FechaDesde { get; set; }
        public Nullable<System.DateTime> FechaHasta { get; set; }
        public Nullable<System.TimeSpan> HoraDesde { get; set; }
        public Nullable<System.TimeSpan> HoraHasta { get; set; }
        public string Observacion { get; set; }
    
        public virtual TipoNovedad TipoNovedad { get; set; }
        public virtual Agente Agente { get; set; }
    }
}
