//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CARA_Draftv0._1
{
    using System;
    using System.Collections.Generic;
    
    public partial class CA_CENTRO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CA_CENTRO()
        {
            this.CA_USUARIO_CENTRO = new HashSet<CA_USUARIO_CENTRO>();
            this.CA_PACIENTE = new HashSet<CA_PACIENTE>();
            this.CA_EPISODIO = new HashSet<CA_EPISODIO>();
        }
    
        public int PK_Centro { get; set; }
        public string NB_Centro { get; set; }
        public System.Guid ID_SLYC { get; set; }
        public string ID_Proveedor { get; set; }
        public bool Activa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CA_USUARIO_CENTRO> CA_USUARIO_CENTRO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CA_PACIENTE> CA_PACIENTE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CA_EPISODIO> CA_EPISODIO { get; set; }
    }
}
