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
    
    public partial class CA_LKP_ICDX
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CA_LKP_ICDX()
        {
            this.CA_PERFIL = new HashSet<CA_PERFIL>();
            this.CA_PERFIL1 = new HashSet<CA_PERFIL>();
            this.CA_PERFIL2 = new HashSet<CA_PERFIL>();
            this.CA_PERFIL3 = new HashSet<CA_PERFIL>();
        }
    
        public int PK_ICDX { get; set; }
        public string CO_ICDX { get; set; }
        public string DE_ICDX { get; set; }
        public string TipoTranstorno { get; set; }
        public string Categoria { get; set; }
        public string SubCategoria { get; set; }
        public bool Activa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CA_PERFIL> CA_PERFIL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CA_PERFIL> CA_PERFIL1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CA_PERFIL> CA_PERFIL2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CA_PERFIL> CA_PERFIL3 { get; set; }
    }
}
