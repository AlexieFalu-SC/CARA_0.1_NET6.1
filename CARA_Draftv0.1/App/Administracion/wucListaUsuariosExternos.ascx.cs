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
    public partial class wucListaUsuariosExternos : System.Web.UI.UserControl
    {
        ApplicationDbContext context = new ApplicationDbContext();
        ApplicationUser Usuario = new ApplicationUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                PrepararPrincipalUsersList();
            }
        }

        private void PrepararPrincipalUsersList()
        {
            try
            {
                Usuario = (ApplicationUser)Session["Usuario"];

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                List<string> rolesRegistrado = new List<string>()
                {
                    "Registrado Administrativo"
                };

                using (CARAEntities dsCARA = new CARAEntities())
                {
                    var usersList = dsCARA.VW_LISTA_USUARIOS_REGISTRADOS.Where(a => a.PK_Usuario != Usuario.Id).Where(p => rolesRegistrado.Contains(p.Rol)).DefaultIfEmpty().ToList();

                    if (usersList[0] != null)
                    {
                        foreach (VW_LISTA_USUARIOS_REGISTRADOS item in usersList)
                        {
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
                                item.Accesos += "<span class='badge bg-success text-white text-wrap' style='width: 6rem;'>Tableros y Datos</span>&nbsp";
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

                    gvUsuariosExternosList.DataSource = usersList;

                    gvUsuariosExternosList.DataBind();

                    gvUsuariosExternosList.UseAccessibleHeader = true;
                    gvUsuariosExternosList.HeaderRow.TableSection = TableRowSection.TableHeader;
                    gvUsuariosExternosList.FooterRow.TableSection = TableRowSection.TableFooter;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void gvUsuariosSecList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string S_id = gvUsuariosExternosList.DataKeys[e.Row.RowIndex].Value.ToString();

                using (CARAEntities dsCARA = new CARAEntities())
                {
                    var usersList = dsCARA.VW_LISTA_USUARIOS_REGISTRADOS.Where(a => a.PK_Usuario != S_id).Where(p => p.Cuenta_Princiapal == S_id).DefaultIfEmpty().ToList();

                    if (usersList[0] != null)
                    {
                        foreach (VW_LISTA_USUARIOS_REGISTRADOS item in usersList)
                        {
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
                                item.Accesos += "<span class='badge bg-success text-white text-wrap' style='width: 6rem;'>Tableros y Datos</span>&nbsp";
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
                        GridView SC = (GridView)e.Row.FindControl("gvUsuariosSecList");
                        SC.DataSource = usersList;
                        SC.DataBind();
                    }


                    
                }
            }
        }
    }
}