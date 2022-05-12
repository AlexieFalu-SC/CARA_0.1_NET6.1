using CARA_Draftv0._1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1
{
    public partial class Website : System.Web.UI.MasterPage
    {
        ApplicationUser Usuario = new ApplicationUser();
        ApplicationDbContext context = new ApplicationDbContext();

        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PK_Sesion"] == null)
            {
                Response.Redirect("~/Account/Login.aspx", false);
                return;
            }
            else if (Session["Usuario"] == null)
            {
                var userId = Context.User.Identity.GetUserId();
                Usuario = context.Users.Where(a => a.Id.Equals(userId)).FirstOrDefault();
                Session["Usuario"] = Usuario;
                setUserInformation();
                return;
            }


            if (!Page.IsPostBack)
            {

                setUserInformation();
                //this.lblNombre.Text = Usuario.NB_Primero + " " + Usuario.AP_Primero;

                //if (Usuario.PasswordChanged && Usuario.EmailConfirmed)
                //{
                //    if (userManager.IsInRole(Usuario.Id, "SuperAdmin") || userManager.IsInRole(Usuario.Id, "Registrado") || userManager.IsInRole(Usuario.Id, "Operador de Registro"))
                //    {
                //        divRegistroPerfiles.Visible = true;
                //    }
                //    if (userManager.IsInRole(Usuario.Id, "SuperAdmin") || userManager.IsInRole(Usuario.Id, "Registrado") || userManager.IsInRole(Usuario.Id, "Operador de Registro") || userManager.IsInRole(Usuario.Id, "AdminCARA") || userManager.IsInRole(Usuario.Id, "AdminPlanificacion"))
                //    {
                //        divExpedientes.Visible = true;
                //    }
                //    if (userManager.IsInRole(Usuario.Id, "SuperAdmin"))
                //    {
                //        divFacilidadesAdmin.Visible = true;
                //    }
                //    if (userManager.IsInRole(Usuario.Id, "Registrado"))
                //    {
                //        divFacilidades.Visible = true;
                //    }
                //    if (userManager.IsInRole(Usuario.Id, "SuperAdmin") || userManager.IsInRole(Usuario.Id, "AdminCARA") || userManager.IsInRole(Usuario.Id, "AdminPlanificacion") || userManager.IsInRole(Usuario.Id, "AdminObservatorio") || userManager.IsInRole(Usuario.Id, "AdminTablero"))
                //    {
                //        divAnaliticaAdmin.Visible = true;
                //    }
                //    if (userManager.IsInRole(Usuario.Id, "Registrado") || userManager.IsInRole(Usuario.Id, "Operador Estadistico"))
                //    {
                //        divAnaliticaRegistrado.Visible = true;
                //    }
                //}

            }

            //if ((System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            //{
            //    if (Session["Usuario"] == null)
            //    {
            //        var userId = Context.User.Identity.GetUserId();
            //        Usuario = context.Users.Where(a => a.Id.Equals(userId)).FirstOrDefault();
            //        Session["Usuario"] = Usuario;
            //    }

            //    //Response.Redirect("~/App/Entrada.aspx", false);

            //}
            //else
            //{
            //    Response.Redirect("~/Account/Login.aspx", false);
            //    return;
            //}

            //if (!Page.IsPostBack)
            //{

            //}

        }

        private void setUserInformation()
        {
            Usuario = (ApplicationUser)Session["Usuario"];

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            this.lblNombre.Text = Usuario.NB_Primero + " " + Usuario.AP_Primero;

            try
            {
                if (userManager.IsInRole(Usuario.Id, "SuperAdmin") || userManager.IsInRole(Usuario.Id, "Supervisor") || userManager.IsInRole(Usuario.Id, "Estadistico"))
                {
                    if (userManager.IsInRole(Usuario.Id, "SuperAdmin"))
                    {
                        divRegistroPerfiles.Visible = true;

                        divExpedientes.Visible = true;

                        divTablerosAnaliticos.Visible = true;
                        secAnaliticaAdministradores.Visible = true;
                        secExportarAdministradores.Visible = true;

                        divAdministracion.Visible = true;
                        secManejoUsuariosAdministrativo.Visible = true;
                    }
                    //secAnaliticaRegistradores.Visible = true;
                }
                else
                {
                    if (userManager.IsInRole(Usuario.Id, "Registrado Administrativo"))
                    {
                        divRegistroPerfiles.Visible = true;

                        divExpedientes.Visible = true;

                        divTablerosAnaliticos.Visible = true;
                        secAnaliticaRegistradores.Visible = true;
                        secExportarRegistradores.Visible = true;

                        divAdministracion.Visible = true;
                        secManejoUsuariosRegistrado.Visible = true;
                    }
                    else
                    {
                        var cla = Usuario.Claims.ToList();
                        // var claims = userManager.GetClaimsAsync(item.PK_Usuario);

                        var RegistroPerfiles = cla.Where(x => x.ClaimValue == "RegistroPerfiles").Count();
                        var AccesoExpedientes = cla.Where(x => x.ClaimValue == "AccesoExpedientes").Count();
                        var AccesoTableros = cla.Where(x => x.ClaimValue == "AccesoTableros").Count();

                        if (RegistroPerfiles > 0)
                        {
                            divRegistroPerfiles.Visible = true;
                        }
                        if (AccesoExpedientes > 0)
                        {
                            divExpedientes.Visible = true;
                        }
                        if (AccesoTableros > 0)
                        {
                            divTablerosAnaliticos.Visible = true;
                            secAnaliticaRegistradores.Visible = true;
                            secExportarRegistradores.Visible = true;
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }

            
        }

        protected void setActiveNav()
        {

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
            Response.Redirect("~/Account/Login.aspx", false);
            return;
        }
    }
}