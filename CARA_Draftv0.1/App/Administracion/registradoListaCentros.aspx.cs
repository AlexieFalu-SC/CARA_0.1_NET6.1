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
    public partial class registradoListaCentros : System.Web.UI.Page
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

            if (!this.IsPostBack)
            {
                PrepararCentrosList();
            }
        }

        private void PrepararCentrosList()
        {
            try
            {
                Usuario = (ApplicationUser)Session["Usuario"];

                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                using (CARAEntities dsCARA = new CARAEntities())
                {
                    var centros = dsCARA.VW_USUARIOS_CENTROS_LICENCIAS.Where(a => a.PK_Usuario.Equals(Usuario.Id)).DefaultIfEmpty().ToList();

                    if (centros[0] != null)
                    {
                        foreach (VW_USUARIOS_CENTROS_LICENCIAS item in centros)
                        {
                            if (item.CentroEstatus == "Activo")
                            {
                                item.CentroEstatus = "<span class='badge bg-success text-white text-wrap' style='width: 6rem;'>Activo</span>";
                            }
                            else
                            {
                                item.CentroEstatus = "<span class='badge bg-danger text-white text-wrap' style='width: 6rem;'>Inactivo</span>";
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

        public string MyNewRow(object PK_Centro)
        {
            return String.Format(@"</td></td><tr id ='tr{0}' class='collapsed-row'>
                                    <td></td><td colspan='100' style='padding:0px; margin:0px;'>", PK_Centro);
        }

        protected void gvLicenciasList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int S_id = Convert.ToInt32(gvCentrosList.DataKeys[e.Row.RowIndex].Value.ToString());

                using (CARAEntities dsCARA = new CARAEntities())
                {
                    var licenciasList = dsCARA.VW_USUARIOS_CENTROS_LICENCIAS.Where(a => a.PK_Centro == S_id).Select(i => new {i.NB_Licencia, i.NB_Categoria, i.NR_Licencia, i.FE_Expiracion, i.CentroLicenciaEstatus }).Distinct().DefaultIfEmpty().ToList();

                    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                    if (licenciasList[0] != null)
                    {
                        //foreach (var item in licenciasList)
                        //{
                        //    if (item.CentroLicenciaEstatus == "Activo")
                        //    {
                        //        item.CentroLicenciaEstatus = "<span class='badge bg-success text-white text-wrap' style='width: 6rem;'>Activo</span>";
                        //    }
                        //    else
                        //    {
                        //        item.CentroLicenciaEstatus = "<span class='badge bg-danger text-white text-wrap' style='width: 6rem;'>Inactivo</span>";
                        //    }
                        //}
                        GridView SC = (GridView)e.Row.FindControl("gvLicenciasList");
                        SC.DataSource = licenciasList;
                        SC.DataBind();
                    }

                }
            }
        }
    }
}