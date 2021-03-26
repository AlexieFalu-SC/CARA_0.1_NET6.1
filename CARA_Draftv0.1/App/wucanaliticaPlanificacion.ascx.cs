using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1.App
{
    public partial class wucanaliticaPlanificacion : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Account/Login.aspx", false);
                return;
            }

            if (!this.IsPostBack)
            {
                PrepararDropDownLists();
            }
        }

        private void PrepararDropDownLists()
        {
            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    lbxGenero.DataValueField = "PK_Genero";
                    lbxGenero.DataTextField = "DE_Genero";
                    lbxGenero.DataSource = dsCARA.CA_LKP_GENERO.ToList();
                    lbxGenero.DataBind();

                    lbxNivelSustancia.DataValueField = "PK_NivelSustancia";
                    lbxNivelSustancia.DataTextField = "DE_NivelSustancia";
                    lbxNivelSustancia.DataSource = dsCARA.CA_LKP_NIVEL_SUSTANCIA.ToList();
                    lbxNivelSustancia.DataBind();

                    lbxCentro.DataValueField = "PK_Centro";
                    lbxCentro.DataTextField = "NB_Centro";
                    lbxCentro.DataSource = dsCARA.CA_CENTRO.ToList();
                    lbxCentro.DataBind();

                    lbxFuenteReferido.DataValueField = "PK_FuenteReferido";
                    lbxFuenteReferido.DataTextField = "DE_FuenteReferido";
                    lbxFuenteReferido.DataSource = dsCARA.CA_LKP_FUENTE_REFERIDO.ToList();
                    lbxFuenteReferido.DataBind();

                    lbxMunicipios.DataValueField = "PK_Municipio";
                    lbxMunicipios.DataTextField = "DE_Municipio";
                    lbxMunicipios.DataSource = dsCARA.CA_LKP_MUNICIPIO.ToList();
                    lbxMunicipios.DataBind();


                    lbxGrupoEdades.Items.Insert(0, new ListItem("18-24", "18-24"));
                    lbxGrupoEdades.Items.Insert(1, new ListItem("25-44", "25-44"));
                    lbxGrupoEdades.Items.Insert(2, new ListItem("45-65", "45-65"));
                    lbxGrupoEdades.Items.Insert(3, new ListItem("65+", "65+"));

                    lbxSobredosis.Items.Insert(0, new ListItem("No", "No"));
                    lbxSobredosis.Items.Insert(1, new ListItem("Si", "Si"));

                    this.txtFechaDesde.Text = DateTime.Today.AddMonths(-6).ToString("yyyy-MM-dd");
                    this.txtFechaHasta.Text = DateTime.Today.ToString("yyyy-MM-dd");

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}