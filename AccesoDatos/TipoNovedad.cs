
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
    
public partial class TipoNovedad
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public TipoNovedad()
    {

        this.Novedades = new HashSet<Novedad>();

    }


    public long Id { get; set; }

    public string Abreviatura { get; set; }

    public string Descripcion { get; set; }

    public bool EsJornadaCompleta { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Novedad> Novedades { get; set; }

}

}
