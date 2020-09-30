using CARA_Draftv0._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1.App.Administracion
{
    public partial class agregarCentro : System.Web.UI.Page
    {
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
                try
                {
                    using (CARAEntities dsCARA = new CARAEntities())
                    {
                        List<ListItem> registrados = dsCARA.VW_USUARIOS_ADMINISTRADORES.Where(p => p.Roles.Equals("Registrado")).Select(r => new ListItem { Value = r.Email, Text = r.Nombre + " " + r.Email }).ToList();

                        ddlEmail.DataValueField = "Value";
                        ddlEmail.DataTextField = "Text";
                        ddlEmail.DataSource = registrados;
                        ddlEmail.DataBind();
                        ddlEmail.Items.Insert(0, new ListItem("", "0"));
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
            }
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            string NB_Centro = txtNB_Centro.Text;
            Guid ID_SLYC = Guid.Parse(txtSLYC.Text);
            string ID_Proveedor = txtProveedor.Text;
            string Email = ddlEmail.SelectedValue;

            string mensaje = string.Empty;

            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    dsCARA.SPC_CENTRO(NB_Centro, ID_SLYC, ID_Proveedor, Email);

                    mensaje = "El registro del centro fué correcto.";

                    ClientScript.RegisterStartupScript(this.GetType(), "Centro Registrado", "sweetAlertRef('Centro Registrado','" + mensaje + "','success','App/Administracion/adminAdministrador.aspx');", true);
                }
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