using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CARA_Draftv0._1.App.WebMethods
{
    public class dashPlanificacionTotales
    {
        public string viaUsada;
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

                    //var viasUso = dashPLN.Select(a => a.DE)
                }
            }
            catch (Exception)
            {

                throw;
            }

            return data;
        }
    }
}
