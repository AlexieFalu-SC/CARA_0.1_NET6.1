using CARA_Draftv0._1.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1.App
{
    public partial class ExportarRegistradores : System.Web.UI.Page
    {
        ApplicationDbContext context = new ApplicationDbContext();
        ApplicationUser Usuario = new ApplicationUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetPerfiles();
            }
        }

        private void GetPerfiles()
        {
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            Usuario = (ApplicationUser)Session["Usuario"];

            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    var centrosMap = dsCARA.CA_USUARIO_CENTRO.Where(a => a.FK_Usuario.Equals(Usuario.Id)).Select(f => f.FK_Centro).DefaultIfEmpty();
                    var centros = dsCARA.CA_CENTRO.Where(u => centrosMap.Contains(u.PK_Centro)).Select(f => f.PK_Centro).DefaultIfEmpty().ToList();


                    var perfilesList = dsCARA.VW_DSH_PERFILES.Where(c => centros.Contains(c.FK_Centro)).DefaultIfEmpty().ToList();

                    if (perfilesList[0] != null)
                    {
                        gvPerfilesList.DataSource = perfilesList;

                        gvPerfilesList.DataBind();

                        gvPerfilesList.UseAccessibleHeader = true;
                        gvPerfilesList.HeaderRow.TableSection = TableRowSection.TableHeader;
                        gvPerfilesList.FooterRow.TableSection = TableRowSection.TableFooter;
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void ExportToExcel(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=MisPerfiles.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                gvPerfilesList.AllowPaging = false;
                //this.BindGrid();

                gvPerfilesList.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gvPerfilesList.HeaderRow.Cells)
                {
                    cell.BackColor = gvPerfilesList.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gvPerfilesList.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvPerfilesList.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvPerfilesList.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gvPerfilesList.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
    }
}