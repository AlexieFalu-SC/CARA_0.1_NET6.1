using CARA_Draftv0._1.App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1.App.Pacientes
{
    public partial class frmVisualizar : System.Web.UI.Page
    {
        protected DatosInternos ca_paciente;
        protected string Centro, Nombre_Centro, Licencia;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CA_Paciente"] == null)
            {
                //Session["TipodeAlerta"] = ConstTipoAlerta.Danger;
                //Session["MensajeError"] = "Por favor seleccione el participante";
                //Session["Redirect"] = "Entrada.aspx";
                //Response.Redirect("Mensajes.aspx", false);
                Response.Redirect("~/App/Pacientes/frmconsulta.aspx", false);
                return;
            }
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Account/Login.aspx", false);
                return;
            }

            this.ca_paciente = (DatosInternos)this.Session["CA_Paciente"];

            Centro = this.Request.QueryString["centro"].ToString();

            Nombre_Centro = this.Session["NB_Centro"].ToString();
            Licencia = this.Session["PK_Centro_Licencia"].ToString();

            lblCentro.Text = Nombre_Centro + " - ";
            lblLicencia.Text = Licencia;

            if (!this.IsPostBack)
            {
                switch (Centro)
                {
                    case ("crear"):
                        this.btnRegistrar.Visible = true;
                        break;
                    case ("leer"):
                        this.btnRegistrar.Visible = false;
                        break;
                    default:
                        break;
                }

                this.lblIUP.Text = this.ca_paciente.PK_Paciente.ToString();
                this.lblExpediente.Text = this.ca_paciente.NR_Expediente.ToString();
                this.lblNacimiento.Text = this.ca_paciente.FE_Nacimiento.ToString("MMMM dd, yyyy");
                this.lblGrupoEtnico.Text = this.ca_paciente.DE_GrupoEtnico.ToString();

                this.lblRaza.Text = "";
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    List<SPR_RAZA_PACIENTE_Result> razas = dsCARA.SPR_RAZA_PACIENTE(this.ca_paciente.PK_Paciente).ToList();

                    if (razas != null)
                    {
                        foreach (var item in razas)
                        {
                            this.lblRaza.Text += dsCARA.CA_LKP_RAZA.Where(a => a.PK_Raza.Equals(item.FK_Raza)).Select(b => b.DE_Raza).SingleOrDefault() + ", ";
                        }
                    }
                }

                this.LeerEpisodios();
            }
        }

        protected void LeerEpisodios()
        {
            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    List<SPR_EPISODIOS_PACIENTE_Result> episodios = dsCARA.SPR_EPISODIOS_PACIENTE(this.ca_paciente.PK_Paciente).ToList();

                    gvEpisodios.PageIndex = 1 - 1;
                    gvEpisodios.DataSource = episodios;
                    gvEpisodios.DataBind();
                }
            }
            catch (Exception ex)
            {

                string mensaje = ex.InnerException.Message;
            }
        }

        protected void btnRegistrar_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("~/App/Perfiles/frmadmision.aspx?accion=crear");
        }

        protected void btnModificarPaciente_Click(object sender, System.EventArgs e)
        {
            Session["CA_Paciente"] = this.ca_paciente;
            Response.Redirect("~/App/Pacientes/frmEditar.aspx?accion=editar");
        }

        protected void lnkEpisodio_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            int PK_Episodio = Convert.ToInt32(btn.CommandArgument);

            Response.Redirect("~/App/Pacientes/frmPerfiles.aspx?pk_episodio="+ PK_Episodio.ToString());
        }
    }
}