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
    public partial class adminAdministrador : System.Web.UI.Page
    {
        ApplicationDbContext context = new ApplicationDbContext();
        protected CARAEntities dsCARA;
        ApplicationUser Usuario = new ApplicationUser();
        string PK_Sesion;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Usuario"] == null || Session["PK_Sesion"] == null)
            {
                Response.Redirect("~/Account/Login.aspx", false);
                return;
            }

            PK_Sesion = Session["PK_Sesion"].ToString();
            Usuario = (ApplicationUser)Session["Usuario"];

            if (!this.IsPostBack)
            {
                int TotalReg = BindGridView(1);
                this.FillJumpToList(TotalReg);

                int TotalRegistrados = BindGvRegistrados(1);
                this.FillJumpToListRegistrados(TotalRegistrados);

                int TotalCentros = BindGvCentros(1);
                this.FillJumpToListCentros(TotalCentros);

                int TotalRoles = BindGvRoles(1);
                this.FillJumpToListRoles(TotalRoles);

                int TotalRolesRegistrados = BindGvRolesRegistrados(1);
                this.FillJumpToListRolesRegistrados(TotalRolesRegistrados);
            }
        }

        private int BindGridView(int pagina)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            int cantidad = 0;

            List<string> rolesRegistrado = new List<string>()
            {
                "Registrado", "Operador de Registro", "Operador Estadistico"
            };

            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    var usuarios = dsCARA.VW_USUARIOS_ADMINISTRADORES.Where(p => !rolesRegistrado.Contains(p.Roles)).ToList();
                    
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

        private int BindGvRegistrados(int pagina)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            int cantidad = 0;

            List<string> rolesRegistrado = new List<string>()
            {
                "Registrado", "Operador de Registro", "Operador Estadistico"
            };

            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    var usuarios = dsCARA.VW_USUARIOS_ADMINISTRADORES.Where(p => rolesRegistrado.Contains(p.Roles)).ToList();

                    LitCantidadRegistrados.Text = usuarios.Count.ToString();

                    gvUsuariosRegistrados.PageIndex = pagina - 1;
                    gvUsuariosRegistrados.DataSource = usuarios;
                    gvUsuariosRegistrados.DataBind();
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
                    var centros = dsCARA.VW_CENTROS_ADMINISTRADORES.ToList();

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
                    List<string> rolesRegistrado = new List<string>()
                    {
                        "Registrado", "Operador de Registro", "Operador Estadistico"
                    };

                    var roles = dsCARA.VW_ROLES_ADMINISTRADORES.Where(a => !rolesRegistrado.Contains(a.Nombre)).ToList();

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

        private int BindGvRolesRegistrados(int pagina)
        {
            int cantidad = 0;

            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    List<string> rolesRegistrado = new List<string>()
                    {
                        "Registrado", "Operador de Registro", "Operador Estadistico"
                    };

                    var roles = dsCARA.VW_ROLES_ADMINISTRADORES.Where(a => rolesRegistrado.Contains(a.Nombre)).ToList();

                    LitCantidadRoles.Text = roles.Count.ToString();

                    gvRolesRegistrados.PageIndex = pagina - 1;
                    gvRolesRegistrados.DataSource = roles;
                    gvRolesRegistrados.DataBind();
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

        private void FillJumpToListRegistrados(int TotalRows)
        {
            int PageCount = this.CalculateTotalPagesRegistrados(TotalRows);
            for (int i = 1; i <= PageCount; i++)
            {
                ddlJumpToRegistrados.Items.Add(new ListItem(i.ToString(), i.ToString()));
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

        private void FillJumpToListRolesRegistrados(int TotalRows)
        {
            int PageCount = this.CalculateTotalPagesRolesRegistrados(TotalRows);
            for (int i = 1; i <= PageCount; i++)
            {
                ddlJumpRolesRegistrados.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        protected void gvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsuarios.PageIndex = e.NewPageIndex;

            //  BindGridView();
        }

        protected void gvUsuariosRegistrados_PageIndexChanging(object sender, GridViewPageEventArgs e)
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

        protected void gvRolesRegistrados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRolesRegistrados.PageIndex = e.NewPageIndex;

            //  BindGridView();
        }

        protected void PageNumberChanged(object sender, EventArgs e)
        {
            int PageNo = Convert.ToInt32(ddlJumpTo.SelectedItem.Value);
            this.BindGridView(PageNo);
        }

        protected void PageNumberChangedRegistrados(object sender, EventArgs e)
        {
            int PageNo = Convert.ToInt32(ddlJumpToRegistrados.SelectedItem.Value);
            this.BindGvRegistrados(PageNo);
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

        protected void PaginaCambiaRolesRegistrados(object sender, EventArgs e)
        {
            int PageNo = Convert.ToInt32(ddlJumpRolesRegistrados.SelectedItem.Value);
            this.BindGvRolesRegistrados(PageNo);
        }

        private int CalculateTotalPages(int intTotalRows)
        {
            int intPageCount = 1;
            double dblPageCount = (double)(Convert.ToDecimal(intTotalRows)

                                    / Convert.ToDecimal(gvUsuarios.PageSize));

            intPageCount = Convert.ToInt32(Math.Ceiling(dblPageCount));
            return intPageCount;
        }

        private int CalculateTotalPagesRegistrados(int intTotalRows)
        {
            int intPageCount = 1;
            double dblPageCount = (double)(Convert.ToDecimal(intTotalRows)

                                    / Convert.ToDecimal(gvUsuariosRegistrados.PageSize));

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

        private int CalculateTotalPagesRolesRegistrados(int intTotalRows)
        {
            int intPageCount = 1;
            double dblPageCount = (double)(Convert.ToDecimal(intTotalRows)

                                    / Convert.ToDecimal(gvRolesRegistrados.PageSize));

            intPageCount = Convert.ToInt32(Math.Ceiling(dblPageCount));
            return intPageCount;
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        #region Bottones
        protected void lnkRol_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string valores = btn.CommandArgument;
            string PK_Rol = valores.Split(',')[0];
            string NB_Rol = valores.Split(',')[1];


            Response.Redirect("~/App/Administracion/rolesRegistrado.aspx?rol=" + PK_Rol + "&nb_rol=" + NB_Rol + "&roles=administradores");

        }

        protected void lnkRolRegistrado_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string valores = btn.CommandArgument;
            string PK_Rol = valores.Split(',')[0];
            string NB_Rol = valores.Split(',')[1];


            Response.Redirect("~/App/Administracion/rolesRegistrado.aspx?rol=" + PK_Rol + "&nb_rol=" + NB_Rol + "&roles=registrados");

        }

        #endregion
    }
}