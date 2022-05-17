using CARA_Draftv0._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1.App.Administracion
{
    public partial class adminListaCentros : System.Web.UI.Page
    {
        ApplicationDbContext context = new ApplicationDbContext();
        ApplicationUser Usuario = new ApplicationUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                PrepararCentrosList();
            }
        }

        private void PrepararCentrosList()
        {
            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    var centros = dsCARA.VW_CENTROS_ADMINISTRADORES.ToList();

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
    }
}