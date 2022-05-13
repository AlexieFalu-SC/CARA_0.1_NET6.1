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

                if (userManager.IsInRole(Usuario.Id, "Registrado Administrativo") || userManager.IsInRole(Usuario.Id, "Registrado Usuario"))
                {
                    try
                    {
                        using (CARAEntities dsCARA = new CARAEntities())
                        {
                            var Centros = dsCARA.VW_USUARIOS_CENTROS_LICENCIAS.Where(a => a.PK_Usuario.Equals(Usuario.Id)).ToList().DefaultIfEmpty();
                            
                            ddlCentro.DataValueField = "PK_Centro";
                            ddlCentro.DataTextField = "NB_Centro";
                            ddlCentro.DataSource = Centros;
                            ddlCentro.DataBind();
                            ddlCentro.Items.FindByValue(Centros.FirstOrDefault().PK_Centro.ToString()).Selected = true;

                            PrepararLicenciasDeCentro();
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

        private void PrepararLicenciasDeCentro()
        {
            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    int PK_Centro = Int32.Parse(ddlCentro.SelectedValue);
                    var Licencias = dsCARA.VW_USUARIOS_CENTROS_LICENCIAS.Where(a => a.PK_Centro.Equals(PK_Centro)).Select(r => new ListItem { Value = r.PK_Centro_Licencia.ToString(), Text = r.NB_Licencia }).ToList().Distinct().DefaultIfEmpty();

                    ddlLicencias.DataValueField = "Value";
                    ddlLicencias.DataTextField = "Text";
                    ddlLicencias.DataSource = Licencias;
                    ddlLicencias.DataBind();
                }
            }
            catch (Exception ex)
            {

                string message = ex.Message;
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

                    PrepararLicenciasDeCentro();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void CambioDePrograma(object sender, EventArgs e)
        {
            PrepararLicenciasDeCentro();
        }

        protected void btnAutenticarPrograma_Click(object sender, EventArgs e)
        {
            int PK_Centro = Convert.ToInt32(this.ddlCentro.SelectedValue.ToString());
            this.Session["PK_Centro"] = this.ddlCentro.SelectedValue.ToString();
            this.Session["NB_Centro"] = this.ddlCentro.SelectedItem.ToString();

            this.Session["PK_Centro_Licencia"] = this.ddlLicencias.SelectedValue.ToString();
            this.Session["NB_Licencia"] = this.ddlLicencias.SelectedItem.ToString();

            this.Response.Redirect("~/App/Pacientes/frmconsulta.aspx?centro=" + Centro);
        }
    }
}