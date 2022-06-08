using CARA_Draftv0._1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1.App.Administracion
{
    public partial class adminRegistroUsuarioExtPrincipal : System.Web.UI.Page
    {
        ApplicationDbContext context = new ApplicationDbContext();
        ApplicationUser Usuario = new ApplicationUser();
        protected string PK_Sesion;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PrepararDropDownLists();
            }
        }

        private void PrepararDropDownLists()
        {
            Usuario = (ApplicationUser)Session["Usuario"];

            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {

                    var licencias = dsCARA.CA_LICENCIA.Select(r => new ListItem { Value = r.PK_Licencia.ToString(), Text = r.NB_Licencia }).ToList();

                    ddlLicencia.DataValueField = "Value";
                    ddlLicencia.DataTextField = "Text";
                    ddlLicencia.DataSource = licencias;
                    ddlLicencia.DataBind();
                    ddlLicencia.Items.Insert(0, new ListItem("", "0"));

                }

            }
            catch (Exception ex)
            {
                string mensaje;

                if (ex.InnerException == null)
                {
                    mensaje = ex.Message;
                }
                else
                {
                    mensaje = ex.InnerException.Message;
                }

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
            }
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            PK_Sesion = Session["PK_Sesion"].ToString();
            Usuario = (ApplicationUser)Session["Usuario"];

            string mensaje = string.Empty;

            Guid idSlyc = Guid.NewGuid();

            var ab = this.txtCentro.Text;
            var aa = this.lblCentro.Text;

            //this.coverScreen.Visible = true;

            /*Validación de existencia de usuario*/
            var emailExiste = manager.FindByEmail(Email.Text);
            if (emailExiste != null)
            {
                mensaje = "Una cuenta con el email: " + Email.Text + " ya existe. Si desea registrarle una facilidad a dicha cuenta, favor acceder a la pantalla de agregar facilidades.";
                //this.coverScreen.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
                return;
            }
            else
            {

                var user = new ApplicationUser()
                {
                    UserName = Email.Text,
                    Email = Email.Text,
                    NB_Primero = NB_Primero.Text,
                    NB_Segundo = NB_Segundo.Text,
                    AP_Primero = AP_Primero.Text,
                    AP_Segundo = AP_Segundo.Text,
                    Tel_Celular = Telefono.Text,
                    Tel_Trabajo = Telefono.Text,
                    PasswordChanged = false,
                    Active = true,
                    EmailConfirmed = false,
                    LockoutEnabled = false
                };

                //var newuser = userManager.Create(user, password);
                var newuser = userManager.Create(user);

                if (newuser.Succeeded)
                {
                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    //string code = manager.GenerateEmailConfirmationToken(user.Id);
                    //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                    //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                    //signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                    //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);

                    // var rol = context.Roles.Where(p => p.Name.Equals("Registrado Usuario")).FirstOrDefault();

                    try
                    {
                        using (CARAEntities dsCARA = new CARAEntities())
                        {
                            userManager.AddToRole(user.Id, "Registrado Administrativo");

                            dsCARA.SPC_CENTRO(txtCentro.Text, idSlyc, "", Email.Text);

                            int pk_centro = dsCARA.VW_CENTROS_ADMINISTRADORES.Where(a => a.Email == Email.Text).Select(f => f.PK_Centro).First();

                            int pk_licencia = Convert.ToInt32(ddlLicencia.SelectedValue);

                            DateTime fechaExp = Convert.ToDateTime(txtFechaExp.Text);

                            dsCARA.SPC_ATAR_CENTRO_LICENCIA(pk_centro, pk_licencia, txtNumLicencia.Text, fechaExp);

                            dsCARA.SPC_SESION_ACTIVIDAD(PK_Sesion, "UsuarioRegistrado", "C", user.Id, pk_centro, null, null);

                            mensaje = "El registro del usuario y facilidad fué correcto. Se envió un email de confirmación al nuevo usuario para realizar la confirmación de cuenta.";


                            string code = manager.GenerateEmailConfirmationToken(user.Id);
                            string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                            string body = CreateBody(callbackUrl, "1234");
                            manager.SendEmail(user.Id, "Confirmacion de su cuenta", body);

                            //this.coverScreen.Visible = false;

                            ClientScript.RegisterStartupScript(this.GetType(), "Usuario Registrado", "sweetAlertRef('Usuario Registrado','" + mensaje + "','success','" + "App/Administracion/adminListaUsuarios.aspx" + "');", true);
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Usuario Registrado", "sweetAlert('Usuario Registrado','" + mensaje + "','success')", true);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex.InnerException == null)
                        {
                            mensaje = ex.Message;
                        }
                        else
                        {
                            mensaje = ex.InnerException.Message;
                        }

                        //this.coverScreen.Visible = false;

                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
                    }

                }
                else
                {
                    //this.coverScreen.Visible = false;

                    mensaje = "Occurió un error al intentar realizar el registro. Favor de intentar nuevamente o contactar a informática.";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
                    return;
                }
            }
        }

        private string CreateBody(string Code, string password)
        {
            string body = string.Empty;
            string code = "<a href =\"" + Code + "\" class=\"es-button\" target=\"_blank\" style=\"mso-style-priority:100 !important;text-decoration:none;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;font-size:18px;color:#4A7EB0;border-style:solid;border-color:#EFEFEF;border-width:10px 25px;display:inline-block;background:#EFEFEF;border-radius:0px;font-weight:normal;font-style:normal;line-height:22px;width:auto;text-align:center;\">Confirmar Cuenta</a>";
            using (StreamReader reader = new StreamReader(Server.MapPath("~/App/EmailsHTML/ConfirmacionCuenta.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{NombreCompleto}", NB_Primero.Text + " " + AP_Primero.Text);
            body = body.Replace("{email}", Email.Text);
            body = body.Replace("{password}", password);
            body = body.Replace("{botonConfirmar}", code);

            return body;

        }
    }
}