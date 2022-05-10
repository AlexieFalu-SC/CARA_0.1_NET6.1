using CARA_Draftv0._1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1.App
{
    public partial class devAnaRegistradores : System.Web.UI.Page
    {
        ApplicationDbContext context = new ApplicationDbContext();
        ApplicationUser Usuario = new ApplicationUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                PrepararDropDownLists();
            }
        }

        private void PrepararDropDownLists()
        {
            try
            {
                Usuario = (ApplicationUser)Session["Usuario"];

                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                using (CARAEntities dsCARA = new CARAEntities())
                {
                    //lbxGenero.DataValueField = "PK_Genero";
                    //lbxGenero.DataTextField = "DE_Genero";
                    //lbxGenero.DataSource = dsCARA.CA_LKP_GENERO.ToList();
                    //lbxGenero.DataBind();

                    //lbxNivelSustancia.DataValueField = "PK_NivelSustancia";
                    //lbxNivelSustancia.DataTextField = "DE_NivelSustancia";
                    //lbxNivelSustancia.DataSource = dsCARA.CA_LKP_NIVEL_SUSTANCIA.ToList();
                    //lbxNivelSustancia.DataBind();

                    //lbxCentro.DataValueField = "PK_Centro";
                    //lbxCentro.DataTextField = "NB_Centro";
                    //lbxCentro.DataSource = dsCARA.CA_CENTRO.ToList();
                    //lbxCentro.DataBind();

                    //this.txtFechaDesde.Text = DateTime.Today.AddMonths(-6).ToString("yyyy-MM-dd");
                    //this.txtFechaHasta.Text = DateTime.Today.ToString("yyyy-MM-dd");


                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}