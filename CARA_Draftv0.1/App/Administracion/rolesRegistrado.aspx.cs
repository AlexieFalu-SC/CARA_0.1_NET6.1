﻿using CARA_Draftv0._1.Models;
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
    public partial class rolesRegistrado : System.Web.UI.Page
    {
        ApplicationDbContext context = new ApplicationDbContext();
        protected CARAEntities dsCARA;
        ApplicationUser Usuario = new ApplicationUser();
        protected string pk_rol, nb_rol, roles;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Account/Login.aspx", false);
                return;
            }

            Usuario = (ApplicationUser)Session["Usuario"];

            pk_rol = this.Request.QueryString["rol"].ToString();
            nb_rol = this.Request.QueryString["nb_rol"].ToString();
            roles = this.Request.QueryString["roles"].ToString();
            lblRol.Text = nb_rol;

            if (!this.IsPostBack)
            {
                int TotalReg = BindGridView(1, pk_rol);
                this.FillJumpToList(TotalReg);
            }
        }

        private int BindGridView(int pagina, string rol)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            int cantidad = 0;
            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    
                    List<string> rolesRegistrado = new List<string>()
                    {
                        "Registrado", "Operador de Registro", "Operador Estadistico"
                    };

                    switch (roles)
                    {
                        case ("administradores"):
                            var administradores = dsCARA.VW_USUARIOS_ADMINISTRADORES.Where(p => !rolesRegistrado.Contains(p.Roles)).ToList();

                            LitCantidadUsuarios.Text = administradores.Count.ToString();

                            gvUsuarios.PageIndex = pagina - 1;
                            gvUsuarios.DataSource = administradores;
                            gvUsuarios.DataBind();
                            cantidad = administradores.Count();
                            break;
                        case ("registrados"):
                            btnRolUsuario.Visible = false;
                            btnEliminarRol.Visible = false;

                            var registrados = dsCARA.VW_USUARIOS_ADMINISTRADORES.Where(p => p.Roles.Equals("Registrado")).ToList();

                            LitCantidadUsuarios.Text = registrados.Count.ToString();

                            gvUsuarios.PageIndex = pagina - 1;
                            gvUsuarios.DataSource = registrados;
                            gvUsuarios.DataBind();
                            cantidad = registrados.Count();
                            break;
                        case ("operadores"):
                            List<SPR_USUARIOS_REGISTRADO_Result> operadores = dsCARA.SPR_USUARIOS_REGISTRADO(Usuario.Id).Where(a => a.PK_Roles.Equals(rol)).ToList();

                            LitCantidadUsuarios.Text = operadores.Count.ToString();

                            gvUsuarios.PageIndex = pagina - 1;
                            gvUsuarios.DataSource = operadores;
                            gvUsuarios.DataBind();
                            cantidad = operadores.Count();
                            break;
                    }

                    

                   

                }
            }
            catch (Exception ex)
            {
                string mensaje;

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

        protected void gvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsuarios.PageIndex = e.NewPageIndex;

            //  BindGridView();
        }

        protected void PageNumberChanged(object sender, EventArgs e)
        {
            int PageNo = Convert.ToInt32(ddlJumpTo.SelectedItem.Value);
            this.BindGridView(PageNo,pk_rol);
        }

        private int CalculateTotalPages(int intTotalRows)
        {
            int intPageCount = 1;
            double dblPageCount = (double)(Convert.ToDecimal(intTotalRows)

                                    / Convert.ToDecimal(gvUsuarios.PageSize));

            intPageCount = Convert.ToInt32(Math.Ceiling(dblPageCount));
            return intPageCount;
        }

        protected void btnRolUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/App/Administracion/agregarRolRegistrado.aspx?rol=" + pk_rol + "&nb_rol=" + nb_rol + "&roles=" + roles);
        }

        protected void btnEliminarRol_Click(object sender, EventArgs e)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            string mensaje = string.Empty;

            foreach (GridViewRow item in gvUsuarios.Rows)
            {
                var checkbox = item.FindControl("CheckBox1") as CheckBox;
                if (checkbox.Checked)
                {
                    try
                    {
                        string PK_Usuario = gvUsuarios.DataKeys[item.RowIndex].Values[0].ToString();
                        userManager.RemoveFromRole(PK_Usuario, nb_rol);

                        mensaje = "Se eliminó correctamente el rol al usuario.";

                        ClientScript.RegisterStartupScript(this.GetType(), "Rol Eliminado", "sweetAlertRef('Rol Eliminado','" + mensaje + "','success','App/Administracion/rolesRegistrado.aspx?rol=" + pk_rol + "&nb_rol=" + nb_rol + "&roles=" + roles + "');", true);
                    }
                    catch (Exception ex)
                    {

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

        protected void lnkVolver_Click(object sender, EventArgs e)
        {
            if(roles == "administradores" || roles == "registrados")
            {
                Response.Redirect("~/App/Administracion/adminAdministrador.aspx");
            }
            else
            {
                Response.Redirect("~/App/Administracion/adminRegistrado.aspx");
            }
        }
    }
}
