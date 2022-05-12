using CARA_Draftv0._1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1.App.Administracion
{
    public partial class registradoListaUsuarios : System.Web.UI.Page
    {
        ApplicationDbContext context = new ApplicationDbContext();
        ApplicationUser Usuario = new ApplicationUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                PrepararUsersList();
            }
        }

        private void PrepararUsersList()
        {
            try
            {
                Usuario = (ApplicationUser)Session["Usuario"];

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                List<string> rolesRegistrado = new List<string>()
                {
                    "Registrado Administrativo", "Registrado Usuario"
                };

                using (CARAEntities dsCARA = new CARAEntities())
                {
                    var usersList = dsCARA.VW_LISTA_USUARIOS_REGISTRADOS.Where(a => a.PK_Usuario != Usuario.Id).Where(p => p.Cuenta_Princiapal == Usuario.Id).DefaultIfEmpty().ToList();

                    if (usersList[0] != null)
                    {
                        foreach (VW_LISTA_USUARIOS_REGISTRADOS item in usersList)
                        {
                            ApplicationUser user = context.Users.Find(item.PK_Usuario);

                            if (item.Rol == "SuperAdmin")
                            {
                                item.Accesos += "<span class='badge bg-warning text-white text-wrap' style='width: 6rem;'>Acceso Total</span>";
                            }
                            else if (item.Rol == "Supervisor")
                            {
                                item.Accesos += "<span class='badge bg-primary text-white text-wrap'>Ver Expedientes</span>&nbsp";
                                item.Accesos += "<span class='badge bg-success text-white text-wrap' style='width: 6rem;'>Tableros y Datos</span>&nbsp";
                            }
                            else
                            {
                                var cla = user.Claims.ToList();
                                // var claims = userManager.GetClaimsAsync(item.PK_Usuario);

                                var RegistroPerfiles = cla.Where(x => x.ClaimValue == "RegistroPerfiles").Count();
                                var AccesoExpedientes = cla.Where(x => x.ClaimValue == "AccesoExpedientes").Count();
                                var AccesoTableros = cla.Where(x => x.ClaimValue == "AccesoTableros").Count();

                                if (RegistroPerfiles > 0)
                                {
                                    item.Accesos += "<h5><span class='badge bg-primary text-white text-wrap' style='width: 6rem;'>Registro de Perfiles</span></h5>&nbsp";
                                }
                                if (AccesoExpedientes > 0)
                                {
                                    item.Accesos += "<span class='badge bg-success text-white text-wrap' style='width: 6rem;'>Ver Expedientes</span>&nbsp";
                                }
                                if (AccesoTableros > 0)
                                {
                                    item.Accesos += "<span class='badge bg-info text-white text-wrap' style='width: 6rem;'>Tableros y Datos</span>&nbsp";
                                }
                            }

                            if (item.Confirmado == "Confirmada")
                            {
                                item.Confirmado = "<span class='badge bg-success text-white text-wrap' style='width: 6rem;'>SI</span>";
                            }
                            else
                            {
                                item.Confirmado = "<span class='badge bg-danger text-white text-wrap' style='width: 6rem;'>NO</span>";
                            }

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

                    gvUsuariosRegistradosList.DataSource = usersList;

                    gvUsuariosRegistradosList.DataBind();

                    gvUsuariosRegistradosList.UseAccessibleHeader = true;
                    gvUsuariosRegistradosList.HeaderRow.TableSection = TableRowSection.TableHeader;
                    gvUsuariosRegistradosList.FooterRow.TableSection = TableRowSection.TableFooter;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}