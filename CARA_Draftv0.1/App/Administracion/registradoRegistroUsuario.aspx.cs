using CARA_Draftv0._1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1.App.Administracion
{
    public partial class registradoRegistroUsuario : System.Web.UI.Page
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
                    var centrosMap = dsCARA.CA_USUARIO_CENTRO.Where(a => a.FK_Usuario.Equals(Usuario.Id)).Select(f => f.FK_Centro).DefaultIfEmpty();
                    var facilidades = dsCARA.CA_CENTRO.Where(u => centrosMap.Contains(u.PK_Centro)).DefaultIfEmpty().ToList();

                    lbxFacilidades.DataValueField = "PK_Centro";
                    lbxFacilidades.DataTextField = "NB_Centro";
                    lbxFacilidades.DataSource = facilidades;
                    lbxFacilidades.DataBind();

                }

            }
            catch (Exception ex)
            {

                string mensaje = ex.Message;
            }
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            string password = GeneratePassword();
            PK_Sesion = Session["PK_Sesion"].ToString();

            string mensaje = string.Empty;

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

            var newuser = userManager.Create(user, password);

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
                        var result = userManager.AddToRole(user.Id, "Registrado Usuario");

                        dsCARA.SPC_SESION_ACTIVIDAD(PK_Sesion, "Usuario", "C", user.Id, null, null, null);

                        mensaje = "El registro del usuario fué correcto. Se envió un email de confirmación al nuevo usuario.";

                        for (int i = 0; i < lbxFacilidades.Items.Count; i++)
                        {
                            if(lbxFacilidades.Items[i].Selected)
                            {
                                int centro = Int32.Parse(lbxFacilidades.Items[i].Value);
                                dsCARA.SPC_CENTROS_A_REGISTRADO(user.Id, centro);
                            }
                        }

                        var RegistroPerfiles_Claims = new Claim("Modulo", "RegistroPerfiles");
                        var AccesoExpedientes_Claims = new Claim("Modulo", "AccesoExpedientes");
                        var AccesoTableros_Claims = new Claim("Modulo", "AccesoTableros");

                        for (int i = 0; i < chkModulos.Items.Count; i++)
                        {
                            if (chkModulos.Items[i].Selected)
                            {
                                if (chkModulos.Items[i].Value == "RegistroPerfiles")
                                {
                                    userManager.AddClaimAsync(user.Id, RegistroPerfiles_Claims).GetAwaiter().GetResult();
                                }
                                else if (chkModulos.Items[i].Value == "AccesoExpedientes")
                                {
                                    userManager.AddClaimAsync(user.Id, AccesoExpedientes_Claims).GetAwaiter().GetResult();
                                }
                                else if (chkModulos.Items[i].Value == "AccesoTableros")
                                {
                                    userManager.AddClaimAsync(user.Id, AccesoTableros_Claims).GetAwaiter().GetResult();
                                }
                            }
                        }

                        string code = manager.GenerateEmailConfirmationToken(user.Id);
                        string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                        string body = CreateBody(callbackUrl, password);
                        manager.SendEmail(user.Id, "Confirmacion de su cuenta", body);

                        ClientScript.RegisterStartupScript(this.GetType(), "Usuario Registrado", "sweetAlertRef('Usuario Registrado','" + mensaje + "','success','" + "App/Administracion/registradoListaUsuarios.aspx" + "');", true);
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

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
                }

            }
            else
            {
                //ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        public string GeneratePassword()
        {


            int length = 8;

            bool nonAlphanumeric = true;
            bool digit = true;
            bool lowercase = true;
            bool uppercase = true;

            StringBuilder password = new StringBuilder();
            Random random = new Random();

            while (password.Length < length)
            {
                char c = (char)random.Next(32, 126);

                password.Append(c);

                if (char.IsDigit(c))
                    digit = false;
                else if (char.IsLower(c))
                    lowercase = false;
                else if (char.IsUpper(c))
                    uppercase = false;
                else if (!char.IsLetterOrDigit(c))
                    nonAlphanumeric = false;
            }

            if (nonAlphanumeric)
                password.Append((char)random.Next(33, 48));
            if (digit)
                password.Append((char)random.Next(48, 58));
            if (lowercase)
                password.Append((char)random.Next(97, 123));
            if (uppercase)
                password.Append((char)random.Next(65, 91));

            return password.ToString();
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