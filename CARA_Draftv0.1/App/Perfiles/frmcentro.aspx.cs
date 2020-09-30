using CARA_Draftv0._1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1.App.Perfiles
{
    public partial class frmCentro : System.Web.UI.Page
    {
        ApplicationUser Usuario = new ApplicationUser();
        protected string Centro;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Account/Login.aspx", false);
                return;
            }

            Usuario = (ApplicationUser)Session["Usuario"];
            Centro = this.Request.QueryString["centro"].ToString();

            if (!this.IsPostBack)
            {
                ApplicationDbContext context = new ApplicationDbContext();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                if (userManager.IsInRole(Usuario.Id, "Registrado"))
                {
                    try
                    {
                        using (CARAEntities dsCARA = new CARAEntities())
                        {
                            var centrosMap = dsCARA.CA_USUARIO_CENTRO.Where(a => a.FK_Usuario.Equals(Usuario.Id)).Select(f => f.FK_Centro).DefaultIfEmpty();

                            ddlCentro.DataValueField = "PK_Centro";
                            ddlCentro.DataTextField = "NB_Centro";
                            ddlCentro.DataSource = dsCARA.CA_CENTRO.Where(u => centrosMap.Contains(u.PK_Centro)).ToList();
                            ddlCentro.DataBind();
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                else
                {
                    PrepararDropDownLists();
                }
                
            }
                
        }

        private void PrepararDropDownLists()
        {
            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    ddlCentro.DataValueField = "PK_Centro";
                    ddlCentro.DataTextField = "NB_Centro";
                    ddlCentro.DataSource = dsCARA.CA_CENTRO.ToList();
                    ddlCentro.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnAutenticarPrograma_Click(object sender, EventArgs e)
        {
            int PK_Centro = Convert.ToInt32(this.ddlCentro.SelectedValue.ToString());
            this.Session["PK_Centro"] = this.ddlCentro.SelectedValue.ToString();
            this.Session["NB_Centro"] = this.ddlCentro.SelectedItem.ToString();

            this.Response.Redirect("~/App/Pacientes/frmconsulta.aspx?centro=" + Centro);
        }
    }
}