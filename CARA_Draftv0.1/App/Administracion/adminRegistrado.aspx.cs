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
    public partial class adminRegistrado : System.Web.UI.Page
    {
        ApplicationDbContext context = new ApplicationDbContext();
        protected CARAEntities dsCARA;
        ApplicationUser Usuario = new ApplicationUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Account/Login.aspx", false);
                return;
            }

            Usuario = (ApplicationUser)Session["Usuario"];

            if (!this.IsPostBack)
            {
                int TotalReg = BindGridView(1);
                this.FillJumpToList(TotalReg);

                int TotalCentros = BindGvCentros(1);
                this.FillJumpToListCentros(TotalCentros);

                int TotalRoles = BindGvRoles(1);
                this.FillJumpToListRoles(TotalRoles);
            }
        }

        private int BindGridView(int pagina)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            int cantidad = 0;
            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    List<SPR_USUARIOS_REGISTRADO_Result> usuarios = dsCARA.SPR_USUARIOS_REGISTRADO(Usuario.Id).ToList();

                    LitCantidadUsuarios.Text = usuarios.Count.ToString();

                    gvUsuarios.PageIndex = pagina - 1;
                    gvUsuarios.DataSource = usuarios;
                    gvUsuarios.DataBind();
                    cantidad = usuarios.Count();

                }
            }
            catch (Exception ex)
            {

                string mensaje = ex.InnerException.Message;
            }

            return cantidad;
        }

        private int BindGvCentros(int pagina)
        {
            int cantidad = 0;

            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    var usuarioCentros = dsCARA.CA_USUARIO_CENTRO.Where(a => a.FK_Usuario.Equals(Usuario.Id)).Select(b => b.FK_Centro).ToList();

                    var centros = dsCARA.CA_CENTRO.Where(a => usuarioCentros.Contains(a.PK_Centro)).ToList();

                    LitCantidadCentros.Text = centros.Count.ToString();

                    gvCentros.PageIndex = pagina - 1;
                    gvCentros.DataSource = centros;
                    gvCentros.DataBind();
                    cantidad = centros.Count();

                }
            }
            catch (Exception ex)
            {

                string mensaje = ex.InnerException.Message;
            }

            return cantidad;
        }

        private int BindGvRoles(int pagina)
        {
            int cantidad = 0;

            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    List<SPR_ROLES_REGISTRADO_Result> roles = dsCARA.SPR_ROLES_REGISTRADO(Usuario.Id).DefaultIfEmpty().ToList();

                    LitCantidadRoles.Text = roles.Count.ToString();

                    gvRoles.PageIndex = pagina - 1;
                    gvRoles.DataSource = roles;
                    gvRoles.DataBind();
                    cantidad = roles.Count();

                }
            }
            catch (Exception ex)
            {

                string mensaje = ex.InnerException.Message;
            }

            return cantidad;
        }

        private void FillJumpToList(int TotalRows)
        {
            int PageCount = this.CalculateTotalPages(TotalRows);
            for (int i = 1; i <= PageCount; i++)
            {
                ddlJumpTo.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        private void FillJumpToListCentros(int TotalRows)
        {
            int PageCount = this.CalculateTotalPagesCentros(TotalRows);
            for (int i = 1; i <= PageCount; i++)
            {
                ddlJumpCentros.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        private void FillJumpToListRoles(int TotalRows)
        {
            int PageCount = this.CalculateTotalPagesRoles(TotalRows);
            for (int i = 1; i <= PageCount; i++)
            {
                ddlJumpRoles.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        protected void gvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsuarios.PageIndex = e.NewPageIndex;

            //  BindGridView();
        }

        protected void gvCentros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCentros.PageIndex = e.NewPageIndex;

            //  BindGridView();
        }

        protected void gvRoles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRoles.PageIndex = e.NewPageIndex;

            //  BindGridView();
        }

        protected void PageNumberChanged(object sender, EventArgs e)
        {
            int PageNo = Convert.ToInt32(ddlJumpTo.SelectedItem.Value);
            this.BindGridView(PageNo);
        }

        protected void PaginaCambiaCentros(object sender, EventArgs e)
        {
            int PageNo = Convert.ToInt32(ddlJumpCentros.SelectedItem.Value);
            this.BindGvCentros(PageNo);
        }

        protected void PaginaCambiaRoles(object sender, EventArgs e)
        {
            int PageNo = Convert.ToInt32(ddlJumpRoles.SelectedItem.Value);
            this.BindGvRoles(PageNo);
        }

        private int CalculateTotalPages(int intTotalRows)
        {
            int intPageCount = 1;
            double dblPageCount = (double)(Convert.ToDecimal(intTotalRows)

                                    / Convert.ToDecimal(gvUsuarios.PageSize));

            intPageCount = Convert.ToInt32(Math.Ceiling(dblPageCount));
            return intPageCount;
        }

        private int CalculateTotalPagesCentros(int intTotalRows)
        {
            int intPageCount = 1;
            double dblPageCount = (double)(Convert.ToDecimal(intTotalRows)

                                    / Convert.ToDecimal(gvCentros.PageSize));

            intPageCount = Convert.ToInt32(Math.Ceiling(dblPageCount));
            return intPageCount;
        }

        private int CalculateTotalPagesRoles(int intTotalRows)
        {
            int intPageCount = 1;
            double dblPageCount = (double)(Convert.ToDecimal(intTotalRows)

                                    / Convert.ToDecimal(gvRoles.PageSize));

            intPageCount = Convert.ToInt32(Math.Ceiling(dblPageCount));
            return intPageCount;
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        protected void lnkRol_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string valores = btn.CommandArgument;
            string PK_Rol = valores.Split(',')[0];
            string NB_Rol = valores.Split(',')[1];


            Response.Redirect("~/App/Administracion/rolesRegistrado.aspx?rol=" + PK_Rol + "&nb_rol=" + NB_Rol + "&roles=operadores");
            
        }
    }
}