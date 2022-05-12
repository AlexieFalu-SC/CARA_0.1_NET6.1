using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using CARA_Draftv0._1.Models;
using System.Linq;

namespace CARA_Draftv0._1.Account
{
    public partial class Confirm : Page
    {
        protected string StatusMessage
        {
            get;
            private set;
        } 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string code = IdentityHelper.GetCodeFromRequest(Request);
                string userId = IdentityHelper.GetUserIdFromRequest(Request);
                string mensaje = string.Empty;

                if (code != null && userId != null)
                {
                    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

                    var result = manager.ConfirmEmail(userId, code);
                    if (result.Succeeded)
                    {
                        var user = manager.FindById(userId);

                        if(!user.PasswordChanged)
                        {
                            successPanel.Visible = true;
                            return;
                        }
                        else
                        {
                            mensaje = "Su cuenta ya fué anteriormente confirmada y usted ya creó una contraseña de usuario.";

                            ClientScript.RegisterStartupScript(this.GetType(), "Cuenta confirmada y con contraseña", "sweetAlertRef('Cuenta confirmada y con contraseña','" + mensaje + "','success','" + "Account/Login.aspx" + "');", true);
                        }

                    }
                    else
                    {
                        ErrorMessage.Text = result.Errors.FirstOrDefault();
                        successPanel.Visible = false;
                        errorPanel.Visible = true;
                    }
                }
                else
                {
                    ErrorMessage.Text = "Ocurrió un error al intentar acceder a esta página.";
                    successPanel.Visible = false;
                    errorPanel.Visible = true;
                }
                
            }
            
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            string code = IdentityHelper.GetCodeFromRequest(Request);
            string userId = IdentityHelper.GetUserIdFromRequest(Request);
            string mensaje = string.Empty;

            if (code != null && userId != null)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var result = manager.AddPassword(userId, NewPassword.Text);
                if(result.Succeeded)
                {
                    var user = manager.FindById(userId);
                    user.PasswordChanged = true;
                    var update = manager.Update(user);
                    if (update.Succeeded)
                    {
                        mensaje = "Se actualizó su contraseña correctamente.";

                        ClientScript.RegisterStartupScript(this.GetType(), "Contraseña Creada", "sweetAlertRef('Contraseña Creada','" + mensaje + "','success','" + "Account/Login.aspx" + "');", true);
                        //Response.Redirect("~/Account/Manage?m=ChangePwdSuccess");
                    }
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