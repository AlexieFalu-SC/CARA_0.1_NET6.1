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
    
    public partial class CA_LKP_FUENTE_INGRESO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CA_LKP_FUENTE_INGRESO()
        {
            this.CA_PERFIL = new HashSet<CA_PERFIL>();
        }
    
        public int PK_FuenteIngreso { get; set; }
        public string DE_FuenteIngreso { get; set; }
        public bool Activa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CA_PERFIL> CA_PERFIL { get; set; }
    }
}
