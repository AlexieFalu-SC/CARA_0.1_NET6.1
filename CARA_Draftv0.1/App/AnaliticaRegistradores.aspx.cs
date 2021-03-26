using CARA_Draftv0._1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1.App
{
    public partial class AnaliticaRegistradores : System.Web.UI.Page
    {
        ApplicationUser Usuario = new ApplicationUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Account/Login.aspx", false);
                return;
            }

            if (!this.IsPostBack)
            {
                Usuario = (ApplicationUser)Session["Usuario"];

                PrepararDropDownLists();
                GenerarReportes();
            }
        }

        private void PrepararDropDownLists()
        {
            try
            {
                ApplicationDbContext context = new ApplicationDbContext();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                using (CARAEntities dsCARA = new CARAEntities())
                {
                    lbxGenero.DataValueField = "PK_Genero";
                    lbxGenero.DataTextField = "DE_Genero";
                    lbxGenero.DataSource = dsCARA.CA_LKP_GENERO.ToList();
                    lbxGenero.DataBind();

                    lbxNivelSustancia.DataValueField = "PK_NivelSustancia";
                    lbxNivelSustancia.DataTextField = "DE_NivelSustancia";
                    lbxNivelSustancia.DataSource = dsCARA.CA_LKP_NIVEL_SUSTANCIA.ToList();
                    lbxNivelSustancia.DataBind();

                    var centrosMap = dsCARA.CA_USUARIO_CENTRO.Where(a => a.FK_Usuario.Equals(Usuario.Id)).Select(f => f.FK_Centro).DefaultIfEmpty();
                    var centros = dsCARA.CA_CENTRO.Where(u => centrosMap.Contains(u.PK_Centro)).ToList();

                    lbxCentro.DataValueField = "PK_Centro";
                    lbxCentro.DataTextField = "NB_Centro";
                    lbxCentro.DataSource = centros;
                    lbxCentro.DataBind();

                    this.txtFechaDesde.Text = DateTime.Today.AddMonths(-6).ToString("yyyy-MM-dd");
                    this.txtFechaHasta.Text = DateTime.Today.ToString("yyyy-MM-dd");


                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        void GenerarReportes()
        {
            rvAnaliticaAdministradores.Height = Unit.Pixel(800 - 58);
            rvAnaliticaAdministradores.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            IReportServerCredentials irsc = new CustomReportCredentials("alexie.ortiz", "Alexito@1912", "assmca.local"); // e.g.: ("demo-001", "123456789", "ifc")
            rvAnaliticaAdministradores.ServerReport.ReportServerCredentials = irsc;
            rvAnaliticaAdministradores.ServerReport.ReportServerUrl = new Uri("http://192.168.100.24//ReportServer"); // Add the Reporting Server URL  
            rvAnaliticaAdministradores.ServerReport.ReportPath = "/Informes CARA/PERFILES";
            rvAnaliticaAdministradores.ServerReport.Refresh();
        }
    }

}