using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using CARA_Draftv0._1.Models;

namespace CARA_Draftv0._1.Account
{
    public partial class ResetPassword : Page
    {
        protected string StatusMessage
        {
            get;
            private set;
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            string code = IdentityHelper.GetCodeFromRequest(Request);
            if (code != null)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

                var user = manager.FindByName(Email.Text);
                if (user == null)
                {
                    ErrorMessage.Text = "No se encontró un usuario";
                    return;
                }
                var result = manager.ResetPassword(user.Id, code, Password.Text);
                if (result.Succeeded)
                {
                    Response.Redirect("~/Account/ResetPasswordConfirmation");
                    return;
                }
                ErrorMessage.Text = result.Errors.FirstOrDefault();
                return;
            }
            else if (Session["Usuario"] != null)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

                var user = manager.FindByName(Email.Text);
                if (user == null)
                {
                    ErrorMessage.Text = "No se encontró un usuario";
                    return;
                }
                code = manager.GeneratePasswordResetToken(user.Id);
                var result = manager.ResetPassword(user.Id, code, Password.Text);

                if (result.Succeeded)
                {
                    if (!user.PasswordChanged)
                    {
                        user.PasswordChanged = true;
                        var update = manager.Update(user);
                        if (update.Succeeded)
                        {
                            Response.Redirect("~/Account/ResetPasswordConfirmation");
                            return;
                        }
                    }
                }
                ErrorMessage.Text = result.Errors.FirstOrDefault();
                return;
            }

            ErrorMessage.Text = "An error has occurred";
        }
    }
}