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
    public partial class ExportarAdministradores : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                PrepararDropDownLists();
            }
        }

        private void PrepararDropDownLists()
        {
            Usuario = (ApplicationUser)Session["Usuario"];

            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    var centrosMap = dsCARA.CA_USUARIO_CENTRO.Where(a => a.FK_Usuario.Equals(Usuario.Id)).Select(f => f.FK_Centro).DefaultIfEmpty();
                    var centros = dsCARA.CA_CENTRO.Where(u => centrosMap.Contains(u.PK_Centro)).DefaultIfEmpty().ToList();

                    lbxCentro.DataValueField = "PK_Centro";
                    lbxCentro.DataTextField = "NB_Centro";
                    lbxCentro.DataSource = dsCARA.CA_CENTRO.ToList();
                    lbxCentro.DataBind();

                    lbxReferido.DataValueField = "PK_FuenteReferido";
                    lbxReferido.DataTextField = "DE_FuenteReferido";
                    lbxReferido.DataSource = dsCARA.CA_LKP_FUENTE_REFERIDO.ToList();
                    lbxReferido.DataBind();

                    lbxMunicipios.DataValueField = "PK_Municipio";
                    lbxMunicipios.DataTextField = "DE_Municipio";
                    lbxMunicipios.DataSource = dsCARA.CA_LKP_MUNICIPIO.ToList();
                    lbxMunicipios.DataBind();

                    this.txtFechaDesde.Text = DateTime.Today.AddMonths(-6).ToString("yyyy-MM-dd");
                    this.txtFechaHasta.Text = DateTime.Today.ToString("yyyy-MM-dd");
                }

                GetPerfiles();

            }
            catch (Exception)
            {

                throw;
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


                    List<int> listCentros = new List<int>();
                    List<int> listReferido = new List<int>();
                    List<int> listMunicipios = new List<int>();
                    DateTime Desde = DateTime.Parse(this.txtFechaDesde.Text);
                    DateTime Hasta = DateTime.Parse(this.txtFechaHasta.Text);

                    for (int i = 0; i < lbxCentro.Items.Count; i++)
                    {
                        if (lbxCentro.Items[i].Selected)
                        {
                            listCentros.Add(Int32.Parse(lbxCentro.Items[i].Value));
                        }
                    }

                    for (int i = 0; i < lbxReferido.Items.Count; i++)
                    {
                        if (lbxReferido.Items[i].Selected)
                        {
                            listReferido.Add(Int32.Parse(lbxReferido.Items[i].Value));
                        }
                    }

                    for (int i = 0; i < lbxMunicipios.Items.Count; i++)
                    {
                        if (lbxMunicipios.Items[i].Selected)
                        {
                            listMunicipios.Add(Int32.Parse(lbxMunicipios.Items[i].Value));
                        }
                    }

                    var perfilesList = dsCARA.VW_DSH_PERFILES.Where(e => e.Fecha_Admisión >= Desde && e.Fecha_Admisión <= Hasta).Where(c => listCentros.Contains(c.FK_Centro)).DefaultIfEmpty().ToList();

                    if (perfilesList[0] != null)
                    {
                        gvPerfilesList.DataSource = perfilesList;

                        gvPerfilesList.DataBind();

                        gvPerfilesList.UseAccessibleHeader = true;
                        gvPerfilesList.HeaderRow.TableSection = TableRowSection.TableHeader;
                        gvPerfilesList.FooterRow.TableSection = TableRowSection.TableFooter;
                    }
                    else
                    {
                        gvPerfilesList.DataSource = null;

                        gvPerfilesList.DataBind();
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void UpdatePerfiles(object sender, EventArgs e)
        {
            GetPerfiles();
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
                //foreach (TableCell cell in gvPerfilesList.HeaderRow.Cells)
                //{
                //    cell.BackColor = gvPerfilesList.HeaderStyle.BackColor;
                //}
                //foreach (GridViewRow row in gvPerfilesList.Rows)
                //{
                //    row.BackColor = Color.White;
                //    foreach (TableCell cell in row.Cells)
                //    {
                //        if (row.RowIndex % 2 == 0)
                //        {
                //            cell.BackColor = gvPerfilesList.AlternatingRowStyle.BackColor;
                //        }
                //        else
                //        {
                //            cell.BackColor = gvPerfilesList.RowStyle.BackColor;
                //        }
                //        cell.CssClass = "textmode";
                //    }
                //}

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