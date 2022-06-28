using CARA_Draftv0._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1.App.Administracion
{
    public partial class adminEdicionFacilidad : System.Web.UI.Page
    {
        ApplicationDbContext context = new ApplicationDbContext();
        ApplicationUser Usuario = new ApplicationUser();
        protected string PK_Sesion;
        protected int pk_centro;
        protected void Page_Load(object sender, EventArgs e)
        {
            pk_centro = Convert.ToInt32(this.Request.QueryString["pk_centro"].ToString());
            Usuario = (ApplicationUser)Session["Usuario"];

            if (!this.IsPostBack)
            {
                SetUserInformation(pk_centro);
                //PrepararCentrosList();
            }
        }

        private void SetUserInformation(int pk_centro)
        {
            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    var centro = dsCARA.VW_CENTROS_ADMINISTRADORES.Where(a => a.PK_Centro == pk_centro).FirstOrDefault();

                    this.txtCentro.Text = centro.Centro;
                    this.txtIdSlyc.Text = "36E4B2DD-19B3-45B7-AF87-B25268668902";
                    this.lblNombrePrincipal.Text = centro.Registrado;
                    this.lblEmailPrincipal.Text = centro.Email;

                    var licenciasAtadas = dsCARA.VW_USUARIOS_CENTROS_LICENCIAS.Where(a => a.PK_Centro == pk_centro).Select(b => new { b.PK_Centro_Licencia, b.NB_Licencia, b.NR_Licencia, b.FE_Expiracion, b.NB_Categoria, b.CentroLicenciaEstatus }).Distinct().ToList();

                    gvUsuariosASSMCAList.DataSource = licenciasAtadas;

                    gvUsuariosASSMCAList.DataBind();

                    gvUsuariosASSMCAList.UseAccessibleHeader = true;
                    gvUsuariosASSMCAList.HeaderRow.TableSection = TableRowSection.TableHeader;
                    gvUsuariosASSMCAList.FooterRow.TableSection = TableRowSection.TableFooter;

                    var licencias = dsCARA.CA_LICENCIA.Select(r => new ListItem { Value = r.PK_Licencia.ToString(), Text = r.NB_Licencia }).ToList();

                    ddlLicencia.DataValueField = "Value";
                    ddlLicencia.DataTextField = "Text";
                    ddlLicencia.DataSource = licencias;
                    ddlLicencia.DataBind();
                    ddlLicencia.Items.Insert(0, new ListItem("", "0"));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            pk_centro = Convert.ToInt32(this.Request.QueryString["pk_centro"].ToString());
            Usuario = (ApplicationUser)Session["Usuario"];

            PK_Sesion = Session["PK_Sesion"].ToString();

            string mensaje = string.Empty;

            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    int pk_licencia = Convert.ToInt32(ddlLicencia.SelectedValue);

                    DateTime fechaExp = Convert.ToDateTime(txtFechaExp.Text);

                    dsCARA.SPC_ATAR_CENTRO_LICENCIA(pk_centro, pk_licencia, txtNumLicencia.Text, fechaExp);

                    dsCARA.SPC_SESION_ACTIVIDAD(PK_Sesion, "AtarLicencia", "C", Usuario.Id, pk_centro, null, null);

                    mensaje = "El registro de la licencia fué correcto.";

                    SetUserInformation(pk_centro);

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Licencia Atada ", "sweetAlert('Licencia Atada','" + mensaje + "','success')", true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnAtarLicencia_Click(object sender, EventArgs e)
        {
            pk_centro = Convert.ToInt32(this.Request.QueryString["pk_centro"].ToString());
            Usuario = (ApplicationUser)Session["Usuario"];

            PK_Sesion = Session["PK_Sesion"].ToString();

            string mensaje = string.Empty;

            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    int pk_licencia = Convert.ToInt32(ddlLicencia.SelectedValue);

                    DateTime fechaExp = Convert.ToDateTime(txtFechaExp.Text);

                    dsCARA.SPC_ATAR_CENTRO_LICENCIA(pk_centro, pk_licencia, txtNumLicencia.Text, fechaExp);

                    dsCARA.SPC_SESION_ACTIVIDAD(PK_Sesion, "AtarLicencia", "C", Usuario.Id, pk_centro, null, null);

                    mensaje = "El registro de la licencia fué correcto.";

                    SetUserInformation(pk_centro);

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Licencia Atada ", "sweetAlert('Licencia Atada','" + mensaje + "','success')", true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}