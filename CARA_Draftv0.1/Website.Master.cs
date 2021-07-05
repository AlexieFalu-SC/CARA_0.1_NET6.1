using CARA_Draftv0._1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1
{
    public partial class Website : System.Web.UI.MasterPage
    {
        ApplicationUser Usuario = new ApplicationUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Account/Login.aspx", false);
                return;
            }

            if (!Page.IsPostBack)
            {
                Usuario = (ApplicationUser)Session["Usuario"];

                ApplicationDbContext context = new ApplicationDbContext();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                this.lblNombre.Text = Usuario.NB_Primero + " " + Usuario.AP_Primero;

                if(Usuario.PasswordChanged && Usuario.EmailConfirmed)
                {
                    if (userManager.IsInRole(Usuario.Id, "SuperAdmin") || userManager.IsInRole(Usuario.Id, "Registrado") || userManager.IsInRole(Usuario.Id, "Operador de Registro"))
                    {
                        divRegistroPerfiles.Visible = true;
                    }
                    if (userManager.IsInRole(Usuario.Id, "SuperAdmin") || userManager.IsInRole(Usuario.Id, "Registrado") || userManager.IsInRole(Usuario.Id, "Operador de Registro") || userManager.IsInRole(Usuario.Id, "AdminCARA") || userManager.IsInRole(Usuario.Id, "AdminPlanificacion"))
                    {
                        divExpedientes.Visible = true;
                    }
                    if (userManager.IsInRole(Usuario.Id, "SuperAdmin"))
                    {
                        divFacilidadesAdmin.Visible = true;
                    }
                    if (userManager.IsInRole(Usuario.Id, "Registrado"))
                    {
                        divFacilidades.Visible = true;
                    }
                    if (userManager.IsInRole(Usuario.Id, "SuperAdmin") || userManager.IsInRole(Usuario.Id, "AdminCARA") || userManager.IsInRole(Usuario.Id, "AdminPlanificacion") || userManager.IsInRole(Usuario.Id, "AdminObservatorio") || userManager.IsInRole(Usuario.Id, "AdminTablero"))
                    {
                        divAnaliticaAdmin.Visible = true;
                    }
                    if (userManager.IsInRole(Usuario.Id, "Registrado") || userManager.IsInRole(Usuario.Id, "Operador Estadistico"))
                    {
                        divAnaliticaRegistrado.Visible = true;
                    }
                }
                
            }

        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    var spd_sesion = dsCARA.SPD_SESION(Session["PK_Sesion"].ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
            Session["Usuario"] = null;
            Session["PK_Sesion"] = null;
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}