using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CARA_Draftv0._1.App.WebMethods
{
    public class dashPlanificacionTotales
    {
        public string totalToxicologia;
        public string totalCentros;
        public string totalAdmisiones;
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
        public dashPlanificacionTotales dashTotales(DateTime Desde, DateTime Hasta, List<dashCaraGenero> gen, List<dashCaraNivel> Niveles, List<dashCaraCentro> Centros)
        {
            dashPlanificacionTotales data = new dashPlanificacionTotales();

            List<int> listGenero = new List<int>();
            List<int> listNiveles = new List<int>();
            List<int> listCentros = new List<int>();

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

                    var dashPLN = dsCARA.VW_DSH_CARA_PERFILES.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.PK_Genero)).Where(x => listNiveles.Contains(x.PK_NivelSustancia)).Where(b => listCentros.Contains(b.PK_Centro)).ToList();

                    var totalCentros = dashPLN.Select(a => a.PK_Centro).Distinct().Count();

                    var totalAdmisiones = dashPLN.Select(a => a.PK_Perfil).Distinct().Count();

                    var totalToxicologia = dsCARA.VW_DSH_CARA_DROGAS_USO.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.FK_Genero)).Where(x => listNiveles.Contains(x.FK_NivelSustancia)).Where(b => listCentros.Contains(b.FK_Centro)).Where(c => !c.DE_Sustancia.Equals("No Aplica")).Where(f => f.IN_Toxicologia.Equals(true)).Count();

                    var drogasUso = dsCARA.VW_DSH_CARA_DROGAS_USO.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.FK_Genero)).Where(x => listNiveles.Contains(x.FK_NivelSustancia)).Where(b => listCentros.Contains(b.FK_Centro)).Where(c => !c.DE_Sustancia.Equals("No Aplica")).GroupBy(a => a.DE_Sustancia).Select(x => new { DE_Sustancia = x.Key, Perfiles = x.Count() });


                    data.totalToxicologia = totalToxicologia.ToString();
                    data.totalCentros = totalCentros.ToString();
                    data.totalAdmisiones = totalAdmisiones.ToString();

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
        public object[] dashDrogasUso(DateTime Desde, DateTime Hasta, List<dashCaraGenero> gen, List<dashCaraNivel> Niveles, List<dashCaraCentro> Centros)
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

                    var dashCara = dsCARA.VW_DSH_CARA_DROGAS_USO.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.FK_Genero)).Where(x => listNiveles.Contains(x.FK_NivelSustancia)).Where(b => listCentros.Contains(b.FK_Centro)).Where(c => !c.DE_Sustancia.Equals("No Aplica")).Where(f => f.IN_Toxicologia.Equals(true)).GroupBy(a => a.DE_Sustancia).Select(x => new { DE_Sustancia = x.Key, Perfiles = x.Count() });

                    var charData = new object[dashCara.Count() + 1];
                    charData[0] = new object[]
                        {
                        "Drogas de Uso","Perfiles"
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
    }
}
