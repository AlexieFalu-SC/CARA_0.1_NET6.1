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
    
    public partial class CA_PACIENTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CA_PACIENTE()
        {
            this.CA_EPISODIO = new HashSet<CA_EPISODIO>();
        }
    
        public int PK_Paciente { get; set; }
        public System.DateTime FE_Nacimiento { get; set; }
        public int FK_Centro { get; set; }
        public int FK_GrupoEtnico { get; set; }
        public string NR_Expediente { get; set; }
        public Nullable<int> FK_Genero { get; set; }
    
        public virtual CA_CENTRO CA_CENTRO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CA_EPISODIO> CA_EPISODIO { get; set; }
        public virtual CA_LKP_GENERO CA_LKP_GENERO { get; set; }
        public virtual CA_LKP_GRUPO_ETNICO CA_LKP_GRUPO_ETNICO { get; set; }
    }
}
