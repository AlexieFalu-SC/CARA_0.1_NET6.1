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
    
    public partial class CA_LKP_EPISODIOS_PREVIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CA_LKP_EPISODIOS_PREVIO()
        {
            this.CA_EPISODIO = new HashSet<CA_EPISODIO>();
        }
    
        public int PK_EpisodiosPrevio { get; set; }
        public string DE_EpisodiosPrevio { get; set; }
        public bool Activa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CA_EPISODIO> CA_EPISODIO { get; set; }
    }
}
