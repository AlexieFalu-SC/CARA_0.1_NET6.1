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
    
    public partial class VW_DSH_PLN_PERFILES
    {
        public int PK_Episodio { get; set; }
        public int PK_Perfil { get; set; }
        public int PK_Centro { get; set; }
        public string NB_Centro { get; set; }
        public System.DateTime FE_Perfil { get; set; }
        public Nullable<int> Edad { get; set; }
        public string GrupoEdad { get; set; }
        public int PK_Genero { get; set; }
        public string DE_Genero { get; set; }
        public int PK_FuenteReferido { get; set; }
        public string DE_FuenteReferido { get; set; }
        public int PK_NivelSustancia { get; set; }
        public string DE_NivelSustancia { get; set; }
        public bool IN_Sobredosis { get; set; }
        public string DE_Sobredosis { get; set; }
        public int PK_Municipio { get; set; }
        public string DE_Municipio { get; set; }
        public int PK_Licencia { get; set; }
        public string NB_Licencia { get; set; }
        public string NB_Categoria { get; set; }
    }
}
