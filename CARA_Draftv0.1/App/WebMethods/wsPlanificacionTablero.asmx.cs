using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CARA_Draftv0._1.App.WebMethods
{
    public class dashPlanificacionTotales
    {
       // public string totalToxicologia;
        public string totalCentros;
        public string totalAdmisiones;
        public string viaUso;
        public string totalMasculino;
        public string perMasculino;
        public string totalFemenino;
        public string perFemenino;
        public string totalFM;
        public string perFM;
        public string totalMF;
        public string perMF;

        public string total18_24;
        public string per18_24;
        public string total25_44;
        public string per25_44;
        public string total45_65;
        public string per45_65;
        public string total65;
        public string per65;
    }

    /// <summary>
    /// Summary description for wsPlanificacionTablero
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class wsPlanificacionTablero : System.Web.Services.WebService
    {

        [WebMethod]
        public dashPlanificacionTotales dashTotales(DateTime Desde, DateTime Hasta, List<dashCaraGenero> gen, List<dashCaraNivel> Niveles, List<dashCaraCentro> Centros, List<dashCaraFuenteReferido> Fuente, List<dashCaraGrupoEdades> Grupo, List<dashCaraSobredosis> Sobredosis, List<dashCaraMunicipios> Municipios, List<dashCaraCategorias> Categorias)
        {
            dashPlanificacionTotales data = new dashPlanificacionTotales();

            List<int> listGenero = new List<int>();
            List<int> listNiveles = new List<int>();
            List<int> listCentros = new List<int>();
            List<int> listFuente = new List<int>();
            List<string> listGrupo = new List<string>();
            List<string> listSobredosis = new List<string>();
            List<int> listMunicipios = new List<int>();
            List<string> listCategorias = new List<string>();

            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    foreach (dashCaraGenero item in gen)
                    {
                        listGenero.Add(item.pk_genero);
                    }

                    foreach (dashCaraNivel item in Niveles)
                    {
                        listNiveles.Add(item.pk_nivel);
                    }

                    foreach (dashCaraCentro item in Centros)
                    {
                        listCentros.Add(item.pk_centro);
                    }

                    foreach (dashCaraFuenteReferido item in Fuente)
                    {
                        listFuente.Add(item.pk_fuentereferido);
                    }

                    foreach (dashCaraGrupoEdades item in Grupo)
                    {
                        listGrupo.Add(item.pk_grupoedades);
                    }

                    foreach (dashCaraSobredosis item in Sobredosis)
                    {
                        listSobredosis.Add(item.pk_sobredosis);
                    }

                    foreach (dashCaraMunicipios item in Municipios)
                    {
                        listMunicipios.Add(item.pk_municipios);
                    }

                    foreach (dashCaraCategorias item in Categorias)
                    {
                        listCategorias.Add(item.nb_categoria);
                    }

                    var dashPLN = dsCARA.VW_DSH_PLN_PERFILES.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.PK_Genero)).Where(x => listNiveles.Contains(x.PK_NivelSustancia)).Where(b => listCentros.Contains(b.PK_Centro)).Where(a => listFuente.Contains(a.PK_FuenteReferido)).Where(f => listGrupo.Contains(f.GrupoEdad)).Where(r => listSobredosis.Contains(r.DE_Sobredosis)).Where(g => listMunicipios.Contains(g.PK_Municipio)).Where(u => listCategorias.Contains(u.NB_Categoria)).ToList();

                    var totalCentros = dashPLN.Select(a => a.PK_Centro).Distinct().Count();

                    var totalAdmisiones = dashPLN.Select(a => a.PK_Perfil).Distinct().Count();


                    if (totalAdmisiones != 0)
                    {
                        //var totalToxicologia = dsCARA.VW_DSH_CARA_DROGAS_USO.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.FK_Genero)).Where(x => listNiveles.Contains(x.FK_NivelSustancia)).Where(b => listCentros.Contains(b.FK_Centro)).Where(c => !c.DE_Sustancia.Equals("No Aplica")).Where(f => f.IN_Toxicologia.Equals(true)).Count();
                        //data.totalToxicologia = totalToxicologia.ToString();
                        /*Comienzo de Generos*/

                        var generos = dsCARA.VW_DSH_PLN_PERFILES.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(b => listCentros.Contains(b.PK_Centro)).Where(c => listGenero.Contains(c.PK_Genero)).Where(x => listNiveles.Contains(x.PK_NivelSustancia)).Where(b => listCentros.Contains(b.PK_Centro)).Where(a => listFuente.Contains(a.PK_FuenteReferido)).Where(f => listGrupo.Contains(f.GrupoEdad)).Where(r => listSobredosis.Contains(r.DE_Sobredosis)).Where(g => listMunicipios.Contains(g.PK_Municipio)).Where(u => listCategorias.Contains(u.NB_Categoria)).GroupBy(a => a.DE_Genero).Select(x => new { DE_Genero = x.Key, Cantidad = x.Count() }).ToList();

                        int totalGeneros = generos.Sum(a => a.Cantidad);

                        var generosPer = dsCARA.VW_DSH_PLN_PERFILES.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(b => listCentros.Contains(b.PK_Centro)).Where(c => listGenero.Contains(c.PK_Genero)).Where(x => listNiveles.Contains(x.PK_NivelSustancia)).Where(b => listCentros.Contains(b.PK_Centro)).Where(a => listFuente.Contains(a.PK_FuenteReferido)).Where(f => listGrupo.Contains(f.GrupoEdad)).Where(r => listSobredosis.Contains(r.DE_Sobredosis)).Where(g => listMunicipios.Contains(g.PK_Municipio)).Where(u => listCategorias.Contains(u.NB_Categoria)).GroupBy(a => a.DE_Genero).Select(x => new { DE_Genero = x.Key, Cantidad = x.Count(), Porcentaje = (((0.0 + x.Count()) / (0.0 + totalGeneros)) * 100) }).ToList();

                        data.totalMasculino = generosPer.Where(a => a.DE_Genero.Equals("Masculino")).Select(x => x.Cantidad).SingleOrDefault().ToString();

                        data.perMasculino = generosPer.Where(a => a.DE_Genero.Equals("Masculino")).Select(x => x.Porcentaje).SingleOrDefault().ToString();

                        data.totalFemenino = generosPer.Where(a => a.DE_Genero.Equals("Femenino")).Select(x => x.Cantidad).SingleOrDefault().ToString();

                        data.perFemenino = generosPer.Where(a => a.DE_Genero.Equals("Femenino")).Select(x => x.Porcentaje).SingleOrDefault().ToString();

                        data.totalFM = generosPer.Where(a => a.DE_Genero.Equals("Transgénero (F->M)")).Select(x => x.Cantidad).SingleOrDefault().ToString();

                        data.perFM = generosPer.Where(a => a.DE_Genero.Equals("Transgénero (F->M)")).Select(x => x.Porcentaje).SingleOrDefault().ToString();

                        data.totalMF = generosPer.Where(a => a.DE_Genero.Equals("Transgénero (M->F)")).Select(x => x.Cantidad).SingleOrDefault().ToString();

                        data.perMF = generosPer.Where(a => a.DE_Genero.Equals("Transgénero (M->F)")).Select(x => x.Porcentaje).SingleOrDefault().ToString();

                        /*Final de Genero*/

                        /*Comienzo de Grupo Edades*/
                        var grupos = dsCARA.VW_DSH_PLN_PERFILES.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(b => listCentros.Contains(b.PK_Centro)).Where(c => listGenero.Contains(c.PK_Genero)).Where(x => listNiveles.Contains(x.PK_NivelSustancia)).Where(b => listCentros.Contains(b.PK_Centro)).Where(a => listFuente.Contains(a.PK_FuenteReferido)).Where(f => listGrupo.Contains(f.GrupoEdad)).Where(r => listSobredosis.Contains(r.DE_Sobredosis)).Where(g => listMunicipios.Contains(g.PK_Municipio)).Where(u => listCategorias.Contains(u.NB_Categoria)).GroupBy(a => a.GrupoEdad).Select(x => new { GrupoEdad = x.Key, Cantidad = x.Count() }).ToList();

                        int totalGrupos = grupos.Sum(a => a.Cantidad);

                        var gruposPer = dsCARA.VW_DSH_PLN_PERFILES.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(b => listCentros.Contains(b.PK_Centro)).Where(c => listGenero.Contains(c.PK_Genero)).Where(x => listNiveles.Contains(x.PK_NivelSustancia)).Where(b => listCentros.Contains(b.PK_Centro)).Where(a => listFuente.Contains(a.PK_FuenteReferido)).Where(f => listGrupo.Contains(f.GrupoEdad)).Where(r => listSobredosis.Contains(r.DE_Sobredosis)).Where(g => listMunicipios.Contains(g.PK_Municipio)).Where(u => listCategorias.Contains(u.NB_Categoria)).GroupBy(a => a.GrupoEdad).Select(x => new { GrupoEdad = x.Key, Cantidad = x.Count(), Porcentaje = (((0.0 + x.Count()) / (0.0 + totalGrupos)) * 100) }).ToList();

                        data.total18_24 = gruposPer.Where(a => a.GrupoEdad.Equals("18-24")).Select(x => x.Cantidad).SingleOrDefault().ToString();

                        data.per18_24 = gruposPer.Where(a => a.GrupoEdad.Equals("18-24")).Select(x => x.Porcentaje).SingleOrDefault().ToString();

                        data.total25_44 = gruposPer.Where(a => a.GrupoEdad.Equals("25-44")).Select(x => x.Cantidad).SingleOrDefault().ToString();

                        data.per25_44 = gruposPer.Where(a => a.GrupoEdad.Equals("25-44")).Select(x => x.Porcentaje).SingleOrDefault().ToString();

                        data.total45_65 = gruposPer.Where(a => a.GrupoEdad.Equals("45-65")).Select(x => x.Cantidad).SingleOrDefault().ToString();

                        data.per45_65 = gruposPer.Where(a => a.GrupoEdad.Equals("45-65")).Select(x => x.Porcentaje).SingleOrDefault().ToString();

                        data.total65 = gruposPer.Where(a => a.GrupoEdad.Equals("65+")).Select(x => x.Cantidad).SingleOrDefault().ToString();

                        data.per65 = gruposPer.Where(a => a.GrupoEdad.Equals("65+")).Select(x => x.Porcentaje).SingleOrDefault().ToString();
                        /*Final de Grupo Edades*/

                        var drogasUso = dsCARA.VW_DSH_CARA_DROGAS_USO.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.FK_Genero)).Where(x => listNiveles.Contains(x.FK_NivelSustancia)).Where(b => listCentros.Contains(b.FK_Centro)).Where(c => !c.DE_Sustancia.Equals("No Aplica")).Where(u => listCategorias.Contains(u.NB_Categoria)).GroupBy(a => a.DE_Sustancia).Select(x => new { DE_Sustancia = x.Key, Perfiles = x.Count() });



                        data.totalCentros = totalCentros.ToString();
                        data.totalAdmisiones = totalAdmisiones.ToString();

                        var PerfilesVia = dsCARA.VW_DSH_PLN_ViaSustancia.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.FK_Genero)).Where(x => listNiveles.Contains(x.FK_NivelSustancia)).Where(b => listCentros.Contains(b.FK_Centro)).Where(c => !c.DE_ViaSustancia.Equals("No Aplica")).Where(u => listCategorias.Contains(u.NB_Categoria)).GroupBy(a => a.DE_ViaSustancia).Select(x => new { DE_ViaSustancia = x.Key, Perfiles = x.Count() });

                        int sumPerfilesVia = PerfilesVia.Select(x => x.Perfiles).Sum();

                        var viaUso = dsCARA.VW_DSH_PLN_ViaSustancia.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.FK_Genero)).Where(x => listNiveles.Contains(x.FK_NivelSustancia)).Where(b => listCentros.Contains(b.FK_Centro)).Where(c => !c.DE_ViaSustancia.Equals("No Aplica")).Where(u => listCategorias.Contains(u.NB_Categoria)).GroupBy(a => a.DE_ViaSustancia).Select(x => new { DE_ViaSustancia = x.Key, Perfiles = x.Count() }).OrderByDescending(f => f.Perfiles).Take(1);

                        int perfilesViaUso = viaUso.Select(a => a.Perfiles).FirstOrDefault();

                        var perViaUso = ((float)perfilesViaUso / (float)sumPerfilesVia) * 100;


                        data.viaUso = viaUso.Select(a => a.DE_ViaSustancia).FirstOrDefault();

                        data.viaUso += " (" + Math.Round(Convert.ToDouble(perViaUso)).ToString() + "%) ";

                       // return data;
                    }
                    else
                    {
                        data.totalMasculino = "0";

                        data.perMasculino = "0";

                        data.totalFemenino = "0";

                        data.perFemenino = "0";

                        data.totalFM = "0";

                        data.perFM = "0";

                        data.totalMF = "0";

                        data.perMF = "0";

                        /*Final de Genero*/

                        /*Comienzo de Grupo Edades*/
                        data.total18_24 = "0";

                        data.per18_24 = "0";

                        data.total25_44 = "0";

                        data.per25_44 = "0";

                        data.total45_65 = "0";

                        data.per45_65 = "0";

                        data.total65 = "0";

                        data.per65 = "0";
                        /*Final de Grupo Edades*/

                        data.totalCentros = "0";
                        data.totalAdmisiones = "0";

                        data.viaUso = "0";
                    }

                    return data;
                }
            }
            catch (Exception)
            {

                throw;
            }

            
        }

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public object[] dashDrogasUso(DateTime Desde, DateTime Hasta, List<dashCaraGenero> gen, List<dashCaraNivel> Niveles, List<dashCaraCentro> Centros, List<dashCaraCategorias> Categorias)
        {
            try
            {
                List<int> listGenero = new List<int>();
                List<int> listNiveles = new List<int>();
                List<int> listCentros = new List<int>();
                List<string> listCategorias = new List<string>();

                using (CARAEntities dsCARA = new CARAEntities())
                {
                    foreach (dashCaraGenero item in gen)
                    {
                        listGenero.Add(item.pk_genero);
                    }
                    foreach (dashCaraNivel item in Niveles)
                    {
                        listNiveles.Add(item.pk_nivel);
                    }

                    foreach (dashCaraCentro item in Centros)
                    {
                        listCentros.Add(item.pk_centro);
                    }

                    foreach (dashCaraCategorias item in Categorias)
                    {
                        listCategorias.Add(item.nb_categoria);
                    }

                    /*
                    Top 5 Drogas confirmadas con toxicologia
                    var dashCaraPer = dsCARA.VW_DSH_CARA_DROGAS_USO.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.FK_Genero)).Where(x => listNiveles.Contains(x.FK_NivelSustancia)).Where(b => listCentros.Contains(b.FK_Centro)).Where(c => !c.DE_Sustancia.Equals("No Aplica")).Where(f => f.IN_Toxicologia.Equals(true)).GroupBy(a => a.DE_Sustancia).Select(x => new { DE_Sustancia = x.Key, Perfiles = x.Count() }).OrderByDescending(f => f.Perfiles).Take(5);
                    */
                    var dashCaraPer = dsCARA.VW_DSH_CARA_DROGAS_USO.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.FK_Genero)).Where(x => listNiveles.Contains(x.FK_NivelSustancia)).Where(b => listCentros.Contains(b.FK_Centro)).Where(c => !c.DE_Sustancia.Equals("No Aplica")).Where(u => listCategorias.Contains(u.NB_Categoria)).GroupBy(a => a.DE_Sustancia).Select(x => new { DE_Sustancia = x.Key, Perfiles = x.Count() }).OrderByDescending(f => f.Perfiles);

                    /*Nueva Sección*/
                    var totalDrogas = dashCaraPer.Sum(a => a.Perfiles);

                    var dashCara = dsCARA.VW_DSH_CARA_DROGAS_USO.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.FK_Genero)).Where(x => listNiveles.Contains(x.FK_NivelSustancia)).Where(b => listCentros.Contains(b.FK_Centro)).Where(c => !c.DE_Sustancia.Equals("No Aplica")).Where(u => listCategorias.Contains(u.NB_Categoria)).GroupBy(a => a.DE_Sustancia).Select(x => new { DE_Sustancia = x.Key, Perfiles = (((0.0 + x.Count()) / (0.0 + totalDrogas)) * 100) }).OrderByDescending(f => f.Perfiles);

                    /*END*/

                    var charData = new object[dashCara.Count() + 1];
                    charData[0] = new object[]
                        {
                        "Drogas de Uso","% Porcentaje"
                        };

                    int j = 0;
                    foreach (var item in dashCara)
                    {
                        j++;
                        charData[j] = new object[] { item.DE_Sustancia, item.Perfiles };
                    }

                    return charData;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public object[] dashICDX(DateTime Desde, DateTime Hasta, List<dashCaraGenero> gen, List<dashCaraNivel> Niveles, List<dashCaraCentro> Centros, List<dashCaraCategorias> Categorias)
        {
            try
            {
                List<int> listGenero = new List<int>();
                List<int> listNiveles = new List<int>();
                List<int> listCentros = new List<int>();
                List<string> listCategorias = new List<string>();

                using (CARAEntities dsCARA = new CARAEntities())
                {
                    foreach (dashCaraGenero item in gen)
                    {
                        listGenero.Add(item.pk_genero);
                    }
                    foreach (dashCaraNivel item in Niveles)
                    {
                        listNiveles.Add(item.pk_nivel);
                    }

                    foreach (dashCaraCentro item in Centros)
                    {
                        listCentros.Add(item.pk_centro);
                    }

                    foreach (dashCaraCategorias item in Categorias)
                    {
                        listCategorias.Add(item.nb_categoria);
                    }

                    var dashCara = dsCARA.VW_DSH_PLN_ICDX.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.FK_Genero)).Where(x => listNiveles.Contains(x.FK_NivelSustancia)).Where(b => listCentros.Contains(b.FK_Centro)).Where(c => !c.DE_ICDX.Equals("No Aplica")).Where(u => listCategorias.Contains(u.NB_Categoria)).GroupBy(a => a.DE_ICDX).Select(x => new { DE_ICDX = x.Key, Perfiles = x.Count() }).OrderByDescending(f => f.Perfiles).Take(5);

                    var charData = new object[dashCara.Count() + 1];
                    charData[0] = new object[]
                        {
                        "ICDX","Cantidad"
                        };

                    int j = 0;
                    foreach (var item in dashCara)
                    {
                        j++;
                        charData[j] = new object[] { item.DE_ICDX, item.Perfiles };
                    }

                    return charData;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public object[] dashDSMV(DateTime Desde, DateTime Hasta, List<dashCaraGenero> gen, List<dashCaraNivel> Niveles, List<dashCaraCentro> Centros, List<dashCaraCategorias> Categorias)
        {
            try
            {
                List<int> listGenero = new List<int>();
                List<int> listNiveles = new List<int>();
                List<int> listCentros = new List<int>();
                List<string> listCategorias = new List<string>();

                using (CARAEntities dsCARA = new CARAEntities())
                {
                    foreach (dashCaraGenero item in gen)
                    {
                        listGenero.Add(item.pk_genero);
                    }
                    foreach (dashCaraNivel item in Niveles)
                    {
                        listNiveles.Add(item.pk_nivel);
                    }

                    foreach (dashCaraCentro item in Centros)
                    {
                        listCentros.Add(item.pk_centro);
                    }

                    foreach (dashCaraCategorias item in Categorias)
                    {
                        listCategorias.Add(item.nb_categoria);
                    }

                    var dashCara = dsCARA.VW_DSH_PLN_DSMV.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.FK_Genero)).Where(x => listNiveles.Contains(x.FK_NivelSustancia)).Where(b => listCentros.Contains(b.FK_Centro)).Where(c => !c.DE_DSMV.Equals("No Aplica")).Where(u => listCategorias.Contains(u.NB_Categoria)).GroupBy(a => a.DE_DSMV).Select(x => new { DE_DSMV = x.Key, Perfiles = x.Count() }).OrderByDescending(f => f.Perfiles).Take(5);

                    var charData = new object[dashCara.Count() + 1];
                    charData[0] = new object[]
                        {
                        "DSMV","Cantidad"
                        };

                    int j = 0;
                    foreach (var item in dashCara)
                    {
                        j++;
                        charData[j] = new object[] { item.DE_DSMV, item.Perfiles };
                    }

                    return charData;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public object[] dashCaraSobredosis(DateTime Desde, DateTime Hasta, List<dashCaraGenero> gen, List<dashCaraNivel> Niveles, List<dashCaraCentro> Centros, List<dashCaraFuenteReferido> Fuente, List<dashCaraGrupoEdades> Grupo, List<dashCaraSobredosis> Sobredosis, List<dashCaraMunicipios> Municipios, List<dashCaraCategorias> Categorias)
        {
            try
            {
                List<int> listGenero = new List<int>();
                List<int> listNiveles = new List<int>();
                List<int> listCentros = new List<int>();
                List<int> listFuente = new List<int>();
                List<string> listGrupo = new List<string>();
                List<string> listSobredosis = new List<string>();
                List<int> listMunicipios = new List<int>();
                List<string> listCategorias = new List<string>();

                using (CARAEntities dsCARA = new CARAEntities())
                {
                    foreach (dashCaraGenero item in gen)
                    {
                        listGenero.Add(item.pk_genero);
                    }
                    foreach (dashCaraNivel item in Niveles)
                    {
                        listNiveles.Add(item.pk_nivel);
                    }

                    foreach (dashCaraCentro item in Centros)
                    {
                        listCentros.Add(item.pk_centro);
                    }
                    foreach (dashCaraFuenteReferido item in Fuente)
                    {
                        listFuente.Add(item.pk_fuentereferido);
                    }

                    foreach (dashCaraGrupoEdades item in Grupo)
                    {
                        listGrupo.Add(item.pk_grupoedades);
                    }

                    foreach (dashCaraSobredosis item in Sobredosis)
                    {
                        listSobredosis.Add(item.pk_sobredosis);
                    }

                    foreach (dashCaraMunicipios item in Municipios)
                    {
                        listMunicipios.Add(item.pk_municipios);
                    }

                    foreach (dashCaraCategorias item in Categorias)
                    {
                        listCategorias.Add(item.nb_categoria);
                    }

                    //var dashCara = dsCARA.VW_DSH_PLN_PERFILES.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.PK_Genero)).Where(x => listNiveles.Contains(x.PK_NivelSustancia)).Where(b => listCentros.Contains(b.PK_Centro)).Where(a => listFuente.Contains(a.PK_FuenteReferido)).Where(f => listGrupo.Contains(f.GrupoEdad)).GroupBy(a => new { a.DE_Sobredosis, a.FE_Perfil.Month } ).Select(x => new { DE_Sobredosis = x.Key.DE_Sobredosis, Perfiles = x.Count(), FE_Perfil = x.Key.Month}).ToList();

                    //var dashCara = dashCaraMes.GroupBy(a => new { a.DE_Sobredosis, a.FE_Perfil }).Select(x => new { DE_Sobredosis = x.Key.DE_Sobredosis, Perfiles = x.Count(), FE_Perfil = x.Key });

                    var dashCaraPerfiles = dsCARA.VW_DSH_PLN_PERFILES.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.PK_Genero)).Where(x => listNiveles.Contains(x.PK_NivelSustancia)).Where(b => listCentros.Contains(b.PK_Centro)).Where(a => listFuente.Contains(a.PK_FuenteReferido)).Where(f => listGrupo.Contains(f.GrupoEdad)).Where(r => listSobredosis.Contains(r.DE_Sobredosis)).Where(g => listMunicipios.Contains(g.PK_Municipio)).Where(u => listCategorias.Contains(u.NB_Categoria)).GroupBy(a => a.FE_Perfil.Month ).Select(x => new { Mes = x.Key, Perfiles = x.Count()}).ToList();

                    var dashCaraEventos = dsCARA.VW_DSH_PLN_PERFILES.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.PK_Genero)).Where(x => listNiveles.Contains(x.PK_NivelSustancia)).Where(b => listCentros.Contains(b.PK_Centro)).Where(a => listFuente.Contains(a.PK_FuenteReferido)).Where(f => listGrupo.Contains(f.GrupoEdad)).Where(g => listMunicipios.Contains(g.PK_Municipio)).Where(g => (bool)g.IN_Sobredosis).Where(i => listSobredosis.Contains("Si")).Where(u => listCategorias.Contains(u.NB_Categoria)).GroupBy(a => a.FE_Perfil.Month).Select(i => new { Mes = i.Key, Eventos = i.Count() }).ToList();

                    if(dashCaraEventos.Count() == 0)
                    {
                        dashCaraEventos.Clear();
                        dashCaraEventos.Add( new { Mes = 1, Eventos = 0 } );
                        dashCaraEventos.Add(new { Mes = 2, Eventos = 0 });
                        dashCaraEventos.Add(new { Mes = 3, Eventos = 0 });
                        dashCaraEventos.Add(new { Mes = 4, Eventos = 0 });
                        dashCaraEventos.Add(new { Mes = 5, Eventos = 0 });
                        dashCaraEventos.Add(new { Mes = 6, Eventos = 0 });
                        dashCaraEventos.Add(new { Mes = 7, Eventos = 0 });
                        dashCaraEventos.Add(new { Mes = 8, Eventos = 0 });
                        dashCaraEventos.Add(new { Mes = 9, Eventos = 0 });
                        dashCaraEventos.Add(new { Mes = 10, Eventos = 0 });
                        dashCaraEventos.Add(new { Mes = 11, Eventos = 0 });
                        dashCaraEventos.Add(new { Mes = 12, Eventos = 0 });
                    }
                    //var dashCara = from A in dashCaraPerfiles join B in dashCaraEventos on A.Mes equals B.Mes into PerfilesEventos from eventos in PerfilesEventos.DefaultIfEmpty() select new { A.Mes, A.Perfiles, Eventos = eventos?.Eventos ?? 0 };

                    var dashCara = (from A in dashCaraPerfiles join B in dashCaraEventos on A.Mes equals B.Mes into PerfilesEventos from eventos in PerfilesEventos.DefaultIfEmpty() select new { A.Mes, A.Perfiles, Eventos = eventos != null ? eventos.Eventos : 0}).ToList();

                    var charData = new object[dashCara.Count() + 1];
                    charData[0] = new object[]
                        {
                        "Mes", "Perfiles", "Evento de Sobredosis"
                        };

                    int j = 0;
                    foreach (var item in dashCara)
                    {
                        j++;

                        //int a = 0;
                        //if(item.DE_Sobredosis == "Si")
                        //{
                        //    a = 1;
                        //}
                        charData[j] = new object[] { CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(item.Mes), item.Perfiles, item.Eventos};
                    }

                    return charData;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public object[] dashMunicipio(DateTime Desde, DateTime Hasta, List<dashCaraGenero> gen, List<dashCaraNivel> Niveles, List<dashCaraCentro> Centros, List<dashCaraFuenteReferido> Fuente, List<dashCaraGrupoEdades> Grupo, List<dashCaraSobredosis> Sobredosis, List<dashCaraMunicipios> Municipios, List<dashCaraCategorias> Categorias)
        {
            try
            {
                List<int> listGenero = new List<int>();
                List<int> listNiveles = new List<int>();
                List<int> listCentros = new List<int>();
                List<int> listFuente = new List<int>();
                List<string> listGrupo = new List<string>();
                List<string> listSobredosis = new List<string>();
                List<int> listMunicipios = new List<int>();
                List<string> listCategorias = new List<string>();

                using (CARAEntities dsCARA = new CARAEntities())
                {
                    foreach (dashCaraGenero item in gen)
                    {
                        listGenero.Add(item.pk_genero);
                    }
                    foreach (dashCaraNivel item in Niveles)
                    {
                        listNiveles.Add(item.pk_nivel);
                    }

                    foreach (dashCaraCentro item in Centros)
                    {
                        listCentros.Add(item.pk_centro);
                    }
                    foreach (dashCaraFuenteReferido item in Fuente)
                    {
                        listFuente.Add(item.pk_fuentereferido);
                    }

                    foreach (dashCaraGrupoEdades item in Grupo)
                    {
                        listGrupo.Add(item.pk_grupoedades);
                    }

                    foreach (dashCaraSobredosis item in Sobredosis)
                    {
                        listSobredosis.Add(item.pk_sobredosis);
                    }

                    foreach (dashCaraMunicipios item in Municipios)
                    {
                        listMunicipios.Add(item.pk_municipios);
                    }

                    foreach (dashCaraCategorias item in Categorias)
                    {
                        listCategorias.Add(item.nb_categoria);
                    }

                    /*
                    Top 5 Drogas confirmadas con toxicologia
                    var dashCaraPer = dsCARA.VW_DSH_CARA_DROGAS_USO.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.FK_Genero)).Where(x => listNiveles.Contains(x.FK_NivelSustancia)).Where(b => listCentros.Contains(b.FK_Centro)).Where(c => !c.DE_Sustancia.Equals("No Aplica")).Where(f => f.IN_Toxicologia.Equals(true)).GroupBy(a => a.DE_Sustancia).Select(x => new { DE_Sustancia = x.Key, Perfiles = x.Count() }).OrderByDescending(f => f.Perfiles).Take(5);
                    */
                    var dashCaraPer = dsCARA.VW_DSH_PLN_PERFILES.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.PK_Genero)).Where(x => listNiveles.Contains(x.PK_NivelSustancia)).Where(b => listCentros.Contains(b.PK_Centro)).Where(a => listFuente.Contains(a.PK_FuenteReferido)).Where(f => listGrupo.Contains(f.GrupoEdad)).Where(r => listSobredosis.Contains(r.DE_Sobredosis)).Where(g => listMunicipios.Contains(g.PK_Municipio)).Where(u => listCategorias.Contains(u.NB_Categoria)).GroupBy(a => a.DE_Municipio).Select(x => new { DE_Municipio = x.Key, Perfiles = x.Count() }).OrderByDescending(f => f.Perfiles);

                    /*Nueva Sección*/
                    var totalDrogas = dashCaraPer.Sum(a => a.Perfiles);

                    var dashCara = dsCARA.VW_DSH_PLN_PERFILES.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.PK_Genero)).Where(x => listNiveles.Contains(x.PK_NivelSustancia)).Where(b => listCentros.Contains(b.PK_Centro)).Where(a => listFuente.Contains(a.PK_FuenteReferido)).Where(f => listGrupo.Contains(f.GrupoEdad)).Where(r => listSobredosis.Contains(r.DE_Sobredosis)).Where(g => listMunicipios.Contains(g.PK_Municipio)).Where(u => listCategorias.Contains(u.NB_Categoria)).GroupBy(a => a.DE_Municipio).Select(x => new { DE_Municipio = x.Key, Perfiles = (((0.0 + x.Count()) / (0.0 + totalDrogas)) * 100) }).OrderByDescending(f => f.Perfiles);

                    /*END*/

                    var charData = new object[dashCara.Count() + 1];
                    charData[0] = new object[]
                        {
                        "Municipio","% Porcentaje"
                        };

                    int j = 0;
                    foreach (var item in dashCara)
                    {
                        j++;
                        charData[j] = new object[] { item.DE_Municipio, item.Perfiles };
                    }

                    return charData;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public object[] dashCaraDrogaSobredosis(DateTime Desde, DateTime Hasta, List<dashCaraGenero> gen, List<dashCaraNivel> Niveles, List<dashCaraCentro> Centros, List<dashCaraCategorias> Categorias)
        {
            try
            {
                List<int> listGenero = new List<int>();
                List<int> listNiveles = new List<int>();
                List<int> listCentros = new List<int>();
                List<string> listCategorias = new List<string>();

                using (CARAEntities dsCARA = new CARAEntities())
                {
                    foreach (dashCaraGenero item in gen)
                    {
                        listGenero.Add(item.pk_genero);
                    }
                    foreach (dashCaraNivel item in Niveles)
                    {
                        listNiveles.Add(item.pk_nivel);
                    }

                    foreach (dashCaraCentro item in Centros)
                    {
                        listCentros.Add(item.pk_centro);
                    }

                    foreach (dashCaraCategorias item in Categorias)
                    {
                        listCategorias.Add(item.nb_categoria);
                    }

                    var dashCaraPer = dsCARA.VW_DSH_CARA_DROGAS_SOBREDOSIS.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.FK_Genero)).Where(x => listNiveles.Contains(x.FK_NivelSustancia)).Where(b => listCentros.Contains(b.FK_Centro)).Where(c => !c.DE_Sustancia.Equals("No Aplica")).Where(u => listCategorias.Contains(u.NB_Categoria)).GroupBy(a => a.DE_Sustancia).Select(x => new { DE_Sustancia = x.Key, Perfiles = x.Count() }).OrderByDescending(f => f.Perfiles).ToList();

                    var totalDrogas = dashCaraPer.Sum(a => a.Perfiles);

                    var dashCara = dsCARA.VW_DSH_CARA_DROGAS_SOBREDOSIS.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.FK_Genero)).Where(x => listNiveles.Contains(x.FK_NivelSustancia)).Where(b => listCentros.Contains(b.FK_Centro)).Where(c => !c.DE_Sustancia.Equals("No Aplica")).Where(u => listCategorias.Contains(u.NB_Categoria)).GroupBy(a => a.DE_Sustancia).Select(x => new { DE_Sustancia = x.Key, Perfiles = (((0.0 + x.Count()) / (0.0 + totalDrogas)) * 100) }).OrderByDescending(f => f.Perfiles);

                    var charData = new object[dashCara.Count() + 1];
                    charData[0] = new object[]
                        {
                        "Drogas de Sobredosis","% Porcentaje"
                        };

                    int j = 0;
                    foreach (var item in dashCara)
                    {
                        j++;
                        charData[j] = new object[] { item.DE_Sustancia, item.Perfiles };
                    }

                    return charData;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public object[] dashCondicionesFisicas(DateTime Desde, DateTime Hasta, List<dashCaraGenero> gen, List<dashCaraNivel> Niveles, List<dashCaraCentro> Centros)
        {
            try
            {
                List<int> listGenero = new List<int>();
                List<int> listNiveles = new List<int>();
                List<int> listCentros = new List<int>();

                using (CARAEntities dsCARA = new CARAEntities())
                {
                    foreach (dashCaraGenero item in gen)
                    {
                        listGenero.Add(item.pk_genero);
                    }
                    foreach (dashCaraNivel item in Niveles)
                    {
                        listNiveles.Add(item.pk_nivel);
                    }

                    foreach (dashCaraCentro item in Centros)
                    {
                        listCentros.Add(item.pk_centro);
                    }

                    var dashCara = dsCARA.VW_DSH_PLN_CondicionesFisicas.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.FK_Genero)).Where(x => listNiveles.Contains(x.FK_NivelSustancia)).Where(b => listCentros.Contains(b.FK_Centro)).Where(c => !c.DE_CondicionesFisicas.Equals("Ningún diagnóstico")).GroupBy(a => a.DE_CondicionesFisicas).Select(x => new { DE_CondicionesFisicas = x.Key, Perfiles = x.Count() }).OrderByDescending(f => f.Perfiles).Take(5);

                    var charData = new object[dashCara.Count() + 1];
                    charData[0] = new object[]
                        {
                        "Condiciones Fisicas","Cantidad"
                        };

                    int j = 0;
                    foreach (var item in dashCara)
                    {
                        j++;
                        charData[j] = new object[] { item.DE_CondicionesFisicas, item.Perfiles };
                    }

                    return charData;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
