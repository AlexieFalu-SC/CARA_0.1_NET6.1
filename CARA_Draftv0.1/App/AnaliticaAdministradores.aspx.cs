using CARA_Draftv0._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

                    lbxCentroPerfiles.DataValueField = "PK_Centro";
                    lbxCentroPerfiles.DataTextField = "NB_Centro";
                    lbxCentroPerfiles.DataSource = dsCARA.CA_CENTRO.ToList();
                    lbxCentroPerfiles.DataBind();

                    this.txtFechaDesde.Text = DateTime.Today.AddMonths(-6).ToString("yyyy-MM-dd");
                    this.txtFechaHasta.Text = DateTime.Today.ToString("yyyy-MM-dd");

                    this.txtPerfilesDesde.Text = DateTime.Today.AddMonths(-6).ToString("yyyy-MM-dd");
                    this.txtPerfilesHasta.Text = DateTime.Today.ToString("yyyy-MM-dd");

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}