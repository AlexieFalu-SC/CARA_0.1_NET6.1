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
    
    public partial class CA_USUARIO_CENTRO
    {
        public string FK_Usuario { get; set; }
        public int FK_Centro { get; set; }
        public bool Activa { get; set; }
    
        public virtual CA_CENTRO CA_CENTRO { get; set; }
        public virtual CA_USUARIO CA_USUARIO { get; set; }
    }
}