using CARA_Draftv0._1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1.Account
{
    public partial class RegistroRegistrado : System.Web.UI.Page
    {
        ApplicationDbContext context = new ApplicationDbContext();
        ApplicationUser Usuario = new ApplicationUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Account/Login.aspx", false);
                return;
            }

            Usuario = (ApplicationUser)Session["Usuario"];

            string Roles = this.Request.QueryString["roles"].ToString();

            if (!this.IsPostBack)
            {
                try
                {
                    List<ListItem> roles = context.Roles.Where(p => p.Name.Contains("Operador")).Select(r => new ListItem { Value = r.Name, Text = r.Name }).ToList();

                    List<string> rolesRegistrado = new List<string>()
                    {
                        "Registrado", "Operador de Registro", "Operador Estadistico"
                    };

                    switch (Roles)
                    {
                        case ("administradores"):
                            roles = context.Roles.Where(p => !rolesRegistrado.Contains(p.Name)).Select(r => new ListItem { Value = r.Name, Text = r.Name }).ToList();
                            break;
                        case ("registrados"):
                            roles = context.Roles.Where(p => p.Name.Equals("Registrado")).Select(r => new ListItem { Value = r.Name, Text = r.Name }).ToList();
                            break;
                        case ("operadores"):
                            roles = context.Roles.Where(p => p.Name.Contains("Operador")).Select(r => new ListItem { Value = r.Name, Text = r.Name }).ToList();
                            break;
                    }

                    ddlRol.DataValueField = "Value";
                    ddlRol.DataTextField = "Text";
                    ddlRol.DataSource = roles;
                    ddlRol.DataBind();
                    ddlRol.Items.Insert(0, new ListItem("", "0"));

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
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            string password = GeneratePassword();
                //GeneratePassword();

            var user = new ApplicationUser()
            {
                UserName = Email.Text,
                Email = Email.Text,
                NB_Primero = txtNB_Primero.Text,
                NB_Segundo = txtNB_Segundo.Text,
                AP_Primero = txtAP_Primero.Text,
                AP_Segundo = txtAP_Segundo.Text,
                Tel_Celular = txtTel.Text,
                Tel_Trabajo = txtTel.Text,
                PasswordChanged = false,
                Active = true,
                EmailConfirmed = false
            };
            IdentityResult result = manager.Create(user, password);
            if (result.Succeeded)
            {
                string mensaje = string.Empty;
                string url = string.Empty;
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                userManager.AddToRole(user.Id, ddlRol.SelectedValue);

                try
                {
                    if (userManager.IsInRole(Usuario.Id, "Registrado"))
                    {
                        using (CARAEntities dsCARA = new CARAEntities())
                        {
                            dsCARA.SPC_CENTROS_A_REGISTRADO(Usuario.Id, user.Id);
                        }

                        url = "Account/adminRegistrado.aspx";
                    }
                    else
                    {
                        url = "Account/adminAdministrador.aspx";
                    }

                    mensaje = "El registro del usuario fué correcto. Se envió un email de confirmación al nuevo usuario.";

                    string code = manager.GenerateEmailConfirmationToken(user.Id);
                    string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                    string body = CreateBody(callbackUrl, password);
                    manager.SendEmail(user.Id, "Confirmacion de su cuenta", body);

                    ClientScript.RegisterStartupScript(this.GetType(), "Usuario Registrado", "sweetAlertRef('Usuario Registrado','" + mensaje + "','success','"+url+"');", true);
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
            body = body.Replace("{NombreCompleto}", txtNB_Primero.Text + " " + txtAP_Primero.Text);
            body = body.Replace("{email}", Email.Text);
            body = body.Replace("{password}", password);
            body = body.Replace("{botonConfirmar}", code);

            return body;

        }
    }
}