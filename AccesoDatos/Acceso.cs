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
    
    public partial class Acceso
    {
        public long Id { get; set; }
        public long AgenteId { get; set; }
        public System.DateTime FechaHora { get; set; }
        public TipoAcceso TipoAcceso { get; set; }
        public string NroReloj { get; set; }
        public Nullable<System.TimeSpan> Hora { get; set; }
    
        public virtual Agente Agente { get; set; }
    }
}
