
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
    
public partial class SubSector
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public SubSector()
    {

        this.Agentes = new HashSet<Agente>();

    }


    public long Id { get; set; }

    public int Codigo { get; set; }

    public string Abreviatura { get; set; }

    public string Descripcion { get; set; }

    public long SectorId { get; set; }



    public virtual Sector Sector { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Agente> Agentes { get; set; }

}

}
