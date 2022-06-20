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
    public partial class adminEdicionUsuarioExterno : System.Web.UI.Page
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
                SetUserInformation(pk_usuario);
                PrepararCentrosList();
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
            this.lblRol.Text = userManager.GetRoles(user.Id).FirstOrDefault().ToString();

            if (userManager.IsInRole(user.Id, "Registrado Usuario"))
            {
                var cla = user.Claims.ToList();

                var RegistroPerfiles = cla.Where(x => x.ClaimValue == "RegistroPerfiles").Count();
                var AccesoExpedientes = cla.Where(x => x.ClaimValue == "AccesoExpedientes").Count();
                var AccesoTableros = cla.Where(x => x.ClaimValue == "AccesoTableros").Count();

                if(RegistroPerfiles > 0)
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

        private void PrepararCentrosList()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user = userManager.FindById(pk_usuario);

            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    var centros = dsCARA.VW_CENTROS_ADMINISTRADORES.Where(a => a.Email == user.Email).DefaultIfEmpty().ToList();

                    if (centros[0] != null)
                    {
                        foreach (VW_CENTROS_ADMINISTRADORES item in centros)
                        {
                            if (item.Estatus == "Activo")
                            {
                                item.Estatus = "<span class='badge bg-success text-white text-wrap' style='width: 6rem;'>Activo</span>";
                            }
                            else
                            {
                                item.Estatus = "<span class='badge bg-danger text-white text-wrap' style='width: 6rem;'>Inactivo</span>";
                            }
                        }
                    }

                    gvCentrosList.DataSource = centros;

                    gvCentrosList.DataBind();

                    gvCentrosList.UseAccessibleHeader = true;
                    gvCentrosList.HeaderRow.TableSection = TableRowSection.TableHeader;
                    gvCentrosList.FooterRow.TableSection = TableRowSection.TableFooter;
                }

            }
            catch (Exception ex)
            {
                string mensaje = string.Empty;
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
            user.PasswordChanged = user.PasswordChanged;
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