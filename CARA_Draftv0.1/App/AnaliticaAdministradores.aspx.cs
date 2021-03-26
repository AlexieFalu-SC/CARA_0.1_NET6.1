using CARA_Draftv0._1.Models;
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
    public partial class AnaliticaAdministradores : System.Web.UI.Page
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
                PrepararDropDownLists();
                GenerarReportes();
            }
        }

        private void PrepararDropDownLists()
        {
            try
            {
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

                    lbxCentro.DataValueField = "PK_Centro";
                    lbxCentro.DataTextField = "NB_Centro";
                    lbxCentro.DataSource = dsCARA.CA_CENTRO.ToList();
                    lbxCentro.DataBind();

                    //lbxCentroPerfiles.DataValueField = "PK_Centro";
                    //lbxCentroPerfiles.DataTextField = "NB_Centro";
                    //lbxCentroPerfiles.DataSource = dsCARA.CA_CENTRO.ToList();
                    //lbxCentroPerfiles.DataBind();

                    this.txtFechaDesde.Text = DateTime.Today.AddMonths(-6).ToString("yyyy-MM-dd");
                    this.txtFechaHasta.Text = DateTime.Today.ToString("yyyy-MM-dd");

                    //this.txtPerfilesDesde.Text = DateTime.Today.AddMonths(-6).ToString("yyyy-MM-dd");
                    //this.txtPerfilesHasta.Text = DateTime.Today.ToString("yyyy-MM-dd");

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

            rvAnaliticaPerfiles.Height = Unit.Pixel(800 - 58);
            rvAnaliticaPerfiles.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            rvAnaliticaPerfiles.ServerReport.ReportServerCredentials = irsc;
            rvAnaliticaPerfiles.ServerReport.ReportServerUrl = new Uri("http://192.168.100.24//ReportServer"); // Add the Reporting Server URL  
            rvAnaliticaPerfiles.ServerReport.ReportPath = "/Informes CARA/PERFILES_PLAN";

            rvAnaliticaAdministradores.ServerReport.Refresh();
            rvAnaliticaPerfiles.ServerReport.Refresh();
        }

    }

    public class CustomReportCredentials : IReportServerCredentials
    {
        private string _UserName;
        private string _PassWord;
        private string _DomainName;

        public CustomReportCredentials(string UserName, string PassWord, string DomainName)
        {
            _UserName = UserName;
            _PassWord = PassWord;
            _DomainName = DomainName;
        }

        public System.Security.Principal.WindowsIdentity ImpersonationUser
        {
            get { return null; }
        }

        public ICredentials NetworkCredentials
        {
            get { return new NetworkCredential(_UserName, _PassWord); }
        }

        //ICredentials IReportServerCredentials.NetworkCredentials => throw new NotImplementedException();

        public bool GetFormsCredentials(out Cookie authCookie, out string user,
         out string password, out string authority)
        {
            authCookie = null;
            user = password = authority = null;
            return false;
        }

        //public bool GetFormsCredentials(out Cookie authCookie, out string userName, out string password, out string authority)
        //{
        //    throw new NotImplementedException();
        //}
    }
}