using CARA_Draftv0._1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1.App.Administracion
{
    public partial class adminEdicionUsuarioInterno : System.Web.UI.Page
    {
        ApplicationDbContext context = new ApplicationDbContext();
        ApplicationUser Usuario = new ApplicationUser();
        protected string PK_Sesion, pk_usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            pk_usuario = this.Request.QueryString["pk_usuario"].ToString();
            Usuario = (ApplicationUser)Session["Usuario"];

            if (!this.IsPostBack)
            {
                PrepararDropDownLists();
                SetUserInformation(pk_usuario);
            }
        }

        private void PrepararDropDownLists()
        {
            Usuario = (ApplicationUser)Session["Usuario"];

            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    List<string> rolesInternos = new List<string>()
                    {
                        "Supervisor", "Estadistico"
                    };

                    var centrosMap = dsCARA.CA_USUARIO_CENTRO.Where(a => a.FK_Usuario.Equals(Usuario.Id)).Select(f => f.FK_Centro).DefaultIfEmpty();
                    var facilidades = dsCARA.CA_CENTRO.Where(u => centrosMap.Contains(u.PK_Centro)).DefaultIfEmpty().ToList();

                    var roles = context.Roles.Where(p => rolesInternos.Contains(p.Name)).Select(r => new ListItem { Value = r.Name, Text = r.Name }).ToList();

                    ddlRol.DataValueField = "Value";
                    ddlRol.DataTextField = "Text";
                    ddlRol.DataSource = roles;
                    ddlRol.DataBind();
                    //ddlRol.Items.Insert(0, new ListItem("", "0"));

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

        private void SetUserInformation(string pk_usuario)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user = userManager.FindById(pk_usuario);

            var rol = userManager.GetRoles(pk_usuario).FirstOrDefault().ToString();

            this.lblEmail.Text = user.Email;
            this.Telefono.Text = user.Tel_Celular;
            this.NB_Primero.Text = user.NB_Primero;
            this.NB_Segundo.Text = user.NB_Segundo;
            this.AP_Primero.Text = user.AP_Primero;
            this.AP_Segundo.Text = user.AP_Segundo;
            this.ddlRol.SelectedValue = rol;

            


        }

        protected void ProfileUpdate_Click(object sender, EventArgs e)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            Usuario = (ApplicationUser)Session["Usuario"];

            string mensaje = string.Empty;

            //var user = new ApplicationUser();

            var user = userManager.FindById(pk_usuario);

            user.UserName = user.UserName;
            user.Email = user.Email;
            user.NB_Primero = NB_Primero.Text;
            user.NB_Segundo = NB_Segundo.Text;
            user.AP_Primero = AP_Primero.Text;
            user.AP_Segundo = AP_Segundo.Text;
            user.Tel_Celular = Telefono.Text;
            user.PasswordChanged = true;
            user.Active = user.Active;
            user.EmailConfirmed = user.EmailConfirmed;
            var newuser = userManager.Update(user);

            if (newuser.Succeeded)
            {
                mensaje = "Se actualizó la información del usuario correctamente.";

                context.SaveChanges();

                //Session["Usuario"] = user;

                SetUserInformation(pk_usuario);

                //Session["Usuario"] = user;

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Cuenta Actualizada", "sweetAlert('Cuenta Actualizada','" + mensaje + "','success')", true);
            }

            else
            {

            }
        }

        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            if (IsValid)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                //IdentityResult result = manager.ChangePassword(User.Identity.GetUserId(),
                //                                               CurrentPassword.Text,
                //                                               NewPassword.Text);

                manager.RemovePassword(pk_usuario);
                IdentityResult result = manager.AddPassword(pk_usuario, NewPassword.Text);
                if (result.Succeeded)
                {

                    mensaje = "Se actualizó la contraseña correctamente.";

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
    }
}