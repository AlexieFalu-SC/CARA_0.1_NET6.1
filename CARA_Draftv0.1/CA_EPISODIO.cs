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
    
    public partial class CA_EPISODIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CA_EPISODIO()
        {
            this.CA_PERFIL = new HashSet<CA_PERFIL>();
        }
    
        public int PK_Episodio { get; set; }
        public int FK_Paciente { get; set; }
        public int FK_Centro { get; set; }
        public System.DateTime FE_Episodio { get; set; }
        public Nullable<System.DateTime> FE_Alta { get; set; }
        public int FK_EstadoServicio { get; set; }
        public int FK_FuenteReferido { get; set; }
        public int FK_EpisodiosPrevios { get; set; }
        public int FK_NivelSustancia { get; set; }
        public Nullable<int> NR_DiasEspera { get; set; }
    
        public virtual CA_CENTRO CA_CENTRO { get; set; }
        public virtual CA_LKP_EPISODIOS_PREVIO CA_LKP_EPISODIOS_PREVIO { get; set; }
        public virtual CA_LKP_ESTADO_SERVICIO CA_LKP_ESTADO_SERVICIO { get; set; }
        public virtual CA_LKP_FUENTE_REFERIDO CA_LKP_FUENTE_REFERIDO { get; set; }
        public virtual CA_LKP_NIVEL_SUSTANCIA CA_LKP_NIVEL_SUSTANCIA { get; set; }
        public virtual CA_PACIENTE CA_PACIENTE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CA_PERFIL> CA_PERFIL { get; set; }
    }
}
