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
    
    public partial class CA_PERFIL
    {
        public int PK_Perfil { get; set; }
        public int FK_Episodio { get; set; }
        public System.DateTime FE_Perfil { get; set; }
        public string IN_TI_Perfil { get; set; }
        public int NR_ArrestosMesPasado { get; set; }
        public int FK_GrupoApoyoMesPasado { get; set; }
        public int FK_Genero { get; set; }
        public int NR_Edad { get; set; }
        public int FK_Residencia { get; set; }
        public int FK_Embarazada { get; set; }
        public int FK_HijosMenoresCuido { get; set; }
        public int FK_Veterano { get; set; }
        public int FK_Escolaridad { get; set; }
        public int FK_CondicionLaboral { get; set; }
        public int FK_NoFuerzaLaboral { get; set; }
        public int FK_Estudios { get; set; }
        public int FK_FuenteIngreso { get; set; }
        public int FK_DrogaPrimaria { get; set; }
        public bool IN_ToxicologiaPrimaria { get; set; }
        public int FK_ViaPrimaria { get; set; }
        public int FK_FrecuenciaPrimaria { get; set; }
        public int NR_EdadPrimaria { get; set; }
        public int FK_DrogaSecundaria { get; set; }
        public bool IN_ToxicologiaSecundaria { get; set; }
        public int FK_ViaSecundaria { get; set; }
        public int FK_FrecuenciaSecundaria { get; set; }
        public int NR_EdadSecundaria { get; set; }
        public int FK_DrogaTerciaria { get; set; }
        public bool IN_ToxicologiaTerciaria { get; set; }
        public int FK_ViaTerciaria { get; set; }
        public int FK_FrecuenciaTerciaria { get; set; }
        public int NR_EdadTerciaria { get; set; }
        public string NB_DrogaCuarta { get; set; }
        public bool IN_ToxicologiaCuarta { get; set; }
        public int FK_ViaCuarta { get; set; }
        public int FK_FrecuenciaCuarta { get; set; }
        public int NR_EdadCuarta { get; set; }
        public string NB_DrogaQuinta { get; set; }
        public bool IN_ToxicologiaQuinta { get; set; }
        public int FK_ViaQuinta { get; set; }
        public int FK_FrecuenciaQuinta { get; set; }
        public int NR_EdadQuinta { get; set; }
        public int FK_DrogaSobredosisPrimaria { get; set; }
        public int FK_DrogaSobredosisSecundaria { get; set; }
        public string DE_DrogaSobredosisTerciaria { get; set; }
        public string DE_DrogaSobredosisCuarta { get; set; }
        public int FK_ICDX_Primaria { get; set; }
        public int FK_ICDX_Secundaria { get; set; }
        public int FK_ICDX_Terciaria { get; set; }
        public int FK_ICDX_Cuarta { get; set; }
        public int FK_DSMV_Primaria { get; set; }
        public int FK_DSMV_Secundaria { get; set; }
        public int FK_DSMV_Terciaria { get; set; }
        public int FK_DSMV_Cuarta { get; set; }
        public int FK_CondicionFisicaPrimaria { get; set; }
        public int FK_CondicionFisicaSecundaria { get; set; }
        public int FK_CondicionFisicaTerciaria { get; set; }
        public int FK_CondicionFisicaCuarta { get; set; }
        public int FK_SeguroSalud { get; set; }
        public int FK_EstadoMarital { get; set; }
        public System.DateTime FE_UltimoContacto { get; set; }
        public System.DateTime CreadoEn { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<bool> IN_Sobredosis { get; set; }
    
        public virtual CA_EPISODIO CA_EPISODIO { get; set; }
        public virtual CA_LKP_CONDICION_LABORAL CA_LKP_CONDICION_LABORAL { get; set; }
        public virtual CA_LKP_CONDICIONES_FISICAS CA_LKP_CONDICIONES_FISICAS { get; set; }
        public virtual CA_LKP_CONDICIONES_FISICAS CA_LKP_CONDICIONES_FISICAS1 { get; set; }
        public virtual CA_LKP_CONDICIONES_FISICAS CA_LKP_CONDICIONES_FISICAS2 { get; set; }
        public virtual CA_LKP_CONDICIONES_FISICAS CA_LKP_CONDICIONES_FISICAS3 { get; set; }
        public virtual CA_LKP_DSMV CA_LKP_DSMV { get; set; }
        public virtual CA_LKP_DSMV CA_LKP_DSMV1 { get; set; }
        public virtual CA_LKP_DSMV CA_LKP_DSMV2 { get; set; }
        public virtual CA_LKP_DSMV CA_LKP_DSMV3 { get; set; }
        public virtual CA_LKP_EMBARAZADA CA_LKP_EMBARAZADA { get; set; }
        public virtual CA_LKP_ESCOLARIDAD CA_LKP_ESCOLARIDAD { get; set; }
        public virtual CA_LKP_ESTADO_MARITAL CA_LKP_ESTADO_MARITAL { get; set; }
        public virtual CA_LKP_ESTUDIOS CA_LKP_ESTUDIOS { get; set; }
        public virtual CA_LKP_FRECUENCIA_APOYO CA_LKP_FRECUENCIA_APOYO { get; set; }
        public virtual CA_LKP_FRECUENCIA_SUSTANCIA CA_LKP_FRECUENCIA_SUSTANCIA { get; set; }
        public virtual CA_LKP_FRECUENCIA_SUSTANCIA CA_LKP_FRECUENCIA_SUSTANCIA1 { get; set; }
        public virtual CA_LKP_FRECUENCIA_SUSTANCIA CA_LKP_FRECUENCIA_SUSTANCIA2 { get; set; }
        public virtual CA_LKP_FRECUENCIA_SUSTANCIA CA_LKP_FRECUENCIA_SUSTANCIA3 { get; set; }
        public virtual CA_LKP_FRECUENCIA_SUSTANCIA CA_LKP_FRECUENCIA_SUSTANCIA4 { get; set; }
        public virtual CA_LKP_FUENTE_INGRESO CA_LKP_FUENTE_INGRESO { get; set; }
        public virtual CA_LKP_FUERZA_LABORAL CA_LKP_FUERZA_LABORAL { get; set; }
        public virtual CA_LKP_GENERO CA_LKP_GENERO { get; set; }
        public virtual CA_LKP_ICDX CA_LKP_ICDX { get; set; }
        public virtual CA_LKP_ICDX CA_LKP_ICDX1 { get; set; }
        public virtual CA_LKP_ICDX CA_LKP_ICDX2 { get; set; }
        public virtual CA_LKP_ICDX CA_LKP_ICDX3 { get; set; }
        public virtual CA_LKP_MENORES_CUSTODIA CA_LKP_MENORES_CUSTODIA { get; set; }
        public virtual CA_LKP_RESIDENCIA CA_LKP_RESIDENCIA { get; set; }
        public virtual CA_LKP_SEGURO_SALUD CA_LKP_SEGURO_SALUD { get; set; }
        public virtual CA_LKP_SUSTANCIA CA_LKP_SUSTANCIA { get; set; }
        public virtual CA_LKP_SUSTANCIA CA_LKP_SUSTANCIA1 { get; set; }
        public virtual CA_LKP_SUSTANCIA CA_LKP_SUSTANCIA2 { get; set; }
        public virtual CA_LKP_SUSTANCIA CA_LKP_SUSTANCIA3 { get; set; }
        public virtual CA_LKP_SUSTANCIA CA_LKP_SUSTANCIA4 { get; set; }
        public virtual CA_LKP_VETERANO CA_LKP_VETERANO { get; set; }
        public virtual CA_LKP_VIA_SUSTANCIA CA_LKP_VIA_SUSTANCIA { get; set; }
        public virtual CA_LKP_VIA_SUSTANCIA CA_LKP_VIA_SUSTANCIA1 { get; set; }
        public virtual CA_LKP_VIA_SUSTANCIA CA_LKP_VIA_SUSTANCIA2 { get; set; }
        public virtual CA_LKP_VIA_SUSTANCIA CA_LKP_VIA_SUSTANCIA3 { get; set; }
        public virtual CA_LKP_VIA_SUSTANCIA CA_LKP_VIA_SUSTANCIA4 { get; set; }
    }
}
