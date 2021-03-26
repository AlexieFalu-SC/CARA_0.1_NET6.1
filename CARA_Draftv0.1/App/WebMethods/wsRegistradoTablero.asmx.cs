using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace CARA_Draftv0._1.App.WebMethods
{
    public class dashCaraData
    {
        public string totalPerfiles;
        public string totalReferidosCara;
        public string totalMasculino;
        public string perMasculino;
        public string totalFemenino;
        public string perFemenino;
        public string totalFM;
        public string perFM;
        public string totalMF;
        public string perMF;
        public string edadPromedio;
    }

    public class dashCaraGenero
    {
        public int pk_genero;

    }

    public class dashCaraNivel
    {
        public int pk_nivel;
    }

    public class dashCaraCentro
    {
        public int pk_centro;
    }

    public class dashCaraFuenteReferido
    {
        public int pk_fuentereferido;
    }

    public class dashCaraGrupoEdades
    {
        public string pk_grupoedades;
    }

    public class dashCaraSobredosis
    {
        public string pk_sobredosis;
    }

    public class dashCaraMunicipios
    {
        public int pk_municipios;
    }

    /// <summary>
    /// Summary description for wsRegistradoTablero
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class wsRegistradoTablero : System.Web.Services.WebService
    {

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public dashCaraData dashCaraTotalPerfiles(DateTime Desde, DateTime Hasta, List<dashCaraGenero> gen, List<dashCaraNivel> Niveles, List<dashCaraCentro> Centros)
        {
            dashCaraData data = new dashCaraData();

            //dashCaraGenero listGenero = new dashCaraGenero();

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

                    var dashCara = dsCARA.VW_DSH_CARA_PERFILES.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.PK_Genero)).Where(x => listNiveles.Contains(x.PK_NivelSustancia)).Where(b => listCentros.Contains(b.PK_Centro)).ToList();

                    var generos = dsCARA.VW_DSH_CARA_PERFILES.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(b => listCentros.Contains(b.PK_Centro)).Where(c => listGenero.Contains(c.PK_Genero)).GroupBy(a => a.DE_Genero).Select(x => new { DE_Genero = x.Key, Cantidad = x.Count() }).ToList();

                    int totalGeneros = generos.Sum(a => a.Cantidad);

                    var generosPer = dsCARA.VW_DSH_CARA_PERFILES.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(b => listCentros.Contains(b.PK_Centro)).Where(c => listGenero.Contains(c.PK_Genero)).GroupBy(a => a.DE_Genero).Select(x => new { DE_Genero = x.Key, Cantidad = x.Count(), Porcentaje = (((0.0 + x.Count()) / (0.0 + totalGeneros)) * 100) }).ToList();

                    //var generosPer = generos.Select(x => new { DE_Genero = x.DE_Genero, Cantidad = x.Cantidad, Porcentaje = ((x.Cantidad / totalGeneros) * 100) });

                    data.totalPerfiles = dashCara.Count().ToString();

                    // data.totalReferidosCara = dsCARA.VW_DSH_CARA_PERFILES.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).GroupBy(a => a.DE_FuenteReferido).Count().ToString();

                    data.totalReferidosCara = dashCara.Where(a => a.DE_FuenteReferido.Equals("Programa FR-CARA")).Select(x => x.PK_FuenteReferido).Count().ToString();

                    data.totalMasculino = generosPer.Where(a => a.DE_Genero.Equals("Masculino")).Select(x => x.Cantidad).SingleOrDefault().ToString();

                    data.perMasculino = generosPer.Where(a => a.DE_Genero.Equals("Masculino")).Select(x => x.Porcentaje).SingleOrDefault().ToString();

                    data.totalFemenino = generosPer.Where(a => a.DE_Genero.Equals("Femenino")).Select(x => x.Cantidad).SingleOrDefault().ToString();

                    data.perFemenino = generosPer.Where(a => a.DE_Genero.Equals("Femenino")).Select(x => x.Porcentaje).SingleOrDefault().ToString();

                    data.totalFM = generosPer.Where(a => a.DE_Genero.Equals("Transgénero (F->M)")).Select(x => x.Cantidad).SingleOrDefault().ToString();

                    data.perFM = generosPer.Where(a => a.DE_Genero.Equals("Transgénero (F->M)")).Select(x => x.Porcentaje).SingleOrDefault().ToString();

                    data.totalMF = generosPer.Where(a => a.DE_Genero.Equals("Transgénero (M->F)")).Select(x => x.Cantidad).SingleOrDefault().ToString();

                    data.perMF = generosPer.Where(a => a.DE_Genero.Equals("Transgénero (M->F)")).Select(x => x.Porcentaje).SingleOrDefault().ToString();

                    data.edadPromedio = Math.Round(Convert.ToDouble(dashCara.Select(x => x.Edad).Average())).ToString();

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
        public object[] dashCaraFuenteReferido(DateTime Desde, DateTime Hasta, List<dashCaraGenero> gen, List<dashCaraNivel> Niveles, List<dashCaraCentro> Centros)
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

                    var dashCara = dsCARA.VW_DSH_CARA_PERFILES.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.PK_Genero)).Where(x => listNiveles.Contains(x.PK_NivelSustancia)).Where(b => listCentros.Contains(b.PK_Centro)).GroupBy(a => a.DE_FuenteReferido).Select(x => new { DE_FuenteReferido = x.Key, Perfiles = x.Count() }).OrderByDescending(f => f.Perfiles);

                    DataTable Datos = new DataTable();

                    Datos.Columns.Add(new DataColumn("Fuente de Referido", typeof(String)));
                    Datos.Columns.Add(new DataColumn("Perfiles", typeof(String)));

                    var charData = new object[dashCara.Count() + 1];
                    charData[0] = new object[]
                        {
                        "Fuente de Referido","Perfiles"
                        };

                        int j = 0;
                        foreach (var item in dashCara)
                        {
                            j++;
                            charData[j] = new object[] { item.DE_FuenteReferido, item.Perfiles };
                        }

                    return charData;
                }
            }
            catch (Exception)
            {

                throw;
            }
            //DataTable Datos = new DataTable();

            //Datos.Columns.Add(new DataColumn("Mes", typeof(DateTime)));
            //Datos.Columns.Add(new DataColumn("Perfiles", typeof(int)));

            //Datos.Rows.Add(new Object[] { new DateTime(2019,1,1), 1000 });
            //Datos.Rows.Add(new Object[] { new DateTime(2019, 2, 2), 1170 });
            //Datos.Rows.Add(new Object[] { new DateTime(2019, 3, 3), 660 });
            //Datos.Rows.Add(new Object[] { new DateTime(2019, 4, 4), 1030 });
            //Datos.Rows.Add(new Object[] { new DateTime(2019, 5, 5), 1000 });

            //Datos.Columns.Add(new DataColumn("Centros de Servicio", typeof(String)));
            //Datos.Columns.Add(new DataColumn("Perfiles", typeof(String)));

            //Datos.Rows.Add(new Object[] { "Falu Home", 15 });
            //Datos.Rows.Add(new Object[] { "San Benedicto", 34 });
            //Datos.Rows.Add(new Object[] { "Casa Al", 22 });
            //Datos.Rows.Add(new Object[] { "Platinum", 66 });

            //string strDatos;

            //strDatos = "[['Centros de Servicio','Perfiles'],";

            //foreach (DataRow item in Datos.Rows)
            //{
            //    strDatos = strDatos + "[";
            //    strDatos = strDatos + "'" + item[0] + "'" + "," + item[1];
            //    strDatos = strDatos + "],";
            //}

            //strDatos = strDatos + "]";

            //var charData = new object[Datos.Rows.Count + 1];
            //charData[0] = new object[]
            //{
            //    "Centros de Servicio","Perfiles"
            //};

            //int j = 0;
            //foreach (DataRow item in Datos.Rows)
            //{
            //    j++;
            //    charData[j] = new object[] { item[0], item[1] };
            //}

            //return charData;
        }


        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void HelloWorld2()
        {
            string a = "a";
            //DataTable Datos = new DataTable();

            //Datos.Columns.Add(new DataColumn("Centros de Servicio", typeof(String)));
            //Datos.Columns.Add(new DataColumn("Perfiles", typeof(String)));

            //Datos.Rows.Add(new Object[] { "Dimelo papi", 5 });
            //Datos.Rows.Add(new Object[] { "Trata", 44});
            //Datos.Rows.Add(new Object[] { "Alcapone", 11 });
            //Datos.Rows.Add(new Object[] { "Oro", 122 });


            //var charData = new object[Datos.Rows.Count + 1];
            //charData[0] = new object[]
            //{
            //    "Centros de Servicio","Perfiles"
            //};

            //int j = 0;
            //foreach (DataRow item in Datos.Rows)
            //{
            //    j++;
            //    charData[j] = new object[] { item[0], item[1] };
            //}

            //return charData;
        }

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public object[] dashCaraNivelCuidado(DateTime Desde, DateTime Hasta, List<dashCaraGenero> gen, List<dashCaraNivel> Niveles, List<dashCaraCentro> Centros)
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

                    var dashCara = dsCARA.VW_DSH_CARA_PERFILES.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.PK_Genero)).Where(x => listNiveles.Contains(x.PK_NivelSustancia)).Where(b => listCentros.Contains(b.PK_Centro)).GroupBy(a => a.DE_NivelSustancia).Select(x => new { DE_NivelSustancia = x.Key, Perfiles = x.Count() }).OrderByDescending(f => f.Perfiles);

                    var charData = new object[dashCara.Count() + 1];
                    charData[0] = new object[]
                        {
                        "Nivel de Cuidado","Perfiles"
                        };

                    int j = 0;
                    foreach (var item in dashCara)
                    {
                        j++;
                        charData[j] = new object[] { item.DE_NivelSustancia, item.Perfiles };
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
        public object[] dashCaraDrogasUso(DateTime Desde, DateTime Hasta, List<dashCaraGenero> gen, List<dashCaraNivel> Niveles, List<dashCaraCentro> Centros)
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

                    var dashCara = dsCARA.VW_DSH_CARA_DROGAS_USO.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.FK_Genero)).Where(x => listNiveles.Contains(x.FK_NivelSustancia)).Where(b => listCentros.Contains(b.FK_Centro)).Where(c => !c.DE_Sustancia.Equals("No Aplica")).GroupBy(a => a.DE_Sustancia).Select(x => new { DE_Sustancia = x.Key, Perfiles = x.Count() });

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

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public object[] dashCaraSobredosis(DateTime Desde, DateTime Hasta, List<dashCaraGenero> gen, List<dashCaraNivel> Niveles, List<dashCaraCentro> Centros)
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

                    var dashCara = dsCARA.VW_DSH_CARA_PERFILES.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.PK_Genero)).Where(x => listNiveles.Contains(x.PK_NivelSustancia)).Where(b => listCentros.Contains(b.PK_Centro)).GroupBy(a => a.DE_Sobredosis).Select(x => new { DE_Sobredosis = x.Key, Perfiles = x.Count() });

                    var charData = new object[dashCara.Count() + 1];
                    charData[0] = new object[]
                        {
                        "Evento de Sobredosis","Perfiles"
                        };

                    int j = 0;
                    foreach (var item in dashCara)
                    {
                        j++;
                        charData[j] = new object[] { item.DE_Sobredosis, item.Perfiles };
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
        public object[] dashCaraDrogaSobredosis(DateTime Desde, DateTime Hasta, List<dashCaraGenero> gen, List<dashCaraNivel> Niveles, List<dashCaraCentro> Centros)
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

                    var dashCara = dsCARA.VW_DSH_CARA_DROGAS_SOBREDOSIS.Where(e => e.FE_Perfil >= Desde && e.FE_Perfil <= Hasta).Where(a => listGenero.Contains(a.FK_Genero)).Where(x => listNiveles.Contains(x.FK_NivelSustancia)).Where(b => listCentros.Contains(b.FK_Centro)).Where(c => !c.DE_Sustancia.Equals("No Aplica")).GroupBy(a => a.DE_Sustancia).Select(x => new { DE_Sustancia = x.Key, Perfiles = x.Count() }).OrderByDescending(f => f.Perfiles);

                    var charData = new object[dashCara.Count() + 1];
                    charData[0] = new object[]
                        {
                        "Drogas de Sobredosis","Cantidad"
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
        public object[] dashPerfiles(DateTime Desde, DateTime Hasta, List<dashCaraCentro> Centros)
        {
            try
            {
                List<int> listCentros = new List<int>();

                using (CARAEntities dsCARA = new CARAEntities())
                {
                    foreach (dashCaraCentro item in Centros)
                    {
                        listCentros.Add(item.pk_centro);
                    }

                    var perfiles = dsCARA.VW_DSH_PERFILES.Where(e => e.Fecha_Admisión >= Desde && e.Fecha_Admisión <= Hasta).Where(b => listCentros.Contains(b.FK_Centro)).ToList();

                    var names = typeof(VW_DSH_PERFILES).GetProperties()
                        .Select(property => property.Name)
                        .ToArray();

                    var charData = new object[perfiles.Count() + 1];
                    charData[0] = names;

                    int j = 0;
                    foreach (var item in perfiles)
                    {
                        j++;
                        charData[j] = new object[] { item.PK_Episodio, item.PK_Perfil, item.FK_Centro, item.Centro, item.Fecha_Admisión.ToString("MMMM dd, yyyy"), item.ID_Paciente, item.Tipo_Admisión, item.Dias_en_Espera, item.Arrestos_30_Dias, item.Fuente_Referido, item.Episodios_Previos,
                                                     item.Grupo_de_Apoyo, item.Genero, item.Estado_Marital, item.Residencia, item.Hijos_Menores, item.Embarazada, item.Veterano, item.Escolaridad, item.Condicion_Laboral, item.Estudios,
                                                     item.Fuente_Ingreso, item.Droga_Primaria, item.Toxicologia_Primaria, item.Via_Primaria, item.Frecuencia_Primaria, item.Edad_Primaria, item.Droga_Secundaria, item.Toxicologia_Secundaria, item.Via_Secundaria, item.Frecuencia_Secundaria, item.Edad_Secundaria,
                                                     item.Droga_Terciaria, item.Toxicologia_Terciaria, item.Via_Terciaria, item.Frecuencia_Terciaria, item.Edad_Terciaria, item.Droga_Cuarta, item.Toxicologia_Cuarta, item.Via_Cuarta, item.Frecuencia_Cuarta, item.Edad_Cuarta,
                                                     item.Droga_Quinta, item.Toxicologia_Quinta, item.Via_Quinta, item.Frecuencia_Quinta, item.Edad_Quinta, item.Evento_Sobredosis, item.Sobredosis_Primaria, item.Sobredosis_Secundaria, item.Sobredosis_Terciaria, item.Sobredosis_Cuarta,
                                                     item.ICDX_Primaria, item.ICDX_Secundaria, item.ICDX_Terciaria, item.ICDX_Cuarta, item.DSMV_Primaria, item.DSMV_Secundaria, item.DSMV_Terciaria, item.DSMV_Cuarta, item.Condicion_Primaria, item.Condicion_Secundaria, item.Condicion_Terciaria,
                                                     item.Condicion_Cuarta, item.Nivel_Cuidado, item.Seguro_Salud
                        };
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
