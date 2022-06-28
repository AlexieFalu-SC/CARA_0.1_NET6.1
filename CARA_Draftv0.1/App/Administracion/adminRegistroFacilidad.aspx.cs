using CARA_Draftv0._1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1.App.Administracion
{
    public partial class adminRegistroFacilidad : System.Web.UI.Page
    {
        ApplicationDbContext context = new ApplicationDbContext();
        ApplicationUser Usuario = new ApplicationUser();
        protected string PK_Sesion;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PrepararDropDownLists();
                PrepararGridView();
            }
        }

        private void PrepararGridView()
        {
            Usuario = (ApplicationUser)Session["Usuario"];

            List<string> rolesRegistrado = new List<string>()
            {
                "Registrado Administrativo"
            };

            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {

                    var usersList = dsCARA.VW_LISTA_USUARIOS_REGISTRADOS.Where(a => a.PK_Usuario != Usuario.Id).Where(p => rolesRegistrado.Contains(p.Rol)).DefaultIfEmpty().ToList();

                    gvUsuariosASSMCAList.DataSource = usersList;

                    gvUsuariosASSMCAList.DataBind();

                    gvUsuariosASSMCAList.UseAccessibleHeader = true;
                    gvUsuariosASSMCAList.HeaderRow.TableSection = TableRowSection.TableHeader;
                    gvUsuariosASSMCAList.FooterRow.TableSection = TableRowSection.TableFooter;

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

        private void PrepararDropDownLists()
        {
            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {

                    var licencias = dsCARA.CA_LICENCIA.Select(r => new ListItem { Value = r.PK_Licencia.ToString(), Text = r.NB_Licencia }).ToList();

                    ddlLicencia.DataValueField = "Value";
                    ddlLicencia.DataTextField = "Text";
                    ddlLicencia.DataSource = licencias;
                    ddlLicencia.DataBind();
                    ddlLicencia.Items.Insert(0, new ListItem("", "0"));

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

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            PK_Sesion = Session["PK_Sesion"].ToString();
            Usuario = (ApplicationUser)Session["Usuario"];

            string mensaje = string.Empty;

            Guid idSlyc = Guid.NewGuid();

            string email = string.Empty;

            for (int i = 0; i < gvUsuariosASSMCAList.Rows.Count; i++)
            {
                CheckBox chkrow = (CheckBox)gvUsuariosASSMCAList.Rows[i].Cells[0].FindControl("chkRegistrado");

                if (chkrow.Checked)
                {
                    email = gvUsuariosASSMCAList.Rows[i].Cells[2].Text;
                }

            }

            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    int centroExiste = dsCARA.VW_CENTROS_ADMINISTRADORES.Where(a => a.Email == email).Where(b => b.Centro == txtCentro.Text).Select(f => f.PK_Centro).FirstOrDefault();

                    if(centroExiste != 0)
                    {
                        mensaje = "Una cuenta con el email: " + email + " y facilidad: " + txtCentro.Text + " ya existe.";
                        //this.coverScreen.Visible = false;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
                        return;
                    }
                    else
                    {
                        dsCARA.SPC_CENTRO(txtCentro.Text, idSlyc, "", email);

                        int pk_centro = dsCARA.VW_CENTROS_ADMINISTRADORES.Where(a => a.Email == email).Where(b => b.Centro == txtCentro.Text).Select(f => f.PK_Centro).First();

                        int pk_licencia = Convert.ToInt32(ddlLicencia.SelectedValue);

                        DateTime fechaExp = Convert.ToDateTime(txtFechaExp.Text);

                        dsCARA.SPC_ATAR_CENTRO_LICENCIA(pk_centro, pk_licencia, txtNumLicencia.Text, fechaExp);

                        dsCARA.SPC_SESION_ACTIVIDAD(PK_Sesion, "RegistroCentro", "C", Usuario.Id, pk_centro, null, null);

                        mensaje = "El registro de la facilidad fué correcto.";

                        ClientScript.RegisterStartupScript(this.GetType(), "Centro Registrado", "sweetAlertRef('Centro Registrado','" + mensaje + "','success','" + "App/Administracion/adminListaCentros.aspx" + "');", true);
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Usuario Registrado", "sweetAlert('Usuario Registrado','" + mensaje + "','success')", true);
                    }

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

                //this.coverScreen.Visible = false;

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
            }
           
        }

        protected void chk_Changed(object sender, EventArgs e)
        {
            CheckBox chkstatus = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chkstatus.NamingContainer;

            string email = string.Empty;

            if(chkstatus.Checked == true)
            {
                foreach (GridViewRow item in gvUsuariosASSMCAList.Rows)
                {
                    if(row.RowIndex != item.RowIndex)
                    {
                        //CheckBox chkrow = (CheckBox)item.FindControl("chkRegistrado");

                        //chkrow.Checked = false;
                        //chkrow.Enabled = false;

                    }
                }

                try
                {
                    using (CARAEntities dsCARA = new CARAEntities())
                    {
                        email = gvUsuariosASSMCAList.Rows[row.RowIndex].Cells[2].Text;

                        var usersList = dsCARA.VW_LISTA_USUARIOS_REGISTRADOS.Where(a => a.Email == email).DefaultIfEmpty().ToList();

                        gvUsuariosASSMCAList.DataSource = usersList;

                        gvUsuariosASSMCAList.DataBind();

                        CheckBox chkrow = (CheckBox)gvUsuariosASSMCAList.Rows[0].Cells[0].FindControl("chkRegistrado");

                        chkrow.Checked = true;

                        gvUsuariosASSMCAList.UseAccessibleHeader = true;
                        gvUsuariosASSMCAList.HeaderRow.TableSection = TableRowSection.TableHeader;
                        gvUsuariosASSMCAList.FooterRow.TableSection = TableRowSection.TableFooter;

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
            else
            {
                //    foreach (GridViewRow item in gvUsuariosASSMCAList.Rows)
                //    {
                //            CheckBox chkrow = (CheckBox)item.FindControl("chkRegistrado");

                //            chkrow.Enabled = true;
                //            chkrow.Checked = false;
                //    }

                //    gvUsuariosASSMCAList.UseAccessibleHeader = true;
                //    gvUsuariosASSMCAList.HeaderRow.TableSection = TableRowSection.TableHeader;
                //    gvUsuariosASSMCAList.FooterRow.TableSection = TableRowSection.TableFooter;

                PrepararGridView();
            }
        }
    }
}