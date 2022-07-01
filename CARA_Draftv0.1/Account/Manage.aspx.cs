using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using CARA_Draftv0._1.Models;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected string SuccessMessage
        {
            get;
            private set;
        }

        private bool HasPassword(ApplicationUserManager manager)
        {
            return manager.HasPassword(User.Identity.GetUserId());
        }

        public bool HasPhoneNumber { get; private set; }

        public bool TwoFactorEnabled { get; private set; }

        public bool TwoFactorBrowserRemembered { get; private set; }

        public int LoginsCount { get; set; }

        ApplicationDbContext context = new ApplicationDbContext();
        ApplicationUser Usuario = new ApplicationUser();

        protected void Page_Load()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            HasPhoneNumber = String.IsNullOrEmpty(manager.GetPhoneNumber(User.Identity.GetUserId()));

            // Enable this after setting up two-factor authentientication
            //PhoneNumber.Text = manager.GetPhoneNumber(User.Identity.GetUserId()) ?? String.Empty;

            TwoFactorEnabled = manager.GetTwoFactorEnabled(User.Identity.GetUserId());

            LoginsCount = manager.GetLogins(User.Identity.GetUserId()).Count;

            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            Usuario = (ApplicationUser)Session["Usuario"];

            

            if (!IsPostBack)
            {
                SetUserInformation();

                //// Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    //    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/Manage");

                SuccessMessage =
                    message == "ChangePwdSuccess" ? "Your password has been changed."
                    : message == "SetPwdSuccess" ? "Your password has been set."
                    : message == "RemoveLoginSuccess" ? "The account was removed."
                    : message == "AddPhoneNumberSuccess" ? "Phone number has been added"
                    : message == "RemovePhoneNumberSuccess" ? "Phone number was removed"
                    : String.Empty;
                    //    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }
            }
        }

        private void SetUserInformation()
        {
            Usuario = (ApplicationUser)Session["Usuario"];

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            var rol = userManager.GetRoles(Usuario.Id).FirstOrDefault().ToString();

            this.lblNombre.Text = Usuario.NB_Primero + " " + Usuario.AP_Primero;

            this.NB_Primero.Text = Usuario.NB_Primero;
            this.NB_Segundo.Text = Usuario.NB_Segundo;
            this.AP_Primero.Text = Usuario.AP_Primero;
            this.AP_Segundo.Text = Usuario.AP_Segundo;
            this.lblEmail.Text = Usuario.Email;
            this.Telefono.Text = Usuario.Tel_Celular;
            this.lblRol.Text = userManager.GetRoles(Usuario.Id).FirstOrDefault().ToString();

            divChkModulos.Visible = true;
            chkModulos.Enabled = true;

            if (userManager.IsInRole(Usuario.Id, "SuperAdmin") || userManager.IsInRole(Usuario.Id, "Supervisor") || userManager.IsInRole(Usuario.Id, "Estadistico"))
            {
                divChkModulos.Visible = false;
                chkModulos.Enabled = false;
            }
            else
            {
                if (userManager.IsInRole(Usuario.Id, "Registrado Administrativo"))
                {
                    for (int i = 0; i < chkModulos.Items.Count; i++)
                    {
                        chkModulos.Items[i].Selected = true;
                    }
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
                        for (int i = 0; i < chkModulos.Items.Count; i++)
                        {
                            if (chkModulos.Items[i].Value == "RegistroPerfiles")
                            {
                                chkModulos.Items[i].Selected = true;
                            }

                        }
                    }
                    if (AccesoExpedientes > 0)
                    {
                        for (int i = 0; i < chkModulos.Items.Count; i++)
                        {
                            if (chkModulos.Items[i].Value == "AccesoExpedientes")
                            {
                                chkModulos.Items[i].Selected = true;
                            }

                        }
                    }
                    if (AccesoTableros > 0)
                    {
                        for (int i = 0; i < chkModulos.Items.Count; i++)
                        {
                            if (chkModulos.Items[i].Value == "AccesoTableros")
                            {
                                chkModulos.Items[i].Selected = true;
                            }

                        }
                    }
                }
            }

            chkModulos.Enabled = false;

            profileImg.ImageUrl = "~/Content/images/profile_images/" + Usuario.ProfileImgPath;

            //if (Usuario.ProfileImgPath != null)
            //{
            //    profileImg.ImageUrl = ConfigurationManager.AppSettings["URL_Documentos"].ToString() + "UsuarioFotosPerfil/" + Usuario.Email + "/" + Usuario.ProfileImgPath;
            //}
            //else
            //{
            //    profileImg.ImageUrl = "~/Content/img/Avatar.png";
            //}

        }

        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            if (IsValid)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                IdentityResult result = manager.ChangePassword(User.Identity.GetUserId(), CurrentPassword.Text, NewPassword.Text);
                if (result.Succeeded)
                {
                    var user = manager.FindById(User.Identity.GetUserId());
                    signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);

                    mensaje = "Se actualizó su contraseña correctamente.";

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Contraseña Actualizada", "sweetAlert('Contraseña Actualizada','" + mensaje + "','success')", true);
                    //Response.Redirect("~/Account/Manage?m=ChangePwdSuccess");
                }
                else
                {
                    //AddErrors(result);
                    foreach (var error in result.Errors)
                    {
                        //ModelState.AddModelError("", error);

                        mensaje += error + "\n";
                    }

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
                    //ClientScript.RegisterStartupScript(this.GetType(), "Error ", "sweetAlertRef('Error','" + mensaje + "','error','Account/Manage.aspx');", true);

                }
            }
        }

        protected void ProfileUpdate_Click(object sender, EventArgs e)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            Usuario = (ApplicationUser)Session["Usuario"];

            string mensaje = string.Empty;

            //var user = new ApplicationUser();

            var user = userManager.FindById(Usuario.Id);

            user.UserName = Usuario.Email;
            user.Email = Usuario.Email;
            user.NB_Primero = NB_Primero.Text;
            user.NB_Segundo = NB_Segundo.Text;
            user.AP_Primero = AP_Primero.Text;
            user.AP_Segundo = AP_Segundo.Text;
            user.Tel_Celular = Telefono.Text;
            user.PasswordChanged = true;
            user.Active = true;
            user.EmailConfirmed = true;
            var newuser = userManager.Update(user);

            if (newuser.Succeeded)
            {
                mensaje = "Se actualizó su contraseña correctamente.";

                context.SaveChanges();

                Session["Usuario"] = user;

                SetUserInformation();

                //Session["Usuario"] = user;

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Cuenta Actualizada", "sweetAlert('Cuenta Actualizada','" + mensaje + "','success')", true);
            }

            else
            {

            }
        }

        protected void actualizarAvatar_Click(object sender, ImageClickEventArgs e)
        {
            var imageButton = sender as ImageButton;

            string newAvatar = imageButton.CommandArgument.ToString();

            ApplicationDbContext context = new ApplicationDbContext();

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            Usuario = (ApplicationUser)Session["Usuario"];

            string mensaje = string.Empty;

            //var user = new ApplicationUser();

            var user = userManager.FindById(Usuario.Id);

            user.ProfileImgPath = newAvatar;

            var newuser = userManager.Update(user);

            if (newuser.Succeeded)
            {
                mensaje = "Se actualizó su avatar correctamente.";

                context.SaveChanges();

                Session["Usuario"] = user;

                SetUserInformation();

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Avatar Actualizada", "sweetAlert('Avatar Actualizada','" + mensaje + "','success')", true);
            }

            else
            {

            }


        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        // Remove phonenumber from user
        protected void RemovePhone_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var result = manager.SetPhoneNumber(User.Identity.GetUserId(), null);
            if (!result.Succeeded)
            {
                return;
            }
            var user = manager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                Response.Redirect("/Account/Manage?m=RemovePhoneNumberSuccess");
            }
        }

        // DisableTwoFactorAuthentication
        protected void TwoFactorDisable_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.SetTwoFactorEnabled(User.Identity.GetUserId(), false);

            Response.Redirect("/Account/Manage");
        }

        //EnableTwoFactorAuthentication 
        protected void TwoFactorEnable_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.SetTwoFactorEnabled(User.Identity.GetUserId(), true);

            Response.Redirect("/Account/Manage");
        }
    }
}